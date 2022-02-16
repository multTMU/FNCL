namespace GuiWidgets.EnergyCalibration
{
    partial class EnergyCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnergyCalibration));
            this.labelPanelDet = new System.Windows.Forms.Label();
            this.pHostECal = new System.Windows.Forms.Panel();
            this.bSubmit = new System.Windows.Forms.Button();
            this.cbConvert = new System.Windows.Forms.CheckBox();
            this.eCalTypeSelector1 = new GuiWidgets.EnergyCalibration.ECalTypeSelector();
            this.SuspendLayout();
            // 
            // labelPanelDet
            // 
            this.labelPanelDet.AutoSize = true;
            this.labelPanelDet.Location = new System.Drawing.Point(12, 9);
            this.labelPanelDet.Name = "labelPanelDet";
            this.labelPanelDet.Size = new System.Drawing.Size(35, 13);
            this.labelPanelDet.TabIndex = 1;
            this.labelPanelDet.Text = "label1";
            // 
            // pHostECal
            // 
            this.pHostECal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pHostECal.Location = new System.Drawing.Point(12, 145);
            this.pHostECal.Name = "pHostECal";
            this.pHostECal.Size = new System.Drawing.Size(174, 187);
            this.pHostECal.TabIndex = 2;
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(107, 338);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(75, 23);
            this.bSubmit.TabIndex = 3;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // cbConvert
            // 
            this.cbConvert.AutoSize = true;
            this.cbConvert.Location = new System.Drawing.Point(12, 122);
            this.cbConvert.Name = "cbConvert";
            this.cbConvert.Size = new System.Drawing.Size(109, 17);
            this.cbConvert.TabIndex = 4;
            this.cbConvert.Text = "Defined in KeVee";
            this.cbConvert.UseVisualStyleBackColor = true;
            this.cbConvert.CheckedChanged += new System.EventHandler(this.cbConvert_CheckedChanged);
            // 
            // eCalTypeSelector1
            // 
            this.eCalTypeSelector1.Location = new System.Drawing.Point(12, 25);
            this.eCalTypeSelector1.Name = "eCalTypeSelector1";
            this.eCalTypeSelector1.Size = new System.Drawing.Size(143, 91);
            this.eCalTypeSelector1.TabIndex = 0;
            // 
            // EnergyCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 365);
            this.Controls.Add(this.cbConvert);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.pHostECal);
            this.Controls.Add(this.labelPanelDet);
            this.Controls.Add(this.eCalTypeSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnergyCalibration";
            this.Text = "E-Cal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ECalTypeSelector eCalTypeSelector1;
        private System.Windows.Forms.Label labelPanelDet;
        private System.Windows.Forms.Panel pHostECal;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.CheckBox cbConvert;
    }
}