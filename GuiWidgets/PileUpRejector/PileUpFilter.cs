using System.Windows.Forms;

namespace GuiWidgets.PileUpRejector
{
    public partial class PileUpFilter : UserControl
    {
        public double Scalar
        {
            get => inScalar.GetValue();
            set => inScalar.SetValueRaiseNoEvent(value);
        }

        public double Interval
        {
            get => inInterval.GetValue();
            set => inInterval.SetValueRaiseNoEvent(value);
        }

        public PileUpFilter()
        {
            InitializeComponent();
            inInterval.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public void SetDefault(double pileUpInterval, double pileUpScalar)
        {
            Scalar = pileUpScalar;
            Interval = pileUpInterval;
        }
    }
}
