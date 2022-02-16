using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;
using Multiplicity;

namespace GuiWidgets.DieAwayTime
{
    public partial class DieAwayFitter : UserControl
    {
        public event EventHandler DieAwayFitTypeChanged;
        private CurveFitType fit;
        private IDieAwayFitGui fitViewer;

        public DieAwayFitter()
        {
            InitializeComponent();
            fit = CurveFitType.SingleExponent;
            rbSingleExponent.Checked = true;
            inRsquared.SetReadonly();
            UpdateFitDisplayed();
        }

        public CurveFitType GetCurveFitType()
        {
            return fit;
        }

        private void rbSingleExponent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSingleExponent.Checked)
            {
                fit = CurveFitType.SingleExponent;
                OnDieAwayFitTypeChanged();
            }
        }

        private void rbTwoExponent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTwoExponent.Checked)
            {
                fit = CurveFitType.TwoExponent;
                OnDieAwayFitTypeChanged();
            }
        }

        protected virtual void OnDieAwayFitTypeChanged()
        {
            UpdateFitDisplayed();
            DieAwayFitTypeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateFitDisplayed()
        {
            uniPanel1.Controls.Clear();
            GetFitForm();
            uniPanel1.Controls.Add(fitViewer as Control);
        }

        private void GetFitForm()
        {
            switch (fit)
            {
                case CurveFitType.SingleExponent:
                    fitViewer = new SingleExponentFit();
                    break;
                case CurveFitType.TwoExponent:
                    fitViewer = new TwoExponentFit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetFitParameters(List<double> dieAwayFitParameters, double rSquared)
        {
            fitViewer.UpdateFitParameters(dieAwayFitParameters);
            inRsquared.SetValueRaiseNoEvent(rSquared);
        }
    }
}
