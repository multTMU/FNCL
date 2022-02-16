using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GuiInterface;
using MathNet.Numerics.Statistics;

namespace GuiWidgets
{
    public partial class HistogramPlotter : UserControl
    {
        private List<Tuple<double, double>> histogramPlot;
        private const int HISTOGRAM = 0;
        private const int LINE = 1;
        private const int MAX_BINS = 100;
        private const string AXIS_NUMBER_FORMAT = "G3";

        public HistogramPlotter()
        {
            InitializeComponent();
            histogramPlot = new List<Tuple<double, double>>();

            chartHistogram.Series.Add(new Series("line"));
            chartHistogram.Series[LINE].ChartType = SeriesChartType.Line;

            chartHistogram.ChartAreas[HISTOGRAM].AxisX.Title = "Number in Gate";
            chartHistogram.ChartAreas[HISTOGRAM].AxisY.Title = "Log Occurrences";

            // 
            chartHistogram.ChartAreas[HISTOGRAM].AxisX.LabelStyle.Format = AXIS_NUMBER_FORMAT;
            chartHistogram.ChartAreas[HISTOGRAM].AxisY.LabelStyle.Format = AXIS_NUMBER_FORMAT;
        }

        public void SetXaxisTitle(string axis)
        {
            chartHistogram.ChartAreas[HISTOGRAM].AxisX.Title = axis;
        }

        public void SetYaxisTitle(string axis)
        {
            chartHistogram.ChartAreas[HISTOGRAM].AxisY.Title = axis;
        }

        public void MakeHistogramToPlot(List<double> values, PlotScaleType verticalScale, PlotScaleType horizontalScale)
        {
            if (verticalScale == PlotScaleType.Linear && horizontalScale == PlotScaleType.Linear)
            {
                MakeHistogramToPlot(values);
            }
            else if (verticalScale == PlotScaleType.Linear && horizontalScale == PlotScaleType.Log)
            {
                MakeHistogramToPlotLogX(values);
            }
            else if (verticalScale == PlotScaleType.Log && horizontalScale == PlotScaleType.Linear)
            {
                MakeHistogramToPlotLogY(values);
            }
            else if (verticalScale == PlotScaleType.Log && horizontalScale == PlotScaleType.Log)
            {
                MakeHistogramToPlotLogLog(values);
            }
        }

        public void MakeHistogramToPlot(List<double> values)
        {
            MakeHistorgram(values, false, false);
        }

        public void MakeHistogramToPlotLogY(List<double> values)
        {
            MakeHistorgram(values, false, true);
        }

        private void MakeHistorgram(List<double> values, bool logX, bool logY)
        {
            if (values.Count > 0)
            {
                histogramPlot.Clear();
                chartHistogram.Series[HISTOGRAM].Points.Clear();
                Histogram histo = GetHistogram(values, logX);

                for (int i = 0; i < histo.BucketCount; i++)
                {
                    double x = GetBinMidPoint(histo[i]);
                    double y = logY ? MultiplicityInterfaceHelper.GetPlotSafeLog(histo[i].Count) : histo[i].Count;

                    histogramPlot.Add(new Tuple<double, double>(x, y));
                    chartHistogram.Series[HISTOGRAM].Points.AddXY(x, y);
                }

                chartHistogram.ChartAreas[HISTOGRAM].AxisX.Minimum = histogramPlot.First().Item1;
                chartHistogram.ChartAreas[HISTOGRAM].AxisX.Maximum = histogramPlot.Last().Item1;
            }
        }

        public void PlotLineData(List<Tuple<double, double>> line)
        {
            chartHistogram.Series[LINE].Points.Clear();
            chartHistogram.Series[LINE].ChartType = SeriesChartType.Line;
            chartHistogram.Series[LINE].BorderWidth = 5;

            foreach (var p in line)
            {
                chartHistogram.Series[LINE].Points.AddXY(p.Item1, p.Item2);
            }
        }

        public void MakeHistogramToPlotLogX(List<double> values)
        {
            MakeHistorgram(values, true, false);
        }

        public void MakeHistogramToPlotLogLog(List<double> values)
        {
            MakeHistorgram(values, true, true);
        }

        private double GetBinMidPoint(Bucket bucket)
        {
            return (bucket.LowerBound + bucket.UpperBound) / 2.0;
        }

        private static Histogram GetHistogram(List<double> values, bool logX)
        {
            try
            {
                if (logX)
                {
                    List<double> logValues = new List<double>();
                    foreach (var v in values)
                    {
                        logValues.Add(MultiplicityInterfaceHelper.GetPlotSafeLog(v));
                    }

                    values = logValues;
                }

                return new Histogram(values, GetNumberOfBins(values));
            }
            catch
            {
                return new Histogram();
            }
        }

        public List<Tuple<double, double>> GetCurrentHistogram()
        {
            return histogramPlot;
        }

        private static int GetNumberOfBins(List<double> values)
        {
            int nBins = (int)Math.Ceiling(Math.Sqrt(values.Count)) + 2;
            if (nBins > MAX_BINS)
            {
                return MAX_BINS;
            }

            return nBins;
        }

        public void PlotHistogram(List<double> histogram)
        {
            chartHistogram.Series[HISTOGRAM].Points.Clear();
            int n = 0;
            foreach (var h in histogram)
            {
                chartHistogram.Series[0].Points.AddXY(n, MultiplicityInterfaceHelper.GetPlotSafeLog(h));
                n++;
            }
        }


        public void PlotHistogram(List<int> histogram)
        {
            chartHistogram.Series[HISTOGRAM].Points.Clear();
            int n = 0;
            foreach (var h in histogram)
            {
                chartHistogram.Series[HISTOGRAM].Points.AddXY(n, MultiplicityInterfaceHelper.GetPlotSafeLog(h));
                n++;
            }
        }

        private void chartHistogram_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string saveFile = MultiplicityInterfaceHelper.GetFile("Save to (png) ...", true);
                if (!string.IsNullOrEmpty(saveFile))
                {
                    saveFile = Path.ChangeExtension(saveFile, "png");
                    chartHistogram.SaveImage(saveFile, ChartImageFormat.Png);
                }
            }
        }
    }
}
