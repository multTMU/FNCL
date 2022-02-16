using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class FnclDetectorButtons : UserControl
    {
        public event EventHandler DetectorSelected;

        private DetectorKey selectedDetectorKey;

        public FnclDetectorButtons()
        {
            InitializeComponent();
            this.eCalPanel1.DetectorSelected += PanelOneChanged;
            this.eCalPanel2.DetectorSelected += PanelTwoChanged;
            this.eCalPanel3.DetectorSelected += PanelThreeChanged;
        }

        public void SetIsNotEnergyCal()
        {
            eCalPanel1.SetNotForEnergyCalibrations();
            eCalPanel2.SetNotForEnergyCalibrations();
            eCalPanel3.SetNotForEnergyCalibrations();
        }

        public DetectorKey GetSelectedDetector()
        {
            return selectedDetectorKey;
        }

        private void PanelThreeChanged(object sender, EventArgs e)
        {
            PanelDetectorChanged(eCalPanel3);
        }

        private void PanelDetectorChanged(FnclPanel fnclPanel)
        {
            selectedDetectorKey = fnclPanel.GetCurrentDetector();
            OnDetectorSelected();
        }

        private void PanelTwoChanged(object sender, EventArgs e)
        {
            PanelDetectorChanged(eCalPanel2);
        }

        private void PanelOneChanged(object sender, EventArgs e)
        {
            PanelDetectorChanged(eCalPanel1);
        }

        public void InitializePanelOne(int panelOne)
        {
            this.eCalPanel1.Initialize(panelOne);
        }

        public void InitializePanelTwo(int panelTwo)
        {
            this.eCalPanel2.Initialize(panelTwo);
        }

        public void InitializePanelThree(int panelThree)
        {
            this.eCalPanel3.Initialize(panelThree);
        }

        public void SetGroupBoxLabel(string groupBoxLabel)
        {
            this.groupBox1.Text = groupBoxLabel;
        }

        protected virtual void OnDetectorSelected()
        {
            DetectorSelected?.Invoke(this, EventArgs.Empty);
        }

        public void InitializePanels(int panelOne, int panelTwo, int panelThree)
        {
            InitializePanelOne(panelOne);
            InitializePanelTwo(panelTwo);
            InitializePanelThree(panelThree);
        }
    }
}
