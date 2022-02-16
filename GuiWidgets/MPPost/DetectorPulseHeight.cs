using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class DetectorPulseHeight : UserControl, IMPPostDetector<MPPostSpecification.DetectorPulseHeight>
    {
        public DetectorPulseHeight()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inCrossTalk.UseAsDetectorVariable();
            inEnablePulseHeight.UseAsDetectorVariable();
            inSumEnergyToLight.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.DetectorPulseHeight specs)
        {
            inCrossTalk.SetDetectorVariable(specs.EliminateCrosstalkParticles);
            inEnablePulseHeight.SetDetectorVariable(specs.EnablePulseHeight);
            inSumEnergyToLight.SetDetectorVariable(specs.SumAllParticleEnergyToLight);
        }

        public MPPostSpecification.DetectorPulseHeight Get()
        {
            return new MPPostSpecification.DetectorPulseHeight(inCrossTalk.GetDetectorVariable(),
                inEnablePulseHeight.GetDetectorVariable(), inSumEnergyToLight.GetDetectorVariable());
        }
    }
}
