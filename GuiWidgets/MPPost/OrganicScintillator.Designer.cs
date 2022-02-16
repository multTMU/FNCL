namespace GuiWidgets.MPPost
{
    partial class OrganicScintillator
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
            this.pHostECal = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bAddNeutronCal = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.eCalFourthPoly1 = new GuiWidgets.EnergyCalibration.ECalFourthPoly();
            this.inPhotonCalibration = new GuiWidgets.EnergyCalibration.ECalLinear();
            this.inEhigh = new GuiWidgets.InputNumber();
            this.inCalibrationRegionsNumber = new GuiWidgets.InputNumber();
            this.inElow = new GuiWidgets.InputNumber();
            this.inNeutronRegionType = new GuiWidgets.InputEnum();
            this.inCarbonCal = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inCarbonCal);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Organic Scintillator";
            // 
            // pHostECal
            // 
            this.pHostECal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pHostECal.Location = new System.Drawing.Point(6, 112);
            this.pHostECal.Name = "pHostECal";
            this.pHostECal.Size = new System.Drawing.Size(204, 187);
            this.pHostECal.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.bAddNeutronCal);
            this.groupBox2.Controls.Add(this.inEhigh);
            this.groupBox2.Controls.Add(this.inCalibrationRegionsNumber);
            this.groupBox2.Controls.Add(this.inElow);
            this.groupBox2.Controls.Add(this.inNeutronRegionType);
            this.groupBox2.Controls.Add(this.pHostECal);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 333);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Neutron Calibration";
            // 
            // bAddNeutronCal
            // 
            this.bAddNeutronCal.Location = new System.Drawing.Point(135, 304);
            this.bAddNeutronCal.Name = "bAddNeutronCal";
            this.bAddNeutronCal.Size = new System.Drawing.Size(75, 23);
            this.bAddNeutronCal.TabIndex = 7;
            this.bAddNeutronCal.Text = "Add";
            this.bAddNeutronCal.UseVisualStyleBackColor = true;
            this.bAddNeutronCal.Click += new System.EventHandler(this.bAddNeutronCal_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(222, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(216, 187);
            this.dataGridView1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inPhotonCalibration);
            this.groupBox3.Location = new System.Drawing.Point(587, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 115);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Photon Calibration";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.eCalFourthPoly1);
            this.groupBox4.Location = new System.Drawing.Point(456, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(125, 226);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Deuterium Calibration";
            // 
            // eCalFourthPoly1
            // 
            this.eCalFourthPoly1.Location = new System.Drawing.Point(6, 19);
            this.eCalFourthPoly1.Name = "eCalFourthPoly1";
            this.eCalFourthPoly1.Size = new System.Drawing.Size(118, 202);
            this.eCalFourthPoly1.TabIndex = 0;
            // 
            // inPhotonCalibration
            // 
            this.inPhotonCalibration.Location = new System.Drawing.Point(6, 19);
            this.inPhotonCalibration.Name = "inPhotonCalibration";
            this.inPhotonCalibration.Size = new System.Drawing.Size(115, 91);
            this.inPhotonCalibration.TabIndex = 5;
            // 
            // inEhigh
            // 
            this.inEhigh.DataIsInteger = false;
            this.inEhigh.Label = "E-High:";
            this.inEhigh.Location = new System.Drawing.Point(6, 81);
            this.inEhigh.Name = "inEhigh";
            this.inEhigh.Size = new System.Drawing.Size(210, 25);
            this.inEhigh.TabIndex = 6;
            // 
            // inCalibrationRegionsNumber
            // 
            this.inCalibrationRegionsNumber.DataIsInteger = true;
            this.inCalibrationRegionsNumber.Label = "Number of Regions:";
            this.inCalibrationRegionsNumber.Location = new System.Drawing.Point(222, 19);
            this.inCalibrationRegionsNumber.Name = "inCalibrationRegionsNumber";
            this.inCalibrationRegionsNumber.Size = new System.Drawing.Size(210, 25);
            this.inCalibrationRegionsNumber.TabIndex = 1;
            // 
            // inElow
            // 
            this.inElow.DataIsInteger = false;
            this.inElow.Label = "E-Low:";
            this.inElow.Location = new System.Drawing.Point(6, 50);
            this.inElow.Name = "inElow";
            this.inElow.Size = new System.Drawing.Size(210, 25);
            this.inElow.TabIndex = 5;
            // 
            // inNeutronRegionType
            // 
            this.inNeutronRegionType.Label = "Neutron Region:";
            this.inNeutronRegionType.Location = new System.Drawing.Point(6, 19);
            this.inNeutronRegionType.Name = "inNeutronRegionType";
            this.inNeutronRegionType.Size = new System.Drawing.Size(210, 25);
            this.inNeutronRegionType.TabIndex = 2;
            // 
            // inCarbonCal
            // 
            this.inCarbonCal.DataIsInteger = false;
            this.inCarbonCal.Label = "Carbon:";
            this.inCarbonCal.Location = new System.Drawing.Point(456, 251);
            this.inCarbonCal.Name = "inCarbonCal";
            this.inCarbonCal.Size = new System.Drawing.Size(210, 25);
            this.inCarbonCal.TabIndex = 8;
            // 
            // OrganicScintillator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OrganicScintillator";
            this.Size = new System.Drawing.Size(738, 365);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputEnum inNeutronRegionType;
        private InputNumber inCalibrationRegionsNumber;
        private System.Windows.Forms.Panel pHostECal;
        private System.Windows.Forms.GroupBox groupBox2;
        private InputNumber inEhigh;
        private InputNumber inElow;
        private System.Windows.Forms.Button bAddNeutronCal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private GuiWidgets.EnergyCalibration.ECalLinear inPhotonCalibration;
        private System.Windows.Forms.GroupBox groupBox4;
        private GuiWidgets.EnergyCalibration.ECalFourthPoly eCalFourthPoly1;
        private InputNumber inCarbonCal;
    }
}
