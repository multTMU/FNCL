namespace GuiWidgets.MPPost
{
    partial class CaptureGatedDetector
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
            this.inEnableCaptureGating = new GuiWidgets.InputBoolean();
            this.inStartTimeNS = new GuiWidgets.InputNumber();
            this.inBinSize = new GuiWidgets.InputNumber();
            this.inStopTimeNS = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inStopTimeNS);
            this.groupBox1.Controls.Add(this.inBinSize);
            this.groupBox1.Controls.Add(this.inStartTimeNS);
            this.groupBox1.Controls.Add(this.inEnableCaptureGating);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Gated Detector";
            // 
            // inEnableCaptureGating
            // 
            this.inEnableCaptureGating.Label = "Enable Capture Gating:";
            this.inEnableCaptureGating.Location = new System.Drawing.Point(6, 19);
            this.inEnableCaptureGating.Name = "inEnableCaptureGating";
            this.inEnableCaptureGating.Size = new System.Drawing.Size(210, 25);
            this.inEnableCaptureGating.TabIndex = 0;
            // 
            // inStartTimeNS
            // 
            this.inStartTimeNS.DataIsInteger = true;
            this.inStartTimeNS.Label = "Start Time (ns):";
            this.inStartTimeNS.Location = new System.Drawing.Point(6, 50);
            this.inStartTimeNS.Name = "inStartTimeNS";
            this.inStartTimeNS.Size = new System.Drawing.Size(210, 25);
            this.inStartTimeNS.TabIndex = 1;
            // 
            // inBinSize
            // 
            this.inBinSize.DataIsInteger = true;
            this.inBinSize.Label = "Bin Size:";
            this.inBinSize.Location = new System.Drawing.Point(6, 112);
            this.inBinSize.Name = "inBinSize";
            this.inBinSize.Size = new System.Drawing.Size(210, 25);
            this.inBinSize.TabIndex = 2;
            // 
            // inStopeTimeNS
            // 
            this.inStopTimeNS.DataIsInteger = true;
            this.inStopTimeNS.Label = "Stop Time (ns):";
            this.inStopTimeNS.Location = new System.Drawing.Point(6, 81);
            this.inStopTimeNS.Name = "inStopTimeNS";
            this.inStopTimeNS.Size = new System.Drawing.Size(210, 25);
            this.inStopTimeNS.TabIndex = 3;
            // 
            // CaptureGatedDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CaptureGatedDetector";
            this.Size = new System.Drawing.Size(226, 150);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inStopTimeNS;
        private InputNumber inBinSize;
        private InputNumber inStartTimeNS;
        private InputBoolean inEnableCaptureGating;
    }
}
