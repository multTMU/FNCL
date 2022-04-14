using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;

namespace FastNeutronCollar
{
    public class StarFireNGen350 : Component
    {
        private const string COMMENT = "NGen350 Neutron Generator";
        private const string SOURCE_COMMENT = "D-D Source Defined By PoliMi Cards";
        private readonly MyPoint3D axis;
        private readonly MyPoint3D sourcePoint;
        private readonly double rotation;
        private readonly bool includeSource;

        public StarFireNGen350(MyPoint3D SourceLocation, MyPoint3D Axis, bool IncludeSource, double HeightDisplacement,
            double Rotation) : base(
            Indices.NGen350.NEUTRON_GENERATOR, COMMENT, true)
        {
            axis = Axis;
            includeSource = IncludeSource;
            rotation = Rotation;
            sourcePoint = SourceLocation;
            sourcePoint.Z += HeightDisplacement;
        }

        public override SourceSpecification GetSource()
        {
            List<string> sources = new List<string>();
            sources.Add(GetPointSource());
            return new SourceSpecification(PoliMiSource.DD, sources);
        }

        private string GetPointSource()
        {
            return SourcesHelper.GetPointSource(sourcePoint) + " " + MCNPformatHelper.GetInLineComment(SOURCE_COMMENT);
        }

        protected override void InitializeSubComponents()
        {
            subComponents.Add(new Tube(primaryIndex + Indices.NGen350.TUBE_OFFSET, GetTubeBase(), axis));
            subComponents.Add(new SourceAndFluxMonitorBox(primaryIndex + Indices.NGen350.BOX_OFFSET, sourcePoint,
                GetBoxOrientationAxis(), axis, includeSource));
        }

        private MyPoint3D GetBoxOrientationAxis()
        {
            // idea is to rotate box by the given angle
            return Extents.NGen350.DefaultBlockOrientation;
        }

        private MyPoint3D GetTubeBase()
        {

            return sourcePoint + axis * Extents.NGen350.Block/2 + axis * (Extents.NGen350.BoronThickness + Extents.EPSILON_GAP) +
                   axis * Extents.NGen350.SourceLocationFromFrontFaceTubeCentered;
        }

        private class Tube : Component
        {
            private readonly MyPoint3D tubeCenter;
            private readonly MyPoint3D tubeAxis;

            public Tube(int mcnpIndex, MyPoint3D TubeBase, MyPoint3D TubeAxis) : base(mcnpIndex, "nGen350 Tube", false)
            {
                tubeAxis = TubeAxis;
                tubeCenter = ExtentsHelper.GetCenterFromCylinderBase(TubeBase, tubeAxis, Extents.NGen350.CentralLength);
            }

            protected override void InitializeSubComponents()
            {
                //shaft
                subComponents.Add(new EncasedCylinder(primaryIndex, ExtentsHelper.GetSharedCenter(tubeCenter),
                    GetTubeCylinderExtents(), GetMaterials(), false, GetEncasedComment()));
                // end cap
            }

            private Encased<string> GetEncasedComment()
            {
                return new Encased<string>("Electronics", "Casing");
            }

            private Encased<int> GetMaterials()
            {
                return new Encased<int>(Materials.ELECTRONICS, Materials.ALUMINUM);
            }

            private Encased<CylinderExtent> GetTubeCylinderExtents()
            {
                return new Encased<CylinderExtent>(
                    new CylinderExtent(Extents.NGen350.CentralLength - 2 * Extents.ENCLOSURE_THICK,
                        Extents.NGen350.Radius - Extents.ENCLOSURE_THICK, tubeAxis),
                    new CylinderExtent(Extents.NGen350.CentralLength, Extents.NGen350.Radius, tubeAxis));
            }
        }

        private class SourceAndFluxMonitorBox : Component
        {
            private readonly MyPoint3D sourcePoint;
            private readonly MyPoint3D shortFaceAxis;
            private readonly MyPoint3D tubeAxis;

            public SourceAndFluxMonitorBox(int mcnpIndex, MyPoint3D SourePoint, MyPoint3D ShortFaceAxis, MyPoint3D TubeAxis, bool IncludeSource)
                : base(mcnpIndex,
                    "Moderator Box", false)
            {
                sourcePoint = SourePoint;
                shortFaceAxis = ShortFaceAxis;
                tubeAxis = TubeAxis;
                hasSourceTerm = IncludeSource;
            }

