using System;
using System.Windows.Forms;

namespace GuiWidgets.PulseShapeDisc
{
    public partial class PsdWaveformResults : UserControl, IWaveformWidget
    {
        public event EventHandler Recalculate;

        public PsdWaveformResults()
        {
            InitializeComponent();
            inAmplitude.SetReadonly();
            inPSD.SetReadonly();
            inParticle.SetReadonly();
        }

        public void SetResults(double psd, double amplitude, string particle)
        {
            inAmplitude.SetValueRaiseNoEvent(amplitude);
            inPSD.SetValueRaiseNoEvent(psd);
            inParticle.SetValueRaiseNoEvent(particle);
        }

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
    }
}
