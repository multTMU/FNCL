namespace GuiWidgets.FilterOrder
{
    partial class FilterOrdering
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
            this.gbFilterOrder = new System.Windows.Forms.GroupBox();
            this.bDown = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bRemove = new System.Windows.Forms.Button();
            this.bRestore = new System.Windows.Forms.Button();
            this.bRestoreAll = new System.Windows.Forms.Button();
            this.bRemoveAll = new System.Windows.Forms.Button();
            this.gbFilterOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilterOrder
            // 
            this.gbFilterOrder.Controls.Add(this.bRestore);
            this.gbFilterOrder.Controls.Add(this.bRemove);
            this.gbFilterOrder.Controls.Add(this.bDown);
            this.gbFilterOrder.Controls.Add(this.bUp);
            this.gbFilterOrder.Controls.Add(this.dataGridView1);
            this.gbFilterOrder.Controls.Add(this.groupBox1);
            this.gbFilterOrder.Location = new System.Drawing.Point(3, 3);
            this.gbFilterOrder.Name = "gbFilterOrder";
            this.gbFilterOrder.Size = new System.Drawing.Size(207, 260);
            this.gbFilterOrder.TabIndex = 0;
            this.gbFilterOrder.TabStop = false;
            this.gbFilterOrder.Text = "Filter Order";
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(139, 48);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(62, 23);
            this.bDown.TabIndex = 2;
            this.bDown.Text = "Down";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(139, 19);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(62, 23);
            this.bUp.TabIndex = 1;
            this.bUp.Text = "Up";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(127, 235);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bRestoreAll);
            this.groupBox1.Controls.Add(this.bRemoveAll);
            this.groupBox1.Location = new System.Drawing.Point(131, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(79, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All";
            // 
            // bRemove
            // 
            this.bRemove.Location = new System.Drawing.Point(139, 97);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(62, 23);
            this.bRemove.TabIndex = 3;
            this.bRemove.Text = "Ignore";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bRestore
            // 
            this.bRestore.Location = new System.Drawing.Point(139, 126);
            this.bRestore.Name = "bRestore";
            this.bRestore.Size = new System.Drawing.Size(62, 23);
            this.bRestore.TabIndex = 4;
            this.bRestore.Text = "Apply";
            this.bRestore.UseVisualStyleBackColor = true;
            this.bRestore.Click += new System.EventHandler(this.bRestore_Click);
            // 
            // bRestoreAll
            // 
            this.bRestoreAll.Location = new System.Drawing.Point(8, 48);
            this.bRestoreAll.Name = "bRestoreAll";
            this.bRestoreAll.Size = new System.Drawing.Size(62, 23);
            this.bRestoreAll.TabIndex = 6;
            this.bRestoreAll.Text = "Apply";
            this.bRestoreAll.UseVisualStyleBackColor = true;
            this.bRestoreAll.Click += new System.EventHandler(this.bRestoreAll_Click);
            // 
            // bRemoveAll
            // 
            this.bRemoveAll.Location = new System.Drawing.Point(8, 19);
            this.bRemoveAll.Name = "bRemoveAll";
            this.bRemoveAll.Size = new System.Drawing.Size(62, 23);
            this.bRemoveAll.TabIndex = 5;
            this.bRemoveAll.Text = "Ignore";
            this.bRemoveAll.UseVisualStyleBackColor = true;
            this.bRemoveAll.Click += new System.EventHandler(this.bRemoveAll_Click);
            // 
            // FilterOrdering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilterOrder);
            this.Name = "FilterOrdering";
            this.Size = new System.Drawing.Size(216, 265);
            this.gbFilterOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilterOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bRestore;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRestoreAll;
        private System.Windows.Forms.Button bRemoveAll;
    }
}
