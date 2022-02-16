using System;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.PulseAmplitude
{
    public partial class LogVsLinear : UserControl
    {
        public event EventHandler ScaleChanged;
        private bool allowEvents;

        public LogVsLinear()
        {
            InitializeComponent();
            allowEvents = true;
        }

        public void SetGroupBoxLabel(string labelNew)
        {
            groupBox1.Text = labelNew;
        }

        public PlotScaleType GetPlotScale()
        {
            return (rbLinear.Checked ? PlotScaleType.Linear : PlotScaleType.Log);
        }

        public void SetInitial(PlotScaleType scale)
        {
            allowEvents = false;
            switch (scale)
            {
                case PlotScaleType.Log:
                    rbLog.Checked = true;
                    break;
                case PlotScaleType.Linear:
                    rbLinear.Checked = true;
                    break;
                default:
                    rbLinear.Checked = true;
                    break;
            }

            allowEvents = true;
        }

        private void rbLog_CheckedChanged(object sender, EventArgs e)
        {
            OnScaleChanged();
        }

        protected virtual void OnScaleChanged()
        {
            if (allowEvents)
            {
                ScaleChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
