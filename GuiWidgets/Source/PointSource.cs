using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public partial class PointSource : UserControl, ISourceSelectionGui
    {
        public PointSource()
        {
            InitializeComponent();
            this.set3D1.DisplayForPoint();
            this.set3D1.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public Sources GetSourceType()
        {
            return Sources.Point;
        }

        public event EventHandler LaunchFuelEditor;

        public bool DisplayMaterialEditor()
        {
            return false;
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
            return this.set3D1.GetPoint();
        }

        public MyPoint3D GetAxis()
        {
            return new MyPoint3D(0, 0, 0);
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
            return 0;
        }
    }
}
