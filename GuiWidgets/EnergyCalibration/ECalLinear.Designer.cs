namespace GuiWidgets.EnergyCalibration
{
    partial class ECalLinear
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
            this.inSlope = new GuiWidgets.InputNumber();
            this.inIntercept = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E(x) = Ax + B";
            // 
            // inSlope
            // 
            this.inSlope.DataIsInteger = true;
            this.inSlope.Label = "A:";
            this.inSlope.Location = new System.Drawing.Point(3, 25);
            this.inSlope.Name = "inSlope";
            this.inSlope.Size = new System.Drawing.Size(111, 27);
            this.inSlope.TabIndex = 1;
            // 
            // inIntercept
            // 
            this.inIntercept.DataIsInteger = true;
            this.inIntercept.Label = "B:";
            this.inIntercept.Location = new System.Drawing.Point(3, 58);
            this.inIntercept.Name = "inIntercept";
            this.inIntercept.Size = new System.Drawing.Size(111, 27);
            this.inIntercept.TabIndex = 2;
            // 
            // ECalLinear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inIntercept);
            this.Controls.Add(this.inSlope);
            this.Controls.Add(this.label1);
            this.Name = "ECalLinear";
            this.Size = new System.Drawing.Size(119, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private InputNumber inSlope;
        private InputNumber inIntercept;
    }
}
