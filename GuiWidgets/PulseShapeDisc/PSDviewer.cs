using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GlobalHelpersDefaults;
using GuiInterface;

namespace GuiWidgets
{
    public partial class PSDviewer : UserControl
    {
        public event EventHandler PlotPSD;
        public event EventHandler LoadPSD;
        public event EventHandler DetectorSelectionChanged;

        public event EventHandler LaunchWaveformPSD;

        public PsdSpecification PsdSpecs =>
            new PsdSpecification
            {
                TriggerType = psdViewerEditor1.PsdType,
                Slow = psdViewerEditor1.SlowInterval,
                Trigger = psdViewerEditor1.Trigger,
                Fast = psdViewerEditor1.FastInterval,
                AmplitudeDivisor = psdViewerEditor1.AmplitudeScalar,
                PolyLine = psdCurve
            };

        public int NumberPulses => psdViewerEditor1.NumberPulses;

        public const string RANGE = START + "-" + SEP + "-" + END;
        private const string START = "[";
        private const string END = "]";
        private const string FORMAT = "e2";
        private const string SEP = ", ";
        private const string SELECTED_DETECTOR = "Editing: ";

        private double psdMin;
        private double psdMax;

        private double ampMax;
        private double ampMin;

        private double psdMinDisplay;
        private double psdMaxDisplay;

        private double ampMinDisplay;
        private double ampMaxDisplay;

        private const int AMP_INDEX = 0;
        private const int PSD_INDEX = 1;

        private bool drawingEnabled;
        private List<PsdComponent> psdCurve;
        private const int PSD_CHART = 0;
        private const int CURVE_CHART = 1;

        private DetectorKey currentDetector;

        public PSDviewer()
        {
            InitializeComponent();
            currentDetector = new DetectorKey {Panel = -1, Detector = -1};

            psdCurve = new List<PsdComponent>();
            drawingEnabled = this.drawCurve1.DrawCurveEnabled;


            InitializePsdChart();
            InitializeCurveChart();
            InitializeDetectorSelector();
            InitializeEvents();

            SetDefaultPsd();

            InitializeInputs();
        }

        private void InitializeDetectorSelector()
        {
            this.fnclDetectorButtons1.SetGroupBoxLabel("Edit PSD for Detector");
            this.labelDetector.Text = "No Detector Selected";
            this.fnclDetectorButtons1.SetIsNotEnergyCal();
        }

        private void InitializeInputs()
        {
            inputPSDmin.DataIsInteger = false;
            inputPSDmax.DataIsInteger = false;
            inputAmpMin.DataIsInteger = false;
            inputAmpMax.DataIsInteger = false;

            inputPSDmax.SetValueRaiseNoEvent(psdMaxDisplay);
            inputPSDmin.SetValueRaiseNoEvent(psdMinDisplay);

            inputAmpMax.SetValueRaiseNoEvent(ampMaxDisplay);
            inputAmpMin.SetValueRaiseNoEvent(ampMinDisplay);

            labelAmpRange.Text = RANGE;
            labelPSDrange.Text = RANGE;

            psdViewerEditor1.EnableAmplitudeScalar(true);
        }

        private void SetDefaultPsd()
        {
            psdMaxDisplay = 2.0;
            psdMinDisplay = 1.0;

            ampMinDisplay = 10;
            ampMaxDisplay = 1000;
        }

        private void InitializeEvents()
        {
            this.drawCurve1.ClearCurve += ClearPsdCurve;
            this.drawCurve1.DrawCurveChanged += DrawCurveChanged;
            this.drawCurve1.LoadCurve += LoadPsdCurve;
            this.fnclDetectorButtons1.DetectorSelected += DetectorChanged;
        }

        private void DetectorChanged(object sender, EventArgs e)
        {
            OnDetectorChanged();
        }

        private void OnDetectorChanged()
        {
            currentDetector = this.fnclDetectorButtons1.GetSelectedDetector();
            this.labelDetector.Text = SELECTED_DETECTOR + currentDetector.ToStringHuman();
            OnDetectorSelectionChanged();
        }

