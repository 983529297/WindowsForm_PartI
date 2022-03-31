
namespace _homeWork
{
    partial class SetUpForm
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
            this._button3 = new System.Windows.Forms.Button();
            this._button4 = new System.Windows.Forms.Button();
            this._button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _button3
            // 
            this._button3.Font = new System.Drawing.Font("新細明體", 25F);
            this._button3.Location = new System.Drawing.Point(12, 12);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(776, 145);
            this._button3.TabIndex = 0;
            this._button3.Text = "Course Selecting System";
            this._button3.UseVisualStyleBackColor = true;
            this._button3.Click += new System.EventHandler(this.Button1Click);
            // 
            // _button4
            // 
            this._button4.Font = new System.Drawing.Font("新細明體", 25F);
            this._button4.Location = new System.Drawing.Point(12, 163);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(776, 145);
            this._button4.TabIndex = 1;
            this._button4.Text = "Course Management System";
            this._button4.UseVisualStyleBackColor = true;
            this._button4.Click += new System.EventHandler(this.Button2Click);
            // 
            // _button5
            // 
            this._button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._button5.Font = new System.Drawing.Font("新細明體", 25F);
            this._button5.Location = new System.Drawing.Point(586, 334);
            this._button5.Name = "_button5";
            this._button5.Size = new System.Drawing.Size(202, 104);
            this._button5.TabIndex = 2;
            this._button5.Text = "Exit";
            this._button5.UseVisualStyleBackColor = true;
            this._button5.Click += new System.EventHandler(this.Button3Click);
            // 
            // SetUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._button5);
            this.Controls.Add(this._button4);
            this.Controls.Add(this._button3);
            this.Name = "SetUpForm";
            this.Text = "SetUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _button3;
        private System.Windows.Forms.Button _button4;
        private System.Windows.Forms.Button _button5;
    }
}