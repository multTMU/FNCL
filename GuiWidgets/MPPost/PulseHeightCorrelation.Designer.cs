namespace GuiWidgets.MPPost
{
    partial class PulseHeightCorrelation
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
            this.inEnablePulseHeightCorrelation = new GuiWidgets.InputBoolean();
            this.inMinBinMeVee = new GuiWidgets.InputNumber();
            this.inBinSizeMeVee = new GuiWidgets.InputNumber();
            this.inMaxBinMeVee = new GuiWidgets.InputNumber();
            this.inIgnoreStartDetectorPulse = new GuiWidgets.InputBoolean();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inIgnoreStartDetectorPulse);
            this.groupBox1.Controls.Add(this.inMaxBinMeVee);
            this.groupBox1.Controls.Add(this.inBinSizeMeVee);
            this.groupBox1.Controls.Add(this.inMinBinMeVee);
            this.groupBox1.Controls.Add(this.inEnablePulseHeightCorrelation);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Height Correlation";
            // 
            // inEnablePulseHeightCorrelation
            // 
            this.inEnablePulseHeightCorrelation.Label = "Pulse Height Correlation:";
            this.inEnablePulseHeightCorrelation.Location = new System.Drawing.Point(6, 19);
            this.inEnablePulseHeightCorrelation.Name = "inEnablePulseHeightCorrelation";
            this.inEnablePulseHeightCorrelation.Size = new System.Drawing.Size(210, 25);
            this.inEnablePulseHeightCorrelation.TabIndex = 0;
            // 
            // inMinBinMeVee
            // 
            this.inMinBinMeVee.DataIsInteger = true;
            this.inMinBinMeVee.Label = "Min. Bin MeVee:";
            this.inMinBinMeVee.Location = new System.Drawing.Point(6, 81);
            this.inMinBinMeVee.Name = "inMinBinMeVee";
            this.inMinBinMeVee.Size = new System.Drawing.Size(210, 25);
            this.inMinBinMeVee.TabIndex = 1;
            // 
            // inBinSizeMeVee
            // 
            this.inBinSizeMeVee.DataIsInteger = true;
            this.inBinSizeMeVee.Label = "Bin Size MeVee:";
            this.inBinSizeMeVee.Location = new System.Drawing.Point(6, 143);
            this.inBinSizeMeVee.Name = "inBinSizeMeVee";
            this.inBinSizeMeVee.Size = new System.Drawing.Size(210, 25);
            this.inBinSizeMeVee.TabIndex = 2;
            // 
            // inMaxBinMeVee
            // 
            this.inMaxBinMeVee.DataIsInteger = true;
            this.inMaxBinMeVee.Label = "Max. Bin MeVee:";
            this.inMaxBinMeVee.Location = new System.Drawing.Point(6, 112);
            this.inMaxBinMeVee.Name = "inMaxBinMeVee";
            this.inMaxBinMeVee.Size = new System.Drawing.Size(210, 25);
            this.inMaxBinMeVee.TabIndex = 3;
            // 
            // inIgnoreStartDetectorPulse
            // 
            this.inIgnoreStartDetectorPulse.Label = "Ignore Start Detector Pulse:";
            this.inIgnoreStartDetectorPulse.Location = new System.Drawing.Point(6, 50);
            this.inIgnoreStartDetectorPulse.Name = "inIgnoreStartDetectorPulse";
            this.inIgnoreStartDetectorPulse.Size = new System.Drawing.Size(210, 25);
            this.inIgnoreStartDetectorPulse.TabIndex = 4;
            // 
            // PulseHeightCorrelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PulseHeightCorrelation";
            this.Size = new System.Drawing.Size(227, 177);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputBoolean inIgnoreStartDetectorPulse;
        private InputNumber inMaxBinMeVee;
        private InputNumber inBinSizeMeVee;
        private InputNumber inMinBinMeVee;
        private InputBoolean inEnablePulseHeightCorrelation;
    }
}
