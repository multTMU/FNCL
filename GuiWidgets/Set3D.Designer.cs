namespace GuiWidgets.Source
{
    partial class Set3D
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
            this.gbPointOrAxis = new System.Windows.Forms.GroupBox();
            this.inZ = new GuiWidgets.InputNumber();
            this.inY = new GuiWidgets.InputNumber();
            this.inX = new GuiWidgets.InputNumber();
            this.gbPointOrAxis.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPointOrAxis
            // 
            this.gbPointOrAxis.Controls.Add(this.inZ);
            this.gbPointOrAxis.Controls.Add(this.inY);
            this.gbPointOrAxis.Controls.Add(this.inX);
            this.gbPointOrAxis.Location = new System.Drawing.Point(3, 3);
            this.gbPointOrAxis.Name = "gbPointOrAxis";
            this.gbPointOrAxis.Size = new System.Drawing.Size(131, 112);
            this.gbPointOrAxis.TabIndex = 1;
            this.gbPointOrAxis.TabStop = false;
            this.gbPointOrAxis.Text = "Set3d";
            // 
            // inZ
            // 
            this.inZ.DataIsInteger = true;
            this.inZ.Label = "Z:";
            this.inZ.Location = new System.Drawing.Point(6, 81);
            this.inZ.Name = "inZ";
            this.inZ.Size = new System.Drawing.Size(123, 25);
            this.inZ.TabIndex = 2;
            // 
            // inY
            // 
            this.inY.DataIsInteger = true;
            this.inY.Label = "Y:";
            this.inY.Location = new System.Drawing.Point(6, 50);
            this.inY.Name = "inY";
            this.inY.Size = new System.Drawing.Size(123, 25);
            this.inY.TabIndex = 1;
            // 
            // inX
            // 
            this.inX.DataIsInteger = true;
            this.inX.Label = "X:";
            this.inX.Location = new System.Drawing.Point(6, 19);
            this.inX.Name = "inX";
            this.inX.Size = new System.Drawing.Size(123, 25);
            this.inX.TabIndex = 0;
            // 
            // Set3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPointOrAxis);
            this.Name = "Set3D";
            this.Size = new System.Drawing.Size(139, 118);
            this.gbPointOrAxis.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private InputNumber inX;
        private System.Windows.Forms.GroupBox gbPointOrAxis;
        private InputNumber inZ;
        private InputNumber inY;
    }
}
