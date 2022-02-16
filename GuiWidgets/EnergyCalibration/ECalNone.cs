using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.EnergyCalibration
{
    public partial class ECalNone : UserControl, IECalForm
    {
        public ECalNone()
        {
            InitializeComponent();
        }

        private List<double> GetEnergyCal()
        {
            return new List<double>();
        }

        public event EventHandler EcalChanged;

        public void SetDefaultEnergyCal()
        {
            // Do Nothing 
        }

        public PoliMiOrganicNeutronEnergyCal GetECalType()
        {
            return PoliMiOrganicNeutronEnergyCal.None;
        }

        public void SetEnergyCal(List<double> eCal)
        {
            // Do Nothing
        }

        public void SetReadonly()
        {
            //throw new NotImplementedException();
        }

        public void SetNotReadonly()
        {
            //throw new NotImplementedException();
        }

        public void SetValueRaiseNoEvent(List<double> valueNew)
        {
            // throw new NotImplementedException();
        }

        public void SetValueRaiseEvent(List<double> valueNew)
        {
            //throw new NotImplementedException();
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
            // do nothing
        }
    }
}
