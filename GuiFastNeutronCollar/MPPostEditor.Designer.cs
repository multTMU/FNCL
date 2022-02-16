namespace GuiFastNeutronCollar
{
    partial class MPPostEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPPostEditor));
            this.mpPostIO1 = new GuiWidgets.MPPost.MPPostIO();
            this.mpPostSpecificationPanels1 = new GuiWidgets.MPPost.MPPostSpecificationPanels();
            this.SuspendLayout();
            // 
            // mpPostIO1
            // 
            this.mpPostIO1.Location = new System.Drawing.Point(3, 3);
            this.mpPostIO1.Name = "mpPostIO1";
            this.mpPostIO1.Size = new System.Drawing.Size(315, 88);
            this.mpPostIO1.TabIndex = 0;
            // 
            // mpPostSpecificationPanels1
            // 
            this.mpPostSpecificationPanels1.Location = new System.Drawing.Point(3, 97);
            this.mpPostSpecificationPanels1.Name = "mpPostSpecificationPanels1";
            this.mpPostSpecificationPanels1.Size = new System.Drawing.Size(998, 500);
            this.mpPostSpecificationPanels1.TabIndex = 1;
            // 
            // MPPostEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 596);
            this.Controls.Add(this.mpPostSpecificationPanels1);
            this.Controls.Add(this.mpPostIO1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1020, 635);
            this.MinimumSize = new System.Drawing.Size(1020, 635);
            this.Name = "MPPostEditor";
            this.Text = "MPPostEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.MPPost.MPPostIO mpPostIO1;
        private GuiWidgets.MPPost.MPPostSpecificationPanels mpPostSpecificationPanels1;
    }
}