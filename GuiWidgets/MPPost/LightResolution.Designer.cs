namespace GuiWidgets.MPPost
{
    partial class LightResolution
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
            this.inOrganicLiquidNeutron = new GuiWidgets.MPPost.InGaussianBroadening();
            this.inOrganicLiquidPhoton = new GuiWidgets.MPPost.InGaussianBroadening();
            this.inEnableLightResolution = new GuiWidgets.InputBoolean();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inOrganicPlasticPhoton = new GuiWidgets.MPPost.InGaussianBroadening();
            this.inOrganicPlasticNeutron = new GuiWidgets.MPPost.InGaussianBroadening();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.inLaBr3BelowTenthMeVee = new GuiWidgets.MPPost.InGaussianBroadening();
            this.inLaBr3AboveTenthMeVee = new GuiWidgets.MPPost.InGaussianBroadening();
            this.inNaI = new GuiWidgets.MPPost.InGaussianBroadening();
            this.inCaF2 = new GuiWidgets.MPPost.InGaussianBroadening();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inCaF2);
            this.groupBox1.Controls.Add(this.inNaI);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.inEnableLightResolution);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(965, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light Resolution";
            // 
            // inOrganicLiquidNeutron
            // 
            this.inOrganicLiquidNeutron.LabelForEnable = "Neutron:";
            this.inOrganicLiquidNeutron.Location = new System.Drawing.Point(6, 186);
            this.inOrganicLiquidNeutron.Name = "inOrganicLiquidNeutron";
            this.inOrganicLiquidNeutron.Size = new System.Drawing.Size(226, 161);
            this.inOrganicLiquidNeutron.TabIndex = 2;
            // 
            // inOrganicLiquidPhoton
            // 
            this.inOrganicLiquidPhoton.LabelForEnable = "Photon:";
            this.inOrganicLiquidPhoton.Location = new System.Drawing.Point(6, 19);
            this.inOrganicLiquidPhoton.Name = "inOrganicLiquidPhoton";
            this.inOrganicLiquidPhoton.Size = new System.Drawing.Size(226, 161);
            this.inOrganicLiquidPhoton.TabIndex = 1;
            // 
            // inEnableLightResolution
            // 
            this.inEnableLightResolution.Label = "Light Resolution:";
            this.inEnableLightResolution.Location = new System.Drawing.Point(6, 19);
            this.inEnableLightResolution.Name = "inEnableLightResolution";
            this.inEnableLightResolution.Size = new System.Drawing.Size(210, 25);
            this.inEnableLightResolution.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inOrganicLiquidPhoton);
            this.groupBox2.Controls.Add(this.inOrganicLiquidNeutron);
            this.groupBox2.Location = new System.Drawing.Point(6, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 353);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Organic Liquid";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inOrganicPlasticPhoton);
            this.groupBox3.Controls.Add(this.inOrganicPlasticNeutron);
            this.groupBox3.Location = new System.Drawing.Point(249, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 353);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Organic Plastic";
            // 
            // inOrganicPlasticPhoton
            // 
            this.inOrganicPlasticPhoton.LabelForEnable = "Photon:";
            this.inOrganicPlasticPhoton.Location = new System.Drawing.Point(6, 19);
            this.inOrganicPlasticPhoton.Name = "inOrganicPlasticPhoton";
            this.inOrganicPlasticPhoton.Size = new System.Drawing.Size(226, 161);
            this.inOrganicPlasticPhoton.TabIndex = 1;
            // 
            // inOrganicPlasticNeutron
            // 
            this.inOrganicPlasticNeutron.LabelForEnable = "Neutron:";
            this.inOrganicPlasticNeutron.Location = new System.Drawing.Point(6, 186);
            this.inOrganicPlasticNeutron.Name = "inOrganicPlasticNeutron";
            this.inOrganicPlasticNeutron.Size = new System.Drawing.Size(226, 161);
            this.inOrganicPlasticNeutron.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.inLaBr3BelowTenthMeVee);
            this.groupBox4.Controls.Add(this.inLaBr3AboveTenthMeVee);
            this.groupBox4.Location = new System.Drawing.Point(492, 50);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 353);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LaBr3";
            // 
            // inLaBr3SubTenthMeVee
            // 
            this.inLaBr3BelowTenthMeVee.LabelForEnable = "Below 0.1 MeVee:";
            this.inLaBr3BelowTenthMeVee.Location = new System.Drawing.Point(6, 19);
            this.inLaBr3BelowTenthMeVee.Name = "inLaBr3BelowTenthMeVee";
            this.inLaBr3BelowTenthMeVee.Size = new System.Drawing.Size(226, 161);
            this.inLaBr3BelowTenthMeVee.TabIndex = 1;
            // 
            // inLaBr3SupTenthMeVee
            // 
            this.inLaBr3AboveTenthMeVee.LabelForEnable = "Above 0.1 MeVee:";
            this.inLaBr3AboveTenthMeVee.Location = new System.Drawing.Point(6, 186);
            this.inLaBr3AboveTenthMeVee.Name = "inLaBr3AboveTenthMeVee";
            this.inLaBr3AboveTenthMeVee.Size = new System.Drawing.Size(226, 161);
            this.inLaBr3AboveTenthMeVee.TabIndex = 2;
            // 
            // inNaI
            // 
            this.inNaI.LabelForEnable = "NaI:";
            this.inNaI.Location = new System.Drawing.Point(735, 69);
            this.inNaI.Name = "inNaI";
            this.inNaI.Size = new System.Drawing.Size(226, 161);
            this.inNaI.TabIndex = 6;
            // 
            // inCaF2
            // 
            this.inCaF2.LabelForEnable = "CaF2:";
            this.inCaF2.Location = new System.Drawing.Point(735, 236);
            this.inCaF2.Name = "inCaF2";
            this.inCaF2.Size = new System.Drawing.Size(226, 161);
            this.inCaF2.TabIndex = 7;
            // 
            // LightResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "LightResolution";
            this.Size = new System.Drawing.Size(977, 418);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputBoolean inEnableLightResolution;
        private InGaussianBroadening inOrganicLiquidNeutron;
        private InGaussianBroadening inOrganicLiquidPhoton;
        private InGaussianBroadening inCaF2;
        private InGaussianBroadening inNaI;
        private System.Windows.Forms.GroupBox groupBox4;
        private InGaussianBroadening inLaBr3BelowTenthMeVee;
        private InGaussianBroadening inLaBr3AboveTenthMeVee;
        private System.Windows.Forms.GroupBox groupBox3;
        private InGaussianBroadening inOrganicPlasticPhoton;
        private InGaussianBroadening inOrganicPlasticNeutron;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
