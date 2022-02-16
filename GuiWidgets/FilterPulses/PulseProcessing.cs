using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiWidgets
{
    public partial class PulseProcessing : UserControl
    {
        public int AdcLLD { get; private set; }
        public int AdcULD { get; private set; }

        public PulseProcessing()
        {
            InitializeComponent();
            SetPanelNumbers();
            inAdcLld.DataIsInteger = true;
            SetEvents();
        }

        public void EnableADCtrigger(bool state)
        {
            inAdcLld.Enabled = state;
            inAdcUld.Enabled = state;
        }

        private void SetEvents()
        {
            inAdcLld.NumberUpdated += UpdateAdc;
            inAdcUld.NumberUpdated += UpdateAdc;
        }

        private void UpdateAdc(object sender, EventArgs e)
        {
            SetAdcTrigger((int)inAdcLld.Value, (int)inAdcUld.Value);
        }

        public void SetAdcTrigger(int lld, int uld)
        {
            AdcLLD = lld;
            inAdcLld.SetValueRaiseNoEvent(AdcLLD);

            AdcULD = uld;
            inAdcUld.SetValueRaiseNoEvent(AdcULD);
        }

        private void SetPanelNumbers()
        {
            panel1.SetPanelNumber("One");
            panel2.SetPanelNumber("Two");
            panel3.SetPanelNumber("Three");
        }

        public List<int> GetPanelOneOffSets()
        {
            return GetOffSet(panel1);
        }

        public List<int> GetPanelTwoOffSets()
        {
            return GetOffSet(panel2);
        }

        public List<int> GetPanelThreeOffSets()
        {
            return GetOffSet(panel3);
        }

        private List<int> GetOffSet(FnclPanelDetectors panel)
        {
            List<int> offSet = new List<int>();
            offSet.Add((int)panel.DetOne);
            offSet.Add((int)panel.DetTwo);
            offSet.Add((int)panel.DetThree);
            offSet.Add((int)panel.DetFour);
            return offSet;
        }
    }
}
