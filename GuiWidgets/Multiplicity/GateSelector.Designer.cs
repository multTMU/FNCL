namespace GuiWidgets.Multiplicity
{
    partial class GateSelector
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbShift = new System.Windows.Forms.RadioButton();
            this.rbSeq = new System.Windows.Forms.RadioButton();
            this.rbTrigger = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTrigger);
            this.groupBox1.Controls.Add(this.rbSeq);
            this.groupBox1.Controls.Add(this.rbShift);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Gate Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(-15, -15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbShift
            // 
            this.rbShift.AutoSize = true;
            this.rbShift.Location = new System.Drawing.Point(6, 19);
            this.rbShift.Name = "rbShift";
            this.rbShift.Size = new System.Drawing.Size(88, 17);
            this.rbShift.TabIndex = 1;
            this.rbShift.TabStop = true;
            this.rbShift.Text = "Shift Register";
            this.rbShift.UseVisualStyleBackColor = true;
            this.rbShift.CheckedChanged += new System.EventHandler(this.rbShift_CheckedChanged);
            // 
            // rbSeq
            // 
            this.rbSeq.AutoSize = true;
            this.rbSeq.Location = new System.Drawing.Point(100, 19);
            this.rbSeq.Name = "rbSeq";
            this.rbSeq.Size = new System.Drawing.Size(75, 17);
            this.rbSeq.TabIndex = 2;
            this.rbSeq.TabStop = true;
            this.rbSeq.Text = "Sequential";
            this.rbSeq.UseVisualStyleBackColor = true;
            this.rbSeq.CheckedChanged += new System.EventHandler(this.rbSeq_CheckedChanged);
            // 
            // rbTrigger
            // 
            this.rbTrigger.AutoSize = true;
            this.rbTrigger.Location = new System.Drawing.Point(181, 19);
            this.rbTrigger.Name = "rbTrigger";
            this.rbTrigger.Size = new System.Drawing.Size(70, 17);
            this.rbTrigger.TabIndex = 3;
            this.rbTrigger.TabStop = true;
            this.rbTrigger.Text = "Triggered";
            this.rbTrigger.UseVisualStyleBackColor = true;
            this.rbTrigger.CheckedChanged += new System.EventHandler(this.rbTrigger_CheckedChanged);
            // 
            // GateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "GateSelector";
            this.Size = new System.Drawing.Size(261, 52);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbTrigger;
        private System.Windows.Forms.RadioButton rbSeq;
        private System.Windows.Forms.RadioButton rbShift;
    }
}
