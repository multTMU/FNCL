namespace GuiWidgets.MPPost
{
    partial class DetectorInformation
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
            this.inDetectorCells = new GuiWidgets.InputString();
            this.inMcnpNPS = new GuiWidgets.InputNumber();
            this.inAnalyzeByTimeNotHistory = new GuiWidgets.InputBoolean();
            this.inDetectorType = new GuiWidgets.InputEnum();
            this.inLLDMeV = new GuiWidgets.InputString();
            this.inULDMeV = new GuiWidgets.InputString();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inULDMeV);
            this.groupBox1.Controls.Add(this.inLLDMeV);
            this.groupBox1.Controls.Add(this.inDetectorCells);
            this.groupBox1.Controls.Add(this.inMcnpNPS);
            this.groupBox1.Controls.Add(this.inAnalyzeByTimeNotHistory);
            this.groupBox1.Controls.Add(this.inDetectorType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detector Information";
            // 
            // inDetectorCells
            // 
            this.inDetectorCells.Enabled = false;
            this.inDetectorCells.Label = "Detector Cells:";
            this.inDetectorCells.Location = new System.Drawing.Point(6, 174);
            this.inDetectorCells.Name = "inDetectorCells";
            this.inDetectorCells.Size = new System.Drawing.Size(210, 25);
            this.inDetectorCells.TabIndex = 5;
            // 
            // inMcnpNPS
            // 
            this.inMcnpNPS.DataIsInteger = true;
            this.inMcnpNPS.Label = "MCNP NPS:";
            this.inMcnpNPS.Location = new System.Drawing.Point(6, 81);
            this.inMcnpNPS.Name = "inMcnpNPS";
            this.inMcnpNPS.Size = new System.Drawing.Size(210, 25);
            this.inMcnpNPS.TabIndex = 2;
            // 
            // inAnalyzeByTimeNotHistory
            // 
            this.inAnalyzeByTimeNotHistory.Label = "Analyze by Time not History";
            this.inAnalyzeByTimeNotHistory.Location = new System.Drawing.Point(6, 50);
            this.inAnalyzeByTimeNotHistory.Name = "inAnalyzeByTimeNotHistory";
            this.inAnalyzeByTimeNotHistory.Size = new System.Drawing.Size(210, 25);
            this.inAnalyzeByTimeNotHistory.TabIndex = 1;
            // 
            // inDetectorType
            // 
            this.inDetectorType.Label = "Type:";
            this.inDetectorType.Location = new System.Drawing.Point(6, 19);
            this.inDetectorType.Name = "inDetectorType";
            this.inDetectorType.Size = new System.Drawing.Size(210, 25);
            this.inDetectorType.TabIndex = 0;
            // 
            // inLLDMeV
            // 
            this.inLLDMeV.Enabled = false;
            this.inLLDMeV.Label = "LLD MeV:";
            this.inLLDMeV.Location = new System.Drawing.Point(4, 112);
            this.inLLDMeV.Name = "inLLDMeV";
            this.inLLDMeV.Size = new System.Drawing.Size(210, 25);
            this.inLLDMeV.TabIndex = 6;
            // 
            // inULDMeV
            // 
            this.inULDMeV.Enabled = false;
            this.inULDMeV.Label = "ULD MeV:";
            this.inULDMeV.Location = new System.Drawing.Point(4, 143);
            this.inULDMeV.Name = "inULDMeV";
            this.inULDMeV.Size = new System.Drawing.Size(210, 25);
            this.inULDMeV.TabIndex = 7;
            // 
            // DetectorInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DetectorInformation";
            this.Size = new System.Drawing.Size(228, 211);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputEnum inDetectorType;
        private InputNumber inMcnpNPS;
        private InputBoolean inAnalyzeByTimeNotHistory;
        private InputString inDetectorCells;
        private InputString inLLDMeV;
        private InputString inULDMeV;
    }
}
