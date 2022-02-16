using System;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets
{
    public partial class PulseFilters : UserControl
    {
        public event EventHandler EditPsd;
        public double PulseHeightLLD { get; private set; }
        public double PulseHeightULD { get; private set; }
        public int PileUp { get; private set; }
        public bool PulseShapeEnabled;
        public CrossTalk DetectorCrossTalk => crossTalk;
        public string PsdFile => psdCurveFile;
        public bool PsdEnabled => (!string.IsNullOrEmpty(psdCurveFile));
        public int MaxTimeInterval => this.correlatedPulsesFilter1.MaxTimeInterval;

        private string psdCurveFile;
        private CrossTalk crossTalk;

        public PulseFilters()
        {
            InitializeComponent();
            SetInputDataType();
            SetUpEvents();
            inCrossTalkTime.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        private void SetUpEvents()
        {
            inPulseHeight.NumberUpdated += UpdatePulseHeightLLDEvent;
            inULD.NumberUpdated += UpdatePulseHeightULDEvent;
            inCrossTalkTime.NumberUpdated += UpdatePileUpEvent;
        }

        private void SetInputDataType()
        {
            inCrossTalkTime.DataIsInteger = true;
            inPulseHeight.DataIsInteger = false;
        }

        private void UpdatePileUpEvent(object sender, EventArgs e)
        {
            UpdatePileUp((int)inCrossTalkTime.Value);
        }

        private void UpdatePulseHeightLLDEvent(object sender, EventArgs e)
        {
            UpdatePulseHeightLLD(inPulseHeight.Value);
        }

        private void UpdatePulseHeightULDEvent(object sender, EventArgs e)
        {
            UpdatePulseHeightULD(inULD.Value);
        }

        public void EnableAll()
        {
            inPulseHeight.Enabled = true;
            gbPsd.Enabled = true;
        }

        public void EnableFlatFile()
        {
            EnableAll();
            inPulseHeight.Enabled = false;
            gbPsd.Enabled = false;
        }

        public void EnableBinaryFile()
        {
            EnableAll();
        }

        public void EnablePoliMiFile()
        {
            EnableAll();
            inPulseHeight.Enabled = false;
            inCrossTalkTime.Enabled = false;
        }

        public void SetCrossTalk(CrossTalk newCrossTalk)
        {
            crossTalk = newCrossTalk;
            SetCrossTalkBoxes();
        }

        public void SetPulseHeightLLD(double newPulseHeight)
        {
            UpdatePulseHeightLLD(newPulseHeight);
        }

        public void SetPulseHeightULD(double newPulseHeight)
        {
            UpdatePulseHeightULD(newPulseHeight);
        }

        public void SetPileUp(int newPileUp)
        {
            UpdatePileUp(newPileUp);
        }

        public void SetDefaults(double pulseHeightLLD, double pulseHeightULD, int pileUp, bool crossTalkState,
            int correlatedPulseTime)
        {
            crossTalk = new CrossTalk(crossTalkState);
            SetCrossTalkBoxes();
            SetPulseHeightLLD(pulseHeightLLD);
            SetPulseHeightULD(pulseHeightULD);
            SetPileUp(pileUp);
            SetCorrelatedPulseTime(correlatedPulseTime);
        }

        private void SetCorrelatedPulseTime(int correlatedPulseTime)
        {
            this.correlatedPulsesFilter1.SetDefault(correlatedPulseTime);
        }

        private void SetCrossTalkBoxes()
        {
            cbSelf.Checked = crossTalk.Self;
            cbOneFour.Checked = crossTalk.OneFour;
            cbOneTwo.Checked = crossTalk.OneTwo;
            cbOneThree.Checked = crossTalk.OneThree;
            cbTwoFour.Checked = crossTalk.TwoFour;
            cbTwoThree.Checked = crossTalk.TwoThree;
            cbThreeFour.Checked = crossTalk.ThreeFour;
        }

        private void UpdatePulseHeightLLD(double newValue)
        {
            PulseHeightLLD = newValue;
            inPulseHeight.SetValueRaiseNoEvent(PulseHeightLLD);
        }

        private void UpdatePulseHeightULD(double newValue)
        {
            PulseHeightULD = newValue;
            inULD.SetValueRaiseNoEvent(newValue);
        }

        private void UpdatePileUp(int newValue)
        {
            PileUp = newValue;
            inCrossTalkTime.SetValueRaiseNoEvent(PileUp);
        }

        private void cbSelf_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.Self = cbSelf.Checked;
        }

        private void cbTwoThree_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.TwoThree = cbTwoThree.Checked;
        }

        private void cbTwoFour_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.TwoFour = cbTwoFour.Checked;
        }

        private void cbOneThree_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.OneThree = cbOneThree.Checked;
        }

        private void cbOneFour_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.OneFour = cbOneFour.Checked;
        }

        private void cbThreeFour_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.ThreeFour = cbThreeFour.Checked;
        }

        private void cbOneTwo_CheckedChanged(object sender, EventArgs e)
        {
            crossTalk.OneTwo = cbOneTwo.Checked;
        }

        public void EnablePulseHeight(bool state)
        {
            inPulseHeight.Enabled = state;
            inULD.Enabled = state;
        }

        public void EnablePSD(bool state)
        {
            gbPsd.Enabled = state;
        }

        protected virtual void OnEnablePsdChanged()
        {
            EditPsd?.Invoke(this, EventArgs.Empty);
        }

        //private void bLoad_Click(object sender, EventArgs e)
        //{
        //    psdCurveFile = MultiplicityInterfaceHelper.GetFile("Choose Pulse Shape Discriminator file...", false);
        //    if (File.Exists(psdCurveFile))
        //    {
        //        this.inPsdCurve.SetValueRaiseNoEvent(psdCurveFile);
        //        OnEnablePsdChanged();
        //    }
        //}

        public void EnableCorrelatedPulseTime(bool state)
        {
            this.correlatedPulsesFilter1.Enabled = state;
        }

        private void bEditPsd_Click(object sender, EventArgs e)
        {
            OnEnablePsdChanged();
        }
    }
}
