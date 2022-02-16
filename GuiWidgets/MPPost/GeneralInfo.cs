using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class GeneralInfo : UserControl, IMPPostDetector<MPPostSpecification.GeneralInfo>
    {
        public GeneralInfo()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
        }

        private void EnableAllAsDetectorVariables()
        {
            inTitle.UseAsDetectorVariable();
            inUserName.UseAsDetectorVariable();
        }

        public void Set(MPPostSpecification.GeneralInfo specs)
        {
            inTitle.SetDetectorVariable(specs.Title);
            inUserName.SetDetectorVariable(specs.Username);
        }

        public MPPostSpecification.GeneralInfo Get()
        {
            return new MPPostSpecification.GeneralInfo(inTitle.GetDetectorVariable(), inUserName.GetDetectorVariable());
        }
    }
}
