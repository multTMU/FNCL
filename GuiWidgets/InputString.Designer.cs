namespace GuiWidgets
{
    partial class InputString
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
            this.labelInput = new System.Windows.Forms.Label();
            this.tbString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(3, 6);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(35, 13);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "label1";
            this.labelInput.Click += new System.EventHandler(this.labelInput_Click);
            // 
            // tbString
            // 
            this.tbString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbString.Location = new System.Drawing.Point(75, 3);
            this.tbString.Name = "tbString";
            this.tbString.Size = new System.Drawing.Size(132, 20);
            this.tbString.TabIndex = 1;
            this.tbString.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbString_KeyPress);
            this.tbString.Validated += new System.EventHandler(this.tbString_Validated);
            // 
            // InputString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbString);
            this.Controls.Add(this.labelInput);
            this.Name = "InputString";
            this.Size = new System.Drawing.Size(210, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox tbString;
    }
}
