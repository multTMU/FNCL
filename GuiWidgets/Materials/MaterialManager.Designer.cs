namespace GuiWidgets.Materials
{
    partial class MaterialManager
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
            this.bAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtSpecs = new System.Windows.Forms.RichTextBox();
            this.inDensity = new GuiWidgets.InputNumber();
            this.inIndex = new GuiWidgets.InputNumber();
            this.inComment = new GuiWidgets.InputString();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtSpecs);
            this.groupBox1.Controls.Add(this.inDensity);
            this.groupBox1.Controls.Add(this.inIndex);
            this.groupBox1.Controls.Add(this.inComment);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material Manager";
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(145, 312);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Specification:";
            // 
            // rtSpecs
            // 
            this.rtSpecs.Location = new System.Drawing.Point(6, 125);
            this.rtSpecs.Name = "rtSpecs";
            this.rtSpecs.Size = new System.Drawing.Size(210, 181);
            this.rtSpecs.TabIndex = 3;
            this.rtSpecs.Text = "";
            // 
            // inDensity
            // 
            this.inDensity.DataIsInteger = true;
            this.inDensity.Label = "Density:";
            this.inDensity.Location = new System.Drawing.Point(0, 81);
            this.inDensity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inDensity.Name = "inDensity";
            this.inDensity.Size = new System.Drawing.Size(210, 25);
            this.inDensity.TabIndex = 2;
            // 
            // inIndex
            // 
            this.inIndex.DataIsInteger = true;
            this.inIndex.Label = "Index:";
            this.inIndex.Location = new System.Drawing.Point(0, 50);
            this.inIndex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inIndex.Name = "inIndex";
            this.inIndex.Size = new System.Drawing.Size(210, 25);
            this.inIndex.TabIndex = 1;
            // 
            // inComment
            // 
            this.inComment.Label = "Name:";
            this.inComment.Location = new System.Drawing.Point(0, 19);
            this.inComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inComment.Name = "inComment";
            this.inComment.Size = new System.Drawing.Size(210, 25);
            this.inComment.TabIndex = 0;
            // 
            // MaterialManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MaterialManager";
            this.Size = new System.Drawing.Size(235, 347);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private InputString inComment;
        private InputNumber inDensity;
        private InputNumber inIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtSpecs;
        private System.Windows.Forms.Button bAdd;
    }
}
