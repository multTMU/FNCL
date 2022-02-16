using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public partial class HollowCylinder : UserControl, ISourceSelectionGui
    {
        public HollowCylinder()
        {
            InitializeComponent();
            inAxis.DisplayForAxis();
            inCenter.DisplayForPoint();
            inHeight.DataIsInteger = false;
            inInRadius.DataIsInteger = false;
            inOutRadius.DataIsInteger = false;
            inCenter.SetGroupBoxLabel("Base Center");

            inCenter.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inHeight.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inInRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inOutRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public Sources GetSourceType()
        {
            return Sources.HollowCylinder;
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
            return inInRadius.Value;
        }

        public double GetOuterRadius()
        {
            return inOutRadius.Value;
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
            return 0;
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
