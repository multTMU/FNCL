namespace GuiWidgets.PulseShapeDisc
{
    partial class PsdWaveformResults
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
            this.inParticle = new GuiWidgets.InputString();
            this.inAmplitude = new GuiWidgets.InputNumber();
            this.inPSD = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inParticle);
            this.groupBox1.Controls.Add(this.inAmplitude);
            this.groupBox1.Controls.Add(this.inPSD);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PSD for Waveform";
            // 
            // inParticle
            // 
            this.inParticle.Label = "Particle:";
            this.inParticle.Location = new System.Drawing.Point(6, 81);
            this.inParticle.Name = "inParticle";
            this.inParticle.Size = new System.Drawing.Size(206, 25);
            this.inParticle.TabIndex = 2;
            // 
            // inAmplitude
            // 
            this.inAmplitude.DataIsInteger = true;
            this.inAmplitude.Label = "Amplitude:";
            this.inAmplitude.Location = new System.Drawing.Point(2, 50);
            this.inAmplitude.Name = "inAmplitude";
            this.inAmplitude.Size = new System.Drawing.Size(210, 25);
            this.inAmplitude.TabIndex = 1;
            // 
            // inPSD
            // 
            this.inPSD.DataIsInteger = true;
            this.inPSD.Label = "PSD:";
            this.inPSD.Location = new System.Drawing.Point(2, 19);
            this.inPSD.Name = "inPSD";
            this.inPSD.Size = new System.Drawing.Size(210, 25);
            this.inPSD.TabIndex = 0;
            // 
            // PsdWaveformResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PsdWaveformResults";
            this.Size = new System.Drawing.Size(227, 122);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputString inParticle;
        private InputNumber inAmplitude;
        private InputNumber inPSD;
    }
}
