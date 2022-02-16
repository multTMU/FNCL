namespace GuiWidgets.PulseShapeDisc
{
    partial class PsdIntervals
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
            this.gbPSD = new System.Windows.Forms.GroupBox();
            this.inPsdFast = new GuiWidgets.InputNumber();
            this.inPsdSlow = new GuiWidgets.InputNumber();
            this.inPsdAmpScalar = new GuiWidgets.InputNumber();
            this.gbPSD.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPSD
            // 
            this.gbPSD.Controls.Add(this.inPsdFast);
            this.gbPSD.Controls.Add(this.inPsdSlow);
            this.gbPSD.Controls.Add(this.inPsdAmpScalar);
            this.gbPSD.Location = new System.Drawing.Point(3, 3);
            this.gbPSD.Name = "gbPSD";
            this.gbPSD.Size = new System.Drawing.Size(195, 112);
            this.gbPSD.TabIndex = 4;
            this.gbPSD.TabStop = false;
            this.gbPSD.Text = "Pulse Shape Discrimination (ns)";
            // 
            // inPsdFast
            // 
            this.inPsdFast.DataIsInteger = true;
            this.inPsdFast.Label = "Fast:";
            this.inPsdFast.Location = new System.Drawing.Point(6, 16);
            this.inPsdFast.Name = "inPsdFast";
            this.inPsdFast.Size = new System.Drawing.Size(164, 27);
            this.inPsdFast.TabIndex = 11;
            // 
            // inPsdSlow
            // 
            this.inPsdSlow.DataIsInteger = true;
            this.inPsdSlow.Label = "Slow:";
            this.inPsdSlow.Location = new System.Drawing.Point(5, 49);
            this.inPsdSlow.Name = "inPsdSlow";
            this.inPsdSlow.Size = new System.Drawing.Size(165, 27);
            this.inPsdSlow.TabIndex = 10;
            // 
            // inPsdAmpScalar
            // 
            this.inPsdAmpScalar.DataIsInteger = true;
            this.inPsdAmpScalar.Label = "Amp Scalar:";
            this.inPsdAmpScalar.Location = new System.Drawing.Point(4, 82);
            this.inPsdAmpScalar.Name = "inPsdAmpScalar";
            this.inPsdAmpScalar.Size = new System.Drawing.Size(166, 27);
            this.inPsdAmpScalar.TabIndex = 9;
            // 
            // PsdIntervals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPSD);
            this.Name = "PsdIntervals";
            this.Size = new System.Drawing.Size(202, 117);
            this.gbPSD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPSD;
        private InputNumber inPsdFast;
        private InputNumber inPsdSlow;
        private InputNumber inPsdAmpScalar;
    }
}
