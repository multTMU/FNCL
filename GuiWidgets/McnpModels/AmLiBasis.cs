using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;
using GuiInterface;

namespace GuiWidgets.FnclModels
{
    public partial class AmLiBasis : UserControl, IModelConfigGui
    {
        private double amLiLeft;
        private double amLiRight;
        private const double GARBAGE = 0;

        public AmLiBasis()
        {
            InitializeComponent();
            amLiLeft = 0.5;
            amLiRight = 0.5;
            this.inLeftAmLi.DataIsInteger = false;
            this.inRightAmLi.DataIsInteger = false;
            UpdateAmLiIntensities();
            this.inLeftAmLi.NumberUpdated += UpdatedIntensity;
            this.inRightAmLi.NumberUpdated += UpdatedIntensity;
            cbAmLiBlock.DataSource = Enum.GetNames(typeof(AmLiBlockTypes));
        }

        public void SetRelativeIntensities(double left, double right)
        {
            amLiRight = right;
            amLiLeft = left;
            UpdateAmLiIntensities();
        }

        private void UpdatedIntensity(object sender, EventArgs e)
        {
            amLiRight = inRightAmLi.Value;
            amLiLeft = inLeftAmLi.Value;
            UpdateAmLiIntensities();
        }

        private void UpdateAmLiIntensities()
        {
            inLeftAmLi.SetValueRaiseNoEvent(amLiLeft);
            inRightAmLi.SetValueRaiseNoEvent(amLiRight);
        }

        public ModelTypes GetModelType()
        {
            return ModelTypes.AmLi;
        }

        public double GetAmLiLeft()
        {
            return amLiLeft;
        }

        public double GetAmLiRight()
        {
            return amLiRight;
        }

        public double GetModeratorThickness()
        {
            return 0;
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
            return (AmLiBlockTypes)cbAmLiBlock.SelectedIndex;
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
