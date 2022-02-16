namespace GuiWidgets.MPPost
{
    partial class TimeResolution
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
            this.inEnableTimeBroadening = new GuiWidgets.InputBoolean();
            this.inOrganicLiquidFwhm = new GuiWidgets.InputNumber();
            this.inNaIFwhm = new GuiWidgets.InputNumber();
            this.inCaF2Fwhm = new GuiWidgets.InputNumber();
            this.inLaBr3Fwhm = new GuiWidgets.InputNumber();
            this.inOrganicPlasticFwhm = new GuiWidgets.InputNumber();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.inEnableTimeBroadening);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Resolution";
            // 
            // inEnableTimeBroadening
            // 
            this.inEnableTimeBroadening.Label = "Time Broadening:";
            this.inEnableTimeBroadening.Location = new System.Drawing.Point(6, 19);
            this.inEnableTimeBroadening.Name = "inEnableTimeBroadening";
            this.inEnableTimeBroadening.Size = new System.Drawing.Size(210, 25);
            this.inEnableTimeBroadening.TabIndex = 0;
            // 
            // inOrganicLiquidFWHM
            // 
            this.inOrganicLiquidFwhm.DataIsInteger = true;
            this.inOrganicLiquidFwhm.Label = "Organic Liquid:";
            this.inOrganicLiquidFwhm.Location = new System.Drawing.Point(6, 18);
            this.inOrganicLiquidFwhm.Name = "inOrganicLiquidFwhm";
            this.inOrganicLiquidFwhm.Size = new System.Drawing.Size(210, 25);
            this.inOrganicLiquidFwhm.TabIndex = 1;
            // 
            // inNaIFwhm
            // 
            this.inNaIFwhm.DataIsInteger = true;
            this.inNaIFwhm.Label = "NaI:";
            this.inNaIFwhm.Location = new System.Drawing.Point(6, 80);
            this.inNaIFwhm.Name = "inNaIFwhm";
            this.inNaIFwhm.Size = new System.Drawing.Size(210, 25);
            this.inNaIFwhm.TabIndex = 2;
            // 
            // inCaF3Fwhm
            // 
            this.inCaF2Fwhm.DataIsInteger = true;
            this.inCaF2Fwhm.Label = "CaF2:";
            this.inCaF2Fwhm.Location = new System.Drawing.Point(6, 111);
            this.inCaF2Fwhm.Name = "inCaF2Fwhm";
            this.inCaF2Fwhm.Size = new System.Drawing.Size(210, 25);
            this.inCaF2Fwhm.TabIndex = 3;
            // 
            // inLaBr3Fwhm
            // 
            this.inLaBr3Fwhm.DataIsInteger = true;
            this.inLaBr3Fwhm.Label = "LaBr3:";
            this.inLaBr3Fwhm.Location = new System.Drawing.Point(6, 142);
            this.inLaBr3Fwhm.Name = "inLaBr3Fwhm";
            this.inLaBr3Fwhm.Size = new System.Drawing.Size(210, 25);
            this.inLaBr3Fwhm.TabIndex = 4;
            // 
            // inOrganicPlastic
            // 
            this.inOrganicPlasticFwhm.DataIsInteger = true;
            this.inOrganicPlasticFwhm.Label = "Organic Plastic:";
            this.inOrganicPlasticFwhm.Location = new System.Drawing.Point(6, 49);
            this.inOrganicPlasticFwhm.Name = "inOrganicPlasticFwhm";
            this.inOrganicPlasticFwhm.Size = new System.Drawing.Size(210, 25);
            this.inOrganicPlasticFwhm.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inOrganicPlasticFwhm);
            this.groupBox2.Controls.Add(this.inCaF2Fwhm);
            this.groupBox2.Controls.Add(this.inNaIFwhm);
            this.groupBox2.Controls.Add(this.inLaBr3Fwhm);
            this.groupBox2.Controls.Add(this.inOrganicLiquidFwhm);
            this.groupBox2.Location = new System.Drawing.Point(6, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 172);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FWHM (ns)";
            // 
            // TimeResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TimeResolution";
            this.Size = new System.Drawing.Size(237, 233);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private InputNumber inOrganicPlasticFwhm;
        private InputNumber inCaF2Fwhm;
        private InputNumber inNaIFwhm;
        private InputNumber inLaBr3Fwhm;
        private InputNumber inOrganicLiquidFwhm;
        private InputBoolean inEnableTimeBroadening;
    }
}
