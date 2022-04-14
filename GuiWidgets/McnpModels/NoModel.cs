using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;
using GuiInterface;

namespace GuiWidgets.FnclModels
{
    public partial class NoModel : UserControl, IModelConfigGui
    {
        private const double GARBAGE = 0;

        public NoModel()
        {
            InitializeComponent();
        }

        public ModelTypes GetModelType()
        {
            return ModelTypes.Undefined;
        }

        public double GetAmLiLeft()
        {
            return GARBAGE;
        }

        public double GetAmLiRight()
        {
            return GARBAGE;
        }

        public double GetModeratorThickness()
        {
            return GARBAGE;
        }

        public bool GetUseLeadShield()
        {
            return false;
        }

        public bool GetUseCadmiumShield()
        {
            return false;
        }

        public double GetLeadThickness()
        {
            return GARBAGE;
        }

        public double GetStandOff()
        {
            return GARBAGE;
        }

        public double GetCadmiumThickness()
        {
            return GARBAGE;
        }

        public AmLiBlockTypes GetAmLiBlockType()
        {
            return AmLiBlockTypes.Undefined;
        }

        public NeutronGeneratorTypes GetNeutronGeneratorType()
        {
            return NeutronGeneratorTypes.Undefined;
        }

        public MyPoint3D GetExtraLeadSideShieldDimensions()
        {
            return new MyPoint3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public bool GetUseExtraLeadRightPanelOne()
        {
            return false;
        }

        public bool GetUseExtraLeadLeftPanelTwo()
        {
            return false;
        }

        public MyPoint3D GetGeneratorAxis()
        {
            return new MyPoint3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public MyPoint3D GetGeneratorSourcePoint()
        {
            return new MyPoint3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public double GetGeneratorRotationDegrees()
        {
            return GARBAGE;
        }
    }
}
