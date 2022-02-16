using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GlobalHelpersDefaults;
using GuiInterface;
using GuiWidgets.PileUpRejector;
using GuiWidgets.PulseShapeDisc;
using GuiWidgets.Waveform;

namespace GuiWidgets
{
    public partial class WaveFormViewer : UserControl
    {
        public event EventHandler PulseIndexChanged;

        public int PulseIndex { get; private set; }
        private int LastPulse;
        private const int FIRST_PULSE = 0;
        private const int INVALID_PULSE = -1;
        private int timeStep;
        private List<int> pulse;
        private bool persist;

        private const int WAVE_SERIES = 0;
        private const int SLOW_SERIES = 1;
        private const int FAST_SERIES = 2;
        private const int TRIGGER_SERIES = 3;
        private const int MARKER_SIZE = 5;
        private IWaveformWidget widget;

        public WaveFormViewer()
        {
            InitializeComponent();
            timeStep = 2;
            PulseIndex = INVALID_PULSE;
            persist = false;
            cbPersist.Checked = persist;
            chartWave.ChartAreas[0].AxisX.Title = "Time (ns)";
            chartWave.ChartAreas[0].AxisY.Title = "ADC (arb)";
            chartWave.Series[WAVE_SERIES].BorderWidth = 2;
            chartWave.Series[WAVE_SERIES].Color = Color.Black;
            widget = new NoWaveWidget();
        }

        public void SetNumberOfPulses(int nPulses)
        {
            LastPulse = nPulses - 1;
            tbNumberPulses.Text = LastPulse.ToString();
        }

        public void SetTimeStep(int TimeStep)
        {
            timeStep = TimeStep;
        }

        private void IncreasePulse()
        {
            int testPulse = PulseIndex + 1;
            SetNewPulseIndex(((testPulse > LastPulse) ? FIRST_PULSE : testPulse));
        }

        private void DecreasePulse()
        {
            int testPulse = PulseIndex - 1;
            SetNewPulseIndex(((testPulse < FIRST_PULSE) ? LastPulse : testPulse));
        }

        private void bDecrease_Click(object sender, EventArgs e)
        {
            DecreasePulse();
        }

        private void bIncrease_Click(object sender, EventArgs e)
        {
            IncreasePulse();
        }

        private bool PulseIsInRange(int testPulse)
        {
            return (testPulse >= FIRST_PULSE) && (testPulse <= LastPulse);
        }

        private void tbCurrentPulse_Validated(object sender, EventArgs e)
        {
            CheckEnteredIndex();
        }

        private void CheckEnteredIndex()
        {
            int testPulse = MultiplicityInterfaceHelper.ValidateInt(tbCurrentPulse.Text, INVALID_PULSE);
            if (PulseIsInRange(testPulse))
            {
                SetNewPulseIndex(testPulse);
            }
        }

        private void SetNewPulseIndex(int newIndex)
        {
            if (PulseIndex != newIndex && newIndex >= 0)
            {
                PulseIndex = newIndex;
                OnPulseIndexChanged();
                tbCurrentPulse.Text = PulseIndex.ToString();
            }
        }

        public void SetPulseWaveForm(List<int> PulseWaveForm)
        {
            pulse = PulseWaveForm;
            PlotPulse();
        }

        private void PlotPulse()
        {
            if (!persist)
            {
                ClearPoints();
            }

            int t = 0;
            foreach (var p in pulse)
            {
                chartWave.Series[WAVE_SERIES].Points.AddXY(t, p);
                t += timeStep;
            }
        }

