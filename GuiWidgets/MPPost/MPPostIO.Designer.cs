namespace GuiWidgets.MPPost
{
    partial class MPPostIO
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
            this.bSaveAs = new System.Windows.Forms.Button();
            this.inMPPostHardDefaults = new GuiWidgets.InputEnum();
            this.inLoadFile = new GuiWidgets.InputFile();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inLoadFile);
            this.groupBox1.Controls.Add(this.bSaveAs);
            this.groupBox1.Controls.Add(this.inMPPostHardDefaults);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MPPost I/O";
            // 
            // bSaveAs
            // 
            this.bSaveAs.Location = new System.Drawing.Point(244, 48);
            this.bSaveAs.Name = "bSaveAs";
            this.bSaveAs.Size = new System.Drawing.Size(57, 23);
            this.bSaveAs.TabIndex = 4;
            this.bSaveAs.Text = "Save As";
            this.bSaveAs.UseVisualStyleBackColor = true;
            this.bSaveAs.Click += new System.EventHandler(this.bSaveAs_Click);
            // 
            // inMPPostHardDefaults
            // 
            this.inMPPostHardDefaults.Label = "Load Defaults:";
            this.inMPPostHardDefaults.Location = new System.Drawing.Point(6, 19);
            this.inMPPostHardDefaults.Name = "inMPPostHardDefaults";
            this.inMPPostHardDefaults.Size = new System.Drawing.Size(210, 25);
            this.inMPPostHardDefaults.TabIndex = 0;
            // 
            // inLoadFile
            // 
            this.inLoadFile.Label = "Load Detector:";
            this.inLoadFile.Location = new System.Drawing.Point(6, 48);
            this.inLoadFile.Name = "inLoadFile";
            this.inLoadFile.Size = new System.Drawing.Size(210, 25);
            this.inLoadFile.TabIndex = 5;
            // 
            // MPPostIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MPPostIO";
            this.Size = new System.Drawing.Size(315, 88);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSaveAs;
        private InputEnum inMPPostHardDefaults;
        private InputFile inLoadFile;
    }
}
