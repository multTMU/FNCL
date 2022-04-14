using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public partial class EmbededSphere : UserControl, ISourceSelectionGui
    {
        private readonly bool isPolyBallNotPointSourceInShell;

        public EmbededSphere(bool IsPolyBallNotPointSourceInShell)
        {
            InitializeComponent();
            isPolyBallNotPointSourceInShell = IsPolyBallNotPointSourceInShell;
            inThickness.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inInnerRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            setCenter.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        public Sources GetSourceType()
        {
            return isPolyBallNotPointSourceInShell ? Sources.PolySphere : Sources.PointSourceInSphericalShell;
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
            return inInnerRadius.Value;
        }

        public double GetOuterRadius()
        {
            return inThickness.Value;
        }

        public MyPoint3D GetCenter()
        {
            return setCenter.GetPoint();
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
