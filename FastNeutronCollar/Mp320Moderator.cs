using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public class Mp320Moderator : Component
    {
        private const string COMMENT = "Mp320 Moderator";
        private Point3D moderatorBulk;
        private readonly bool useCdShield;
        private readonly double cdThickness;
        private readonly bool usePdShield;
        private readonly double pbThickness;
        private readonly double heightDisplacement;
        private MaterialElement hdpeMat;

        private int neutronIndex;
        private int he3Index;
        private Point3D faceCenter;
        private double additionalThickness;


        private bool useSideShieldLeftPanelTwo;
        private bool useSideShieldRightPanelOne;
        private Point3D sideShieldDimensions;

        public Mp320Moderator(int mcnpIndex, bool UseCdShield, double CdThickness,
            bool UsePdShield, double PbThickness, double HeightDisplacement, double extraThickness,
            Point3D SideShieldDimensions, bool UseSideShieldLeftPanelTwo, bool UseSideShieldRightPanelOne,
            int neutronGeneratorOutermostIndex, int he3TubeOutermostIndex) : base(
            mcnpIndex, COMMENT)
        {
            InitializeMaterials();

            useCdShield = UseCdShield;
            cdThickness = CdThickness;
            usePdShield = UsePdShield;
            pbThickness = PbThickness;
            useSideShieldLeftPanelTwo = UseSideShieldLeftPanelTwo;
            useSideShieldRightPanelOne = UseSideShieldRightPanelOne;
            sideShieldDimensions = SideShieldDimensions;

            heightDisplacement = HeightDisplacement;
            additionalThickness = extraThickness + pbThickness + cdThickness;

            neutronIndex = neutronGeneratorOutermostIndex;
            he3Index = he3TubeOutermostIndex;
            AddPEoffsetToBulk();
            AdjustFaceCenter();
        }

        protected override void InitializeSubComponents()
        {
            if (useCdShield || usePdShield)
            {
                subComponents.Add(new Mp320ModeratorShield(faceCenter, useCdShield, cdThickness, usePdShield,
                    pbThickness));
            }

            if (useSideShieldRightPanelOne)
            {
                subComponents.Add(new RightPanelSideShield(primaryIndex, heightDisplacement, sideShieldDimensions));
            }

            if (useSideShieldLeftPanelTwo)
            {
                subComponents.Add(new LeftPanelSideShield(primaryIndex, heightDisplacement, sideShieldDimensions));
            }
        }

        private void AdjustFaceCenter()
        {
            faceCenter = AddOffsetToFace(); // 
            faceCenter.Z += heightDisplacement;
        }

        private Point3D AddOffsetToFace()
        {
            Point3D face = Extents.Mp320.ModeratorFaceCenter;
            face.Y -= (pbThickness + cdThickness);

            if (useSideShieldRightPanelOne || useSideShieldLeftPanelTwo)
            {
                face.Y -= sideShieldDimensions.Y;
            }

            return face;
        }

        private void AddPEoffsetToBulk()
        {
            Point3D bulk = Extents.Mp320.ModeratorBulk;
            bulk.Y += additionalThickness;
            moderatorBulk = bulk;
        }

        private void InitializeMaterials()
        {
            hdpeMat = MaterialManager.GetMaterial(Materials.HDPE);
        }

        protected override List<string> MakeCells()
        {
            List<string> mp320Cells = new List<string>();
            mp320Cells.Add(GetTopLevelComment());
            mp320Cells.Add(GetModeratorCell());
            mp320Cells.Add(GetRightCorner());
            mp320Cells.Add(GetLeftCorner());
            mp320Cells.AddRange(base.MakeCells());
            return mp320Cells;
        }

        private string GetLeftCorner()
        {
            return (GlobalDefaults.INTERNAL_WORLD + Indices.Mp320.MODERATOR_LEFT_VOID).ToString() + " " +
                   MaterialManager.GetMaterial(GlobalDefaults.FillMaterial).ToCell() + " " + GetInteriorIndexBase() +
                   " " + GetFrontPlaneIndex() + " " + GetLeftPlaneIndex() + " " + GetCellImportanceAndComments();
        }

        private string GetRightCorner()
        {
            return (GlobalDefaults.INTERNAL_WORLD + Indices.Mp320.MODERATOR_RIGHT_VOID).ToString() + " " +
                   MaterialManager.GetMaterial(GlobalDefaults.FillMaterial).ToCell() + " " + GetInteriorIndexBase() +
                   " " + GetFrontPlaneIndex() + " " + GetRightPlaneIndex() + " " + GetCellImportanceAndComments();
        }

        private string GetModeratorCell()
        {
            return GetIndex() + " " + hdpeMat.ToCell() + " " + GetInteriorIndexBase() + " " + GetEdges() + " " +
                   GetPenetrations() + GetCellImportanceAndComments();
        }

        private string GetEdges()
        {
            string left = GetUnion(new List<int>() {GetInside(GetLeftPlaneIndex()), GetInside(GetFrontPlaneIndex())});
            string right = GetUnion(new List<int>() {GetInside(GetRightPlaneIndex()), GetInside(GetFrontPlaneIndex())});

            return left + " " + right;
        }

        protected override List<string> MakeSurfaces()
        {
            List<string> surfaces = new List<string>();
            surfaces.Add(GetTopLevelComment());
            surfaces.AddRange(GetModeratorSurfaces());
            return surfaces;
        }

        protected override List<string> MakeExternalSurfaces()
        {
            List<string> externals = base.MakeExternalSurfaces();
            externals.Add(GetIndex().ToString());
            //externals.AddRange(base.MakeExternalSurfaces());
            return externals;

            //return new List<string>() {GetIndex().ToString()};
        }

        private string GetPenetrations()
        {
            return MCNPformatHelper.ConvertListToSpacedString(new List<int>() {neutronIndex, he3Index});
            // return neutronIndex.ToString() + " ";
        }

        private List<string> GetModeratorSurfaces()
        {
            Point3D rightNormal = GetRightNormalVector();

            List<string> surfaces = new List<string>();
            surfaces.Add(GetBulkIndex() + " " +
                         McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(GetBulkCenter(), moderatorBulk) +
                         " " +
                         GetComments(true, "Bulk"));
            surfaces.Add(GetFrontPlaneIndex() + " " +
                         McnpSurfaces.GetPlane(GetNotchPlane(), Extents.Mp320.ModeratorFaceNormal) +
                         " " +
                         GetComments(true, "Front Plane"));
            surfaces.Add(GetRightPlaneIndex() + " " + McnpSurfaces.GetPlane(GetPlanePoint(true), rightNormal) + " " +
                         GetComments(true, "Right Plane"));
            surfaces.Add(GetLeftPlaneIndex() + " " +
                         McnpSurfaces.GetPlane(GetPlanePoint(false), Point3D.MirrorX(rightNormal)) + " " +
                         GetComments(true, "Left Plane"));
            surfaces.AddRange(base.MakeSurfaces());
            return surfaces;
        }

        private Point3D GetNotchPlane()
        {
            Point3D notchPlane = faceCenter;
            notchPlane.Y -= additionalThickness + Extents.Mp320.MODERATOR_FRONT_LENGTH_Y;
            return notchPlane;
        }

        private Point3D GetBulkCenter()
        {
            Point3D bulkMidPoint = faceCenter;
            bulkMidPoint.Y -= moderatorBulk.Y / 2;
            return bulkMidPoint;
        }

        private Point3D GetRightNormalVector()
        {
            return Point3DHelper.GetUnitVector(Point3DHelper.CrossProduct(GetRightVector2() - GetRightVector1(),
                new Point3D(0, 0, -1)));
        }

        private Point3D GetRightVector1()
        {
            Point3D rightA1 = faceCenter;
            rightA1.X += Extents.Mp320.ModeratorBulk.X / 2 -
                         Extents.Mp320.MODERATOR_INSET_LENGTH_X;
            rightA1.Y -= additionalThickness + Extents.Mp320.MODERATOR_FRONT_LENGTH_Y;
            return rightA1;
        }

        private Point3D GetRightVector2()
        {
            Point3D rightA2 = faceCenter;
            rightA2.Y -= additionalThickness + Extents.Mp320.ModeratorBulk.Y;
            rightA2.X += Extents.Mp320.MODERATOR_BACK_LENGTH_X / 2;
            return rightA2;
        }

        private Point3D GetPlanePoint(bool rightPlane)
        {
            double extentSide = (rightPlane) ? -1.0 : 1.0;
            double bulkSide = (rightPlane) ? 1.0 : -1.0;

            Point3D planePoint = faceCenter;
            planePoint.X += bulkSide * (moderatorBulk.X / 2.0) +
                            extentSide * Extents.Mp320.MODERATOR_INSET_LENGTH_X;
            planePoint.Y -= additionalThickness + Extents.Mp320.MODERATOR_FRONT_LENGTH_Y;
            return planePoint;
        }

        private int GetRightPlaneIndex()
        {
            return Indices.Mp320.MODERATOR + Indices.Mp320.MODERATOR_RIGHT_PLANE;
        }

        private int GetLeftPlaneIndex()
        {
            return Indices.Mp320.MODERATOR + Indices.Mp320.MODERATOR_LEFT_PLANE;
        }

        private int GetFrontPlaneIndex()
        {
            return Indices.Mp320.MODERATOR + Indices.Mp320.MODERATOR_FRONT_PLANE;
        }

        private int GetBulkIndex()
        {
            return Indices.Mp320.MODERATOR + Indices.Mp320.MODERATOR_BULK;
        }

        private class Mp320ModeratorShield : Component
        {
            private Point3D shieldExtent;
            private Point3D shieldNormal;
            private Point3D planeCutPoint;

            private MaterialElement leadMat;
            private MaterialElement cadmiumMat;

            private int blockAndCdIndex;
            private int cutPlaneAndLeadIndex;
            private bool useCdShield;
            private bool usePdShield;
            private bool includeCutPlane;

            public Mp320ModeratorShield(Point3D FaceCenter, bool UseCdShield, double cdThickness, bool UsePdShield,
                double pbThickness) : base(
                Indices.Mp320.MODERATOR + Indices.Mp320.MODERATOR_SHIELD,
                "Moderator Front Shield")
            {
                usePdShield = UsePdShield;
                useCdShield = UseCdShield;
                includeCutPlane = usePdShield && useCdShield;

                leadMat = MaterialManager.GetMaterial(Materials.LEAD);
                cadmiumMat = MaterialManager.GetMaterial(Materials.CADMIUM);

                shieldExtent = Extents.Mp320.ModeratorShieldFace;
                shieldExtent.Y = cdThickness + pbThickness;

                shieldNormal = Extents.Mp320.ModeratorFaceNormal;
                center = FaceCenter;
                center.Y += shieldExtent.Y / 2;

                planeCutPoint = FaceCenter;
                planeCutPoint.Y += pbThickness;

                blockAndCdIndex = primaryIndex; // + Indices.NeutronGenerator.MODERATOR_SHIELD_CD;
                cutPlaneAndLeadIndex = primaryIndex + Indices.Mp320.MODERATOR_SHIELD_PB;
            }

            protected override List<string> MakeCells()
            {
                List<string> cells = new List<string>();

                if (usePdShield)
                {
                    cells.Add(GetLeadCell());
                }

                if (useCdShield)
                {
                    cells.Add(GetCadmiumCell());
                }

                return cells;
            }

            private string GetCadmiumCell()
            {
                return blockAndCdIndex + " " + cadmiumMat.ToCell() + " " + GetInside(blockAndCdIndex) +
                       " " + GetCutPlaneIndex() + GetCellImportanceAndComments("Cadmium");
            }


            private string GetCutPlaneIndex()
            {
                return includeCutPlane ? cutPlaneAndLeadIndex.ToString() : "";
            }

            private string GetLeadCell()
            {
                return cutPlaneAndLeadIndex + " " + leadMat.ToCell() + " " + GetInside(blockAndCdIndex) +
                       " " + GetInside(cutPlaneAndLeadIndex) + GetCellImportanceAndComments("Lead");
            }

            protected override List<string> MakeSurfaces()
            {
                List<string> surfaces = new List<string>();
                surfaces.Add(GetShieldBox());
                if (includeCutPlane)
                {
                    surfaces.Add(GetShieldCutPlane());
                }

                return surfaces;
            }

            private string GetShieldCutPlane()
            {
                string shieldPartitionMacro = McnpSurfaces.GetPlane(planeCutPoint, shieldNormal);
                return cutPlaneAndLeadIndex.ToString() + " " + shieldPartitionMacro + " " +
                       GetComments(additionalComment: "cut plane");
            }

            private string GetShieldBox()
            {
                string shieldMacro =
                    McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(center, shieldExtent);
                return blockAndCdIndex.ToString() + " " + shieldMacro + " " +
                       GetComments(additionalComment: "shield box");
            }

            protected override List<string> MakeExternalSurfaces()
            {
                return new List<string>() {GetIndex().ToString()};
            }
        }


        private class LeftPanelSideShield : PanelExtraSideShield
        {
            private const string PANEL_COMMENT = "Left Panel One";

            public LeftPanelSideShield(int mcnpIndex, double heightOffset, Point3D ShieldExtents,
                bool TopLevel = false) : base(mcnpIndex + Indices.Mp320.SIDE_PANEL_SHIELD_LEFT, heightOffset,
                ShieldExtents, PANEL_COMMENT, TopLevel)
            {
            }

            protected override Point3D ShiftFaceFromRightFace(Point3D rightPanelFace)
            {
                return Point3D.MirrorX(rightPanelFace);
            }

            protected override string GetPanelComment()
            {
                return PANEL_COMMENT;
            }
        }

        private class RightPanelSideShield : PanelExtraSideShield
        {
            private const string PANEL_COMMENT = "Right Panel Two";

            public RightPanelSideShield(int mcnpIndex, double heightOffset, Point3D ShieldExtents,
                bool TopLevel = false) : base(mcnpIndex + Indices.Mp320.SIDE_PANEL_SHIELD_RIGHT,
                heightOffset, ShieldExtents, PANEL_COMMENT, TopLevel)
            {
            }

            protected override Point3D ShiftFaceFromRightFace(Point3D rightPanelFace)
            {
                return rightPanelFace;
            }

            protected override string GetPanelComment()
            {
                return PANEL_COMMENT;
            }
        }

        private abstract class PanelExtraSideShield : Component
        {
            private readonly Point3D shieldCenter;
            private readonly Point3D shieldExtents;
            private readonly MaterialElement shieldMaterial;

            protected PanelExtraSideShield(int mcnpIndex, double heightOffset, Point3D ShieldExtents, string Comment,
                bool TopLevel = false) : base(mcnpIndex + Indices.Mp320.SIDE_PANEL_SHIELD,
                Comment + " Lead Side Shield", TopLevel)
            {
                shieldExtents = ShieldExtents;
                shieldMaterial = MaterialManager.GetMaterial(Materials.LEAD);
                shieldCenter = GetPanelFaceCenter();
                shieldCenter.Z += heightOffset;
                shieldCenter.Y += ShieldExtents.Y / 2.0;
            }

            protected Point3D GetPanelFaceCenter()
            {
                Point3D rightPanelFace = Extents.FNCL.PANEL_CENTER;
                rightPanelFace.Y -= (Extents.FNCL.PANEL_ENCLOSURE_EXTENT.Y / 2.0 + shieldExtents.Y +
                                     Extents.ENCLOSURE_THICK);
                return ShiftFaceFromRightFace(rightPanelFace);
            }

            protected abstract Point3D ShiftFaceFromRightFace(Point3D rightPanelFace);

            protected override List<string> MakeExternalSurfaces()
            {
                return new List<string>() {primaryIndex.ToString()};
            }

            protected override List<string> MakeCells()
            {
                return new List<string>()
                {
                    MCNPformatHelper.GetCell(primaryIndex, shieldMaterial, GetInteriorIndexBase(),
                        GetPanelComment())
                };
            }

            protected override List<string> MakeSurfaces()
            {
                return new List<string>()
                {
                    MCNPformatHelper.GetSurface(primaryIndex,
                        McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(shieldCenter,
                            shieldExtents), GetPanelComment())
                };
            }

            protected abstract string GetPanelComment();
        }
    }
}
