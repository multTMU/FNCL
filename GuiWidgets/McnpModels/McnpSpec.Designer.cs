namespace GuiWidgets.FnclModels
{
    partial class McnpSpec
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
            this.inActivity = new GuiWidgets.InputNumber();
            this.inNPS = new GuiWidgets.InputNumber();
            this.inSaveDir = new GuiWidgets.InputFile();
            this.inProblemDirectory = new GuiWidgets.InputString();
            this.inDescription = new GuiWidgets.InputString();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inDescription);
            this.groupBox1.Controls.Add(this.inProblemDirectory);
            this.groupBox1.Controls.Add(this.inActivity);
            this.groupBox1.Controls.Add(this.inNPS);
            this.groupBox1.Controls.Add(this.inSaveDir);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MCNP-PoliMi";
            // 
            // inActivity
            // 
            this.inActivity.DataIsInteger = true;
            this.inActivity.Label = "Activity(Bqs):";
            this.inActivity.Location = new System.Drawing.Point(6, 143);
            this.inActivity.Name = "inActivity";
            this.inActivity.Size = new System.Drawing.Size(210, 25);
            this.inActivity.TabIndex = 2;
            // 
            // inNPS
            // 
            this.inNPS.DataIsInteger = true;
            this.inNPS.Label = "NPS:";
            this.inNPS.Location = new System.Drawing.Point(6, 112);
            this.inNPS.Name = "inNPS";
            this.inNPS.Size = new System.Drawing.Size(210, 25);
            this.inNPS.TabIndex = 1;
            // 
            // inSaveDir
            // 
            this.inSaveDir.Label = "Top Directory:";
            this.inSaveDir.Location = new System.Drawing.Point(6, 19);
            this.inSaveDir.Name = "inSaveDir";
            this.inSaveDir.Size = new System.Drawing.Size(210, 25);
            this.inSaveDir.TabIndex = 0;
            // 
            // inProblemDirectory
            // 
            this.inProblemDirectory.Label = "Directory:";
            this.inProblemDirectory.Location = new System.Drawing.Point(6, 50);
            this.inProblemDirectory.Name = "inProblemDirectory";
            this.inProblemDirectory.Size = new System.Drawing.Size(210, 25);
            this.inProblemDirectory.TabIndex = 3;
            // 
            // inDescription
            // 
            this.inDescription.Label = "Description:";
            this.inDescription.Location = new System.Drawing.Point(6, 81);
            this.inDescription.Name = "inDescription";
            this.inDescription.Size = new System.Drawing.Size(210, 25);
            this.inDescription.TabIndex = 4;
            // 
            // McnpSpec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "McnpSpec";
            this.Size = new System.Drawing.Size(227, 178);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inNPS;
        private InputFile inSaveDir;
        private InputNumber inActivity;
        private InputString inDescription;
        private InputString inProblemDirectory;
    }
}
