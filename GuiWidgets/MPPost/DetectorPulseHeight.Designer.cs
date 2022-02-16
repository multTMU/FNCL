namespace GuiWidgets.MPPost
{
    partial class DetectorPulseHeight
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
            this.inEnablePulseHeight = new GuiWidgets.InputBoolean();
            this.inCrossTalk = new GuiWidgets.InputBoolean();
            this.inSumEnergyToLight = new GuiWidgets.InputBoolean();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inSumEnergyToLight);
            this.groupBox1.Controls.Add(this.inCrossTalk);
            this.groupBox1.Controls.Add(this.inEnablePulseHeight);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detector Pulse Height";
            // 
            // inEnablePulseHeight
            // 
            this.inEnablePulseHeight.Label = "Pulse Height:";
            this.inEnablePulseHeight.Location = new System.Drawing.Point(6, 19);
            this.inEnablePulseHeight.Name = "inEnablePulseHeight";
            this.inEnablePulseHeight.Size = new System.Drawing.Size(210, 25);
            this.inEnablePulseHeight.TabIndex = 0;
            // 
            // inCrossTalk
            // 
            this.inCrossTalk.Label = "Eliminate Crosstalk Particles:";
            this.inCrossTalk.Location = new System.Drawing.Point(6, 81);
            this.inCrossTalk.Name = "inCrossTalk";
            this.inCrossTalk.Size = new System.Drawing.Size(210, 25);
            this.inCrossTalk.TabIndex = 1;
            // 
            // inSumEnergyToLight
            // 
            this.inSumEnergyToLight.Label = "Sum All Energy to Light:";
            this.inSumEnergyToLight.Location = new System.Drawing.Point(6, 50);
            this.inSumEnergyToLight.Name = "inSumEnergyToLight";
            this.inSumEnergyToLight.Size = new System.Drawing.Size(210, 25);
            this.inSumEnergyToLight.TabIndex = 2;
            // 
            // DetectorPulseHeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DetectorPulseHeight";
            this.Size = new System.Drawing.Size(229, 115);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputBoolean inSumEnergyToLight;
        private InputBoolean inCrossTalk;
        private InputBoolean inEnablePulseHeight;
    }
}
