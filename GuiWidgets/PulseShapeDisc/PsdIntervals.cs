using System;
using System.Windows.Forms;

namespace GuiWidgets.PulseShapeDisc
{
    public partial class PsdIntervals : UserControl
    {
        public int PSDfast { get; private set; }
        public int PSDslow { get; private set; }
        public double AmplitudeScalar { get; private set; }

        public PsdIntervals()
        {
            InitializeComponent();
            SetInputDataType();
            SetUpEvents();
            inPsdFast.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
            inPsdSlow.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        private void SetUpEvents()
        {
            inPsdFast.NumberUpdated += UpdatePSDfastEvent;
            inPsdSlow.NumberUpdated += UpdatePsdSlowEvent;
            inPsdAmpScalar.NumberUpdated += UpdatePsdRangeEvent;
        }

        private void SetInputDataType()
        {
            inPsdSlow.DataIsInteger = true;
            inPsdAmpScalar.DataIsInteger = false;
            inPsdFast.DataIsInteger = true;
        }

        private void UpdatePsdRangeEvent(object sender, EventArgs e)
        {
            UpdateAmplitudeScalar(inPsdAmpScalar.Value);
        }

        private void UpdatePsdSlowEvent(object sender, EventArgs e)
        {
            UpdatePSDslow((int)inPsdSlow.Value);
        }

        private void UpdatePSDfastEvent(object sender, EventArgs e)
        {
            UpdatePSDfast((int)inPsdFast.Value);
        }

        public void SetPSDslow(int newPSDslow)
        {
            UpdatePSDslow(newPSDslow);
        }

        public void SetPSDfast(int newPSDfast)
        {
            UpdatePSDfast(newPSDfast);
        }

        public void SetAmplitudeScalar(double newAmpScalar)
        {
            UpdateAmplitudeScalar(newAmpScalar);
        }

        private void UpdatePSDfast(int newValue)
        {
            PSDfast = newValue;
            inPsdFast.SetValueRaiseNoEvent(PSDfast);
        }

        private void UpdateAmplitudeScalar(double newValue)
        {
            AmplitudeScalar = newValue;
            inPsdAmpScalar.SetValueRaiseNoEvent(AmplitudeScalar);
        }

        private void UpdatePSDslow(int newValue)
        {
            PSDslow = newValue;
            inPsdSlow.SetValueRaiseNoEvent(PSDslow);
        }

        public void EnableRange(bool state)
        {
            inPsdAmpScalar.Enabled = state;
        }
    }
}
