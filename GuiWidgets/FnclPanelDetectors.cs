using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets
{
    public partial class FnclPanelDetectors : UserControl
    {
        public double DetOne { get; private set; }
        public double DetTwo { get; private set; }
        public double DetThree { get; private set; }
        public double DetFour { get; private set; }

        public FnclPanelDetectors()
        {
            InitializeComponent();
            SetDataTypes();
            MakeEvents();
            SetAll(0);
            inDet1.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
            inDet2.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
            inDet3.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
            inDet4.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        public void SetPanelNumber(string panelNumber)
        {
            groupBox1.Text = "Panel " + panelNumber;
        }

        public void SetAll(double time)
        {
            SetDet1(time);
            SetDet2(time);
            SetDet3(time);
            SetDet4(time);
        }

        public void SetByDetectorKeyPair(KeyValuePair<int, double> detectorKeyValue)
        {
            DetectorKey panelDetector = FNCLdetectorDictionary.GetKeyByIndex(detectorKeyValue.Key);
            switch (panelDetector.Detector)
            {
                case FnclHelpers.DETECTOR_ONE:
                    inDet1.SetValueRaiseNoEvent(detectorKeyValue.Value);
                    break;
                case FnclHelpers.DETECTOR_TWO:
                    inDet2.SetValueRaiseNoEvent(detectorKeyValue.Value);
                    break;
                case FnclHelpers.DETECTOR_THREE:
                    inDet3.SetValueRaiseNoEvent(detectorKeyValue.Value);
                    break;
                case FnclHelpers.DETECTOR_FOUR:
                    inDet4.SetValueRaiseNoEvent(detectorKeyValue.Value);
                    break;
            }
        }

        public void SetDetOne(double time)
        {
            SetDet1(time);
        }

        public void SetDetTwo(double time)
        {
            SetDet2(time);
        }

        public void SetDetThree(double time)
        {
            SetDet3(time);
        }

        public void SetDetFour(double time)
        {
            SetDet4(time);
        }

        public void SetDataTypes(bool isInteger = true)
        {
            inDet1.DataIsInteger = isInteger;
            inDet2.DataIsInteger = isInteger;
            inDet3.DataIsInteger = isInteger;
            inDet4.DataIsInteger = isInteger;
        }

        private void MakeEvents()
        {
            inDet1.NumberUpdated += UpdateDet1;
            inDet2.NumberUpdated += UpdateDet2;
            inDet3.NumberUpdated += UpdateDet3;
            inDet4.NumberUpdated += UpdateDet4;
        }

        private void UpdateDet4(object sender, EventArgs e)
        {
            SetDet4(inDet4.Value);
        }

        private void SetDet4(double value)
        {
            DetFour = value;
            inDet4.SetValueRaiseNoEvent(DetFour);
        }

        private void UpdateDet3(object sender, EventArgs e)
        {
            SetDet3(inDet3.Value);
        }

        private void SetDet3(double value)
        {
            DetThree = value;
            inDet3.SetValueRaiseNoEvent(DetThree);
        }

        private void UpdateDet2(object sender, EventArgs e)
        {
            SetDet2(inDet2.Value);
        }

        private void SetDet2(double value)
        {
            DetTwo = value;
            inDet2.SetValueRaiseNoEvent(DetTwo);
        }

        private void UpdateDet1(object sender, EventArgs e)
        {
            SetDet1(inDet1.Value);
        }

        private void SetDet1(double value)
        {
            DetOne = value;
            inDet1.SetValueRaiseNoEvent(DetOne);
        }

        public void SetReadOnly()
        {
            inDet1.SetReadonly();
            inDet2.SetReadonly();
            inDet3.SetReadonly();
            inDet4.SetReadonly();
        }
    }
}
