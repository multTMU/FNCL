namespace GuiWidgets.PulseStream
{
    partial class PulseStreamInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxCountTime = new System.Windows.Forms.TextBox();
            this.tbRate = new System.Windows.Forms.TextBox();
            this.tbRateSelected = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRateSelected);
            this.groupBox1.Controls.Add(this.tbRate);
            this.groupBox1.Controls.Add(this.tbMaxCountTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max. Count Time(ns):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rate(1/s):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "View Rate(1/s):";
            // 
            // tbMaxCountTime
            // 
            this.tbMaxCountTime.Location = new System.Drawing.Point(119, 13);
            this.tbMaxCountTime.Name = "tbMaxCountTime";
            this.tbMaxCountTime.ReadOnly = true;
            this.tbMaxCountTime.Size = new System.Drawing.Size(100, 20);
            this.tbMaxCountTime.TabIndex = 3;
            // 
            // tbRate
            // 
            this.tbRate.Location = new System.Drawing.Point(119, 39);
            this.tbRate.Name = "tbRate";
            this.tbRate.ReadOnly = true;
            this.tbRate.Size = new System.Drawing.Size(100, 20);
            this.tbRate.TabIndex = 4;
            // 
            // tbRateSelected
            // 
            this.tbRateSelected.Location = new System.Drawing.Point(119, 65);
            this.tbRateSelected.Name = "tbRateSelected";
            this.tbRateSelected.ReadOnly = true;
            this.tbRateSelected.Size = new System.Drawing.Size(100, 20);
            this.tbRateSelected.TabIndex = 5;
            // 
            // PulseStreamInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PulseStreamInfo";
            this.Size = new System.Drawing.Size(231, 100);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRateSelected;
        private System.Windows.Forms.TextBox tbRate;
        private System.Windows.Forms.TextBox tbMaxCountTime;
        private System.Windows.Forms.Label label3;
    }
}
