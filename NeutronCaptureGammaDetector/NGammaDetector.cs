using System.Collections.Generic;
using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;

namespace NeutronCaptureGammaDetector
{
    public class NGammaDetector : Component
    {
        private MaterialElement shieldMat;
        private MaterialElement detectorMat;
        private Point3D detectorFacePlaneCenter;
        private double shieldThickness;
        private Point3D shieldExtents;
        private double deltaXY;
        private Point3D firstDetector;

        public NGammaDetector(Point3D DetectorFacePlaneCenter, double ShieldThickness) : base(
            Indices.NGammaDetector.BASE_INDEX, "Neutron Capture Gamma Detector")
        {
            shieldMat = MaterialManager.GetMaterial(Materials.LEAD);
            detectorMat = MaterialManager.GetMaterial(Materials.NAI);

            detectorFacePlaneCenter = DetectorFacePlaneCenter;
            shieldThickness = ShieldThickness;
            SetShieldExtents();
        }

        public void OverrideShieldMaterial(int newShieldMaterial)
        {
            shieldMat = MaterialManager.GetMaterial(newShieldMaterial);
        }

        private void SetShieldExtents()
        {
            shieldExtents =
                GetShieldExtentsToCoverDetectors(); ///Extents.NGammaDetector.SHIELD_EXTENTS;// + shieldThickness * normalAxis;
            shieldExtents.Y += shieldThickness;
        }

        protected override List<string> MakeCells()
        {
            List<string> cells = new List<string>();
            cells.Add(GetShieldCell());
            cells.AddRange(GetDetectorCells());
            return cells;
        }

        private List<string> GetDetectorCells()
        {
            List<string> cells = new List<string>();
            foreach (var d in GetDetectorIndicesIntegers())
            {
                cells.Add(MCNPformatHelper.GetCell(d, detectorMat, GetInside(d), "detector"));
                PoliMiMPPostInputHelper.AddDetectorCell(d);
            }

            return cells;
        }

        //private List<string> GetDetectorIndicesString()
        //{
        //    List<int> cellsInts = GetDetectorIndicesIntegers();
        //    List<string> cellsString = new List<string>();
        //    foreach (var c in cellsInts)
        //    {
        //        cellsString.Add(c.ToString());
        //    }

        //    return cellsString;
        //}

        private List<int> GetDetectorIndicesIntegers()
        {
            List<int> cells = new List<int>();
            for (int row = 0; row < NGammaHelpers.NUMBER_ROWS; row++)
            {
                for (int col = 0; col < NGammaHelpers.NUMBER_COLUMNS; col++)
                {
                    cells.Add(GetDetetorIndex(row, col));
                }
            }

            return cells;
        }

        private string GetShieldCell()
        {
            return MCNPformatHelper.GetCell(GetShieldIndex(), shieldMat, GetShieldCells(), "NGamma Shield");
        }

        private List<int> GetShieldCells()
        {
            List<int> cells = new List<int>();
            cells.Add(GetInside(GetShieldIndex()));
            cells.AddRange(GetDetectorIndicesIntegers());
            return cells;
        }

        protected override List<string> MakeExternalSurfaces()
        {
            return new List<string>() {GetShieldIndex().ToString()};
        }

        protected override List<string> MakeSurfaces()
        {
            List<string> surfaces = new List<string>();
            surfaces.Add(GetShieldSurface());
            surfaces.AddRange(GetDetectorSurfaces());
            return surfaces;
        }

        private List<string> GetDetectorSurfaces()
        {
            List<string> surfaces = new List<string>();
            firstDetector = GetFirstDetectorPosition();
            deltaXY = 2 * Extents.NGammaDetector.DETECTOR_RADIUS + Extents.NGammaDetector.MIN_SHIELD_THICKNESS;
            for (int row = 0; row < NGammaHelpers.NUMBER_ROWS; row++)
            {
                for (int col = 0; col < NGammaHelpers.NUMBER_COLUMNS; col++)
                {
                    surfaces.Add(MCNPformatHelper.GetSurface(GetDetetorIndex(row, col),
                        GetDetectorMacroBody(row, col), GetDetectorComment(row, col)));
                }
            }

            return surfaces;
        }

        private string GetDetectorComment(int row, int col)
        {
            return "Row: " + (row + 1).ToString() + " Col: " + (col + 1).ToString();
        }

        private string GetDetectorMacroBody(int row, int col)
        {
            Point3D detectorBase = firstDetector;
            detectorBase.X += deltaXY * col;
            detectorBase.Z += deltaXY * row;

            return McnpSurfaces.GetRightCircularCylinder(detectorBase, Extents.NGammaDetector.Extent);
        }

        private int GetDetetorIndex(int row, int col)
        {
            return GetIndex(Indices.NGammaDetector.DETECTOR_ROW_1_COL_1) + 10 * (row + 1) +
                   (col + 1);
        }

        private Point3D GetFirstDetectorPosition()
        {
            // Point3D offset = shieldExtents - (shieldExtents / 2) * normalAxis;
            Point3D corner = detectorFacePlaneCenter; //- offset;
            corner.X += (Extents.NGammaDetector.DETECTOR_RADIUS + Extents.NGammaDetector.MIN_SHIELD_THICKNESS) -
                        (shieldExtents.X / 2);
            corner.Z += (Extents.NGammaDetector.DETECTOR_RADIUS + Extents.NGammaDetector.MIN_SHIELD_THICKNESS) -
                        (shieldExtents.Z / 2);
            corner.Y += Extents.NGammaDetector.THIN_SKIN; // + shieldThickness;
            return corner;
        }

        private string GetShieldSurface()
        {
            Point3D shieldCenter = detectorFacePlaneCenter;
            shieldCenter.Y += (shieldExtents.Y / 2) - shieldThickness;

            return MCNPformatHelper.GetSurface(GetShieldIndex(),
                McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(shieldCenter, shieldExtents),
                "Shield Block");
        }

        private int GetShieldIndex()
        {
            return GetIndex(Indices.NGammaDetector.SHIELD);
        }

        private Point3D GetShieldExtentsToCoverDetectors()
        {
            double rowWidth = (2 + NGammaHelpers.NUMBER_ROWS - 1) * Extents.NGammaDetector.MIN_SHIELD_THICKNESS +
                              2 * NGammaHelpers.NUMBER_ROWS * Extents.NGammaDetector.DETECTOR_RADIUS;
            double colWidth = (2 + NGammaHelpers.NUMBER_COLUMNS - 1) * Extents.NGammaDetector.MIN_SHIELD_THICKNESS +
                              2 * NGammaHelpers.NUMBER_COLUMNS * Extents.NGammaDetector.DETECTOR_RADIUS;

            return new Point3D(colWidth,
                Extents.NGammaDetector.DETECTOR_LENGTH + 2.0 * Extents.NGammaDetector.THIN_SKIN, rowWidth);
        }
    }
}
