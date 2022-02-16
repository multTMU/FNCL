using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class DetectorResponse : Form, IDetectorResponse
    {
        public event EventHandler CalculateDrf;

        public DetectorResponse()
        {
            InitializeComponent();
            this.detectorResponse1.RunDrf += RunDrfCalculation;
        }

        private void RunDrfCalculation(object sender, EventArgs e)
        {
            OnCalculateDrf();
        }

        protected virtual void OnCalculateDrf()
        {
            CalculateDrf?.Invoke(this, EventArgs.Empty);
        }

        public double GetSourceRate()
        {
            return this.detectorResponse1.GetSourceRate();
        }

        public void SetDrf(Dictionary<int, double> calculatedDrf)
        {
            this.detectorResponse1.SetDrf(calculatedDrf);
        }
    }
}
