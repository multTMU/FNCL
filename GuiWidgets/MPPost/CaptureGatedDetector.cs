using System;
using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class CaptureGatedDetector : UserControl, IMPPostDetector<MPPostSpecification.CaptureGatedDetector>
    {
        public CaptureGatedDetector()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inEnableCaptureGating.UseAsDetectorVariable();
            inStartTimeNS.UseAsDetectorVariable();
            inBinSize.UseAsDetectorVariable();
            inStopTimeNS.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.CaptureGatedDetector specs)
        {
            inEnableCaptureGating.SetDetectorVariable(specs.EnableCaptureGating);
            inStartTimeNS.SetDetectorVariable(specs.StartTimeNanoSec);
            inStopTimeNS.SetDetectorVariable(specs.StopTimeNanoSec);
            inBinSize.SetDetectorVariable(specs.BinSize);
        }

        public MPPostSpecification.CaptureGatedDetector Get()
        {
            return new MPPostSpecification.CaptureGatedDetector(inEnableCaptureGating.GetDetectorVariable(),
                inStartTimeNS.GetDetectorVariable(), inStopTimeNS.GetDetectorVariable(),
                inBinSize.GetDetectorVariable());
        }
    }
}
