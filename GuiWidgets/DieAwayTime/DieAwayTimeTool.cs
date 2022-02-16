using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Multiplicity;

namespace GuiWidgets.DieAwayTime
{
    public partial class DieAwayTimeTool : UserControl
    {
        public event EventHandler CalculateDieAwayTime;
        public event EventHandler FitDieAwayTime;

        public DieAwayTimeTool()
        {
            InitializeComponent();

            this.fitSelector1.DieAwayFitTypeChanged += FitTypeChange;
            this.histogramPlotter1.SetYaxisTitle("Occurrences");
            this.histogramPlotter1.SetXaxisTitle("Time");
            inMinTime.SetValueRaiseNoEvent(0);
            inMaxTime.SetValueRaiseNoEvent(0);

            this.inMaxTime.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
            this.inMinTime.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertTimeToNanoSeconds);
        }

        private void FitTypeChange(object sender, EventArgs e)
        {
            OnFitDieAwayTime();
        }


        private void bRun_Click(object sender, EventArgs e)
        {
            OnCalculateDieAwayTime();
        }

        public void PlotDieAway(List<double> timeIntervals)
        {
            //this.histogramPlotter1.MakeHistogramToPlotLogY(timeIntervals);
            this.histogramPlotter1.MakeHistogramToPlot(timeIntervals);
        }

        public void PlotDieAwayFit(List<Tuple<double, double>> line)
        {
            this.histogramPlotter1.PlotLineData(line);
        }

        protected virtual void OnCalculateDieAwayTime()
        {
            CalculateDieAwayTime?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFitDieAwayTime()
        {
            FitDieAwayTime?.Invoke(this, EventArgs.Empty);
        }

        public CurveFitType GetCurveFitType()
        {
            return this.fitSelector1.GetCurveFitType();
        }

        public void SetFitParameters(List<double> dieAwayFitParameters, double rSquared)
        {
            this.fitSelector1.SetFitParameters(dieAwayFitParameters, rSquared);
        }

        public double GetMinTime()
        {
            return this.inMinTime.Value;
        }

        public double GetMaxTime()
        {
            return this.inMaxTime.Value;
        }

        public List<Tuple<double, double>> GetHistogram()
        {
            return this.histogramPlotter1.GetCurrentHistogram();
        }
    }
}
