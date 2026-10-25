namespace DSA_MainForm
{
    partial class Exercise2Control
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

        private void InitializeComponent()
        {

            inputGroup = new GroupBox();
            outputGroup = new GroupBox();
            flowLayout = new FlowLayoutPanel();
            lblResult = new Label();

            expressionInput = new TextBox();
            evaluateBtn = new Button();
            clearBtn = new Button();

            evaluationTable = new DataGridView();

            SuspendLayout();
            // 
            // Exercise2Control
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Size = new System.Drawing.Size(900, 450);
            Name = "Exercise2Control";

            inputGroup.Size = new Size(320,100);
            inputGroup.Location = new Point(10,10);
            inputGroup.Name = "inputGroup";
            inputGroup.Text = "Expression";

            flowLayout.Name = "flowLayout";
            flowLayout.Location = new Point(10,20);
            flowLayout.Size = new Size(300,80);
            flowLayout.TabIndex = 0;

            expressionInput.Size = new Size(250,50);
            expressionInput.Location = new Point(20,10);
            expressionInput.Name = "expressionInput";

            evaluateBtn.Size = new Size(120,30);
            evaluateBtn.Name = "evaluateBtn";
            evaluateBtn.Text = "Evaluate";
            evaluateBtn.Click += evaluateExpression;

            clearBtn.Size = new Size(120,30);
            clearBtn.Name = "clearBtn";
            clearBtn.Text = "Clear";


            flowLayout.Controls.Add(expressionInput);
            flowLayout.Controls.Add(evaluateBtn);
            flowLayout.Controls.Add(clearBtn);
            inputGroup.Controls.Add(flowLayout);

            lblResult.Size = new Size(200,30);
            lblResult.Location = new Point(10, 200);
            lblResult.Name = "lblResult";

            outputGroup.Size = new Size(300,400);
            outputGroup.Location = new Point(360, 10);
            outputGroup.Name = "outputGroup";
            outputGroup.Text = "Output";

            evaluationTable.Size = new Size(280, 380);
            evaluationTable.Location = new Point(10,20);
            evaluationTable.MultiSelect = false;
            evaluationTable.Name = "evaluationTable";
            evaluationTable.ReadOnly = true;

            outputGroup.Controls.Add(evaluationTable);

            Controls.Add(inputGroup);
            Controls.Add(lblResult);
            Controls.Add(outputGroup);

            ResumeLayout(false);
        }

        private FlowLayoutPanel flowLayout;
        private GroupBox inputGroup;
        private GroupBox outputGroup;

        private TextBox expressionInput;
        private Button evaluateBtn;
        private Button clearBtn;

        private DataGridView evaluationTable;
        private Label lblResult;

        #endregion
    }
}
