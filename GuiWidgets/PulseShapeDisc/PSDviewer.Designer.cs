namespace GuiWidgets
{
    partial class PSDviewer
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
            this.cPSD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bPlotPSD = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPSDrange = new System.Windows.Forms.Label();
            this.inputPSDmax = new GuiWidgets.InputNumber();
            this.inputPSDmin = new GuiWidgets.InputNumber();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelAmpRange = new System.Windows.Forms.Label();
            this.inputAmpMax = new GuiWidgets.InputNumber();
            this.inputAmpMin = new GuiWidgets.InputNumber();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelDetector = new System.Windows.Forms.Label();
            this.bReload = new System.Windows.Forms.Button();
            this.bSaveAs = new System.Windows.Forms.Button();
            this.fnclDetectorButtons1 = new GuiWidgets.EnergyCalibration.FnclDetectorButtons();
            this.drawCurve1 = new GuiWidgets.PulseShapeDisc.DrawCurve();
            this.psdViewerEditor1 = new GuiWidgets.PulseShapeDisc.PsdViewerEditor();
            this.bWaveForm = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cPSD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cPSD
            // 
            chartArea1.Name = "ChartArea1";
            this.cPSD.ChartAreas.Add(chartArea1);
            this.cPSD.Location = new System.Drawing.Point(205, 0);
            this.cPSD.Margin = new System.Windows.Forms.Padding(2);
            this.cPSD.Name = "cPSD";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Name = "Series1";
            this.cPSD.Series.Add(series1);
            this.cPSD.Size = new System.Drawing.Size(487, 371);
            this.cPSD.TabIndex = 0;
            this.cPSD.Text = "chart1";
            this.cPSD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cPSD_MouseClick);
            // 
            // bPlotPSD
            // 
            this.bPlotPSD.Location = new System.Drawing.Point(922, 218);
            this.bPlotPSD.Name = "bPlotPSD";
            this.bPlotPSD.Size = new System.Drawing.Size(75, 23);
            this.bPlotPSD.TabIndex = 1;
            this.bPlotPSD.Text = "Plot";
            this.bPlotPSD.UseVisualStyleBackColor = true;
            this.bPlotPSD.Click += new System.EventHandler(this.bPlotPSD_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelPSDrange);
            this.groupBox1.Controls.Add(this.inputPSDmax);
            this.groupBox1.Controls.Add(this.inputPSDmin);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 102);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PSD";
            // 
            // labelPSDrange
            // 
            this.labelPSDrange.AutoSize = true;
            this.labelPSDrange.Location = new System.Drawing.Point(6, 19);
            this.labelPSDrange.Name = "labelPSDrange";
            this.labelPSDrange.Size = new System.Drawing.Size(35, 13);
            this.labelPSDrange.TabIndex = 10;
            this.labelPSDrange.Text = "label1";
            // 
            // inputPSDmax
            // 
            this.inputPSDmax.DataIsInteger = true;
            this.inputPSDmax.Label = "Max:";
            this.inputPSDmax.Location = new System.Drawing.Point(9, 65);
            this.inputPSDmax.Name = "inputPSDmax";
            this.inputPSDmax.Size = new System.Drawing.Size(125, 27);
            this.inputPSDmax.TabIndex = 9;
            // 
            // inputPSDmin
            // 
            this.inputPSDmin.DataIsInteger = true;
            this.inputPSDmin.Label = "Min:";
            this.inputPSDmin.Location = new System.Drawing.Point(6, 35);
            this.inputPSDmin.Name = "inputPSDmin";
            this.inputPSDmin.Size = new System.Drawing.Size(128, 27);
            this.inputPSDmin.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelAmpRange);
            this.groupBox2.Controls.Add(this.inputAmpMax);
            this.groupBox2.Controls.Add(this.inputAmpMin);
            this.groupBox2.Location = new System.Drawing.Point(162, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 102);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Amplitude";
            // 
            // labelAmpRange
            // 
            this.labelAmpRange.AutoSize = true;
            this.labelAmpRange.Location = new System.Drawing.Point(6, 16);
            this.labelAmpRange.Name = "labelAmpRange";
            this.labelAmpRange.Size = new System.Drawing.Size(35, 13);
            this.labelAmpRange.TabIndex = 12;
            this.labelAmpRange.Text = "label2";
            // 
            // inputAmpMax
            // 
            this.inputAmpMax.DataIsInteger = true;
            this.inputAmpMax.Label = "Max:";
            this.inputAmpMax.Location = new System.Drawing.Point(6, 65);
            this.inputAmpMax.Name = "inputAmpMax";
            this.inputAmpMax.Size = new System.Drawing.Size(128, 27);
            this.inputAmpMax.TabIndex = 11;
            // 
            // inputAmpMin
            // 
            this.inputAmpMin.DataIsInteger = true;
            this.inputAmpMin.Label = "Min:";
            this.inputAmpMin.Location = new System.Drawing.Point(6, 35);
            this.inputAmpMin.Name = "inputAmpMin";
            this.inputAmpMin.Size = new System.Drawing.Size(128, 27);
            this.inputAmpMin.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(697, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 124);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display Options";
            // 
            // labelDetector
            // 
            this.labelDetector.AutoSize = true;
            this.labelDetector.Location = new System.Drawing.Point(3, 0);
            this.labelDetector.Name = "labelDetector";
            this.labelDetector.Size = new System.Drawing.Size(35, 13);
            this.labelDetector.TabIndex = 12;
            this.labelDetector.Text = "label1";
            // 
            // bReload
            // 
            this.bReload.Location = new System.Drawing.Point(6, 348);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(58, 23);
            this.bReload.TabIndex = 13;
            this.bReload.Text = "Reload";
            this.bReload.UseVisualStyleBackColor = true;
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // bSaveAs
            // 
            this.bSaveAs.Location = new System.Drawing.Point(70, 348);
            this.bSaveAs.Name = "bSaveAs";
            this.bSaveAs.Size = new System.Drawing.Size(58, 23);
            this.bSaveAs.TabIndex = 14;
            this.bSaveAs.Text = "Save As";
            this.bSaveAs.UseVisualStyleBackColor = true;
            this.bSaveAs.Click += new System.EventHandler(this.bSaveAs_Click);
            // 
            // fnclDetectorButtons1
            // 
            this.fnclDetectorButtons1.Location = new System.Drawing.Point(3, 16);
            this.fnclDetectorButtons1.Name = "fnclDetectorButtons1";
            this.fnclDetectorButtons1.Size = new System.Drawing.Size(197, 329);
            this.fnclDetectorButtons1.TabIndex = 11;
            // 
            // drawCurve1
            // 
            this.drawCurve1.Location = new System.Drawing.Point(906, 69);
            this.drawCurve1.Name = "drawCurve1";
            this.drawCurve1.Size = new System.Drawing.Size(104, 109);
            this.drawCurve1.TabIndex = 10;
            // 
            // psdViewerEditor1
            // 
            this.psdViewerEditor1.Location = new System.Drawing.Point(697, 0);
            this.psdViewerEditor1.Name = "psdViewerEditor1";
            this.psdViewerEditor1.Size = new System.Drawing.Size(307, 250);
            this.psdViewerEditor1.TabIndex = 8;
            // 
            // bWaveForm
            // 
            this.bWaveForm.Location = new System.Drawing.Point(922, 184);
            this.bWaveForm.Name = "bWaveForm";
            this.bWaveForm.Size = new System.Drawing.Size(75, 23);
            this.bWaveForm.TabIndex = 15;
            this.bWaveForm.Text = "Waveforms";
            this.bWaveForm.UseVisualStyleBackColor = true;
            this.bWaveForm.Click += new System.EventHandler(this.bWaveForm_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(134, 348);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(58, 23);
            this.bLoad.TabIndex = 16;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // PSDviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bWaveForm);
            this.Controls.Add(this.bSaveAs);
            this.Controls.Add(this.bReload);
            this.Controls.Add(this.labelDetector);
            this.Controls.Add(this.fnclDetectorButtons1);
            this.Controls.Add(this.drawCurve1);
            this.Controls.Add(this.bPlotPSD);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.psdViewerEditor1);
            this.Controls.Add(this.cPSD);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PSDviewer";
            this.Size = new System.Drawing.Size(1016, 379);
            ((System.ComponentModel.ISupportInitialize)(this.cPSD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart cPSD;
        private System.Windows.Forms.Button bPlotPSD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private InputNumber inputPSDmax;
        private InputNumber inputPSDmin;
        private InputNumber inputAmpMax;
        private InputNumber inputAmpMin;
        private PulseShapeDisc.PsdViewerEditor psdViewerEditor1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelPSDrange;
        private System.Windows.Forms.Label labelAmpRange;
        private PulseShapeDisc.DrawCurve drawCurve1;
        private EnergyCalibration.FnclDetectorButtons fnclDetectorButtons1;
        private System.Windows.Forms.Label labelDetector;
        private System.Windows.Forms.Button bReload;
        private System.Windows.Forms.Button bSaveAs;
        private System.Windows.Forms.Button bWaveForm;
        private System.Windows.Forms.Button bLoad;
    }
}
