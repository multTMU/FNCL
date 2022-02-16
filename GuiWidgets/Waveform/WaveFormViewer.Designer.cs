namespace GuiWidgets
{
    partial class WaveFormViewer
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbViewWave = new System.Windows.Forms.Label();
            this.bDecrease = new System.Windows.Forms.Button();
            this.bIncrease = new System.Windows.Forms.Button();
            this.tbCurrentPulse = new System.Windows.Forms.TextBox();
            this.chartWave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumberPulses = new System.Windows.Forms.TextBox();
            this.cbPersist = new System.Windows.Forms.CheckBox();
            this.bReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartWave)).BeginInit();
            this.SuspendLayout();
            // 
            // lbViewWave
            // 
            this.lbViewWave.AutoSize = true;
            this.lbViewWave.Location = new System.Drawing.Point(16, 39);
            this.lbViewWave.Name = "lbViewWave";
            this.lbViewWave.Size = new System.Drawing.Size(62, 13);
            this.lbViewWave.TabIndex = 0;
            this.lbViewWave.Text = "View Pulse:";
            // 
            // bDecrease
            // 
            this.bDecrease.Location = new System.Drawing.Point(76, 36);
            this.bDecrease.Name = "bDecrease";
            this.bDecrease.Size = new System.Drawing.Size(20, 20);
            this.bDecrease.TabIndex = 1;
            this.bDecrease.Text = "<";
            this.bDecrease.UseVisualStyleBackColor = true;
            this.bDecrease.Click += new System.EventHandler(this.bDecrease_Click);
            // 
            // bIncrease
            // 
            this.bIncrease.Location = new System.Drawing.Point(208, 36);
            this.bIncrease.Name = "bIncrease";
            this.bIncrease.Size = new System.Drawing.Size(20, 20);
            this.bIncrease.TabIndex = 2;
            this.bIncrease.Text = ">";
            this.bIncrease.UseVisualStyleBackColor = true;
            this.bIncrease.Click += new System.EventHandler(this.bIncrease_Click);
            // 
            // tbCurrentPulse
            // 
            this.tbCurrentPulse.Location = new System.Drawing.Point(102, 36);
            this.tbCurrentPulse.Name = "tbCurrentPulse";
            this.tbCurrentPulse.Size = new System.Drawing.Size(100, 20);
            this.tbCurrentPulse.TabIndex = 3;
            this.tbCurrentPulse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCurrentPulse_KeyPress);
            this.tbCurrentPulse.Validated += new System.EventHandler(this.tbCurrentPulse_Validated);
            // 
            // chartWave
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWave.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartWave.Legends.Add(legend1);
            this.chartWave.Location = new System.Drawing.Point(3, 128);
            this.chartWave.Name = "chartWave";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWave.Series.Add(series1);
            this.chartWave.Size = new System.Drawing.Size(553, 354);
            this.chartWave.TabIndex = 4;
            this.chartWave.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Pulses:";
            // 
            // tbNumberPulses
            // 
            this.tbNumberPulses.Location = new System.Drawing.Point(102, 10);
            this.tbNumberPulses.Name = "tbNumberPulses";
            this.tbNumberPulses.ReadOnly = true;
            this.tbNumberPulses.Size = new System.Drawing.Size(100, 20);
            this.tbNumberPulses.TabIndex = 6;
            // 
            // cbPersist
            // 
            this.cbPersist.AutoSize = true;
            this.cbPersist.Location = new System.Drawing.Point(6, 68);
            this.cbPersist.Margin = new System.Windows.Forms.Padding(2);
            this.cbPersist.Name = "cbPersist";
            this.cbPersist.Size = new System.Drawing.Size(57, 17);
            this.cbPersist.TabIndex = 7;
            this.cbPersist.Text = "Persist";
            this.cbPersist.UseVisualStyleBackColor = true;
            this.cbPersist.CheckedChanged += new System.EventHandler(this.cbPersist_CheckedChanged);
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(2, 89);
            this.bReset.Margin = new System.Windows.Forms.Padding(2);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(50, 20);
            this.bReset.TabIndex = 8;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(286, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 119);
            this.panel1.TabIndex = 10;
            // 
            // WaveFormViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.cbPersist);
            this.Controls.Add(this.tbNumberPulses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartWave);
            this.Controls.Add(this.tbCurrentPulse);
            this.Controls.Add(this.bIncrease);
            this.Controls.Add(this.bDecrease);
            this.Controls.Add(this.lbViewWave);
            this.Controls.Add(this.panel1);
            this.Name = "WaveFormViewer";
            this.Size = new System.Drawing.Size(561, 488);
            ((System.ComponentModel.ISupportInitialize)(this.chartWave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbViewWave;
        private System.Windows.Forms.Button bDecrease;
        private System.Windows.Forms.Button bIncrease;
        private System.Windows.Forms.TextBox tbCurrentPulse;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumberPulses;
        private System.Windows.Forms.CheckBox cbPersist;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Panel panel1;
    }
}
