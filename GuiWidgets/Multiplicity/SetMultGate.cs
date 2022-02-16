using System.Windows.Forms;

namespace GuiWidgets
{
    public partial class SetShiftRegister : UserControl
    {
        public int Gate => (int)inGate.Value;

        public int PreDelay => (int)inPreDelay.Value;

        public int LongDelay => (int)inLongDelay.Value;

        public SetShiftRegister()
        {
            InitializeComponent();
            inGate.DataIsInteger = false;
            inPreDelay.DataIsInteger = false;
            inLongDelay.DataIsInteger = false;

            inGate.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inPreDelay.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inLongDelay.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public void SetNewTitle(string title)
        {
            groupBox1.Text = title;
        }

        public void ConfigureAsShiftRegister(bool isShift)
        {
            inGate.Enabled = true;
            inPreDelay.Enabled = isShift;
            inLongDelay.Enabled = isShift;
        }

        public void SetDefaults(double Gate, double PreDelay, double LongDelay)
        {
            inGate.SetValueRaiseNoEvent(Gate);
            inPreDelay.SetValueRaiseNoEvent(PreDelay);
            inLongDelay.SetValueRaiseNoEvent(LongDelay);
        }
    }
}
