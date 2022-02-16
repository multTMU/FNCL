using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public class SelMeasurementComponents : Component
    {
        private const string COMMENT = "SEL measurement setup ";
        private readonly Point3D postTopCenter;
        private readonly int numberPucks;

        public const double HEIGHT_ABOVE_PUCK = 0.01;

        private const int POST_INDEX = 0;
        private const int PUCK_INDEX = 1;
        private const int PESLAB_INDEX = 2;
        private const int CONCRETE_INDEX = 3;

        private readonly int puckIndex;
        private readonly int postIndex;
        private readonly int peSlabIndex;
        private readonly int concreteIndex;

        public Point3D topOfPostPucks;
        private Point3D lastBottomCenter;

        public SelMeasurementComponents(int mcnpIndex, int NumberPucks) : base(mcnpIndex, COMMENT, true)
        {
            postTopCenter = Extents.SelMeasurementSetup.PostTopOffsetFromCenter;
            numberPucks = NumberPucks;

            puckIndex = primaryIndex + PUCK_INDEX;
            postIndex = primaryIndex + POST_INDEX;
            peSlabIndex = primaryIndex + PESLAB_INDEX;
            concreteIndex = primaryIndex + CONCRETE_INDEX;

            topOfPostPucks = postTopCenter;
            lastBottomCenter = postTopCenter;
        }

        public static Point3D GetCenterOfTopOfPucksAndPost(int nPucks)
        {
            Point3D centerTop = Extents.SelMeasurementSetup.PostTopOffsetFromCenter;
            return centerTop += (nPucks * Extents.SelMeasurementSetup.Puck.Height) *
                                Extents.SelMeasurementSetup.Puck.Axis;
        }

        protected override List<string> MakeCells()
        {
            List<string> cells = new List<string>();
            if (numberPucks > 0)
            {
                cells.Add(getCell(puckIndex, Materials.POLYURETHANE_FOAM));
            }

            cells.Add(getCell(postIndex, Materials.PLYWOOD));
            cells.Add(getCell(peSlabIndex, Materials.HDPE));
            cells.Add(getCell(concreteIndex, Materials.CONCRETE));

            return cells;
        }

        private string getCell(int index, int matIndex)
        {
            MaterialElement mat = MaterialManager.GetMaterial(matIndex);
            return index + " " + mat.ToCell() + " " + GetInside(index) + GetCellImportanceAndComments();
        }

        protected override List<string> MakeSurfaces()
        {
            List<string> surfaces = new List<string>();
            if (numberPucks > 0)
            {
                surfaces.Add(puckSurface());
            }

            surfaces.Add(woodenPostSurface());
            surfaces.Add(peSlabSurface());
            surfaces.Add(concreteSurface());
            return surfaces;
        }

        private string concreteSurface()
        {
            ExternalSurfaces.Add(concreteIndex.ToString());
            Point3D baseCenter = lastBottomCenter;
            baseCenter.Z -= Extents.SelMeasurementSetup.ConcreteFloor.Height;
            string macroBody =
                McnpSurfaces.GetRightCircularCylinder(baseCenter, Extents.SelMeasurementSetup.ConcreteFloor);
            return concreteIndex + " " + macroBody + " " + GetComments(additionalComment: "Concrete Floor");
        }

        private string peSlabSurface()
        {
            ExternalSurfaces.Add(peSlabIndex.ToString());
            Point3D slabCenter = lastBottomCenter;
            slabCenter.Z -= (Extents.SelMeasurementSetup.PEslab.Z / 2.0);
            lastBottomCenter.Z -= Extents.SelMeasurementSetup.PEslab.Z;
            string macroBody =
                McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(slabCenter,
                    Extents.SelMeasurementSetup.PEslab);
            return peSlabIndex + " " + macroBody + " " + GetComments(additionalComment: "Pe slab");
        }

        private string puckSurface()
        {
            ExternalSurfaces.Add(puckIndex.ToString());
            CylinderExtent puck = Extents.SelMeasurementSetup.Puck;
            puck.Height *= numberPucks;
            topOfPostPucks.Z += puck.Height;
            string macroBody = McnpSurfaces.GetRightCircularCylinder(postTopCenter, puck);
            return puckIndex + " " + macroBody + " " + GetComments(additionalComment: "Foam Puck(s)");
        }

        private string woodenPostSurface()
        {
            ExternalSurfaces.Add(postIndex.ToString());
            Point3D postCenter = Extents.SelMeasurementSetup.GetPostCenter(postTopCenter);
            lastBottomCenter.Z -= Extents.SelMeasurementSetup.PostExtents.Z;
            string macroBody =
                McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(postCenter,
                    Extents.SelMeasurementSetup.PostExtents);
            return postIndex + " " + macroBody + " " + GetComments(additionalComment: "Wood Post");
        }
    }
}
