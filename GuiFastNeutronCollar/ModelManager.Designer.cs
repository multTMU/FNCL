namespace GuiFastNeutronCollar
{
    partial class ModelManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelManager));
            this.problemRunner1 = new GuiWidgets.FnclModels.ProblemRunner();
            this.mcnpAndInterogator = new GuiWidgets.FnclModels.Model();
            this.materialViewer1 = new GuiWidgets.Materials.MaterialViewer();
            this.sourceSelection1 = new GuiWidgets.Source.SourceSelection();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // problemRunner1
            // 
            this.problemRunner1.Location = new System.Drawing.Point(12, 461);
            this.problemRunner1.Name = "problemRunner1";
            this.problemRunner1.Size = new System.Drawing.Size(380, 198);
            this.problemRunner1.TabIndex = 5;
            // 
            // mcnpAndInterogator
            // 
            this.mcnpAndInterogator.Location = new System.Drawing.Point(12, 12);
            this.mcnpAndInterogator.Name = "mcnpAndInterogator";
            this.mcnpAndInterogator.Size = new System.Drawing.Size(381, 443);
            this.mcnpAndInterogator.TabIndex = 4;
            // 
            // materialViewer1
            // 
            this.materialViewer1.Location = new System.Drawing.Point(399, 312);
            this.materialViewer1.Name = "materialViewer1";
            this.materialViewer1.Size = new System.Drawing.Size(659, 347);
            this.materialViewer1.TabIndex = 3;
            // 
            // sourceSelection1
            // 
            this.sourceSelection1.Location = new System.Drawing.Point(399, 12);
            this.sourceSelection1.Name = "sourceSelection1";
            this.sourceSelection1.Size = new System.Drawing.Size(659, 294);
            this.sourceSelection1.TabIndex = 2;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-10, -6);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(1117, 711);
            this.uniPanel1.TabIndex = 0;
            // 
            // ModelManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 671);
            this.Controls.Add(this.problemRunner1);
            this.Controls.Add(this.mcnpAndInterogator);
            this.Controls.Add(this.materialViewer1);
            this.Controls.Add(this.sourceSelection1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 710);
            this.MinimumSize = new System.Drawing.Size(1080, 710);
            this.Name = "ModelManager";
            this.Text = "MCNP-PoliMi Modeling";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.Source.SourceSelection sourceSelection1;
        private GuiWidgets.Materials.MaterialViewer materialViewer1;
        private GuiWidgets.FnclModels.Model mcnpAndInterogator;
        private GuiWidgets.FnclModels.ProblemRunner problemRunner1;
    }
}