using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class PulseAmplitude : Form
    {
        public event EventHandler SendNewPadPlot;

        public PulseAmplitude()
        {
            InitializeComponent();
            this.pulseAmpPlotter1.PadAmplitudeChanged += AmplitudeTypeChanged;
        }

        private void AxisTypeChanged(object sender, EventArgs e)
        {
            OnSendNewPadPlot();
        }

        private void AmplitudeTypeChanged(object sender, EventArgs e)
        {
            OnSendNewPadPlot();
        }

        public PulseAmplitudeType GetAmplitudeType()
        {
            return pulseAmpPlotter1.GetAmplitudeType();
        }

        public void Plot(List<double> padPlot)
        {
            pulseAmpPlotter1.Plot(padPlot);
        }

        protected virtual void OnSendNewPadPlot()
        {
            SendNewPadPlot?.Invoke(this, EventArgs.Empty);
        }
    }
}
