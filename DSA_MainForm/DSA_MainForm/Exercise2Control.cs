using System;
using System.Windows.Forms;

namespace DSA_MainForm
{
    public partial class Exercise2Control : UserControl
    {
        private readonly PostfixEvaluator _handler = new PostfixEvaluator();

        public Exercise2Control()
        {
            InitializeComponent();
        }

        public void evaluateExpression(object sender, EventArgs e)
        {
            try
            {
                double result = _handler.Evaluate(expressionInput.Text);
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

        private void clearAll(object sender, EventArgs e)
        {

            expressionInput.Text = "";
            lblResult.Text = "";

        }
    }
}
