using System;
using System.Windows.Forms;
using Multiplicity;

namespace GuiWidgets.Multiplicity
{
    public partial class GateSelector : UserControl
    {
        public event EventHandler GateTypeChanged;
        private MultiplicityGateType gateType;
        public MultiplicityGateType GateType => gateType;

        public GateSelector()
        {
            InitializeComponent();
        }

        private void rbShift_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShift.Checked)
            {
                gateType = MultiplicityGateType.ShiftRegister;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbSeq_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSeq.Checked)
            {
                gateType = MultiplicityGateType.Sequential;
                HandleChange(EventArgs.Empty);
            }
        }

        private void rbTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTrigger.Checked)
            {
                gateType = MultiplicityGateType.TriggeredNotShift;
                HandleChange(EventArgs.Empty);
            }
        }

        protected virtual void HandleChange(EventArgs e)
        {
            EventHandler handler = this.GateTypeChanged;
            handler?.Invoke(this, e);
        }

        public void SetGateType(MultiplicityGateType typeOfGate)
        {
            switch (typeOfGate)
            {
                case MultiplicityGateType.Sequential:
                    rbSeq.Checked = true;
                    break;
                case MultiplicityGateType.TriggeredNotShift:
                    rbTrigger.Checked = true;
                    break;
                case MultiplicityGateType.ShiftRegister:
                    rbShift.Checked = true;
                    break;
                default:
                    rbShift.Checked = true;
                    break;
            }
        }
    }
}
