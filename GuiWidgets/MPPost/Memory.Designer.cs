namespace GuiWidgets.MPPost
{
    partial class Memory
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
            this.inFileSizeMB = new GuiWidgets.InputNumber();
            this.inOverStepBuffer = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inOverStepBuffer);
            this.groupBox1.Controls.Add(this.inFileSizeMB);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memory";
            // 
            // inFileSizeMB
            // 
            this.inFileSizeMB.DataIsInteger = true;
            this.inFileSizeMB.Label = "File Size (MB):";
            this.inFileSizeMB.Location = new System.Drawing.Point(6, 19);
            this.inFileSizeMB.Name = "inFileSizeMB";
            this.inFileSizeMB.Size = new System.Drawing.Size(210, 25);
            this.inFileSizeMB.TabIndex = 0;
            // 
            // inOverStepBuffer
            // 
            this.inOverStepBuffer.DataIsInteger = true;
            this.inOverStepBuffer.Label = "Overstep Buffer:";
            this.inOverStepBuffer.Location = new System.Drawing.Point(6, 50);
            this.inOverStepBuffer.Name = "inOverStepBuffer";
            this.inOverStepBuffer.Size = new System.Drawing.Size(210, 25);
            this.inOverStepBuffer.TabIndex = 1;
            // 
            // Memory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Memory";
            this.Size = new System.Drawing.Size(224, 85);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inOverStepBuffer;
        private InputNumber inFileSizeMB;
    }
}
