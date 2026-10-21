using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace Exercise2;

public class PostfixEvaluator
{
    private static readonly Dictionary<string, int> Prec = new()
    {
        ["+"] = 1, ["-"] = 1,
        ["*"] = 2, ["/"] = 2,
        ["$"] = 3
    };

    public DataTable Steps { get; } = CreateStepsTable();

    private static DataTable CreateStepsTable()
    {
        var table = new DataTable("Steps");
        table.Columns.Add("Operator Stack", typeof(string));
        table.Columns.Add("Postfix Output", typeof(string));
        return table;
    }

    public string Evaluate(string expression)
    {
        Steps.Clear();
        List<string> postfix = ToPostfixCore(Tokenize(expression));
        EvaluatePostfix(postfix);

        return string.Join(" ", postfix);
    }

    public List<string> ToPostfix(string expression)
    {
        Steps.Clear();
        return ToPostfixCore(Tokenize(expression));
    }

    public List<string> Tokenize(string input)
    {
        if (input is null)
            throw new ArgumentException("Expression is null");

        var tokens = new List<string>();
        var number = new StringBuilder();

        void FlushNumber()
        {
            if (number.Length > 0)
            {
                tokens.Add(number.ToString());
                number.Clear();
            }
        }

        foreach (char c in input)
        {
            if (char.IsDigit(c) || c == '.')
            {
                number.Append(c);
            }
            else if (char.IsWhiteSpace(c))
            {
                FlushNumber();
            }
            else
            {
                FlushNumber();
                tokens.Add(c.ToString());
            }
        }
        FlushNumber();

        if (tokens.Count == 0)
            throw new ArgumentException("Expression is empty");

        return tokens;
    }

    private List<string> ToPostfixCore(List<string> tokens)
    {
        var output = new List<string>();
        var ops = new Stack<string>();

        void Log() => Steps.Rows.Add(Show(ops), string.Join(" ", output));

        foreach (string t in tokens)
        {
            if (Prec.ContainsKey(t))
            {
                while (ops.Count > 0 && Prec.ContainsKey(ops.Peek()))
                {
                    int top = Prec[ops.Peek()];
                    int cur = Prec[t];
                    bool rightAssoc = t == "$";

                    if (top > cur || (top == cur && !rightAssoc))
                    {
                        output.Add(ops.Pop());
                        Log();
                    }
                    else break;
                }
                ops.Push(t);
                Log();
            }
            else if (t == "(")
            {
                ops.Push(t);
                Log();
            }
            else if (t == ")")
            {
                while (ops.Count > 0 && ops.Peek() != "(")
                {
                    output.Add(ops.Pop());
                    Log();
                }

                if (ops.Count == 0)
                    throw new ArgumentException("Unbalanced )");

                ops.Pop(); // discard "("
                Log();
            }
            else
            {
                output.Add(t);
                Log();
            }
        }

        while (ops.Count > 0)
        {
            string op = ops.Pop();
            if (op == "(")
                throw new ArgumentException("Unbalanced (");
            output.Add(op);
            Log();
        }

        return output;
    }

    private double EvaluatePostfix(List<string> postfix)
    {
        var operands = new Stack<double>();

        foreach (string t in postfix)
        {
            if (Prec.ContainsKey(t))
            {
                if (operands.Count < 2)
                    throw new ArgumentException($"Malformed expression: missing operand for '{t}'");

                double b = operands.Pop();
                double a = operands.Pop();

                switch (t)
                {
                    case "+": operands.Push(a + b); break;
                    case "-": operands.Push(a - b); break;
                    case "*": operands.Push(a * b); break;
                    case "/":
                        if (b == 0)
                            throw new DivideByZeroException("Division by zero");
                    operands.Push(a / b);
                    break;
                    case "$": operands.Push(Math.Pow(a, b)); break;
                    default:
                        throw new ArgumentException("Unknown operator: " + t);
                }
            }
            else
            {
                if (!double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    throw new ArgumentException("Invalid operand: " + t);
                operands.Push(value);
            }
        }

        if (operands.Count != 1)
            throw new ArgumentException("Malformed expression");

        return operands.Pop();
    }

    private static string Show(Stack<string> stack)
    {
        string[] items = stack.ToArray();
        Array.Reverse(items);
        return string.Join(" ", items);
    }
}
