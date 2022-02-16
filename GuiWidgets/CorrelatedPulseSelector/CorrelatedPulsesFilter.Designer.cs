namespace GuiWidgets.CorrelatedPulseSelector
{
    partial class CorrelatedPulsesFilter
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
            this.gbCorrelatePulseSelector = new System.Windows.Forms.GroupBox();
            this.inTimeInterval = new GuiWidgets.InputNumber();
            this.gbCorrelatePulseSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCorrelatePulseSelector
            // 
            this.gbCorrelatePulseSelector.Controls.Add(this.inTimeInterval);
            this.gbCorrelatePulseSelector.Location = new System.Drawing.Point(3, 3);
            this.gbCorrelatePulseSelector.Name = "gbCorrelatePulseSelector";
            this.gbCorrelatePulseSelector.Size = new System.Drawing.Size(214, 51);
            this.gbCorrelatePulseSelector.TabIndex = 0;
            this.gbCorrelatePulseSelector.TabStop = false;
            this.gbCorrelatePulseSelector.Text = "Correlated Pulse Selector";
            // 
            // inTimeInterval
            // 
            this.inTimeInterval.DataIsInteger = true;
            this.inTimeInterval.Label = "Max Time Interval (ns):";
            this.inTimeInterval.Location = new System.Drawing.Point(4, 19);
            this.inTimeInterval.Name = "inTimeInterval";
            this.inTimeInterval.Size = new System.Drawing.Size(204, 25);
            this.inTimeInterval.TabIndex = 0;
            // 
            // CorrelatedPulsesFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCorrelatePulseSelector);
            this.Name = "CorrelatedPulsesFilter";
            this.Size = new System.Drawing.Size(220, 59);
            this.gbCorrelatePulseSelector.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCorrelatePulseSelector;
        private InputNumber inTimeInterval;
    }
}
