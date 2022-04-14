using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public partial class NblStandard : UserControl, ISourceSelectionGui
    {
        public NblStandard()
        {
            InitializeComponent();
            inAxis.DisplayForAxis();
            inCenter.SetGroupBoxLabel("Base Center");
            inFillHeight.DataIsInteger = false;
            inFillHeight.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inCenter.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public Sources GetSourceType()
        {
            return Sources.NblStandard;
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

        public MyPoint3D GetCenter()
        {
            return inCenter.GetPoint();
        }

        public MyPoint3D GetAxis()
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
            return inFillHeight.Value;
        }
    }
}
