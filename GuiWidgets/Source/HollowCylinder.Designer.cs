namespace GuiWidgets.Source
{
    partial class HollowCylinder
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
            this.inCenter = new GuiWidgets.Source.Set3D();
            this.inAxis = new GuiWidgets.Source.Set3D();
            this.inHeight = new GuiWidgets.InputNumber();
            this.inOutRadius = new GuiWidgets.InputNumber();
            this.inInRadius = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // inCenter
            // 
            this.inCenter.Location = new System.Drawing.Point(3, 3);
            this.inCenter.Name = "inCenter";
            this.inCenter.Size = new System.Drawing.Size(139, 118);
            this.inCenter.TabIndex = 0;
            // 
            // inAxis
            // 
            this.inAxis.Location = new System.Drawing.Point(148, 3);
            this.inAxis.Name = "inAxis";
            this.inAxis.Size = new System.Drawing.Size(139, 118);
            this.inAxis.TabIndex = 1;
            // 
            // inHeight
            // 
            this.inHeight.DataIsInteger = true;
            this.inHeight.Label = "Height:";
            this.inHeight.Location = new System.Drawing.Point(293, 19);
            this.inHeight.Name = "inHeight";
            this.inHeight.Size = new System.Drawing.Size(210, 25);
            this.inHeight.TabIndex = 2;
            // 
            // inOutRadius
            // 
            this.inOutRadius.DataIsInteger = true;
            this.inOutRadius.Label = "Outer Radius:";
            this.inOutRadius.Location = new System.Drawing.Point(293, 50);
            this.inOutRadius.Name = "inOutRadius";
            this.inOutRadius.Size = new System.Drawing.Size(210, 25);
            this.inOutRadius.TabIndex = 3;
            // 
            // inInRadius
            // 
            this.inInRadius.DataIsInteger = true;
            this.inInRadius.Label = "Inner Radius:";
            this.inInRadius.Location = new System.Drawing.Point(293, 81);
            this.inInRadius.Name = "inInRadius";
            this.inInRadius.Size = new System.Drawing.Size(210, 25);
            this.inInRadius.TabIndex = 4;
            // 
            // HollowCylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inInRadius);
            this.Controls.Add(this.inOutRadius);
            this.Controls.Add(this.inHeight);
            this.Controls.Add(this.inAxis);
            this.Controls.Add(this.inCenter);
            this.Name = "HollowCylinder";
            this.Size = new System.Drawing.Size(514, 124);
            this.ResumeLayout(false);

        }

        #endregion

        private Set3D inCenter;
        private Set3D inAxis;
        private InputNumber inHeight;
        private InputNumber inOutRadius;
        private InputNumber inInRadius;
    }
}
