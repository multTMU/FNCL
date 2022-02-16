namespace GuiFastNeutronCollar
{
    partial class AddPoliMi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPoliMi));
            this.bSubmit = new System.Windows.Forms.Button();
            this.poliMiSpecification1 = new GuiWidgets.PoliMiSpecification();
            this.poliMiFiles1 = new GuiWidgets.PoliMi.PoliMiFiles();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(617, 198);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(75, 23);
            this.bSubmit.TabIndex = 3;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // poliMiSpecification1
            // 
            this.poliMiSpecification1.Location = new System.Drawing.Point(12, 6);
            this.poliMiSpecification1.Name = "poliMiSpecification1";
            this.poliMiSpecification1.Size = new System.Drawing.Size(217, 185);
            this.poliMiSpecification1.TabIndex = 2;
            // 
            // poliMiFiles1
            // 
            this.poliMiFiles1.Location = new System.Drawing.Point(235, 6);
            this.poliMiFiles1.Name = "poliMiFiles1";
            this.poliMiFiles1.Size = new System.Drawing.Size(460, 185);
            this.poliMiFiles1.TabIndex = 1;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-6, -6);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(711, 240);
            this.uniPanel1.TabIndex = 0;
            // 
            // AddPoliMi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 231);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.poliMiSpecification1);
            this.Controls.Add(this.poliMiFiles1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(715, 270);
            this.MinimumSize = new System.Drawing.Size(715, 270);
            this.Name = "AddPoliMi";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add PoliMi File";
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.PoliMi.PoliMiFiles poliMiFiles1;
        private GuiWidgets.PoliMiSpecification poliMiSpecification1;
        private System.Windows.Forms.Button bSubmit;
    }
}