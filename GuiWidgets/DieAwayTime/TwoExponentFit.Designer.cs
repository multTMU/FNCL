namespace GuiWidgets.DieAwayTime
{
    partial class TwoExponentFit
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
            this.inDieAwayOne = new GuiWidgets.InputNumber();
            this.inScalar = new GuiWidgets.InputNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.inDieAwayTwo = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // inDieAwayOne
            // 
            this.inDieAwayOne.DataIsInteger = true;
            this.inDieAwayOne.Label = "T1 (ns):";
            this.inDieAwayOne.Location = new System.Drawing.Point(6, 47);
            this.inDieAwayOne.Name = "inDieAwayOne";
            this.inDieAwayOne.Size = new System.Drawing.Size(134, 25);
            this.inDieAwayOne.TabIndex = 5;
            // 
            // inScalar
            // 
            this.inScalar.DataIsInteger = true;
            this.inScalar.Label = "A:";
            this.inScalar.Location = new System.Drawing.Point(6, 16);
            this.inScalar.Name = "inScalar";
            this.inScalar.Size = new System.Drawing.Size(134, 25);
            this.inScalar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rate( t ) = A exp( t / T1 ) (1 - exp ( t / T2 ) )";
            // 
            // inDieAwayTwo
            // 
            this.inDieAwayTwo.DataIsInteger = true;
            this.inDieAwayTwo.Label = "T2 (ns):";
            this.inDieAwayTwo.Location = new System.Drawing.Point(6, 78);
            this.inDieAwayTwo.Name = "inDieAwayTwo";
            this.inDieAwayTwo.Size = new System.Drawing.Size(134, 25);
            this.inDieAwayTwo.TabIndex = 6;
            // 
            // TwoExponentFit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inDieAwayTwo);
            this.Controls.Add(this.inDieAwayOne);
            this.Controls.Add(this.inScalar);
            this.Controls.Add(this.label1);
            this.Name = "TwoExponentFit";
            this.Size = new System.Drawing.Size(211, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InputNumber inDieAwayOne;
        private InputNumber inScalar;
        private System.Windows.Forms.Label label1;
        private InputNumber inDieAwayTwo;
    }
}
