using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiFastNeutronCollar
{
    public partial class PulseWaveFormViewer : Form
    {
        public event EventHandler PulseIndexChanged;

        public PulseWaveFormViewer()
        {
            InitializeComponent();
            waveFormViewer1.PulseIndexChanged += UpdatePulseIndex;
        }

        private void UpdatePulseIndex(object sender, EventArgs e)
        {
            OnPulseIndexChanged();
        }

        public void SetNumberOfPulses(int nPulses)
        {
            waveFormViewer1.SetNumberOfPulses(nPulses);
        }

        public void SetTimeStep(int timeStep)
        {
            waveFormViewer1.SetTimeStep(timeStep);
        }

        public int GetPulseIndex()
        {
            return waveFormViewer1.PulseIndex;
        }

        public void SetPulseWaveForm(List<int> pulseWaveform)
        {
            waveFormViewer1.SetPulseWaveForm(pulseWaveform);
        }

        public void ConfigureForPSD()
        {
            waveFormViewer1.ConfigureForPSD();
        }

        public void ConfigureForPileUp()
        {
            waveFormViewer1.ConfigureForPileUp();
        }

        public void SetPsdPulseWaveForm(PsdWaveformGui psdPulseWaveform)
        {
            waveFormViewer1.PlotPsdWaveform(psdPulseWaveform);
        }

        public double GetPileUpScalar()
        {
            return waveFormViewer1.GetPileUpScalar();
        }

        public double GetPileUpInterval()
        {
            return waveFormViewer1.GetPileUpInterval();
        }

        public void SetPileUpDefaults(double interval, double scalar)
        {
            waveFormViewer1.SetRejector(scalar, interval);
        }

        public void SetIsPileUp(bool isPileUp)
        {
            waveFormViewer1.SesIsPileUp(isPileUp);
        }

        protected virtual void OnPulseIndexChanged()
        {
            PulseIndexChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
