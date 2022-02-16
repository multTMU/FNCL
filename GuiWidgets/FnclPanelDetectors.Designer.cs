namespace GuiWidgets
{
    partial class FnclPanelDetectors
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
            this.inDet4 = new GuiWidgets.InputNumber();
            this.inDet3 = new GuiWidgets.InputNumber();
            this.inDet2 = new GuiWidgets.InputNumber();
            this.inDet1 = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inDet4);
            this.groupBox1.Controls.Add(this.inDet3);
            this.groupBox1.Controls.Add(this.inDet2);
            this.groupBox1.Controls.Add(this.inDet1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Panel ";
            // 
            // inDet4
            // 
            this.inDet4.DataIsInteger = true;
            this.inDet4.Label = "Det. 4:";
            this.inDet4.Location = new System.Drawing.Point(144, 52);
            this.inDet4.Name = "inDet4";
            this.inDet4.Size = new System.Drawing.Size(132, 27);
            this.inDet4.TabIndex = 3;
            // 
            // inDet3
            // 
            this.inDet3.DataIsInteger = true;
            this.inDet3.Label = "Det. 3:";
            this.inDet3.Location = new System.Drawing.Point(6, 52);
            this.inDet3.Name = "inDet3";
            this.inDet3.Size = new System.Drawing.Size(132, 27);
            this.inDet3.TabIndex = 2;
            // 
            // inDet2
            // 
            this.inDet2.DataIsInteger = true;
            this.inDet2.Label = "Det. 2:";
            this.inDet2.Location = new System.Drawing.Point(144, 19);
            this.inDet2.Name = "inDet2";
            this.inDet2.Size = new System.Drawing.Size(132, 27);
            this.inDet2.TabIndex = 1;
            // 
            // inDet1
            // 
            this.inDet1.DataIsInteger = true;
            this.inDet1.Label = "Det. 1:";
            this.inDet1.Location = new System.Drawing.Point(6, 19);
            this.inDet1.Name = "inDet1";
            this.inDet1.Size = new System.Drawing.Size(132, 27);
            this.inDet1.TabIndex = 0;
            // 
            // PanelTimeOffset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FnclPanelDetectors";
            this.Size = new System.Drawing.Size(285, 92);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inDet4;
        private InputNumber inDet3;
        private InputNumber inDet2;
        private InputNumber inDet1;
    }
}
