using System.Windows.Forms;

namespace GuiWidgets.FilterPulses
{
    public partial class FlatTopPulseFilter : UserControl
    {
        public double PeakMaxTolerancePercent => inPeakMaxTolerance.GetValue();
        public double Duration => inFlatTopDuration.GetValue();

        public FlatTopPulseFilter()
        {
            InitializeComponent();
            this.inFlatTopDuration.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        public void SetDefaults(double flatTopDuration, double peakMaxTolerance)
        {
            inFlatTopDuration.SetValueRaiseNoEvent(flatTopDuration);
            inPeakMaxTolerance.SetValueRaiseNoEvent(peakMaxTolerance);
        }

        public void EnableFlatTop(bool state)
        {
            inFlatTopDuration.Enabled = state;
            inPeakMaxTolerance.Enabled = state;
        }
    }
}
