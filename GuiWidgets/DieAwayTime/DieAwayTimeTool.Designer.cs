namespace GuiWidgets.DieAwayTime
{
    partial class DieAwayTimeTool
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
            this.bRun = new System.Windows.Forms.Button();
            this.histogramPlotter1 = new GuiWidgets.HistogramPlotter();
            this.fitSelector1 = new GuiWidgets.DieAwayTime.DieAwayFitter();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.inMaxTime = new GuiWidgets.InputNumber();
            this.inMinTime = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // bRun
            // 
            this.bRun.Location = new System.Drawing.Point(466, 392);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 5;
            this.bRun.Text = "Run";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // histogramPlotter1
            // 
            this.histogramPlotter1.Location = new System.Drawing.Point(13, 17);
            this.histogramPlotter1.Name = "histogramPlotter1";
            this.histogramPlotter1.Size = new System.Drawing.Size(528, 369);
            this.histogramPlotter1.TabIndex = 9;
            // 
            // fitSelector1
            // 
            this.fitSelector1.Location = new System.Drawing.Point(547, 17);
            this.fitSelector1.Name = "fitSelector1";
            this.fitSelector1.Size = new System.Drawing.Size(233, 252);
            this.fitSelector1.TabIndex = 7;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-15, -9);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(825, 459);
            this.uniPanel1.TabIndex = 0;
            // 
            // inMaxTime
            // 
            this.inMaxTime.DataIsInteger = true;
            this.inMaxTime.Label = "Maximum Time (ns):";
            this.inMaxTime.Location = new System.Drawing.Point(229, 390);
            this.inMaxTime.Name = "inMaxTime";
            this.inMaxTime.Size = new System.Drawing.Size(210, 25);
            this.inMaxTime.TabIndex = 10;
            // 
            // inMinTime
            // 
            this.inMinTime.DataIsInteger = true;
            this.inMinTime.Label = "Minimum Time (ns):";
            this.inMinTime.Location = new System.Drawing.Point(13, 390);
            this.inMinTime.Name = "inMinTime";
            this.inMinTime.Size = new System.Drawing.Size(210, 25);
            this.inMinTime.TabIndex = 11;
            // 
            // DieAwayTimeTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inMinTime);
            this.Controls.Add(this.inMaxTime);
            this.Controls.Add(this.histogramPlotter1);
            this.Controls.Add(this.fitSelector1);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.uniPanel1);
            this.Name = "DieAwayTimeTool";
            this.Size = new System.Drawing.Size(796, 439);
            this.ResumeLayout(false);

        }

        #endregion

        private UniPanel uniPanel1;
        private System.Windows.Forms.Button bRun;
        private DieAwayFitter fitSelector1;
        private HistogramPlotter histogramPlotter1;
        private InputNumber inMaxTime;
        private InputNumber inMinTime;
    }
}
