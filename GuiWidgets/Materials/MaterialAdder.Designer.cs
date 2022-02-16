namespace GuiWidgets.Materials
{
    partial class MaterialAdder
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
            this.materialViewer1 = new GuiWidgets.Materials.MaterialViewer();
            this.materialManager1 = new GuiWidgets.Materials.MaterialManager();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialViewer1);
            this.groupBox1.Controls.Add(this.materialManager1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(907, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/Edit Materials";
            // 
            // materialViewer1
            // 
            this.materialViewer1.Location = new System.Drawing.Point(245, 18);
            this.materialViewer1.Name = "materialViewer1";
            this.materialViewer1.Size = new System.Drawing.Size(659, 347);
            this.materialViewer1.TabIndex = 1;
            // 
            // materialManager1
            // 
            this.materialManager1.Location = new System.Drawing.Point(5, 18);
            this.materialManager1.Name = "materialManager1";
            this.materialManager1.Size = new System.Drawing.Size(235, 347);
            this.materialManager1.TabIndex = 0;
            // 
            // MaterialAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MaterialAdder";
            this.Size = new System.Drawing.Size(919, 381);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialViewer materialViewer1;
        private MaterialManager materialManager1;
    }
}
