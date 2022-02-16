namespace GuiWidgets.SampleParameters
{
    partial class FissionParameters
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
            this.inNuBar = new GuiWidgets.Source.Set3D();
            this.inFissionEnum = new GuiWidgets.InputEnum();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inNuBar);
            this.groupBox1.Controls.Add(this.inFissionEnum);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Fission Paramters";
            // 
            // inNuBar
            // 
            this.inNuBar.Location = new System.Drawing.Point(6, 50);
            this.inNuBar.Name = "inNuBar";
            this.inNuBar.Size = new System.Drawing.Size(139, 118);
            this.inNuBar.TabIndex = 1;
            // 
            // inFissionEnum
            // 
            this.inFissionEnum.Label = "label1";
            this.inFissionEnum.Location = new System.Drawing.Point(6, 19);
            this.inFissionEnum.Name = "inFissionEnum";
            this.inFissionEnum.Size = new System.Drawing.Size(210, 25);
            this.inFissionEnum.TabIndex = 0;
            // 
            // FissionParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FissionParameters";
            this.Size = new System.Drawing.Size(225, 176);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputEnum inFissionEnum;
        private Source.Set3D inNuBar;
    }
}
