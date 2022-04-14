namespace FastNeutronCollar
{
    //public class HollowCylinderSource : HollowCylinderNoSource
    //{
    //    private const string SOURCE = "Source";
    //    private readonly PoliMiSource source;

    //    public HollowCylinderSource(int mcnpIndex, MyPoint3D Center, MyPoint3D Axis, double Height, double InnerRadius,
    //        double OuterRadius, MaterialElement InnerMat, MaterialElement OuterMat, PoliMiSource Source,
    //        string extraCommnent = SOURCE) :
    //        base(mcnpIndex, Center, Axis, Height, InnerRadius, OuterRadius, InnerMat, OuterMat, extraCommnent)
    //    {
    //        source = Source;
    //    }

    //    //public HollowCylinderSource(int mcnpIndex, MyPoint3D Center, UraniumHollowCylinderSpec spec,
    //    //    string extraCommnent = SOURCE) : base(mcnpIndex, Center, spec.Axis, spec.Height, spec.InnerRadius,
    //    //    spec.OuterRadius, spec.InnerMat, extraCommnent)
    //    //{

    //    //}

    //    public override SourceSpecification GetSource()
    //    { List<string> sourceSpec = new List<string>();

    //        sourceSpec.Add("sdef pos=" + center.ToString() + " rad=d1 cel=" + GetIndex(OUTER));
    //        sourceSpec.Add("si1 " + extents.Inner.Radius.ToString(MyPoint3D.FORMAT) + " " + MCNPsurfacesHelpers
    //            .BoundingSphereRadiusForCylinder(extents.Outer.Radius, extents.Outer.Axis)
    //            .ToString(MyPoint3D.FORMAT));
    //        sourceSpec.Add("sp1 -21 2");
    //        return new SourceSpecification(source, sourceSpec);
    //    }
    //}

    //public class HollowCylinderNoSource : Component
    //{
    //    private const string COMMENT = "Hollow Cylinder";

    //    private const bool TOP_LEVEL = true;
    //    //  protected readonly MyPoint3D baseCenter;
    //    //   protected readonly MyPoint3D axisVector;
    //    //   protected readonly double innerRadius;
    //    //   protected readonly double outerRadius;
    //    //  private readonly MaterialElement innerMat;
    //    //   private readonly MaterialElement outerMat;

    //    protected const int OUTER = 0;
    //    protected const int INNER = 1;

    //    private Encased<string> comments = new Encased<string>("Inner Cylinder", "Outer Cylinder");

    //    // can we use Encased Cylinder here
    //    private EncasedCylinder hollowCylinder;
    //    protected Encased<CylinderExtent> extents;

    //    public HollowCylinderNoSource(int mcnpIndex, MyPoint3D Center, MyPoint3D Axis, double Height, double InnerRadius,
    //        double OuterRadius, MaterialElement InnerMat, MaterialElement OuterMat, string extraComment = "NoSource") :
    //        base(mcnpIndex, COMMENT + " " + extraComment, TOP_LEVEL)
    //    {
    //        //  innerRadius = InnerRadius;
    //        //    outerRadius = OuterRadius;

    //        //  innerMat = InnerMat;
    //        //   outerMat = OuterMat;

    //        // baseCenter = Center - (Height / 2) * Axis;
    //        // axisVector = Height * Axis;

    //        Encased<MyPoint3D> encasedCenter = new Encased<MyPoint3D>(Center, Center);
    //        extents = new Encased<CylinderExtent>
    //        {
    //            Inner = new CylinderExtent(Height, InnerRadius, Axis),
    //            Outer = new CylinderExtent(Height, OuterRadius, Axis)
    //        };

    //        Encased<MaterialElement> materials = new Encased<MaterialElement>(InnerMat, OuterMat);
    //        hollowCylinder = new EncasedCylinder(primaryIndex, encasedCenter, extents, materials, true, comments);
    //    }

    //    public HollowCylinderNoSource(int mcnpIndex, MyPoint3D Center, Encased<CylinderExtent> Extents,
    //        Encased<MaterialElement> Materials, string extraComment = "NoSource") :
    //        base(mcnpIndex, COMMENT + " " + extraComment, TOP_LEVEL)
    //    {
    //        Encased<MyPoint3D> encasedCenter = new Encased<MyPoint3D>(Center, Center);
    //        extents = Extents;
    //        hollowCylinder = new EncasedCylinder(primaryIndex, encasedCenter, extents, Materials, true, comments);
    //    }

    //    protected override void InitializeSubComponents()
    //    {
    //        subComponents.Add(hollowCylinder);
    //    }

    //    //protected override List<string> MakeSurfaces()
    //    //{
    //    //    List<string> surfaces = new List<string>();
    //    //    surfaces.Add(GetInnerCylinderSurface());
    //    //    surfaces.Add(GetOuterCylinderSurface());
    //    //    return surfaces;
    //    //}

    //    //protected override List<string> MakeExternalSurfaces()
    //    //{
    //    //    return new List<string>() {GetIndex(OUTER).ToString()};
    //    //}

    //    //private string GetOuterCylinderSurface()
    //    //{
    //    //    string macroBody = MCNPsurfaces.GetRightCircularCylinder(baseCenter, axisVector, outerRadius);
    //    //    return GetIndex(OUTER) + " " + macroBody + " " + GetComments();
    //    //}

    //    //private string GetInnerCylinderSurface()
    //    //{
    //    //    string macroBody = MCNPsurfaces.GetRightCircularCylinder(baseCenter, axisVector, innerRadius);
    //    //    return GetIndex(INNER) + " " + macroBody + " " + GetComments();
    //    //}

    //    //protected override List<string> MakeCells()
    //    //{
    //    //    List<string> cells = new List<string>();
    //    //    cells.Add(GetInnerCylinderCell());
    //    //    cells.Add(GetOuterCylinderCell());
    //    //    return cells;
    //    //}

    //    //private string GetOuterCylinderCell()
    //    //{
    //    //    return GetIndex(OUTER) + " " + outerMat.ToCell() + " " + GetInteriorIndex(OUTER) + " " + GetIndex(INNER) +
    //    //           " " + UniverseAndImportanceHelper.UniverseAndImportance() + " " + GetComments();
    //    //}

    //    //private string GetInnerCylinderCell()
    //    //{
    //    //    return GetIndex(INNER) + " " + innerMat.ToCell() + " " + GetInteriorIndex(INNER) + " " +
    //    //           UniverseAndImportanceHelper.UniverseAndImportance() + " " + GetComments();
    //    //}
    //}
}
