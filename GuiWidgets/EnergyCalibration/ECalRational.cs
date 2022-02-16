using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalRational : UserControl, IECalForm
    {
        private CustomValidator<List<double>, List<double>> validator;

        public ECalRational()
        {
            InitializeComponent();
        }

        public event EventHandler EcalChanged;

        private List<double> GetEnergyCal()
        {
            List<double> eCal = new List<double>();
            eCal.Add(inNumerator.Value);
            eCal.Add(inDenomerator.Value);
            return eCal;
        }

        private void SetEnergyCal(List<double> eCal)
        {
            if (validator != null)
            {
                eCal = validator(eCal);
            }

            inNumerator.SetValueRaiseNoEvent(eCal[0]);
            inDenomerator.SetValueRaiseNoEvent(eCal[1]);
        }

        public void SetDefaultEnergyCal()
        {
            SetEnergyCal(new List<double>() {0, 0});
        }

        public PoliMiOrganicNeutronEnergyCal GetECalType()
        {
            return PoliMiOrganicNeutronEnergyCal.Rational;
        }

        public void SetReadonly()
        {
            SetReadonlyState(true);
        }

        private void SetReadonlyState(bool state)
        {
            if (state)
            {
                inNumerator.SetReadonly();
                inDenomerator.SetReadonly();
            }
            else
            {
                inNumerator.SetNotReadonly();
                inDenomerator.SetNotReadonly();
            }
        }

        public void SetNotReadonly()
        {
            SetReadonlyState(false);
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
            return GetEnergyCal();
        }

        public void SetCustomValidator(CustomValidator<List<double>, List<double>> customValidator)
        {
            validator = customValidator;
        }

        protected virtual void OnEcalChanged()
        {
            EcalChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
