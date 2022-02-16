using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class DeadTime : UserControl, IMPPostDetector<MPPostSpecification.DeadTimeNanoSeconds>
    {
        public DeadTime()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inCaF2.UseAsDetectorVariable();
            inHistoBinMeVee.UseAsDetectorVariable();
            inHistoEndMeVee.UseAsDetectorVariable();
            inHistoStartMeVee.UseAsDetectorVariable();
            inLaBr3.UseAsDetectorVariable();
            inNaI.UseAsDetectorVariable();
            inOrganicLiquid.UseAsDetectorVariable();
            inOrganicPlastic.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.DeadTimeNanoSeconds specs)
        {
            inCaF2.SetDetectorVariable(specs.CaF2);
            inHistoBinMeVee.SetDetectorVariable(specs.BinStepMeVee);
            inHistoEndMeVee.SetDetectorVariable(specs.HistogramEndMeVee);
            inHistoStartMeVee.SetDetectorVariable(specs.HistogramStartMeVee);
            inLaBr3.SetDetectorVariable(specs.LaBr3);
            inNaI.SetDetectorVariable(specs.NaI);
            inOrganicLiquid.SetDetectorVariable(specs.OrganicLiquid);
            inOrganicPlastic.SetDetectorVariable(specs.OrganicPlastic);
        }

        public MPPostSpecification.DeadTimeNanoSeconds Get()
        {
            return new MPPostSpecification.DeadTimeNanoSeconds(inCaF2.GetDetectorVariable(),
                inHistoBinMeVee.GetDetectorVariable(),
                MPPostSpecification.ConvertDoubleToInt(inHistoEndMeVee.GetDetectorVariable()),
                MPPostSpecification.ConvertDoubleToInt(inHistoStartMeVee.GetDetectorVariable()),
                inLaBr3.GetDetectorVariable(), inNaI.GetDetectorVariable(), inOrganicLiquid.GetDetectorVariable(),
                inOrganicPlastic.GetDetectorVariable());
        }
    }
}
