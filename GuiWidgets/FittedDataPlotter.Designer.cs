namespace GuiWidgets
{
    partial class FittedDataPlotter
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.fittedData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.fittedData)).BeginInit();
            this.SuspendLayout();
            // 
            // fittedData
            // 
            this.fittedData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.fittedData.ChartAreas.Add(chartArea1);
            this.fittedData.Location = new System.Drawing.Point(3, 3);
            this.fittedData.Name = "fittedData";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.fittedData.Series.Add(series1);
            this.fittedData.Size = new System.Drawing.Size(593, 380);
            this.fittedData.TabIndex = 0;
            this.fittedData.Text = "chart1";
            // 
            // FittedDataPlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fittedData);
            this.Name = "FittedDataPlotter";
            this.Size = new System.Drawing.Size(599, 386);
            ((System.ComponentModel.ISupportInitialize)(this.fittedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart fittedData;
    }
}
