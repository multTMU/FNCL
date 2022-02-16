namespace GuiWidgets.CombinePulses
{
    partial class CombinePulses
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
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFilters = new System.Windows.Forms.CheckBox();
            this.bSaveAs = new System.Windows.Forms.Button();
            this.bAddFiles = new System.Windows.Forms.Button();
            this.cbEcal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(6, 19);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.Size = new System.Drawing.Size(368, 177);
            this.dgvFiles.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEcal);
            this.groupBox1.Controls.Add(this.cbFilters);
            this.groupBox1.Controls.Add(this.bSaveAs);
            this.groupBox1.Controls.Add(this.bAddFiles);
            this.groupBox1.Controls.Add(this.dgvFiles);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 236);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Combine Pulses to Time Stamped Format";
            // 
            // cbFilters
            // 
            this.cbFilters.AutoSize = true;
            this.cbFilters.Location = new System.Drawing.Point(211, 206);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(82, 17);
            this.cbFilters.TabIndex = 4;
            this.cbFilters.Text = "Apply Filters";
            this.cbFilters.UseVisualStyleBackColor = true;
            this.cbFilters.CheckedChanged += new System.EventHandler(this.cbFilters_CheckedChanged);
            // 
            // bSaveAs
            // 
            this.bSaveAs.Location = new System.Drawing.Point(299, 202);
            this.bSaveAs.Name = "bSaveAs";
            this.bSaveAs.Size = new System.Drawing.Size(75, 23);
            this.bSaveAs.TabIndex = 3;
            this.bSaveAs.Text = "Save As";
            this.bSaveAs.UseVisualStyleBackColor = true;
            this.bSaveAs.Click += new System.EventHandler(this.bSaveAs_Click);
            // 
            // bAddFiles
            // 
            this.bAddFiles.Location = new System.Drawing.Point(6, 202);
            this.bAddFiles.Name = "bAddFiles";
            this.bAddFiles.Size = new System.Drawing.Size(75, 23);
            this.bAddFiles.TabIndex = 1;
            this.bAddFiles.Text = "Add Files";
            this.bAddFiles.UseVisualStyleBackColor = true;
            this.bAddFiles.Click += new System.EventHandler(this.bAddFiles_Click);
            // 
            // cbEcal
            // 
            this.cbEcal.AutoSize = true;
            this.cbEcal.Location = new System.Drawing.Point(125, 206);
            this.cbEcal.Name = "cbEcal";
            this.cbEcal.Size = new System.Drawing.Size(80, 17);
            this.cbEcal.TabIndex = 5;
            this.cbEcal.Text = "Apply E-Cal";
            this.cbEcal.UseVisualStyleBackColor = true;
            this.cbEcal.CheckedChanged += new System.EventHandler(this.cbEcal_CheckedChanged);
            // 
            // CombinePulses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CombinePulses";
            this.Size = new System.Drawing.Size(392, 243);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bSaveAs;
        private System.Windows.Forms.Button bAddFiles;
        private System.Windows.Forms.CheckBox cbFilters;
        private System.Windows.Forms.CheckBox cbEcal;
    }
}
