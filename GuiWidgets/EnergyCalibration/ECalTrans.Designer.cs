namespace GuiWidgets.EnergyCalibration
{
    partial class ECalTrans
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
            this.inExpPower = new GuiWidgets.InputNumber();
            this.inExpScalar = new GuiWidgets.InputNumber();
            this.inExpLinear = new GuiWidgets.InputNumber();
            this.inLinear = new GuiWidgets.InputNumber();
            this.inAmp = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E(x) = A ( Bx - C ( 1 - exp( Dx^E)))";
            // 
            // inExpPower
            // 
            this.inExpPower.DataIsInteger = true;
            this.inExpPower.Label = "E:";
            this.inExpPower.Location = new System.Drawing.Point(6, 154);
            this.inExpPower.Name = "inExpPower";
            this.inExpPower.Size = new System.Drawing.Size(111, 27);
            this.inExpPower.TabIndex = 16;
            // 
            // inExpScalar
            // 
            this.inExpScalar.DataIsInteger = true;
            this.inExpScalar.Label = "D:";
            this.inExpScalar.Location = new System.Drawing.Point(6, 121);
            this.inExpScalar.Name = "inExpScalar";
            this.inExpScalar.Size = new System.Drawing.Size(111, 27);
            this.inExpScalar.TabIndex = 15;
            // 
            // inExpLinear
            // 
            this.inExpLinear.DataIsInteger = true;
            this.inExpLinear.Label = "C:";
            this.inExpLinear.Location = new System.Drawing.Point(6, 88);
            this.inExpLinear.Name = "inExpLinear";
            this.inExpLinear.Size = new System.Drawing.Size(111, 27);
            this.inExpLinear.TabIndex = 14;
            // 
            // inLinear
            // 
            this.inLinear.DataIsInteger = true;
            this.inLinear.Label = "B:";
            this.inLinear.Location = new System.Drawing.Point(6, 55);
            this.inLinear.Name = "inLinear";
            this.inLinear.Size = new System.Drawing.Size(111, 27);
            this.inLinear.TabIndex = 11;
            // 
            // inAmp
            // 
            this.inAmp.DataIsInteger = true;
            this.inAmp.Label = "A:";
            this.inAmp.Location = new System.Drawing.Point(6, 26);
            this.inAmp.Name = "inAmp";
            this.inAmp.Size = new System.Drawing.Size(111, 27);
            this.inAmp.TabIndex = 10;
            // 
            // ECalTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inExpPower);
            this.Controls.Add(this.inExpScalar);
            this.Controls.Add(this.inExpLinear);
            this.Controls.Add(this.inLinear);
            this.Controls.Add(this.inAmp);
            this.Controls.Add(this.label1);
            this.Name = "ECalTrans";
            this.Size = new System.Drawing.Size(168, 185);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private InputNumber inExpLinear;
        private InputNumber inLinear;
        private InputNumber inAmp;
        private InputNumber inExpScalar;
        private InputNumber inExpPower;
    }
}
