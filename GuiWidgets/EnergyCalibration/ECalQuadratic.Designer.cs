namespace GuiWidgets.EnergyCalibration
{
    partial class ECalQuadratic
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
            this.inC1 = new GuiWidgets.InputNumber();
            this.inC2 = new GuiWidgets.InputNumber();
            this.inC0 = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E(x) = Ax^2 + Bx + C";
            // 
            // inC1
            // 
            this.inC1.DataIsInteger = true;
            this.inC1.Label = "B:";
            this.inC1.Location = new System.Drawing.Point(3, 51);
            this.inC1.Name = "inC1";
            this.inC1.Size = new System.Drawing.Size(111, 27);
            this.inC1.TabIndex = 6;
            // 
            // inC2
            // 
            this.inC2.DataIsInteger = true;
            this.inC2.Label = "A:";
            this.inC2.Location = new System.Drawing.Point(3, 22);
            this.inC2.Name = "inC2";
            this.inC2.Size = new System.Drawing.Size(111, 27);
            this.inC2.TabIndex = 5;
            // 
            // inC0
            // 
            this.inC0.DataIsInteger = true;
            this.inC0.Label = "C:";
            this.inC0.Location = new System.Drawing.Point(3, 84);
            this.inC0.Name = "inC0";
            this.inC0.Size = new System.Drawing.Size(111, 27);
            this.inC0.TabIndex = 9;
            // 
            // ECalQuadratic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inC0);
            this.Controls.Add(this.inC1);
            this.Controls.Add(this.inC2);
            this.Controls.Add(this.label1);
            this.Name = "ECalQuadratic";
            this.Size = new System.Drawing.Size(118, 116);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private InputNumber inC1;
        private InputNumber inC2;
        private InputNumber inC0;
    }
}
