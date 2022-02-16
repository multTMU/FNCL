using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GlobalHelpers;

namespace GuiWidgets.FnclModels
{
    public partial class ProblemRunner : UserControl
    {
        public event EventHandler RunCurrentModels;
        private List<SimulationSpecification> simSpec;
        private int selectedProblem;

        public ProblemRunner()
        {
            InitializeComponent();
            simSpec = new List<SimulationSpecification>();
            SetUpGrid();
        }

        private void SetUpGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("ProblemDirectory", "Problem Directory");
        }

        public List<SimulationSpecification> GetSimulationsToRun()
        {
            return simSpec;
        }

        public void RefreshList()
        {
            simSpec = new List<SimulationSpecification>();
            UpdateDataGridView();
        }


        private void UpdateDataGridView()
        {
            int iRow = 0;
            this.dataGridView1.Rows.Clear();
            foreach (var s in simSpec)
            {
                this.dataGridView1.Rows.Add(new DataGridViewRow());
                this.dataGridView1.Rows[iRow].Cells[0].Value = Path.GetFileName(s.McnpInputDirectory);
                iRow++;
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            try
            {
                simSpec.RemoveAt(selectedProblem);
            }
            catch
            {
            }

            UpdateDataGridView();
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            OnRunCurrentModels();
        }

        protected virtual void OnRunCurrentModels()
        {
            RunCurrentModels?.Invoke(this, EventArgs.Empty);
        }

        public void AddProblem(SimulationSpecification simulationSpecification)
        {
            simSpec.Add(simulationSpecification);
            UpdateDataGridView();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                selectedProblem = this.dataGridView1.SelectedRows[0].Index;
            }
        }
    }
}
