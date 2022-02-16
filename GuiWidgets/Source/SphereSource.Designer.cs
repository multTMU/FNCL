namespace GuiWidgets.Source
{
    partial class SphereSource
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
            this.inRadius = new GuiWidgets.InputNumber();
            this.set3D1 = new GuiWidgets.Source.Set3D();
            this.SuspendLayout();
            // 
            // inRadius
            // 
            this.inRadius.DataIsInteger = true;
            this.inRadius.Label = "Radius:";
            this.inRadius.Location = new System.Drawing.Point(3, 3);
            this.inRadius.Name = "inRadius";
            this.inRadius.Size = new System.Drawing.Size(139, 25);
            this.inRadius.TabIndex = 0;
            // 
            // set3D1
            // 
            this.set3D1.Location = new System.Drawing.Point(3, 33);
            this.set3D1.Name = "set3D1";
            this.set3D1.Size = new System.Drawing.Size(139, 118);
            this.set3D1.TabIndex = 1;
            // 
            // SphereSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.set3D1);
            this.Controls.Add(this.inRadius);
            this.Name = "SphereSource";
            this.Size = new System.Drawing.Size(143, 154);
            this.ResumeLayout(false);

        }

        #endregion

        private InputNumber inRadius;
        private Set3D set3D1;
    }
}
