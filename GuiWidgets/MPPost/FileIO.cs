using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class FileIO : UserControl, IMPPostDetector<MPPostSpecification.FileIO>
    {
        public FileIO()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inCollisionHistory.UseAsDetectorVariable();
            inCommaDelimeted.UseAsDetectorVariable();
            inDetectorFile.UseAsDetectorVariable();
            inLabelOutput.UseAsDetectorVariable();
            inOutputFiles.UseAsDetectorVariable();
            inOverwriteFiles.UseAsDetectorVariable();
            inPrintListmode.UseAsDetectorVariable();
            inPrintSummaryTable.UseAsDetectorVariable();
            inSeparateDRFs.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.FileIO specs)
        {
            inCollisionHistory.SetDetectorVariable(specs.CollisionHistory);
            inCommaDelimeted.SetDetectorVariable(specs.CommaDelimited);
            inDetectorFile.SetDetectorVariable(specs.DetectorFileName);
            inLabelOutput.SetDetectorVariable(specs.LabelOutput);
            inOutputFiles.SetDetectorVariable(specs.OutputFileName);
            inOverwriteFiles.SetDetectorVariable(specs.OverWriteFiles);
            inPrintListmode.SetDetectorVariable(specs.PrintListModeFile);
            inPrintSummaryTable.SetDetectorVariable(specs.PrintSummaryTable);
            inSeparateDRFs.SetDetectorVariable(specs.SeparateDetectorResponse);
        }

        public MPPostSpecification.FileIO Get()
        {
            return new MPPostSpecification.FileIO(inCollisionHistory.GetDetectorVariable(),
                inCommaDelimeted.GetDetectorVariable(), inDetectorFile.GetDetectorVariable(),
                inLabelOutput.GetDetectorVariable(), inOutputFiles.GetDetectorVariable(),
                inOverwriteFiles.GetDetectorVariable(), inPrintListmode.GetDetectorVariable(),
                inPrintSummaryTable.GetDetectorVariable(), inSeparateDRFs.GetDetectorVariable());
        }
    }
}
