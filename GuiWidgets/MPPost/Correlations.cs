using System;
using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class Correlations : UserControl, IMPPostDetector<MPPostSpecification.Correlations>
    {
        public Correlations()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inStartTimeNS.UseAsDetectorVariable();
            inStopTimeNS.UseAsDetectorVariable();
            inAutoCorrelation.UseAsDetectorVariable();
            inBinIncrementNS.UseAsDetectorVariable();
            inCellDetectorStart.UseAsDetectorVariable();
            inCrossCorrelation.UseAsDetectorVariable();
            inTimeOfFlight.UseAsDetectorVariable();
            inTimeWindowNS.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.Correlations specs)
        {
            inStartTimeNS.SetDetectorVariable(specs.StopTimeNanoSec);
            inStopTimeNS.SetDetectorVariable(specs.StopTimeNanoSec);
            inAutoCorrelation.SetDetectorVariable(specs.EnableAutoCorrelation);
            inBinIncrementNS.SetDetectorVariable(specs.BinIncrementNanoSec);
            inCellDetectorStart.SetDetectorVariable(specs.CellOfStartDetector_BlankForTOF);
            inCrossCorrelation.SetDetectorVariable(specs.EnableCrossCorrelation);
            inTimeOfFlight.SetDetectorVariable(specs.EnableTimeOfFlight);
            inTimeWindowNS.SetDetectorVariable(specs.CorrelationTimeWindowNanoSec);
        }

        public MPPostSpecification.Correlations Get()
        {
            return new MPPostSpecification.Correlations(inStartTimeNS.GetDetectorVariable(),
                inStopTimeNS.GetDetectorVariable(), inAutoCorrelation.GetDetectorVariable(),
                inBinIncrementNS.GetDetectorVariable(),
                MPPostSpecification.ConvertDoubleToInt(inCellDetectorStart.GetDetectorVariable()),
                inCrossCorrelation.GetDetectorVariable(), inTimeOfFlight.GetDetectorVariable(),
                inTimeWindowNS.GetDetectorVariable());
        }
    }
}
