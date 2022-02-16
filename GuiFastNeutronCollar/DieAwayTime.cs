using Multiplicity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiFastNeutronCollar
{
    public partial class DieAwayTime : Form
    {
        public event EventHandler CalculateRates;
        public event EventHandler FitTypeChange;

        public DieAwayTime()
        {
            InitializeComponent();
            this.dieAwayTimeTool1.CalculateDieAwayTime += CalculateDieAwayRates;
            this.dieAwayTimeTool1.FitDieAwayTime += DieAwayFitChanged;
        }

        private void DieAwayFitChanged(object sender, EventArgs e)
        {
            OnFitTypeChange();
        }

        private void CalculateDieAwayRates(object sender, EventArgs e)
        {
            OnCalculateRates();
        }

        protected virtual void OnCalculateRates()
        {
            CalculateRates?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFitTypeChange()
        {
            FitTypeChange?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateRawPlot(List<double> timeIntervals)
        {
            this.dieAwayTimeTool1.PlotDieAway(timeIntervals);
        }

        public void UpdateFitPlot(List<Tuple<double, double>> dieAwayFit)
        {
            this.dieAwayTimeTool1.PlotDieAwayFit(dieAwayFit);
        }

        public List<Tuple<double, double>> GetTimeIntervalHistorgram()
        {
            return this.dieAwayTimeTool1.GetHistogram();
        }

        public CurveFitType GetFitType()
        {
            return this.dieAwayTimeTool1.GetCurveFitType();
        }

        public void SetFitParameters(List<double> dieAwayFitParameters, double rSquared)
        {
            this.dieAwayTimeTool1.SetFitParameters(dieAwayFitParameters, rSquared);
        }

        public double GetMinTime()
        {
            return this.dieAwayTimeTool1.GetMinTime();
        }

        public double GetMaxTime()
        {
            return this.dieAwayTimeTool1.GetMaxTime();
        }
    }
}
