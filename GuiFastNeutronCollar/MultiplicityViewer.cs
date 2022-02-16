using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class MultiplicityViewer : Form
    {
        public event EventHandler UpdateMultiplicityViewer;

        public MultiplicityViewer()
        {
            InitializeComponent();
            this.multiplicityViewer1.UpdateMultiplicityViewer += RaiseUpdateMultiplicityViewer;
        }

        private void RaiseUpdateMultiplicityViewer(object sender, EventArgs e)
        {
            HandleChange(EventArgs.Empty);
        }

        public void SetDefaultGates(int gate, int preDelay, int longDelay)
        {
            multiplicityViewer1.SetDefaults(gate, preDelay, longDelay);
        }

        protected virtual void HandleChange(EventArgs e)
        {
            EventHandler handler = this.UpdateMultiplicityViewer;
            handler?.Invoke(this, e);
        }

        public IMultiplicityViewer GetMultiplicityGate()
        {
            return multiplicityViewer1;
        }

        internal void PlotRealAccs(List<int> histo)
        {
            this.multiplicityViewer1.PlotRealAccs(histo);
        }

        public void PlotReals(List<int> histo)
        {
            this.multiplicityViewer1.PlotReals(histo);
        }

        public void DisplayMultiplets(double S, double D, double T)
        {
            this.multiplicityViewer1.DisplayMultiplets(S, D, T);
        }

        public void DisplayMultipletsUncert(double SUnc, double DUnc, double TUnc)
        {
            this.multiplicityViewer1.DisplayMultipletsUncert(SUnc, DUnc, TUnc);
        }
    }
}
