namespace GuiWidgets.MPPost
{
    partial class FileIO
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
            this.inLabelOutput = new GuiWidgets.InputBoolean();
            this.inSeparateDRFs = new GuiWidgets.InputBoolean();
            this.inPrintListmode = new GuiWidgets.InputBoolean();
            this.inPrintSummaryTable = new GuiWidgets.InputBoolean();
            this.inCollisionHistory = new GuiWidgets.InputBoolean();
            this.inOverwriteFiles = new GuiWidgets.InputBoolean();
            this.inCommaDelimeted = new GuiWidgets.InputBoolean();
            this.inDetectorFile = new GuiWidgets.InputString();
            this.inOutputFiles = new GuiWidgets.InputString();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inOutputFiles);
            this.groupBox1.Controls.Add(this.inDetectorFile);
            this.groupBox1.Controls.Add(this.inCommaDelimeted);
            this.groupBox1.Controls.Add(this.inOverwriteFiles);
            this.groupBox1.Controls.Add(this.inCollisionHistory);
            this.groupBox1.Controls.Add(this.inPrintSummaryTable);
            this.groupBox1.Controls.Add(this.inPrintListmode);
            this.groupBox1.Controls.Add(this.inSeparateDRFs);
            this.groupBox1.Controls.Add(this.inLabelOutput);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 298);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File I/O";
            // 
            // inLabelOutput
            // 
            this.inLabelOutput.Label = "Label Output:";
            this.inLabelOutput.Location = new System.Drawing.Point(6, 19);
            this.inLabelOutput.Name = "inLabelOutput";
            this.inLabelOutput.Size = new System.Drawing.Size(210, 25);
            this.inLabelOutput.TabIndex = 0;
            // 
            // inSeparateDRFs
            // 
            this.inSeparateDRFs.Label = "Separate DRF:";
            this.inSeparateDRFs.Location = new System.Drawing.Point(6, 50);
            this.inSeparateDRFs.Name = "inSeparateDRFs";
            this.inSeparateDRFs.Size = new System.Drawing.Size(210, 25);
            this.inSeparateDRFs.TabIndex = 1;
            // 
            // inPrintListmode
            // 
            this.inPrintListmode.Label = "Print Listmode File:";
            this.inPrintListmode.Location = new System.Drawing.Point(6, 81);
            this.inPrintListmode.Name = "inPrintListmode";
            this.inPrintListmode.Size = new System.Drawing.Size(210, 25);
            this.inPrintListmode.TabIndex = 2;
            // 
            // inPrintSummaryTable
            // 
            this.inPrintSummaryTable.Label = "Print Summary Table:";
            this.inPrintSummaryTable.Location = new System.Drawing.Point(6, 112);
            this.inPrintSummaryTable.Name = "inPrintSummaryTable";
            this.inPrintSummaryTable.Size = new System.Drawing.Size(210, 25);
            this.inPrintSummaryTable.TabIndex = 3;
            // 
            // inCollisionHistory
            // 
            this.inCollisionHistory.Label = "Collision History:";
            this.inCollisionHistory.Location = new System.Drawing.Point(6, 143);
            this.inCollisionHistory.Name = "inCollisionHistory";
            this.inCollisionHistory.Size = new System.Drawing.Size(210, 25);
            this.inCollisionHistory.TabIndex = 4;
            // 
            // inOverwriteFiles
            // 
            this.inOverwriteFiles.Label = "Overwrite Files:";
            this.inOverwriteFiles.Location = new System.Drawing.Point(6, 174);
            this.inOverwriteFiles.Name = "inOverwriteFiles";
            this.inOverwriteFiles.Size = new System.Drawing.Size(210, 25);
            this.inOverwriteFiles.TabIndex = 5;
            // 
            // inCommaDelimeted
            // 
            this.inCommaDelimeted.Label = "Comma Delimited:";
            this.inCommaDelimeted.Location = new System.Drawing.Point(6, 205);
            this.inCommaDelimeted.Name = "inCommaDelimeted";
            this.inCommaDelimeted.Size = new System.Drawing.Size(210, 25);
            this.inCommaDelimeted.TabIndex = 6;
            // 
            // inDetectorFile
            // 
            this.inDetectorFile.Label = "Detector File:";
            this.inDetectorFile.Location = new System.Drawing.Point(6, 236);
            this.inDetectorFile.Name = "inDetectorFile";
            this.inDetectorFile.Size = new System.Drawing.Size(210, 25);
            this.inDetectorFile.TabIndex = 7;
            // 
            // inOutputFiles
            // 
            this.inOutputFiles.Label = "Output Name:";
            this.inOutputFiles.Location = new System.Drawing.Point(6, 267);
            this.inOutputFiles.Name = "inOutputFiles";
            this.inOutputFiles.Size = new System.Drawing.Size(210, 25);
            this.inOutputFiles.TabIndex = 8;
            // 
            // FileIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FileIO";
            this.Size = new System.Drawing.Size(229, 305);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputString inOutputFiles;
        private InputString inDetectorFile;
        private InputBoolean inCommaDelimeted;
        private InputBoolean inOverwriteFiles;
        private InputBoolean inCollisionHistory;
        private InputBoolean inPrintSummaryTable;
        private InputBoolean inPrintListmode;
        private InputBoolean inSeparateDRFs;
        private InputBoolean inLabelOutput;
    }
}
