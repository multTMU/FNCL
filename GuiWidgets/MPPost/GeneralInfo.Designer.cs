namespace GuiWidgets.MPPost
{
    partial class GeneralInfo
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
            this.inTitle = new GuiWidgets.InputString();
            this.inUserName = new GuiWidgets.InputString();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inUserName);
            this.groupBox1.Controls.Add(this.inTitle);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Information";
            // 
            // inTitle
            // 
            this.inTitle.Label = "Title:";
            this.inTitle.Location = new System.Drawing.Point(6, 19);
            this.inTitle.Name = "inTitle";
            this.inTitle.Size = new System.Drawing.Size(210, 25);
            this.inTitle.TabIndex = 0;
            // 
            // inUserName
            // 
            this.inUserName.Label = "Username:";
            this.inUserName.Location = new System.Drawing.Point(6, 50);
            this.inUserName.Name = "inUserName";
            this.inUserName.Size = new System.Drawing.Size(210, 25);
            this.inUserName.TabIndex = 1;
            // 
            // GeneralInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "GeneralInfo";
            this.Size = new System.Drawing.Size(225, 87);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputString inUserName;
        private InputString inTitle;
    }
}
