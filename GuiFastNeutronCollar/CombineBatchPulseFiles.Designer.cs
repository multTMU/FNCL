namespace GuiFastNeutronCollar
{
    partial class CombineBatchPulseFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombineBatchPulseFiles));
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.batchCombinePulses1 = new GuiWidgets.CombinePulses.BatchCombinePulses();
            this.SuspendLayout();
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-12, -14);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(276, 229);
            this.uniPanel1.TabIndex = 0;
            // 
            // batchCombinePulses1
            // 
            this.batchCombinePulses1.Location = new System.Drawing.Point(12, 12);
            this.batchCombinePulses1.Name = "batchCombinePulses1";
            this.batchCombinePulses1.Size = new System.Drawing.Size(230, 180);
            this.batchCombinePulses1.TabIndex = 1;
            // 
            // CombineBatchPulseFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 201);
            this.Controls.Add(this.batchCombinePulses1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 240);
            this.MinimumSize = new System.Drawing.Size(270, 240);
            this.Name = "CombineBatchPulseFiles";
            this.Text = "Combine Batch Pulse Files";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.CombinePulses.BatchCombinePulses batchCombinePulses1;
    }
}