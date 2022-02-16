namespace GuiFastNeutronCollar
{
    partial class FnclAnalysisGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FnclAnalysisGUI));
            this.tabAnalysis = new System.Windows.Forms.TabPage();
            this.gbAnalyze = new System.Windows.Forms.GroupBox();
            this.bMultiplicity = new System.Windows.Forms.Button();
            this.bDrf = new System.Windows.Forms.Button();
            this.bDieAway = new System.Windows.Forms.Button();
            this.bFilter = new System.Windows.Forms.Button();
            this.detectorSelector = new GuiWidgets.DetectorSelector();
            this.inPulseFile = new GuiWidgets.InputFile();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.bPileUp = new System.Windows.Forms.Button();
            this.bECal = new System.Windows.Forms.Button();
            this.bPulseStreamViewer = new System.Windows.Forms.Button();
            this.bPulseHeight = new System.Windows.Forms.Button();
            this.bPsd = new System.Windows.Forms.Button();
            this.bWaveform = new System.Windows.Forms.Button();
            this.pulseInfo = new GuiWidgets.PulseFileInformation();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.tabsSim = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bDetectorEditor = new System.Windows.Forms.Button();
            this.bMaterial = new System.Windows.Forms.Button();
            this.modelSelector1 = new GuiWidgets.ModelSelector();
            this.simConfig1 = new GuiWidgets.SimConfig();
            this.uniPanel2 = new GuiWidgets.UniPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergePoliMi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentPulsesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuelEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabAnalysis.SuspendLayout();
            this.gbAnalyze.SuspendLayout();
            this.gbView.SuspendLayout();
            this.tabsSim.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAnalysis
            // 
            this.tabAnalysis.Controls.Add(this.gbAnalyze);
            this.tabAnalysis.Controls.Add(this.bFilter);
            this.tabAnalysis.Controls.Add(this.detectorSelector);
            this.tabAnalysis.Controls.Add(this.inPulseFile);
            this.tabAnalysis.Controls.Add(this.gbView);
            this.tabAnalysis.Controls.Add(this.pulseInfo);
            this.tabAnalysis.Controls.Add(this.uniPanel1);
            this.tabAnalysis.Location = new System.Drawing.Point(4, 22);
            this.tabAnalysis.Name = "tabAnalysis";
            this.tabAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalysis.Size = new System.Drawing.Size(364, 313);
            this.tabAnalysis.TabIndex = 5;
            this.tabAnalysis.Text = "Analysis";
            this.tabAnalysis.UseVisualStyleBackColor = true;
            // 
            // gbAnalyze
            // 
            this.gbAnalyze.Controls.Add(this.bMultiplicity);
            this.gbAnalyze.Controls.Add(this.bDrf);
            this.gbAnalyze.Controls.Add(this.bDieAway);
            this.gbAnalyze.Location = new System.Drawing.Point(245, 206);
            this.gbAnalyze.Name = "gbAnalyze";
            this.gbAnalyze.Size = new System.Drawing.Size(116, 104);
            this.gbAnalyze.TabIndex = 23;
            this.gbAnalyze.TabStop = false;
            this.gbAnalyze.Text = "Analyze";
            // 
            // bMultiplicity
            // 
            this.bMultiplicity.Location = new System.Drawing.Point(6, 19);
            this.bMultiplicity.Name = "bMultiplicity";
            this.bMultiplicity.Size = new System.Drawing.Size(103, 23);
            this.bMultiplicity.TabIndex = 14;
            this.bMultiplicity.Text = "Multiplicity";
            this.bMultiplicity.UseVisualStyleBackColor = true;
            this.bMultiplicity.Click += new System.EventHandler(this.bMultiplicity_Click);
            // 
            // bDrf
            // 
            this.bDrf.Location = new System.Drawing.Point(6, 48);
            this.bDrf.Name = "bDrf";
            this.bDrf.Size = new System.Drawing.Size(103, 23);
            this.bDrf.TabIndex = 20;
            this.bDrf.Text = "DRF";
            this.bDrf.UseVisualStyleBackColor = true;
            this.bDrf.Click += new System.EventHandler(this.bDrf_Click);
            // 
            // bDieAway
            // 
            this.bDieAway.Location = new System.Drawing.Point(6, 77);
            this.bDieAway.Name = "bDieAway";
            this.bDieAway.Size = new System.Drawing.Size(103, 23);
            this.bDieAway.TabIndex = 17;
            this.bDieAway.Text = "Die-Away";
            this.bDieAway.UseVisualStyleBackColor = true;
            this.bDieAway.Click += new System.EventHandler(this.bDieAway_Click);
            // 
            // bFilter
            // 
            this.bFilter.Location = new System.Drawing.Point(62, 258);
            this.bFilter.Name = "bFilter";
            this.bFilter.Size = new System.Drawing.Size(110, 39);
            this.bFilter.TabIndex = 19;
            this.bFilter.Text = "Apply Pulse Filters";
            this.bFilter.UseVisualStyleBackColor = true;
            this.bFilter.Click += new System.EventHandler(this.bFilter_Click);
            // 
            // detectorSelector
            // 
            this.detectorSelector.Location = new System.Drawing.Point(7, 3);
            this.detectorSelector.Name = "detectorSelector";
            this.detectorSelector.Size = new System.Drawing.Size(227, 26);
            this.detectorSelector.TabIndex = 22;
            // 
            // inPulseFile
            // 
            this.inPulseFile.Label = "Pulse File:";
            this.inPulseFile.Location = new System.Drawing.Point(7, 35);
            this.inPulseFile.Name = "inPulseFile";
            this.inPulseFile.Size = new System.Drawing.Size(226, 25);
            this.inPulseFile.TabIndex = 21;
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.bPileUp);
            this.gbView.Controls.Add(this.bECal);
            this.gbView.Controls.Add(this.bPulseStreamViewer);
            this.gbView.Controls.Add(this.bPulseHeight);
            this.gbView.Controls.Add(this.bPsd);
            this.gbView.Controls.Add(this.bWaveform);
            this.gbView.Location = new System.Drawing.Point(245, 6);
            this.gbView.Name = "gbView";
            this.gbView.Size = new System.Drawing.Size(116, 198);
            this.gbView.TabIndex = 17;
            this.gbView.TabStop = false;
            this.gbView.Text = "View/Set";
            // 
            // bPileUp
            // 
            this.bPileUp.Location = new System.Drawing.Point(6, 48);
            this.bPileUp.Name = "bPileUp";
            this.bPileUp.Size = new System.Drawing.Size(103, 23);
            this.bPileUp.TabIndex = 21;
            this.bPileUp.Text = "Pile Up Rejector";
            this.bPileUp.UseVisualStyleBackColor = true;
            this.bPileUp.Click += new System.EventHandler(this.bPileUp_Click);
            // 
            // bECal
            // 
            this.bECal.Location = new System.Drawing.Point(6, 19);
            this.bECal.Name = "bECal";
            this.bECal.Size = new System.Drawing.Size(103, 23);
            this.bECal.TabIndex = 18;
            this.bECal.Text = "Energy Calibration";
            this.bECal.UseVisualStyleBackColor = true;
            this.bECal.Click += new System.EventHandler(this.bECal_Click);
            // 
            // bPulseStreamViewer
            // 
            this.bPulseStreamViewer.Location = new System.Drawing.Point(6, 164);
            this.bPulseStreamViewer.Name = "bPulseStreamViewer";
            this.bPulseStreamViewer.Size = new System.Drawing.Size(103, 23);
            this.bPulseStreamViewer.TabIndex = 19;
            this.bPulseStreamViewer.Text = "Pulse Stream";
            this.bPulseStreamViewer.UseVisualStyleBackColor = true;
            this.bPulseStreamViewer.Click += new System.EventHandler(this.bPulseStreamViewer_Click);
            // 
            // bPulseHeight
            // 
            this.bPulseHeight.Location = new System.Drawing.Point(6, 135);
            this.bPulseHeight.Name = "bPulseHeight";
            this.bPulseHeight.Size = new System.Drawing.Size(103, 23);
            this.bPulseHeight.TabIndex = 18;
            this.bPulseHeight.Text = "Pulse Amplitude";
            this.bPulseHeight.UseVisualStyleBackColor = true;
            this.bPulseHeight.Click += new System.EventHandler(this.bPulseHeight_Click);
            // 
            // bPsd
            // 
            this.bPsd.Location = new System.Drawing.Point(6, 77);
            this.bPsd.Name = "bPsd";
            this.bPsd.Size = new System.Drawing.Size(103, 23);
            this.bPsd.TabIndex = 16;
            this.bPsd.Text = "Pulse Shape";
            this.bPsd.UseVisualStyleBackColor = true;
            this.bPsd.Click += new System.EventHandler(this.bPsd_Click);
            // 
            // bWaveform
            // 
            this.bWaveform.Location = new System.Drawing.Point(6, 106);
            this.bWaveform.Name = "bWaveform";
            this.bWaveform.Size = new System.Drawing.Size(103, 23);
            this.bWaveform.TabIndex = 15;
            this.bWaveform.Text = "Waveform";
            this.bWaveform.UseVisualStyleBackColor = true;
            this.bWaveform.Click += new System.EventHandler(this.bWaveform_Click);
            // 
            // pulseInfo
            // 
            this.pulseInfo.Location = new System.Drawing.Point(7, 68);
            this.pulseInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pulseInfo.Name = "pulseInfo";
            this.pulseInfo.Size = new System.Drawing.Size(227, 182);
            this.pulseInfo.TabIndex = 12;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-10, -10);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(392, 354);
            this.uniPanel1.TabIndex = 0;
            // 
            // tabsSim
            // 
            this.tabsSim.Controls.Add(this.tabAnalysis);
            this.tabsSim.Controls.Add(this.tabPage1);
            this.tabsSim.Location = new System.Drawing.Point(12, 27);
            this.tabsSim.Name = "tabsSim";
            this.tabsSim.SelectedIndex = 0;
            this.tabsSim.Size = new System.Drawing.Size(372, 339);
            this.tabsSim.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bDetectorEditor);
            this.tabPage1.Controls.Add(this.bMaterial);
            this.tabPage1.Controls.Add(this.modelSelector1);
            this.tabPage1.Controls.Add(this.simConfig1);
            this.tabPage1.Controls.Add(this.uniPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(364, 313);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Simulation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bDetectorEditor
            // 
            this.bDetectorEditor.Location = new System.Drawing.Point(87, 104);
            this.bDetectorEditor.Name = "bDetectorEditor";
            this.bDetectorEditor.Size = new System.Drawing.Size(75, 38);
            this.bDetectorEditor.TabIndex = 4;
            this.bDetectorEditor.Text = "Detector Editor";
            this.bDetectorEditor.UseVisualStyleBackColor = true;
            this.bDetectorEditor.Click += new System.EventHandler(this.bDetectorEditor_Click);
            // 
            // bMaterial
            // 
            this.bMaterial.Location = new System.Drawing.Point(6, 104);
            this.bMaterial.Name = "bMaterial";
            this.bMaterial.Size = new System.Drawing.Size(75, 38);
            this.bMaterial.TabIndex = 3;
            this.bMaterial.Text = "Material Editor";
            this.bMaterial.UseVisualStyleBackColor = true;
            // 
            // modelSelector1
            // 
            this.modelSelector1.Location = new System.Drawing.Point(3, 148);
            this.modelSelector1.Name = "modelSelector1";
            this.modelSelector1.Size = new System.Drawing.Size(260, 138);
            this.modelSelector1.TabIndex = 2;
            // 
            // simConfig1
            // 
            this.simConfig1.Location = new System.Drawing.Point(6, 6);
            this.simConfig1.Name = "simConfig1";
            this.simConfig1.Size = new System.Drawing.Size(260, 92);
            this.simConfig1.TabIndex = 1;
            // 
            // uniPanel2
            // 
            this.uniPanel2.Location = new System.Drawing.Point(-9, -6);
            this.uniPanel2.Name = "uniPanel2";
            this.uniPanel2.Size = new System.Drawing.Size(391, 330);
            this.uniPanel2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergePoliMi,
            this.saveCurrentPulsesToolStripMenuItem,
            this.fuelEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mergePoliMi
            // 
            this.mergePoliMi.Name = "mergePoliMi";
            this.mergePoliMi.Size = new System.Drawing.Size(177, 22);
            this.mergePoliMi.Text = "Merge PoliMi";
            this.mergePoliMi.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // saveCurrentPulsesToolStripMenuItem
            // 
            this.saveCurrentPulsesToolStripMenuItem.Name = "saveCurrentPulsesToolStripMenuItem";
            this.saveCurrentPulsesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveCurrentPulsesToolStripMenuItem.Text = "Save Current Pulses";
            this.saveCurrentPulsesToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentPulsesToolStripMenuItem_Click);
            // 
            // fuelEditorToolStripMenuItem
            // 
            this.fuelEditorToolStripMenuItem.Name = "fuelEditorToolStripMenuItem";
            this.fuelEditorToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.fuelEditorToolStripMenuItem.Text = "Fuel Editor";
            this.fuelEditorToolStripMenuItem.Click += new System.EventHandler(this.fuelEditorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // FnclAnalysisGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 371);
            this.Controls.Add(this.tabsSim);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 410);
            this.MinimumSize = new System.Drawing.Size(410, 410);
            this.Name = "FnclAnalysisGUI";
            this.Text = "Multiplicity Analysis And Simulation (Alpha)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FnclAnalysisGUI_FormClosing);
            this.tabAnalysis.ResumeLayout(false);
            this.gbAnalyze.ResumeLayout(false);
            this.gbView.ResumeLayout(false);
            this.tabsSim.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabAnalysis;
        private System.Windows.Forms.Button bECal;
        private System.Windows.Forms.GroupBox gbView;
        private System.Windows.Forms.Button bMultiplicity;
        private System.Windows.Forms.Button bPsd;
        private System.Windows.Forms.Button bWaveform;
        private GuiWidgets.PulseFileInformation pulseInfo;
        private GuiWidgets.UniPanel uniPanel1;
        private System.Windows.Forms.TabControl tabsSim;
        private System.Windows.Forms.Button bFilter;
        private System.Windows.Forms.TabPage tabPage1;
        private GuiWidgets.UniPanel uniPanel2;
        private GuiWidgets.SimConfig simConfig1;
        private GuiWidgets.ModelSelector modelSelector1;
        private GuiWidgets.InputFile inPulseFile;
        private System.Windows.Forms.Button bDieAway;
        private System.Windows.Forms.Button bPulseHeight;
        private GuiWidgets.DetectorSelector detectorSelector;
        private System.Windows.Forms.Button bPulseStreamViewer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergePoliMi;
        private System.Windows.Forms.Button bDrf;
        private System.Windows.Forms.Button bDetectorEditor;
        private System.Windows.Forms.Button bMaterial;
        private System.Windows.Forms.Button bPileUp;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentPulsesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuelEditorToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbAnalyze;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}