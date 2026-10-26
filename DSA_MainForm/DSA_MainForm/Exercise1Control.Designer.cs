namespace DSA_MainForm
{
    partial class Exercise1Control
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPush = new Button();
            btnPop = new Button();
            btnDisplay = new Button();
            btnPeek = new Button();
            textBoxInput = new TextBox();
            listBoxStack = new ListBox();
            IsEmpty = new Button();
            IsFull = new Button();
            SuspendLayout();
            // 
            // btnPush
            // 
            btnPush.Location = new Point(86, 244);
            btnPush.Name = "btnPush";
            btnPush.Size = new Size(94, 29);
            btnPush.TabIndex = 0;
            btnPush.Text = "PUSH";
            btnPush.UseVisualStyleBackColor = true;
            btnPush.Click += btnPush_Click;
            // 
            // btnPop
            // 
            btnPop.Location = new Point(186, 244);
            btnPop.Name = "btnPop";
            btnPop.Size = new Size(94, 29);
            btnPop.TabIndex = 1;
            btnPop.Text = "POP";
            btnPop.UseVisualStyleBackColor = true;
            btnPop.Click += btnPop_Click;
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(586, 244);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(94, 29);
            btnDisplay.TabIndex = 3;
            btnDisplay.Text = "DISPLAY";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnPeek
            // 
            btnPeek.Location = new Point(286, 244);
            btnPeek.Name = "btnPeek";
            btnPeek.Size = new Size(94, 29);
            btnPeek.TabIndex = 2;
            btnPeek.Text = "PEEK";
            btnPeek.UseVisualStyleBackColor = true;
            btnPeek.Click += btnPeek_Click;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(327, 297);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new Size(125, 27);
            textBoxInput.TabIndex = 10;
            // 
            // listBoxStack
            // 
            listBoxStack.BackColor = SystemColors.Window;
            listBoxStack.FormattingEnabled = true;
            listBoxStack.Location = new Point(315, 76);
            listBoxStack.Name = "listBoxStack";
            listBoxStack.Size = new Size(150, 128);
            listBoxStack.TabIndex = 11;
            // 
            // IsEmpty
            // 
            IsEmpty.Location = new Point(486, 244);
            IsEmpty.Name = "IsEmpty";
            IsEmpty.Size = new Size(94, 29);
            IsEmpty.TabIndex = 12;
            IsEmpty.Text = "IsEmpty";
            IsEmpty.UseVisualStyleBackColor = true;
            IsEmpty.Click += button1_Click;
            // 
            // IsFull
            // 
            IsFull.Location = new Point(386, 244);
            IsFull.Name = "IsFull";
            IsFull.Size = new Size(94, 29);
            IsFull.TabIndex = 13;
            IsFull.Text = "IsFull";
            IsFull.UseVisualStyleBackColor = true;
            IsFull.Click += IsFull_Click;
            // 
            // Exercise1Control
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Size = new Size(800, 450);
            Controls.Add(IsFull);
            Controls.Add(IsEmpty);
            Controls.Add(listBoxStack);
            Controls.Add(textBoxInput);
            Controls.Add(btnDisplay);
            Controls.Add(btnPeek);
            Controls.Add(btnPop);
            Controls.Add(btnPush);
            Name = "Exercise1Control";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPush;
        private Button btnPop;
        private Button btnDisplay;
        private Button btnPeek;
        private TextBox textBoxInput;
        private ListBox listBoxStack;
        private Button IsEmpty;
        private Button IsFull;
    }
}
