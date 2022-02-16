using System;
using System.Windows.Forms;

namespace GuiWidgets.CombinePulses
{
    public partial class BatchCombinePulses : UserControl
    {
        public event EventHandler RunBatchPulseCombine;
        public double CountTimeSec => inCountTime.Value;
        public double MaxFileSizeMB => inMaxSizeMB.Value;
        public string FilePrefix => inFilePrefix.Value;
        public bool ApplyFilters => inApplyFilters.Value;
        public bool CombineActive => cbActive.Checked;
        public bool CombinePassive => cbPassisve.Checked;

        public BatchCombinePulses()
        {
            InitializeComponent();
            cbActive.Checked = true;
            cbPassisve.Checked = true;
        }

        protected virtual void OnRunBatchPulseCombine()
        {
            RunBatchPulseCombine?.Invoke(this, EventArgs.Empty);
        }

        private void TryRun()
        {
            if (formComplete())
            {
                OnRunBatchPulseCombine();
            }
        }

        private bool formComplete()
        {
            bool validCountTime = (inCountTime.Value > 0);
            bool validFileSize = (inMaxSizeMB.Value > 0);
            bool validPrefix = !string.IsNullOrEmpty(inFilePrefix.Value);
            bool validPassiveOrActive = cbPassisve.Checked || cbActive.Checked;

            return validPrefix && validCountTime && validFileSize && validPassiveOrActive;
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            TryRun();
        }
    }
}
