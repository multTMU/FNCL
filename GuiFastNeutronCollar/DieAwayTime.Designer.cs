namespace GuiFastNeutronCollar
{
    partial class DieAwayTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DieAwayTime));
            this.dieAwayTimeTool1 = new GuiWidgets.DieAwayTime.DieAwayTimeTool();
            this.SuspendLayout();
            // 
            // dieAwayTimeTool1
            // 
            this.dieAwayTimeTool1.Location = new System.Drawing.Point(-5, -7);
            this.dieAwayTimeTool1.Name = "dieAwayTimeTool1";
            this.dieAwayTimeTool1.Size = new System.Drawing.Size(792, 437);
            this.dieAwayTimeTool1.TabIndex = 0;
            // 
            // DieAwayTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 426);
            this.Controls.Add(this.dieAwayTimeTool1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 465);
            this.MinimumSize = new System.Drawing.Size(800, 465);
            this.Name = "DieAwayTime";
            this.Text = "Die-Away Time";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.DieAwayTime.DieAwayTimeTool dieAwayTimeTool1;
    }
}