        public void SetPsd(PsdSpecification psdSpecification)
        {
            psdViewerEditor1.SetFromPsdSpecification(psdSpecification.Trigger, psdSpecification.Fast,
                psdSpecification.Slow, psdSpecification.TriggerType, psdSpecification.AmplitudeDivisor);
            UpdateCurve(psdSpecification.PolyLine);
        }

        private void UpdateCurve(List<PsdComponent> psdSpecificationCurve)
        {
            psdCurve = psdSpecificationCurve;
            DrawCurve();
        }

        private void LoadPsdCurve(object sender, EventArgs e)
        {
            OnLoadPsd();
        }

        private void InitializeCurveChart()
        {
            cPSD.Series.Add(new Series("Curve"));
            cPSD.Series[CURVE_CHART].ChartType = SeriesChartType.Line;
            cPSD.Series[CURVE_CHART].Color = Color.Green;
            cPSD.Series[CURVE_CHART].BorderWidth = 4;
        }

        private void InitializePsdChart()
        {
            cPSD.ChartAreas[PSD_CHART].AxisX.Title = "Amplitude";
            cPSD.ChartAreas[PSD_CHART].AxisY.Title = "PSD";
        }

        private void DrawCurveChanged(object sender, EventArgs e)
        {
            drawingEnabled = this.drawCurve1.DrawCurveEnabled;
        }

        private void ClearPsdCurve(object sender, EventArgs e)
        {
            psdCurve.Clear();
            DrawCurve();
        }

        public void SetDefaults(int fast, int slow, double amplitudeScalar, int trigger,
            PsdTriggerTypes triggerType)
        {
            psdViewerEditor1.SetDefaults(slow, fast, amplitudeScalar, trigger, triggerType);
        }

        public void Plot(List<double[]> points)
        {
            cPSD.Series[PSD_CHART].Points.Clear();
            cPSD.Series[PSD_CHART].MarkerSize = 1;
            cPSD.Series[PSD_CHART].MarkerStyle = MarkerStyle.Circle;
            ResetMinMax();
            foreach (var p in points)
            {
                double amp = p[AMP_INDEX];
                double psd = p[PSD_INDEX];
                if (validPoint(amp, psd))
                {
                    cPSD.Series[PSD_CHART].Points.AddXY(amp, psd);
                }

                UpdateMinMax(amp, psd);
            }

            SetChartAxisMinMax();
            DisplayAmpPsdRanges();
        }

        private void SetChartAxisMinMax()
        {
            cPSD.ChartAreas[PSD_CHART].AxisX.Maximum = ampMaxDisplay;
            cPSD.ChartAreas[PSD_CHART].AxisX.Minimum = ampMinDisplay;

            cPSD.ChartAreas[PSD_CHART].AxisY.Maximum = psdMaxDisplay;
            cPSD.ChartAreas[PSD_CHART].AxisY.Minimum = psdMinDisplay;
        }

        private void AddPointsToSpanPlot()
        {
            try
            {
                if (psdCurve.Count > 0)
                {
                    SortPointsToEnsureFunction();
                }
            }
            catch
            {
                // in the event this is clicked before a detector is selected
            }
        }

        private void SortPointsToEnsureFunction()
        {
            psdCurve.Sort((x, y) => x.Amplitude.CompareTo(y.Amplitude));
        }

