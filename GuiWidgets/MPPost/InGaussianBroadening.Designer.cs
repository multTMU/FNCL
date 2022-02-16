namespace GuiWidgets.MPPost
{
    partial class InGaussianBroadening
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
            this.inA = new GuiWidgets.InputNumber();
            this.inB = new GuiWidgets.InputNumber();
            this.inC = new GuiWidgets.InputNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.inEnableAsVariable = new GuiWidgets.InputBoolean();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inEnableAsVariable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inC);
            this.groupBox1.Controls.Add(this.inB);
            this.groupBox1.Controls.Add(this.inA);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gaussian Broadening";
            // 
            // inA
            // 
            this.inA.DataIsInteger = true;
            this.inA.Label = "A:";
            this.inA.Location = new System.Drawing.Point(6, 63);
            this.inA.Name = "inA";
            this.inA.Size = new System.Drawing.Size(210, 25);
            this.inA.TabIndex = 0;
            // 
            // inB
            // 
            this.inB.DataIsInteger = true;
            this.inB.Label = "B:";
            this.inB.Location = new System.Drawing.Point(6, 94);
            this.inB.Name = "inB";
            this.inB.Size = new System.Drawing.Size(210, 25);
            this.inB.TabIndex = 1;
            // 
            // inC
            // 
            this.inC.DataIsInteger = true;
            this.inC.Label = "C:";
            this.inC.Location = new System.Drawing.Point(6, 125);
            this.inC.Name = "inC";
            this.inC.Size = new System.Drawing.Size(210, 25);
            this.inC.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "delta L / L_Fwhm =A*L0+B*Sqrt(L0) + C";
            // 
            // inEnableAsVariable
            // 
            this.inEnableAsVariable.Label = "label1";
            this.inEnableAsVariable.Location = new System.Drawing.Point(6, 19);
            this.inEnableAsVariable.Name = "inEnableAsVariable";
            this.inEnableAsVariable.Size = new System.Drawing.Size(210, 25);
            this.inEnableAsVariable.TabIndex = 3;
            // 
            // InGaussianBroadening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "InGaussianBroadening";
            this.Size = new System.Drawing.Size(226, 161);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private InputNumber inC;
        private InputNumber inB;
        private InputNumber inA;
        private InputBoolean inEnableAsVariable;
    }
}
