using System;
using System.Windows.Forms;
using GlobalHelpers;

namespace GuiFastNeutronCollar
{
    public partial class FuelSpecsEditor : Form
    {
        public event EventHandler UpdatedFuelSpecs;
        private bool specsChanged;

        public FuelSpecsEditor()
        {
            InitializeComponent();
            specsChanged = false;
        }

        public void SetSpecs(FuelAssemblySpecification fuelAssemblySpecs)
        {
            this.fuelAssemblySpecs1.SetSpecs(fuelAssemblySpecs);
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            specsChanged = true;
            Close();
        }

        public FuelAssemblySpecification GetSpecs()
        {
            return this.fuelAssemblySpecs1.GetSpecs();
        }

        protected virtual void HandleSubmit()
        {
            EventHandler handler = this.UpdatedFuelSpecs;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void FuelSpecsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (specsChanged)
            {
                HandleSubmit();
            }
        }
    }
}
