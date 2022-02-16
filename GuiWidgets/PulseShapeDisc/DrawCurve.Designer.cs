namespace GuiWidgets.PulseShapeDisc
{
    partial class DrawCurve
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
            this.bReLoad = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.cbDraw = new System.Windows.Forms.CheckBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bReLoad);
            this.groupBox1.Controls.Add(this.bClear);
            this.groupBox1.Controls.Add(this.cbDraw);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw Boundary";
            // 
            // bReLoad
            // 
            this.bReLoad.Location = new System.Drawing.Point(6, 71);
            this.bReLoad.Name = "bReLoad";
            this.bReLoad.Size = new System.Drawing.Size(75, 23);
            this.bReLoad.TabIndex = 3;
            this.bReLoad.Text = "Reload";
            this.bReLoad.UseVisualStyleBackColor = true;
            this.bReLoad.Click += new System.EventHandler(this.bReLoad_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(6, 42);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 1;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // cbDraw
            // 
            this.cbDraw.AutoSize = true;
            this.cbDraw.Location = new System.Drawing.Point(6, 19);
            this.cbDraw.Name = "cbDraw";
            this.cbDraw.Size = new System.Drawing.Size(81, 17);
            this.cbDraw.TabIndex = 0;
            this.cbDraw.Text = "Enable Pen";
            this.cbDraw.UseVisualStyleBackColor = true;
            this.cbDraw.CheckedChanged += new System.EventHandler(this.cbDraw_CheckedChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // DrawCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DrawCurve";
            this.Size = new System.Drawing.Size(104, 109);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbDraw;
        private System.Windows.Forms.Button bClear;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button bReLoad;
    }
}
