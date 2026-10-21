using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Exercise2
{
    public partial class Form1 : Form
    {

        private readonly PostfixEvaluator _handler = new PostfixEvaluator();

        public Form1()
        {

            InitializeComponent();

        }

        public void evaluateExpression(object sender, EventArgs e)
        {
            try
            {
                string result = _handler.Evaluate(expressionInput.Text);
                lblResult.Text = "Final expression: " + result;
            }
            catch (DivideByZeroException ex)
            {
                lblResult.Text = "Error: " + ex.Message;
            }
            catch (ArgumentException ex)
            {
                lblResult.Text = "Invalid expression: " + ex.Message;
            }
            finally
            {
                // Show the trace even when an error occurs (the last row is the error).
                evaluationTable.DataSource = _handler.Steps;
            }
        }
    }
}
