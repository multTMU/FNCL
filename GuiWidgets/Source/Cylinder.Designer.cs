namespace GuiWidgets.Source
{
    partial class Cylinder
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
            this.inHeight = new GuiWidgets.InputNumber();
            this.inAxis = new GuiWidgets.Source.Set3D();
            this.inCenter = new GuiWidgets.Source.Set3D();
            this.SuspendLayout();
            // 
            // inRadius
            // 
            this.inRadius.DataIsInteger = true;
            this.inRadius.Label = "Radius:";
            this.inRadius.Location = new System.Drawing.Point(293, 50);
            this.inRadius.Name = "inRadius";
            this.inRadius.Size = new System.Drawing.Size(210, 25);
            this.inRadius.TabIndex = 7;
            // 
            // inHeight
            // 
            this.inHeight.DataIsInteger = true;
            this.inHeight.Label = "Height:";
            this.inHeight.Location = new System.Drawing.Point(293, 19);
            this.inHeight.Name = "inHeight";
            this.inHeight.Size = new System.Drawing.Size(210, 25);
            this.inHeight.TabIndex = 6;
            // 
            // inAxis
            // 
            this.inAxis.Location = new System.Drawing.Point(148, 3);
            this.inAxis.Name = "inAxis";
            this.inAxis.Size = new System.Drawing.Size(139, 118);
            this.inAxis.TabIndex = 5;
            // 
            // inCenter
            // 
            this.inCenter.Location = new System.Drawing.Point(3, 3);
            this.inCenter.Name = "inCenter";
            this.inCenter.Size = new System.Drawing.Size(139, 118);
            this.inCenter.TabIndex = 4;
            // 
            // Cylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inRadius);
            this.Controls.Add(this.inHeight);
            this.Controls.Add(this.inAxis);
            this.Controls.Add(this.inCenter);
            this.Name = "Cylinder";
            this.Size = new System.Drawing.Size(510, 123);
            this.ResumeLayout(false);

        }

        #endregion

        private InputNumber inRadius;
        private InputNumber inHeight;
        private Set3D inAxis;
        private Set3D inCenter;
    }
}
