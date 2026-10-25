using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DSA
{
    public partial class Form1 : Form
    {
        private Stack myStack;
        public Form1()
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

                }
            }
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            myStack.Pop();

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
            // CHANGE "listBoxStack" to match the actual Name of your ListBox control
            if (listBoxStack != null)
            {
                listBoxStack.Items.Clear(); // Clear old items

                int[] currentItems = myStack.Display(); // Get active items array
                foreach (int item in currentItems)
                {
                    listBoxStack.Items.Add(item); // Add them to the visual list
                }
            }
        }

        // Add this method inside your Form1 class
        private void Log(string message)
        {
            MessageBox.Show(message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("isEmpty() = " + myStack.isEmpty());
        }

        private void IsFull_Click(object sender, EventArgs e)
        {
            Log("isFull() = " + myStack.isFull());
        }

        }
    }
