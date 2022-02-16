using System;
using System.Windows.Forms;
using GlobalHelpers;
using GeometrySampling;

namespace GuiWidgets.Source
{
    public partial class FuelSource : UserControl, ISourceSelectionGui
    {
        public event EventHandler LaunchFuelEditor;

        public FuelSource()
        {
            InitializeComponent();
            inHeightDisplacement.DataIsInteger = false;
            inHeightDisplacement.SetValueRaiseNoEvent(0);
            inHeightDisplacement.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inFuelFile.SetInitialDirectory(ConfigureDictionaries.GetDataDirectory());
        }

        private void bLaunchFuel_Click(object sender, EventArgs e)
        {
            RaiseLaunchFuelEditor();
        }

        private void RaiseLaunchFuelEditor()
        {
            EventHandler handler = this.LaunchFuelEditor;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public Sources GetSourceType()
        {
            return Sources.Fuel;
        }

        public bool DisplayMaterialEditor()
        {
            return false;
        }

        public string GetFuelFile()
        {
            return this.inFuelFile.FileFullPath;
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
            return new Point3D(0, 0, 0);
        }

        public Point3D GetAxis()
        {
            return new Point3D(0, 0, 0);
        }

        public double GetRadius()
        {
            return 0;
        }

        public double GetFuelHeightDisplacement()
        {
            return inHeightDisplacement.Value;
        }

        public double GetCylinderHeight()
        {
            return 0;
        }
    }
}
