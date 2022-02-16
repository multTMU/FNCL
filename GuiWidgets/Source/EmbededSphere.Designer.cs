namespace GuiWidgets.Source
{
    partial class EmbededSphere
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
            this.setCenter = new GuiWidgets.Source.Set3D();
            this.inInnerRadius = new GuiWidgets.InputNumber();
            this.inThickness = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // setCenter
            // 
            this.setCenter.Location = new System.Drawing.Point(3, 3);
            this.setCenter.Name = "setCenter";
            this.setCenter.Size = new System.Drawing.Size(139, 118);
            this.setCenter.TabIndex = 3;
            // 
            // inInnerRadius
            // 
            this.inInnerRadius.DataIsInteger = false;
            this.inInnerRadius.Label = "Inner Radius:";
            this.inInnerRadius.Location = new System.Drawing.Point(148, 16);
            this.inInnerRadius.Name = "inInnerRadius";
            this.inInnerRadius.Size = new System.Drawing.Size(178, 25);
            this.inInnerRadius.TabIndex = 2;
            // 
            // inThickness
            // 
            this.inThickness.DataIsInteger = false;
            this.inThickness.Label = "Shell Thickness:";
            this.inThickness.Location = new System.Drawing.Point(148, 47);
            this.inThickness.Name = "inThickness";
            this.inThickness.Size = new System.Drawing.Size(178, 25);
            this.inThickness.TabIndex = 4;
            // 
            // HdpeSphere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inThickness);
            this.Controls.Add(this.setCenter);
            this.Controls.Add(this.inInnerRadius);
            this.Name = "EmbededSphere";
            this.Size = new System.Drawing.Size(329, 123);
            this.ResumeLayout(false);

        }

        #endregion

        private Set3D setCenter;
        private InputNumber inInnerRadius;
        private InputNumber inThickness;
    }
}
