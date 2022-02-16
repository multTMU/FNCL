namespace GuiFastNeutronCollar
{
    partial class MultiplicityViewer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplicityViewer));
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.multiplicityViewer1 = new GuiWidgets.Multiplicity.MultiplicityViewer();
            this.SuspendLayout();
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-5, -5);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(640, 475);
            this.uniPanel1.TabIndex = 0;
            // 
            // multiplicityViewer1
            // 
            this.multiplicityViewer1.Location = new System.Drawing.Point(12, 12);
            this.multiplicityViewer1.Name = "multiplicityViewer1";
            this.multiplicityViewer1.Size = new System.Drawing.Size(596, 438);
            this.multiplicityViewer1.TabIndex = 1;
            // 
            // MultiplicityViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 461);
            this.Controls.Add(this.multiplicityViewer1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(635, 500);
            this.MinimumSize = new System.Drawing.Size(635, 500);
            this.Name = "MultiplicityViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Multiplicity Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.Multiplicity.MultiplicityViewer multiplicityViewer1;
    }
}