        private void cPSD_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawingEnabled)
            {
                psdCurve.Add(TranslatePointToPlot(e.Location));
                DrawCurve();
            }
        }

        private PsdComponent TranslatePointToPlot(Point mousePoint)
        {
            return new PsdComponent
            {
                Amplitude = cPSD.ChartAreas[PSD_CHART].AxisX.PixelPositionToValue(mousePoint.X),
                PSD = cPSD.ChartAreas[PSD_CHART].AxisY.PixelPositionToValue(mousePoint.Y)
            };
        }

        private void DrawCurve()
        {
            cPSD.Series[CURVE_CHART].Points.Clear();
            AddPointsToSpanPlot();
            foreach (var p in psdCurve)
            {
                cPSD.Series[CURVE_CHART].Points.Add(new DataPoint(p.Amplitude, p.PSD));
            }
        }

        private void DisplayAmpPsdRanges()
        {
            labelAmpRange.Text = START + ampMin.ToString(FORMAT) + SEP + ampMax.ToString(FORMAT) + END;
            labelPSDrange.Text = START + psdMin.ToString(FORMAT) + SEP + psdMax.ToString(FORMAT) + END;
        }

        private void UpdateMinMax(double amp, double psd)
        {
            if (amp < ampMin)
            {
                ampMin = amp;
            }

            if (amp > ampMax)
            {
                ampMax = amp;
            }

            if (psd < psdMin)
            {
                psdMin = psd;
            }

            if (psd > psdMax)
            {
                psdMax = psd;
            }
        }

        private void ResetMinMax()
        {
            ampMax = double.MinValue;
            ampMin = double.MaxValue;

            psdMax = double.MinValue;
            psdMin = double.MaxValue;
        }

        private bool validPoint(double amp, double psd)
        {
            if (amp >= ampMinDisplay && amp <= ampMaxDisplay)
            {
                if (psd >= psdMinDisplay && psd <= psdMaxDisplay)
                {
                    return true;
                }
            }

            return false;
        }

        private void bPlotPSD_Click(object sender, EventArgs e)
        {
            PsdPlot();
        }

        private void PsdPlot()
        {
            psdMinDisplay = inputPSDmin.Value;
            psdMaxDisplay = inputPSDmax.Value;

            ampMaxDisplay = inputAmpMax.Value;
            ampMinDisplay = inputAmpMin.Value;

            HandlePlotPSD(EventArgs.Empty);
        }

        protected virtual void HandlePlotPSD(EventArgs e)
        {
            EventHandler handler = this.PlotPSD;
            handler?.Invoke(this, e);
        }

        protected virtual void OnLoadPsd()
        {
            LoadPSD?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDetectorSelectionChanged()
        {
            DetectorSelectionChanged?.Invoke(this, EventArgs.Empty);
            PsdPlot();
        }

        public void InitializePanels(int panelOne, int panelTwo, int panelThree)
        {
            this.fnclDetectorButtons1.InitializePanels(panelOne, panelTwo, panelThree);
        }

        public DetectorKey GetSelectedDetector()
        {
            return currentDetector;
        }

        private void bReload_Click(object sender, EventArgs e)
        {
            // PulseShapeDiscriminationCalibration.ReloadFromLastSaveFile()
            // could this call refresh enough?
            PulseShapeDiscriminationCalibration.RestoreLastForDetector(currentDetector);
            OnDetectorSelectionChanged();
        }

        private void bSaveAs_Click(object sender, EventArgs e)
        {
            string saveFile = MultiplicityInterfaceHelper.GetFile("Save All As...", true);
            if (!string.IsNullOrEmpty(saveFile))
            {
                PulseShapeDiscriminationCalibration.SaveCurrentPsdCalibration(saveFile);
            }
        }

        public void SetNumberOfPulses(int numberOfPulses)
        {
            psdViewerEditor1.SetNumberOfPulses(numberOfPulses);
        }

        private void bWaveForm_Click(object sender, EventArgs e)
        {
            OnLaunchWaveformPsd();
        }

        protected virtual void OnLaunchWaveformPsd()
        {
            LaunchWaveformPSD?.Invoke(this, EventArgs.Empty);
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            string loadFile = MultiplicityInterfaceHelper.GetFile("Load Psd File...", false);
            if (File.Exists(loadFile))
            {
                PulseShapeDiscriminationCalibration.LoadPsdCalibrationFromFile(loadFile, true);
            }
        }
    }
}
