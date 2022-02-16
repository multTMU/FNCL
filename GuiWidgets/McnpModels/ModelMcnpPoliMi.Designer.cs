namespace GuiWidgets.FnclModels
{
    partial class Model
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
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.bAddProblem = new System.Windows.Forms.Button();
            this.particleSelector1 = new GuiWidgets.ParticleSelector();
            this.mcnpSpec1 = new GuiWidgets.FnclModels.McnpSpec();
            this.uniPanelModel = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(238, 110);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(56, 17);
            this.cbActive.TabIndex = 2;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            this.cbActive.CheckedChanged += new System.EventHandler(this.cbActive_CheckedChanged);
            // 
            // bAddProblem
            // 
            this.bAddProblem.Location = new System.Drawing.Point(300, 106);
            this.bAddProblem.Name = "bAddProblem";
            this.bAddProblem.Size = new System.Drawing.Size(75, 23);
            this.bAddProblem.TabIndex = 3;
            this.bAddProblem.Text = "Add Problem";
            this.bAddProblem.UseVisualStyleBackColor = true;
            this.bAddProblem.Click += new System.EventHandler(this.bAddProblem_Click);
            // 
            // particleSelector1
            // 
            this.particleSelector1.Location = new System.Drawing.Point(236, 7);
            this.particleSelector1.Name = "particleSelector1";
            this.particleSelector1.Size = new System.Drawing.Size(115, 97);
            this.particleSelector1.TabIndex = 4;
            // 
            // mcnpSpec1
            // 
            this.mcnpSpec1.Location = new System.Drawing.Point(3, 3);
            this.mcnpSpec1.Name = "mcnpSpec1";
            this.mcnpSpec1.Size = new System.Drawing.Size(227, 179);
            this.mcnpSpec1.TabIndex = 1;
            // 
            // uniPanelModel
            // 
            this.uniPanelModel.Location = new System.Drawing.Point(0, 180);
            this.uniPanelModel.Name = "uniPanelModel";
            this.uniPanelModel.Size = new System.Drawing.Size(394, 280);
            this.uniPanelModel.TabIndex = 0;
            // 
            // FnclModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.particleSelector1);
            this.Controls.Add(this.bAddProblem);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.mcnpSpec1);
            this.Controls.Add(this.uniPanelModel);
            this.Name = "Model";
            this.Size = new System.Drawing.Size(381, 437);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UniPanel uniPanelModel;
        private McnpSpec mcnpSpec1;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button bAddProblem;
        private ParticleSelector particleSelector1;
    }
}
