namespace GuiWidgets.Source
{
    partial class PointSource
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
            this.set3D1 = new GuiWidgets.Source.Set3D();
            this.SuspendLayout();
            // 
            // set3D1
            // 
            this.set3D1.Location = new System.Drawing.Point(3, 3);
            this.set3D1.Name = "set3D1";
            this.set3D1.Size = new System.Drawing.Size(140, 120);
            this.set3D1.TabIndex = 0;
            // 
            // PointSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.set3D1);
            this.Name = "PointSource";
            this.Size = new System.Drawing.Size(146, 123);
            this.ResumeLayout(false);

        }

        #endregion

        private Source.Set3D set3D1;
    }
}
