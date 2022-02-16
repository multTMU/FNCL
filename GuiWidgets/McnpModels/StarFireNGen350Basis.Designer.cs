namespace GuiWidgets.McnpModels
{
    partial class StarFireNGen350Basis
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
            this.inSourcePoint = new GuiWidgets.Source.Set3D();
            this.inAxis = new GuiWidgets.Source.Set3D();
            this.inRotation = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inRotation);
            this.groupBox1.Controls.Add(this.inAxis);
            this.groupBox1.Controls.Add(this.inSourcePoint);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Starfire NGen-350 DD Generator";
            // 
            // inSourcePoint
            // 
            this.inSourcePoint.Location = new System.Drawing.Point(6, 19);
            this.inSourcePoint.Name = "inSourcePoint";
            this.inSourcePoint.Size = new System.Drawing.Size(139, 118);
            this.inSourcePoint.TabIndex = 8;
            // 
            // inAxis
            // 
            this.inAxis.Location = new System.Drawing.Point(145, 19);
            this.inAxis.Name = "inAxis";
            this.inAxis.Size = new System.Drawing.Size(139, 118);
            this.inAxis.TabIndex = 9;
            // 
            // inRotation
            // 
            this.inRotation.DataIsInteger = true;
            this.inRotation.Label = "Rotation (deg):";
            this.inRotation.Location = new System.Drawing.Point(6, 143);
            this.inRotation.Name = "inRotation";
            this.inRotation.Size = new System.Drawing.Size(210, 25);
            this.inRotation.TabIndex = 10;
            // 
            // StarFireNGen350Basis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "StarFireNGen350Basis";
            this.Size = new System.Drawing.Size(296, 263);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Source.Set3D inAxis;
        private Source.Set3D inSourcePoint;
        private InputNumber inRotation;
    }
}
