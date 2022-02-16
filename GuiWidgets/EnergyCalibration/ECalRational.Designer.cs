namespace GuiWidgets.EnergyCalibration
{
    partial class ECalRational
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
            this.inDenomerator = new GuiWidgets.InputNumber();
            this.inNumerator = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E(x) = Ax^2/( x + B)";
            // 
            // inDenomerator
            // 
            this.inDenomerator.DataIsInteger = true;
            this.inDenomerator.Label = "B:";
            this.inDenomerator.Location = new System.Drawing.Point(3, 58);
            this.inDenomerator.Name = "inDenomerator";
            this.inDenomerator.Size = new System.Drawing.Size(111, 27);
            this.inDenomerator.TabIndex = 12;
            // 
            // inNumerator
            // 
            this.inNumerator.DataIsInteger = true;
            this.inNumerator.Label = "A:";
            this.inNumerator.Location = new System.Drawing.Point(3, 25);
            this.inNumerator.Name = "inNumerator";
            this.inNumerator.Size = new System.Drawing.Size(111, 27);
            this.inNumerator.TabIndex = 13;
            // 
            // ECalRational
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inNumerator);
            this.Controls.Add(this.inDenomerator);
            this.Controls.Add(this.label1);
            this.Name = "ECalRational";
            this.Size = new System.Drawing.Size(118, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private InputNumber inDenomerator;
        private InputNumber inNumerator;
    }
}
