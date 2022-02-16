namespace GuiWidgets.EnergyCalibration
{
    partial class FnclDetectorButtons
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
            this.eCalPanel3 = new FnclPanel();
            this.eCalPanel2 = new FnclPanel();
            this.eCalPanel1 = new FnclPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eCalPanel3);
            this.groupBox1.Controls.Add(this.eCalPanel2);
            this.groupBox1.Controls.Add(this.eCalPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 323);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Energy Calibration";
            // 
            // eCalPanel3
            // 
            this.eCalPanel3.Location = new System.Drawing.Point(6, 225);
            this.eCalPanel3.Name = "eCalPanel3";
            this.eCalPanel3.Size = new System.Drawing.Size(177, 96);
            this.eCalPanel3.TabIndex = 2;
            // 
            // eCalPanel2
            // 
            this.eCalPanel2.Location = new System.Drawing.Point(6, 123);
            this.eCalPanel2.Name = "eCalPanel2";
            this.eCalPanel2.Size = new System.Drawing.Size(177, 96);
            this.eCalPanel2.TabIndex = 1;
            // 
            // eCalPanel1
            // 
            this.eCalPanel1.Location = new System.Drawing.Point(6, 21);
            this.eCalPanel1.Name = "eCalPanel1";
            this.eCalPanel1.Size = new System.Drawing.Size(177, 96);
            this.eCalPanel1.TabIndex = 0;
            // 
            // FnclEnergyCal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FnclEnergyCal";
            this.Size = new System.Drawing.Size(197, 329);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FnclPanel eCalPanel3;
        private FnclPanel eCalPanel2;
        private FnclPanel eCalPanel1;
    }
}
