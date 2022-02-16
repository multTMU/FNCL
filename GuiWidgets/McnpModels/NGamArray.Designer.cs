namespace GuiWidgets.McnpModels
{
    partial class NGamArray
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
            this.inStandOff = new GuiWidgets.InputNumber();
            this.inShieldThickness = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inShieldThickness);
            this.groupBox1.Controls.Add(this.inStandOff);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NaI Array 3x4";
            // 
            // inStandOff
            // 
            this.inStandOff.DataIsInteger = true;
            this.inStandOff.Label = "Detector-Face Stand Off:";
            this.inStandOff.Location = new System.Drawing.Point(6, 19);
            this.inStandOff.Name = "inStandOff";
            this.inStandOff.Size = new System.Drawing.Size(223, 25);
            this.inStandOff.TabIndex = 0;
            // 
            // inShieldThickness
            // 
            this.inShieldThickness.DataIsInteger = true;
            this.inShieldThickness.Label = "Shield Thickness:";
            this.inShieldThickness.Location = new System.Drawing.Point(6, 50);
            this.inShieldThickness.Name = "inShieldThickness";
            this.inShieldThickness.Size = new System.Drawing.Size(223, 25);
            this.inShieldThickness.TabIndex = 1;
            // 
            // NGamArray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "NGamArray";
            this.Size = new System.Drawing.Size(244, 85);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inShieldThickness;
        private InputNumber inStandOff;
    }
}
