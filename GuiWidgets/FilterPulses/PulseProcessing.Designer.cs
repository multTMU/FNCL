namespace GuiWidgets
{
    partial class PulseProcessing
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
            this.timeOffset = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.inAdcUld = new GuiWidgets.InputNumber();
            this.inAdcLld = new GuiWidgets.InputNumber();
            this.panel3 = new GuiWidgets.FnclPanelDetectors();
            this.panel2 = new GuiWidgets.FnclPanelDetectors();
            this.panel1 = new GuiWidgets.FnclPanelDetectors();
            this.timeOffset.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeOffset
            // 
            this.timeOffset.Controls.Add(this.panel3);
            this.timeOffset.Controls.Add(this.panel2);
            this.timeOffset.Controls.Add(this.panel1);
            this.timeOffset.Location = new System.Drawing.Point(6, 51);
            this.timeOffset.Name = "timeOffset";
            this.timeOffset.Size = new System.Drawing.Size(293, 309);
            this.timeOffset.TabIndex = 0;
            this.timeOffset.TabStop = false;
            this.timeOffset.Text = "Time Offset (ns)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.inAdcUld);
            this.groupBox4.Controls.Add(this.inAdcLld);
            this.groupBox4.Controls.Add(this.timeOffset);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 366);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pulse Processing";
            // 
            // inAdcUld
            // 
            this.inAdcUld.DataIsInteger = true;
            this.inAdcUld.Label = "ADC ULD:";
            this.inAdcUld.Location = new System.Drawing.Point(153, 18);
            this.inAdcUld.Name = "inAdcUld";
            this.inAdcUld.Size = new System.Drawing.Size(147, 27);
            this.inAdcUld.TabIndex = 2;
            // 
            // inAdcLld
            // 
            this.inAdcLld.DataIsInteger = true;
            this.inAdcLld.Label = "ADC LLD:";
            this.inAdcLld.Location = new System.Drawing.Point(6, 18);
            this.inAdcLld.Name = "inAdcLld";
            this.inAdcLld.Size = new System.Drawing.Size(145, 27);
            this.inAdcLld.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(6, 215);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 92);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(6, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 92);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 92);
            this.panel1.TabIndex = 0;
            // 
            // PulseProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "PulseProcessing";
            this.Size = new System.Drawing.Size(313, 374);
            this.timeOffset.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox timeOffset;
        private InputNumber inAdcLld;
        private System.Windows.Forms.GroupBox groupBox4;
        private FnclPanelDetectors panel1;
        private FnclPanelDetectors panel2;
        private FnclPanelDetectors panel3;
        private InputNumber inAdcUld;
    }
}
