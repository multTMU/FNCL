namespace GuiWidgets.PileUpRejector
{
    partial class PileUpWaveform
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
            this.bRecalc = new System.Windows.Forms.Button();
            this.inRejected = new GuiWidgets.InputString();
            this.pileUpFilter1 = new GuiWidgets.PileUpRejector.PileUpFilter();
            this.SuspendLayout();
            // 
            // bRecalc
            // 
            this.bRecalc.Location = new System.Drawing.Point(173, 97);
            this.bRecalc.Name = "bRecalc";
            this.bRecalc.Size = new System.Drawing.Size(56, 23);
            this.bRecalc.TabIndex = 2;
            this.bRecalc.Text = "Recalc";
            this.bRecalc.UseVisualStyleBackColor = true;
            this.bRecalc.Click += new System.EventHandler(this.bRecalc_Click);
            // 
            // inRejected
            // 
            this.inRejected.Label = "Pile Up:";
            this.inRejected.Location = new System.Drawing.Point(3, 95);
            this.inRejected.Name = "inRejected";
            this.inRejected.Size = new System.Drawing.Size(164, 25);
            this.inRejected.TabIndex = 1;
            // 
            // pileUpFilter1
            // 
            this.pileUpFilter1.Interval = 0D;
            this.pileUpFilter1.Location = new System.Drawing.Point(3, 3);
            this.pileUpFilter1.Name = "pileUpFilter1";
            this.pileUpFilter1.Scalar = 0D;
            this.pileUpFilter1.Size = new System.Drawing.Size(227, 86);
            this.pileUpFilter1.TabIndex = 0;
            // 
            // PileUpWaveform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bRecalc);
            this.Controls.Add(this.inRejected);
            this.Controls.Add(this.pileUpFilter1);
            this.Name = "PileUpWaveform";
            this.Size = new System.Drawing.Size(232, 125);
            this.ResumeLayout(false);

        }

        #endregion

        private PileUpFilter pileUpFilter1;
        private InputString inRejected;
        private System.Windows.Forms.Button bRecalc;
    }
}
