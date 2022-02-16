using System;
using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class InGaussianBroadening : UserControl,
        IDetectorVariableGUI<MPPostSpecification.LightResolution.GaussianBroadening>
    {
        private bool isEnabled;
        public string LabelForEnable { get; set; }

        public InGaussianBroadening()
        {
            InitializeComponent();
            isEnabled = false;
            UpdateEnabled();
            inEnableAsVariable.BoolUpdated += EnabledUpdated;
            inEnableAsVariable.Label = LabelForEnable;
        }

        private void EnabledUpdated(object sender, EventArgs e)
        {
            isEnabled = inEnableAsVariable.Value;
            UpdateEnabled();
        }

        private void UpdateEnabled()
        {
            inA.Enabled = isEnabled;
            inB.Enabled = isEnabled;
            inC.Enabled = isEnabled;
        }

        public bool IsDetectorVariableSet()
        {
            return isEnabled;
        }

        public void SetDetectorVariableState(bool varIsSet)
        {
            isEnabled = varIsSet;
            UpdateEnabled();
        }

        public void UseAsDetectorVariable()
        {
            isEnabled = true;
            UpdateEnabled();
        }

        public MPPostSpecification.LightResolution.GaussianBroadening GetValue()
        {
            return new MPPostSpecification.LightResolution.GaussianBroadening(inA.Value, inB.Value, inC.Value,
                isEnabled);
        }

        public void SetDetectorVariable(
            MPPostSpecification.DetectorVariable<MPPostSpecification.LightResolution.GaussianBroadening>
                detectorVariable)
        {
            var values = detectorVariable.Value;
            isEnabled = detectorVariable.VarIsSet;
            inA.SetValueRaiseNoEvent(values.P0);
            inB.SetValueRaiseNoEvent(values.P1);
            inC.SetValueRaiseNoEvent(values.Exponent);
            UpdateEnabled();
        }

        public MPPostSpecification.DetectorVariableBase<MPPostSpecification.LightResolution.GaussianBroadening>
            GetDetectorVariable()
        {
            return new MPPostSpecification.DetectorVariableBase<MPPostSpecification.LightResolution.GaussianBroadening>(
                isEnabled, GetValue());
        }
    }
}
