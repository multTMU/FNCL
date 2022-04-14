using System.Windows.Forms;
using GuiWidgets.FnclModels;
using GlobalHelpers;
using GuiInterface;
using GeometrySampling;

namespace GuiWidgets.McnpModels
{
    public partial class StarFireNGen350Basis : UserControl, IModelConfigGui
    {
        private const double GARBAGE = 0;

        public StarFireNGen350Basis()
        {
            InitializeComponent();
            inSourcePoint.SetGroupBoxLabel("Source Position");
            inAxis.SetGroupBoxLabel("Axis");
            inRotation.DataIsInteger = false;

            inSourcePoint.SetAll(Extents.NGen350.InternalSourceLocation);
            inAxis.SetAll(Extents.NGen350.Axis);
            inRotation.SetValueRaiseNoEvent(0);

            inRotation.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertBetweenRadiansAndDegree);
            inSourcePoint.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public AmLiBlockTypes GetAmLiBlockType()
        {
            return AmLiBlockTypes.Undefined;
        }

        public double GetAmLiLeft()
        {
            return GARBAGE;
        }

        public double GetAmLiRight()
        {
            return GARBAGE;
        }

        public double GetCadmiumThickness()
        {
            return GARBAGE;
        }

        public MyPoint3D GetExtraLeadSideShieldDimensions()
        {
            return new MyPoint3D(GARBAGE, GARBAGE, GARBAGE);
        }

        public MyPoint3D GetGeneratorAxis()
        {
            return this.inAxis.GetPoint();
        }

        public double GetGeneratorRotationDegrees()
        {
            return this.inRotation.GetValue();
        }

        public MyPoint3D GetGeneratorSourcePoint()
        {
            return this.inSourcePoint.GetPoint();
        }

        public double GetLeadThickness()
        {
            return GARBAGE;
        }

        public ModelTypes GetModelType()
        {
            return ModelTypes.Starfire;
        }

        public double GetModeratorThickness()
        {
            return GARBAGE;
        }

        public NeutronGeneratorTypes GetNeutronGeneratorType()
        {
            return NeutronGeneratorTypes.StarFire;
        }

        public double GetStandOff()
        {
            return GARBAGE;
        }

        public bool GetUseCadmiumShield()
        {
            return false;
        }

        public bool GetUseExtraLeadLeftPanelTwo()
        {
            return false;
        }

        public bool GetUseExtraLeadRightPanelOne()
        {
            return false;
        }

        public bool GetUseLeadShield()
        {
            return false;
        }
    }
}
