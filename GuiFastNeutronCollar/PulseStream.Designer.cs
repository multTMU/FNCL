﻿namespace GuiFastNeutronCollar
{
    partial class PulseStream
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PulseStream));
            this.pulseStreamViewer1 = new GuiWidgets.PulseStream.PulseStreamViewer();
            this.uniPanel1 = new GuiWidgets.UniPanel();
            this.SuspendLayout();
            // 
            // pulseStreamViewer1
            // 
            this.pulseStreamViewer1.Location = new System.Drawing.Point(12, 12);
            this.pulseStreamViewer1.Name = "pulseStreamViewer1";
            this.pulseStreamViewer1.Size = new System.Drawing.Size(604, 313);
            this.pulseStreamViewer1.TabIndex = 1;
            // 
            // uniPanel1
            // 
            this.uniPanel1.Location = new System.Drawing.Point(-16, -6);
            this.uniPanel1.Name = "uniPanel1";
            this.uniPanel1.Size = new System.Drawing.Size(658, 438);
            this.uniPanel1.TabIndex = 0;
            // 
            // PulseStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 326);
            this.Controls.Add(this.pulseStreamViewer1);
            this.Controls.Add(this.uniPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(645, 365);
            this.MinimumSize = new System.Drawing.Size(645, 365);
            this.Name = "PulseStream";
            this.Text = "Pulse Stream";
            this.ResumeLayout(false);

        }

        #endregion
        private GuiWidgets.PulseStream.PulseStreamViewer pulseStreamViewer1;
        private GuiWidgets.UniPanel uniPanel1;
    }
}