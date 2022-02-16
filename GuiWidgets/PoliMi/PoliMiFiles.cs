using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Multiplicity;

namespace GuiWidgets.PoliMi
{
    public partial class PoliMiFiles : UserControl
    {
        public event EventHandler EditPoliMiSpecs;

        private List<PulsesHelper.PoliMiSimulations> poliMi;
        private int selectedIndex;
        private int editingIndex;

        public PoliMiFiles()
        {
            InitializeComponent();
            poliMi = new List<PulsesHelper.PoliMiSimulations>();
            SetupGrid();
        }

        private void SetupGrid()
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;


            dataGridView1.Columns.Add("PoliMiFile", "PoliMi File");
            dataGridView1.Columns.Add("Activity", "Activity(Bqs)");
            dataGridView1.Columns.Add("NPS", "NPS");
        }

        public PulsesHelper.PoliMiSimulations GetEditingProblem()
        {
            return poliMi[editingIndex];
        }

        public void SetInitialProblems(List<PulsesHelper.PoliMiSimulations> PoliMiProblems)
        {
            poliMi = PoliMiProblems;
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            this.dataGridView1.Rows.Clear();
            int iRow = 0;
            this.dataGridView1.Rows.Clear();
            foreach (var r in poliMi)
            {
                this.dataGridView1.Rows.Add(new DataGridViewRow());
                this.dataGridView1.Rows[iRow].Cells[0].Value = r.PulseFile.ToString();
                this.dataGridView1.Rows[iRow].Cells[1].Value = r.ActivityBqs.ToString();
                this.dataGridView1.Rows[iRow].Cells[2].Value = r.McnpNPS.ToString();

                iRow++;
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            EditExistingPoliMi();
        }

        private void UpdateSelectedIndex()
        {
            selectedIndex = this.dataGridView1.SelectedRows[0].Index;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            DeletePoliMi();
        }

        private void DeletePoliMi()
        {
            UpdateSelectedIndex();
            try
            {
                poliMi.RemoveAt(selectedIndex);
                UpdateDataGridView();
            }
            catch
            {
                //likely no row selected
            }
        }

        private void EditExistingPoliMi()
        {
            if (selectedIndex >= 0 && poliMi.Count > 0)
            {
                editingIndex = selectedIndex;
                HandleEdit(EventArgs.Empty);
            }

            UpdateDataGridView();
        }

        protected virtual void HandleEdit(EventArgs e)
        {
            EventHandler handler = this.EditPoliMiSpecs;
            handler?.Invoke(this, e);
        }

        public List<PulsesHelper.PoliMiSimulations> GetProblems()
        {
            return poliMi;
        }

        public void AddNew(PulsesHelper.PoliMiSimulations newPoliMi)
        {
            poliMi.Add(newPoliMi);
            UpdateCountTime();
            UpdateDataGridView();
        }

        private void UpdateCountTime()
        {
            this.tbDwellTime.Text = PulsesHelper
                .ConvertNanoSecondsToSeconds(PulsesHelper.GetCountTimePoliMiNanoSec(poliMi)).ToString();
        }

        public void Edited(PulsesHelper.PoliMiSimulations editedPoliMi)
        {
            poliMi[editingIndex] = editedPoliMi;
            UpdateCountTime();
            UpdateDataGridView();
        }
    }
}
