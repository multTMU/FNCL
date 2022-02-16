using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;

namespace Runner
{
    public static class UraniumHollowCylinderModels
    {
        //public enum UraniumEnrichment
        //{
        //    Depleted, Natural, LowEnriched, HighEnriched, VeryHighEnriched
        //}
        public struct SpontaneousFission
        {
            public double HalfLifeYear;
            public double FissionProbPercent;
            public double NeutronsPerFission;
            public double NeutronRatePerGram;
        }

        public static class UraniumHelper
        {
            public const double DENSITY_UOXIDE = 3.0; // g/cc

            public const double DENSITY_UMETAL = 18.95;
            //  public const double U238_SF_NUBAR = 2.07;

            public static SpontaneousFission U235SF = new SpontaneousFission
            {
                HalfLifeYear = 7.04e8,
                FissionProbPercent = 2.0e-7,
                NeutronsPerFission = 1.86,
                NeutronRatePerGram = 0.0003
            };

            public static SpontaneousFission U238SF = new SpontaneousFission
            {
                HalfLifeYear = 4.47e9,
                FissionProbPercent = 5.4e-5,
                NeutronsPerFission = 2.07,
                NeutronRatePerGram = 0.0136
            };

            private const double DEPLETED = 0.2;
            private const double NATURAL = 0.72;
            private const double LOW = 3.3;
            private const double HIGH = 90.27;
            private const double VERYHIGH = 93.5;

            public static double GetPercentU235(UraniumEnrichment enrichment)
            {
                switch (enrichment)
                {
                    case UraniumEnrichment.Depleted:
                        return DEPLETED;
                    case UraniumEnrichment.Natural:
                        return NATURAL;
                    case UraniumEnrichment.LowEnriched:
                        return LOW;
                    case UraniumEnrichment.HighEnriched:
                        return HIGH;
                    case UraniumEnrichment.VeryHighEnriched:
                        return VERYHIGH;
                    default:
                        return DEPLETED;
                }
            }

            public static MaterialElement GetMaterial(UraniumEnrichment enrichment)
            {
                switch (enrichment)
                {
                    case UraniumEnrichment.Depleted:
                        return MaterialManager.GetMaterial(Materials.URANIUM_METAL_P2);
                    case UraniumEnrichment.Natural:
                        return MaterialManager.GetMaterial(Materials.URANIUM_METAL_P72);
                    case UraniumEnrichment.LowEnriched:
                        return MaterialManager.GetMaterial(Materials.URANIUM_METAL_3P3);
                    case UraniumEnrichment.HighEnriched:
                        return MaterialManager.GetMaterial(Materials.URANIUM_METAL_90P27);
                    case UraniumEnrichment.VeryHighEnriched:
                        return MaterialManager.GetMaterial(Materials.URANIUM_METAL_93P5);
                    default:
                        return MaterialManager.GetMaterial(Materials.URANIUM_METAL_P72);
                }
            }

            public static double GetActivityForUraniumMetal(UraniumEnrichment enrichment, double volume)
            {
                double u235Fraction = GetPercentU235(enrichment) / 100.0;
                double u238Fraction = 1.0 - u235Fraction;
                double massU = volume * DENSITY_UMETAL;
                // In PoliMi NPS is source decays, it samples p(nu) 
                double u235Rate = (U235SF.NeutronRatePerGram * massU * u235Fraction) / U235SF.NeutronsPerFission;
                double u238Rate = (U238SF.NeutronRatePerGram * massU * u238Fraction) / U238SF.NeutronsPerFission;

                return u238Rate + u235Rate;
            }

            public static double DefaultGetActivityScalarForUraniumMetal(UraniumHollowCylinderSpec specifications)
            {
                double outerVolume = VolumeHelper.GetCylinderVolume(specifications.OuterRadius, specifications.Height);
                double innerVolume = VolumeHelper.GetCylinderVolume(specifications.InnerRadius, specifications.Height);
                double netVolume = outerVolume - innerVolume;

                return GetActivityForUraniumMetal(specifications.Enrichment, netVolume);
            }
        }

