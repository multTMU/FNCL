using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;
using GuiInterface;

namespace GuiWidgets
{
    public partial class DetectorResponse : UserControl, IDetectorResponse
    {
        public event EventHandler RunDrf;
        private double totalDrf;

        private double totalPanelOne;
        private double totalPanelTwo;
        private double totalPanelThree;

        private double avgPanelOne;
        private double avgPanelTwo;
        private double avgPanelThree;

        public DetectorResponse()
        {
            InitializeComponent();

            InitializePanelOne();
            InitializePanelTwo();
            InitializePanelThree();

            inTotal.SetReadonly();
            this.inSourceRate.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertCuriesToBq);
        }

        private void InitializePanelThree()
        {
            this.panelThree.SetPanelNumber("3");
            this.panelThree.SetReadOnly();
            this.panelThree.SetDataTypes(false);
            inPanelThreeAvg.SetReadonly();
            inPanelThreeTotal.SetReadonly();
        }

        private void InitializePanelTwo()
        {
            this.panelTwo.SetPanelNumber("2");
            this.panelTwo.SetReadOnly();
            this.panelTwo.SetDataTypes(false);
            inPanelTwoAvg.SetReadonly();
            inPanelTwoTotal.SetReadonly();
        }

        private void InitializePanelOne()
        {
            this.panelOne.SetPanelNumber("1");
            this.panelOne.SetReadOnly();
            this.panelOne.SetDataTypes(false);
            inPanelOneAvg.SetReadonly();
            inPanelOneTotal.SetReadonly();
        }

        private void bRunDrf_Click(object sender, EventArgs e)
        {
            OnRunDrf();
        }

        protected virtual void OnRunDrf()
        {
            RunDrf?.Invoke(this, EventArgs.Empty);
        }

        public double GetSourceRate()
        {
            return inSourceRate.Value;
        }

        public void SetDrf(Dictionary<int, double> calculatedDrf)
        {
            InitializeDrfs();
            foreach (KeyValuePair<int, double> kp in calculatedDrf)
            {
                DetectorKey detectorKey = FNCLdetectorDictionary.GetKeyByIndex(kp.Key);
                switch (detectorKey.Panel)
                {
                    case FnclHelpers.PANEL_ONE:
                        totalPanelOne += kp.Value;
                        this.panelOne.SetByDetectorKeyPair(kp);
                        break;
                    case FnclHelpers.PANEL_TWO:
                        totalPanelTwo += kp.Value;
                        this.panelTwo.SetByDetectorKeyPair(kp);
                        break;
                    case FnclHelpers.PANEL_THREE:
                        totalPanelThree += kp.Value;
                        this.panelThree.SetByDetectorKeyPair(kp);
                        break;
                }

                totalDrf += kp.Value;
            }

            CalculateDrfs();
            DisplayDrfs();
        }

        private void CalculateDrfs()
        {
            avgPanelOne = totalPanelOne / FnclHelpers.DETECTORS_PER_PANEL;
            avgPanelTwo = totalPanelTwo / FnclHelpers.DETECTORS_PER_PANEL;
            avgPanelThree = totalPanelThree / FnclHelpers.DETECTORS_PER_PANEL;
        }

        private void DisplayDrfs()
        {
            inPanelOneTotal.SetValueRaiseNoEvent(totalPanelOne);
            inPanelTwoTotal.SetValueRaiseNoEvent(totalPanelTwo);
            inPanelThreeTotal.SetValueRaiseNoEvent(totalPanelThree);

            inPanelOneAvg.SetValueRaiseNoEvent(avgPanelOne);
            inPanelTwoAvg.SetValueRaiseNoEvent(avgPanelTwo);
            inPanelThreeAvg.SetValueRaiseNoEvent(avgPanelThree);

            inTotal.SetValueRaiseNoEvent(totalDrf);
        }

        private void InitializeDrfs()
        {
            totalDrf = 0;

            totalPanelOne = 0;
            totalPanelTwo = 0;
            totalPanelThree = 0;

            avgPanelOne = 0;
            avgPanelTwo = 0;
            avgPanelThree = 0;
        }
    }
}
