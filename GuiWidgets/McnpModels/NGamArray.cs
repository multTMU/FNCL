using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;
using GuiInterface;
using GuiWidgets.FnclModels;

namespace GuiWidgets.McnpModels
{
    public partial class NGamArray : UserControl, IModelConfigGui
    {
        private const double GARBAGE = 0;

        public NGamArray()
        {
            InitializeComponent();
            this.inShieldThickness.DataIsInteger = false;
            this.inStandOff.DataIsInteger = false;

            this.inStandOff.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            this.inShieldThickness.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public ModelTypes GetModelType()
        {
            return ModelTypes.NGamArray12;
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
            return inShieldThickness.Value;
        }

        public double GetStandOff()
        {
            return inStandOff.Value;
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

        public Point3D GetExtraLeadSideShieldDimensions()
        {
            return new Point3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public bool GetUseExtraLeadRightPanelOne()
        {
            return false;
        }

        public bool GetUseExtraLeadLeftPanelTwo()
        {
            return false;
        }

        public Point3D GetGeneratorAxis()
        {
            return new Point3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public Point3D GetGeneratorSourcePoint()
        {
            return new Point3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public double GetGeneratorRotationDegrees()
        {
            return GARBAGE;
        }
    }
}