        public interface IUraniumHollowCylinder
        {
            void SetSpecifications(UraniumHollowCylinderSpec specifications);
            void SetCenter(Point3D Center);
            void SetCylinderAxis(Point3D Axis);
            void SetHeight(double Height);
            void SetInnerRadius(double InnerRadius);
            void SetOuterRadius(double OuterRadius);
            double GetEnrichmentPercent();
            void SetEnrichment(UraniumEnrichment Enrichment);
            double GetActivityScalarForUraniumMetal(UraniumHollowCylinderSpec specifications);
        }


        //public class UraniumHollowCylinderNGen : Mp320Fncl, IUraniumHollowCylinder
        //{
        //    protected const string DefaultDescription = "Uranium Hollow Cylinder AmLi";
        //    protected Point3D center;
        //    protected Point3D axis;
        //    protected double height;
        //    protected double innerRadius;
        //    protected double outerRadius;
        //    protected MaterialElement innerMat;
        //    protected MaterialElement outerMat;
        //    protected UraniumEnrichment enrichment;
        //    private readonly bool useNGenSource;
        //    private const bool USE_SOURCE = false;

        //    public void SetSpecifications(UraniumHollowCylinderSpec specifications)
        //    {
        //        axis = specifications.Axis;
        //        height = specifications.Height;
        //        innerRadius = specifications.InnerRadius;
        //        outerRadius = specifications.OuterRadius;
        //        innerMat = MaterialManager.GetMaterial(specifications.InnerMat);
        //        outerMat = UraniumHelper.GetMaterial(specifications.Enrichment);
        //    }

        //    public void SetCenter(Point3D Center)
        //    {
        //        center = Center;
        //    }

        //    public void SetCylinderAxis(Point3D Axis)
        //    {
        //        axis = Axis;
        //    }

        //    public void SetHeight(double Height)
        //    {
        //        height = Height;
        //    }

        //    public void SetInnerRadius(double InnerRadius)
        //    {
        //        innerRadius = InnerRadius;
        //    }

        //    public void SetOuterRadius(double OuterRadius)
        //    {
        //        outerRadius = OuterRadius;
        //    }

        //    public double GetEnrichmentPercent()
        //    {
        //        return UraniumHelper.GetPercentU235(enrichment);
        //    }

        //    public void SetEnrichment(UraniumEnrichment Enrichment)
        //    {
        //        enrichment = Enrichment;
        //    }

        //    public double GetActivityScalarForUraniumMetal(UraniumHollowCylinderSpec specifications)
        //    {
        //        return UraniumHollowCylinderModels.UraniumHelper
        //            .DefaultGetActivityScalarForUraniumMetal(specifications);
        //    }

        //    protected override void InitializeComponents()
        //    {
        //        AddComponent(new NonEmbeddedSources.HollowCylinder(center, axis, height,
        //            innerRadius,
        //            outerRadius, innerMat, outerMat, USE_SOURCE));
        //        base.InitializeComponents();
        //    }

        //    public UraniumHollowCylinderNGen(string configFile) : base(configFile, true)
        //    {
        //        innerMat = MaterialManager.GetMaterial(Materials.AIR);
        //    }
        //}

        //public class UraniumHollowCylinderAmLiInterrogator : AmLiFNCL, IUraniumHollowCylinder
        //{
        //    protected const string mcnpDescription = "Uranium Hollow Cylinder AmLi";
        //    protected Point3D center;
        //    protected Point3D axis;
        //    protected double height;
        //    protected double innerRadius;
        //    protected double outerRadius;
        //    protected MaterialElement innerMat;
        //    protected MaterialElement outerMat;
        //    protected UraniumEnrichment enrichment;
        //    private const bool USE_SOURCE = false;
        //    public UraniumHollowCylinderAmLiInterrogator(string configurationFile) :
        //        base(configurationFile, true, mcnpDescription)
        //    {
        //        innerMat = MaterialManager.GetMaterial(Materials.AIR);
        //    }

        //    public void SetSpecifications(UraniumHollowCylinderSpec specifications)
        //    {
        //        axis = specifications.Axis;
        //        height = specifications.Height;
        //        innerRadius = specifications.InnerRadius;
        //        outerRadius = specifications.OuterRadius;
        //        innerMat = MaterialManager.GetMaterial(specifications.InnerMat);
        //        outerMat = UraniumHelper.GetMaterial(specifications.Enrichment);
        //    }

