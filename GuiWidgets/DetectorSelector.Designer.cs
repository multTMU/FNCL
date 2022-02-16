namespace GuiWidgets
{
    partial class DetectorSelector
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbDetector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Detector:";
            // 
            // cbDetector
            // 
            this.cbDetector.FormattingEnabled = true;
            this.cbDetector.Location = new System.Drawing.Point(91, 3);
            this.cbDetector.Name = "cbDetector";
            this.cbDetector.Size = new System.Drawing.Size(121, 21);
            this.cbDetector.TabIndex = 1;
            this.cbDetector.SelectionChangeCommitted += new System.EventHandler(this.cbDetector_SelectionChangeCommitted);
            // 
            // DetectorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbDetector);
            this.Controls.Add(this.label1);
            this.Name = "DetectorSelector";
            this.Size = new System.Drawing.Size(217, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDetector;
    }
}
