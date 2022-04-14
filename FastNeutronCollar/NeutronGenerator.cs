using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public class Mp320Component : Component
    {
        private const string COMMENT = "Mp320 Neutron Generator";

        private readonly MyPoint3D axis;
        protected readonly double heightDisplacement;
        private readonly bool includeSource;
        private readonly bool usePdShield;
        private readonly bool useCdShield;
        private readonly double cdThickness;
        private readonly double pbThickness;
        private readonly double extraPEthickness;

        private bool useSideShieldLeftPanelTwo;
        private bool useSideShieldRightPanelOne;
        private MyPoint3D sideShieldDimensions;

        public Mp320Component(MyPoint3D generatorCenter, MyPoint3D orientationAxis,
            bool UsePbSheild, double PbThickness, bool UseCdShield, double CdThickness, MyPoint3D SideShieldDimensions,
            bool IncludeSource = true,
            double HeightDisplacement = 0, double ExtraPEthickness = 0, bool UseSideShieldLeftPanelTwo = false,
            bool UseSideShieldRightPanelOne = false) : base(
            Indices.Mp320.NEUTRON_GENERATOR, COMMENT, true)
        {
            center = generatorCenter;
            axis = orientationAxis;

            includeSource = IncludeSource;
            heightDisplacement = HeightDisplacement;

            useCdShield = UseCdShield;
            usePdShield = UsePbSheild;

            pbThickness = PbThickness;
            cdThickness = CdThickness;
            extraPEthickness = ExtraPEthickness;

            useSideShieldRightPanelOne = UseSideShieldRightPanelOne;
            useSideShieldLeftPanelTwo = UseSideShieldLeftPanelTwo;
            sideShieldDimensions = SideShieldDimensions;
        }

        protected override void InitializeSubComponents()
        {
            int he3externalIndex = primaryIndex + Indices.Mp320.HE3_DETECTOR;
            subComponents.Add(new Mp320Moderator(Indices.Mp320.MODERATOR, useCdShield, cdThickness,
                usePdShield, pbThickness, heightDisplacement, extraPEthickness, sideShieldDimensions,
                useSideShieldRightPanelOne, useSideShieldLeftPanelTwo,
                Indices.Mp320.NEUTRON_GENERATOR, he3externalIndex));

            subComponents.Add(new NeutronGeneratorTube(Indices.Mp320.NEUTRON_GENERATOR, GetNGenCenter(),
                axis,
                includeSource));

            subComponents.Add(new He3TubeDetector(he3externalIndex, GetHe3TubeCenter(), axis, "Mp320 Poly Embedded"));
        }

        private MyPoint3D GetHe3TubeCenter()
        {
            return GetNGenCenter() + Extents.He3TubeMP320.TubeOffsetFromNGenCenter;
        }

        private MyPoint3D GetNGenCenter()
        {
            MyPoint3D ngenCenter = center + Extents.Mp320.ModeratorFaceCenter;
            ngenCenter.Y -= (extraPEthickness + cdThickness + pbThickness);
            if (useSideShieldRightPanelOne || useSideShieldLeftPanelTwo)
            {
                ngenCenter.Y -= sideShieldDimensions.Y;
            }

            return ngenCenter;
        }
    }
}
