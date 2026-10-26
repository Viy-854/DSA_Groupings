using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Exercise3
{
    public partial class Form1 : Form
    {
        private StackModel.Step[] steps = null;
        private int stepIndex = 0; // next step to execute (0-based)
        private int conversionBase = 2;
        private System.Windows.Forms.Timer playTimer;

        public Form1()
        {
            InitializeComponent();
            playTimer = new System.Windows.Forms.Timer();
            playTimer.Tick += PlayTimer_Tick;
            sldSpeed.Minimum = 25; sldSpeed.Maximum = 200; sldSpeed.Value = 100;
            UpdateSpeedLabel();
            UpdateStateIdle();
        }

private void PlayTimer_Tick(object sender, EventArgs e)
        {
            DoNextStep();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (!ValidateInput(out int n)) return;
            conversionBase = cboBase.SelectedIndex == 1 ? 8 : 2;
            steps = StackModel.CreateSteps(n, conversionBase).ToArray();
            stepIndex = 0;
            dgvLog.Rows.Clear();
            dgvLog.Columns[2].HeaderText = "÷" + conversionBase;
            pnlStack.Controls.Clear();
            lblPopSeq.Text = string.Empty;
            lblResult.Text = string.Empty;
            lblStatus.Text = "Starting...";

            // populate log with push rows (we will mark during execution)
            int stepNum = 1;
            foreach (var s in steps)
            {
                if (s.Op == StackModel.StepOp.Push)
                {
                    dgvLog.Rows.Add(stepNum.ToString(), s.N.ToString(), conversionBase.ToString(), s.Q.ToString(), s.R.ToString(), "push");
                    stepNum++;
                }
                else
                {
                    dgvLog.Rows.Add("", "", "", "", "", "pop");
                }
            }

            if (rdoInstant.Checked)
            {
                // execute all steps immediately
                for (int i = 0; i < steps.Length; i++) ExecuteStep(steps[i]);
                Finish();
            }
            else
            {
                UpdateStateDividing();
                HighlightLogRow(0);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            playTimer.Stop();
            steps = null;
            stepIndex = 0;
            dgvLog.Rows.Clear();
            pnlStack.Controls.Clear();
            lblPopSeq.Text = string.Empty;
            lblResult.Text = string.Empty;
            lblStatus.Text = "Reset";
            txtDecimal.Text = string.Empty;
            lblError.Text = string.Empty;
            UpdateStateIdle();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DoNextStep();
        }

        private void DoNextStep()
        {
            if (steps == null || stepIndex >= steps.Length) return;
            var s = steps[stepIndex];
            ExecuteStep(s);
            stepIndex++;
            HighlightLogRow(stepIndex);
            if (stepIndex >= steps.Length)
            {
                Finish();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (steps == null) return;
            // rebuild view up to stepIndex-1
            int target = Math.Max(0, stepIndex - 1);
            RebuildViewUpTo(target);
            stepIndex = target;
            HighlightLogRow(stepIndex);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (steps == null) return;
            playTimer.Interval = (int)(600.0 * 100 / sldSpeed.Value);
            playTimer.Start();
            UpdateStatePlaying();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            playTimer.Stop();
            UpdateStateDividing();
        }

        private void sldSpeed_Scroll(object sender, EventArgs e)
        {
            UpdateSpeedLabel();
            if (playTimer.Enabled) playTimer.Interval = (int)(600.0 * 100 / sldSpeed.Value);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResult.Text)) Clipboard.SetText(lblResult.Text.Replace("₂", "").Replace("₈", ""));
        }

        private bool ValidateInput(out int n)
        {
            n = 0;
            var txt = txtDecimal.Text.Trim();
            if (string.IsNullOrEmpty(txt))
            {
                lblError.Text = "Enter a decimal number."; return false;
            }
            if (!txt.All(char.IsDigit)) { lblError.Text = "Only whole digits allowed."; return false; }
            if (!int.TryParse(txt, out n)) { lblError.Text = "Number too large (max 2,147,483,647)."; return false; }
            if (n < 0) { lblError.Text = "Enter a non-negative integer."; return false; }
            lblError.Text = string.Empty;
            return true;
        }

        private void ExecuteStep(StackModel.Step s)
        {
            if (s.Op == StackModel.StepOp.Push)
            {
                // create a label for cell
                var lbl = new Label();
                lbl.Text = s.R.ToString();
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = s.R != 0 ? Color.LightBlue : Color.LightGray;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Size = new Size(64, 40);
                // insert at top (controls collection uses Z-order; we position manually)
                // position cells bottom-up; compute y based on existing count
                int count = pnlStack.Controls.Count;
                int x = 10; int y = pnlStack.Height - (count + 1) * (lbl.Height + 6) - 10;
                lbl.Location = new Point(x, Math.Max(6, y));
                pnlStack.Controls.Add(lbl);
                lbl.BringToFront();
                lbl.Tag = "cell";
                lbl.AccessibleName = "stackCell";
                lblAccessibleUpdate();
                lblStatus.Text = $"Step: push {s.R} (n={s.N} -> q={s.Q})";
            }
            else if (s.Op == StackModel.StepOp.Pop)
            {
                // pop top cell
                var top = pnlStack.Controls.Cast<Control>().Where(c => c.Tag as string == "cell").OrderBy(c => c.Location.Y).FirstOrDefault();
                if (top != null)
                {
                    string bit = top.Text;
                    lblPopSeq.Text = string.IsNullOrEmpty(lblPopSeq.Text) ? bit : lblPopSeq.Text + " " + bit;
                    pnlStack.Controls.Remove(top);
                    top.Dispose();
                    lblStatus.Text = $"Pop → {bit}";
                }
            }
        }

        private void RebuildViewUpTo(int targetStepIndex)
        {
            pnlStack.Controls.Clear();
            lblPopSeq.Text = string.Empty;
            lblResult.Text = string.Empty;
            for (int i = 0; i < targetStepIndex; i++)
            {
                ExecuteStep(steps[i]);
            }
        }

        private void Finish()
        {
            playTimer.Stop();
            // collect popped bits as final result; if not popped yet, simulate pops to build result
            if (string.IsNullOrEmpty(lblPopSeq.Text))
            {
                // pop remaining
                var cells = pnlStack.Controls.Cast<Control>().Where(c => c.Tag as string == "cell").OrderBy(c => c.Location.Y).ToList();
                var bits = cells.Select(c => c.Text).Reverse();
                lblResult.Text = string.Join("", bits) + (conversionBase == 2 ? "₂" : "₈");
                lblStatus.Text = "Done — result ready.";
            }
            else
            {
                var bits = lblPopSeq.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                lblResult.Text = string.Join("", bits) + (conversionBase == 2 ? "₂" : "₈");
                lblStatus.Text = "Done — result ready.";
            }
            UpdateStateDone();
        }

        private void HighlightLogRow(int rowIndex)
        {
            for (int i = 0; i < dgvLog.Rows.Count; i++)
            {
                var r = dgvLog.Rows[i];
                r.DefaultCellStyle.BackColor = i == rowIndex ? Color.Khaki : Color.White;
            }
        }

        private void UpdateSpeedLabel()
        {
            lblSpeed.Text = (sldSpeed.Value / 100.0).ToString("0.00") + "x";
        }

        private void UpdateStateIdle()
        {
            btnConvert.Enabled = true; btnReset.Enabled = true; cboBase.Enabled = true;
            btnPrev.Enabled = false; btnNext.Enabled = false; btnPlay.Enabled = false; btnPause.Enabled = false; sldSpeed.Enabled = false; btnCopy.Enabled = false;
        }
        private void UpdateStateDividing()
        {
            btnConvert.Enabled = false; btnReset.Enabled = true; cboBase.Enabled = false;
            btnPrev.Enabled = true; btnNext.Enabled = true; btnPlay.Enabled = true; btnPause.Enabled = true; sldSpeed.Enabled = true; btnCopy.Enabled = false;
        }
        private void UpdateStatePlaying()
        {
            btnPlay.Enabled = false; btnPause.Enabled = true;
        }
        private void UpdateStateDone()
        {
            btnConvert.Enabled = true; btnReset.Enabled = true; btnCopy.Enabled = true; cboBase.Enabled = true;
            btnPrev.Enabled = false; btnNext.Enabled = false; btnPlay.Enabled = false; btnPause.Enabled = false; sldSpeed.Enabled = false;
        }

        private void lblAccessibleUpdate()
        {
            // expose stack size
            int size = pnlStack.Controls.Cast<Control>().Count(c => c.Tag as string == "cell");
            lblStackSize.Text = $"size: {size}";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // keyboard shortcuts: Enter = Convert/Next, Esc = Reset, Space = Play/Pause, Left/Right = Prev/Next
            if (keyData == Keys.Enter)
            {
                if (steps == null) btnConvert.PerformClick(); else btnNext.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                btnReset.PerformClick(); return true;
            }
            if (keyData == Keys.Space)
            {
                if (playTimer.Enabled) btnPause.PerformClick(); else btnPlay.PerformClick(); return true;
            }
            if (keyData == Keys.Left)
            {
                btnPrev.PerformClick(); return true;
            }
            if (keyData == Keys.Right)
            {
                btnNext.PerformClick(); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
