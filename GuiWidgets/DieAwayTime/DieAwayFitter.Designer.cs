namespace GuiWidgets.DieAwayTime
{
    partial class DieAwayFitter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTwoExponent = new System.Windows.Forms.RadioButton();
            this.rbSingleExponent = new System.Windows.Forms.RadioButton();
            this.inRsquared = new GuiWidgets.InputNumber();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTwoExponent);
            this.groupBox1.Controls.Add(this.rbSingleExponent);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Die Away Fit";
            // 
            // rbTwoExponent
            // 
            this.rbTwoExponent.AutoSize = true;
            this.rbTwoExponent.Location = new System.Drawing.Point(114, 19);
            this.rbTwoExponent.Name = "rbTwoExponent";
            this.rbTwoExponent.Size = new System.Drawing.Size(99, 17);
            this.rbTwoExponent.TabIndex = 1;
            this.rbTwoExponent.TabStop = true;
            this.rbTwoExponent.Text = "Two Exponents";
            this.rbTwoExponent.UseVisualStyleBackColor = true;
            this.rbTwoExponent.CheckedChanged += new System.EventHandler(this.rbTwoExponent_CheckedChanged);
            // 
            // rbSingleExponent
            // 
            this.rbSingleExponent.AutoSize = true;
            this.rbSingleExponent.Location = new System.Drawing.Point(6, 19);
            this.rbSingleExponent.Name = "rbSingleExponent";
            this.rbSingleExponent.Size = new System.Drawing.Size(102, 17);
            this.rbSingleExponent.TabIndex = 0;
            this.rbSingleExponent.TabStop = true;
            this.rbSingleExponent.Text = "Single Exponent";
            this.rbSingleExponent.UseVisualStyleBackColor = true;
            this.rbSingleExponent.CheckedChanged += new System.EventHandler(this.rbSingleExponent_CheckedChanged);
            // 
            // inRsquared
            // 
            this.inRsquared.DataIsInteger = true;
            this.inRsquared.Label = "R-Squared:";
            this.inRsquared.Location = new System.Drawing.Point(9, 220);
            this.inRsquared.Name = "inRsquared";
            this.inRsquared.Size = new System.Drawing.Size(210, 25);
            this.inRsquared.TabIndex = 2;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(3, 56);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(227, 158);
            this.uniPanel1.TabIndex = 1;
            // 
            // DieAwayFitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inRsquared);
            this.Controls.Add(this.uniPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DieAwayFitter";
            this.Size = new System.Drawing.Size(233, 252);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTwoExponent;
        private System.Windows.Forms.RadioButton rbSingleExponent;
        private UniPanel uniPanel1;
        private InputNumber inRsquared;
    }
}
