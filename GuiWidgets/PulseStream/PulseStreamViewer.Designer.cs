namespace GuiWidgets.PulseStream
{
    partial class PulseStreamViewer
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
            this.histogramPlotter1 = new GuiWidgets.HistogramPlotter();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // histogramPlotter1
            // 
            this.histogramPlotter1.Location = new System.Drawing.Point(3, 3);
            this.histogramPlotter1.Name = "histogramPlotter1";
            this.histogramPlotter1.Size = new System.Drawing.Size(598, 299);
            this.histogramPlotter1.TabIndex = 0;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-12, -11);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(630, 328);
            this.uniPanel1.TabIndex = 2;
            // 
            // PulseStreamViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.histogramPlotter1);
            this.Controls.Add(this.uniPanel1);
            this.Name = "PulseStreamViewer";
            this.Size = new System.Drawing.Size(608, 305);
            this.ResumeLayout(false);

        }

        #endregion

        private HistogramPlotter histogramPlotter1;
        private UniPanel uniPanel1;
    }
}
