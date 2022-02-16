namespace GuiWidgets.MPPost
{
    partial class He3Module
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
            this.inEnableHe3Module = new GuiWidgets.InputBoolean();
            this.inOutputStyle = new GuiWidgets.InputEnum();
            this.inDeadTimeType = new GuiWidgets.InputEnum();
            this.inTriggerType = new GuiWidgets.InputEnum();
            this.inNumberWindows = new GuiWidgets.InputNumber();
            this.inParalyzeable = new GuiWidgets.InputBoolean();
            this.inWindowIncrementMicroSec = new GuiWidgets.InputNumber();
            this.inPreDelayMicroSec = new GuiWidgets.InputNumber();
            this.inLongDelayMicroSec = new GuiWidgets.InputNumber();
            this.inRunTimeSec = new GuiWidgets.InputNumber();
            this.inMaxMultiplicity = new GuiWidgets.InputNumber();
            this.inAmpDeadTimeMicroSec = new GuiWidgets.InputNumber();
            this.inDeadTimeMicroSec = new GuiWidgets.InputNumber();
            this.inAmp2DeadTimeMicroSec = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inAmp2DeadTimeMicroSec);
            this.groupBox1.Controls.Add(this.inDeadTimeMicroSec);
            this.groupBox1.Controls.Add(this.inAmpDeadTimeMicroSec);
            this.groupBox1.Controls.Add(this.inMaxMultiplicity);
            this.groupBox1.Controls.Add(this.inRunTimeSec);
            this.groupBox1.Controls.Add(this.inLongDelayMicroSec);
            this.groupBox1.Controls.Add(this.inPreDelayMicroSec);
            this.groupBox1.Controls.Add(this.inWindowIncrementMicroSec);
            this.groupBox1.Controls.Add(this.inParalyzeable);
            this.groupBox1.Controls.Add(this.inNumberWindows);
            this.groupBox1.Controls.Add(this.inTriggerType);
            this.groupBox1.Controls.Add(this.inDeadTimeType);
            this.groupBox1.Controls.Add(this.inOutputStyle);
            this.groupBox1.Controls.Add(this.inEnableHe3Module);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 453);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Helium-3 Module";
            // 
            // inEnableHe3Module
            // 
            this.inEnableHe3Module.Label = "Enable He3 Module:";
            this.inEnableHe3Module.Location = new System.Drawing.Point(6, 19);
            this.inEnableHe3Module.Name = "inEnableHe3Module";
            this.inEnableHe3Module.Size = new System.Drawing.Size(210, 25);
            this.inEnableHe3Module.TabIndex = 0;
            // 
            // inOutputStyle
            // 
            this.inOutputStyle.Label = "Output Style:";
            this.inOutputStyle.Location = new System.Drawing.Point(6, 81);
            this.inOutputStyle.Name = "inOutputStyle";
            this.inOutputStyle.Size = new System.Drawing.Size(210, 25);
            this.inOutputStyle.TabIndex = 1;
            // 
            // inDeadTimeType
            // 
            this.inDeadTimeType.Label = "Deadtime Type:";
            this.inDeadTimeType.Location = new System.Drawing.Point(6, 143);
            this.inDeadTimeType.Name = "inDeadTimeType";
            this.inDeadTimeType.Size = new System.Drawing.Size(210, 25);
            this.inDeadTimeType.TabIndex = 2;
            // 
            // inTriggerType
            // 
            this.inTriggerType.Label = "Trigger Type:";
            this.inTriggerType.Location = new System.Drawing.Point(6, 112);
            this.inTriggerType.Name = "inTriggerType";
            this.inTriggerType.Size = new System.Drawing.Size(210, 25);
            this.inTriggerType.TabIndex = 3;
            // 
            // inNumberWindows
            // 
            this.inNumberWindows.DataIsInteger = true;
            this.inNumberWindows.Label = "Number Windows:";
            this.inNumberWindows.Location = new System.Drawing.Point(6, 174);
            this.inNumberWindows.Name = "inNumberWindows";
            this.inNumberWindows.Size = new System.Drawing.Size(210, 25);
            this.inNumberWindows.TabIndex = 4;
            // 
            // inParalyzeable
            // 
            this.inParalyzeable.Label = "Paralyzable";
            this.inParalyzeable.Location = new System.Drawing.Point(6, 50);
            this.inParalyzeable.Name = "inParalyzeable";
            this.inParalyzeable.Size = new System.Drawing.Size(210, 25);
            this.inParalyzeable.TabIndex = 5;
            // 
            // inWindowIncrementMicroSec
            // 
            this.inWindowIncrementMicroSec.DataIsInteger = true;
            this.inWindowIncrementMicroSec.Label = "Window (us):";
            this.inWindowIncrementMicroSec.Location = new System.Drawing.Point(6, 205);
            this.inWindowIncrementMicroSec.Name = "inWindowIncrementMicroSec";
            this.inWindowIncrementMicroSec.Size = new System.Drawing.Size(210, 25);
            this.inWindowIncrementMicroSec.TabIndex = 6;
            // 
            // inPreDelayMicroSec
            // 
            this.inPreDelayMicroSec.DataIsInteger = true;
            this.inPreDelayMicroSec.Label = "Pre-Delay (us):";
            this.inPreDelayMicroSec.Location = new System.Drawing.Point(6, 236);
            this.inPreDelayMicroSec.Name = "inPreDelayMicroSec";
            this.inPreDelayMicroSec.Size = new System.Drawing.Size(210, 25);
            this.inPreDelayMicroSec.TabIndex = 7;
            // 
            // inLongDelayMicroSec
            // 
            this.inLongDelayMicroSec.DataIsInteger = true;
            this.inLongDelayMicroSec.Label = "Long Delay (us):";
            this.inLongDelayMicroSec.Location = new System.Drawing.Point(6, 267);
            this.inLongDelayMicroSec.Name = "inLongDelayMicroSec";
            this.inLongDelayMicroSec.Size = new System.Drawing.Size(210, 25);
            this.inLongDelayMicroSec.TabIndex = 8;
            // 
            // inRunTimeSec
            // 
            this.inRunTimeSec.DataIsInteger = true;
            this.inRunTimeSec.Label = "Run Time (s):";
            this.inRunTimeSec.Location = new System.Drawing.Point(6, 298);
            this.inRunTimeSec.Name = "inRunTimeSec";
            this.inRunTimeSec.Size = new System.Drawing.Size(210, 25);
            this.inRunTimeSec.TabIndex = 9;
            // 
            // inMaxMultiplicity
            // 
            this.inMaxMultiplicity.DataIsInteger = true;
            this.inMaxMultiplicity.Label = "Max.  Multiplicity:";
            this.inMaxMultiplicity.Location = new System.Drawing.Point(6, 329);
            this.inMaxMultiplicity.Name = "inMaxMultiplicity";
            this.inMaxMultiplicity.Size = new System.Drawing.Size(210, 25);
            this.inMaxMultiplicity.TabIndex = 10;
            // 
            // inAmpDeadTimeMicroSec
            // 
            this.inAmpDeadTimeMicroSec.DataIsInteger = true;
            this.inAmpDeadTimeMicroSec.Label = "Amp. Deadtime (us):";
            this.inAmpDeadTimeMicroSec.Location = new System.Drawing.Point(6, 391);
            this.inAmpDeadTimeMicroSec.Name = "inAmpDeadTimeMicroSec";
            this.inAmpDeadTimeMicroSec.Size = new System.Drawing.Size(210, 25);
            this.inAmpDeadTimeMicroSec.TabIndex = 11;
            // 
            // inDeadTimeMicroSec
            // 
            this.inDeadTimeMicroSec.DataIsInteger = true;
            this.inDeadTimeMicroSec.Label = "Deadtime (us):";
            this.inDeadTimeMicroSec.Location = new System.Drawing.Point(6, 360);
            this.inDeadTimeMicroSec.Name = "inDeadTimeMicroSec";
            this.inDeadTimeMicroSec.Size = new System.Drawing.Size(210, 25);
            this.inDeadTimeMicroSec.TabIndex = 12;
            // 
            // inAmp2DeadTimeMicroSec
            // 
            this.inAmp2DeadTimeMicroSec.DataIsInteger = true;
            this.inAmp2DeadTimeMicroSec.Label = "Amp. 2 Deadtime (us):";
            this.inAmp2DeadTimeMicroSec.Location = new System.Drawing.Point(6, 422);
            this.inAmp2DeadTimeMicroSec.Name = "inAmp2DeadTimeMicroSec";
            this.inAmp2DeadTimeMicroSec.Size = new System.Drawing.Size(210, 25);
            this.inAmp2DeadTimeMicroSec.TabIndex = 13;
            // 
            // He3Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "He3Module";
            this.Size = new System.Drawing.Size(226, 461);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputBoolean inParalyzeable;
        private InputNumber inNumberWindows;
        private InputEnum inTriggerType;
        private InputEnum inDeadTimeType;
        private InputEnum inOutputStyle;
        private InputBoolean inEnableHe3Module;
        private InputNumber inAmp2DeadTimeMicroSec;
        private InputNumber inDeadTimeMicroSec;
        private InputNumber inAmpDeadTimeMicroSec;
        private InputNumber inMaxMultiplicity;
        private InputNumber inRunTimeSec;
        private InputNumber inLongDelayMicroSec;
        private InputNumber inPreDelayMicroSec;
        private InputNumber inWindowIncrementMicroSec;
    }
}
