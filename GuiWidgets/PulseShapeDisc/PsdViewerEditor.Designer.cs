namespace GuiWidgets.PulseShapeDisc
{
    partial class PsdViewerEditor
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
            this.inMaxPulses = new GuiWidgets.InputNumber();
            this.inputTrigger = new GuiWidgets.InputNumber();
            this.psdIntervals1 = new GuiWidgets.PulseShapeDisc.PsdIntervals();
            this.psdTypeSelector1 = new GuiWidgets.PulseShapeDisc.PsdTypeSelector();
            this.SuspendLayout();
            // 
            // inMaxPulses
            // 
            this.inMaxPulses.DataIsInteger = true;
            this.inMaxPulses.Label = "Number Pulses:";
            this.inMaxPulses.Location = new System.Drawing.Point(3, 216);
            this.inMaxPulses.Name = "inMaxPulses";
            this.inMaxPulses.Size = new System.Drawing.Size(191, 27);
            this.inMaxPulses.TabIndex = 3;
            // 
            // inputTrigger
            // 
            this.inputTrigger.DataIsInteger = true;
            this.inputTrigger.Label = "Trigger:";
            this.inputTrigger.Location = new System.Drawing.Point(3, 60);
            this.inputTrigger.Name = "inputTrigger";
            this.inputTrigger.Size = new System.Drawing.Size(191, 27);
            this.inputTrigger.TabIndex = 2;
            // 
            // psdIntervals1
            // 
            this.psdIntervals1.Location = new System.Drawing.Point(3, 93);
            this.psdIntervals1.Name = "psdIntervals1";
            this.psdIntervals1.Size = new System.Drawing.Size(202, 117);
            this.psdIntervals1.TabIndex = 1;
            // 
            // psdTypeSelector1
            // 
            this.psdTypeSelector1.Location = new System.Drawing.Point(3, 3);
            this.psdTypeSelector1.Name = "psdTypeSelector1";
            this.psdTypeSelector1.Size = new System.Drawing.Size(280, 51);
            this.psdTypeSelector1.TabIndex = 0;
            // 
            // PsdViewerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inMaxPulses);
            this.Controls.Add(this.inputTrigger);
            this.Controls.Add(this.psdIntervals1);
            this.Controls.Add(this.psdTypeSelector1);
            this.Name = "PsdViewerEditor";
            this.Size = new System.Drawing.Size(279, 246);
            this.ResumeLayout(false);

        }

        #endregion

        private PsdTypeSelector psdTypeSelector1;
        private PsdIntervals psdIntervals1;
        private InputNumber inputTrigger;
        private InputNumber inMaxPulses;
    }
}
