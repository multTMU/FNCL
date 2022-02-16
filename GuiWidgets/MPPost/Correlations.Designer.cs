namespace GuiWidgets.MPPost
{
    partial class Correlations
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
            this.inTimeOfFlight = new GuiWidgets.InputBoolean();
            this.inCellDetectorStart = new GuiWidgets.InputNumber();
            this.inCrossCorrelation = new GuiWidgets.InputBoolean();
            this.inAutoCorrelation = new GuiWidgets.InputBoolean();
            this.inStartTimeNS = new GuiWidgets.InputNumber();
            this.inStopTimeNS = new GuiWidgets.InputNumber();
            this.inBinIncrementNS = new GuiWidgets.InputNumber();
            this.inTimeWindowNS = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inTimeWindowNS);
            this.groupBox1.Controls.Add(this.inBinIncrementNS);
            this.groupBox1.Controls.Add(this.inStopTimeNS);
            this.groupBox1.Controls.Add(this.inStartTimeNS);
            this.groupBox1.Controls.Add(this.inAutoCorrelation);
            this.groupBox1.Controls.Add(this.inCrossCorrelation);
            this.groupBox1.Controls.Add(this.inCellDetectorStart);
            this.groupBox1.Controls.Add(this.inTimeOfFlight);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 265);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Correlations";
            // 
            // inTimeOfFlight
            // 
            this.inTimeOfFlight.Label = "Time of Flight:";
            this.inTimeOfFlight.Location = new System.Drawing.Point(6, 19);
            this.inTimeOfFlight.Name = "inTimeOfFlight";
            this.inTimeOfFlight.Size = new System.Drawing.Size(210, 25);
            this.inTimeOfFlight.TabIndex = 0;
            // 
            // inCellDetectorStart
            // 
            this.inCellDetectorStart.DataIsInteger = true;
            this.inCellDetectorStart.Label = "Cell of Start Detector:";
            this.inCellDetectorStart.Location = new System.Drawing.Point(6, 112);
            this.inCellDetectorStart.Name = "inCellDetectorStart";
            this.inCellDetectorStart.Size = new System.Drawing.Size(210, 25);
            this.inCellDetectorStart.TabIndex = 1;
            // 
            // inCrossCorrelation
            // 
            this.inCrossCorrelation.Label = "Cross Correlation:";
            this.inCrossCorrelation.Location = new System.Drawing.Point(6, 50);
            this.inCrossCorrelation.Name = "inCrossCorrelation";
            this.inCrossCorrelation.Size = new System.Drawing.Size(210, 25);
            this.inCrossCorrelation.TabIndex = 2;
            // 
            // inAutoCorrelation
            // 
            this.inAutoCorrelation.Label = "Auto Correlation:";
            this.inAutoCorrelation.Location = new System.Drawing.Point(6, 81);
            this.inAutoCorrelation.Name = "inAutoCorrelation";
            this.inAutoCorrelation.Size = new System.Drawing.Size(210, 25);
            this.inAutoCorrelation.TabIndex = 3;
            // 
            // inStartTimeNS
            // 
            this.inStartTimeNS.DataIsInteger = true;
            this.inStartTimeNS.Label = "Start Time (ns):";
            this.inStartTimeNS.Location = new System.Drawing.Point(6, 143);
            this.inStartTimeNS.Name = "inStartTimeNS";
            this.inStartTimeNS.Size = new System.Drawing.Size(210, 25);
            this.inStartTimeNS.TabIndex = 4;
            // 
            // inStopTimeNS
            // 
            this.inStopTimeNS.DataIsInteger = true;
            this.inStopTimeNS.Label = "Stop Time (ns):";
            this.inStopTimeNS.Location = new System.Drawing.Point(6, 174);
            this.inStopTimeNS.Name = "inStopTimeNS";
            this.inStopTimeNS.Size = new System.Drawing.Size(210, 25);
            this.inStopTimeNS.TabIndex = 5;
            // 
            // inBinIncrementNS
            // 
            this.inBinIncrementNS.DataIsInteger = true;
            this.inBinIncrementNS.Label = "Bin Increment (ns):";
            this.inBinIncrementNS.Location = new System.Drawing.Point(6, 205);
            this.inBinIncrementNS.Name = "inBinIncrementNS";
            this.inBinIncrementNS.Size = new System.Drawing.Size(210, 25);
            this.inBinIncrementNS.TabIndex = 6;
            // 
            // inTimeWindowNS
            // 
            this.inTimeWindowNS.DataIsInteger = true;
            this.inTimeWindowNS.Label = "Time Window (ns):";
            this.inTimeWindowNS.Location = new System.Drawing.Point(6, 236);
            this.inTimeWindowNS.Name = "inTimeWindowNS";
            this.inTimeWindowNS.Size = new System.Drawing.Size(210, 25);
            this.inTimeWindowNS.TabIndex = 7;
            // 
            // Correlations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Correlations";
            this.Size = new System.Drawing.Size(230, 269);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inTimeWindowNS;
        private InputNumber inBinIncrementNS;
        private InputNumber inStopTimeNS;
        private InputNumber inStartTimeNS;
        private InputBoolean inAutoCorrelation;
        private InputBoolean inCrossCorrelation;
        private InputNumber inCellDetectorStart;
        private InputBoolean inTimeOfFlight;
    }
}
