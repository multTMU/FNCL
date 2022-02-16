using System.Windows.Forms;

namespace GuiWidgets.CorrelatedPulseSelector
{
    public partial class CorrelatedPulsesFilter : UserControl
    {
        public int MaxTimeInterval => (int)inTimeInterval.Value;

        public CorrelatedPulsesFilter()
        {
            InitializeComponent();
            inTimeInterval.DataIsInteger = true;
            this.inTimeInterval.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        public void SetDefault(int timeInterval)
        {
            inTimeInterval.SetValueRaiseNoEvent(timeInterval);
        }
    }
}
