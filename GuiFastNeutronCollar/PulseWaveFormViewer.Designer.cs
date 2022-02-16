namespace GuiFastNeutronCollar
{
    partial class PulseWaveFormViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PulseWaveFormViewer));
            this.waveFormViewer1 = new GuiWidgets.WaveFormViewer();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // waveFormViewer1
            // 
            this.waveFormViewer1.Location = new System.Drawing.Point(12, 12);
            this.waveFormViewer1.Name = "waveFormViewer1";
            this.waveFormViewer1.Size = new System.Drawing.Size(567, 492);
            this.waveFormViewer1.TabIndex = 1;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-5, -4);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(610, 525);
            this.uniPanel1.TabIndex = 0;
            // 
            // PulseWaveFormViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 511);
            this.Controls.Add(this.waveFormViewer1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 550);
            this.MinimumSize = new System.Drawing.Size(610, 550);
            this.Name = "PulseWaveFormViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Pulse Waveform Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.WaveFormViewer waveFormViewer1;
    }
}