using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GeometrySampling;
using GlobalHelpersDefaults;

namespace GlobalHelpers
{
    public static class GlobalDefaults
    {
        public const int EXTERNAL_WORLD = 999;
        public const int INTERNAL_WORLD = 998;
        public const string EXTERNAL_WORLD_COMMENT = "External World";
        public const string INTERNAL_WORLD_COMMENT = "Internal World";
        public const double WORLD_RADIUS = 500;
        public static ParticleImportance ParticleInProblem = ParticleImportance.NeutronOnly;
        public static ParticleImportance ExternalParticleImportance = ParticleImportance.NoNeutron;
        public const int NO_TRANSFORMATION = -1;
        public static Point3D CENTER = new Point3D(0, 0, 0);
        public static int FillMaterial = Materials.AIR;
        public static int MCNP_PARTILCES_TO_RUN = (int)1e7;
        public const int FIRST_POLIMI_DETECTOR_INDEX = 1;

        public static void SetParticleImportance(Particle particle)
        {
            switch (particle)
            {
                case Particle.Undetermined:
                    ParticleInProblem = ParticleImportance.Neither;
                    ExternalParticleImportance = ParticleImportance.Neither;
                    break;
                case Particle.Neutron:
                    ParticleInProblem = ParticleImportance.NeutronOnly;
                    ExternalParticleImportance = ParticleImportance.NoNeutron;
                    break;
                case Particle.Photon:
                    ParticleInProblem = ParticleImportance.GammaOnly;
                    ExternalParticleImportance = ParticleImportance.NoGamma;
                    break;
                case Particle.NeutronAndPhoton:
                    ParticleInProblem = ParticleImportance.NeutronAndGamma;
                    ExternalParticleImportance = ParticleImportance.Neither;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(particle), particle, null);
            }
        }

        public static MaterialElement GetFillMaterial()
        {
            return MaterialManager.GetMaterial(FillMaterial);
        }

