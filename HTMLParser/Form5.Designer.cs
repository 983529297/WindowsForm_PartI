
namespace _homeWork
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this._label1 = new System.Windows.Forms.Label();
            this._progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // _label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(9, 9);
            this._label1.Name = "_label1";
            this._label1.Size = new System.Drawing.Size(109, 15);
            this._label1.TabIndex = 0;
            this._label1.Text = "正在載入課程...";
            this._label1.TextChanged += new System.EventHandler(this.ChangeLabel1Text);
            // 
            // _progressBar1
            // 
            this._progressBar1.ForeColor = System.Drawing.Color.LimeGreen;
            this._progressBar1.Location = new System.Drawing.Point(12, 41);
            this._progressBar1.Name = "_progressBar1";
            this._progressBar1.Size = new System.Drawing.Size(437, 50);
            this._progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._progressBar1.TabIndex = 1;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 103);
            this.Controls.Add(this._progressBar1);
            this.Controls.Add(this._label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Shown += new System.EventHandler(this.ShowForm5);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.ProgressBar _progressBar1;
    }
}