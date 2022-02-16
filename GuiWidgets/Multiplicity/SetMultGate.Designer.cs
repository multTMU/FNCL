namespace GuiWidgets
{
    partial class SetShiftRegister
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
            this.inGate = new GuiWidgets.InputNumber();
            this.inPreDelay = new GuiWidgets.InputNumber();
            this.inLongDelay = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inLongDelay);
            this.groupBox1.Controls.Add(this.inPreDelay);
            this.groupBox1.Controls.Add(this.inGate);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Gate (ns)";
            // 
            // inGate
            // 
            this.inGate.DataIsInteger = true;
            this.inGate.Label = "Gate Width:";
            this.inGate.Location = new System.Drawing.Point(6, 19);
            this.inGate.Name = "inGate";
            this.inGate.Size = new System.Drawing.Size(171, 27);
            this.inGate.TabIndex = 0;
            // 
            // inPreDelay
            // 
            this.inPreDelay.DataIsInteger = true;
            this.inPreDelay.Label = "Pre-Delay:";
            this.inPreDelay.Location = new System.Drawing.Point(6, 52);
            this.inPreDelay.Name = "inPreDelay";
            this.inPreDelay.Size = new System.Drawing.Size(171, 27);
            this.inPreDelay.TabIndex = 1;
            // 
            // inLongDelay
            // 
            this.inLongDelay.DataIsInteger = true;
            this.inLongDelay.Label = "Long-Delay:";
            this.inLongDelay.Location = new System.Drawing.Point(6, 85);
            this.inLongDelay.Name = "inLongDelay";
            this.inLongDelay.Size = new System.Drawing.Size(171, 27);
            this.inLongDelay.TabIndex = 2;
            // 
            // SetShiftRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SetShiftRegister";
            this.Size = new System.Drawing.Size(187, 122);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inLongDelay;
        private InputNumber inPreDelay;
        private InputNumber inGate;
    }
}
