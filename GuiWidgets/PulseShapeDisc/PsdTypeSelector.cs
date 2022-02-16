using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets.PulseShapeDisc
{
    public partial class PsdTypeSelector : UserControl
    {
        public event EventHandler PsdTypeChanged;

        public PsdTriggerTypes PsdType { get; private set; }

        public PsdTypeSelector()
        {
            InitializeComponent();
        }

        protected virtual void HandleChange(EventArgs e)
        {
            EventHandler handler = this.PsdTypeChanged;
            handler?.Invoke(this, e);
        }

        private void rbFixed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFixed.Checked)
            {
                PsdType = PsdTriggerTypes.Fixed;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbOffset_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOffset.Checked)
            {
                PsdType = PsdTriggerTypes.PeakOffset;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbHeight_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHeight.Checked)
            {
                PsdType = PsdTriggerTypes.PeakHeight;
                HandleChange(EventArgs.Empty);
            }
        }

        public void SetSelectedPSD(PsdTriggerTypes psdType)
        {
            switch (psdType)
            {
                case PsdTriggerTypes.Fixed:
                    rbFixed.Checked = true;
                    break;
                case PsdTriggerTypes.PeakOffset:
                    rbOffset.Checked = true;
                    break;
                case PsdTriggerTypes.PeakHeight:
                    rbHeight.Checked = true;
                    break;
                default:
                    rbOffset.Checked = true;
                    break;
            }
        }
    }
}
