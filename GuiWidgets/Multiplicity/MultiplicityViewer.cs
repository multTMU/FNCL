using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;
using Multiplicity;

namespace GuiWidgets.Multiplicity
{
    public partial class MultiplicityViewer : UserControl, IMultiplicityViewer
    {
        public event EventHandler UpdateMultiplicityViewer;
        private bool isShiftRegister;

        public MultiplicityViewer()
        {
            InitializeComponent();
            this.gateSelector1.GateTypeChanged += SelectedGateTypeChanged;
        }

        private void SelectedGateTypeChanged(object sender, EventArgs e)
        {
            isShiftRegister = (gateSelector1.GateType == MultiplicityGateType.ShiftRegister);
            ConfigureForGateType();
        }

        private void ConfigureForGateType()
        {
            if (isShiftRegister)
            {
                this.multGate.ConfigureAsShiftRegister(true);
                this.RandAHisto.Enabled = true;
            }
            else
            {
                this.multGate.ConfigureAsShiftRegister(false);
                this.RandAHisto.Enabled = false;
            }
        }

        private void bAnalyzePulseFile_Click(object sender, EventArgs e)
        {
            HandleChange(EventArgs.Empty);
        }

        protected virtual void HandleChange(EventArgs e)
        {
            EventHandler handler = this.UpdateMultiplicityViewer;
            handler?.Invoke(this, e);
        }

        public void SetDefaults(int getGate, int preDelay, int longDelay)
        {
            isShiftRegister = true;
            this.multGate.SetDefaults(getGate, preDelay, longDelay);
            this.gateSelector1.SetGateType(MultiplicityGateType.ShiftRegister);
            ConfigureForGateType();
        }

        public int GetGate()
        {
            return multGate.Gate;
        }

        public int GetPreDelay()
        {
            return multGate.PreDelay;
        }

        public int GetLongDelay()
        {
            return multGate.LongDelay;
        }

        public MultiplicityGateType GetGateType()
        {
            return gateSelector1.GateType;
        }

        public void DisplayMultiplets(double singles, double doubles, double triples)
        {
            this.displayMultiplets.SetValues(singles, doubles, triples);
        }

        public void PlotRealAccs(List<int> rAndAHisto)
        {
            this.RandAHisto.PlotHistogram(rAndAHisto);
        }

        public void PlotReals(List<int> realsHisto)
        {
            this.Rhisto.PlotHistogram(realsHisto);
        }

        public void DisplayMultipletsUncert(double singlesUncert, double doubleUncert, double triplesUncert)
        {
            this.displayMultiplets.SetUncertainties(singlesUncert, doubleUncert, triplesUncert);
        }
    }
}
