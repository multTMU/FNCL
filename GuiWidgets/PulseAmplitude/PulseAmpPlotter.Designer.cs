namespace GuiWidgets.PulseAmplitude
{
    partial class PulseAmpPlotter
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
            this.rbEnergy = new System.Windows.Forms.RadioButton();
            this.rbADC = new System.Windows.Forms.RadioButton();
            this.histogramPlotter1 = new GuiWidgets.HistogramPlotter();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.scaleVertical = new GuiWidgets.PulseAmplitude.LogVsLinear();
            this.scaleHorizontal = new GuiWidgets.PulseAmplitude.LogVsLinear();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEnergy);
            this.groupBox1.Controls.Add(this.rbADC);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plot Options";
            // 
            // rbEnergy
            // 
            this.rbEnergy.AutoSize = true;
            this.rbEnergy.Location = new System.Drawing.Point(59, 19);
            this.rbEnergy.Name = "rbEnergy";
            this.rbEnergy.Size = new System.Drawing.Size(56, 17);
            this.rbEnergy.TabIndex = 1;
            this.rbEnergy.TabStop = true;
            this.rbEnergy.Text = "keVee";
            this.rbEnergy.UseVisualStyleBackColor = true;
            this.rbEnergy.CheckedChanged += new System.EventHandler(this.rbEnergy_CheckedChanged);
            // 
            // rbADC
            // 
            this.rbADC.AutoSize = true;
            this.rbADC.Location = new System.Drawing.Point(6, 19);
            this.rbADC.Name = "rbADC";
            this.rbADC.Size = new System.Drawing.Size(47, 17);
            this.rbADC.TabIndex = 0;
            this.rbADC.TabStop = true;
            this.rbADC.Text = "ADC";
            this.rbADC.UseVisualStyleBackColor = true;
            this.rbADC.CheckedChanged += new System.EventHandler(this.rbADC_CheckedChanged);
            // 
            // histogramPlotter1
            // 
            this.histogramPlotter1.Location = new System.Drawing.Point(16, 67);
            this.histogramPlotter1.Name = "histogramPlotter1";
            this.histogramPlotter1.Size = new System.Drawing.Size(527, 364);
            this.histogramPlotter1.TabIndex = 1;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-7, -9);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(572, 469);
            this.uniPanel1.TabIndex = 0;
            // 
            // scaleVertical
            // 
            this.scaleVertical.Location = new System.Drawing.Point(410, 10);
            this.scaleVertical.Name = "scaleVertical";
            this.scaleVertical.Size = new System.Drawing.Size(133, 51);
            this.scaleVertical.TabIndex = 3;
            // 
            // scaleHorizontal
            // 
            this.scaleHorizontal.Location = new System.Drawing.Point(271, 10);
            this.scaleHorizontal.Name = "scaleHorizontal";
            this.scaleHorizontal.Size = new System.Drawing.Size(133, 51);
            this.scaleHorizontal.TabIndex = 4;
            // 
            // PulseAmpPlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleHorizontal);
            this.Controls.Add(this.scaleVertical);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.histogramPlotter1);
            this.Controls.Add(this.uniPanel1);
            this.Name = "PulseAmpPlotter";
            this.Size = new System.Drawing.Size(557, 451);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UniPanel uniPanel1;
        private HistogramPlotter histogramPlotter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEnergy;
        private System.Windows.Forms.RadioButton rbADC;
        private LogVsLinear scaleVertical;
        private LogVsLinear scaleHorizontal;
    }
}
