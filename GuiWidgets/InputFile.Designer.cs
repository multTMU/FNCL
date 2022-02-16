namespace GuiWidgets
{
    partial class InputFile
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
            this.components = new System.ComponentModel.Container();
            this.lbFile = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lbFile
            // 
            this.lbFile.AutoSize = true;
            this.lbFile.Location = new System.Drawing.Point(3, 6);
            this.lbFile.Name = "lbFile";
            this.lbFile.Size = new System.Drawing.Size(35, 13);
            this.lbFile.TabIndex = 0;
            this.lbFile.Text = "label1";
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(90, 2);
            this.tbFile.Name = "tbFile";
            this.tbFile.ReadOnly = true;
            this.tbFile.Size = new System.Drawing.Size(90, 20);
            this.tbFile.TabIndex = 1;
            // 
            // bBrowse
            // 
            this.bBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.bBrowse.Location = new System.Drawing.Point(186, 0);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(24, 25);
            this.bBrowse.TabIndex = 2;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // InputFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.lbFile);
            this.Name = "InputFile";
            this.Size = new System.Drawing.Size(210, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFile;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
