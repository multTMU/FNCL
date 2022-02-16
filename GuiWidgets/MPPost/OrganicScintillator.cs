using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class OrganicScintillator : UserControl, IMPPostDetector<MPPostSpecification.OrganicScintillator>
    {
        public OrganicScintillator()
        {
            InitializeComponent();
            EnableAllAsDetectorVariables();
            inNeutronRegionType.ComboxSelectionUpdated += OnNeutronRegionTypeChanged;
            inNeutronRegionType.SetEnum(EnumGuiHelpers.GetNeutronRegionType());
        }

        private void OnNeutronRegionTypeChanged(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void EnableAllAsDetectorVariables()
        {
            // throw new NotImplementedException();
        }

        private void bAddNeutronCal_Click(object sender, EventArgs e)
        {
        }

        private struct EnergyCalibration
        {
            public double Elow;
            public double Ehigh;
            public List<double> Ecal;
        }

        public void Set(MPPostSpecification.OrganicScintillator specs)
        {
            inCalibrationRegionsNumber.SetDetectorVariable(specs.CalibrationRegions);
            inCarbonCal.SetDetectorVariable(specs.CarbonLightConstant);
        }

        public MPPostSpecification.OrganicScintillator Get()
        {
            return new MPPostSpecification.OrganicScintillator();
        }
    }
}
