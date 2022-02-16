namespace GuiWidgets
{
    partial class PoliMiSpecification
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
            this.bAddPoliMi = new System.Windows.Forms.Button();
            this.inSeed = new GuiWidgets.InputNumber();
            this.inFile = new GuiWidgets.InputFile();
            this.inNPS = new GuiWidgets.InputNumber();
            this.inActivity = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inNPS);
            this.groupBox1.Controls.Add(this.inActivity);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PoliMi Specifications";
            // 
            // bAddPoliMi
            // 
            this.bAddPoliMi.Location = new System.Drawing.Point(129, 151);
            this.bAddPoliMi.Name = "bAddPoliMi";
            this.bAddPoliMi.Size = new System.Drawing.Size(75, 23);
            this.bAddPoliMi.TabIndex = 12;
            this.bAddPoliMi.Text = "Add ";
            this.bAddPoliMi.UseVisualStyleBackColor = true;
            this.bAddPoliMi.Click += new System.EventHandler(this.bAddPoliMi_Click);
            // 
            // inSeed
            // 
            this.inSeed.DataIsInteger = true;
            this.inSeed.Label = "Seed For All:";
            this.inSeed.Location = new System.Drawing.Point(9, 117);
            this.inSeed.Name = "inSeed";
            this.inSeed.Size = new System.Drawing.Size(189, 27);
            this.inSeed.TabIndex = 8;
            // 
            // inFile
            // 
            this.inFile.Location = new System.Drawing.Point(3, 3);
            this.inFile.Name = "inFile";
            this.inFile.Size = new System.Drawing.Size(210, 25);
            this.inFile.TabIndex = 2;
            // 
            // inNPS
            // 
            this.inNPS.DataIsInteger = true;
            this.inNPS.Label = "NPS:";
            this.inNPS.Location = new System.Drawing.Point(6, 47);
            this.inNPS.Name = "inNPS";
            this.inNPS.Size = new System.Drawing.Size(189, 27);
            this.inNPS.TabIndex = 7;
            // 
            // inActivity
            // 
            this.inActivity.DataIsInteger = true;
            this.inActivity.Label = "Activity (Bqs):";
            this.inActivity.Location = new System.Drawing.Point(6, 14);
            this.inActivity.Name = "inActivity";
            this.inActivity.Size = new System.Drawing.Size(189, 27);
            this.inActivity.TabIndex = 6;
            // 
            // PoliMiSpecification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inSeed);
            this.Controls.Add(this.bAddPoliMi);
            this.Controls.Add(this.inFile);
            this.Controls.Add(this.groupBox1);
            this.Name = "PoliMiSpecification";
            this.Size = new System.Drawing.Size(217, 180);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inSeed;
        private InputNumber inNPS;
        private InputNumber inActivity;
        private InputFile inFile;
        private System.Windows.Forms.Button bAddPoliMi;
    }
}
