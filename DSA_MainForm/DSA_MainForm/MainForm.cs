using System;
using System.Windows.Forms;

namespace DSA_MainForm
{
    public partial class MainForm : Form
    {
        // Each exercise is created ONCE, so it keeps its data when you switch away and back.
        private readonly Exercise1Control exercise1 = new Exercise1Control();
        private readonly Exercise2Control exercise2 = new Exercise2Control();
        private readonly Exercise3Control exercise3 = new Exercise3Control();
        private readonly Exercise4 exercise4 = new Exercise4();

        public MainForm()
        {
            InitializeComponent();
            ShowControl(exercise1);   // show Exercise 1 when the app starts
        }

        private void ShowControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);
        }

        private void btnExercise1_Click(object sender, EventArgs e) => ShowControl(exercise1);
        private void btnExercise2_Click(object sender, EventArgs e) => ShowControl(exercise2);
        private void btnExercise3_Click(object sender, EventArgs e) => ShowControl(exercise3);
        private void btnExercise4_Click(object sender, EventArgs e) => ShowControl(exercise4);
    }
}
