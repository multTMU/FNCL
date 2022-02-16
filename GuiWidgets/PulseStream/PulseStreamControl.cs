using System;
using System.Windows.Forms;

namespace GuiWidgets.PulseStream
{
    public partial class PulseStreamControl : UserControl
    {
        private double StartTimeDefault;
        private double EndTimeDefault;

        public PulseStreamControl()
        {
            InitializeComponent();
            this.inEnd.DataIsInteger = false;
            this.inStart.DataIsInteger = false;
            this.inEnd.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
            this.inStart.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        public double StartTime
        {
            get { return inStart.Value; }
        }

        public double EndTime
        {
            get { return inEnd.Value; }
        }

        public void SetDefaults(double startTimeNanoSec, double endTimeNanoSec)
        {
            StartTimeDefault = startTimeNanoSec;
            EndTimeDefault = endTimeNanoSec;
            SetDefaultTimes();
        }

        private void SetDefaultTimes()
        {
            inStart.SetValueRaiseNoEvent(StartTimeDefault);
            inEnd.SetValueRaiseNoEvent(EndTimeDefault);
        }

        private bool FormInputsAreValid()
        {
            return (inStart.Value < inEnd.Value);
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            SetDefaultTimes();
        }
    }
}
