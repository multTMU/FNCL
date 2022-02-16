namespace GuiWidgets.Source
{
    partial class NblStandard
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
            this.inFillHeight = new GuiWidgets.InputNumber();
            this.inAxis = new GuiWidgets.Source.Set3D();
            this.inCenter = new GuiWidgets.Source.Set3D();
            this.SuspendLayout();
            // 
            // inFillHeight
            // 
            this.inFillHeight.DataIsInteger = true;
            this.inFillHeight.Label = "Fill Height:";
            this.inFillHeight.Location = new System.Drawing.Point(3, 122);
            this.inFillHeight.Name = "inFillHeight";
            this.inFillHeight.Size = new System.Drawing.Size(284, 25);
            this.inFillHeight.TabIndex = 7;
            // 
            // inAxis
            // 
            this.inAxis.Location = new System.Drawing.Point(148, 3);
            this.inAxis.Name = "inAxis";
            this.inAxis.Size = new System.Drawing.Size(139, 118);
            this.inAxis.TabIndex = 9;
            // 
            // inCenter
            // 
            this.inCenter.Location = new System.Drawing.Point(3, 3);
            this.inCenter.Name = "inCenter";
            this.inCenter.Size = new System.Drawing.Size(139, 118);
            this.inCenter.TabIndex = 8;
            // 
            // NblStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inAxis);
            this.Controls.Add(this.inCenter);
            this.Controls.Add(this.inFillHeight);
            this.Name = "NblStandard";
            this.Size = new System.Drawing.Size(297, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private InputNumber inFillHeight;
        private Set3D inAxis;
        private Set3D inCenter;
    }
}