        public static void SetFillMaterial(int newFillMaterial)
        {
            FillMaterial = newFillMaterial;
        }
    }

    public enum UraniumEnrichment
    {
        Depleted,
        Natural,
        LowEnriched,
        HighEnriched,
        VeryHighEnriched
    }

    public enum AmLiBlockTypes
    {
        Undefined,
        PWR,
        BWR,
        VVER
    }

    public enum NeutronGeneratorTypes
    {
        Undefined,
        MP320,
        StarFire
    }

    public enum DUcylinders
    {
        JANY,
        JAPO
    };

    public static class Materials
    {
        public const string DEFAULT_FILE = "MaterialDefinitions.txt";
        public const string USER_FILE = "UserMaterialDefinitions.txt";
        public const int COPPER = 52;
        public const int SF6GAS = 51;
        public const int MAGNET = 53;
        public const int NAI = 72;
        public const int CLAD = 30;
        public const int HDPE = 42;
        public const int ALUMINUM = 50;
        public const int AL_ALLOY = 43;
        public const int HE3_GAS = 70;
        public const int EJ309 = 71;
        public const int AIR = 40;
        public const int CADMIUM = 44;
        public const int WATER = 46;
        public const int LEAD = 47;
        public const int STAINLESS = 41;
        public const int ELECTRONICS = 54;
        public const int AMLI_SOURCE = 61;
        public const int TUNGSTEN_ALLOY = 62;
        public const int BORATED_25_PE = 64;
        public const int URANIUM_METAL_P2 = 80;
        public const int URANIUM_METAL_P72 = 81;
        public const int URANIUM_METAL_3P3 = 82;
        public const int URANIUM_METAL_90P27 = 83;
        public const int URANIUM_METAL_93P5 = 84;
        public const int CONCRETE = 34;
        public const int PINEWOOD = 33;
        public const int PLYWOOD = 35;
        public const int URANIUMOXIDE_20p11 = 90;
        public const int POLYURETHANE_FOAM = 48;
    }

    public static class FuelAssembly
    {
        public const string DEFAULT_FILE = "FuelAssemblySpecs.txt";
        public const int UNIVERSE = 50;
        public const double BOX_BUFFER = 0.5;

        public static class DefaultIndices
        {
            public const int FUEL = 2;
            public const int GAP = 3;
            public const int CLAD = 4;
        }
    }

    public static class Indices
    {
        public const int SOURCE = 1000;
        public static Encased<int> EnclosedIndexOffsets = new Encased<int>(1, 0);

        public static class NGammaDetector
        {
            public const int BASE_INDEX = 100;
            public const int DETECTOR_ROW_1_COL_1 = 0;

            public const int SHIELD = 50;
        }

        public static class FNCL
        {
            public const int DETECTOR_INDEX = 1;
            public const int PANEL1 = 100;
            public const int PANEL2 = 200;
            public const int PANEL3 = 300;
            public const int LEFT_HDPE = 400;
            public const int RIGHT_HDPE = 500;
            public const int DETECTOR1 = 10;
            public const int DETECTOR2 = 20;
            public const int DETECTOR3 = 30;
            public const int DETECTOR4 = 40;
            public const int SHIELD = 50;
            public const int SIDE_SHIELD = 60;
            public const int PANEL_ENCLOSURE_OFFSET = 70;
            public const int PMTOFFSET = 5;

            public const int SEL_COMPONENTS = 900;
            // public const int SOURCE = 1000;
        }

        public static class NGen350
        {
            public const int TUBE_OFFSET = 10;
            public const int NEUTRON_GENERATOR = Mp320.NEUTRON_GENERATOR;
            public const int BOX_OFFSET = 20;
            public static int FLUX_MONITOR_OFFSET = 30;
        }


        public static class Mp320
        {
            public const int MODERATOR = 600;
            public const int MODERATOR_BULK = 0;
            public const int MODERATOR_FRONT_PLANE = 1;
            public const int MODERATOR_LEFT_PLANE = 2;
            public const int MODERATOR_RIGHT_PLANE = 3;

            public const int MODERATOR_LEFT_VOID = -1;
            public const int MODERATOR_RIGHT_VOID = -2;

            public const int MODERATOR_SHIELD = 50;
            public const int MODERATOR_SHIELD_PB = 1;
            public const int MODERATOR_SHIELD_CD = 0;

            public const int SIDE_PANEL_SHIELD = 60;
            public const int SIDE_PANEL_SHIELD_LEFT = 2;
            public const int SIDE_PANEL_SHIELD_RIGHT = 1;

            public const int HE3_DETECTOR = 70;

            public const int NEUTRON_GENERATOR = 700;
            //public const int NEUTRON_GENERATOR_TRANSFORMATION = 7;
        }

        public static class NblStandard
        {
            public const int OUTER_CAN = 0;
            public const int INNER_CAN = 1;

            public const int PLUG_PLANE_BOTTOM = 10;
            public const int INNER_PLUG = 11;
            public const int PLUG_PLANE_TOP = 12;

            public const int CHAMBER = 30;

            public const int VOID_UPPER = 20;
            public const int VOID_LOWER = 21;
        }

        public static class AmLi
        {
            public const int BASEINDEX = 800;
            public const int AMLI_RIGHT_OFFSET = 10;
            public const int AMLI_LEFT_OFFSET = 20;
            public const int BLOCK_OFFSET = 30;

            public static class BWR
            {
                public const int FRONT_OUTER_PLANE = 1;
                public const int FRONT_MIDDLE_PLANE = 2;
                public const int FRONT_INNER_PLANE = 3;

                public const int MIDDLE_OUTER_PLANE = 4;
                public const int MIDDLE_MIDDLE_PLANE = 5;
                public const int MIDDLE_INNER_PLANE = 6;

                public const int BACK_OUTER_PLANE = 7;
                public const int BACK_MIDDLE_PLANE = 8;
                public const int BACK_INNER_PLANE = 9;

                public const int LEFT_SIDE_OUTER_PLANE = 10;
                public const int LEFT_SIDE_MIDDLE_PLANE = 11;
                public const int LEFT_SIDE_INNER_PLANE = 12;

                public const int RIGHT_SIDE_OUTER_PLANE = 13;
                public const int RIGHT_SIDE_MIDDLE_PLANE = 14;
                public const int RIGHT_SIDE_INNER_PLANE = 15;

                public const int LEFT_SLOPE_OUTER_PLANE = 16;
                public const int LEFT_SLOPE_MIDDLE_PLANE = 17;
                public const int LEFT_SLOPE_INNER_PLANE = 18;

                public const int RIGHT_SLOPE_OUTER_PLANE = 19;
                public const int RIGHT_SLOPE_MIDDLE_PLANE = 20;
                public const int RIGHT_SLOPE_INNER_PLANE = 21;

                //public const int LEFT_INNER_CUT_PLANE = 22;
                //public const int RIGHT_INNER_CUT_PLANE = 23;

                //public const int LEFT_OUTER_CUT_PLANE = 24;
                //public const int RIGHT_OUTER_CUT_PLANE = 25;
                public const int TOP_OUTER_PLANE = 23;
                public const int TOP_MIDDLE_PLANE = 24;
                public const int TOP_INNER_PLANE = 25;

                public const int BOTTON_OUTER_PLANE = 26;
                public const int BOTTOM_MIDDLE_PLANE = 27;
                public const int BOTTOM_INNER_PLANE = 28;

                public const int POLY = 30;
                public const int CADMIUM = 31;

                public const int CASE = 32;
                // public const int FILL = 33;
            }
        }
    }

    public static class Extents
    {
        public const double EPSILON_GAP = 1e-3;
        public const double ENCLOSURE_THICK = 0.3; // Y

        public const double CADMIUM_THICKNESS = 0.1; // Y based on Neutron Rodeo Phase II final report

        //private const double SIDESHIELD_THICK = 3; // N
        public const double LEAD_THICKNESS = 1.0; // Y  based on Neutron Rodeo Phase II final report
        
        public static class FNCL
        {
            // TODO this is a mess
            // Y = based off STMP_MU7154_FNCL_SYSTEM_SD7750D_rev3.pdf
            // N = best guess
            private static double detectorOffsetX = 2.0 * ENCLOSURE_THICK;

            public static Point3D DETECTOR_EXTENT = new Point3D(9.4, 9.4, 9.4); //Y
            public static Point3D HDPE_BLOCK_EXTENT = new Point3D(13.24, 12.5, 28.4); // Y

            public static Point3D
                HDPE_BLOCK_CENTER =
                    new Point3D(18.00 + 3.0 * ENCLOSURE_THICK, 18 + 2.0 * ENCLOSURE_THICK,
                        0.0); //N, assuming PANEL_CENTER and it is diagonally located

            public static Point3D PANEL_CENTER = new Point3D(18.25, 0.0, 0.0); // N
            public static Point3D PANEL_SHIELD_EXTENT = new Point3D(CADMIUM_THICKNESS + LEAD_THICKNESS, 21.65, 22); //N

            public static Point3D PANEL_SHIELD_CENTER =
                new Point3D(12.75 + ENCLOSURE_THICK + CADMIUM_THICKNESS, 0, 0); // N

            public static Point3D PANEL_ENCLOSURE_EXTENT = new Point3D(12.45 - 2 * ENCLOSURE_THICK,
                23.85 - 2 * ENCLOSURE_THICK, 97.7 - 2 * ENCLOSURE_THICK); // Z includes the handle  

            public static Point3D
                PANEL_SHIELD_NORMAL =
                    new Point3D(-1, 0, 0); //Y face toward center, kinda arbitrary but Detector.cs uses this convention


            public static Point3D DETECTOR_CENTER =
                new Point3D(0.0 + detectorOffsetX, 5.0 + ENCLOSURE_THICK, 5.0 + ENCLOSURE_THICK); // N

            public static Encased<Point3D> GetPmtCenter() // Y derived
            {
                Point3D center = DETECTOR_CENTER;
                center += (PMT_EXTENTS.Outer.Height / 2 * pmtAxis) + (DETECTOR_EXTENT / 2 * pmtAxis) +
                          ENCLOSURE_THICK * pmtAxis;
                Encased<Point3D> pmtCenter = new Encased<Point3D> {Inner = center, Outer = center};
                return pmtCenter;
            }

            private static Point3D pmtAxis = new Point3D(0, 0, 1); // Y they are up!

            public static Encased<CylinderExtent> PMT_EXTENTS = new Encased<CylinderExtent> // Y
            {
                Inner = new CylinderExtent(20.722, 2.876, pmtAxis), Outer = new CylinderExtent(20.85, 2.94, pmtAxis)
            };

            public static Point3D GetDetectorSideShieldExtents() //N
            {
                // screw it, just hardcode it
                //Point3D sideShield = 2.0 * (DETECTOR_EXTENT + ENCLOSURE_THICK);
                //sideShield.Y += 2.0 * SIDESHIELD_THICK;
                return new Point3D(9.9, 21.8, 20.5);
            }

            public static Point3D GetDetectorSideShieldCenter()
            {
                Point3D Center = PANEL_CENTER;
                Center.X += detectorOffsetX;
                return Center;
            }
        }

        public static class NblStandard
        {
            public const double Height = 10;
            public const double BaseThickness = 0.2;
            public const double Radius = 4;
            public const double WallThickness = 1;
            public const double PlugHeight = 3; // hieght of plug above cap 
            public static double PlugOuterRadius = Radius - WallThickness;
            public static double PlugInnerRadius = PlugOuterRadius - WallThickness;
        }

        public static class NGen350
        {
            public static Point3D Axis = new Point3D(0, 0, 1);
            public static Point3D InternalSourceLocation = new Point3D(0, -18, 0);
            public const double Radius = 4.5;
            public const double EndRadius = 5.0;
            public const double CentralLength = 25;
            public const double OverallLength = 50;

            public static Point3D Block = new Point3D(17.0, 17.0, 13.0);
            public static Point3D SourceOffsetFromCenterBlock = new Point3D(0, -3.35, 0);

            public static Point3D
                SourceLocationFromFrontFaceTubeCentered = new Point3D(0, 0, 5); //new Point3D(0, -1.5, 0);

            public static Point3D DefaultTubeOrientation = new Point3D(0, 0, 1);
            public static Point3D DefaultBlockOrientation = new Point3D(0, 1, 0);

            public const double BoronThickness = 0.3;

            public static class FluxMonitors
            {
                public const double OFFSET_FROM_SOURCE = 2.2;
                public static Point3D Dimensions = new Point3D(3.6, 0.6, 2.8);

                private static readonly List<Point3D> startEndPoint = new List<Point3D>()
                {
                    //Order Counts, as we get direction vector from x(i+1) - x(i)
                    new Point3D(2.9, 3.9, OFFSET_FROM_SOURCE),
                    new Point3D(5.0, 0.6, OFFSET_FROM_SOURCE),
                    new Point3D(3.7, -3.4, OFFSET_FROM_SOURCE),
                    new Point3D(0, -5.2, OFFSET_FROM_SOURCE),
                    new Point3D(-3.7, -3.4, OFFSET_FROM_SOURCE),
                    new Point3D(-5.0, 0.6, OFFSET_FROM_SOURCE),
                    new Point3D(-2.9, 3.9, OFFSET_FROM_SOURCE)
                };

                public const double CASE_THICKNESS = 0.05; // ?

                public static Point3D GetHeadPoint(int index)
                {
                    return startEndPoint[index];
                }
            }
        }

        public static class Mp320
        {
            public static Point3D CenterRelativeToModeratorBulkFace = new Point3D(0, -7, 0); // 

            public static Point3D Axis = new Point3D(0, 0, 1);
            // public static Point3D ModeratorExtents = new Point3D(40, 10, 20);

            public static Point3D ModeratorCenter = new Point3D(0, -17.75, 0);

            // distance from the end of the neutron generator, along the axis, where the source term lies
            public const double HEIGHT_SHIFT = 5.75; // 4.5; // 14.5,
            public const double SOURCE_FROM_CENTER = 0; //13.5; Bob says the source is lined up to teh center 7/2/2021
            public const double LENGTH = 56; //20.0;
            public const double ENCLOSURE_THICK = 0.5;
            public const double OUTER_RADIUS = 5.25; //2.5;

            //
            public const double GENERATOR_CENTER_OFFSET = 7;
            public static Point3D ModeratorBulk = new Point3D(35.5, 17, 35);
            public static Point3D ModeratorShieldFace = new Point3D(35.5, 0, 35);
            public const double MODERATOR_FRONT_LENGTH_Y = 4.5;
            public const double MODERATOR_INSET_LENGTH_X = 5;
            public const double MODERATOR_BACK_LENGTH_X = 19;
            public static Point3D ModeratorFaceCenter = new Point3D(0, -12, 0); // This is just to prevent collissions
            private const double SOURCE_OFFSET_FROM_CENTER = 0;

            public static Point3D ModeratorFaceNormal = new Point3D(0, -1, 0);

            public const double CADMIUM_THICKNESS = 0.015;
        }

        public static class He3TubeMP320
        {
            public static Point3D TubeOffsetFromNGenCenter = new Point3D(-6.75, -7, 3);
            public const double TUBE_LENGTH = 27.0;
            public const double TUBE_THICKNESS = 0.1;
            public const double INNER_RADIUS = 2.0;
        }


        public static class AmLiSource
        {
            public static class PWR
            {
                public static Point3D BlockCenter = new Point3D(0, -17.5, 0);
                public static Point3D SourceCenter = new Point3D(7.25, 3, 0);

                public static Point3D BlockExtent = new Point3D(51.3, 9.9, 28.4); //Y

                public static Point3D CadmiumCenter = new Point3D(0,
                    CADMIUM_THICKNESS / 2 + BlockCenter.Y + BlockExtent.Y / 2 + ENCLOSURE_THICK, 0);

                public static Point3D CadmiumExtents = new Point3D(51.3, CADMIUM_THICKNESS, 28.4);
            }

            public static class BWR
            {
                public static Point3D BlockCenter = new Point3D(0, -13.0, 0);
                public static Point3D SourceCenter = new Point3D(2.54, 6.0325, 0);

                public static Point3D BlockExtent = new Point3D(51.3, 18.4725, 28.4); // new Point3D(51.3, 9.9, 28.4);

                public const double ExtensionLength = 8.5725; // not sure on the length
                public const double CavityLength = 13.6525;
                public const double BlockLength = 21.2725;

                //public static Point3D CadmiumCenter = new Point3D(0,
                //    CADMIUM_THICKNESS / 2 + BlockCenter.Y + BlockExtent.Y / 2 + ENCLOSURE_THICK, 0);

                //public static Point3D CadmiumExtents = new Point3D(51.3, CADMIUM_THICKNESS, 28.4);
            }

            public static class VVER
            {
                public static Point3D BlockCenter = new Point3D(0, -17.5, 0);
                public static Point3D SourceCenter = new Point3D(7.25, 3, 0);

                public static Point3D BlockExtent = new Point3D(51.3, 9.9, 28.4); //Y

                public const double NotchWidth = 5; //N
                public const double NotchDepth = 4; //N

                //public static Point3D CadmiumCenter = new Point3D(0,
                //    CADMIUM_THICKNESS / 2 + BlockCenter.Y + BlockExtent.Y / 2 + ENCLOSURE_THICK, 0);

                //public static Point3D CadmiumExtents = new Point3D(51.3, CADMIUM_THICKNESS, 28.4);
            }

            public static Point3D IntoCavity = new Point3D(0, 1, 0);
            public static Point3D SideCavity = new Point3D(1, 0, 0);

            public static Point3D Axis = new Point3D(0, 0, 1);

            // these points are wrong
            public static class OuterBottle
            {
                public const double Radius = 1.5875;
                public const double Height = 5.715;
            }

            public static class InnerBottle
            {
                public const double Radius = 0.5;
                public const double Height = 1.0;
            }
        }

        public static UraniumHollowCylinderSpec JANY = new UraniumHollowCylinderSpec()
        {
            Height = 16,
            InnerRadius = 8.5 / 2.0,
            OuterRadius = 13 / 2.0,
            Enrichment = UraniumEnrichment.Depleted,
            Axis = new Point3D(0, 0, 1),
            InnerMat = Materials.AIR
        };

        public static UraniumHollowCylinderSpec JAPO = new UraniumHollowCylinderSpec()
        {
            Height = 9,
            InnerRadius = 7.5 / 2.0,
            OuterRadius = 13 / 2.0,
            Enrichment = UraniumEnrichment.Depleted,
            Axis = new Point3D(0, 0, 1),
            InnerMat = Materials.AIR
        };

        public static class SelMeasurementSetup
        {
            private static Point3D axis = new Point3D(0, 0, 1);
            public static Point3D PostExtents = new Point3D(10, 10, 81.5);
            public static Point3D PostTopOffsetFromCenter = new Point3D(0, 0, -6.25);
            public static Point3D PEslab = new Point3D(58, 101, 3);
            public static CylinderExtent ConcreteFloor = new CylinderExtent(25, 100.0, axis);
            public static CylinderExtent Puck = new CylinderExtent(2.54, 4.1275, axis);
            public static double AmLiMagnitudeLeft = .5;
            public static double AmLiMagnitudeRight = .5;

            public static Point3D GetPostCenter(Point3D postTopCenter)
            {
                return postTopCenter - (PostExtents / 2.0) * axis;
            }
        }

        public static class NGammaDetector
        {
            //public static Point3D SHIELD_EXTENTS = new Point3D(33.02, 43.18, 7.62);
            // public static CylinderExtent DETECTOR = new CylinderExtent(7.62, 3.81, new Point3D(0, 1, 0));
            // want to make arbitrary arrays
            public const double MIN_SHIELD_THICKNESS = 2.25;
            public const double DETECTOR_LENGTH = 7.62;
            public const double DETECTOR_RADIUS = 3.81;
            public static Point3D FACE_NORMAL = new Point3D(0, 1, 0);
            public static CylinderExtent Extent = new CylinderExtent(DETECTOR_LENGTH, DETECTOR_RADIUS, FACE_NORMAL);
            public static double THIN_SKIN = 0.01;
        }
    }

    public struct UraniumHollowCylinderSpec
    {
        public double Height;
        public double InnerRadius;
        public double OuterRadius;
        public UraniumEnrichment Enrichment;
        public Point3D Axis;
        public int InnerMat;
    }

    [Serializable]
    public struct SimulationSpecification
    {
        public AmLiBlockTypes AmLiBlockType;
        public NeutronGeneratorTypes NeutronGeneratorType;

        public double StandOff;
        public string McnpInputDirectory;
        public int NPS;
        public double Activity;
        public bool ActiveProblem;
        public string Description;
        public string FuelFile;
        public double FuelHeightDisplacement;

        public double InnerRadius;
        public double OutRadius;
        public Point3D Center;
        public Point3D Axis;
        public double Radius;
        public double Height;

        public int Material;
        public PoliMiSource SourcePoliMi;
        public Sources SourceType;

        public double AmLiLeft;
        public double AmLiRight;

        public int NumberOfSelPucks;

        public double ModeratorThickness;
        public bool UseCdShield;
        public bool UsePbShield;
        public double PbThickness;
        public double CdThickness;
        public bool UseLeftPanelTwoShield;
        public bool UseRightPanelOneShield;
        public Point3D ExtraPbShieldDimensions;

        public Particle TrackParticle;

        //Ngen 350 Starfire
        public double RotationDegrees;
        public Point3D GeneratorAxis;
        public Point3D GeneratorSourcePosistion;
    }

    public static class SimulationSpecificationHelper
    {
        public static void SaveSimulationSpecsToFile(string saveFile, List<SimulationSpecification> simulations)
        {
            System.Xml.Serialization.XmlSerializer xOut = new XmlSerializer(simulations.GetType());
        }

        //private static void WriteToFile(StreamWriter sw, SimulationSpecification s)
        //{
        //    throw new NotImplementedException();
        //}

        public static List<SimulationSpecification> LoadSimulationSpecsFromFile(string loadFile)
        {
            List<SimulationSpecification> simulations = new List<SimulationSpecification>();


            return simulations;
        }
    }
}
