namespace Exercise3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdoInstant;
        private System.Windows.Forms.RadioButton rdoStep;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TrackBar sldSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Panel pnlStack;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Label lblPopSeq;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblStackSize;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.rdoInstant = new System.Windows.Forms.RadioButton();
            this.rdoStep = new System.Windows.Forms.RadioButton();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.sldSpeed = new System.Windows.Forms.TrackBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pnlStack = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.lblPopSeq = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblStackSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sldSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(12, 12);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(200, 20);
            this.txtDecimal.TabIndex = 0;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(220, 10);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(300, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rdoInstant
            // 
            this.rdoInstant.AutoSize = true;
            this.rdoInstant.Location = new System.Drawing.Point(12, 40);
            this.rdoInstant.Name = "rdoInstant";
            this.rdoInstant.Size = new System.Drawing.Size(60, 17);
            this.rdoInstant.TabIndex = 3;
            this.rdoInstant.Text = "Instant";
            this.rdoInstant.Checked = true;
            this.rdoInstant.UseVisualStyleBackColor = true;
            // 
            // rdoStep
            // 
            this.rdoStep.AutoSize = true;
            this.rdoStep.Location = new System.Drawing.Point(80, 40);
            this.rdoStep.Name = "rdoStep";
            this.rdoStep.Size = new System.Drawing.Size(96, 17);
            this.rdoStep.TabIndex = 4;
            this.rdoStep.Text = "Step-by-step";
            this.rdoStep.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 70);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 23);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "◀ Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(68, 70);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next ▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(124, 70);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(50, 23);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.Text = "⏵ Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(180, 70);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(50, 23);
            this.btnPause.TabIndex = 8;
            this.btnPause.Text = "⏸ Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // sldSpeed
            // 
            this.sldSpeed.Location = new System.Drawing.Point(240, 70);
            this.sldSpeed.Name = "sldSpeed";
            this.sldSpeed.Size = new System.Drawing.Size(150, 45);
            this.sldSpeed.TabIndex = 9;
            this.sldSpeed.Scroll += new System.EventHandler(this.sldSpeed_Scroll);
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(400, 70);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(60, 23);
            this.lblSpeed.Text = "1.00x";
            // 
            // pnlStack
            // 
            this.pnlStack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStack.Location = new System.Drawing.Point(12, 110);
            this.pnlStack.Name = "pnlStack";
            this.pnlStack.Size = new System.Drawing.Size(200, 230);
            this.pnlStack.TabIndex = 10;
            // 
            // dgvLog
            // 
            this.dgvLog.Location = new System.Drawing.Point(230, 110);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.Size = new System.Drawing.Size(540, 200);
            this.dgvLog.TabIndex = 11;
            this.dgvLog.ColumnCount = 6;
            this.dgvLog.Columns[0].Name = "Step";
            this.dgvLog.Columns[1].Name = "n";
            this.dgvLog.Columns[2].Name = "÷2";
            this.dgvLog.Columns[3].Name = "q";
            this.dgvLog.Columns[4].Name = "r";
            this.dgvLog.Columns[5].Name = "Op";
            // 
            // lblPopSeq
            // 
            this.lblPopSeq.Location = new System.Drawing.Point(12, 350);
            this.lblPopSeq.Name = "lblPopSeq";
            this.lblPopSeq.Size = new System.Drawing.Size(760, 23);
            this.lblPopSeq.Text = "Pop sequence:";
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(12, 380);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(300, 23);
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblResult.Text = "RESULT: " ;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(320, 380);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(420, 380);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(350, 23);
            this.lblStatus.Text = "Status: Idle";
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(12, 95);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(400, 13);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            // 
            // lblStackSize
            // 
            this.lblStackSize.Location = new System.Drawing.Point(12, 340);
            this.lblStackSize.Name = "lblStackSize";
            this.lblStackSize.Size = new System.Drawing.Size(100, 13);
            this.lblStackSize.Text = "size: 0";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.lblStackSize);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblPopSeq);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.pnlStack);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.sldSpeed);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.rdoStep);
            this.Controls.Add(this.rdoInstant);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtDecimal);
            this.Name = "Form1";
            this.Text = "Decimal → Binary Converter (Stack Visualizer)";
            ((System.ComponentModel.ISupportInitialize)(this.sldSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
