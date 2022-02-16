using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class TimeResolution : UserControl, IMPPostDetector<MPPostSpecification.TimeResolution>
    {
        public TimeResolution()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        public MPPostSpecification.TimeResolution Get()
        {
            return new MPPostSpecification.TimeResolution(inOrganicPlasticFwhm.GetDetectorVariable(),
                inOrganicLiquidFwhm.GetDetectorVariable(), inCaF2Fwhm.GetDetectorVariable(),
                inLaBr3Fwhm.GetDetectorVariable(), inNaIFwhm.GetDetectorVariable(),
                inEnableTimeBroadening.GetDetectorVariable());
        }

        public void Set(MPPostSpecification.TimeResolution specs)
        {
            inCaF2Fwhm.SetDetectorVariable(specs.CaF2_FWHM);
            inEnableTimeBroadening.SetDetectorVariable(specs.EnableTimeBroadening);
            inLaBr3Fwhm.SetDetectorVariable(specs.LaBr3_FWHM);
            inNaIFwhm.SetDetectorVariable(specs.NaI_FWHM);
            inOrganicLiquidFwhm.SetDetectorVariable(specs.OrganicLiquid_FWHM);
            inOrganicPlasticFwhm.SetDetectorVariable(specs.OrganicPlastic_FWHM);
        }

        private void EnableAllAsDetectorVariables()
        {
            inOrganicPlasticFwhm.UseAsDetectorVariable();
            inOrganicLiquidFwhm.UseAsDetectorVariable();
            inCaF2Fwhm.UseAsDetectorVariable();
            inLaBr3Fwhm.UseAsDetectorVariable();
            inNaIFwhm.UseAsDetectorVariable();
            inEnableTimeBroadening.UseAsDetectorVariable();
        }
    }
}