            protected override void InitializeSubComponents()
            {
                int fluxMonitorBaseIndex = primaryIndex + Indices.NGen350.FLUX_MONITOR_OFFSET;

                Encased<string> componentComment = new Encased<string>("Case", "Moderator");
                EncasedBlock block = new EncasedBlock(primaryIndex,
                    false, GetCenterOfBlock(), Extents.NGen350.Block, Extents.NGen350.BoronThickness,
                    Materials.HDPE, Materials.BORATED_25_PE, componentComment,
                    InteriorCells: FluxMonitors.GetDetectorVolumeCells(fluxMonitorBaseIndex));

                subComponents.Add(block);
                subComponents.Add(new FluxMonitors(fluxMonitorBaseIndex, sourcePoint, shortFaceAxis, tubeAxis));
            }

            public override SourceSpecification GetSource()
            {
                List<string> sources = new List<string>();
                sources.Add(GetPointSource());
                return new SourceSpecification(PoliMiSource.DD, sources);
            }

            private string GetPointSource()
            {
                return SourcesHelper.GetPointSource(sourcePoint) + " " + MCNPformatHelper.GetInLineComment(SOURCE_COMMENT);
            }

            private MyPoint3D GetCenterOfBlock()
            {
                return sourcePoint + Extents.NGen350.SourceOffsetFromCenterBlock +
                       Extents.NGen350.SourceLocationFromFrontFaceTubeCentered;
            }

            private class FluxMonitors : Component
            {
                private MyPoint3D sourcePoint;
                private MyPoint3D shortFaceAxis;
                private MyPoint3D tubeAxis;

                public FluxMonitors(int mcnpIndex, MyPoint3D SourcePoint, MyPoint3D ShortFaceAxis, MyPoint3D TubeAxis) : base(
                    mcnpIndex, "Flux Monitors", true)
                {
                    sourcePoint = SourcePoint;
                    shortFaceAxis = ShortFaceAxis;
                    tubeAxis = TubeAxis;
                }

                public static List<int> GetDetectorVolumeCells(int basisIndex)
                {
                    List<int> fluxMonitorCells = new List<int>();

                    for (int i = 1; i <= FnclHelpers.NUMBER_NGEN350_DETECTORS; i++)
                    {
                        int unit = basisIndex + 5 * i;
                        PoliMiMPPostInputHelper.AddSecondDetector(unit);
                        fluxMonitorCells.Add(unit);
                    }

                    return fluxMonitorCells;
                }

                protected override void InitializeSubComponents()
                {
                    int fluxMonIndex = 0;
                    foreach (int c in GetDetectorVolumeCells(primaryIndex))
                    {
                        subComponents.Add(new UnitFluxMonitor(c, GetFluxMonitorCorner(fluxMonIndex)));
                        fluxMonIndex++;
                    }
                }

                private FluxMonitorSpec GetFluxMonitorCorner(int detectorIndex)
                {
                    MyPoint3D startPoint = Extents.NGen350.FluxMonitors.GetHeadPoint(detectorIndex);
                    MyPoint3D endPoint = Extents.NGen350.FluxMonitors.GetHeadPoint(detectorIndex + 1);

                    MyPoint3D aSide = endPoint - startPoint;
                    MyPoint3D bSide = Extents.NGen350.FluxMonitors.Dimensions.Z * tubeAxis;
                    MyPoint3D cSide = Extents.NGen350.FluxMonitors.Dimensions.Y *
                                    Point3DHelper.GetUnitVector(Point3DHelper.CrossProduct(bSide, aSide));

                    FluxMonitorSpec outer = new FluxMonitorSpec
                    {
                        Sides = new Matrix3D(aSide, bSide, cSide), Corner = startPoint + sourcePoint
                    };

                    return outer; 
                }

                private static MyPoint3D GetInteriorSide(MyPoint3D side)
                {
                    return Point3DHelper.GetUnitVector(side) *
                           (Point3DHelper.GetMagnitude(side) - 2.0 * Extents.NGen350.FluxMonitors.CASE_THICKNESS);
                }

                private struct FluxMonitorSpec
                {
                    public Matrix3D Sides;
                    public MyPoint3D Corner;
                }

                private class UnitFluxMonitor : Component
                {
                    private readonly FluxMonitorSpec fluxMonitor;

                    public UnitFluxMonitor(int mcnpIndex, FluxMonitorSpec FluxMonitor) : base(mcnpIndex,
                        "unit flux monitor", false)
                    {
                        fluxMonitor = FluxMonitor;
                    }

                    protected override List<string> MakeCells()
                    {
                        return new List<string>()
                        {
                            MCNPformatHelper.GetCell(primaryIndex, MaterialManager.GetMaterial(Materials.EJ309),
                                GetInteriorIndexBase(), comment)
                        };
                    }

                    protected override List<string> MakeSurfaces()
                    {
                        return new List<string>()
                        {
                            MCNPformatHelper.GetSurface(primaryIndex,
                                McnpSurfaces.GetArbitrarilyOrientedOrthogonalBox(fluxMonitor.Corner, fluxMonitor.Sides),
                                comment)
                        };
                    }
                }
            }
        }
    }
}
