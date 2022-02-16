using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpers;

namespace GuiWidgets.Materials
{
    public partial class MaterialViewer : UserControl
    {
        public event EventHandler ApplySelected;

        private readonly Dictionary<int, MaterialElement> materials;
        private int selectedKey;

        public MaterialViewer()
        {
            InitializeComponent();
            SetUpGrid();
            materials = GlobalHelpers.MaterialManager.GetClone();
            selectedKey = 0;
            UpdateDataGridView();
        }

        public int GetMaterialKey()
        {
            try
            {
                return materials[selectedKey].MaterialIndex;
            }
            catch
            {
                return GlobalHelpers.MaterialManager.VOID;
            }
        }

        private void SetUpGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("MaterialKey", "Index");
            dataGridView1.Columns.Add("Density", "Density");
            // dataGridView1.Columns.Add("Specification", "Specification");
            dataGridView1.Columns.Add("Description", "Description");
        }

        private void UpdateDataGridView()
        {
            int iRow = 0;
            this.dataGridView1.Rows.Clear();
            foreach (var m in materials)
            {
                this.dataGridView1.Rows.Add(new DataGridViewRow());
                this.dataGridView1.Rows[iRow].Cells[0].Value = m.Value.MaterialIndex;
                this.dataGridView1.Rows[iRow].Cells[1].Value = m.Value.Density;
                this.dataGridView1.Rows[iRow].Cells[2].Value = m.Value.Comment;

                iRow++;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectedKey = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            PopulateTextBox();
        }

        private void PopulateTextBox()
        {
            this.richTextBox1.Lines = materials[selectedKey].Specification.ToArray();
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            HandleApply();
        }

        protected virtual void HandleApply()
        {
            EventHandler handler = this.ApplySelected;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeApplyLabel(string buttonText)
        {
            this.bApply.Text = buttonText;
        }

        public void ChangeGroupBoxLabel(string groupBoxText)
        {
            this.groupBox1.Text = groupBoxText;
        }
    }
}
