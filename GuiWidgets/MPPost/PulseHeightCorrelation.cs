using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class PulseHeightCorrelation : UserControl,
        IMPPostDetector<MPPostSpecification.PulseHeightCorrelation>
    {
        public PulseHeightCorrelation()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inBinSizeMeVee.UseAsDetectorVariable();
            inEnablePulseHeightCorrelation.UseAsDetectorVariable();
            inIgnoreStartDetectorPulse.UseAsDetectorVariable();
            inMaxBinMeVee.UseAsDetectorVariable();
            inMinBinMeVee.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.PulseHeightCorrelation specs)
        {
            inBinSizeMeVee.SetDetectorVariable(specs.BinIncrementMeVee);
            inEnablePulseHeightCorrelation.SetDetectorVariable(specs.EnablePulseHeightCorrelation);
            inIgnoreStartDetectorPulse.SetDetectorVariable(specs.IgnoreStartDetectorPulse);
            inMaxBinMeVee.SetDetectorVariable(specs.MaxBinMeVee);
            inMinBinMeVee.SetDetectorVariable(specs.MinBinMeVee);
        }

        public MPPostSpecification.PulseHeightCorrelation Get()
        {
            return new MPPostSpecification.PulseHeightCorrelation(inBinSizeMeVee.GetDetectorVariable(),
                inMinBinMeVee.GetDetectorVariable(), inMaxBinMeVee.GetDetectorVariable(),
                inIgnoreStartDetectorPulse.GetDetectorVariable(), inEnablePulseHeightCorrelation.GetDetectorVariable());
        }
    }
}
