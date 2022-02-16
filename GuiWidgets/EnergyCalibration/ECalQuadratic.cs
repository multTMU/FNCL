using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalQuadratic : UserControl, IECalForm
    {
        private CustomValidator<List<double>, List<double>> validator;

        public ECalQuadratic()
        {
            InitializeComponent();
        }

        private List<double> GetEnergyCal()
        {
            List<double> eCal = new List<double>();
            eCal.Add(inC0.Value);
            eCal.Add(inC1.Value);
            eCal.Add(inC2.Value);
            return eCal;
        }

        private void SetEnergyCal(List<double> eCal)
        {
            if (validator != null)
            {
                eCal = validator(eCal);
            }

            inC0.SetValueRaiseNoEvent(eCal[0]);
            inC1.SetValueRaiseNoEvent(eCal[1]);
            inC2.SetValueRaiseNoEvent(eCal[2]);
        }

        public event EventHandler EcalChanged;

        public void SetDefaultEnergyCal()
        {
            SetEnergyCal(new List<double>() {0, 0, 0});
        }

        public PoliMiOrganicNeutronEnergyCal GetECalType()
        {
            return PoliMiOrganicNeutronEnergyCal.Quadratic;
        }

        public void SetReadonly()
        {
            SetReadonlyState(true);
        }

        private void SetReadonlyState(bool state)
        {
            if (state)
            {
                inC0.SetReadonly();
                inC1.SetReadonly();
                inC2.SetReadonly();
            }
            else
            {
                inC0.SetNotReadonly();
                inC1.SetNotReadonly();
                inC2.SetNotReadonly();
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
