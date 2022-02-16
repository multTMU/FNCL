using GlobalHelpersDefaults;
using System;
using System.Windows.Forms;

namespace GuiWidgets.EnergyCalibration
{
    public partial class EnergyCalibration : Form
    {
        private int panel;
        private int detector;
        private IEnergyCalibration energyCalibration;
        private IECalForm eCalWidget;
        private bool convertToKeVee;
        private bool eCalChanged;

        public EnergyCalibration()
        {
            InitializeComponent();
            eCalChanged = false;
        }

        public void SetForm(int Panel, int Detector, IEnergyCalibration EnergyCalibration)
        {
            panel = Panel;
            detector = Detector;
            energyCalibration = EnergyCalibration;
            SetLabel();
            SetRadar();
            DrawPanel(energyCalibration.GetPoliMiCalType());
            SetEvents();
        }

        private void SetRadar()
        {
            this.eCalTypeSelector1.SetSelectedEcal(energyCalibration.GetPoliMiCalType());
        }

        private void SetEvents()
        {
            this.eCalTypeSelector1.ECalTypeChanged += SelectedECalTypeChanged;
        }

        private void SelectedECalTypeChanged(object sender, EventArgs e)
        {
            DrawPanel(eCalTypeSelector1.EcalType);
        }

        private void DrawPanel(PoliMiOrganicNeutronEnergyCal eCalType)
        {
            eCalWidget = ECalFormHelper.GetFormByEnergyCalSelected(eCalType);
            pHostECal.Controls.Clear();
            pHostECal.Controls.Add(eCalWidget as Control);

            if (eCalType == energyCalibration.GetPoliMiCalType())
            {
                eCalWidget.SetValueRaiseNoEvent(energyCalibration.GetParameters());
            }
            else
            {
                eCalWidget.SetDefaultEnergyCal();
            }
        }

        internal IEnergyCalibration GetECal()
        {
            return EnergyCalibrationHelper.GetEnergyCalibration(eCalWidget.GetECalType(), eCalWidget.GetValue(),
                convertToKeVee);
        }

        private void SetLabel()
        {
            labelPanelDet.Text = "Panel: " + panel + " Detector: " + detector;
        }

        public bool ECalChanged()
        {
            return eCalChanged;
        }

        private void cbConvert_CheckedChanged(object sender, EventArgs e)
        {
            convertToKeVee = !cbConvert.Checked;
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            eCalChanged = true;
            this.Close();
        }
    }
}
