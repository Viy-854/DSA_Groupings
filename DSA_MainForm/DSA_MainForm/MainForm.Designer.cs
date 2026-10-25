namespace DSA_MainForm
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlNav = new Panel();
            btnExercise1 = new Button();
            btnExercise2 = new Button();
            btnExercise3 = new Button();
            pnlContainer = new Panel();
            pnlNav.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNav
            // 
            pnlNav.Controls.Add(btnExercise3);
            pnlNav.Controls.Add(btnExercise2);
            pnlNav.Controls.Add(btnExercise1);
            pnlNav.Dock = DockStyle.Top;
            pnlNav.Location = new Point(0, 0);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(940, 50);
            pnlNav.TabIndex = 0;
            // 
            // btnExercise1
            // 
            btnExercise1.Location = new Point(12, 8);
            btnExercise1.Name = "btnExercise1";
            btnExercise1.Size = new Size(140, 34);
            btnExercise1.TabIndex = 0;
            btnExercise1.Text = "Exercise 1";
            btnExercise1.UseVisualStyleBackColor = true;
            btnExercise1.Click += btnExercise1_Click;
            // 
            // btnExercise2
            // 
            btnExercise2.Location = new Point(158, 8);
            btnExercise2.Name = "btnExercise2";
            btnExercise2.Size = new Size(140, 34);
            btnExercise2.TabIndex = 1;
            btnExercise2.Text = "Exercise 2";
            btnExercise2.UseVisualStyleBackColor = true;
            btnExercise2.Click += btnExercise2_Click;
            // 
            // btnExercise3
            // 
            btnExercise3.Location = new Point(304, 8);
            btnExercise3.Name = "btnExercise3";
            btnExercise3.Size = new Size(140, 34);
            btnExercise3.TabIndex = 2;
            btnExercise3.Text = "Exercise 3";
            btnExercise3.UseVisualStyleBackColor = true;
            btnExercise3.Click += btnExercise3_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 50);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(940, 550);
            pnlContainer.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 600);
            Controls.Add(pnlContainer);
            Controls.Add(pnlNav);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DSA Exercises";
            pnlNav.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNav;
        private Button btnExercise1;
        private Button btnExercise2;
        private Button btnExercise3;
        private Panel pnlContainer;
    }
}
