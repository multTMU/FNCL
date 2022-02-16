using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuiWidgets.PileUpRejector
{
    public partial class PileUpWaveform : UserControl, IWaveformWidget
    {
        public event EventHandler Recalculate;

        public PileUpWaveform()
        {
            InitializeComponent();
            this.inRejected.SetReadonly();
        }

        public void SetIsPileUp(bool isPileUp)
        {
            this.inRejected.SetValueRaiseNoEvent(GetPiledUpString(isPileUp));
        }

        private string GetPiledUpString(bool isPileUp)
        {
            if (isPileUp)
            {
                this.inRejected.BackColor = Color.Red;
                return "Pile Up";
            }

            this.inRejected.BackColor = Color.Green;
            return "NOT Pile Up";
        }

        public void SetRejector(double scalar, double interval)
        {
            this.pileUpFilter1.Scalar = scalar;
            this.pileUpFilter1.Interval = interval;
        }

        public double GetScalar()
        {
            return this.pileUpFilter1.Scalar;
        }

        public double GetInterval()
        {
            return this.pileUpFilter1.Interval;
        }

        public void SetResults(double psd, double amplitude, string particle)
        {
            // do nothing
        }

        private void bRecalc_Click(object sender, EventArgs e)
        {
            OnRecalculate();
        }

        protected virtual void OnRecalculate()
        {
            Recalculate?.Invoke(this, EventArgs.Empty);
        }
    }
}
