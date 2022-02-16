namespace GuiFastNeutronCollar
{
    partial class DetectorResponse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectorResponse));
            this.detectorResponse1 = new GuiWidgets.DetectorResponse();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // detectorResponse1
            // 
            this.detectorResponse1.Location = new System.Drawing.Point(12, 12);
            this.detectorResponse1.Name = "detectorResponse1";
            this.detectorResponse1.Size = new System.Drawing.Size(306, 568);
            this.detectorResponse1.TabIndex = 0;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-9, -6);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(344, 606);
            this.uniPanel1.TabIndex = 1;
            // 
            // DetectorResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 591);
            this.Controls.Add(this.detectorResponse1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 630);
            this.MinimumSize = new System.Drawing.Size(345, 630);
            this.Name = "DetectorResponse";
            this.Text = "Detector Response";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.DetectorResponse detectorResponse1;
        private GuiWidgets.UniPanel uniPanel1;
    }
}