namespace GuiFastNeutronCollar
{
    partial class PulseShapeDiscrimination
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PulseShapeDiscrimination));
            this.psDviewer1 = new GuiWidgets.PSDviewer();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // psDviewer1
            // 
            this.psDviewer1.Location = new System.Drawing.Point(9, 11);
            this.psDviewer1.Margin = new System.Windows.Forms.Padding(2);
            this.psDviewer1.Name = "psDviewer1";
            this.psDviewer1.Size = new System.Drawing.Size(1006, 384);
            this.psDviewer1.TabIndex = 1;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-1, -2);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(1038, 419);
            this.uniPanel1.TabIndex = 0;
            // 
            // PulseShapeDiscrimination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 411);
            this.Controls.Add(this.psDviewer1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1040, 450);
            this.MinimumSize = new System.Drawing.Size(1040, 450);
            this.Name = "PulseShapeDiscrimination";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Pulse Shape Discrimination Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PulseShapeDiscrimination_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.PSDviewer psDviewer1;
    }
}