namespace GuiWidgets.DieAwayTime
{
    partial class SingleExponentFit
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
            this.label1 = new System.Windows.Forms.Label();
            this.inScalar = new GuiWidgets.InputNumber();
            this.inDieAway = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rate( t ) = A exp( t / T )";
            // 
            // inScalar
            // 
            this.inScalar.DataIsInteger = true;
            this.inScalar.Label = "A:";
            this.inScalar.Location = new System.Drawing.Point(6, 16);
            this.inScalar.Name = "inScalar";
            this.inScalar.Size = new System.Drawing.Size(134, 25);
            this.inScalar.TabIndex = 1;
            // 
            // inDieAway
            // 
            this.inDieAway.DataIsInteger = true;
            this.inDieAway.Label = "T(ns):";
            this.inDieAway.Location = new System.Drawing.Point(6, 47);
            this.inDieAway.Name = "inDieAway";
            this.inDieAway.Size = new System.Drawing.Size(134, 25);
            this.inDieAway.TabIndex = 2;
            // 
            // SingleExponentFit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inDieAway);
            this.Controls.Add(this.inScalar);
            this.Controls.Add(this.label1);
            this.Name = "SingleExponentFit";
            this.Size = new System.Drawing.Size(139, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private InputNumber inScalar;
        private InputNumber inDieAway;
    }
}
