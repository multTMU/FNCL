namespace GuiWidgets
{
    partial class ParticleSelector
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
            this.rbPhoton = new System.Windows.Forms.RadioButton();
            this.rbNeutron = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbBoth);
            this.groupBox1.Controls.Add(this.rbPhoton);
            this.groupBox1.Controls.Add(this.rbNeutron);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Particle(s)";
            // 
            // rbPhoton
            // 
            this.rbPhoton.AutoSize = true;
            this.rbPhoton.Location = new System.Drawing.Point(6, 42);
            this.rbPhoton.Name = "rbPhoton";
            this.rbPhoton.Size = new System.Drawing.Size(59, 17);
            this.rbPhoton.TabIndex = 1;
            this.rbPhoton.TabStop = true;
            this.rbPhoton.Text = "Photon";
            this.rbPhoton.UseVisualStyleBackColor = true;
            this.rbPhoton.CheckedChanged += new System.EventHandler(this.rbPhoton_CheckedChanged);
            // 
            // rbNeutron
            // 
            this.rbNeutron.AutoSize = true;
            this.rbNeutron.Location = new System.Drawing.Point(6, 19);
            this.rbNeutron.Name = "rbNeutron";
            this.rbNeutron.Size = new System.Drawing.Size(63, 17);
            this.rbNeutron.TabIndex = 0;
            this.rbNeutron.TabStop = true;
            this.rbNeutron.Text = "Neutron";
            this.rbNeutron.UseVisualStyleBackColor = true;
            this.rbNeutron.CheckedChanged += new System.EventHandler(this.rbNeutron_CheckedChanged);
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(6, 65);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(47, 17);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.TabStop = true;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rbBoth_CheckedChanged);
            // 
            // ParticleSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ParticleSelector";
            this.Size = new System.Drawing.Size(115, 97);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPhoton;
        private System.Windows.Forms.RadioButton rbNeutron;
        private System.Windows.Forms.RadioButton rbBoth;
    }
}
