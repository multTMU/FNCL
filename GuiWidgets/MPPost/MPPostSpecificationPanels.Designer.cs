namespace GuiWidgets.MPPost
{
    partial class MPPostSpecificationPanels
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
            this.tabsMPPost = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.memory1 = new GuiWidgets.MPPost.Memory();
            this.fileIO1 = new GuiWidgets.MPPost.FileIO();
            this.generalInfo1 = new GuiWidgets.MPPost.GeneralInfo();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.tabDetector = new System.Windows.Forms.TabPage();
            this.timeResolution1 = new GuiWidgets.MPPost.TimeResolution();
            this.deadTime1 = new GuiWidgets.MPPost.DeadTime();
            this.detectorPulseHeight1 = new GuiWidgets.MPPost.DetectorPulseHeight();
            this.detectorInformation1 = new GuiWidgets.MPPost.DetectorInformation();
            this.uniPanel2 = new GuiWidgets.UniPanel();
            this.tabPulsesCaptures = new System.Windows.Forms.TabPage();
            this.pulseHeightCorrelation1 = new GuiWidgets.MPPost.PulseHeightCorrelation();
            this.pulseGeneration1 = new GuiWidgets.MPPost.PulseGeneration();
            this.uniPanel3 = new GuiWidgets.UniPanel();
            this.tabCapture = new System.Windows.Forms.TabPage();
            this.correlations1 = new GuiWidgets.MPPost.Correlations();
            this.captureEvents1 = new GuiWidgets.MPPost.CaptureEvents();
            this.captureGatedDetector1 = new GuiWidgets.MPPost.CaptureGatedDetector();
            this.uniPanel4 = new GuiWidgets.UniPanel();
            this.tabOrganic = new System.Windows.Forms.TabPage();
            this.organicScintillator1 = new GuiWidgets.MPPost.OrganicScintillator();
            this.uniPanel5 = new GuiWidgets.UniPanel();
            this.tabLightResolution = new System.Windows.Forms.TabPage();
            this.lightResolution1 = new GuiWidgets.MPPost.LightResolution();
            this.uniPanel6 = new GuiWidgets.UniPanel();
            this.tabHe3Module = new System.Windows.Forms.TabPage();
            this.he3Module1 = new GuiWidgets.MPPost.He3Module();
            this.uniPanel7 = new GuiWidgets.UniPanel();
            this.tabsMPPost.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDetector.SuspendLayout();
            this.tabPulsesCaptures.SuspendLayout();
            this.tabCapture.SuspendLayout();
            this.tabOrganic.SuspendLayout();
            this.tabLightResolution.SuspendLayout();
            this.tabHe3Module.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsMPPost
            // 
            this.tabsMPPost.Controls.Add(this.tabGeneral);
            this.tabsMPPost.Controls.Add(this.tabDetector);
            this.tabsMPPost.Controls.Add(this.tabPulsesCaptures);
            this.tabsMPPost.Controls.Add(this.tabCapture);
            this.tabsMPPost.Controls.Add(this.tabOrganic);
            this.tabsMPPost.Controls.Add(this.tabLightResolution);
            this.tabsMPPost.Controls.Add(this.tabHe3Module);
            this.tabsMPPost.Location = new System.Drawing.Point(3, 3);
            this.tabsMPPost.Name = "tabsMPPost";
            this.tabsMPPost.SelectedIndex = 0;
            this.tabsMPPost.Size = new System.Drawing.Size(990, 495);
            this.tabsMPPost.TabIndex = 16;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.memory1);
            this.tabGeneral.Controls.Add(this.fileIO1);
            this.tabGeneral.Controls.Add(this.generalInfo1);
            this.tabGeneral.Controls.Add(this.uniPanel1);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(982, 469);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // memory1
            // 
            this.memory1.Location = new System.Drawing.Point(237, 8);
            this.memory1.Name = "memory1";
            this.memory1.Size = new System.Drawing.Size(224, 85);
            this.memory1.TabIndex = 11;
            // 
            // fileIO1
            // 
            this.fileIO1.Location = new System.Drawing.Point(6, 99);
            this.fileIO1.Name = "fileIO1";
            this.fileIO1.Size = new System.Drawing.Size(229, 305);
            this.fileIO1.TabIndex = 9;
            // 
            // generalInfo1
            // 
            this.generalInfo1.Location = new System.Drawing.Point(6, 6);
            this.generalInfo1.Name = "generalInfo1";
            this.generalInfo1.Size = new System.Drawing.Size(225, 87);
            this.generalInfo1.TabIndex = 8;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(0, 0);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(998, 488);
            this.uniPanel1.TabIndex = 0;
            // 
            // tabDetector
            // 
            this.tabDetector.Controls.Add(this.timeResolution1);
            this.tabDetector.Controls.Add(this.deadTime1);
            this.tabDetector.Controls.Add(this.detectorPulseHeight1);
            this.tabDetector.Controls.Add(this.detectorInformation1);
            this.tabDetector.Controls.Add(this.uniPanel2);
            this.tabDetector.Location = new System.Drawing.Point(4, 22);
            this.tabDetector.Name = "tabDetector";
            this.tabDetector.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetector.Size = new System.Drawing.Size(982, 469);
            this.tabDetector.TabIndex = 1;
            this.tabDetector.Text = "Detector";
            this.tabDetector.UseVisualStyleBackColor = true;
            // 
            // timeResolution1
            // 
            this.timeResolution1.Location = new System.Drawing.Point(485, 6);
            this.timeResolution1.Name = "timeResolution1";
            this.timeResolution1.Size = new System.Drawing.Size(237, 233);
            this.timeResolution1.TabIndex = 15;
            // 
            // deadTime1
            // 
            this.deadTime1.Location = new System.Drawing.Point(241, 6);
            this.deadTime1.Name = "deadTime1";
            this.deadTime1.Size = new System.Drawing.Size(238, 293);
            this.deadTime1.TabIndex = 7;
            // 
            // detectorPulseHeight1
            // 
            this.detectorPulseHeight1.Location = new System.Drawing.Point(6, 223);
            this.detectorPulseHeight1.Name = "detectorPulseHeight1";
            this.detectorPulseHeight1.Size = new System.Drawing.Size(229, 115);
            this.detectorPulseHeight1.TabIndex = 6;
            // 
            // detectorInformation1
            // 
            this.detectorInformation1.Location = new System.Drawing.Point(6, 6);
            this.detectorInformation1.Name = "detectorInformation1";
            this.detectorInformation1.Size = new System.Drawing.Size(228, 211);
            this.detectorInformation1.TabIndex = 5;
            // 
            // uniPanel2
            // 
            this.uniPanel2.Location = new System.Drawing.Point(-7, 0);
            this.uniPanel2.Name = "uniPanel2";
            this.uniPanel2.Size = new System.Drawing.Size(1003, 486);
            this.uniPanel2.TabIndex = 1;
            // 
            // tabPulsesCaptures
            // 
            this.tabPulsesCaptures.Controls.Add(this.pulseHeightCorrelation1);
            this.tabPulsesCaptures.Controls.Add(this.pulseGeneration1);
            this.tabPulsesCaptures.Controls.Add(this.uniPanel3);
            this.tabPulsesCaptures.Location = new System.Drawing.Point(4, 22);
            this.tabPulsesCaptures.Name = "tabPulsesCaptures";
            this.tabPulsesCaptures.Padding = new System.Windows.Forms.Padding(3);
            this.tabPulsesCaptures.Size = new System.Drawing.Size(982, 469);
            this.tabPulsesCaptures.TabIndex = 2;
            this.tabPulsesCaptures.Text = "Pulses";
            this.tabPulsesCaptures.UseVisualStyleBackColor = true;
            // 
            // pulseHeightCorrelation1
            // 
            this.pulseHeightCorrelation1.Location = new System.Drawing.Point(6, 194);
            this.pulseHeightCorrelation1.Name = "pulseHeightCorrelation1";
            this.pulseHeightCorrelation1.Size = new System.Drawing.Size(227, 177);
            this.pulseHeightCorrelation1.TabIndex = 14;
            // 
            // pulseGeneration1
            // 
            this.pulseGeneration1.Location = new System.Drawing.Point(6, 6);
            this.pulseGeneration1.Name = "pulseGeneration1";
            this.pulseGeneration1.Size = new System.Drawing.Size(229, 182);
            this.pulseGeneration1.TabIndex = 13;
            // 
            // uniPanel3
            // 
            this.uniPanel3.Location = new System.Drawing.Point(-4, -9);
            this.uniPanel3.Name = "uniPanel3";
            this.uniPanel3.Size = new System.Drawing.Size(954, 703);
            this.uniPanel3.TabIndex = 0;
            // 
            // tabCapture
            // 
            this.tabCapture.Controls.Add(this.correlations1);
            this.tabCapture.Controls.Add(this.captureEvents1);
            this.tabCapture.Controls.Add(this.captureGatedDetector1);
            this.tabCapture.Controls.Add(this.uniPanel4);
            this.tabCapture.Location = new System.Drawing.Point(4, 22);
            this.tabCapture.Name = "tabCapture";
            this.tabCapture.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapture.Size = new System.Drawing.Size(982, 469);
            this.tabCapture.TabIndex = 3;
            this.tabCapture.Text = "Capture/Correlations";
            this.tabCapture.UseVisualStyleBackColor = true;
            // 
            // correlations1
            // 
            this.correlations1.Location = new System.Drawing.Point(238, 6);
            this.correlations1.Name = "correlations1";
            this.correlations1.Size = new System.Drawing.Size(230, 269);
            this.correlations1.TabIndex = 4;
            // 
            // captureEvents1
            // 
            this.captureEvents1.Location = new System.Drawing.Point(6, 162);
            this.captureEvents1.Name = "captureEvents1";
            this.captureEvents1.Size = new System.Drawing.Size(226, 150);
            this.captureEvents1.TabIndex = 3;
            // 
            // captureGatedDetector1
            // 
            this.captureGatedDetector1.Location = new System.Drawing.Point(6, 6);
            this.captureGatedDetector1.Name = "captureGatedDetector1";
            this.captureGatedDetector1.Size = new System.Drawing.Size(226, 150);
            this.captureGatedDetector1.TabIndex = 2;
            // 
            // uniPanel4
            // 
            this.uniPanel4.Location = new System.Drawing.Point(-4, -9);
            this.uniPanel4.Name = "uniPanel4";
            this.uniPanel4.Size = new System.Drawing.Size(896, 554);
            this.uniPanel4.TabIndex = 0;
            // 
            // tabOrganic
            // 
            this.tabOrganic.Controls.Add(this.organicScintillator1);
            this.tabOrganic.Controls.Add(this.uniPanel5);
            this.tabOrganic.Location = new System.Drawing.Point(4, 22);
            this.tabOrganic.Name = "tabOrganic";
            this.tabOrganic.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrganic.Size = new System.Drawing.Size(982, 469);
            this.tabOrganic.TabIndex = 4;
            this.tabOrganic.Text = "Organic Scintillator";
            this.tabOrganic.UseVisualStyleBackColor = true;
            // 
            // organicScintillator1
            // 
            this.organicScintillator1.Location = new System.Drawing.Point(3, 6);
            this.organicScintillator1.Name = "organicScintillator1";
            this.organicScintillator1.Size = new System.Drawing.Size(738, 365);
            this.organicScintillator1.TabIndex = 12;
            // 
            // uniPanel5
            // 
            this.uniPanel5.Location = new System.Drawing.Point(-7, -10);
            this.uniPanel5.Name = "uniPanel5";
            this.uniPanel5.Size = new System.Drawing.Size(1009, 501);
            this.uniPanel5.TabIndex = 0;
            // 
            // tabLightResolution
            // 
            this.tabLightResolution.Controls.Add(this.lightResolution1);
            this.tabLightResolution.Controls.Add(this.uniPanel6);
            this.tabLightResolution.Location = new System.Drawing.Point(4, 22);
            this.tabLightResolution.Name = "tabLightResolution";
            this.tabLightResolution.Padding = new System.Windows.Forms.Padding(3);
            this.tabLightResolution.Size = new System.Drawing.Size(982, 469);
            this.tabLightResolution.TabIndex = 5;
            this.tabLightResolution.Text = "Light Resolution";
            this.tabLightResolution.UseVisualStyleBackColor = true;
            // 
            // lightResolution1
            // 
            this.lightResolution1.Location = new System.Drawing.Point(3, 6);
            this.lightResolution1.Name = "lightResolution1";
            this.lightResolution1.Size = new System.Drawing.Size(977, 418);
            this.lightResolution1.TabIndex = 10;
            // 
            // uniPanel6
            // 
            this.uniPanel6.Location = new System.Drawing.Point(-7, -9);
            this.uniPanel6.Name = "uniPanel6";
            this.uniPanel6.Size = new System.Drawing.Size(993, 527);
            this.uniPanel6.TabIndex = 0;
            // 
            // tabHe3Module
            // 
            this.tabHe3Module.Controls.Add(this.he3Module1);
            this.tabHe3Module.Controls.Add(this.uniPanel7);
            this.tabHe3Module.Location = new System.Drawing.Point(4, 22);
            this.tabHe3Module.Name = "tabHe3Module";
            this.tabHe3Module.Padding = new System.Windows.Forms.Padding(3);
            this.tabHe3Module.Size = new System.Drawing.Size(982, 469);
            this.tabHe3Module.TabIndex = 6;
            this.tabHe3Module.Text = "He3 Module";
            this.tabHe3Module.UseVisualStyleBackColor = true;
            // 
            // he3Module1
            // 
            this.he3Module1.Location = new System.Drawing.Point(6, 3);
            this.he3Module1.Name = "he3Module1";
            this.he3Module1.Size = new System.Drawing.Size(226, 461);
            this.he3Module1.TabIndex = 9;
            // 
            // uniPanel7
            // 
            this.uniPanel7.Location = new System.Drawing.Point(-7, -10);
            this.uniPanel7.Name = "uniPanel7";
            this.uniPanel7.Size = new System.Drawing.Size(1013, 491);
            this.uniPanel7.TabIndex = 0;
            // 
            // MPPostSpecificationPanels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabsMPPost);
            this.Name = "MPPostSpecificationPanels";
            this.Size = new System.Drawing.Size(998, 500);
            this.tabsMPPost.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabDetector.ResumeLayout(false);
            this.tabPulsesCaptures.ResumeLayout(false);
            this.tabCapture.ResumeLayout(false);
            this.tabOrganic.ResumeLayout(false);
            this.tabLightResolution.ResumeLayout(false);
            this.tabHe3Module.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsMPPost;
        private System.Windows.Forms.TabPage tabGeneral;
        private UniPanel uniPanel1;
        private System.Windows.Forms.TabPage tabDetector;
        private UniPanel uniPanel2;
        private GeneralInfo generalInfo1;
        private FileIO fileIO1;
        private Memory memory1;
        private DetectorInformation detectorInformation1;
        private DetectorPulseHeight detectorPulseHeight1;
        private DeadTime deadTime1;
        private System.Windows.Forms.TabPage tabPulsesCaptures;
        private UniPanel uniPanel3;
        private PulseGeneration pulseGeneration1;
        private PulseHeightCorrelation pulseHeightCorrelation1;
        private System.Windows.Forms.TabPage tabCapture;
        private UniPanel uniPanel4;
        private CaptureGatedDetector captureGatedDetector1;
        private CaptureEvents captureEvents1;
        private Correlations correlations1;
        private System.Windows.Forms.TabPage tabOrganic;
        private UniPanel uniPanel5;
        private OrganicScintillator organicScintillator1;
        private System.Windows.Forms.TabPage tabLightResolution;
        private UniPanel uniPanel6;
        private LightResolution lightResolution1;
        private System.Windows.Forms.TabPage tabHe3Module;
        private UniPanel uniPanel7;
        private He3Module he3Module1;
        private TimeResolution timeResolution1;
    }
}