        //    public void SetCenter(Point3D Center)
        //    {
        //        center = Center;
        //    }

        //    public void SetCylinderAxis(Point3D Axis)
        //    {
        //        axis = Axis;
        //    }

        //    public void SetHeight(double Height)
        //    {
        //        height = Height;
        //    }

        //    public void SetInnerRadius(double InnerRadius)
        //    {
        //        innerRadius = InnerRadius;
        //    }

        //    public void SetOuterRadius(double OuterRadius)
        //    {
        //        outerRadius = OuterRadius;
        //    }

        //    public double GetEnrichmentPercent()
        //    {
        //        return UraniumHelper.GetPercentU235(enrichment);
        //    }

        //    public void SetEnrichment(UraniumEnrichment Enrichment)
        //    {
        //        enrichment = Enrichment;
        //    }

        //    public double GetActivityScalarForUraniumMetal(UraniumHollowCylinderSpec specifications)
        //    {
        //        return UraniumHollowCylinderModels.UraniumHelper
        //            .DefaultGetActivityScalarForUraniumMetal(specifications);
        //    }

        //    protected override void InitializeComponents()
        //    {
        //        outerMat = UraniumHelper.GetMaterial(enrichment);
        //        AddComponent(new NonEmbeddedSources.HollowCylinder(center, axis, height,
        //            innerRadius,
        //            outerRadius, innerMat, outerMat, USE_SOURCE));
        //        base.InitializeComponents();
        //    }
        //}


        //public class UraniumHollowCylinderNoInterrogator : RunFnclDetector, IUraniumHollowCylinder
        //{
        //    protected const string mcnpDescription = "Uranium Hollow Cylinder No Iterrogator";
        //    protected Point3D center;
        //    protected Point3D axis;
        //    protected double height;
        //    protected double innerRadius;
        //    protected double outerRadius;
        //    protected MaterialElement innerMat;
        //    protected MaterialElement outerMat;
        //    protected UraniumEnrichment enrichment;
        //    private const bool USE_SOURCE = false;

        //    public UraniumHollowCylinderNoInterrogator(string configurationFile) : base(configurationFile,
        //        mcnpDescription)
        //    {
        //        innerMat = MaterialManager.GetMaterial(Materials.AIR);
        //    }

        //    public void SetSpecifications(UraniumHollowCylinderSpec specifications)
        //    {
        //        axis = specifications.Axis;
        //        height = specifications.Height;
        //        innerRadius = specifications.InnerRadius;
        //        outerRadius = specifications.OuterRadius;
        //        innerMat = MaterialManager.GetMaterial(specifications.InnerMat);
        //        outerMat = UraniumHelper.GetMaterial(specifications.Enrichment);
        //    }

        //    public void SetCenter(Point3D Center)
        //    {
        //        center = Center;
        //    }

        //    public void SetCylinderAxis(Point3D Axis)
        //    {
        //        axis = Axis;
        //    }

        //    public void SetHeight(double Height)
        //    {
        //        height = Height;
        //    }

        //    public void SetInnerRadius(double InnerRadius)
        //    {
        //        innerRadius = InnerRadius;
        //    }

        //    public void SetOuterRadius(double OuterRadius)
        //    {
        //        outerRadius = OuterRadius;
        //    }

        //    public double GetEnrichmentPercent()
        //    {
        //        return UraniumHelper.GetPercentU235(enrichment);
        //    }

        //    protected override void InitializeComponents()
        //    {
        //        AddComponent(new NonEmbeddedSources.HollowCylinder(center, axis, height,
        //            innerRadius,
        //            outerRadius, innerMat, outerMat, USE_SOURCE));
        //    }

        //    public void SetEnrichment(UraniumEnrichment Enrichment)
        //    {
        //        enrichment = Enrichment;
        //    }

        //    public double GetActivityScalarForUraniumMetal(UraniumHollowCylinderSpec specifications)
        //    {
        //        return UraniumHollowCylinderModels.UraniumHelper
        //            .DefaultGetActivityScalarForUraniumMetal(specifications);
        //    }
        //}
    }
}
