using System;
using System.Windows.Forms;

namespace DSA_MainForm
{
    public partial class Exercise1Control : UserControl
    {
        private Stack myStack;

        public Exercise1Control()
        {
            InitializeComponent();
            myStack = new Stack(5);
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInput.Text, out int number))
            {
                if (myStack.isFull())
                {
                    MessageBox.Show("Stack is full. Cannot push item.");
                }
                else
                {
                    myStack.Push(number);
                    // RefreshStackDisplay();
                }
            }
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            if (myStack.isEmpty())
            {
                Log("Stack is empty. Nothing to pop.");
                return;
            }
            myStack.Pop();
            // RefreshStackDisplay();
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Peek: top is " + myStack.Peek());
            }
            catch (InvalidOperationException ex)
            {
                Log(ex.Message);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            RefreshStackDisplay();
        }

        private void RefreshStackDisplay()
        {
            if (listBoxStack != null)
            {
                listBoxStack.Items.Clear();

                int[] currentItems = myStack.Display();
                foreach (int item in currentItems)
                {
                    listBoxStack.Items.Add(item);
                }
            }
        }

        private void Log(string message)
        {
            MessageBox.Show(message);
        }

        // IsEmpty button
        private void button1_Click(object sender, EventArgs e)
        {
            Log("isEmpty() = " + myStack.isEmpty());
        }

        // IsFull button
        private void IsFull_Click(object sender, EventArgs e)
        {
            Log("isFull() = " + myStack.isFull());
        }
    }
}
