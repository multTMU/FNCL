namespace GuiWidgets.CombinePulses
{
    partial class BatchCombinePulses
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
            this.bRun = new System.Windows.Forms.Button();
            this.inFilePrefix = new GuiWidgets.InputString();
            this.inMaxSizeMB = new GuiWidgets.InputNumber();
            this.inCountTime = new GuiWidgets.InputNumber();
            this.inApplyFilters = new GuiWidgets.InputBoolean();
            this.cbPassisve = new System.Windows.Forms.CheckBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbActive);
            this.groupBox1.Controls.Add(this.cbPassisve);
            this.groupBox1.Controls.Add(this.bRun);
            this.groupBox1.Controls.Add(this.inFilePrefix);
            this.groupBox1.Controls.Add(this.inMaxSizeMB);
            this.groupBox1.Controls.Add(this.inCountTime);
            this.groupBox1.Controls.Add(this.inApplyFilters);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Combine Pulses";
            // 
            // bRun
            // 
            this.bRun.Location = new System.Drawing.Point(141, 143);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 4;
            this.bRun.Text = "Run";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // inFilePrefix
            // 
            this.inFilePrefix.Label = "File Prefix:";
            this.inFilePrefix.Location = new System.Drawing.Point(6, 81);
            this.inFilePrefix.Name = "inFilePrefix";
            this.inFilePrefix.Size = new System.Drawing.Size(210, 25);
            this.inFilePrefix.TabIndex = 3;
            // 
            // inMaxSizeMB
            // 
            this.inMaxSizeMB.DataIsInteger = true;
            this.inMaxSizeMB.Label = "Max File Size (MB):";
            this.inMaxSizeMB.Location = new System.Drawing.Point(6, 50);
            this.inMaxSizeMB.Name = "inMaxSizeMB";
            this.inMaxSizeMB.Size = new System.Drawing.Size(210, 25);
            this.inMaxSizeMB.TabIndex = 2;
            // 
            // inCountTime
            // 
            this.inCountTime.DataIsInteger = true;
            this.inCountTime.Label = "Count Time (sec):";
            this.inCountTime.Location = new System.Drawing.Point(6, 19);
            this.inCountTime.Name = "inCountTime";
            this.inCountTime.Size = new System.Drawing.Size(210, 25);
            this.inCountTime.TabIndex = 1;
            // 
            // inApplyFilters
            // 
            this.inApplyFilters.Label = "Apply Filters:";
            this.inApplyFilters.Location = new System.Drawing.Point(6, 112);
            this.inApplyFilters.Name = "inApplyFilters";
            this.inApplyFilters.Size = new System.Drawing.Size(210, 25);
            this.inApplyFilters.TabIndex = 0;
            // 
            // cbPassisve
            // 
            this.cbPassisve.AutoSize = true;
            this.cbPassisve.Location = new System.Drawing.Point(6, 147);
            this.cbPassisve.Name = "cbPassisve";
            this.cbPassisve.Size = new System.Drawing.Size(63, 17);
            this.cbPassisve.TabIndex = 5;
            this.cbPassisve.Text = "Passive";
            this.cbPassisve.UseVisualStyleBackColor = true;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(75, 147);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 6;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // BatchCombinePulses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "BatchCombinePulses";
            this.Size = new System.Drawing.Size(230, 180);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRun;
        private InputString inFilePrefix;
        private InputNumber inMaxSizeMB;
        private InputNumber inCountTime;
        private InputBoolean inApplyFilters;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.CheckBox cbPassisve;
    }
}
