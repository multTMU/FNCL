using System;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;
using GuiInterface;
using GuiWidgets.McnpModels;

namespace GuiWidgets.FnclModels
{
    public interface IModelConfigGui
    {
        ModelTypes GetModelType();
        double GetAmLiLeft();
        double GetAmLiRight();
        double GetModeratorThickness();
        bool GetUseLeadShield();
        bool GetUseCadmiumShield();
        double GetLeadThickness();
        double GetStandOff();
        double GetCadmiumThickness();
        AmLiBlockTypes GetAmLiBlockType();
        NeutronGeneratorTypes GetNeutronGeneratorType();
        Point3D GetExtraLeadSideShieldDimensions();
        bool GetUseExtraLeadRightPanelOne();
        bool GetUseExtraLeadLeftPanelTwo();

        Point3D GetGeneratorAxis();
        Point3D GetGeneratorSourcePoint();
        double GetGeneratorRotationDegrees();
    }

    public static class ModelSelectionGuiHelper
    {
        public static IModelConfigGui GetModel(ModelTypes modelTypes)
        {
            switch (modelTypes)
            {
                case ModelTypes.Undefined:
                    return new NoModel();
                case ModelTypes.AmLi:
                    return new AmLiBasis();
                case ModelTypes.AmLiSel:
                    break;
                case ModelTypes.MP320:
                    return new Mp320Basis();
                case ModelTypes.MP320Sel:
                    break;
                case ModelTypes.Starfire:
                    return new StarFireNGen350Basis();
                case ModelTypes.StarfireSel:
                    break;
                case ModelTypes.NGamArray12:
                    return new NGamArray();
                default:
                    return new NoModel();
            }

            return new NoModel();
        }

        public static Particle GetModelDefaultParticle(ModelTypes modelSelected)
        {
            switch (modelSelected)
            {
                case ModelTypes.Undefined:
                    return Particle.Undetermined;
                case ModelTypes.AmLi:
                    return Particle.Neutron;
                case ModelTypes.AmLiSel:
                    return Particle.Neutron;
                case ModelTypes.MP320:
                    return Particle.Neutron;
                case ModelTypes.MP320Sel:
                    return Particle.Neutron;
                case ModelTypes.Starfire:
                    return Particle.Neutron;
                case ModelTypes.StarfireSel:
                    return Particle.Neutron;
                case ModelTypes.NGamArray12:
                    return Particle.NeutronAndPhoton;
                default:
                    throw new ArgumentOutOfRangeException(nameof(modelSelected), modelSelected, null);
            }
        }

        public static bool ModelCanBeActive(ModelTypes modelSelected)
        {
            switch (modelSelected)
            {
                case ModelTypes.Undefined:
                    return false;
                case ModelTypes.AmLi:
                    return true;
                case ModelTypes.AmLiSel:
                    return true;
                case ModelTypes.MP320:
                    return true;
                case ModelTypes.MP320Sel:
                    return true;
                case ModelTypes.Starfire:
                    return true;
                case ModelTypes.StarfireSel:
                    return true;
                case ModelTypes.NGamArray12:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(modelSelected), modelSelected, null);
            }
        }
    }
}
