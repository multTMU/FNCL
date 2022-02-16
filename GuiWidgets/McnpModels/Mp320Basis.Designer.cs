namespace GuiWidgets.FnclModels
{
    partial class Mp320Basis
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
            this.gbModerator = new System.Windows.Forms.GroupBox();
            this.cbCd = new System.Windows.Forms.CheckBox();
            this.cbPb = new System.Windows.Forms.CheckBox();
            this.gbMP320 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLeftPanelTwo = new System.Windows.Forms.CheckBox();
            this.inShieldDimensions = new GuiWidgets.Source.Set3D();
            this.inPeExtraThickness = new GuiWidgets.InputNumber();
            this.inThickCd = new GuiWidgets.InputNumber();
            this.inThickPb = new GuiWidgets.InputNumber();
            this.cbRightPanelOne = new System.Windows.Forms.CheckBox();
            this.gbModerator.SuspendLayout();
            this.gbMP320.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbModerator
            // 
            this.gbModerator.Controls.Add(this.inPeExtraThickness);
            this.gbModerator.Controls.Add(this.inThickCd);
            this.gbModerator.Controls.Add(this.inThickPb);
            this.gbModerator.Controls.Add(this.cbCd);
            this.gbModerator.Controls.Add(this.cbPb);
            this.gbModerator.Location = new System.Drawing.Point(6, 19);
            this.gbModerator.Name = "gbModerator";
            this.gbModerator.Size = new System.Drawing.Size(284, 102);
            this.gbModerator.TabIndex = 3;
            this.gbModerator.TabStop = false;
            this.gbModerator.Text = "Moderator";
            // 
            // cbCd
            // 
            this.cbCd.AutoSize = true;
            this.cbCd.Location = new System.Drawing.Point(151, 18);
            this.cbCd.Name = "cbCd";
            this.cbCd.Size = new System.Drawing.Size(69, 17);
            this.cbCd.TabIndex = 4;
            this.cbCd.Text = "Cadmium";
            this.cbCd.UseVisualStyleBackColor = true;
            // 
            // cbPb
            // 
            this.cbPb.AutoSize = true;
            this.cbPb.Location = new System.Drawing.Point(13, 18);
            this.cbPb.Name = "cbPb";
            this.cbPb.Size = new System.Drawing.Size(50, 17);
            this.cbPb.TabIndex = 3;
            this.cbPb.Text = "Lead";
            this.cbPb.UseVisualStyleBackColor = true;
            // 
            // gbMP320
            // 
            this.gbMP320.Controls.Add(this.groupBox1);
            this.gbMP320.Controls.Add(this.gbModerator);
            this.gbMP320.Location = new System.Drawing.Point(3, 3);
            this.gbMP320.Name = "gbMP320";
            this.gbMP320.Size = new System.Drawing.Size(296, 263);
            this.gbMP320.TabIndex = 0;
            this.gbMP320.TabStop = false;
            this.gbMP320.Text = "MP320 Neutron Generator";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbRightPanelOne);
            this.groupBox1.Controls.Add(this.inShieldDimensions);
            this.groupBox1.Controls.Add(this.cbLeftPanelTwo);
            this.groupBox1.Location = new System.Drawing.Point(6, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Side Panel Pb Shield";
            // 
            // cbLeftPanel
            // 
            this.cbLeftPanelTwo.AutoSize = true;
            this.cbLeftPanelTwo.Location = new System.Drawing.Point(6, 42);
            this.cbLeftPanelTwo.Name = "cbLeftPanelTwo";
            this.cbLeftPanelTwo.Size = new System.Drawing.Size(89, 17);
            this.cbLeftPanelTwo.TabIndex = 5;
            this.cbLeftPanelTwo.Text = "Panel Left (2)";
            this.cbLeftPanelTwo.UseVisualStyleBackColor = true;
            // 
            // inShieldDimensions
            // 
            this.inShieldDimensions.Location = new System.Drawing.Point(139, 10);
            this.inShieldDimensions.Name = "inShieldDimensions";
            this.inShieldDimensions.Size = new System.Drawing.Size(139, 118);
            this.inShieldDimensions.TabIndex = 7;
            // 
            // inPeExtraThickness
            // 
            this.inPeExtraThickness.DataIsInteger = true;
            this.inPeExtraThickness.Label = "Extra PE Thickenss:";
            this.inPeExtraThickness.Location = new System.Drawing.Point(6, 72);
            this.inPeExtraThickness.Name = "inPeExtraThickness";
            this.inPeExtraThickness.Size = new System.Drawing.Size(197, 25);
            this.inPeExtraThickness.TabIndex = 7;
            // 
            // inThickCd
            // 
            this.inThickCd.DataIsInteger = true;
            this.inThickCd.Label = "Width:";
            this.inThickCd.Location = new System.Drawing.Point(145, 41);
            this.inThickCd.Name = "inThickCd";
            this.inThickCd.Size = new System.Drawing.Size(133, 25);
            this.inThickCd.TabIndex = 6;
            // 
            // inThickPb
            // 
            this.inThickPb.DataIsInteger = true;
            this.inThickPb.Label = "Width:";
            this.inThickPb.Location = new System.Drawing.Point(6, 41);
            this.inThickPb.Name = "inThickPb";
            this.inThickPb.Size = new System.Drawing.Size(133, 25);
            this.inThickPb.TabIndex = 5;
            // 
            // cbRightPanelOne
            // 
            this.cbRightPanelOne.AutoSize = true;
            this.cbRightPanelOne.Location = new System.Drawing.Point(6, 19);
            this.cbRightPanelOne.Name = "cbRightPanelOne";
            this.cbRightPanelOne.Size = new System.Drawing.Size(96, 17);
            this.cbRightPanelOne.TabIndex = 8;
            this.cbRightPanelOne.Text = "Panel Right (1)";
            this.cbRightPanelOne.UseVisualStyleBackColor = true;
            // 
            // Mp320Basis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMP320);
            this.Name = "Mp320Basis";
            this.Size = new System.Drawing.Size(303, 269);
            this.gbModerator.ResumeLayout(false);
            this.gbModerator.PerformLayout();
            this.gbMP320.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbModerator;
        private InputNumber inPeExtraThickness;
        private InputNumber inThickCd;
        private InputNumber inThickPb;
        private System.Windows.Forms.CheckBox cbCd;
        private System.Windows.Forms.CheckBox cbPb;
        private System.Windows.Forms.GroupBox gbMP320;
        private System.Windows.Forms.GroupBox groupBox1;
        private Source.Set3D inShieldDimensions;
        private System.Windows.Forms.CheckBox cbLeftPanelTwo;
        private System.Windows.Forms.CheckBox cbRightPanelOne;
    }
}
