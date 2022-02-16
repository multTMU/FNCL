namespace GuiWidgets
{
    partial class PulseFileInformation
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelFilterCountTime = new System.Windows.Forms.Label();
            this.labelFilterNumberPulses = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCountTime = new System.Windows.Forms.Label();
            this.labelNumberPulses = new System.Windows.Forms.Label();
            this.labelCreation = new System.Windows.Forms.Label();
            this.labelSizeMB = new System.Windows.Forms.Label();
            this.labelPulseFileType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.labelCreation);
            this.groupBox1.Controls.Add(this.labelSizeMB);
            this.groupBox1.Controls.Add(this.labelPulseFileType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse File Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.labelFilterCountTime);
            this.groupBox3.Controls.Add(this.labelFilterNumberPulses);
            this.groupBox3.Location = new System.Drawing.Point(6, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 50);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtered Pulses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Count Time (sec):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Number Pulses:";
            // 
            // labelFilterCountTime
            // 
            this.labelFilterCountTime.AutoSize = true;
            this.labelFilterCountTime.Location = new System.Drawing.Point(102, 29);
            this.labelFilterCountTime.Name = "labelFilterCountTime";
            this.labelFilterCountTime.Size = new System.Drawing.Size(13, 13);
            this.labelFilterCountTime.TabIndex = 10;
            this.labelFilterCountTime.Text = "--";
            // 
            // labelFilterNumberPulses
            // 
            this.labelFilterNumberPulses.AutoSize = true;
            this.labelFilterNumberPulses.Location = new System.Drawing.Point(93, 16);
            this.labelFilterNumberPulses.Name = "labelFilterNumberPulses";
            this.labelFilterNumberPulses.Size = new System.Drawing.Size(13, 13);
            this.labelFilterNumberPulses.TabIndex = 11;
            this.labelFilterNumberPulses.Text = "--";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelCountTime);
            this.groupBox2.Controls.Add(this.labelNumberPulses);
            this.groupBox2.Location = new System.Drawing.Point(6, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 50);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unfiltered Pulses";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Count Time (sec):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number Pulses:";
            // 
            // labelCountTime
            // 
            this.labelCountTime.AutoSize = true;
            this.labelCountTime.Location = new System.Drawing.Point(102, 31);
            this.labelCountTime.Name = "labelCountTime";
            this.labelCountTime.Size = new System.Drawing.Size(13, 13);
            this.labelCountTime.TabIndex = 6;
            this.labelCountTime.Text = "--";
            // 
            // labelNumberPulses
            // 
            this.labelNumberPulses.AutoSize = true;
            this.labelNumberPulses.Location = new System.Drawing.Point(93, 18);
            this.labelNumberPulses.Name = "labelNumberPulses";
            this.labelNumberPulses.Size = new System.Drawing.Size(13, 13);
            this.labelNumberPulses.TabIndex = 7;
            this.labelNumberPulses.Text = "--";
            // 
            // labelCreation
            // 
            this.labelCreation.AutoSize = true;
            this.labelCreation.Location = new System.Drawing.Point(61, 16);
            this.labelCreation.Name = "labelCreation";
            this.labelCreation.Size = new System.Drawing.Size(13, 13);
            this.labelCreation.TabIndex = 9;
            this.labelCreation.Text = "--";
            // 
            // labelSizeMB
            // 
            this.labelSizeMB.AutoSize = true;
            this.labelSizeMB.Location = new System.Drawing.Point(67, 29);
            this.labelSizeMB.Name = "labelSizeMB";
            this.labelSizeMB.Size = new System.Drawing.Size(13, 13);
            this.labelSizeMB.TabIndex = 8;
            this.labelSizeMB.Text = "--";
            // 
            // labelPulseFileType
            // 
            this.labelPulseFileType.AutoSize = true;
            this.labelPulseFileType.Location = new System.Drawing.Point(94, 42);
            this.labelPulseFileType.Name = "labelPulseFileType";
            this.labelPulseFileType.Size = new System.Drawing.Size(13, 13);
            this.labelPulseFileType.TabIndex = 5;
            this.labelPulseFileType.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pulse File Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size (MB):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creation:";
            // 
            // PulseFileInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PulseFileInformation";
            this.Size = new System.Drawing.Size(220, 177);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCreation;
        private System.Windows.Forms.Label labelSizeMB;
        private System.Windows.Forms.Label labelNumberPulses;
        private System.Windows.Forms.Label labelCountTime;
        private System.Windows.Forms.Label labelPulseFileType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelFilterCountTime;
        private System.Windows.Forms.Label labelFilterNumberPulses;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
