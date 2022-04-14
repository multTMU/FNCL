using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class DetectorInformation : UserControl, IMPPostDetector<MPPostSpecification.DetectorInformation>
    {
        public DetectorInformation()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
            inDetectorType.SetEnum(EnumGuiHelpers.GetMPPostDetectorTypes());
        }

        private void EnableAllAsDetectorVariables()
        {
            inAnalyzeByTimeNotHistory.UseAsDetectorVariable();
            inDetectorCells.UseAsDetectorVariable();
            inDetectorType.UseAsDetectorVariable();
            inLLDMeV.UseAsDetectorVariable();
            inULDMeV.UseAsDetectorVariable();
            inMcnpNPS.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.DetectorInformation specs)
        {
            //inAnalyzeByTimeNotHistory.SetDetectorVariable(specs.AnalyzeByTimeNotHistory);
            //inDetectorCells.SetDetectorVariable(MPPostSpecification.DetectorInformation.ToGroupedList(specs.DetectorCells));
            //inDetectorType.SetDetectorVariable(EnumGuiHelpers.ConvertDetectorVariableEnumToInt<MPPostDetectorTypes>(specs.DetectorTypes));
            //inULDMeV.SetDetectorVariable(MPPostSpecification.ToList(specs.UpperThresholdMeVee));
            //inLLDMeV.SetDetectorVariable(MPPostSpecification.ToList(specs.LowerThresholdMeVee));
            //inMcnpNPS.SetDetectorVariable(specs.McnpNps);
        }

        public MPPostSpecification.DetectorInformation Get()
        {
            return new MPPostSpecification.DetectorInformation();
            //return new MPPostSpecification.DetectorInformation(inAnalyzeByTimeNotHistory.GetDetectorVariable(),
            //    inDetectorCells.GetDetectorVariable(), inDetectorType.GetDetectorVariable(),
            //    inLLDMeV.GetDetectorVariable(), inLLDMeV.GetDetectorVariable(), MPPostSpecification.ConvertDoubleToInt(inMcnpNPS.GetDetectorVariable()));
        }
    }
}
