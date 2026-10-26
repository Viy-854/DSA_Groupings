using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace DSA_MainForm;

public class PostfixEvaluator
{
    private static readonly HashSet<string> Operators = new() { "+", "-", "*", "/", "$" };

    /// <summary>Trace of the last evaluation (operand stack shown bottom -> top).</summary>
    public DataTable Steps { get; } = CreateStepsTable();

    private static DataTable CreateStepsTable()
    {
        var table = new DataTable("Steps");
        table.Columns.Add("Token", typeof(string));
        table.Columns.Add("Operand Stack", typeof(string));
        return table;
    }

    /// <summary>Evaluates a postfix expression, e.g. "6244+-*" or "6 2 4 4 + - *".</summary>
    /// <exception cref="DivideByZeroException">Division by zero.</exception>
    /// <exception cref="ArgumentException">Malformed or invalid expression.</exception>
    public double Evaluate(string postfix)
    {
        Steps.Clear();
        var operands = new Stack<double>();

        foreach (string t in Tokenize(postfix))
        {
            if (Operators.Contains(t))
            {
                if (operands.Count < 2)
                    throw new ArgumentException($"Malformed expression: missing operand for '{t}'");

                double b = operands.Pop(); // right operand
                double a = operands.Pop(); // left operand

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
                }
            }
            else
            {
                if (!double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    throw new ArgumentException("Invalid operand: " + t);
                operands.Push(value);
            }

            Steps.Rows.Add(t, Show(operands));
        }

        if (operands.Count != 1)
            throw new ArgumentException("Malformed expression");

        return operands.Pop();
    }

    /// <summary>
    /// If the input contains spaces, tokens are split on whitespace (multi-digit numbers allowed).
    /// Otherwise every character is its own token (single-digit operands, e.g. "6244+-*").
    /// </summary>
    public List<string> Tokenize(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Expression is empty");

        input = input.Trim();
        var tokens = new List<string>();

        if (input.Any(char.IsWhiteSpace))
        {
            tokens.AddRange(input.Split((char[])null, StringSplitOptions.RemoveEmptyEntries));
        }
        else
        {
            foreach (char c in input)
                tokens.Add(c.ToString());
        }

        return tokens;
    }

    private static string Show(Stack<double> stack)
    {
        double[] items = stack.ToArray();
        Array.Reverse(items);
        return string.Join(" ", Array.ConvertAll(items, d => d.ToString(CultureInfo.InvariantCulture)));
    }
}
