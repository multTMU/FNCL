using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class Memory : UserControl, IMPPostDetector<MPPostSpecification.Memory>
    {
        public Memory()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inFileSizeMB.UseAsDetectorVariable();
            inOverStepBuffer.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.Memory specs)
        {
            inFileSizeMB.SetDetectorVariable(specs.FileSizeMB);
            inOverStepBuffer.SetDetectorVariable(specs.OverstepBuffer);
        }

        public MPPostSpecification.Memory Get()
        {
            return new MPPostSpecification.Memory(
                MPPostSpecification.ConvertDoubleToInt(inFileSizeMB.GetDetectorVariable()),
                MPPostSpecification.ConvertDoubleToInt(inOverStepBuffer.GetDetectorVariable()));
        }
    }
}
