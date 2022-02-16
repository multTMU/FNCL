using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;
using static PoliMiRunner.MPPostSpecification.He3Module;

namespace GuiWidgets.MPPost
{
    public partial class He3Module : UserControl, IMPPostDetector<MPPostSpecification.He3Module>
    {
        public He3Module()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
            SetEnumTypes();
            SetIntegerVariables();
        }

        private void SetIntegerVariables()
        {
            inNumberWindows.DataIsInteger = true;
            inMaxMultiplicity.DataIsInteger = true;
            inWindowIncrementMicroSec.DataIsInteger = true;
        }

        private void SetEnumTypes()
        {
            inOutputStyle.SetEnum(EnumGuiHelpers.GetHe3OutputStyle());
            inTriggerType.SetEnum(EnumGuiHelpers.GetHe3TriggerType());
            inDeadTimeType.SetEnum(EnumGuiHelpers.GetHe3DeadTimeType());
        }

        private void EnableAllAsDetectorVariables()
        {
            inAmp2DeadTimeMicroSec.UseAsDetectorVariable();
            inAmpDeadTimeMicroSec.UseAsDetectorVariable();
            inDeadTimeMicroSec.UseAsDetectorVariable();
            inDeadTimeType.UseAsDetectorVariable();
            inEnableHe3Module.UseAsDetectorVariable();
            inLongDelayMicroSec.UseAsDetectorVariable();
            inMaxMultiplicity.UseAsDetectorVariable();
            inNumberWindows.UseAsDetectorVariable();
            inOutputStyle.UseAsDetectorVariable();
            inParalyzeable.UseAsDetectorVariable();
            inPreDelayMicroSec.UseAsDetectorVariable();
            inRunTimeSec.UseAsDetectorVariable();
            inTriggerType.UseAsDetectorVariable();
            inWindowIncrementMicroSec.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.He3Module specs)
        {
            inAmp2DeadTimeMicroSec.SetDetectorVariable(specs.AmplifierTwoDeadTimeMicroSec);
            inAmpDeadTimeMicroSec.SetDetectorVariable(specs.AmplifierDeadTimeMicroSec);
            inDeadTimeMicroSec.SetDetectorVariable(specs.DeadTimeMicroSec);
            inDeadTimeType.SetDetectorVariable(EnumGuiHelpers.ConvertDetectorVariableEnumToInt(specs.DeadTimeType));
            inEnableHe3Module.SetDetectorVariable(specs.EnableHe3);
            inLongDelayMicroSec.SetDetectorVariable(specs.LongDelayMicroSec);
            inMaxMultiplicity.SetDetectorVariable(specs.MaxExpectedMultiplicity);
            inNumberWindows.SetDetectorVariable(specs.NumberWindows);
            inOutputStyle.SetDetectorVariable(EnumGuiHelpers.ConvertDetectorVariableEnumToInt(specs.OutputStyle));
            inParalyzeable.SetDetectorVariable(specs.IsParalyzable);
            inPreDelayMicroSec.SetDetectorVariable(specs.PreDelayMicroSec);
            inRunTimeSec.SetDetectorVariable(specs.RunTimeSec);
            inTriggerType.SetDetectorVariable(EnumGuiHelpers.ConvertDetectorVariableEnumToInt(specs.TriggerType));
            inWindowIncrementMicroSec.SetDetectorVariable(specs.WindowIncrementMicroSec);
        }

        public MPPostSpecification.He3Module Get()
        {
            return new MPPostSpecification.He3Module(inAmpDeadTimeMicroSec.GetDetectorVariable(),
                inAmp2DeadTimeMicroSec.GetDetectorVariable(), inDeadTimeMicroSec.GetDetectorVariable(),
                EnumGuiHelpers.ConvertDetectorVariableBaseIntToEnum<He3DeadTimeType>(
                    inDeadTimeType.GetDetectorVariable()), inEnableHe3Module.GetDetectorVariable(),
                inLongDelayMicroSec.GetDetectorVariable(),
                MPPostSpecification.ConvertDoubleToInt(inMaxMultiplicity.GetDetectorVariable()),
                MPPostSpecification.ConvertDoubleToInt(inNumberWindows.GetDetectorVariable()),
                EnumGuiHelpers.ConvertDetectorVariableBaseIntToEnum<He3OutputStyle>(
                    inOutputStyle.GetDetectorVariable()),
                inParalyzeable.GetDetectorVariable(), inPreDelayMicroSec.GetDetectorVariable(),
                inRunTimeSec.GetDetectorVariable(),
                EnumGuiHelpers.ConvertDetectorVariableBaseIntToEnum<He3TriggerType>(
                    inTriggerType.GetDetectorVariable()),
                MPPostSpecification.ConvertDoubleToInt(inWindowIncrementMicroSec.GetDetectorVariable()));
        }
    }
}
