using System;
using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class LightResolution : UserControl, IMPPostDetector<MPPostSpecification.LightResolution>
    {
        public LightResolution()
        {
            InitializeComponent();
        }

        public void Set(MPPostSpecification.LightResolution specs)
        {
            inOrganicLiquidPhoton.SetDetectorVariable(specs.OrganicLiquidPhoton);
            inOrganicLiquidNeutron.SetDetectorVariable(specs.OrganicLiquidNeutron);
            inNaI.SetDetectorVariable(specs.NaI);
            inCaF2.SetDetectorVariable(specs.CaF2);
            inEnableLightResolution.SetDetectorVariable(specs.EnableLightResolution);
            inLaBr3AboveTenthMeVee.SetDetectorVariable(specs.LaBr3SupTenthMeVee);
            inLaBr3BelowTenthMeVee.SetDetectorVariable(specs.LaBr3SubTenthMeVee);
            inOrganicPlasticNeutron.SetDetectorVariable(specs.OrganicPlasticNeutron);
            inOrganicPlasticPhoton.SetDetectorVariable(specs.OrganicPlasticPhoton);
        }

        public MPPostSpecification.LightResolution Get()
        {
            return new MPPostSpecification.LightResolution(inOrganicLiquidPhoton.GetDetectorVariable(),
                inOrganicLiquidNeutron.GetDetectorVariable(), inNaI.GetDetectorVariable(), inCaF2.GetDetectorVariable(),
                inEnableLightResolution.GetDetectorVariable(), inLaBr3AboveTenthMeVee.GetDetectorVariable(),
                inLaBr3BelowTenthMeVee.GetDetectorVariable(), inOrganicPlasticNeutron.GetDetectorVariable(),
                inOrganicPlasticPhoton.GetDetectorVariable());
        }
    }
}
