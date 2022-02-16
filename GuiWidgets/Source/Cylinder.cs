using System;
using System.Windows.Forms;
using GlobalHelpers;
using GeometrySampling;

namespace GuiWidgets.Source
{
    public partial class Cylinder : UserControl, ISourceSelectionGui
    {
        public Cylinder()
        {
            InitializeComponent();
            this.inAxis.DisplayForAxis();
            this.inCenter.DisplayForPoint();
            this.inCenter.SetGroupBoxLabel("Base Center");

            inCenter.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inHeight.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public Sources GetSourceType()
        {
            return Sources.Cylinder;
        }

        public event EventHandler LaunchFuelEditor;

        public bool DisplayMaterialEditor()
        {
            return true;
        }

        public string GetFuelFile()
        {
            return string.Empty;
        }

        public double GetInnerRadius()
        {
            return 0;
        }

        public double GetOuterRadius()
        {
            return 0;
        }

        public Point3D GetCenter()
        {
            return inCenter.GetPoint();
        }

        public Point3D GetAxis()
        {
            return inAxis.GetPoint();
        }

        public double GetRadius()
        {
            return this.inRadius.Value;
        }

        public double GetFuelHeightDisplacement()
        {
            return 0;
        }

        public double GetCylinderHeight()
        {
            return inHeight.Value;
        }
    }
}
