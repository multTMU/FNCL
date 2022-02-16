namespace GuiFastNeutronCollar
{
    partial class PulseAmplitude
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PulseAmplitude));
            this.pulseAmpPlotter1 = new GuiWidgets.PulseAmplitude.PulseAmpPlotter();
            this.SuspendLayout();
            // 
            // pulseAmpPlotter1
            // 
            this.pulseAmpPlotter1.Location = new System.Drawing.Point(-7, -3);
            this.pulseAmpPlotter1.Name = "pulseAmpPlotter1";
            this.pulseAmpPlotter1.Size = new System.Drawing.Size(573, 473);
            this.pulseAmpPlotter1.TabIndex = 0;
            // 
            // PulseAmplitude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 451);
            this.Controls.Add(this.pulseAmpPlotter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(565, 490);
            this.MinimumSize = new System.Drawing.Size(565, 490);
            this.Name = "PulseAmplitude";
            this.Text = "Pulse Amplitude Plotter";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.PulseAmplitude.PulseAmpPlotter pulseAmpPlotter1;
    }
}