namespace GuiWidgets.Fuel
{
    partial class FuelPin
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
            this.cbFuel = new System.Windows.Forms.CheckBox();
            this.matLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // cbFuel
            // 
            this.cbFuel.AutoSize = true;
            this.cbFuel.Location = new System.Drawing.Point(3, 3);
            this.cbFuel.Name = "cbFuel";
            this.cbFuel.Size = new System.Drawing.Size(15, 14);
            this.cbFuel.TabIndex = 1;
            this.cbFuel.UseVisualStyleBackColor = true;
            this.cbFuel.CheckedChanged += new System.EventHandler(this.cbFuel_CheckedChanged);
            // 
            // matLabel
            // 
            this.matLabel.AutoSize = true;
            this.matLabel.Location = new System.Drawing.Point(24, 3);
            this.matLabel.Name = "matLabel";
            this.matLabel.Size = new System.Drawing.Size(30, 13);
            this.matLabel.TabIndex = 2;
            this.matLabel.Text = "MAT";
            this.matLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.matLabel_MouseClick);
            // 
            // FuelPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.matLabel);
            this.Controls.Add(this.cbFuel);
            this.Name = "FuelPin";
            this.Size = new System.Drawing.Size(60, 20);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FuelPin_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbFuel;
        private System.Windows.Forms.Label matLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
