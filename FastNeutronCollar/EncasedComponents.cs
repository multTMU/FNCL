using System;
using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public abstract class EncasedComponent<TExtents> : Component
    {
        private const string DESCRIPTION = "Encased";
        protected Encased<Point3D> centerEncased;
        protected Encased<TExtents> extents;
        protected Encased<MaterialElement> material;
        private readonly Encased<string> componentComment;
        private readonly List<int> interiorCells;
        protected readonly bool innerSource;

        protected EncasedComponent(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Center,
            Encased<TExtents> Extents, Encased<int> Material,
            Encased<string> ComponentComment, PoliMiSource Source = PoliMiSource.None, bool InnerSource = true,
            string comment = DESCRIPTION, List<int> InteriorCells = null) : base(
            mcnpIndex, Comment, TopLevel)
        {
            centerEncased = Center;
            extents = Extents;
            material = new Encased<MaterialElement>(MaterialManager.GetMaterial(Material.Inner),
                MaterialManager.GetMaterial(Material.Outer));
            componentComment = ComponentComment;
            interiorCells = InteriorCells;
            poliMiSource = Source;
            innerSource = InnerSource;
        }

        protected EncasedComponent(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Center,
            Encased<TExtents> Extents, Encased<MaterialElement> Material,
            Encased<string> ComponentComment, PoliMiSource Source = PoliMiSource.None, bool InnerSource = true,
            string comment = DESCRIPTION, List<int> InteriorCells = null) : base(
            mcnpIndex, Comment, TopLevel)
        {
            centerEncased = Center;
            extents = Extents;
            material = Material;
            componentComment = ComponentComment;
            interiorCells = InteriorCells;
            poliMiSource = Source;
            innerSource = InnerSource;
        }

        public abstract Encased<double> GetVolume();

        public Encased<string> GetCellsLabels()
        {
            return new Encased<string>(GetIndex(Indices.EnclosedIndexOffsets.Inner).ToString(),
                GetIndex(Indices.EnclosedIndexOffsets.Outer).ToString());
        }

        protected override List<string> MakeExternalSurfaces()
        {
            return new List<string>() {GetIndex(Indices.EnclosedIndexOffsets.Outer).ToString()};
        }

        protected override List<string> MakeCells()
        {
            List<string> cells = new List<string>();
            cells.Add(GetInnerCell());
            cells.Add(GetOuterCell());
            return cells;
        }

        private string GetOuterCell()
        {
            //return GetIndex(Indices.EnclosedIndexOffsets.Outer) + " " + material.Outer.ToCell() + " " +
            //       GetInteriorIndexBase(Indices.EnclosedIndexOffsets.Outer) + " " +
            //       GetIndex(Indices.EnclosedIndexOffsets.Inner) + GetCellImportanceAndComments(componentComment.Outer);

            return MCNPformatHelper.GetCell(GetIndex(Indices.EnclosedIndexOffsets.Outer), material.Outer,
                GetOuterSurfaces(), componentComment.Outer);
        }

        private List<int> GetOuterSurfaces()
        {
            return new List<int>()
            {
                GetInteriorIndexBase(Indices.EnclosedIndexOffsets.Outer),
                GetIndex(Indices.EnclosedIndexOffsets.Inner)
            };
        }

        private string GetInnerCell()
        {
            //return GetIndex(Indices.EnclosedIndexOffsets.Inner) + " " + material.Inner.ToCell() + " " +
            //       GetInteriorIndexBase(Indices.EnclosedIndexOffsets.Inner) + " " + GetInteriorCells() +
            //       GetCellImportanceAndComments(componentComment.Inner);

            return MCNPformatHelper.GetCell(GetIndex(Indices.EnclosedIndexOffsets.Inner), material.Inner,
                GetInnerSurfaces(), componentComment.Inner);
        }

        private List<int> GetInnerSurfaces()
        {
            List<int> surfaces = new List<int>();
            surfaces.Add(GetInteriorIndexBase(Indices.EnclosedIndexOffsets.Inner));
            if (interiorCells != null)
            {
                surfaces.AddRange(interiorCells);
            }

            return surfaces;
        }

        private string GetInteriorCells()
        {
            if (interiorCells != null)
            {
                string inside = "";
                foreach (var c in interiorCells)
                {
                    inside += (c + " ");
                }

                return inside;
            }

            return string.Empty;
        }

        protected override List<string> MakeSurfaces()
        {
            List<string> surfaces = new List<string>();
            // surfaces.Add(GetTopLevelComment());
            surfaces.Add(GetInnerSurface());
            surfaces.Add(GetOuterSurface());
            return surfaces;
        }

        private string GetOuterSurface()
        {
            return GetIndex(Indices.EnclosedIndexOffsets.Outer) + " " + GetMacroBodyOuter() + " " +
                   GetComments(additionalComment: componentComment.Outer);
        }

        protected abstract string GetMacroBodyInner();
        protected abstract string GetMacroBodyOuter();

        private string GetInnerSurface()
        {
            return GetIndex(Indices.EnclosedIndexOffsets.Inner) + " " + GetMacroBodyInner() + " " +
                   GetComments(additionalComment: componentComment.Inner);
        }
    }

    public class EncasedCylinder : EncasedComponent<CylinderExtent>
    {
        private const string DESCRIPTION = "Cylinder";

        public EncasedCylinder(int mcnpIndex, Encased<Point3D> Center, Encased<CylinderExtent> Extents,
            Encased<int> Material,
            bool TopLevel, Encased<string> ComponentComment, PoliMiSource Source = PoliMiSource.None,
            bool IsInnerSource = true, string comment = DESCRIPTION,
            List<int> InteriorCells = null) : base(mcnpIndex, DESCRIPTION, TopLevel, Center, Extents, Material,
            ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public EncasedCylinder(int mcnpIndex, Encased<Point3D> Center, Encased<CylinderExtent> Extents,
            Encased<MaterialElement> Material,
            bool TopLevel, Encased<string> ComponentComment, PoliMiSource Source = PoliMiSource.None,
            bool IsInnerSource = true, string comment = DESCRIPTION,
            List<int> InteriorCells = null) : base(mcnpIndex, DESCRIPTION, TopLevel, Center, Extents, Material,
            ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        protected override string GetMacroBodyOuter()
        {
            Point3D baseCenter = GetBaseCenter(centerEncased.Outer, extents.Outer);
            return McnpSurfaces.GetRightCircularCylinder(baseCenter, extents.Outer.Axis, extents.Outer.Height,
                extents.Outer.Radius);
        }

        public override Encased<double> GetVolume()
        {
            return new Encased<double>
            {
                Inner = VolumeHelper.GetCylinderVolume(extents.Inner),
                Outer = VolumeHelper.GetCylinderVolume(extents.Outer)
            };
        }

        protected override string GetMacroBodyInner()
        {
            Point3D baseCenter = GetBaseCenter(centerEncased.Inner, extents.Inner);
            return McnpSurfaces.GetRightCircularCylinder(baseCenter, extents.Inner.Axis, extents.Inner.Height,
                extents.Inner.Radius);
        }

        private Point3D GetBaseCenter(Point3D center, CylinderExtent extent)
        {
            return center - (extent.Height / 2) * extent.Axis;
        }
    }

    public class EncasedArbitrarilyOrientedBox : EncasedComponent<Matrix3D>
    {
        public EncasedArbitrarilyOrientedBox(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Corner,
            Encased<Matrix3D> Extents, Encased<int> Material, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None, bool InnerSource = true, string comment = "Encased",
            List<int> InteriorCells = null) : base(mcnpIndex, Comment, TopLevel, Corner, Extents, Material,
            ComponentComment, Source, InnerSource, comment, InteriorCells)
        {
        }

        public EncasedArbitrarilyOrientedBox(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Corner,
            Encased<Matrix3D> Extents, Encased<MaterialElement> Material, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None, bool InnerSource = true, string comment = "Encased",
            List<int> InteriorCells = null) : base(mcnpIndex, Comment, TopLevel, Corner, Extents, Material,
            ComponentComment, Source, InnerSource, comment, InteriorCells)
        {
        }

        public override Encased<double> GetVolume()
        {
            return new Encased<double>
            {
                Inner = Point3DHelper.GetVolume(extents.Inner), Outer = Point3DHelper.GetVolume(extents.Outer)
            };
        }

        protected override string GetMacroBodyInner()
        {
            // centerEncased is used as the Corner in this context
            return McnpSurfaces.GetArbitrarilyOrientedOrthogonalBox(centerEncased.Inner, extents.Inner.Xrow,
                extents.Inner.Yrow, extents.Inner.Zrow);
        }

        protected override string GetMacroBodyOuter()
        {
            // centerEncased is used as the Corner in this context
            return McnpSurfaces.GetArbitrarilyOrientedOrthogonalBox(centerEncased.Outer, extents.Outer.Xrow,
                extents.Outer.Yrow, extents.Outer.Zrow);
        }
    }

    public class EncasedBlock : EncasedComponent<Point3D>
    {
        private const string DESCRIPTION = "Cuboid";

        public EncasedBlock(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Center,
            Encased<Point3D> Extents, Encased<int> Material, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None, bool IsInnerSource = true,
            string comment = DESCRIPTION, List<int> InteriorCells = null) : base(mcnpIndex, Comment, TopLevel,
            Center, Extents, Material,
            ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public EncasedBlock(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Center,
            Encased<Point3D> Extents, Encased<MaterialElement> Material, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None, bool IsInnerSource = true,
            string comment = DESCRIPTION, List<int> InteriorCells = null) : base(mcnpIndex, Comment, TopLevel,
            Center, Extents, Material,
            ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public EncasedBlock(int mcnpIndex, bool TopLevel, Point3D Center, Point3D Extents, double thickness,
            int innerMat, int outermat, Encased<string> ComponentComment, PoliMiSource Source = PoliMiSource.None,
            bool IsInnerSource = true, string comment = DESCRIPTION,
            List<int> InteriorCells = null) : base(
            mcnpIndex, comment, TopLevel,
            new Encased<Point3D> {Inner = Center, Outer = Center},
            new Encased<Point3D> {Inner = Extents, Outer = Extents + 2.0 * thickness},
            new Encased<MaterialElement>
            {
                Inner = MaterialManager.GetMaterial(innerMat), Outer = MaterialManager.GetMaterial(outermat)
            },
            ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public EncasedBlock(int mcnpIndex, bool TopLevel, Point3D Center, Point3D Extents, double thickness,
            MaterialElement innerMat, MaterialElement outermat, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None,
            bool IsInnerSource = true, string comment = DESCRIPTION,
            List<int> InteriorCells = null) : base(
            mcnpIndex, comment, TopLevel,
            new Encased<Point3D> {Inner = Center, Outer = Center},
            new Encased<Point3D> {Inner = Extents, Outer = Extents + 2.0 * thickness},
            new Encased<MaterialElement> {Inner = innerMat, Outer = outermat},
            ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public override Encased<double> GetVolume()
        {
            return new Encased<double>
            {
                Inner = VolumeHelper.GetCuboidVolume(extents.Inner),
                Outer = VolumeHelper.GetCuboidVolume(extents.Outer)
            };
        }

        protected override string GetMacroBodyInner()
        {
            return McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(centerEncased.Inner, extents.Inner);
        }

        protected override string GetMacroBodyOuter()
        {
            return McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(centerEncased.Outer, extents.Outer);
        }
    }

    public class EncasedSphere : EncasedComponent<double>
    {
        private const string DESCRIPTION = "Sphere";

        public EncasedSphere(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Center,
            Encased<double> Extents, Encased<int> Material, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None, bool IsInnerSource = true,
            string comment = "Encased", List<int> InteriorCells = null) : base(mcnpIndex, Comment, TopLevel, Center,
            Extents, Material, ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public EncasedSphere(int mcnpIndex, string Comment, bool TopLevel, Encased<Point3D> Center,
            Encased<double> Extents, Encased<MaterialElement> Material, Encased<string> ComponentComment,
            PoliMiSource Source = PoliMiSource.None, bool IsInnerSource = true,
            string comment = "Encased", List<int> InteriorCells = null) : base(mcnpIndex, Comment, TopLevel, Center,
            Extents, Material, ComponentComment, Source, IsInnerSource, comment, InteriorCells)
        {
        }

        public override Encased<double> GetVolume()
        {
            return new Encased<double>
            {
                Inner = VolumeHelper.GetSphereVolume(extents.Inner),
                Outer = VolumeHelper.GetSphereVolume(extents.Outer)
            };
        }

        protected override string GetMacroBodyInner()
        {
            return McnpSurfaces.GetSphere(centerEncased.Inner, extents.Inner);
        }

        protected override string GetMacroBodyOuter()
        {
            return McnpSurfaces.GetSphere(centerEncased.Outer, extents.Outer);
        }
    }
}
