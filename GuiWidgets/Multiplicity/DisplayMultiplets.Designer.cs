namespace GuiWidgets
{
    partial class DisplayMultiplets
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.singlesValue = new System.Windows.Forms.TextBox();
            this.doublesValue = new System.Windows.Forms.TextBox();
            this.triplesValue = new System.Windows.Forms.TextBox();
            this.triplesUncert = new System.Windows.Forms.TextBox();
            this.doublesUncert = new System.Windows.Forms.TextBox();
            this.singlesUncert = new System.Windows.Forms.TextBox();
            this.gbRates = new System.Windows.Forms.GroupBox();
            this.gbRates.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Singles:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Doubles:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Triples:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "+/-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "+/-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "+/-";
            // 
            // singlesValue
            // 
            this.singlesValue.Location = new System.Drawing.Point(61, 17);
            this.singlesValue.Name = "singlesValue";
            this.singlesValue.ReadOnly = true;
            this.singlesValue.Size = new System.Drawing.Size(100, 20);
            this.singlesValue.TabIndex = 6;
            // 
            // doublesValue
            // 
            this.doublesValue.Location = new System.Drawing.Point(61, 43);
            this.doublesValue.Name = "doublesValue";
            this.doublesValue.ReadOnly = true;
            this.doublesValue.Size = new System.Drawing.Size(100, 20);
            this.doublesValue.TabIndex = 7;
            // 
            // tripelsValue
            // 
            this.triplesValue.Location = new System.Drawing.Point(61, 69);
            this.triplesValue.Name = "triplesValue";
            this.triplesValue.ReadOnly = true;
            this.triplesValue.Size = new System.Drawing.Size(100, 20);
            this.triplesValue.TabIndex = 8;
            // 
            // triplesUncert
            // 
            this.triplesUncert.Location = new System.Drawing.Point(194, 69);
            this.triplesUncert.Name = "triplesUncert";
            this.triplesUncert.ReadOnly = true;
            this.triplesUncert.Size = new System.Drawing.Size(100, 20);
            this.triplesUncert.TabIndex = 11;
            // 
            // doublesUncert
            // 
            this.doublesUncert.Location = new System.Drawing.Point(194, 43);
            this.doublesUncert.Name = "doublesUncert";
            this.doublesUncert.ReadOnly = true;
            this.doublesUncert.Size = new System.Drawing.Size(100, 20);
            this.doublesUncert.TabIndex = 10;
            // 
            // singlesUncert
            // 
            this.singlesUncert.Location = new System.Drawing.Point(194, 17);
            this.singlesUncert.Name = "singlesUncert";
            this.singlesUncert.ReadOnly = true;
            this.singlesUncert.Size = new System.Drawing.Size(100, 20);
            this.singlesUncert.TabIndex = 9;
            // 
            // gbRates
            // 
            this.gbRates.Controls.Add(this.label2);
            this.gbRates.Controls.Add(this.triplesUncert);
            this.gbRates.Controls.Add(this.label1);
            this.gbRates.Controls.Add(this.doublesUncert);
            this.gbRates.Controls.Add(this.label3);
            this.gbRates.Controls.Add(this.singlesUncert);
            this.gbRates.Controls.Add(this.label4);
            this.gbRates.Controls.Add(this.triplesValue);
            this.gbRates.Controls.Add(this.label5);
            this.gbRates.Controls.Add(this.doublesValue);
            this.gbRates.Controls.Add(this.label6);
            this.gbRates.Controls.Add(this.singlesValue);
            this.gbRates.Location = new System.Drawing.Point(3, 3);
            this.gbRates.Name = "gbRates";
            this.gbRates.Size = new System.Drawing.Size(304, 98);
            this.gbRates.TabIndex = 12;
            this.gbRates.TabStop = false;
            this.gbRates.Text = "Multiplet Rates (cps)";
            // 
            // DisplayMultiplets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbRates);
            this.MaximumSize = new System.Drawing.Size(310, 100);
            this.MinimumSize = new System.Drawing.Size(310, 100);
            this.Name = "DisplayMultiplets";
            this.Size = new System.Drawing.Size(310, 100);
            this.gbRates.ResumeLayout(false);
            this.gbRates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox singlesValue;
        private System.Windows.Forms.TextBox doublesValue;
        private System.Windows.Forms.TextBox triplesValue;
        private System.Windows.Forms.TextBox triplesUncert;
        private System.Windows.Forms.TextBox doublesUncert;
        private System.Windows.Forms.TextBox singlesUncert;
        private System.Windows.Forms.GroupBox gbRates;
    }
}
