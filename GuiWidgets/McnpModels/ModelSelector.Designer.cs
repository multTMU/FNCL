namespace GuiWidgets
{
    partial class ModelSelector
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
            this.bAmLi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bStarfireSEL = new System.Windows.Forms.Button();
            this.bStarfire = new System.Windows.Forms.Button();
            this.bMP320SEL = new System.Windows.Forms.Button();
            this.bMP320 = new System.Windows.Forms.Button();
            this.bAmLiSEL = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bNGam12Array = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAmLi
            // 
            this.bAmLi.Location = new System.Drawing.Point(6, 19);
            this.bAmLi.Name = "bAmLi";
            this.bAmLi.Size = new System.Drawing.Size(75, 23);
            this.bAmLi.TabIndex = 0;
            this.bAmLi.Text = "AmLi";
            this.bAmLi.UseVisualStyleBackColor = true;
            this.bAmLi.Click += new System.EventHandler(this.bAmLi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bStarfireSEL);
            this.groupBox1.Controls.Add(this.bStarfire);
            this.groupBox1.Controls.Add(this.bMP320SEL);
            this.groupBox1.Controls.Add(this.bMP320);
            this.groupBox1.Controls.Add(this.bAmLiSEL);
            this.groupBox1.Controls.Add(this.bAmLi);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FNCL Models";
            // 
            // bStarfireSEL
            // 
            this.bStarfireSEL.Enabled = false;
            this.bStarfireSEL.Location = new System.Drawing.Point(168, 48);
            this.bStarfireSEL.Name = "bStarfireSEL";
            this.bStarfireSEL.Size = new System.Drawing.Size(75, 23);
            this.bStarfireSEL.TabIndex = 7;
            this.bStarfireSEL.Text = "Starfire SEL";
            this.bStarfireSEL.UseVisualStyleBackColor = true;
            this.bStarfireSEL.Click += new System.EventHandler(this.bStarfireSEL_Click);
            // 
            // bStarfire
            // 
            this.bStarfire.Location = new System.Drawing.Point(168, 19);
            this.bStarfire.Name = "bStarfire";
            this.bStarfire.Size = new System.Drawing.Size(75, 23);
            this.bStarfire.TabIndex = 6;
            this.bStarfire.Text = "Starfire";
            this.bStarfire.UseVisualStyleBackColor = true;
            this.bStarfire.Click += new System.EventHandler(this.bStarfire_Click);
            // 
            // bMP320SEL
            // 
            this.bMP320SEL.Enabled = false;
            this.bMP320SEL.Location = new System.Drawing.Point(87, 48);
            this.bMP320SEL.Name = "bMP320SEL";
            this.bMP320SEL.Size = new System.Drawing.Size(75, 23);
            this.bMP320SEL.TabIndex = 4;
            this.bMP320SEL.Text = "M320 SEL";
            this.bMP320SEL.UseVisualStyleBackColor = true;
            this.bMP320SEL.Click += new System.EventHandler(this.bMP320SEL_Click);
            // 
            // bMP320
            // 
            this.bMP320.Location = new System.Drawing.Point(87, 19);
            this.bMP320.Name = "bMP320";
            this.bMP320.Size = new System.Drawing.Size(75, 23);
            this.bMP320.TabIndex = 3;
            this.bMP320.Text = "MP320";
            this.bMP320.UseVisualStyleBackColor = true;
            this.bMP320.Click += new System.EventHandler(this.bMP320_Click);
            // 
            // bAmLiSEL
            // 
            this.bAmLiSEL.Enabled = false;
            this.bAmLiSEL.Location = new System.Drawing.Point(6, 48);
            this.bAmLiSEL.Name = "bAmLiSEL";
            this.bAmLiSEL.Size = new System.Drawing.Size(75, 23);
            this.bAmLiSEL.TabIndex = 1;
            this.bAmLiSEL.Text = "AmLi SEL";
            this.bAmLiSEL.UseVisualStyleBackColor = true;
            this.bAmLiSEL.Click += new System.EventHandler(this.bAmLiSEL_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bNGam12Array);
            this.groupBox2.Location = new System.Drawing.Point(3, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Neutron Capture Gamma Models";
            // 
            // bNGam12Array
            // 
            this.bNGam12Array.Location = new System.Drawing.Point(6, 19);
            this.bNGam12Array.Name = "bNGam12Array";
            this.bNGam12Array.Size = new System.Drawing.Size(75, 23);
            this.bNGam12Array.TabIndex = 8;
            this.bNGam12Array.Text = "NaI-Array";
            this.bNGam12Array.UseVisualStyleBackColor = true;
            this.bNGam12Array.Click += new System.EventHandler(this.bNGam12Array_Click);
            // 
            // ModelSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModelSelector";
            this.Size = new System.Drawing.Size(254, 141);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAmLi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bAmLiSEL;
        private System.Windows.Forms.Button bStarfireSEL;
        private System.Windows.Forms.Button bStarfire;
        private System.Windows.Forms.Button bMP320SEL;
        private System.Windows.Forms.Button bMP320;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bNGam12Array;
    }
}
