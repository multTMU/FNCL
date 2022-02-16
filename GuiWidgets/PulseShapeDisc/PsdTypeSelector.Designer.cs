namespace GuiWidgets.PulseShapeDisc
{
    partial class PsdTypeSelector
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
            this.rbFixed = new System.Windows.Forms.RadioButton();
            this.rbOffset = new System.Windows.Forms.RadioButton();
            this.rbHeight = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHeight);
            this.groupBox1.Controls.Add(this.rbOffset);
            this.groupBox1.Controls.Add(this.rbFixed);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set PSD Filter Type";
            // 
            // rbFixed
            // 
            this.rbFixed.AutoSize = true;
            this.rbFixed.Location = new System.Drawing.Point(6, 19);
            this.rbFixed.Name = "rbFixed";
            this.rbFixed.Size = new System.Drawing.Size(86, 17);
            this.rbFixed.TabIndex = 0;
            this.rbFixed.TabStop = true;
            this.rbFixed.Text = "Fixed Trigger";
            this.rbFixed.UseVisualStyleBackColor = true;
            this.rbFixed.CheckedChanged += new System.EventHandler(this.rbFixed_CheckedChanged);
            // 
            // rbOffset
            // 
            this.rbOffset.AutoSize = true;
            this.rbOffset.Location = new System.Drawing.Point(98, 19);
            this.rbOffset.Name = "rbOffset";
            this.rbOffset.Size = new System.Drawing.Size(81, 17);
            this.rbOffset.TabIndex = 1;
            this.rbOffset.TabStop = true;
            this.rbOffset.Text = "Peak Offset";
            this.rbOffset.UseVisualStyleBackColor = true;
            this.rbOffset.CheckedChanged += new System.EventHandler(this.rbOffset_CheckedChanged);
            // 
            // rbHeight
            // 
            this.rbHeight.AutoSize = true;
            this.rbHeight.Location = new System.Drawing.Point(185, 19);
            this.rbHeight.Name = "rbHeight";
            this.rbHeight.Size = new System.Drawing.Size(84, 17);
            this.rbHeight.TabIndex = 2;
            this.rbHeight.TabStop = true;
            this.rbHeight.Text = "Peak Height";
            this.rbHeight.UseVisualStyleBackColor = true;
            this.rbHeight.CheckedChanged += new System.EventHandler(this.rbHeight_CheckedChanged);
            // 
            // PsdTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PsdTypeSelector";
            this.Size = new System.Drawing.Size(280, 51);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHeight;
        private System.Windows.Forms.RadioButton rbOffset;
        private System.Windows.Forms.RadioButton rbFixed;
    }
}
