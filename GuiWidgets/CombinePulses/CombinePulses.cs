using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.CombinePulses
{
    public partial class CombinePulses : UserControl
    {
        public event EventHandler CombinePulseFilesEvent;
        public event EventHandler PulseFilterCombine;
        public event EventHandler ApplyECal;

        public string SaveFile => saveFile;
        public List<string> PulseFiles => pulseFiles;
        public bool Filters => filters;
        public bool ECal => eCal;

        private string saveFile;
        private List<string> pulseFiles;
        private bool filters;
        private bool eCal;

        public CombinePulses()
        {
            InitializeComponent();
            SetupGrid();
            pulseFiles = new List<string>();
            filters = cbFilters.Checked;
            eCal = cbEcal.Checked;
            saveFile = string.Empty;
        }

        private void SetupGrid()
        {
            this.dgvFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.MultiSelect = true;
            this.dgvFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFiles.AllowUserToAddRows = false;

            this.dgvFiles.Columns.Add("PulseFile", "Pulse File");
        }

        private void UpdateDataGridView()
        {
            this.dgvFiles.Rows.Clear();
            int iRow = 0;
            this.dgvFiles.Rows.Clear();
            foreach (var f in pulseFiles)
            {
                this.dgvFiles.Rows.Add(new DataGridViewRow());
                this.dgvFiles.Rows[iRow].Cells[0].Value = System.IO.Path.GetFileName(f);
                iRow++;
            }
        }

        private void bAddFiles_Click(object sender, EventArgs e)
        {
            pulseFiles.AddRange(MultiplicityInterfaceHelper.GetFiles("Select Pulse Files"));
            UpdateDataGridView();
        }

        private void bSaveAs_Click(object sender, EventArgs e)
        {
            saveFile =
                MultiplicityInterfaceHelper.GetFile("Save Combined Pules As...", true, "flat-file(*.txt) | *.txt");
            OnCombinePulseFilesEvent();
        }

        private void cbFilters_CheckedChanged(object sender, EventArgs e)
        {
            filters = cbFilters.Checked;
            if (filters)
            {
                OnPulseFilterCombine();
            }
        }

        protected virtual void OnCombinePulseFilesEvent()
        {
            CombinePulseFilesEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPulseFilterCombine()
        {
            PulseFilterCombine?.Invoke(this, EventArgs.Empty);
        }

        private void cbEcal_CheckedChanged(object sender, EventArgs e)
        {
            eCal = cbEcal.Checked;
            if (eCal)
            {
                OnApplyECal();
            }
        }

        protected virtual void OnApplyECal()
        {
            ApplyECal?.Invoke(this, EventArgs.Empty);
        }
    }
}
