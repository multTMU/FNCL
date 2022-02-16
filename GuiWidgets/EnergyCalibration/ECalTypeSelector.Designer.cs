namespace GuiWidgets.EnergyCalibration
{
    partial class ECalTypeSelector
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
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbRational = new System.Windows.Forms.RadioButton();
            this.rbTrans = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbQuad = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(6, 19);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 0;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Location = new System.Drawing.Point(77, 19);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(54, 17);
            this.rbLinear.TabIndex = 1;
            this.rbLinear.TabStop = true;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            this.rbLinear.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbRational
            // 
            this.rbRational.AutoSize = true;
            this.rbRational.Location = new System.Drawing.Point(28, 63);
            this.rbRational.Name = "rbRational";
            this.rbRational.Size = new System.Drawing.Size(64, 17);
            this.rbRational.TabIndex = 2;
            this.rbRational.TabStop = true;
            this.rbRational.Text = "Rational";
            this.rbRational.UseVisualStyleBackColor = true;
            this.rbRational.CheckedChanged += new System.EventHandler(this.rbRational_CheckedChanged);
            // 
            // rbTrans
            // 
            this.rbTrans.AutoSize = true;
            this.rbTrans.Location = new System.Drawing.Point(76, 42);
            this.rbTrans.Name = "rbTrans";
            this.rbTrans.Size = new System.Drawing.Size(55, 17);
            this.rbTrans.TabIndex = 3;
            this.rbTrans.TabStop = true;
            this.rbTrans.Text = "Trans.";
            this.rbTrans.UseVisualStyleBackColor = true;
            this.rbTrans.CheckedChanged += new System.EventHandler(this.rbTrans_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbQuad);
            this.groupBox1.Controls.Add(this.rbLinear);
            this.groupBox1.Controls.Add(this.rbTrans);
            this.groupBox1.Controls.Add(this.rbNone);
            this.groupBox1.Controls.Add(this.rbRational);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 86);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select E-Cal Type";
            // 
            // rbQuad
            // 
            this.rbQuad.AutoSize = true;
            this.rbQuad.Location = new System.Drawing.Point(6, 42);
            this.rbQuad.Name = "rbQuad";
            this.rbQuad.Size = new System.Drawing.Size(68, 17);
            this.rbQuad.TabIndex = 4;
            this.rbQuad.TabStop = true;
            this.rbQuad.Text = "Quadatic";
            this.rbQuad.UseVisualStyleBackColor = true;
            this.rbQuad.CheckedChanged += new System.EventHandler(this.rbQuad_CheckedChanged);
            // 
            // ECalTypeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ECalTypeSelector";
            this.Size = new System.Drawing.Size(142, 91);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.RadioButton rbRational;
        private System.Windows.Forms.RadioButton rbTrans;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbQuad;
    }
}
