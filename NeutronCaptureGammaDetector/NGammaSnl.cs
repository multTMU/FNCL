using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;

namespace NeutronCaptureGammaDetector
{
    public class NGammaSnlCubic : NGammaSnl<MyPoint3D>
    {
        public NGammaSnlCubic(int NumX, int NumY, double DetectorCenterSpacing, double SideShieldThickness,
            double FrontShieldThickness, MyPoint3D DetectorExtent, int ShieldMat, int DetectorMat,
            MPPostDetectorTypes DetectorType) : base(NumX, NumY, DetectorCenterSpacing, SideShieldThickness,
            FrontShieldThickness, DetectorExtent, ShieldMat, DetectorMat, DetectorType)
        {
        }

        protected override EncasedComponent<MyPoint3D> getDetector(FaceCoordinate det)
        {
            EncasedBlock detector = new EncasedBlock(GetDetectorIndex(det.Row, det.Col), "Cubic Detector", true,
                getCenters(det), getExtents(det), detectorMat, commentDetector);
            return detector;
        }
        private Encased<MyPoint3D> getCenters(FaceCoordinate det)
        {
            return new Encased<MyPoint3D>()
            {
                Inner = new MyPoint3D(),
                Outer = new MyPoint3D()
            };
        }

        private Encased<MyPoint3D> getExtents(FaceCoordinate det)
        {
            return new Encased<MyPoint3D>()
            {
                Inner = new MyPoint3D(),
                Outer = new MyPoint3D()
            };
        }
    }

    public abstract class NGammaSnl<TExtent> : Component
    {
        protected struct FaceCoordinate
        {
            public MyPoint3D Face;
            public int Row;
            public int Col;

            public FaceCoordinate(int row, int col, MyPoint3D face)
            {
                Face = face;
                Row = row;
                Col = col;
            }
        }

        protected readonly Encased<MaterialElement> detectorMat;
        //protected readonly MaterialElement shieldMat;
        //protected readonly MaterialElement detectorMat;
        protected readonly MyPoint3D detectorFacePlaneCenter;
        protected readonly double sideShieldThickness;
        protected readonly double detectorCenterSpacing;
        protected readonly double frontShieldThickness;
        protected readonly int nX;
        protected readonly int nY;
        protected readonly TExtent detectorExtent;

        protected readonly Encased<string> commentDetector;
        //protected List<EncasedComponent<TExtent>> detectors;

        protected List<FaceCoordinate> detectorFaceCenters;
        protected readonly MPPostDetectorTypes detectorType;

        public NGammaSnl(int NumX, int NumY, double DetectorCenterSpacing, double SideShieldThickness, double FrontShieldThickness,
            TExtent DetectorExtent, int ShieldMat, int DetectorMat, MPPostDetectorTypes DetectorType) : base(
            Indices.NGammaDetector.BASE_INDEX, "SNL Neutron Capture Gamma Detector")
        {
            commentDetector = new Encased<string>("detector", "shield");
            nX = NumX;
            nY = NumY;
            detectorMat = new Encased<MaterialElement>
            {
                Inner = MaterialManager.GetMaterial(DetectorMat),
                Outer = MaterialManager.GetMaterial(ShieldMat)
            };
   
            sideShieldThickness = SideShieldThickness;
            detectorCenterSpacing = DetectorCenterSpacing;
            detectorExtent = DetectorExtent;
            frontShieldThickness = FrontShieldThickness;
            detectorType = DetectorType;
            SetDetectorFaceCenters();
        }

        protected override void InitializeSubComponents()
        {
            foreach (var d in detectorFaceCenters)
            {
                subComponents.Add(getDetector(d));
            }
        }

        protected abstract EncasedComponent<TExtent> getDetector(FaceCoordinate faceCoordinate);

        private void SetDetectorFaceCenters()
        {
            detectorFaceCenters = new List<FaceCoordinate>();

            MyPoint3D upperCorner = detectorFacePlaneCenter;
            upperCorner.X -= ((double)nX/2)*detectorCenterSpacing;
            upperCorner.Y -= ((double)nY / 2) * detectorCenterSpacing;

            for (int i = 0; i < nX; i++)
            {
                for (int j = 0; j < nY; j++)
                {
                    double dx = (i + 0.5) * detectorCenterSpacing;
                    double dy = (j + 0.5) * detectorCenterSpacing;
                    detectorFaceCenters.Add(new FaceCoordinate(i, j,
                        new MyPoint3D(upperCorner.X + dx, upperCorner.Y + dy, upperCorner.Z)));
                }
            }

        }

        //protected override List<string> MakeCells()
        //{
        //    List<string> cells = new List<string>();
        //    //cells.Add(GetShieldCell());
        //    cells.AddRange(GetDetectorCells());
        //    return cells;
        //}

        //private List<string> GetDetectorCells()
        //{
        //    List<string> cells = new List<string>();
        //    foreach (var d in GetDetectorIndicesIntegers())
        //    {
        //        cells.Add(MCNPformatHelper.GetCell(d, detectorMat, GetInside(d), "detector"));
        //        PoliMiMPPostInputHelper.AddDetectorCell(d);
        //    }

        //    return cells;
        //}

        private List<int> GetDetectorIndicesIntegers()
        {
            List<int> cells = new List<int>();
            for (int row = 0; row < nX; row++)
            {
                for (int col = 0; col < nY; col++)
                {
                    cells.Add(GetDetectorIndex(row, col));
                }
            }

            return cells;
        }
        protected int GetDetectorIndex(int row, int col)
        {
            return GetIndex(Indices.NGammaDetector.DETECTOR_ROW_1_COL_1) + 10 * (row + 1) +
                   (col + 1);
        }

        //protected override List<string> MakeExternalSurfaces()
        //{
        //    return new List<string>();// { GetShieldIndex().ToString() };
        //}

        //protected override List<string> MakeSurfaces()
        //{
        //    List<string> surfaces = new List<string>();
        //    //surfaces.Add(GetShieldSurface());
        //    surfaces.AddRange(GetDetectorSurfaces());
        //    return surfaces;
        //}

        //    private List<string> GetDetectorSurfaces()
        //    {
        //        List<string> surfaces = new List<string>();

        //        foreach (var d in detectorFaceCenters)
        //        {
        //            surfaces.Add(MCNPformatHelper.GetSurface(GetDetetorIndex(d.Row, d.Col),
        //                GetDetectorMacroBody(d), GetDetectorComment(d.Row, d.Col)));
        //        }

        //        return surfaces;
        //    }

        //    private string GetDetectorMacroBody(FaceCoordinate detectorFace)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private string GetDetectorComment(int row, int col)
        //    {
        //        return "Row: " + (row + 1).ToString() + " Col: " + (col + 1).ToString();
        //    }

        //private int GetDetetorIndex(int row, int col)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
