namespace GuiFastNeutronCollar
{
    partial class FuelArrayEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuelArrayEditor));
            this.bSelectAll = new System.Windows.Forms.Button();
            this.bDeSelect = new System.Windows.Forms.Button();
            this.bSetAllFuel = new System.Windows.Forms.Button();
            this.bInChannels = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bFuelSpecs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inComment = new GuiWidgets.InputString();
            this.materialViewer1 = new GuiWidgets.Materials.MaterialViewer();
            this.inCols = new GuiWidgets.InputNumber();
            this.inRows = new GuiWidgets.InputNumber();
            this.inFuelArrayFile = new GuiWidgets.InputFile();
            this.fuelArrayGui1 = new GuiWidgets.Fuel.FuelArrayGui();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bInvert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSelectAll
            // 
            this.bSelectAll.Location = new System.Drawing.Point(534, 43);
            this.bSelectAll.Name = "bSelectAll";
            this.bSelectAll.Size = new System.Drawing.Size(75, 23);
            this.bSelectAll.TabIndex = 1;
            this.bSelectAll.Text = "Select All";
            this.bSelectAll.UseVisualStyleBackColor = true;
            this.bSelectAll.Click += new System.EventHandler(this.bSelectAll_Click);
            // 
            // bDeSelect
            // 
            this.bDeSelect.Location = new System.Drawing.Point(615, 43);
            this.bDeSelect.Name = "bDeSelect";
            this.bDeSelect.Size = new System.Drawing.Size(75, 23);
            this.bDeSelect.TabIndex = 2;
            this.bDeSelect.Text = "DeSelect All";
            this.bDeSelect.UseVisualStyleBackColor = true;
            this.bDeSelect.Click += new System.EventHandler(this.bDeSelect_Click);
            // 
            // bSetAllFuel
            // 
            this.bSetAllFuel.Location = new System.Drawing.Point(858, 43);
            this.bSetAllFuel.Name = "bSetAllFuel";
            this.bSetAllFuel.Size = new System.Drawing.Size(75, 23);
            this.bSetAllFuel.TabIndex = 3;
            this.bSetAllFuel.Text = "Set All Pins";
            this.bSetAllFuel.UseVisualStyleBackColor = true;
            this.bSetAllFuel.Click += new System.EventHandler(this.bSetAllFuel_Click);
            // 
            // bInChannels
            // 
            this.bInChannels.Location = new System.Drawing.Point(939, 43);
            this.bInChannels.Name = "bInChannels";
            this.bInChannels.Size = new System.Drawing.Size(93, 23);
            this.bInChannels.TabIndex = 4;
            this.bInChannels.Text = "Set All Channels";
            this.bInChannels.UseVisualStyleBackColor = true;
            this.bInChannels.Click += new System.EventHandler(this.bInChannels_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(156, 50);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 11;
            this.bSave.Text = "Save As...";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bFuelSpecs
            // 
            this.bFuelSpecs.Location = new System.Drawing.Point(823, 727);
            this.bFuelSpecs.Name = "bFuelSpecs";
            this.bFuelSpecs.Size = new System.Drawing.Size(94, 23);
            this.bFuelSpecs.TabIndex = 12;
            this.bFuelSpecs.Text = "Edit Fuel Specs";
            this.bFuelSpecs.UseVisualStyleBackColor = true;
            this.bFuelSpecs.Click += new System.EventHandler(this.bFuelSpecs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inComment);
            this.groupBox1.Controls.Add(this.bSave);
            this.groupBox1.Location = new System.Drawing.Point(680, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 81);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Current";
            // 
            // inComment
            // 
            this.inComment.Label = "Comment:";
            this.inComment.Location = new System.Drawing.Point(6, 19);
            this.inComment.Name = "inComment";
            this.inComment.Size = new System.Drawing.Size(225, 25);
            this.inComment.TabIndex = 10;
            // 
            // materialViewer1
            // 
            this.materialViewer1.Location = new System.Drawing.Point(12, 418);
            this.materialViewer1.Name = "materialViewer1";
            this.materialViewer1.Size = new System.Drawing.Size(662, 347);
            this.materialViewer1.TabIndex = 13;
            // 
            // inCols
            // 
            this.inCols.DataIsInteger = true;
            this.inCols.Label = "Cols:";
            this.inCols.Location = new System.Drawing.Point(150, 41);
            this.inCols.Name = "inCols";
            this.inCols.Size = new System.Drawing.Size(132, 25);
            this.inCols.TabIndex = 9;
            // 
            // inRows
            // 
            this.inRows.DataIsInteger = true;
            this.inRows.Label = "Rows:";
            this.inRows.Location = new System.Drawing.Point(12, 41);
            this.inRows.Name = "inRows";
            this.inRows.Size = new System.Drawing.Size(132, 25);
            this.inRows.TabIndex = 8;
            // 
            // inFuelArrayFile
            // 
            this.inFuelArrayFile.Label = "Load Fuel File:";
            this.inFuelArrayFile.Location = new System.Drawing.Point(12, 12);
            this.inFuelArrayFile.Name = "inFuelArrayFile";
            this.inFuelArrayFile.Size = new System.Drawing.Size(210, 25);
            this.inFuelArrayFile.TabIndex = 5;
            // 
            // fuelArrayGui1
            // 
            this.fuelArrayGui1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fuelArrayGui1.Location = new System.Drawing.Point(12, 72);
            this.fuelArrayGui1.Name = "fuelArrayGui1";
            this.fuelArrayGui1.Size = new System.Drawing.Size(1020, 340);
            this.fuelArrayGui1.TabIndex = 0;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-5, -4);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(1058, 787);
            this.uniPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Checked denotes Cooling Channel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Unchecked denotes  Fuel Pin";
            // 
            // bInvert
            // 
            this.bInvert.Location = new System.Drawing.Point(696, 43);
            this.bInvert.Name = "bInvert";
            this.bInvert.Size = new System.Drawing.Size(75, 23);
            this.bInvert.TabIndex = 17;
            this.bInvert.Text = "Invert Select";
            this.bInvert.UseVisualStyleBackColor = true;
            this.bInvert.Click += new System.EventHandler(this.bInvert_Click);
            // 
            // FuelArrayEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 781);
            this.Controls.Add(this.bInvert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.materialViewer1);
            this.Controls.Add(this.bFuelSpecs);
            this.Controls.Add(this.inCols);
            this.Controls.Add(this.inRows);
            this.Controls.Add(this.inFuelArrayFile);
            this.Controls.Add(this.bInChannels);
            this.Controls.Add(this.bSetAllFuel);
            this.Controls.Add(this.bDeSelect);
            this.Controls.Add(this.bSelectAll);
            this.Controls.Add(this.fuelArrayGui1);
            this.Controls.Add(this.uniPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1060, 820);
            this.MinimumSize = new System.Drawing.Size(1060, 820);
            this.Name = "FuelArrayEditor";
            this.Text = "Fuel Assembly Editor";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GuiWidgets.Fuel.FuelArrayGui fuelArrayGui1;
        private System.Windows.Forms.Button bSelectAll;
        private System.Windows.Forms.Button bDeSelect;
        private System.Windows.Forms.Button bSetAllFuel;
        private System.Windows.Forms.Button bInChannels;
        private GuiWidgets.InputFile inFuelArrayFile;
        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.InputNumber inRows;
        private GuiWidgets.InputNumber inCols;
        private GuiWidgets.InputString inComment;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bFuelSpecs;
        private GuiWidgets.Materials.MaterialViewer materialViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bInvert;
    }
}