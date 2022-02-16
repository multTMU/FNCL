using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class PulseGeneration : UserControl,
        IMPPostDetector<MPPostSpecification.PulseGenerationTimeNanoSeconds>
    {
        public PulseGeneration()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        public MPPostSpecification.PulseGenerationTimeNanoSeconds Get()
        {
            return new MPPostSpecification.PulseGenerationTimeNanoSeconds(inCaF2.GetDetectorVariable(),
                inLaBr3.GetDetectorVariable(), inNaI.GetDetectorVariable(), inOrganicLiquid.GetDetectorVariable(),
                inOrganicPlastic.GetDetectorVariable());
        }

        public void Set(MPPostSpecification.PulseGenerationTimeNanoSeconds specs)
        {
            inOrganicPlastic.SetDetectorVariable(specs.OrganicPlastic);
            inNaI.SetDetectorVariable(specs.NaI);
            inOrganicLiquid.SetDetectorVariable(specs.OrganicLiquid);
            inCaF2.SetDetectorVariable(specs.CaF2);
            inLaBr3.SetDetectorVariable(specs.LaBr3);
        }

        private void EnableAllAsDetectorVariables()
        {
            inCaF2.UseAsDetectorVariable();
            inLaBr3.UseAsDetectorVariable();
            inNaI.UseAsDetectorVariable();
            inOrganicLiquid.UseAsDetectorVariable();
            inOrganicPlastic.UseAsDetectorVariable();
        }
    }
}
