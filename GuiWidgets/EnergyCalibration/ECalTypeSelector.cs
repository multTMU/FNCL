using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalTypeSelector : UserControl
    {
        public event EventHandler ECalTypeChanged;
        private PoliMiOrganicNeutronEnergyCal eCalType;
        public PoliMiOrganicNeutronEnergyCal EcalType => eCalType;

        public ECalTypeSelector()
        {
            InitializeComponent();
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNone.Checked)
            {
                eCalType = PoliMiOrganicNeutronEnergyCal.None;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbLinear_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLinear.Checked)
            {
                eCalType = PoliMiOrganicNeutronEnergyCal.NotPoliMiLinear;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbRational_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRational.Checked)
            {
                eCalType = PoliMiOrganicNeutronEnergyCal.Rational;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbQuad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuad.Checked)
            {
                eCalType = PoliMiOrganicNeutronEnergyCal.Quadratic;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrans.Checked)
            {
                eCalType = PoliMiOrganicNeutronEnergyCal.Transcendental;
                HandleChange(EventArgs.Empty);
            }
        }

        protected virtual void HandleChange(EventArgs e)
        {
            EventHandler handler = this.ECalTypeChanged;
            handler?.Invoke(this, e);
        }

        public void SetSelectedEcal(PoliMiOrganicNeutronEnergyCal energyCalType)
        {
            switch (energyCalType)
            {
                case PoliMiOrganicNeutronEnergyCal.None:
                    rbNone.Checked = true;
                    break;
                case PoliMiOrganicNeutronEnergyCal.NotPoliMiLinear:
                    rbLinear.Checked = true;
                    break;
                case PoliMiOrganicNeutronEnergyCal.Quadratic:
                    rbQuad.Checked = true;
                    break;
                case PoliMiOrganicNeutronEnergyCal.Rational:
                    rbRational.Checked = true;
                    break;
                case PoliMiOrganicNeutronEnergyCal.Transcendental:
                    rbTrans.Checked = true;
                    break;
                default:
                    rbNone.Checked = true;
                    break;
            }
        }
    }
}
