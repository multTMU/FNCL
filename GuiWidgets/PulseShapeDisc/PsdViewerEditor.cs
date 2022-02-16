using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.PulseShapeDisc
{
    public partial class PsdViewerEditor : UserControl
    {
        private PsdTriggerTypes psdType;
        public PsdTriggerTypes PsdType => psdType;
        public int FastInterval => this.psdIntervals1.PSDfast;
        public int SlowInterval => this.psdIntervals1.PSDslow;
        public double AmplitudeScalar => this.psdIntervals1.AmplitudeScalar;
        public double Trigger => this.inputTrigger.Value;
        public int NumberPulses => (int)this.inMaxPulses.Value;

        public PsdViewerEditor()
        {
            InitializeComponent();
            SetEvents();
        }

        internal void EnableAmplitudeScalar(bool state)
        {
            this.psdIntervals1.EnableRange(state);
        }

        public void SetDefaults(int slowInterval, int fastInterval, double amplitudeScalar, double trigger,
            PsdTriggerTypes psdTriggerType)
        {
            this.psdTypeSelector1.SetSelectedPSD(psdTriggerType);
            this.psdIntervals1.SetPSDfast(fastInterval);
            this.psdIntervals1.SetPSDslow(slowInterval);
            this.psdIntervals1.SetAmplitudeScalar(amplitudeScalar);
            this.inputTrigger.SetValueRaiseNoEvent(trigger);
            this.inMaxPulses.SetValueRaiseNoEvent(0);
        }

        private void SetEvents()
        {
            this.psdTypeSelector1.PsdTypeChanged += SelectedPsdTypeChanged;
        }

        private void SelectedPsdTypeChanged(object sender, EventArgs e)
        {
            psdType = this.psdTypeSelector1.PsdType;
            switch (psdType)
            {
                case PsdTriggerTypes.Fixed:
                    SetFixed();
                    break;
                case PsdTriggerTypes.PeakOffset:
                    SetOffset();
                    break;
                case PsdTriggerTypes.PeakHeight:
                    SetPeakHeight();
                    break;
                default:
                    SetOffset();
                    break;
            }
        }

        private void SetPeakHeight()
        {
            this.inputTrigger.Label = "Peak Fraction(%):";
            this.inputTrigger.DataIsInteger = false;
        }

        private void SetOffset()
        {
            this.inputTrigger.Label = "Peak Offset:";
            this.inputTrigger.DataIsInteger = true;
        }

        private void SetFixed()
        {
            this.inputTrigger.Label = "Fixed Time:";
            this.inputTrigger.DataIsInteger = true;
        }

        public void SetFromPsdSpecification(double trigger, int fast, int slow,
            PsdTriggerTypes triggerType, double amplitudeScalar)
        {
            this.psdIntervals1.SetPSDfast(fast);
            this.psdIntervals1.SetPSDslow(slow);
            this.psdIntervals1.SetAmplitudeScalar(amplitudeScalar);
            this.psdTypeSelector1.SetSelectedPSD(triggerType);
            this.inputTrigger.SetValueRaiseNoEvent(trigger);
        }

        public void SetNumberOfPulses(int numberOfPulses)
        {
            this.inMaxPulses.SetValueRaiseNoEvent(numberOfPulses);
        }
    }
}
