namespace GuiWidgets.FilterPulses
{
    partial class FlatTopPulseFilter
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
            this.inFlatTopDuration = new GuiWidgets.InputNumber();
            this.inPeakMaxTolerance = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inPeakMaxTolerance);
            this.groupBox1.Controls.Add(this.inFlatTopDuration);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Flat Top";
            // 
            // inFlatTopDuration
            // 
            this.inFlatTopDuration.DataIsInteger = true;
            this.inFlatTopDuration.Label = "Duration (ns):";
            this.inFlatTopDuration.Location = new System.Drawing.Point(6, 19);
            this.inFlatTopDuration.Name = "inFlatTopDuration";
            this.inFlatTopDuration.Size = new System.Drawing.Size(210, 25);
            this.inFlatTopDuration.TabIndex = 0;
            // 
            // inPeakMaxTolerance
            // 
            this.inPeakMaxTolerance.DataIsInteger = true;
            this.inPeakMaxTolerance.Label = "Pulse Max (%):";
            this.inPeakMaxTolerance.Location = new System.Drawing.Point(6, 50);
            this.inPeakMaxTolerance.Name = "inPeakMaxTolerance";
            this.inPeakMaxTolerance.Size = new System.Drawing.Size(210, 25);
            this.inPeakMaxTolerance.TabIndex = 1;
            // 
            // FlatTopPulseFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FlatTopPulseFilter";
            this.Size = new System.Drawing.Size(227, 86);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inPeakMaxTolerance;
        private InputNumber inFlatTopDuration;
    }
}
