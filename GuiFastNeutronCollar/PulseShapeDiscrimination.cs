using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiFastNeutronCollar
{
    public partial class PulseShapeDiscrimination : Form
    {
        public event EventHandler SendNewPsdPlot;
        public event EventHandler LoadPSD;
        public event EventHandler DetectorChanged;
        public event EventHandler LaunchPsdWaveformViewer;
        public event EventHandler PsdFormClosing;

        public int NumberPulses => this.psDviewer1.NumberPulses;
        public PsdSpecification PsdSpecification => this.psDviewer1.PsdSpecs;

        public PulseShapeDiscrimination()
        {
            InitializeComponent();
            this.psDviewer1.PlotPSD += UpdatePsdPlot;
            this.psDviewer1.LoadPSD += HandleLoadPsd;
            this.psDviewer1.LaunchWaveformPSD += HandleLaunchWaveformViewer;
            this.psDviewer1.DetectorSelectionChanged += HandleDetectorChanged;
        }

        private void HandleLaunchWaveformViewer(object sender, EventArgs e)
        {
            OnLaunchPsdWaveformViewer();
        }

        private void HandleDetectorChanged(object sender, EventArgs e)
        {
            OnDetectorChanged();
        }

        private void HandleLoadPsd(object sender, EventArgs e)
        {
            OnLoadPsd();
        }

        private void UpdatePsdPlot(object sender, EventArgs e)
        {
            HandlePsdPlotChange(EventArgs.Empty);
        }

        protected virtual void HandlePsdPlotChange(EventArgs e)
        {
            EventHandler handler = this.SendNewPsdPlot;
            handler?.Invoke(this, e);
        }

        public void SetDefaults(int fast, int slow, double amplitudeScalar, int trigger,
            PsdTriggerTypes triggerType)
        {
            this.psDviewer1.SetDefaults(fast, slow, amplitudeScalar, trigger, triggerType);
        }

        public void Plot(List<double[]> psd)
        {
            this.psDviewer1.Plot(psd);
        }

        protected virtual void OnLoadPsd()
        {
            LoadPSD?.Invoke(this, EventArgs.Empty);
        }

        public void SetPsd(PsdSpecification psdSpecification)
        {
            psDviewer1.SetPsd(psdSpecification);
        }

        protected virtual void OnDetectorChanged()
        {
            DetectorChanged?.Invoke(this, EventArgs.Empty);
        }

        public void InitializePanels(int panelOne, int panelTwo, int panelThree)
        {
            this.psDviewer1.InitializePanels(panelOne, panelTwo, panelThree);
        }

        public DetectorKey GetSelectedDetector()
        {
            return this.psDviewer1.GetSelectedDetector();
        }

        public void SetMaxNumberOfPulses(int numberOfPulses)
        {
            this.psDviewer1.SetNumberOfPulses(numberOfPulses);
        }

        protected virtual void OnLaunchPsdWaveformViewer()
        {
            LaunchPsdWaveformViewer?.Invoke(this, EventArgs.Empty);
        }

        private void PulseShapeDiscrimination_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnPsdFormClosing();
        }

        protected virtual void OnPsdFormClosing()
        {
            PsdFormClosing?.Invoke(this, EventArgs.Empty);
        }
    }
}
