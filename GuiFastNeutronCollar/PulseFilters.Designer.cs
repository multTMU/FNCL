namespace GuiFastNeutronCollar
{
    partial class PulseFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PulseFilters));
            this.bApply = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.filterOrdering1 = new GuiWidgets.FilterOrder.FilterOrdering();
            this.pulseStreamControl1 = new GuiWidgets.PulseStream.PulseStreamControl();
            this.particleSelector1 = new GuiWidgets.ParticleSelector();
            this.fnclDetectorSelect1 = new GuiWidgets.FnclDetectorSelect();
            this.pulseProcessing1 = new GuiWidgets.PulseProcessing();
            this.pulseFilters1 = new GuiWidgets.PulseFilters();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.bSaveFlat = new System.Windows.Forms.Button();
            this.bBatchSaveFlat = new System.Windows.Forms.Button();
            this.pileUpFilter1 = new GuiWidgets.PileUpRejector.PileUpFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flatTopPulseFilter1 = new GuiWidgets.FilterPulses.FlatTopPulseFilter();
            this.bSaveFilters = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bApply
            // 
            this.bApply.Location = new System.Drawing.Point(1118, 364);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(75, 23);
            this.bApply.TabIndex = 4;
            this.bApply.Text = "Apply";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(1037, 364);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 7;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // filterOrdering1
            // 
            this.filterOrdering1.Location = new System.Drawing.Point(979, 12);
            this.filterOrdering1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filterOrdering1.Name = "filterOrdering1";
            this.filterOrdering1.Size = new System.Drawing.Size(215, 268);
            this.filterOrdering1.TabIndex = 6;
            // 
            // pulseStreamControl1
            // 
            this.pulseStreamControl1.Location = new System.Drawing.Point(746, 106);
            this.pulseStreamControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pulseStreamControl1.Name = "pulseStreamControl1";
            this.pulseStreamControl1.Size = new System.Drawing.Size(226, 90);
            this.pulseStreamControl1.TabIndex = 5;
            // 
            // particleSelector1
            // 
            this.particleSelector1.Location = new System.Drawing.Point(12, 12);
            this.particleSelector1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.particleSelector1.Name = "particleSelector1";
            this.particleSelector1.Size = new System.Drawing.Size(115, 92);
            this.particleSelector1.TabIndex = 0;
            // 
            // fnclDetectorSelect1
            // 
            this.fnclDetectorSelect1.Location = new System.Drawing.Point(12, 106);
            this.fnclDetectorSelect1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fnclDetectorSelect1.MaximumSize = new System.Drawing.Size(115, 280);
            this.fnclDetectorSelect1.MinimumSize = new System.Drawing.Size(115, 280);
            this.fnclDetectorSelect1.Name = "fnclDetectorSelect1";
            this.fnclDetectorSelect1.Size = new System.Drawing.Size(115, 280);
            this.fnclDetectorSelect1.TabIndex = 3;
            // 
            // pulseProcessing1
            // 
            this.pulseProcessing1.Location = new System.Drawing.Point(133, 12);
            this.pulseProcessing1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pulseProcessing1.Name = "pulseProcessing1";
            this.pulseProcessing1.Size = new System.Drawing.Size(313, 374);
            this.pulseProcessing1.TabIndex = 2;
            // 
            // pulseFilters1
            // 
            this.pulseFilters1.Location = new System.Drawing.Point(452, 12);
            this.pulseFilters1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pulseFilters1.Name = "pulseFilters1";
            this.pulseFilters1.Size = new System.Drawing.Size(286, 340);
            this.pulseFilters1.TabIndex = 1;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-13, -14);
            this.uniPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(1260, 445);
            this.uniPanel1.TabIndex = 0;
            // 
            // bSaveFlat
            // 
            this.bSaveFlat.Location = new System.Drawing.Point(81, 19);
            this.bSaveFlat.Name = "bSaveFlat";
            this.bSaveFlat.Size = new System.Drawing.Size(66, 23);
            this.bSaveFlat.TabIndex = 8;
            this.bSaveFlat.Text = "Current";
            this.bSaveFlat.UseVisualStyleBackColor = true;
            this.bSaveFlat.Click += new System.EventHandler(this.bSaveFlat_Click);
            // 
            // bBatchSaveFlat
            // 
            this.bBatchSaveFlat.Location = new System.Drawing.Point(6, 19);
            this.bBatchSaveFlat.Name = "bBatchSaveFlat";
            this.bBatchSaveFlat.Size = new System.Drawing.Size(69, 23);
            this.bBatchSaveFlat.TabIndex = 9;
            this.bBatchSaveFlat.Text = "Batch";
            this.bBatchSaveFlat.UseVisualStyleBackColor = true;
            this.bBatchSaveFlat.Click += new System.EventHandler(this.bBatchSaveFlat_Click);
            // 
            // pileUpFilter1
            // 
            this.pileUpFilter1.Interval = 0D;
            this.pileUpFilter1.Location = new System.Drawing.Point(746, 12);
            this.pileUpFilter1.Name = "pileUpFilter1";
            this.pileUpFilter1.Scalar = 0D;
            this.pileUpFilter1.Size = new System.Drawing.Size(227, 86);
            this.pileUpFilter1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bBatchSaveFlat);
            this.groupBox1.Controls.Add(this.bSaveFlat);
            this.groupBox1.Location = new System.Drawing.Point(1037, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Pules Flat";
            // 
            // flatTopPulseFilter1
            // 
            this.flatTopPulseFilter1.Location = new System.Drawing.Point(745, 199);
            this.flatTopPulseFilter1.Name = "flatTopPulseFilter1";
            this.flatTopPulseFilter1.Size = new System.Drawing.Size(227, 86);
            this.flatTopPulseFilter1.TabIndex = 12;
            // 
            // bSaveFilters
            // 
            this.bSaveFilters.Location = new System.Drawing.Point(746, 364);
            this.bSaveFilters.Name = "bSaveFilters";
            this.bSaveFilters.Size = new System.Drawing.Size(75, 23);
            this.bSaveFilters.TabIndex = 13;
            this.bSaveFilters.Text = "Save As...";
            this.bSaveFilters.UseVisualStyleBackColor = true;
            this.bSaveFilters.Click += new System.EventHandler(this.bSaveFilters_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(827, 364);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(75, 23);
            this.bLoad.TabIndex = 14;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // PulseFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 396);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bSaveFilters);
            this.Controls.Add(this.flatTopPulseFilter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pileUpFilter1);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.filterOrdering1);
            this.Controls.Add(this.pulseStreamControl1);
            this.Controls.Add(this.particleSelector1);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.fnclDetectorSelect1);
            this.Controls.Add(this.pulseProcessing1);
            this.Controls.Add(this.pulseFilters1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1220, 435);
            this.MinimumSize = new System.Drawing.Size(1220, 435);
            this.Name = "PulseFilters";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Pulse Filters";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.PulseFilters pulseFilters1;
        private GuiWidgets.PulseProcessing pulseProcessing1;
        private GuiWidgets.FnclDetectorSelect fnclDetectorSelect1;
        private System.Windows.Forms.Button bApply;
        private GuiWidgets.ParticleSelector particleSelector1;
        private GuiWidgets.PulseStream.PulseStreamControl pulseStreamControl1;
        private GuiWidgets.FilterOrder.FilterOrdering filterOrdering1;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Button bSaveFlat;
        private System.Windows.Forms.Button bBatchSaveFlat;
        private GuiWidgets.PileUpRejector.PileUpFilter pileUpFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GuiWidgets.FilterPulses.FlatTopPulseFilter flatTopPulseFilter1;
        private System.Windows.Forms.Button bSaveFilters;
        private System.Windows.Forms.Button bLoad;
    }
}