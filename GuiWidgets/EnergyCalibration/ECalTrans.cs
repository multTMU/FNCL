using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalTrans : UserControl, IECalForm
    {
        private CustomValidator<List<double>, List<double>> validator;

        public ECalTrans()
        {
            InitializeComponent();
        }

        public event EventHandler EcalChanged;

        private List<double> GetEnergyCal()
        {
            List<double> eCal = new List<double>();
            eCal.Add(inAmp.Value);
            eCal.Add(inLinear.Value);
            eCal.Add(inExpLinear.Value);
            eCal.Add(inExpScalar.Value);
            eCal.Add(inExpPower.Value);
            return eCal;
        }

        private void SetEnergyCal(List<double> eCal)
        {
            if (validator != null)
            {
                eCal = validator(eCal);
            }

            inAmp.SetValueRaiseNoEvent(eCal[0]);
            inLinear.SetValueRaiseNoEvent(eCal[1]);
            inExpLinear.SetValueRaiseNoEvent(eCal[2]);
            inExpScalar.SetValueRaiseNoEvent(eCal[3]);
            inExpPower.SetValueRaiseNoEvent(eCal[4]);
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

        public PoliMiOrganicNeutronEnergyCal GetECalType()
        {
            return PoliMiOrganicNeutronEnergyCal.Transcendental;
        }

        public void SetReadonly()
        {
            SetReadonlyState(true);
        }

        private void SetReadonlyState(bool state)
        {
            if (state)
            {
                inAmp.SetReadonly();
                inLinear.SetReadonly();
                inExpLinear.SetReadonly();
                inExpScalar.SetReadonly();
                inExpPower.SetReadonly();
            }
            else
            {
                inAmp.SetNotReadonly();
                inLinear.SetNotReadonly();
                inExpLinear.SetNotReadonly();
                inExpScalar.SetNotReadonly();
                inExpPower.SetNotReadonly();
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
