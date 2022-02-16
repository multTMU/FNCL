using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets
{
    public partial class FnclDetectorSelect : UserControl
    {
        private SelectedDetectors detectors;
        private const bool DEFAULT_STATE = true;

        public FnclDetectorSelect()
        {
            InitializeComponent();
            detectors = new SelectedDetectors();
            SetUniformCheckedState(DEFAULT_STATE);
        }

        public List<int> GetSelectedDetectors()
        {
            return detectors.GetSelectedDetectors();
        }

        public void SetDetectors(SelectedDetectors Detectors)
        {
            detectors = Detectors;
            SetCheckedState();
        }

        private void SetUniformCheckedState(bool state)
        {
            SetOneOne(state);
            SetOneTwo(state);
            SetOneThree(state);
            SetOneFour(state);

            SetTwoOne(state);
            SetTwoTwo(state);
            SetTwoThree(state);
            SetTwoFour(state);

            SetThreeOne(state);
            SetThreeTwo(state);
            SetThreeThree(state);
            SetThreeFour(state);
        }

        private void SetCheckedState()
        {
            SetOneOne(detectors.PanelOne.DetectorOne);
            SetOneTwo(detectors.PanelOne.DetectorTwo);
            SetOneThree(detectors.PanelOne.DetectorThree);
            SetOneFour(detectors.PanelOne.DetectorFour);

            SetTwoOne(detectors.PanelTwo.DetectorOne);
            SetTwoTwo(detectors.PanelTwo.DetectorTwo);
            SetTwoThree(detectors.PanelTwo.DetectorThree);
            SetTwoFour(detectors.PanelTwo.DetectorFour);

            SetThreeOne(detectors.PanelThree.DetectorOne);
            SetThreeTwo(detectors.PanelThree.DetectorTwo);
            SetThreeThree(detectors.PanelThree.DetectorThree);
            SetThreeFour(detectors.PanelThree.DetectorFour);
        }

        #region Panel One

        private void SetOneOne(bool state)
        {
            detectors.PanelOne.DetectorOne = state;
            cb1_1.Checked = state;
        }

        private void SetOneTwo(bool state)
        {
            detectors.PanelOne.DetectorTwo = state;
            cb1_2.Checked = state;
        }

        private void SetOneThree(bool state)
        {
            detectors.PanelOne.DetectorThree = state;
            cb1_3.Checked = state;
        }

        private void SetOneFour(bool state)
        {
            detectors.PanelOne.DetectorFour = state;
            cb1_4.Checked = state;
        }

        #endregion

        #region Panel Two

        private void SetTwoOne(bool state)
        {
            detectors.PanelTwo.DetectorOne = state;
            cb2_1.Checked = state;
        }

        private void SetTwoTwo(bool state)
        {
            detectors.PanelTwo.DetectorTwo = state;
            cb2_2.Checked = state;
        }

        private void SetTwoThree(bool state)
        {
            detectors.PanelTwo.DetectorThree = state;
            cb2_3.Checked = state;
        }

        private void SetTwoFour(bool state)
        {
            detectors.PanelTwo.DetectorFour = state;
            cb2_4.Checked = state;
        }

        #endregion

        #region Panel Three

        private void SetThreeOne(bool state)
        {
            detectors.PanelThree.DetectorOne = state;
            cb3_1.Checked = state;
        }

        private void SetThreeTwo(bool state)
        {
            detectors.PanelThree.DetectorTwo = state;
            cb3_2.Checked = state;
        }

        private void SetThreeThree(bool state)
        {
            detectors.PanelThree.DetectorThree = state;
            cb3_3.Checked = state;
        }

        private void SetThreeFour(bool state)
        {
            detectors.PanelThree.DetectorFour = state;
            cb3_4.Checked = state;
        }

        #endregion

        #region events

        private void cb1_1_CheckedChanged(object sender, EventArgs e)
        {
            SetOneOne(cb1_1.Checked);
        }


        private void cb1_2_CheckedChanged(object sender, EventArgs e)
        {
            SetOneTwo(cb1_2.Checked);
        }

        private void cb1_3_CheckedChanged(object sender, EventArgs e)
        {
            SetOneThree(cb1_3.Checked);
        }

        private void cb1_4_CheckedChanged(object sender, EventArgs e)
        {
            SetOneFour(cb1_4.Checked);
        }

        private void cb2_1_CheckedChanged(object sender, EventArgs e)
        {
            SetTwoOne(cb2_1.Checked);
        }

        private void cb2_2_CheckedChanged(object sender, EventArgs e)
        {
            SetTwoTwo(cb2_2.Checked);
        }

        private void cb2_3_CheckedChanged(object sender, EventArgs e)
        {
            SetTwoThree(cb2_3.Checked);
        }

        private void cb2_4_CheckedChanged(object sender, EventArgs e)
        {
            SetTwoFour(cb2_4.Checked);
        }

        private void cb3_1_CheckedChanged(object sender, EventArgs e)
        {
            SetThreeOne(cb3_1.Checked);
        }

        private void cb3_2_CheckedChanged(object sender, EventArgs e)
        {
            SetThreeTwo(cb3_2.Checked);
        }

        private void cb3_3_CheckedChanged(object sender, EventArgs e)
        {
            SetThreeThree(cb3_3.Checked);
        }

        private void cb3_4_CheckedChanged(object sender, EventArgs e)
        {
            SetThreeFour(cb3_4.Checked);
        }

        #endregion
    }
}
