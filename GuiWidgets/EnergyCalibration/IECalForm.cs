using System;
using GlobalHelpersDefaults;
using System.Collections.Generic;

namespace GuiWidgets.EnergyCalibration
{
    public interface IECalForm : IGuiInputs<List<double>, List<double>>
    {
        event EventHandler EcalChanged;
        void SetDefaultEnergyCal();
        PoliMiOrganicNeutronEnergyCal GetECalType();
    }

    public static class ECalFormHelper
    {
        public static IECalForm GetFormByEnergyCalSelected(PoliMiOrganicNeutronEnergyCal eCalType)
        {
            switch (eCalType)
            {
                case PoliMiOrganicNeutronEnergyCal.None:
                    return new ECalNone();
                case PoliMiOrganicNeutronEnergyCal.NotPoliMiLinear:
                    return new ECalLinear();
                case PoliMiOrganicNeutronEnergyCal.Quadratic:
                    return new ECalQuadratic();
                case PoliMiOrganicNeutronEnergyCal.Rational:
                    return new ECalRational();
                case PoliMiOrganicNeutronEnergyCal.Transcendental:
                    return new ECalTrans();
                default:
                    return new ECalNone();
            }
        }
    }
}
