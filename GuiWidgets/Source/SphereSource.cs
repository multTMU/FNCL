using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public partial class SphereSource : UserControl, ISourceSelectionGui
    {
        public SphereSource()
        {
            InitializeComponent();
            set3D1.DisplayForPoint();
            inRadius.DataIsInteger = false;
            inRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            set3D1.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public void SetAll(double Radius, double X, double Y, double Z)
        {
            SetRadius(Radius);
            this.set3D1.SetAll(X, Y, Z);
        }


        private void SetRadius(double radius)
        {
            inRadius.SetValueRaiseNoEvent(radius);
        }

        public Sources GetSourceType()
        {
            return Sources.Sphere;
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
            return set3D1.GetPoint();
        }

        public Point3D GetAxis()
        {
            return new Point3D(0, 0, 0);
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
            return 0;
        }
    }
}
