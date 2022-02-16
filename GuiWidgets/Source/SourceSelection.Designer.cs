namespace GuiWidgets.Source
{
    partial class SourceSelection
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
            this.sourceSelector1 = new GuiWidgets.SourceSelector();
            this.pickPoliMiSource1 = new GuiWidgets.Source.PickPoliMiSource();
            this.pSource = new GuiWidgets.UniPanel();
            this.inMaterial = new GuiWidgets.InputNumber();
            this.SuspendLayout();
            // 
            // sourceSelector1
            // 
            this.sourceSelector1.Location = new System.Drawing.Point(3, 3);
            this.sourceSelector1.Name = "sourceSelector1";
            this.sourceSelector1.Size = new System.Drawing.Size(356, 70);
            this.sourceSelector1.TabIndex = 0;
            // 
            // pickPoliMiSource1
            // 
            this.pickPoliMiSource1.Location = new System.Drawing.Point(365, 0);
            this.pickPoliMiSource1.Name = "pickPoliMiSource1";
            this.pickPoliMiSource1.Size = new System.Drawing.Size(139, 52);
            this.pickPoliMiSource1.TabIndex = 1;
            // 
            // pSource
            // 
            this.pSource.Location = new System.Drawing.Point(3, 79);
            this.pSource.Name = "pSource";
            this.pSource.Size = new System.Drawing.Size(649, 212);
            this.pSource.TabIndex = 2;
            // 
            // inMaterial
            // 
            this.inMaterial.DataIsInteger = true;
            this.inMaterial.Label = "Material:";
            this.inMaterial.Location = new System.Drawing.Point(511, 19);
            this.inMaterial.Name = "inMaterial";
            this.inMaterial.Size = new System.Drawing.Size(141, 25);
            this.inMaterial.TabIndex = 3;
            // 
            // SourceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inMaterial);
            this.Controls.Add(this.pSource);
            this.Controls.Add(this.pickPoliMiSource1);
            this.Controls.Add(this.sourceSelector1);
            this.Name = "SourceSelection";
            this.Size = new System.Drawing.Size(654, 296);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceSelector sourceSelector1;
        private PickPoliMiSource pickPoliMiSource1;
        private UniPanel pSource;
        private InputNumber inMaterial;
    }
}
