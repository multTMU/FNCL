namespace GuiWidgets.Multiplicity
{
    partial class MultiplicityViewer
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bAnalyzePulseFile = new System.Windows.Forms.Button();
            this.gateSelector1 = new GuiWidgets.Multiplicity.GateSelector();
            this.multGate = new GuiWidgets.SetShiftRegister();
            this.displayMultiplets = new GuiWidgets.DisplayMultiplets();
            this.Rhisto = new GuiWidgets.HistogramPlotter();
            this.RandAHisto = new GuiWidgets.HistogramPlotter();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Reals and Accidentals Multiplicity Distribution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Reals Multiplicity Distribution";
            // 
            // bAnalyzePulseFile
            // 
            this.bAnalyzePulseFile.Location = new System.Drawing.Point(201, 99);
            this.bAnalyzePulseFile.Margin = new System.Windows.Forms.Padding(2);
            this.bAnalyzePulseFile.Name = "bAnalyzePulseFile";
            this.bAnalyzePulseFile.Size = new System.Drawing.Size(63, 31);
            this.bAnalyzePulseFile.TabIndex = 12;
            this.bAnalyzePulseFile.Text = "Analyze";
            this.bAnalyzePulseFile.UseVisualStyleBackColor = true;
            this.bAnalyzePulseFile.Click += new System.EventHandler(this.bAnalyzePulseFile_Click);
            // 
            // gateSelector1
            // 
            this.gateSelector1.Location = new System.Drawing.Point(6, 3);
            this.gateSelector1.Name = "gateSelector1";
            this.gateSelector1.Size = new System.Drawing.Size(261, 52);
            this.gateSelector1.TabIndex = 19;
            // 
            // multGate
            // 
            this.multGate.Location = new System.Drawing.Point(4, 63);
            this.multGate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.multGate.Name = "multGate";
            this.multGate.Size = new System.Drawing.Size(190, 125);
            this.multGate.TabIndex = 16;
            // 
            // displayMultiplets
            // 
            this.displayMultiplets.Location = new System.Drawing.Point(270, 63);
            this.displayMultiplets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.displayMultiplets.MaximumSize = new System.Drawing.Size(310, 100);
            this.displayMultiplets.MinimumSize = new System.Drawing.Size(310, 100);
            this.displayMultiplets.Name = "displayMultiplets";
            this.displayMultiplets.Size = new System.Drawing.Size(310, 100);
            this.displayMultiplets.TabIndex = 15;
            // 
            // Rhisto
            // 
            this.Rhisto.Location = new System.Drawing.Point(6, 207);
            this.Rhisto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Rhisto.Name = "Rhisto";
            this.Rhisto.Size = new System.Drawing.Size(291, 234);
            this.Rhisto.TabIndex = 14;
            // 
            // RandAHisto
            // 
            this.RandAHisto.Location = new System.Drawing.Point(305, 207);
            this.RandAHisto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RandAHisto.Name = "RandAHisto";
            this.RandAHisto.Size = new System.Drawing.Size(275, 234);
            this.RandAHisto.TabIndex = 13;
            // 
            // MultiplicityViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gateSelector1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.multGate);
            this.Controls.Add(this.displayMultiplets);
            this.Controls.Add(this.bAnalyzePulseFile);
            this.Controls.Add(this.Rhisto);
            this.Controls.Add(this.RandAHisto);
            this.Name = "MultiplicityViewer";
            this.Size = new System.Drawing.Size(596, 438);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private SetShiftRegister multGate;
        private DisplayMultiplets displayMultiplets;
        private System.Windows.Forms.Button bAnalyzePulseFile;
        private HistogramPlotter Rhisto;
        private HistogramPlotter RandAHisto;
        private GateSelector gateSelector1;
    }
}
