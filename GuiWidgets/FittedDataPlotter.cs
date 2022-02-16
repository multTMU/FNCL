using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GuiWidgets
{
    public partial class FittedDataPlotter : UserControl
    {
        private const string RAW = "RAW";
        private const string FIT = "FIT";

        public FittedDataPlotter()
        {
            InitializeComponent();
            this.fittedData.Series.Add(RAW);
            this.fittedData.Series.Add(FIT);
        }

        public void SetXaxisLabel(string axisLabel)
        {
            this.fittedData.ChartAreas[0].AxisX.Title = axisLabel;
        }

        public void SetYaxisLabel(string axisLabel)
        {
            this.fittedData.ChartAreas[0].AxisY.Title = axisLabel;
        }

        public void PlotFittedData(double[] xValues, double[] yValues)
        {
            AddPlotData(FIT, xValues, yValues);
        }

        private void AddPlotData(string dataName, double[] xValues, double[] yValues)
        {
            this.fittedData.Series[dataName].Points.Clear();

            foreach (var p in GetPointCollection(xValues, yValues))
            {
                this.fittedData.Series[dataName].Points.Add(p);
            }
        }

        private static List<DataPoint> GetPointCollection(double[] xValues, double[] yValues)
        {
            List<DataPoint> points = new List<DataPoint>();
            for (int i = 0; i < xValues.Length; i++)
            {
                points.Add(new DataPoint(xValues[i], yValues[i]));
            }

            return points;
        }

        public void PlotRawData(double[] xValues, double[] yValues)
        {
            AddPlotData(RAW, xValues, yValues);
        }
    }
}
