namespace GuiWidgets.Source
{
    partial class FuelSource
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
            this.bLaunchFuel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inHeightDisplacement = new GuiWidgets.InputNumber();
            this.inFuelFile = new GuiWidgets.InputFile();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bLaunchFuel
            // 
            this.bLaunchFuel.Location = new System.Drawing.Point(6, 50);
            this.bLaunchFuel.Name = "bLaunchFuel";
            this.bLaunchFuel.Size = new System.Drawing.Size(108, 23);
            this.bLaunchFuel.TabIndex = 0;
            this.bLaunchFuel.Text = "Launch Fuel Editor";
            this.bLaunchFuel.UseVisualStyleBackColor = true;
            this.bLaunchFuel.Click += new System.EventHandler(this.bLaunchFuel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inHeightDisplacement);
            this.groupBox1.Controls.Add(this.inFuelFile);
            this.groupBox1.Controls.Add(this.bLaunchFuel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specify Fuel Assembly";
            // 
            // inHeightDisplacement
            // 
            this.inHeightDisplacement.DataIsInteger = true;
            this.inHeightDisplacement.Label = "Raise/Lower (cm):";
            this.inHeightDisplacement.Location = new System.Drawing.Point(6, 79);
            this.inHeightDisplacement.Name = "inHeightDisplacement";
            this.inHeightDisplacement.Size = new System.Drawing.Size(210, 25);
            this.inHeightDisplacement.TabIndex = 2;
            // 
            // inFuelFile
            // 
            this.inFuelFile.Label = "Fuel File:";
            this.inFuelFile.Location = new System.Drawing.Point(6, 19);
            this.inFuelFile.Name = "inFuelFile";
            this.inFuelFile.Size = new System.Drawing.Size(210, 25);
            this.inFuelFile.TabIndex = 1;
            // 
            // FuelSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FuelSource";
            this.Size = new System.Drawing.Size(226, 118);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bLaunchFuel;
        private System.Windows.Forms.GroupBox groupBox1;
        private InputFile inFuelFile;
        private InputNumber inHeightDisplacement;
    }
}
