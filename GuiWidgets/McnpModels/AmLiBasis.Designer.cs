namespace GuiWidgets.FnclModels
{
    partial class AmLiBasis
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
            this.inRightAmLi = new GuiWidgets.InputNumber();
            this.inLeftAmLi = new GuiWidgets.InputNumber();
            this.cbAmLiBlock = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inRightAmLi);
            this.groupBox1.Controls.Add(this.inLeftAmLi);
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AmLi Relative Intensity";
            // 
            // inRightAmLi
            // 
            this.inRightAmLi.DataIsInteger = true;
            this.inRightAmLi.Label = "Right:";
            this.inRightAmLi.Location = new System.Drawing.Point(6, 50);
            this.inRightAmLi.Name = "inRightAmLi";
            this.inRightAmLi.Size = new System.Drawing.Size(210, 25);
            this.inRightAmLi.TabIndex = 1;
            // 
            // inLeftAmLi
            // 
            this.inLeftAmLi.DataIsInteger = true;
            this.inLeftAmLi.Label = "Left:";
            this.inLeftAmLi.Location = new System.Drawing.Point(6, 19);
            this.inLeftAmLi.Name = "inLeftAmLi";
            this.inLeftAmLi.Size = new System.Drawing.Size(210, 25);
            this.inLeftAmLi.TabIndex = 0;
            // 
            // cbAmLiBlock
            // 
            this.cbAmLiBlock.FormattingEnabled = true;
            this.cbAmLiBlock.Location = new System.Drawing.Point(128, 3);
            this.cbAmLiBlock.Name = "cbAmLiBlock";
            this.cbAmLiBlock.Size = new System.Drawing.Size(91, 21);
            this.cbAmLiBlock.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AmLi Block Type:";
            // 
            // AmLiBasis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAmLiBlock);
            this.Controls.Add(this.groupBox1);
            this.Name = "AmLiBasis";
            this.Size = new System.Drawing.Size(226, 116);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inRightAmLi;
        private InputNumber inLeftAmLi;
        private System.Windows.Forms.ComboBox cbAmLiBlock;
        private System.Windows.Forms.Label label1;
    }
}
