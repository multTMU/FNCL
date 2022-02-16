using System.Windows.Forms;
using GlobalHelpers;

namespace GuiWidgets.Fuel
{
    public partial class FuelAssemblySpecs : UserControl
    {
        public FuelAssemblySpecs()
        {
            InitializeComponent();
            SetInputDataType();
            SetValidators();
        }

        private void SetValidators()
        {
            inCladdingInnerRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inCladdingOuterRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inCoolInnerRad.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inCoolOuterRad.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inPitch.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inFuelPinRadius.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
            inFuelLength.SetCustomValidator(GuiWidgets.CustomValidatorHelper.GetDistanceToCm);
        }

        private void SetInputDataType()
        {
            inCols.DataIsInteger = true;
            inRows.DataIsInteger = true;
            inCladdingInnerRadius.DataIsInteger = false;
            inCladdingOuterRadius.DataIsInteger = false;
            inCoolInnerRad.DataIsInteger = false;
            inCoolOuterRad.DataIsInteger = false;
            inPitch.DataIsInteger = false;
            inFuelPinRadius.DataIsInteger = false;
            inFuelLength.DataIsInteger = false;
        }

        public void SetSpecs(FuelAssemblySpecification specs)
        {
            inRows.SetValueRaiseNoEvent(specs.nRodsRow);
            inCols.SetValueRaiseNoEvent(specs.nRodsColumn);
            inCoolInnerRad.SetValueRaiseNoEvent(specs.CoolingChannelInnerRadius);
            inCoolOuterRad.SetValueRaiseNoEvent(specs.CoolingChannelOuterRadius);
            inCladdingInnerRadius.SetValueRaiseNoEvent(specs.CladdingInnerRadius);
            inCladdingOuterRadius.SetValueRaiseNoEvent(specs.CladdingOuterRadius);
            inPitch.SetValueRaiseNoEvent(specs.ArrayPitch);
            inFuelPinRadius.SetValueRaiseNoEvent(specs.FuelPinRadius);
            inFuelLength.SetValueRaiseNoEvent(specs.Length);
        }

        public FuelAssemblySpecification GetSpecs()
        {
            return new FuelAssemblySpecification
            {
                nRodsRow = (int)inRows.Value,
                nRodsColumn = (int)inCols.Value,
                ArrayPitch = inPitch.Value,
                FuelPinRadius = inFuelPinRadius.Value,
                CladdingInnerRadius = inCladdingInnerRadius.Value,
                CladdingOuterRadius = inCladdingOuterRadius.Value,
                CoolingChannelInnerRadius = inCoolInnerRad.Value,
                CoolingChannelOuterRadius = inCladdingOuterRadius.Value,
                Length = inFuelLength.Value
            };
        }
    }
}
