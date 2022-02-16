using System.Windows.Forms;
using GlobalHelpersDefaults;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class CaptureEvents : UserControl, IMPPostDetector<MPPostSpecification.CaptureEvents>
    {
        public CaptureEvents()
        {
            InitializeComponent();
            inSortMaterial.DataIsInteger = true;
            inSortInteraction.DataIsInteger = true;
            inParticle.SetEnum(EnumGuiHelpers.GetParticles());
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inParticle.UseAsDetectorVariable();
            inSortInteraction.UseAsDetectorVariable();
            inSortMaterial.UseAsDetectorVariable();
            inPrintSortedEvent.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.CaptureEvents specs)
        {
            inSortMaterial.SetDetectorVariable(specs.SortMaterial);
            inParticle.SetDetectorVariable(EnumGuiHelpers.ConvertDetectorVariableEnumToInt(specs.SortParticleType));
            inSortInteraction.SetDetectorVariable(specs.SortInteraction);
            inPrintSortedEvent.SetDetectorVariable(specs.PrintSortedEventFile);
        }

        public MPPostSpecification.CaptureEvents Get()
        {
            return new MPPostSpecification.CaptureEvents(
                EnumGuiHelpers.ConvertDetectorVariableBaseIntToEnum<Particle>(inParticle.GetDetectorVariable()),
                MPPostSpecification.ConvertDoubleToInt(inSortMaterial.GetDetectorVariable()),
                MPPostSpecification.ConvertDoubleToInt(inSortInteraction.GetDetectorVariable()),
                inPrintSortedEvent.GetDetectorVariable());
        }
    }
}
