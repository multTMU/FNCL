namespace GuiWidgets
{
    partial class SimConfig
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
            this.inMPPostPath = new GuiWidgets.InputFile();
            this.inPoliMiPath = new GuiWidgets.InputFile();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inMPPostPath);
            this.groupBox1.Controls.Add(this.inPoliMiPath);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 81);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure";
            // 
            // inMPPostPath
            // 
            this.inMPPostPath.Label = "MPPost Path:";
            this.inMPPostPath.Location = new System.Drawing.Point(6, 50);
            this.inMPPostPath.Name = "inMPPostPath";
            this.inMPPostPath.Size = new System.Drawing.Size(210, 25);
            this.inMPPostPath.TabIndex = 4;
            // 
            // inPoliMiPath
            // 
            this.inPoliMiPath.Label = "PoliMi Path:";
            this.inPoliMiPath.Location = new System.Drawing.Point(6, 19);
            this.inPoliMiPath.Name = "inPoliMiPath";
            this.inPoliMiPath.Size = new System.Drawing.Size(210, 25);
            this.inPoliMiPath.TabIndex = 2;
            // 
            // SimConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SimConfig";
            this.Size = new System.Drawing.Size(229, 88);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private InputFile inPoliMiPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private InputFile inMPPostPath;
    }
}
