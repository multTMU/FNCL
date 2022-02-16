using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets
{
    public partial class FnclPanel : UserControl
    {
        public event EventHandler DetectorSelected;
        private int panel;
        private int currentDetector;
        private EnergyCalibration.EnergyCalibration eCalForm;
        private bool isEnergyCal;

        public FnclPanel()
        {
            InitializeComponent();
            isEnergyCal = true;
        }

        public void SetNotForEnergyCalibrations()
        {
            isEnergyCal = false;
        }

        public void Initialize(int Panel)
        {
            panel = Panel;
            this.groupBox1.Text = "Panel " + panel.ToString();
        }

        private void GetEnergyCalibration()
        {
            if (isEnergyCal)
            {
                eCalForm = new EnergyCalibration.EnergyCalibration();
                eCalForm.SetForm(panel, currentDetector,
                    DetectorEnergyCalibration.GetEnergyCalibration(panel, currentDetector));
                eCalForm.ShowDialog();
                if (eCalForm.ECalChanged())
                {
                    DetectorEnergyCalibration.AddEnergyCalibration(panel, currentDetector, eCalForm.GetECal());
                }
            }
        }

        private void bD1_Click(object sender, EventArgs e)
        {
            currentDetector = GuiInterface.DetectorDefaults.GetDetectorOne();
            OnDetectorSelected();
            GetEnergyCalibration();
        }

        private void bD2_Click(object sender, EventArgs e)
        {
            currentDetector = GuiInterface.DetectorDefaults.GetDetectorTwo();
            OnDetectorSelected();
            GetEnergyCalibration();
        }

        private void bD3_Click(object sender, EventArgs e)
        {
            currentDetector = GuiInterface.DetectorDefaults.GetDetectorThree();
            OnDetectorSelected();
            GetEnergyCalibration();
        }

        private void bD4_Click(object sender, EventArgs e)
        {
            currentDetector = GuiInterface.DetectorDefaults.GetDetectorFour();
            OnDetectorSelected();
            GetEnergyCalibration();
        }

        protected virtual void OnDetectorSelected()
        {
            DetectorSelected?.Invoke(this, EventArgs.Empty);
        }

        public DetectorKey GetCurrentDetector()
        {
            return new DetectorKey(panel, currentDetector);
        }
    }
}
