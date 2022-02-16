namespace GuiWidgets.PileUpRejector
{
    partial class PileUpFilter
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
            this.inScalar = new GuiWidgets.InputNumber();
            this.inInterval = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inInterval);
            this.groupBox1.Controls.Add(this.inScalar);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pile-Up Rejector";
            // 
            // inScalar
            // 
            this.inScalar.DataIsInteger = true;
            this.inScalar.Label = "Scalar:";
            this.inScalar.Location = new System.Drawing.Point(6, 19);
            this.inScalar.Name = "inScalar";
            this.inScalar.Size = new System.Drawing.Size(210, 25);
            this.inScalar.TabIndex = 0;
            // 
            // inInterval
            // 
            this.inInterval.DataIsInteger = true;
            this.inInterval.Label = "Interval (ns):";
            this.inInterval.Location = new System.Drawing.Point(6, 50);
            this.inInterval.Name = "inInterval";
            this.inInterval.Size = new System.Drawing.Size(210, 25);
            this.inInterval.TabIndex = 1;
            // 
            // PileUpFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PileUpFilter";
            this.Size = new System.Drawing.Size(227, 86);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inInterval;
        private InputNumber inScalar;
    }
}
