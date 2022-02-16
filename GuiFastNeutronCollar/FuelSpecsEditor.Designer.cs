namespace GuiFastNeutronCollar
{
    partial class FuelSpecsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuelSpecsEditor));
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.fuelAssemblySpecs1 = new GuiWidgets.Fuel.FuelAssemblySpecs();
            this.bSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-7, -8);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(259, 366);
            this.uniPanel1.TabIndex = 0;
            // 
            // fuelAssemblySpecs1
            // 
            this.fuelAssemblySpecs1.Location = new System.Drawing.Point(12, 12);
            this.fuelAssemblySpecs1.Name = "fuelAssemblySpecs1";
            this.fuelAssemblySpecs1.Size = new System.Drawing.Size(224, 302);
            this.fuelAssemblySpecs1.TabIndex = 1;
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(161, 320);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(75, 23);
            this.bSubmit.TabIndex = 2;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // FuelSpecsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 351);
            this.Controls.Add(this.bSubmit);
            this.Controls.Add(this.fuelAssemblySpecs1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 390);
            this.MinimumSize = new System.Drawing.Size(260, 390);
            this.Name = "FuelSpecsEditor";
            this.Text = "Fuel Specs Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FuelSpecsEditor_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private GuiWidgets.UniPanel uniPanel1;
        private GuiWidgets.Fuel.FuelAssemblySpecs fuelAssemblySpecs1;
        private System.Windows.Forms.Button bSubmit;
    }
}