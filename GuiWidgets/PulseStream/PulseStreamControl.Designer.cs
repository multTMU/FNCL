namespace GuiWidgets.PulseStream
{
    partial class PulseStreamControl
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
            this.bReset = new System.Windows.Forms.Button();
            this.inEnd = new GuiWidgets.InputNumber();
            this.inStart = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bReset);
            this.groupBox1.Controls.Add(this.inEnd);
            this.groupBox1.Controls.Add(this.inStart);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Stream Selection";
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(154, 36);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(45, 23);
            this.bReset.TabIndex = 2;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // inEnd
            // 
            this.inEnd.DataIsInteger = true;
            this.inEnd.Label = "End(ns):";
            this.inEnd.Location = new System.Drawing.Point(6, 54);
            this.inEnd.Name = "inEnd";
            this.inEnd.Size = new System.Drawing.Size(142, 25);
            this.inEnd.TabIndex = 1;
            // 
            // inStart
            // 
            this.inStart.DataIsInteger = true;
            this.inStart.Label = "Start(ns):";
            this.inStart.Location = new System.Drawing.Point(6, 19);
            this.inStart.Name = "inStart";
            this.inStart.Size = new System.Drawing.Size(142, 25);
            this.inStart.TabIndex = 0;
            // 
            // PulseStreamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PulseStreamControl";
            this.Size = new System.Drawing.Size(215, 90);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inStart;
        private InputNumber inEnd;
        private System.Windows.Forms.Button bReset;
    }
}
