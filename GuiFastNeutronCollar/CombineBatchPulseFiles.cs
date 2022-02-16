using System;
using System.Windows.Forms;

namespace GuiFastNeutronCollar
{
    public partial class CombineBatchPulseFiles : Form
    {
        public event EventHandler RunBatchCombinePulsesToFlat;
        public double CountTimeSec => batchCombinePulses1.CountTimeSec;
        public double MaxFileSizeMB => batchCombinePulses1.MaxFileSizeMB;
        public string FilePrefix => batchCombinePulses1.FilePrefix;
        public bool ApplyFilters => batchCombinePulses1.ApplyFilters;
        public bool CombineActive => batchCombinePulses1.CombineActive;
        public bool CombinePassive => batchCombinePulses1.CombinePassive;

        public CombineBatchPulseFiles()
        {
            InitializeComponent();
            this.batchCombinePulses1.RunBatchPulseCombine += RunBatchCombine;
        }

        private void RunBatchCombine(object sender, EventArgs e)
        {
            OnRunBatchCombinePulsesToFlat();
        }

        protected virtual void OnRunBatchCombinePulsesToFlat()
        {
            RunBatchCombinePulsesToFlat?.Invoke(this, EventArgs.Empty);
        }
    }
}
