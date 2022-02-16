using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalFourthPoly : UserControl, IECalForm
    {
        public event EventHandler EcalChanged;
        private CustomValidator<List<double>, List<double>> validator;

        public ECalFourthPoly()
        {
            InitializeComponent();
        }

        public PoliMiOrganicNeutronEnergyCal GetECalType()
        {
            return PoliMiOrganicNeutronEnergyCal.FourthOrder;
        }

        public List<double> GetValue()
        {
            List<double> eCal = new List<double>();
            eCal.Add(inC0.Value);
            eCal.Add(inC1.Value);
            eCal.Add(inC2.Value);
            eCal.Add(inC3.Value);
            eCal.Add(inC4.Value);
            return eCal;
        }

        public void SetDefaultEnergyCal()
        {
            SetEnergyCal(new List<double>()
            {
                0,
                0,
                0,
                0,
                0
            });
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
            inC3.SetValueRaiseNoEvent(eCal[3]);
            inC4.SetValueRaiseNoEvent(eCal[4]);
        }

        public void SetLabel(string labelNew)
        {
            this.label1.Text = labelNew;
        }

        public void SetNotReadonly()
        {
            SetReadOnlyState(false);
        }

        private void SetReadOnlyState(bool state)
        {
            if (state)
            {
                inC0.SetReadonly();
                inC1.SetReadonly();
                inC2.SetReadonly();
                inC3.SetReadonly();
                inC4.SetReadonly();
            }
            else
            {
                inC0.SetNotReadonly();
                inC1.SetNotReadonly();
                inC2.SetNotReadonly();
                inC3.SetNotReadonly();
                inC4.SetNotReadonly();
            }
        }

        public void SetReadonly()
        {
            SetReadOnlyState(true);
        }

        public void SetValueRaiseEvent(List<double> valueNew)
        {
            SetEnergyCal(valueNew);
            OnEcalChanged();
        }

        public void SetValueRaiseNoEvent(List<double> valueNew)
        {
            SetEnergyCal(valueNew);
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
