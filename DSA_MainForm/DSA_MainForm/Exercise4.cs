using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DSA_MainForm;

public partial class Exercise4 : UserControl
{
        private Queue myQueue;

        public Exercise4()
        {

                InitializeComponent();
                myQueue = new Queue();

        }
        private void btnPush_Click(object sender, EventArgs e)
        {
                if (int.TryParse(textBoxInput.Text, out int number))
                {
                        myQueue.enqueue(number);
                }
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
                if (myQueue.isEmpty())
                {
                        Log("Queue is empty. Nothing to dequeue.");
                        return;
                }
                myQueue.dequeue();
                // RefreshStackDisplay();
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
                try
                {
                        Log("Item at the front is: " + myQueue.Peek());
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

                        int[] currentItems = myQueue.Display();
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
                Log("isEmpty() = " + myQueue.isEmpty());
        }

        // IsFull button
        private void IsFull_Click(object sender, EventArgs e)
        {
                Log("Item at rear is " + myQueue.getRear());
        }
}


