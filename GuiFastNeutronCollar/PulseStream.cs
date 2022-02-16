using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiFastNeutronCollar
{
    public partial class PulseStream : Form
    {
        public PulseStream()
        {
            InitializeComponent();
        }

        public void ReplotPulses(List<double> pulseStream)
        {
            this.pulseStreamViewer1.Replot(pulseStream);
        }
    }
}
