using System;
using System.Windows.Forms;

namespace GuiWidgets.Waveform
{
    public partial class NoWaveWidget : UserControl, IWaveformWidget
    {
        public NoWaveWidget()
        {
            InitializeComponent();
        }

        public event EventHandler Recalculate;

        public void SetIsPileUp(bool isPileUp)
        {
            // do nothing
        }

        public void SetRejector(double scalar, double interval)
        {
            // do nothing
        }

        public double GetScalar()
        {
            return 0;
        }

        public double GetInterval()
        {
            return 0;
        }

        public void SetResults(double psd, double amplitude, string particle)
        {
            // do nothing
        }
    }
}
