namespace GuiWidgets.Fuel
{
    partial class FuelAssemblySpecs
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
            this.inRows = new GuiWidgets.InputNumber();
            this.inCols = new GuiWidgets.InputNumber();
            this.inPitch = new GuiWidgets.InputNumber();
            this.inCladdingOuterRadius = new GuiWidgets.InputNumber();
            this.inCladdingInnerRadius = new GuiWidgets.InputNumber();
            this.inFuelPinRadius = new GuiWidgets.InputNumber();
            this.inFuelLength = new GuiWidgets.InputNumber();
            this.inCoolOuterRad = new GuiWidgets.InputNumber();
            this.inCoolInnerRad = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inFuelLength);
            this.groupBox1.Controls.Add(this.inCoolOuterRad);
            this.groupBox1.Controls.Add(this.inCoolInnerRad);
            this.groupBox1.Controls.Add(this.inCladdingOuterRadius);
            this.groupBox1.Controls.Add(this.inCladdingInnerRadius);
            this.groupBox1.Controls.Add(this.inFuelPinRadius);
            this.groupBox1.Controls.Add(this.inPitch);
            this.groupBox1.Controls.Add(this.inCols);
            this.groupBox1.Controls.Add(this.inRows);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuel Assembly Specification";
            // 
            // inRows
            // 
            this.inRows.DataIsInteger = true;
            this.inRows.Label = "Rows:";
            this.inRows.Location = new System.Drawing.Point(6, 19);
            this.inRows.Name = "inRows";
            this.inRows.Size = new System.Drawing.Size(210, 25);
            this.inRows.TabIndex = 0;
            // 
            // inCols
            // 
            this.inCols.DataIsInteger = true;
            this.inCols.Label = "Columns:";
            this.inCols.Location = new System.Drawing.Point(6, 50);
            this.inCols.Name = "inCols";
            this.inCols.Size = new System.Drawing.Size(210, 25);
            this.inCols.TabIndex = 1;
            // 
            // inPitch
            // 
            this.inPitch.DataIsInteger = true;
            this.inPitch.Label = "Pitch:";
            this.inPitch.Location = new System.Drawing.Point(6, 81);
            this.inPitch.Name = "inPitch";
            this.inPitch.Size = new System.Drawing.Size(210, 25);
            this.inPitch.TabIndex = 2;
            // 
            // inCladdingOuterRadius
            // 
            this.inCladdingOuterRadius.DataIsInteger = true;
            this.inCladdingOuterRadius.Label = "Clad Outer Radius:";
            this.inCladdingOuterRadius.Location = new System.Drawing.Point(6, 174);
            this.inCladdingOuterRadius.Name = "inCladdingOuterRadius";
            this.inCladdingOuterRadius.Size = new System.Drawing.Size(210, 25);
            this.inCladdingOuterRadius.TabIndex = 5;
            // 
            // inCladdingInnerRadius
            // 
            this.inCladdingInnerRadius.DataIsInteger = true;
            this.inCladdingInnerRadius.Label = "Clad Inner Radius:";
            this.inCladdingInnerRadius.Location = new System.Drawing.Point(6, 143);
            this.inCladdingInnerRadius.Name = "inCladdingInnerRadius";
            this.inCladdingInnerRadius.Size = new System.Drawing.Size(210, 25);
            this.inCladdingInnerRadius.TabIndex = 4;
            // 
            // inFuelPinRadius
            // 
            this.inFuelPinRadius.DataIsInteger = true;
            this.inFuelPinRadius.Label = "Fuel Pin Radius:";
            this.inFuelPinRadius.Location = new System.Drawing.Point(6, 112);
            this.inFuelPinRadius.Name = "inFuelPinRadius";
            this.inFuelPinRadius.Size = new System.Drawing.Size(210, 25);
            this.inFuelPinRadius.TabIndex = 3;
            // 
            // inFuelLength
            // 
            this.inFuelLength.DataIsInteger = true;
            this.inFuelLength.Label = "Fuel Length:";
            this.inFuelLength.Location = new System.Drawing.Point(6, 267);
            this.inFuelLength.Name = "inFuelLength";
            this.inFuelLength.Size = new System.Drawing.Size(210, 25);
            this.inFuelLength.TabIndex = 8;
            // 
            // inCoolOuterRad
            // 
            this.inCoolOuterRad.DataIsInteger = true;
            this.inCoolOuterRad.Label = "Cool Outer Radius:";
            this.inCoolOuterRad.Location = new System.Drawing.Point(6, 236);
            this.inCoolOuterRad.Name = "inCoolOuterRad";
            this.inCoolOuterRad.Size = new System.Drawing.Size(210, 25);
            this.inCoolOuterRad.TabIndex = 7;
            // 
            // inCoolInnerRad
            // 
            this.inCoolInnerRad.DataIsInteger = true;
            this.inCoolInnerRad.Label = "Cool Inner Radius:";
            this.inCoolInnerRad.Location = new System.Drawing.Point(6, 205);
            this.inCoolInnerRad.Name = "inCoolInnerRad";
            this.inCoolInnerRad.Size = new System.Drawing.Size(210, 25);
            this.inCoolInnerRad.TabIndex = 6;
            // 
            // FuelAssemblySpecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FuelAssemblySpecs";
            this.Size = new System.Drawing.Size(224, 302);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inFuelLength;
        private InputNumber inCoolOuterRad;
        private InputNumber inCoolInnerRad;
        private InputNumber inCladdingOuterRadius;
        private InputNumber inCladdingInnerRadius;
        private InputNumber inFuelPinRadius;
        private InputNumber inPitch;
        private InputNumber inCols;
        private InputNumber inRows;
    }
}
