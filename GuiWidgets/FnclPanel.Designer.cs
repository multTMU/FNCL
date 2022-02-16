namespace GuiWidgets
{
    partial class FnclPanel
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
            this.bD3 = new System.Windows.Forms.Button();
            this.bD2 = new System.Windows.Forms.Button();
            this.bD4 = new System.Windows.Forms.Button();
            this.bD1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bD3);
            this.groupBox1.Controls.Add(this.bD2);
            this.groupBox1.Controls.Add(this.bD4);
            this.groupBox1.Controls.Add(this.bD1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Panel";
            // 
            // bD3
            // 
            this.bD3.Location = new System.Drawing.Point(6, 57);
            this.bD3.Name = "bD3";
            this.bD3.Size = new System.Drawing.Size(75, 23);
            this.bD3.TabIndex = 3;
            this.bD3.Text = "Det. Three";
            this.bD3.UseVisualStyleBackColor = true;
            this.bD3.Click += new System.EventHandler(this.bD3_Click);
            // 
            // bD2
            // 
            this.bD2.Location = new System.Drawing.Point(87, 28);
            this.bD2.Name = "bD2";
            this.bD2.Size = new System.Drawing.Size(75, 23);
            this.bD2.TabIndex = 2;
            this.bD2.Text = "Det. Two";
            this.bD2.UseVisualStyleBackColor = true;
            this.bD2.Click += new System.EventHandler(this.bD2_Click);
            // 
            // bD4
            // 
            this.bD4.Location = new System.Drawing.Point(87, 57);
            this.bD4.Name = "bD4";
            this.bD4.Size = new System.Drawing.Size(75, 23);
            this.bD4.TabIndex = 1;
            this.bD4.Text = "Det. Four";
            this.bD4.UseVisualStyleBackColor = true;
            this.bD4.Click += new System.EventHandler(this.bD4_Click);
            // 
            // bD1
            // 
            this.bD1.Location = new System.Drawing.Point(6, 28);
            this.bD1.Name = "bD1";
            this.bD1.Size = new System.Drawing.Size(75, 23);
            this.bD1.TabIndex = 0;
            this.bD1.Text = "Det. One";
            this.bD1.UseVisualStyleBackColor = true;
            this.bD1.Click += new System.EventHandler(this.bD1_Click);
            // 
            // ECalPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ECalPanel";
            this.Size = new System.Drawing.Size(177, 96);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bD1;
        private System.Windows.Forms.Button bD3;
        private System.Windows.Forms.Button bD2;
        private System.Windows.Forms.Button bD4;
    }
}
