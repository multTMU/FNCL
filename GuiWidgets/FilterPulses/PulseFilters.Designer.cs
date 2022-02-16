namespace GuiWidgets
{
    partial class PulseFilters
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
            this.correlatedPulsesFilter1 = new GuiWidgets.CorrelatedPulseSelector.CorrelatedPulsesFilter();
            this.gbPsd = new System.Windows.Forms.GroupBox();
            this.bEditPsd = new System.Windows.Forms.Button();
            this.inULD = new GuiWidgets.InputNumber();
            this.inPulseHeight = new GuiWidgets.InputNumber();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSelf = new System.Windows.Forms.CheckBox();
            this.cbThreeFour = new System.Windows.Forms.CheckBox();
            this.cbTwoFour = new System.Windows.Forms.CheckBox();
            this.inCrossTalkTime = new GuiWidgets.InputNumber();
            this.cbTwoThree = new System.Windows.Forms.CheckBox();
            this.cbOneFour = new System.Windows.Forms.CheckBox();
            this.cbOneThree = new System.Windows.Forms.CheckBox();
            this.cbOneTwo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gbPsd.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.correlatedPulsesFilter1);
            this.groupBox1.Controls.Add(this.gbPsd);
            this.groupBox1.Controls.Add(this.inULD);
            this.groupBox1.Controls.Add(this.inPulseHeight);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Filters";
            // 
            // correlatedPulsesFilter1
            // 
            this.correlatedPulsesFilter1.Location = new System.Drawing.Point(0, 85);
            this.correlatedPulsesFilter1.Name = "correlatedPulsesFilter1";
            this.correlatedPulsesFilter1.Size = new System.Drawing.Size(220, 59);
            this.correlatedPulsesFilter1.TabIndex = 15;
            // 
            // gbPsd
            // 
            this.gbPsd.Controls.Add(this.bEditPsd);
            this.gbPsd.Location = new System.Drawing.Point(6, 272);
            this.gbPsd.Name = "gbPsd";
            this.gbPsd.Size = new System.Drawing.Size(214, 50);
            this.gbPsd.TabIndex = 14;
            this.gbPsd.TabStop = false;
            this.gbPsd.Text = "Pulse Shape Discrimination";
            // 
            // bEditPsd
            // 
            this.bEditPsd.Location = new System.Drawing.Point(6, 19);
            this.bEditPsd.Name = "bEditPsd";
            this.bEditPsd.Size = new System.Drawing.Size(103, 23);
            this.bEditPsd.TabIndex = 0;
            this.bEditPsd.Text = "Edit";
            this.bEditPsd.UseVisualStyleBackColor = true;
            this.bEditPsd.Click += new System.EventHandler(this.bEditPsd_Click);
            // 
            // inULD
            // 
            this.inULD.DataIsInteger = true;
            this.inULD.Label = "ULD (keVee):";
            this.inULD.Location = new System.Drawing.Point(0, 52);
            this.inULD.Name = "inULD";
            this.inULD.Size = new System.Drawing.Size(176, 27);
            this.inULD.TabIndex = 13;
            // 
            // inPulseHeight
            // 
            this.inPulseHeight.DataIsInteger = true;
            this.inPulseHeight.Label = "LLD (keVee):";
            this.inPulseHeight.Location = new System.Drawing.Point(0, 19);
            this.inPulseHeight.Name = "inPulseHeight";
            this.inPulseHeight.Size = new System.Drawing.Size(176, 27);
            this.inPulseHeight.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSelf);
            this.groupBox2.Controls.Add(this.cbThreeFour);
            this.groupBox2.Controls.Add(this.cbTwoFour);
            this.groupBox2.Controls.Add(this.inCrossTalkTime);
            this.groupBox2.Controls.Add(this.cbTwoThree);
            this.groupBox2.Controls.Add(this.cbOneFour);
            this.groupBox2.Controls.Add(this.cbOneThree);
            this.groupBox2.Controls.Add(this.cbOneTwo);
            this.groupBox2.Location = new System.Drawing.Point(6, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 116);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inhibit Crosstalk";
            // 
            // cbSelf
            // 
            this.cbSelf.AutoSize = true;
            this.cbSelf.Location = new System.Drawing.Point(5, 48);
            this.cbSelf.Name = "cbSelf";
            this.cbSelf.Size = new System.Drawing.Size(44, 17);
            this.cbSelf.TabIndex = 6;
            this.cbSelf.Text = "Self";
            this.cbSelf.UseVisualStyleBackColor = true;
            this.cbSelf.CheckedChanged += new System.EventHandler(this.cbSelf_CheckedChanged);
            // 
            // cbThreeFour
            // 
            this.cbThreeFour.AutoSize = true;
            this.cbThreeFour.Location = new System.Drawing.Point(129, 94);
            this.cbThreeFour.Name = "cbThreeFour";
            this.cbThreeFour.Size = new System.Drawing.Size(56, 17);
            this.cbThreeFour.TabIndex = 5;
            this.cbThreeFour.Text = "3<-->4";
            this.cbThreeFour.UseVisualStyleBackColor = true;
            this.cbThreeFour.CheckedChanged += new System.EventHandler(this.cbThreeFour_CheckedChanged);
            // 
            // cbTwoFour
            // 
            this.cbTwoFour.AutoSize = true;
            this.cbTwoFour.Location = new System.Drawing.Point(67, 94);
            this.cbTwoFour.Name = "cbTwoFour";
            this.cbTwoFour.Size = new System.Drawing.Size(56, 17);
            this.cbTwoFour.TabIndex = 4;
            this.cbTwoFour.Text = "2<-->4";
            this.cbTwoFour.UseVisualStyleBackColor = true;
            this.cbTwoFour.CheckedChanged += new System.EventHandler(this.cbTwoFour_CheckedChanged);
            // 
            // inCrossTalkTime
            // 
            this.inCrossTalkTime.DataIsInteger = true;
            this.inCrossTalkTime.Label = "Veto Time (ns):";
            this.inCrossTalkTime.Location = new System.Drawing.Point(6, 15);
            this.inCrossTalkTime.Name = "inCrossTalkTime";
            this.inCrossTalkTime.Size = new System.Drawing.Size(176, 27);
            this.inCrossTalkTime.TabIndex = 10;
            // 
            // cbTwoThree
            // 
            this.cbTwoThree.AutoSize = true;
            this.cbTwoThree.Location = new System.Drawing.Point(5, 94);
            this.cbTwoThree.Name = "cbTwoThree";
            this.cbTwoThree.Size = new System.Drawing.Size(56, 17);
            this.cbTwoThree.TabIndex = 3;
            this.cbTwoThree.Text = "2<-->3";
            this.cbTwoThree.UseVisualStyleBackColor = true;
            this.cbTwoThree.CheckedChanged += new System.EventHandler(this.cbTwoThree_CheckedChanged);
            // 
            // cbOneFour
            // 
            this.cbOneFour.AutoSize = true;
            this.cbOneFour.Location = new System.Drawing.Point(129, 71);
            this.cbOneFour.Name = "cbOneFour";
            this.cbOneFour.Size = new System.Drawing.Size(56, 17);
            this.cbOneFour.TabIndex = 2;
            this.cbOneFour.Text = "1<-->4";
            this.cbOneFour.UseVisualStyleBackColor = true;
            this.cbOneFour.CheckedChanged += new System.EventHandler(this.cbOneFour_CheckedChanged);
            // 
            // cbOneThree
            // 
            this.cbOneThree.AutoSize = true;
            this.cbOneThree.Location = new System.Drawing.Point(67, 71);
            this.cbOneThree.Name = "cbOneThree";
            this.cbOneThree.Size = new System.Drawing.Size(56, 17);
            this.cbOneThree.TabIndex = 1;
            this.cbOneThree.Text = "1<-->3";
            this.cbOneThree.UseVisualStyleBackColor = true;
            this.cbOneThree.CheckedChanged += new System.EventHandler(this.cbOneThree_CheckedChanged);
            // 
            // cbOneTwo
            // 
            this.cbOneTwo.AutoSize = true;
            this.cbOneTwo.Location = new System.Drawing.Point(5, 71);
            this.cbOneTwo.Name = "cbOneTwo";
            this.cbOneTwo.Size = new System.Drawing.Size(56, 17);
            this.cbOneTwo.TabIndex = 0;
            this.cbOneTwo.Text = "1<-->2";
            this.cbOneTwo.UseVisualStyleBackColor = true;
            this.cbOneTwo.CheckedChanged += new System.EventHandler(this.cbOneTwo_CheckedChanged);
            // 
            // PulseFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PulseFilters";
            this.Size = new System.Drawing.Size(236, 338);
            this.groupBox1.ResumeLayout(false);
            this.gbPsd.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbOneFour;
        private System.Windows.Forms.CheckBox cbOneThree;
        private System.Windows.Forms.CheckBox cbOneTwo;
        private System.Windows.Forms.CheckBox cbSelf;
        private System.Windows.Forms.CheckBox cbThreeFour;
        private System.Windows.Forms.CheckBox cbTwoFour;
        private System.Windows.Forms.CheckBox cbTwoThree;
        private InputNumber inPulseHeight;
        private InputNumber inCrossTalkTime;
        private InputNumber inULD;
        private System.Windows.Forms.GroupBox gbPsd;
        private CorrelatedPulseSelector.CorrelatedPulsesFilter correlatedPulsesFilter1;
        private System.Windows.Forms.Button bEditPsd;
    }
}
