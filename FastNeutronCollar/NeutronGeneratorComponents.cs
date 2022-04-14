using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public class NeutronGeneratorTube : Component
    {
        private const string COMMENT = "Neutron Generator Tube";
        private const string ENCLOSURE_COMMENT = "Enclosure";
        private const string INTERNAL_COMMENT = "Interior";
        private const string SOURCE_COMMENT = "D-D Source Defined By PoliMi Cards";
        private const int INTERIOR_INDEX_SHIFT = 1;

        private readonly MyPoint3D axis;
        private readonly MyPoint3D enclosureAxisLength;
        private readonly MyPoint3D internalAxisLength;

        private MaterialElement internalMat;
        private MaterialElement enclosureMat;

        public NeutronGeneratorTube(int mcnpIndex, MyPoint3D Center, MyPoint3D Axis, bool IncludeSource = true) : base(
            mcnpIndex, COMMENT)
        {
            axis = Point3DHelper.GetUnitVector(Axis);

            center = Center - (Extents.Mp320.LENGTH / 2) * axis;
            center -= (Extents.Mp320.HEIGHT_SHIFT) * axis;

            hasSourceTerm = IncludeSource;
            enclosureAxisLength = Extents.Mp320.LENGTH * axis;
            internalAxisLength = (Extents.Mp320.LENGTH -
                                  2 * Extents.Mp320.ENCLOSURE_THICK) * axis;

            internalMat = MaterialManager.GetMaterial(Materials.ELECTRONICS);
            enclosureMat = MaterialManager.GetMaterial(Materials.AL_ALLOY);
        }


        public override SourceSpecification GetSource()
        {
            List<string> sources = new List<string>();
            sources.Add(GetPointSource());
            return new SourceSpecification(PoliMiSource.DD, sources);
        }

        private string GetPointSource()
        {
            MyPoint3D sourcePoint = center + ((Extents.Mp320.SOURCE_FROM_CENTER + (Extents.Mp320.LENGTH / 2)) * axis);
            return SourcesHelper.GetPointSource(sourcePoint) + " " + MCNPformatHelper.GetInLineComment(SOURCE_COMMENT);
        }

        protected override List<string> MakeCells()
        {
            List<string> cells = new List<string>();
            cells.Add(GetEnclosureCell());
            cells.Add(GetInternalCell());
            return cells;
        }

        protected override List<string> MakeSurfaces()
        {
            List<string> surfaces = new List<string>();
            surfaces.Add(GetEnclosureSurface());
            surfaces.Add(GetInternalSurface());
            return surfaces;
        }

        private string GetInternalIndex()
        {
            return GetIndex(INTERIOR_INDEX_SHIFT).ToString();
        }

        private string GetEnclosureIndex()
        {
            return GetIndex().ToString();
        }

        private string GetEnclosureComment()
        {
            return MCNPformatHelper.GetInLineComment(ENCLOSURE_COMMENT);
        }

        private string GetInternalComment()
        {
            return MCNPformatHelper.GetInLineComment(INTERNAL_COMMENT);
        }

        private string GetInternalSurface()
        {
            string macroBody = McnpSurfaces.GetRightCircularCylinder(
                center + Extents.Mp320.ENCLOSURE_THICK * axis,
                internalAxisLength,
                Extents.Mp320.OUTER_RADIUS - Extents.Mp320.ENCLOSURE_THICK);
            return GetInternalIndex() + " " + macroBody + " " + GetInternalComment();
        }

        private string GetInternalCell()
        {
            return GetInternalIndex() + " " + internalMat.ToCell() + " " + GetInteriorIndexBase(INTERIOR_INDEX_SHIFT) +
                   GetCellImportanceAndComments(GetInternalComment());
        }

        private string GetEnclosureSurface()
        {
            string macroBody = McnpSurfaces.GetRightCircularCylinder(center,
                enclosureAxisLength, Extents.Mp320.OUTER_RADIUS);
            return GetEnclosureIndex() + " " + macroBody + " " + GetEnclosureComment();
        }

        private string GetEnclosureCell()
        {
            return GetEnclosureIndex() + " " + enclosureMat.ToCell() + " " + GetInteriorIndexBase() + " " +
                   GetInternalIndex() + GetCellImportanceAndComments(GetEnclosureComment());
        }

        protected override List<string> MakeExternalSurfaces()
        {
            return new List<string>() {GetEnclosureIndex()};
        }
    }

    public class He3TubeDetector : Component
    {
        private const string COMMENT = "He3 Tube ";
        private MyPoint3D axis;

        public He3TubeDetector(int mcnpIndex, MyPoint3D He3TubeCenter, MyPoint3D Axis, string Comment) : base(mcnpIndex,
            COMMENT + Comment, false)
        {
            center = He3TubeCenter;
            axis = Axis;
            PoliMiMPPostInputHelper.AddSecondDetector(GetIndex(Indices.EnclosedIndexOffsets.Inner));
        }

        protected override void InitializeSubComponents()
        {
            subComponents.Add(new EncasedCylinder(primaryIndex, GetEncasedCenter(), GetEncasedExtents(),
                GetEncasedMaterials(), false, GetEncasedComments(), IsInnerSource: false));
        }

        private Encased<string> GetEncasedComments()
        {
            return new Encased<string> {Inner = "He 3 gas", Outer = "Tube"};
        }

        private Encased<MyPoint3D> GetEncasedCenter()
        {
            return new Encased<MyPoint3D> {Inner = center, Outer = center};
        }

        private Encased<int> GetEncasedMaterials()
        {
            return new Encased<int> {Inner = Materials.HE3_GAS, Outer = Materials.ALUMINUM};
        }

        private Encased<CylinderExtent> GetEncasedExtents()
        {
            return new Encased<CylinderExtent>
            {
                Inner = new CylinderExtent
                {
                    Height = Extents.He3TubeMP320.TUBE_LENGTH,
                    Radius = Extents.He3TubeMP320.INNER_RADIUS,
                    Axis = axis
                },
                Outer = new CylinderExtent
                {
                    Height = Extents.He3TubeMP320.TUBE_LENGTH + 2.0 * Extents.He3TubeMP320.TUBE_THICKNESS,
                    Radius = Extents.He3TubeMP320.INNER_RADIUS + Extents.He3TubeMP320.TUBE_THICKNESS,
                    Axis = axis
                }
            };
        }
    }
}
