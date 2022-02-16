using System.Windows.Forms;
using GuiInterface;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.FnclModels
{
    public partial class Mp320Basis : UserControl, IModelConfigGui
    {
        private const double GARBAGE = 0;

        public Mp320Basis()
        {
            InitializeComponent();
            this.inThickPb.DataIsInteger = false;
            this.inThickCd.DataIsInteger = false;
            this.inPeExtraThickness.DataIsInteger = false;

            this.inThickPb.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            this.inThickCd.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            this.inPeExtraThickness.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            this.inShieldDimensions.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);

            inShieldDimensions.SetGroupBoxLabel("Shield Dimensions");
            //inShieldDimensions.SetXYZtext("Width","Thick", "Height");
            SetDefaults();
        }

        public double GetAmLiLeft()
        {
            return GARBAGE;
        }

        public double GetAmLiRight()
        {
            return GARBAGE;
        }

        public ModelTypes GetModelType()
        {
            return ModelTypes.MP320;
        }

        public double GetModeratorThickness()
        {
            return this.inPeExtraThickness.Value;
        }

        public bool GetUseLeadShield()
        {
            return cbPb.Checked;
        }

        public bool GetUseCadmiumShield()
        {
            return cbCd.Checked;
        }

        public double GetLeadThickness()
        {
            return inThickPb.Value;
        }

        public double GetStandOff()
        {
            return GARBAGE;
        }

        public double GetCadmiumThickness()
        {
            return inThickCd.Value;
        }

        public AmLiBlockTypes GetAmLiBlockType()
        {
            return AmLiBlockTypes.Undefined;
        }

        public NeutronGeneratorTypes GetNeutronGeneratorType()
        {
            return NeutronGeneratorTypes.MP320;
        }

        public void SetDefaults()
        {
            inThickCd.SetValueRaiseNoEvent(Extents.Mp320.CADMIUM_THICKNESS);
            this.cbCd.Checked = true;
            this.cbPb.Checked = false;
            inThickPb.SetValueRaiseNoEvent(0);
        }

        public Point3D GetExtraLeadSideShieldDimensions()
        {
            return inShieldDimensions.GetPoint();
        }

        public bool GetUseExtraLeadRightPanelOne()
        {
            return cbRightPanelOne.Checked;
        }

        public bool GetUseExtraLeadLeftPanelTwo()
        {
            return cbLeftPanelTwo.Checked;
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
