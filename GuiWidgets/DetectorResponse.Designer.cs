namespace GuiWidgets
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbDrf = new System.Windows.Forms.GroupBox();
            this.inPanelThreeAvg = new GuiWidgets.InputNumber();
            this.inPanelThreeTotal = new GuiWidgets.InputNumber();
            this.inPanelTwoAvg = new GuiWidgets.InputNumber();
            this.inPanelTwoTotal = new GuiWidgets.InputNumber();
            this.inPanelOneAvg = new GuiWidgets.InputNumber();
            this.inPanelOneTotal = new GuiWidgets.InputNumber();
            this.inTotal = new GuiWidgets.InputNumber();
            this.panelThree = new GuiWidgets.FnclPanelDetectors();
            this.panelTwo = new GuiWidgets.FnclPanelDetectors();
            this.panelOne = new GuiWidgets.FnclPanelDetectors();
            this.inSourceRate = new GuiWidgets.InputNumber();
            this.bRunDrf = new System.Windows.Forms.Button();
            this.grbDrf.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDrf
            // 
            this.grbDrf.Controls.Add(this.inPanelThreeAvg);
            this.grbDrf.Controls.Add(this.inPanelThreeTotal);
            this.grbDrf.Controls.Add(this.inPanelTwoAvg);
            this.grbDrf.Controls.Add(this.inPanelTwoTotal);
            this.grbDrf.Controls.Add(this.inPanelOneAvg);
            this.grbDrf.Controls.Add(this.inPanelOneTotal);
            this.grbDrf.Controls.Add(this.inTotal);
            this.grbDrf.Controls.Add(this.panelThree);
            this.grbDrf.Controls.Add(this.panelTwo);
            this.grbDrf.Controls.Add(this.panelOne);
            this.grbDrf.Location = new System.Drawing.Point(3, 34);
            this.grbDrf.Name = "grbDrf";
            this.grbDrf.Size = new System.Drawing.Size(294, 531);
            this.grbDrf.TabIndex = 0;
            this.grbDrf.TabStop = false;
            this.grbDrf.Text = "Detector Response Function";
            // 
            // inPanelThreeAvg
            // 
            this.inPanelThreeAvg.DataIsInteger = true;
            this.inPanelThreeAvg.Label = "Average:";
            this.inPanelThreeAvg.Location = new System.Drawing.Point(6, 498);
            this.inPanelThreeAvg.Name = "inPanelThreeAvg";
            this.inPanelThreeAvg.Size = new System.Drawing.Size(210, 25);
            this.inPanelThreeAvg.TabIndex = 9;
            // 
            // inPanelThreeTotal
            // 
            this.inPanelThreeTotal.DataIsInteger = true;
            this.inPanelThreeTotal.Label = "Total:";
            this.inPanelThreeTotal.Location = new System.Drawing.Point(6, 467);
            this.inPanelThreeTotal.Name = "inPanelThreeTotal";
            this.inPanelThreeTotal.Size = new System.Drawing.Size(210, 25);
            this.inPanelThreeTotal.TabIndex = 8;
            // 
            // inPanelTwoAvg
            // 
            this.inPanelTwoAvg.DataIsInteger = true;
            this.inPanelTwoAvg.Label = "Average:";
            this.inPanelTwoAvg.Location = new System.Drawing.Point(6, 338);
            this.inPanelTwoAvg.Name = "inPanelTwoAvg";
            this.inPanelTwoAvg.Size = new System.Drawing.Size(210, 25);
            this.inPanelTwoAvg.TabIndex = 7;
            // 
            // inPanelTwoTotal
            // 
            this.inPanelTwoTotal.DataIsInteger = true;
            this.inPanelTwoTotal.Label = "Total:";
            this.inPanelTwoTotal.Location = new System.Drawing.Point(6, 307);
            this.inPanelTwoTotal.Name = "inPanelTwoTotal";
            this.inPanelTwoTotal.Size = new System.Drawing.Size(210, 25);
            this.inPanelTwoTotal.TabIndex = 6;
            // 
            // inPanelOneAvg
            // 
            this.inPanelOneAvg.DataIsInteger = true;
            this.inPanelOneAvg.Label = "Average:";
            this.inPanelOneAvg.Location = new System.Drawing.Point(6, 178);
            this.inPanelOneAvg.Name = "inPanelOneAvg";
            this.inPanelOneAvg.Size = new System.Drawing.Size(210, 25);
            this.inPanelOneAvg.TabIndex = 5;
            // 
            // inPanelOneTotal
            // 
            this.inPanelOneTotal.DataIsInteger = true;
            this.inPanelOneTotal.Label = "Total:";
            this.inPanelOneTotal.Location = new System.Drawing.Point(6, 147);
            this.inPanelOneTotal.Name = "inPanelOneTotal";
            this.inPanelOneTotal.Size = new System.Drawing.Size(210, 25);
            this.inPanelOneTotal.TabIndex = 4;
            // 
            // inTotal
            // 
            this.inTotal.DataIsInteger = true;
            this.inTotal.Label = "Total DRF:";
            this.inTotal.Location = new System.Drawing.Point(6, 19);
            this.inTotal.Name = "inTotal";
            this.inTotal.Size = new System.Drawing.Size(210, 25);
            this.inTotal.TabIndex = 3;
            // 
            // panelThree
            // 
            this.panelThree.Location = new System.Drawing.Point(6, 369);
            this.panelThree.Name = "panelThree";
            this.panelThree.Size = new System.Drawing.Size(285, 92);
            this.panelThree.TabIndex = 2;
            // 
            // panelTwo
            // 
            this.panelTwo.Location = new System.Drawing.Point(6, 209);
            this.panelTwo.Name = "panelTwo";
            this.panelTwo.Size = new System.Drawing.Size(285, 92);
            this.panelTwo.TabIndex = 1;
            // 
            // panelOne
            // 
            this.panelOne.Location = new System.Drawing.Point(6, 49);
            this.panelOne.Name = "panelOne";
            this.panelOne.Size = new System.Drawing.Size(285, 92);
            this.panelOne.TabIndex = 0;
            // 
            // inSourceRate
            // 
            this.inSourceRate.DataIsInteger = true;
            this.inSourceRate.Label = "Source Rate:";
            this.inSourceRate.Location = new System.Drawing.Point(3, 3);
            this.inSourceRate.Name = "inSourceRate";
            this.inSourceRate.Size = new System.Drawing.Size(210, 25);
            this.inSourceRate.TabIndex = 4;
            // 
            // bRunDrf
            // 
            this.bRunDrf.Location = new System.Drawing.Point(219, 5);
            this.bRunDrf.Name = "bRunDrf";
            this.bRunDrf.Size = new System.Drawing.Size(75, 23);
            this.bRunDrf.TabIndex = 5;
            this.bRunDrf.Text = "Calculate";
            this.bRunDrf.UseVisualStyleBackColor = true;
            this.bRunDrf.Click += new System.EventHandler(this.bRunDrf_Click);
            // 
            // DetectorResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bRunDrf);
            this.Controls.Add(this.inSourceRate);
            this.Controls.Add(this.grbDrf);
            this.Name = "DetectorResponse";
            this.Size = new System.Drawing.Size(306, 568);
            this.grbDrf.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDrf;
        private FnclPanelDetectors panelThree;
        private FnclPanelDetectors panelTwo;
        private FnclPanelDetectors panelOne;
        private InputNumber inPanelThreeAvg;
        private InputNumber inPanelThreeTotal;
        private InputNumber inPanelTwoAvg;
        private InputNumber inPanelTwoTotal;
        private InputNumber inPanelOneAvg;
        private InputNumber inPanelOneTotal;
        private InputNumber inTotal;
        private InputNumber inSourceRate;
        private System.Windows.Forms.Button bRunDrf;
    }
}
