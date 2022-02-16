using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalLinear : UserControl, IECalForm
    {
        private CustomValidator<List<double>, List<double>> validator;

        public ECalLinear()
        {
            InitializeComponent();
        }

        private void SetEnergyCal(List<double> eCal)
        {
            if (validator != null)
            {
                eCal = validator(eCal);
            }

            inIntercept.SetValueRaiseNoEvent(eCal[0]);
            inSlope.SetValueRaiseNoEvent(eCal[1]);
        }

        public event EventHandler EcalChanged;

        public void SetDefaultEnergyCal()
        {
            SetEnergyCal(new List<double>() {0, 0});
        }

        public PoliMiOrganicNeutronEnergyCal GetECalType()
        {
            return PoliMiOrganicNeutronEnergyCal.NotPoliMiLinear;
        }

        public void SetReadonly()
        {
            SetReadOnlyState(true);
        }

        public void SetNotReadonly()
        {
            SetReadOnlyState(false);
        }

        private void SetReadOnlyState(bool state)
        {
            if (state)
            {
                inIntercept.SetReadonly();
                inSlope.SetReadonly();
            }
            else
            {
                inIntercept.SetNotReadonly();
                inSlope.SetNotReadonly();
            }
        }

        public void SetValueRaiseNoEvent(List<double> valueNew)
        {
            SetEnergyCal(valueNew);
        }

        public void SetValueRaiseEvent(List<double> valueNew)
        {
            SetEnergyCal(valueNew);
            OnEcalChanged();
        }

        public void SetLabel(string labelNew)
        {
            this.label1.Text = labelNew;
        }

        public List<double> GetValue()
        {
            List<double> eCal = new List<double>();
            eCal.Add(inIntercept.Value);
            eCal.Add(inSlope.Value);
            return eCal;
        }

        protected virtual void OnEcalChanged()
        {
            EcalChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SetCustomValidator(CustomValidator<List<double>, List<double>> customValidator)
        {
            validator = customValidator;
        }
    }
}
