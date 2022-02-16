using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.PulseAmplitude
{
    public partial class PulseAmpPlotter : UserControl
    {
        public event EventHandler PadAmplitudeChanged;

        private PulseAmplitudeType amplitudeType;

        private PlotScaleType VerticalScale;
        private PlotScaleType HorizontalScale;

        public PulseAmpPlotter()
        {
            InitializeComponent();
            this.histogramPlotter1.SetXaxisTitle(" ");
            this.histogramPlotter1.SetYaxisTitle(" ");

            this.scaleHorizontal.SetGroupBoxLabel("Horizontal");
            this.scaleVertical.SetGroupBoxLabel("Vertical");

            this.scaleHorizontal.SetInitial(PlotScaleType.Linear);
            this.scaleVertical.SetInitial(PlotScaleType.Log);

            this.scaleHorizontal.ScaleChanged += ScaleChanged;
            this.scaleVertical.ScaleChanged += ScaleChanged;
            UpdatePlotScales();
        }

        private void ScaleChanged(object sender, EventArgs e)
        {
            OnPadAmplitudeChanged();
        }

        private void UpdatePlotScales()
        {
            VerticalScale = this.scaleVertical.GetPlotScale();
            HorizontalScale = this.scaleHorizontal.GetPlotScale();
        }

        public PulseAmplitudeType GetAmplitudeType()
        {
            return amplitudeType;
        }

        public void Plot(List<double> padPlot)
        {
            this.histogramPlotter1.MakeHistogramToPlot(padPlot, VerticalScale, HorizontalScale);
        }

        private void rbADC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbADC.Checked)
            {
                amplitudeType = PulseAmplitudeType.ADC;
                OnPadAmplitudeChanged();
            }
        }

        private void rbEnergy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnergy.Checked)
            {
                amplitudeType = PulseAmplitudeType.KeVee;
                OnPadAmplitudeChanged();
            }
        }

        protected virtual void OnPadAmplitudeChanged()
        {
            UpdatePlotScales();
            SetAxisLabels();
            PadAmplitudeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetAxisLabels()
        {
            this.histogramPlotter1.SetXaxisTitle(GetAmpString());
            this.histogramPlotter1.SetYaxisTitle(GetScalePrefix(VerticalScale) + "Occurrences");
        }

        private string GetAmpString()
        {
            string scalePrefix = GetScalePrefix(HorizontalScale);

            if (amplitudeType == PulseAmplitudeType.KeVee)
            {
                return scalePrefix + "KeVee";
            }
            else
            {
                return scalePrefix + "ADC";
            }
        }

        private static string GetScalePrefix(PlotScaleType scale)
        {
            switch (scale)
            {
                case PlotScaleType.Log:
                    return "Log ";
                case PlotScaleType.Linear:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}
