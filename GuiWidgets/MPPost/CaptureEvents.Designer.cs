using GlobalHelpersDefaults;

namespace GuiWidgets.MPPost
{
    partial class CaptureEvents
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
            this.inPrintSortedEvent = new GuiWidgets.InputBoolean();
            this.inParticle = new GuiWidgets.InputEnum();
            this.inSortMaterial = new GuiWidgets.InputNumber();
            this.inSortInteraction = new GuiWidgets.InputNumber();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inSortInteraction);
            this.groupBox1.Controls.Add(this.inSortMaterial);
            this.groupBox1.Controls.Add(this.inParticle);
            this.groupBox1.Controls.Add(this.inPrintSortedEvent);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Capture Events";
            // 
            // inPrintSortedEvent
            // 
            this.inPrintSortedEvent.Label = "Print Sorted Event File:";
            this.inPrintSortedEvent.Location = new System.Drawing.Point(6, 19);
            this.inPrintSortedEvent.Name = "inPrintSortedEvent";
            this.inPrintSortedEvent.Size = new System.Drawing.Size(210, 25);
            this.inPrintSortedEvent.TabIndex = 0;
            // 
            // inParticle
            // 
            this.inParticle.Label = "Sort Particle:";
            this.inParticle.Location = new System.Drawing.Point(6, 50);
            this.inParticle.Name = "inParticle";
            this.inParticle.Size = new System.Drawing.Size(210, 25);
            this.inParticle.TabIndex = 1;
            // 
            // inSortMaterial
            // 
            this.inSortMaterial.DataIsInteger = true;
            this.inSortMaterial.Label = "Sort Material:";
            this.inSortMaterial.Location = new System.Drawing.Point(6, 81);
            this.inSortMaterial.Name = "inSortMaterial";
            this.inSortMaterial.Size = new System.Drawing.Size(210, 25);
            this.inSortMaterial.TabIndex = 2;
            // 
            // inSortInteraction
            // 
            this.inSortInteraction.DataIsInteger = true;
            this.inSortInteraction.Label = "Sort Interaction:";
            this.inSortInteraction.Location = new System.Drawing.Point(6, 112);
            this.inSortInteraction.Name = "inSortInteraction";
            this.inSortInteraction.Size = new System.Drawing.Size(210, 25);
            this.inSortInteraction.TabIndex = 3;
            // 
            // CaptureEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CaptureEvents";
            this.Size = new System.Drawing.Size(226, 150);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputBoolean inPrintSortedEvent;
        private InputEnum inParticle;
        private InputNumber inSortInteraction;
        private InputNumber inSortMaterial;
    }
}
