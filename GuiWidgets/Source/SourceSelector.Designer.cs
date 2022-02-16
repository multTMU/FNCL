namespace GuiWidgets
{
    partial class SourceSelector
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
            this.rbPeSphere = new System.Windows.Forms.RadioButton();
            this.rbNbl = new System.Windows.Forms.RadioButton();
            this.rbFuel = new System.Windows.Forms.RadioButton();
            this.rbCyl = new System.Windows.Forms.RadioButton();
            this.rbUhollowCyl = new System.Windows.Forms.RadioButton();
            this.rbSphere = new System.Windows.Forms.RadioButton();
            this.rbPoint = new System.Windows.Forms.RadioButton();
            this.rbSphereShell = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSphereShell);
            this.groupBox1.Controls.Add(this.rbPeSphere);
            this.groupBox1.Controls.Add(this.rbNbl);
            this.groupBox1.Controls.Add(this.rbFuel);
            this.groupBox1.Controls.Add(this.rbCyl);
            this.groupBox1.Controls.Add(this.rbUhollowCyl);
            this.groupBox1.Controls.Add(this.rbSphere);
            this.groupBox1.Controls.Add(this.rbPoint);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Source";
            // 
            // rbPeSphere
            // 
            this.rbPeSphere.AutoSize = true;
            this.rbPeSphere.Location = new System.Drawing.Point(58, 42);
            this.rbPeSphere.Name = "rbPeSphere";
            this.rbPeSphere.Size = new System.Drawing.Size(92, 17);
            this.rbPeSphere.TabIndex = 6;
            this.rbPeSphere.TabStop = true;
            this.rbPeSphere.Text = "HDPE Sphere";
            this.rbPeSphere.UseVisualStyleBackColor = true;
            this.rbPeSphere.CheckedChanged += new System.EventHandler(this.rbPeSphere_CheckedChanged);
            // 
            // rbNbl
            // 
            this.rbNbl.AutoSize = true;
            this.rbNbl.Location = new System.Drawing.Point(6, 42);
            this.rbNbl.Name = "rbNbl";
            this.rbNbl.Size = new System.Drawing.Size(46, 17);
            this.rbNbl.TabIndex = 5;
            this.rbNbl.TabStop = true;
            this.rbNbl.Text = "NBL";
            this.rbNbl.UseVisualStyleBackColor = true;
            this.rbNbl.CheckedChanged += new System.EventHandler(this.rbNbl_CheckedChanged);
            // 
            // rbFuel
            // 
            this.rbFuel.AutoSize = true;
            this.rbFuel.Location = new System.Drawing.Point(297, 18);
            this.rbFuel.Name = "rbFuel";
            this.rbFuel.Size = new System.Drawing.Size(48, 17);
            this.rbFuel.TabIndex = 4;
            this.rbFuel.TabStop = true;
            this.rbFuel.Text = "Fuel ";
            this.rbFuel.UseVisualStyleBackColor = true;
            this.rbFuel.CheckedChanged += new System.EventHandler(this.rbFuel_CheckedChanged);
            // 
            // rbCyl
            // 
            this.rbCyl.AutoSize = true;
            this.rbCyl.Location = new System.Drawing.Point(229, 18);
            this.rbCyl.Name = "rbCyl";
            this.rbCyl.Size = new System.Drawing.Size(62, 17);
            this.rbCyl.TabIndex = 3;
            this.rbCyl.TabStop = true;
            this.rbCyl.Text = "Cylinder";
            this.rbCyl.UseVisualStyleBackColor = true;
            this.rbCyl.CheckedChanged += new System.EventHandler(this.rbCyl_CheckedChanged);
            // 
            // rbUhollowCyl
            // 
            this.rbUhollowCyl.AutoSize = true;
            this.rbUhollowCyl.Location = new System.Drawing.Point(126, 19);
            this.rbUhollowCyl.Name = "rbUhollowCyl";
            this.rbUhollowCyl.Size = new System.Drawing.Size(97, 17);
            this.rbUhollowCyl.TabIndex = 2;
            this.rbUhollowCyl.TabStop = true;
            this.rbUhollowCyl.Text = "Hollow Cylinder";
            this.rbUhollowCyl.UseVisualStyleBackColor = true;
            this.rbUhollowCyl.CheckedChanged += new System.EventHandler(this.rbUhollowCyl_CheckedChanged);
            // 
            // rbSphere
            // 
            this.rbSphere.AutoSize = true;
            this.rbSphere.Location = new System.Drawing.Point(61, 19);
            this.rbSphere.Name = "rbSphere";
            this.rbSphere.Size = new System.Drawing.Size(59, 17);
            this.rbSphere.TabIndex = 1;
            this.rbSphere.TabStop = true;
            this.rbSphere.Text = "Sphere";
            this.rbSphere.UseVisualStyleBackColor = true;
            this.rbSphere.CheckedChanged += new System.EventHandler(this.rbSphere_CheckedChanged);
            // 
            // rbPoint
            // 
            this.rbPoint.AutoSize = true;
            this.rbPoint.Location = new System.Drawing.Point(6, 19);
            this.rbPoint.Name = "rbPoint";
            this.rbPoint.Size = new System.Drawing.Size(49, 17);
            this.rbPoint.TabIndex = 0;
            this.rbPoint.TabStop = true;
            this.rbPoint.Text = "Point";
            this.rbPoint.UseVisualStyleBackColor = true;
            this.rbPoint.CheckedChanged += new System.EventHandler(this.rbPoint_CheckedChanged);
            // 
            // rbSphereShell
            // 
            this.rbSphereShell.AutoSize = true;
            this.rbSphereShell.Location = new System.Drawing.Point(156, 41);
            this.rbSphereShell.Name = "rbSphereShell";
            this.rbSphereShell.Size = new System.Drawing.Size(86, 17);
            this.rbSphereShell.TabIndex = 7;
            this.rbSphereShell.TabStop = true;
            this.rbSphereShell.Text = "Point in Shell";
            this.rbSphereShell.UseVisualStyleBackColor = true;
            this.rbSphereShell.CheckedChanged += new System.EventHandler(this.rbSphereShell_CheckedChanged);
            // 
            // SourceSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "SourceSelector";
            this.Size = new System.Drawing.Size(352, 69);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPoint;
        private System.Windows.Forms.RadioButton rbSphere;
        private System.Windows.Forms.RadioButton rbCyl;
        private System.Windows.Forms.RadioButton rbUhollowCyl;
        private System.Windows.Forms.RadioButton rbFuel;
        private System.Windows.Forms.RadioButton rbNbl;
        private System.Windows.Forms.RadioButton rbPeSphere;
        private System.Windows.Forms.RadioButton rbSphereShell;
    }
}
