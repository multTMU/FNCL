namespace GuiWidgets.EnergyCalibration
{
    partial class ECalFourthPoly
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
            this.inC2 = new GuiWidgets.InputNumber();
            this.inC3 = new GuiWidgets.InputNumber();
            this.inC4 = new GuiWidgets.InputNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.inC1 = new GuiWidgets.InputNumber();
            this.inC0 = new GuiWidgets.InputNumber();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inC2
            // 
            this.inC2.DataIsInteger = true;
            this.inC2.Label = "C:";
            this.inC2.Location = new System.Drawing.Point(3, 106);
            this.inC2.Name = "inC2";
            this.inC2.Size = new System.Drawing.Size(111, 27);
            this.inC2.TabIndex = 13;
            // 
            // inC3
            // 
            this.inC3.DataIsInteger = true;
            this.inC3.Label = "B:";
            this.inC3.Location = new System.Drawing.Point(3, 73);
            this.inC3.Name = "inC3";
            this.inC3.Size = new System.Drawing.Size(111, 27);
            this.inC3.TabIndex = 12;
            // 
            // inC4
            // 
            this.inC4.DataIsInteger = true;
            this.inC4.Label = "A:";
            this.inC4.Location = new System.Drawing.Point(3, 44);
            this.inC4.Name = "inC4";
            this.inC4.Size = new System.Drawing.Size(111, 27);
            this.inC4.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "E(x) = Ax^4 + Bx^3 +";
            // 
            // inC1
            // 
            this.inC1.DataIsInteger = true;
            this.inC1.Label = "D:";
            this.inC1.Location = new System.Drawing.Point(3, 139);
            this.inC1.Name = "inC1";
            this.inC1.Size = new System.Drawing.Size(111, 27);
            this.inC1.TabIndex = 14;
            // 
            // inC0
            // 
            this.inC0.DataIsInteger = true;
            this.inC0.Label = "E:";
            this.inC0.Location = new System.Drawing.Point(3, 172);
            this.inC0.Name = "inC0";
            this.inC0.Size = new System.Drawing.Size(111, 27);
            this.inC0.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cx^2 + Dx + E";
            // 
            // ECalFourthPoly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inC0);
            this.Controls.Add(this.inC1);
            this.Controls.Add(this.inC2);
            this.Controls.Add(this.inC3);
            this.Controls.Add(this.inC4);
            this.Controls.Add(this.label1);
            this.Name = "ECalFourthPoly";
            this.Size = new System.Drawing.Size(118, 203);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InputNumber inC2;
        private InputNumber inC3;
        private InputNumber inC4;
        private System.Windows.Forms.Label label1;
        private InputNumber inC1;
        private InputNumber inC0;
        private System.Windows.Forms.Label label2;
    }
}
