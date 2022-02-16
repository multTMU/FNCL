namespace GuiWidgets.MPPost
{
    partial class PulseGeneration
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
            this.inOrganicLiquid = new GuiWidgets.InputNumber();
            this.inNaI = new GuiWidgets.InputNumber();
            this.inOrganicPlastic = new GuiWidgets.InputNumber();
            this.inCaF2 = new GuiWidgets.InputNumber();
            this.inLaBr3 = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inLaBr3);
            this.groupBox1.Controls.Add(this.inCaF2);
            this.groupBox1.Controls.Add(this.inOrganicPlastic);
            this.groupBox1.Controls.Add(this.inNaI);
            this.groupBox1.Controls.Add(this.inOrganicLiquid);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Generate Time (ns)";
            // 
            // inOrganicLiquid
            // 
            this.inOrganicLiquid.DataIsInteger = true;
            this.inOrganicLiquid.Label = "Organic Liquid:";
            this.inOrganicLiquid.Location = new System.Drawing.Point(6, 19);
            this.inOrganicLiquid.Name = "inOrganicLiquid";
            this.inOrganicLiquid.Size = new System.Drawing.Size(210, 25);
            this.inOrganicLiquid.TabIndex = 0;
            // 
            // inNaI
            // 
            this.inNaI.DataIsInteger = true;
            this.inNaI.Label = "NaI:";
            this.inNaI.Location = new System.Drawing.Point(6, 81);
            this.inNaI.Name = "inNaI";
            this.inNaI.Size = new System.Drawing.Size(210, 25);
            this.inNaI.TabIndex = 1;
            // 
            // inOrganicPlastic
            // 
            this.inOrganicPlastic.DataIsInteger = true;
            this.inOrganicPlastic.Label = "Organic Plastic:";
            this.inOrganicPlastic.Location = new System.Drawing.Point(6, 50);
            this.inOrganicPlastic.Name = "inOrganicPlastic";
            this.inOrganicPlastic.Size = new System.Drawing.Size(210, 25);
            this.inOrganicPlastic.TabIndex = 2;
            // 
            // inCaF2
            // 
            this.inCaF2.DataIsInteger = true;
            this.inCaF2.Label = "CaF2:";
            this.inCaF2.Location = new System.Drawing.Point(6, 112);
            this.inCaF2.Name = "inCaF2";
            this.inCaF2.Size = new System.Drawing.Size(210, 25);
            this.inCaF2.TabIndex = 3;
            // 
            // inLaBr3
            // 
            this.inLaBr3.DataIsInteger = true;
            this.inLaBr3.Label = "LaBr3:";
            this.inLaBr3.Location = new System.Drawing.Point(6, 143);
            this.inLaBr3.Name = "inLaBr3";
            this.inLaBr3.Size = new System.Drawing.Size(210, 25);
            this.inLaBr3.TabIndex = 4;
            // 
            // PulseGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PulseGeneration";
            this.Size = new System.Drawing.Size(229, 182);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inLaBr3;
        private InputNumber inCaF2;
        private InputNumber inOrganicPlastic;
        private InputNumber inNaI;
        private InputNumber inOrganicLiquid;
    }
}