        private void tbCurrentPulse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CheckEnteredIndex();
            }
        }

        private void cbPersist_CheckedChanged(object sender, EventArgs e)
        {
            persist = cbPersist.Checked;
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            ClearPoints();
        }

        private void ClearPoints()
        {
            chartWave.Series[WAVE_SERIES].Points.Clear();
        }

        public void ConfigureForPSD()
        {
            panel1.Controls.Clear();
            widget = new PsdWaveformResults();
            panel1.Controls.Add(widget as Control);

            DisablePersistance();

            InitialzeSlowSeries();
            InitializeFastSeries();
            InitializeTriggerSeries();
        }

        private void DisablePersistance()
        {
            cbPersist.Enabled = false;
            persist = false;
        }

        public void ConfigureForPileUp()
        {
            panel1.Controls.Clear();
            widget = new PileUpWaveform();
            panel1.Controls.Add(widget as Control);
            widget.Recalculate += RecalculateForPulse;
            DisablePersistance();
        }

        private void RecalculateForPulse(object sender, EventArgs e)
        {
            OnPulseIndexChanged();
        }

        public double GetPileUpScalar()
        {
            return widget.GetScalar();
        }

        public double GetPileUpInterval()
        {
            return widget.GetInterval();
        }

        public void SesIsPileUp(bool state)
        {
            widget.SetIsPileUp(state);
        }

        public void SetRejector(double scalar, double interval)
        {
            widget.SetRejector(scalar, interval);
        }

        private void InitializeTriggerSeries()
        {
            chartWave.Series.Add("Trigger");
            chartWave.Series[TRIGGER_SERIES].ChartType = SeriesChartType.Line;
            chartWave.Series[TRIGGER_SERIES].Color = Color.Red;
            chartWave.Series[TRIGGER_SERIES].BorderWidth = MARKER_SIZE;
        }

        private void InitializeFastSeries()
        {
            chartWave.Series.Add("Fast");
            chartWave.Series[FAST_SERIES].ChartType = SeriesChartType.Line;
            chartWave.Series[FAST_SERIES].Color = Color.Green;
            chartWave.Series[FAST_SERIES].BorderWidth = MARKER_SIZE;
        }

        private void InitialzeSlowSeries()
        {
            chartWave.Series.Add("Slow");
            chartWave.Series[SLOW_SERIES].ChartType = SeriesChartType.Line;
            chartWave.Series[SLOW_SERIES].Color = Color.Blue;
            chartWave.Series[SLOW_SERIES].BorderWidth = MARKER_SIZE;
        }

        public void PlotPsdWaveform(PsdWaveformGui psdPulseWaveform)
        {
            widget.SetResults(psdPulseWaveform.PSD.PSD, psdPulseWaveform.PSD.Amplitude,
                psdPulseWaveform.PsdParticle.ToString());
            SetPulseWaveForm(psdPulseWaveform.Waveform);

            PlotFastSeries(psdPulseWaveform);
            PlotSlowSeries(psdPulseWaveform);
            PlotTriggerSeries(psdPulseWaveform);
        }

        private void PlotTriggerSeries(PsdWaveformGui psdPulseWaveform)
        {
            chartWave.Series[TRIGGER_SERIES].Points.Clear();
            chartWave.Series[TRIGGER_SERIES].Points.AddXY(psdPulseWaveform.TriggerTime, 0);
            chartWave.Series[TRIGGER_SERIES].Points
                .AddXY(psdPulseWaveform.TriggerTime, psdPulseWaveform.Waveform.Min());
        }

        private void PlotSlowSeries(PsdWaveformGui psdPulseWaveform)
        {
            chartWave.Series[SLOW_SERIES].Points.Clear();
            chartWave.Series[SLOW_SERIES].Points.AddXY(psdPulseWaveform.SlowTimeLow, 0);
            chartWave.Series[SLOW_SERIES].Points.AddXY(psdPulseWaveform.SlowTimeHigh, 0);
        }

        private void PlotFastSeries(PsdWaveformGui psdPulseWaveform)
        {
            chartWave.Series[FAST_SERIES].Points.Clear();
            chartWave.Series[FAST_SERIES].Points.AddXY(psdPulseWaveform.FastTimeLow, 0);
            chartWave.Series[FAST_SERIES].Points.AddXY(psdPulseWaveform.FastTimeHigh, 0);
        }

        protected virtual void OnPulseIndexChanged()
        {
            PulseIndexChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
