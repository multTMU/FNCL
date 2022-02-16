using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiWidgets.PulseStream
{
    public partial class PulseStreamViewer : UserControl
    {
        public PulseStreamViewer()
        {
            InitializeComponent();
            this.histogramPlotter1.SetXaxisTitle("Pulse Time (ns)");
            this.histogramPlotter1.SetYaxisTitle("Number of Pulses");
        }


        public void Replot(List<double> pulseStream)
        {
            this.histogramPlotter1.MakeHistogramToPlot(pulseStream);
        }
    }
}
