namespace GuiWidgets.MPPost
{
    partial class DeadTime
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inOrganicLiquid = new GuiWidgets.InputNumber();
            this.inOrganicPlastic = new GuiWidgets.InputNumber();
            this.inCaF2 = new GuiWidgets.InputNumber();
            this.inNaI = new GuiWidgets.InputNumber();
            this.inLaBr3 = new GuiWidgets.InputNumber();
            this.inHistoEndMeVee = new GuiWidgets.InputNumber();
            this.inHistoBinMeVee = new GuiWidgets.InputNumber();
            this.inHistoStartMeVee = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inLaBr3);
            this.groupBox1.Controls.Add(this.inNaI);
            this.groupBox1.Controls.Add(this.inCaF2);
            this.groupBox1.Controls.Add(this.inOrganicPlastic);
            this.groupBox1.Controls.Add(this.inOrganicLiquid);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dead Time (ns)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inHistoStartMeVee);
            this.groupBox2.Controls.Add(this.inHistoBinMeVee);
            this.groupBox2.Controls.Add(this.inHistoEndMeVee);
            this.groupBox2.Location = new System.Drawing.Point(6, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 111);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Histogram (MeVee)";
            // 
            // inOrganicLiquid
            // 
            this.inOrganicLiquid.DataIsInteger = true;
            this.inOrganicLiquid.Label = "Organic Liquid:";
            this.inOrganicLiquid.Location = new System.Drawing.Point(6, 16);
            this.inOrganicLiquid.Name = "inOrganicLiquid";
            this.inOrganicLiquid.Size = new System.Drawing.Size(210, 25);
            this.inOrganicLiquid.TabIndex = 1;
            // 
            // inOrganicPlastic
            // 
            this.inOrganicPlastic.DataIsInteger = true;
            this.inOrganicPlastic.Label = "Organic Plastic:";
            this.inOrganicPlastic.Location = new System.Drawing.Point(6, 47);
            this.inOrganicPlastic.Name = "inOrganicPlastic";
            this.inOrganicPlastic.Size = new System.Drawing.Size(210, 25);
            this.inOrganicPlastic.TabIndex = 2;
            // 
            // inCaF2
            // 
            this.inCaF2.DataIsInteger = true;
            this.inCaF2.Label = "CaF2:";
            this.inCaF2.Location = new System.Drawing.Point(6, 109);
            this.inCaF2.Name = "inCaF2";
            this.inCaF2.Size = new System.Drawing.Size(210, 25);
            this.inCaF2.TabIndex = 3;
            // 
            // inNaI
            // 
            this.inNaI.DataIsInteger = true;
            this.inNaI.Label = "NaI:";
            this.inNaI.Location = new System.Drawing.Point(6, 78);
            this.inNaI.Name = "inNaI";
            this.inNaI.Size = new System.Drawing.Size(210, 25);
            this.inNaI.TabIndex = 4;
            // 
            // inLaBr3
            // 
            this.inLaBr3.DataIsInteger = true;
            this.inLaBr3.Label = "LaBr3:";
            this.inLaBr3.Location = new System.Drawing.Point(6, 140);
            this.inLaBr3.Name = "inLaBr3";
            this.inLaBr3.Size = new System.Drawing.Size(210, 25);
            this.inLaBr3.TabIndex = 5;
            // 
            // inHistoEndMeVee
            // 
            this.inHistoEndMeVee.DataIsInteger = true;
            this.inHistoEndMeVee.Label = "End:";
            this.inHistoEndMeVee.Location = new System.Drawing.Point(6, 50);
            this.inHistoEndMeVee.Name = "inHistoEndMeVee";
            this.inHistoEndMeVee.Size = new System.Drawing.Size(210, 25);
            this.inHistoEndMeVee.TabIndex = 6;
            // 
            // inHistoBinMeVee
            // 
            this.inHistoBinMeVee.DataIsInteger = true;
            this.inHistoBinMeVee.Label = "Bin Step:";
            this.inHistoBinMeVee.Location = new System.Drawing.Point(6, 81);
            this.inHistoBinMeVee.Name = "inHistoBinMeVee";
            this.inHistoBinMeVee.Size = new System.Drawing.Size(210, 25);
            this.inHistoBinMeVee.TabIndex = 7;
            // 
            // inHistoStartMeVee
            // 
            this.inHistoStartMeVee.DataIsInteger = true;
            this.inHistoStartMeVee.Label = "Start:";
            this.inHistoStartMeVee.Location = new System.Drawing.Point(6, 19);
            this.inHistoStartMeVee.Name = "inHistoStartMeVee";
            this.inHistoStartMeVee.Size = new System.Drawing.Size(210, 25);
            this.inHistoStartMeVee.TabIndex = 8;
            // 
            // DeadTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DeadTime";
            this.Size = new System.Drawing.Size(238, 293);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputNumber inLaBr3;
        private InputNumber inNaI;
        private InputNumber inCaF2;
        private InputNumber inOrganicPlastic;
        private InputNumber inOrganicLiquid;
        private System.Windows.Forms.GroupBox groupBox2;
        private InputNumber inHistoStartMeVee;
        private InputNumber inHistoBinMeVee;
        private InputNumber inHistoEndMeVee;
    }
}
