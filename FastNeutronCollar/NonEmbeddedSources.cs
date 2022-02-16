using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public static class NonEmbeddedSources
    {
        public class CylinderSource : Component
        {
            private readonly CylinderExtent cylinder;

            public CylinderSource(Point3D Base, Point3D Axis, double Radius, double Height, bool UseSource,
                PoliMiSource Source, int mcnpIndex = Indices.SOURCE) : base(mcnpIndex, "Cylinder", true)
            {
                hasSourceTerm = UseSource;
                poliMiSource = Source;
                center = ExtentsHelper.GetCenterFromCylinderBase(Base, Axis, Height);
                cylinder = new CylinderExtent(Height, Radius, Axis);
            }

            protected override List<string> MakeCells()
            {
                return new List<string>() {McnpSurfaces.GetRightCircularCylinder(center, cylinder)};
            }

            protected override List<string> MakeSurfaces()
            {
                return base.MakeSurfaces();
            }

            public override SourceSpecification GetSource()
            {
                return base.GetSource();
            }
        }

        public class HollowCylinder : Component
        {
            private const string COMMENT = "Hollow Cylinder";

            private const bool TOP_LEVEL = true;

            protected const int OUTER = 0;

            // protected const int INNER = 1;
            //private PoliMiSource source;
            private Encased<string> comments = new Encased<string>("Inner Cylinder", "Outer Cylinder");

            // can we use Encased Cylinder here
            private EncasedCylinder hollowCylinder;
            protected Encased<CylinderExtent> extents;

            public HollowCylinder(int mcnpIndex, Point3D Base, Point3D Axis, double Height, double InnerRadius,
                double OuterRadius, MaterialElement InnerMat, MaterialElement OuterMat, bool UseSource,
                PoliMiSource Source = PoliMiSource.None) :
                base(mcnpIndex, COMMENT, TOP_LEVEL)
            {
                Initialze(Base, Axis, Height, InnerRadius, OuterRadius, InnerMat, OuterMat, UseSource, Source);
            }

            private void Initialze(Point3D Base, Point3D Axis, double Height, double InnerRadius, double OuterRadius,
                MaterialElement InnerMat, MaterialElement OuterMat, bool UseSource, PoliMiSource Source)
            {
                center = ExtentsHelper.GetCenterFromCylinderBase(Base, Axis, Height);
                hasSourceTerm = UseSource;
                poliMiSource = Source;
                Encased<Point3D> encasedCenter = new Encased<Point3D>(center, center);
                extents = new Encased<CylinderExtent>
                {
                    Inner = new CylinderExtent(Height, InnerRadius, Axis),
                    Outer = new CylinderExtent(Height, OuterRadius, Axis)
                };

                Encased<MaterialElement> materials = new Encased<MaterialElement>(InnerMat, OuterMat);
                hollowCylinder = new EncasedCylinder(primaryIndex, encasedCenter, extents, materials, true, comments);
            }

            //public HollowCylinder(Point3D Center, Encased<CylinderExtent> Extents,
            //    Encased<MaterialElement> Materials, bool UseSource, PoliMiSource Source,
            //    int mcnpIndex = Indices.NonEmbeddedSource) :
            //    base(mcnpIndex, COMMENT, TOP_LEVEL)
            //{
            //    poliMiSource = Source;
            //    Encased<Point3D> encasedCenter = new Encased<Point3D>(Center, Center);
            //    extents = Extents;
            //    hollowCylinder = new EncasedCylinder(primaryIndex, encasedCenter, extents, Materials, true, comments);
            //}

            public HollowCylinder(SimulationSpecification sim, int mcnpIndex = Indices.SOURCE) : base(mcnpIndex,
                COMMENT)
            {
                Initialze(sim.Center, sim.Axis, sim.Height, sim.InnerRadius, sim.OutRadius,
                    MaterialManager.GetMaterial(GlobalDefaults.FillMaterial), MaterialManager.GetMaterial(sim.Material),
                    sim.ActiveProblem, sim.SourcePoliMi);
            }


            protected override void InitializeSubComponents()
            {
                subComponents.Add(hollowCylinder);
            }

            public override SourceSpecification GetSource()
            {
                List<string> sourceSpec = new List<string>();

                sourceSpec.Add("sdef pos=" + center.ToString() + " rad=d1 cel=" + GetIndex(OUTER));
                sourceSpec.Add("si1 " + extents.Inner.Radius.ToString(Point3D.FORMAT) + " " + McnpSurfaceHelpers
                    .BoundingSphereRadiusForCylinder(extents.Outer.Radius, extents.Outer.Axis)
                    .ToString(Point3D.FORMAT));
                sourceSpec.Add("sp1 -21 2");
                return new SourceSpecification(poliMiSource, sourceSpec);
            }
        }

        public class PointSourceInSphericalShell : Component
        {
            private const string COMMENT = "Point Source In Spherical Shell";
            private Encased<double> sphereExtents;
            private Encased<Point3D> sphereCenters;
            private Encased<MaterialElement> materials;
            private Encased<string> comments;

            public PointSourceInSphericalShell(Point3D Center, double InnerRadius, double Thickness,
                PoliMiSource Source, int shellMaterial, bool ActiveProblem, int mcnpIndex = Indices.SOURCE) : base(
                mcnpIndex, COMMENT)
            {
                materials = new Encased<MaterialElement>
                {
                    Inner = GlobalDefaults.GetFillMaterial(), Outer = MaterialManager.GetMaterial(shellMaterial)
                };

                sphereExtents = new Encased<double> {Inner = InnerRadius, Outer = InnerRadius + Thickness};

                sphereCenters = new Encased<Point3D> {Inner = Center, Outer = Center};

                comments = new Encased<string>() {Inner = "Inner Void", Outer = "Spherical Shell"};
                hasSourceTerm = !ActiveProblem;
                poliMiSource = Source;
            }

            public override SourceSpecification GetSource()
            {
                return new SourceSpecification(poliMiSource, new List<string>()
                {
                    SourcesHelper.GetPointSource(sphereCenters.Inner) + " " +
                    MCNPformatHelper.GetInLineComment("Point Source")
                });
            }

            protected override void InitializeSubComponents()
            {
                subComponents.Add(new EncasedSphere(primaryIndex, COMMENT, false, sphereCenters, sphereExtents,
                    materials, comments));
            }
        }

        public class PolyBall : Component
        {
            private const string COMMENT = "Poly Ball";
            private Encased<double> sphereExtents;
            private Encased<Point3D> sphereCenters;
            private Encased<MaterialElement> materials;
            private Encased<string> comments;

            public PolyBall(Point3D Center, double Radius, double Thickness, PoliMiSource source, int InnerMaterial,
                bool ActiveProblem,
                int mcnpIndex = Indices.SOURCE) : base(mcnpIndex, COMMENT)
            {
                materials = new Encased<MaterialElement>
                {
                    Inner = MaterialManager.GetMaterial(InnerMaterial),
                    Outer = MaterialManager.GetMaterial(Materials.HDPE)
                };

                sphereExtents = new Encased<double> {Inner = Radius, Outer = Radius + Thickness};

                sphereCenters = new Encased<Point3D> {Inner = Center, Outer = Center};
                hasSourceTerm = !ActiveProblem;
                poliMiSource = source;
            }

            protected override void InitializeSubComponents()
            {
                subComponents.Add(new EncasedSphere(primaryIndex, COMMENT, false, sphereCenters, sphereExtents,
                    materials, comments));
            }

            //protected override List<string> MakeCells()
            //{
            //    List<string> cells = new List<string>();
            //    cells.Add(GetTopLevelComment());
            //    cells.Add(GetIndex() + " " + hdpeMat.ToCell() + " " + GetInteriorIndexBase() +
            //              GetCellImportanceAndComments());
            //    return cells;
            //}

            //protected override List<string> MakeSurfaces()
            //{
            //    string macroBody = MCNPsurfaces.GetSphere(center, radius);
            //    List<string> surface = new List<string>();
            //    surface.Add(GetTopLevelComment());
            //    surface.Add(GetIndex() + " " + macroBody + " " + GetComments());
            //    return surface.ToList();
            //}
            public override SourceSpecification GetSource()
            {
                return new SourceSpecification(poliMiSource,
                    SourcesHelper.GetSphereSource(sphereCenters.Inner, sphereExtents.Inner));
            }
        }

        public class PointSource : Component
        {
            //protected Point3D center;
            protected string SourceName;
            // private readonly PoliMiSource Source;

            public PointSource(Point3D Center, PoliMiSource source, int mcnpIndex = 0,
                bool topLevelComments = false) : base(
                mcnpIndex, "Point Source", topLevelComments)
            {
                hasSourceTerm = true;
                center = Center;
                SourceName = source.ToString();
                poliMiSource = source;
            }

            //protected override SourceSpecification  MakeSources()
            //{
            //    return new SourceSpecification(Source, new List<string>()
            //    {
            //        SourcesHelper.GetPointSource(center) + " " + MCNPformatHelper.GetInLineComment() + " " + SourceName
            //    });
            //}

            public override SourceSpecification GetSource()
            {
                return new SourceSpecification(poliMiSource,
                    new List<string>()
                    {
                        SourcesHelper.GetPointSource(center) + " " + MCNPformatHelper.GetInLineComment(SourceName)
                    });
            }

            //public override bool HasSourceTerm()
            //{
            //    return true;
            //}
        }

        public class Sphere : Component
        {
            // private Point3D center;
            private double radius;
            private MaterialElement material;

            public Sphere(Point3D Center, double Radius, int Material, PoliMiSource Source, bool UseSourceTerm,
                int mcnpIndex = Indices.SOURCE) : base(mcnpIndex,
                "Homogenous Sphere", true)
            {
                material = MaterialManager.GetMaterial(Material);
                SetHasSourceTerm(UseSourceTerm);
                Initialize(Center, Radius, Source);
            }

            private void SetHasSourceTerm(bool UseSourceTerm)
            {
                hasSourceTerm = UseSourceTerm;
            }

            public Sphere(Point3D Center, double Radius, MaterialElement Material, PoliMiSource Source,
                bool UseSourceTerm,
                int mcnpIndex = Indices.SOURCE) : base(mcnpIndex,
                "Homogenous Sphere", true)
            {
                material = Material;
                SetHasSourceTerm(UseSourceTerm);
                Initialize(Center, Radius, Source);
            }

            private void Initialize(Point3D Center, double Radius, PoliMiSource Source)
            {
                center = Center;
                radius = Radius;
                poliMiSource = Source;
            }

            protected override List<string> MakeCells()
            {
                List<string> cells = new List<string>();
                cells.Add(GetTopLevelComment());
                //cells.Add(MCNPformatHelper.Get);

                cells.Add(MCNPformatHelper.GetCell(GetIndex(), material, GetInteriorIndexBase()));
                //cells.Add(GetIndex() + " " + material.ToCell() + " " + GetInteriorIndexBase() +
                //         GetCellImportanceAndComments());
                return cells;
            }

            protected override List<string> MakeSurfaces()
            {
                List<string> surface = new List<string>();
                surface.Add(GetTopLevelComment());
                surface.Add(MCNPformatHelper.GetSurface(GetIndex(), McnpSurfaces.GetSphere(center, radius)));
                return surface;
            }

            protected override List<string> MakeExternalSurfaces()
            {
                return new List<string>() {GetIndex().ToString()};
            }

            public override SourceSpecification GetSource()
            {
                return new SourceSpecification(poliMiSource, SourcesHelper.GetSphereSource(center, radius));
            }

            //protected override SourceSpecification MakeSources()
            //{
            //    return new SourceSpecification(poliMiSource, SourcesHelper.GetSphereSource(center, radius));
            //}
        }

        public class NblStandard : Component
        {
            private Point3D baseOfCylinder;
            private Point3D axis;
            private MaterialElement innermaterial;
            private MaterialElement canMaterial;
            private double height;
            private Encased<Point3D> baseOfPlug;
            private const string COMMENT = "NBL Standard";

            public NblStandard(Point3D Base, Point3D Axis, int FillMaterial, double Height,
                PoliMiSource Source, int mcnpIndex = Indices.SOURCE) : base(mcnpIndex, COMMENT)
            {
                baseOfCylinder = Base;
                axis = Axis;
                innermaterial = MaterialManager.GetMaterial(FillMaterial);
                height = Height;
                canMaterial = MaterialManager.GetMaterial(Materials.ALUMINUM);
                poliMiSource = Source;
                baseOfPlug = GetBaseOfPlug();
            }

            public override SourceSpecification GetSource()
            {
                return new SourceSpecification(poliMiSource,
                    SourcesHelper.GetCylinderSource(baseOfPlug.Inner,
                        new CylinderExtent(height, GetPowderChamberRadius(), axis)));
            }

            private double GetPowderChamberRadius()
            {
                return Extents.NblStandard.Radius - Extents.NblStandard.WallThickness;
            }

            //public override bool HasSourceTerm()
            //{
            //    return IsPoliMiSourceDefined();
            //}

            protected override List<string> MakeSurfaces()
            {
                List<string> surfaces = new List<string>();

                surfaces.Add(MCNPformatHelper.GetCommentLine(COMMENT));
                surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.NblStandard.OUTER_CAN),
                    McnpSurfaces.GetRightCircularCylinder(baseOfCylinder, GetOuterCan()), "Outer Can"));

                surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.NblStandard.INNER_CAN),
                    McnpSurfaces.GetRightCircularCylinder(GetInnerCanBase(), GetInnerCan()), "Inner Can"));

                //surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.NblStandard.OUTER_PLUG),
                //  McnpSurfaces.GetRightCircularCylinder(baseOfPlug.Outer, GetPlugOuter()), "Outer Plug"));

                surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.NblStandard.PLUG_PLANE_BOTTOM),
                    McnpSurfaces.GetPlane(baseOfPlug.Outer, axis), "Outer Plug"));

                surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.NblStandard.INNER_PLUG),
                    McnpSurfaces.GetRightCircularCylinder(baseOfPlug.Inner, GetPlugInner()), "Inner Plug"));

                surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.NblStandard.PLUG_PLANE_TOP),
                    McnpSurfaces.GetPlane(GetTopPlugCutPoint(baseOfPlug.Inner), axis), "Plug Cut Plane"));

                return surfaces;
            }

            private Point3D GetInnerCanBase()
            {
                return baseOfCylinder + Extents.NblStandard.BaseThickness * axis;
            }

            protected override List<string> MakeCells()
            {
                List<string> cells = new List<string>();
                cells.Add(MCNPformatHelper.GetCommentLine(COMMENT));
                cells.Add(MCNPformatHelper.GetCell(GetIndex(Indices.NblStandard.OUTER_CAN), canMaterial,
                    GetOuterCanSurfaces(), "Outer Can"));
                cells.Add(MCNPformatHelper.GetCell(GetIndex(Indices.NblStandard.CHAMBER), innermaterial,
                    GetChamberSurfaces(), "Chamber"));
                cells.Add(MCNPformatHelper.GetCell(GetIndex(Indices.NblStandard.INNER_PLUG), canMaterial,
                    GetInnerPlugSurfaces(), "Inner Plug"));
                cells.Add(MCNPformatHelper.GetCell(GetIndex(Indices.NblStandard.VOID_UPPER),
                    GlobalDefaults.GetFillMaterial(), GetUpperVoidSurfaces(), "Upper Void"));
                cells.Add(MCNPformatHelper.GetCell(GetIndex(Indices.NblStandard.VOID_LOWER),
                    GlobalDefaults.GetFillMaterial(), GetLowerVoidSurfaces(), "Lower Void"));
                return cells;
            }

            private List<int> GetLowerVoidSurfaces()
            {
                List<int> surfaces = new List<int>();
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.INNER_CAN));
                surfaces.Add(GetIndex(Indices.NblStandard.PLUG_PLANE_TOP));
                return surfaces;
            }

            private List<int> GetUpperVoidSurfaces()
            {
                List<int> surfaces = new List<int>();
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.INNER_PLUG));
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.PLUG_PLANE_TOP));
                return surfaces;
            }

            private List<int> GetInnerPlugSurfaces()
            {
                List<int> surfaces = new List<int>();
                surfaces.Add(GetIndex(Indices.NblStandard.PLUG_PLANE_BOTTOM));
                surfaces.Add(GetIndex(Indices.NblStandard.INNER_PLUG));
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.PLUG_PLANE_TOP));
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.INNER_CAN));
                return surfaces;
            }

            private List<int> GetChamberSurfaces()
            {
                List<int> surfaces = new List<int>();
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.INNER_CAN));
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.PLUG_PLANE_BOTTOM));
                return surfaces;
            }

            private List<int> GetOuterCanSurfaces()
            {
                List<int> surfaces = new List<int>();
                surfaces.Add(GetInteriorIndexBase(Indices.NblStandard.OUTER_CAN));
                surfaces.Add(GetIndex(Indices.NblStandard.INNER_CAN));
                return surfaces;
            }

            private Point3D GetTopPlugCutPoint(Point3D baseOfPlug)
            {
                return baseOfPlug + Extents.NblStandard.PlugHeight * axis;
            }

            private Encased<Point3D> GetBaseOfPlug()
            {
                Point3D baseOfPlugOuter = GetInnerCanBase() + height * axis;

                return new Encased<Point3D>
                {
                    Inner = baseOfPlugOuter + Extents.NblStandard.WallThickness * axis, Outer = baseOfPlugOuter
                };
            }

            private CylinderExtent GetPlugInner()
            {
                return new CylinderExtent(Extents.NblStandard.PlugHeight, Extents.NblStandard.PlugInnerRadius, axis);
            }

            private CylinderExtent GetPlugOuter()
            {
                return new CylinderExtent(Extents.NblStandard.PlugHeight, Extents.NblStandard.PlugOuterRadius, axis);
            }

            private CylinderExtent GetOuterCan()
            {
                return new CylinderExtent(Extents.NblStandard.Height, Extents.NblStandard.Radius, axis);
            }

            private CylinderExtent GetInnerCan()
            {
                return new CylinderExtent(
                    Extents.NblStandard.Height -
                    (Extents.NblStandard.WallThickness + Extents.NblStandard.BaseThickness),
                    GetPowderChamberRadius(), axis);
            }

            protected override List<string> MakeExternalSurfaces()
            {
                return new List<string>() {GetIndex(Indices.NblStandard.OUTER_CAN).ToString()};
            }
        }
    }
}
