using System;
using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public static class AmLiBlockHelper
    {
        public static IComponentSpecification GetAmLiBlock(AmLiBlockTypes blockType, int mcnpIndex,
            double heightDisplacement,
            double magnitudeLeft, double magnitudeRight, bool activeInterrogation)
        {
            switch (blockType)
            {
                case AmLiBlockTypes.Undefined:
                    throw new Exception("Selected Undefined AmLi block type");
                case AmLiBlockTypes.PWR:
                    return new AmLiBlockPWR(mcnpIndex, magnitudeRight, magnitudeLeft, activeInterrogation,
                        heightDisplacement);
                case AmLiBlockTypes.BWR:
                    return new AmLiBlockBWR(mcnpIndex, magnitudeRight, magnitudeLeft, activeInterrogation,
                        heightDisplacement);
                case AmLiBlockTypes.VVER:
                    return new AmLiBlockVVER(mcnpIndex, magnitudeRight, magnitudeLeft, activeInterrogation,
                        heightDisplacement);
                default:
                    throw new ArgumentOutOfRangeException(nameof(blockType), blockType, null);
            }
        }

        private class AmLiBlockBWR : AmLiBlock
        {
            public AmLiBlockBWR(int mcnpIndex, double RelativeMagnitudeRight, double RelativeMagnitudeLeft,
                bool ActiveInterrogation, double HeightDisplacement) : base(mcnpIndex, RelativeMagnitudeRight,
                RelativeMagnitudeLeft, ActiveInterrogation, HeightDisplacement, "AmLI BWR")
            {
            }

            protected override void InitializeAmLi()
            {
                blockCenter = Extents.AmLiSource.BWR.BlockCenter;
                blockExtents = Extents.AmLiSource.BWR.BlockExtent;
                amLiCenter = Extents.AmLiSource.BWR.SourceCenter;
            }

            protected override List<IComponentSpecification> AddShieldingBlocks(List<int> amLiExteriorCells)
            {
                return new List<IComponentSpecification>()
                {
                    new BWRblock(GetIndex(Indices.AmLi.BLOCK_OFFSET), blockCenter, blockExtents,
                        amLiExteriorCells)
                };
            }

            private class BWRblock : Component
            {
                private Point3D blockExtents;
                private Point3D frontOuterFace;
                private List<int> amLiExteriorCells;

                public BWRblock(int primaryIndex, Point3D blockCenter, Point3D BlockExtents,
                    List<int> AmLiExteriorCells) :
                    base(primaryIndex, "VVER Block")
                {
                    center = blockCenter;
                    blockExtents = BlockExtents;
                    frontOuterFace = center;
                    frontOuterFace.Y += blockExtents.Y / 2;
                    amLiExteriorCells = AmLiExteriorCells;
                }

                protected override List<string> MakeExternalSurfaces()
                {
                    List<string> externalSurfaces = new List<string>();
                    externalSurfaces.Add(GetCompliment(GetIndex(Indices.AmLi.BWR.CASE)));
                    externalSurfaces.Add(GetCompliment(GetIndex(Indices.AmLi.BWR.CADMIUM)));
                    externalSurfaces.Add(GetCompliment(GetIndex(Indices.AmLi.BWR.POLY)));
                    externalSurfaces.AddRange(MCNPformatHelper.ConvertIntListToStringList(amLiExteriorCells));
                    return externalSurfaces;
                }

                protected override List<string> MakeSurfaces()
                {
                    List<string> surfaces = new List<string>();
                    surfaces.AddRange(GetFrontSurfaces());
                    surfaces.AddRange(GetMiddleSurfaces());
                    surfaces.AddRange(GetBackSurfaces());
                    surfaces.AddRange(GetSideSurfaces());
                    surfaces.AddRange(GetTopBottomSurfaces());
                    surfaces.AddRange(GetSlopedSurfaces());
                    return surfaces;
                }

                protected override List<string> MakeCells()
                {
                    List<string> cells = new List<string>();

                    cells.Add(GetPolyBlockCell());
                    cells.Add(GetCadimumCell());
                    cells.Add(GetCaseCell());

                    return cells;
                }

                private string GetCaseCell()
                {
                    return MCNPformatHelper.GetCell(GetIndex(Indices.AmLi.BWR.CASE), caseMat,
                        GetCaseCellSurfaces(), "AmLi Case");
                }

                private List<string> GetCaseCellSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.TOP_OUTER_PLANE).ToString());
                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.BOTTON_OUTER_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.LEFT_SIDE_OUTER_PLANE).ToString());
                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.RIGHT_SIDE_OUTER_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.BACK_OUTER_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.FRONT_OUTER_PLANE).ToString());

                    surfaces.Add(GetUnion(new List<int>()
                    {
                        GetInteriorIndexBase(Indices.AmLi.BWR.MIDDLE_OUTER_PLANE),
                        GetInteriorIndexBase(Indices.AmLi.BWR.RIGHT_SLOPE_OUTER_PLANE)
                    }));

                    surfaces.Add(GetUnion(new List<int>()
                    {
                        GetInteriorIndexBase(Indices.AmLi.BWR.MIDDLE_OUTER_PLANE),
                        GetInteriorIndexBase(Indices.AmLi.BWR.LEFT_SLOPE_OUTER_PLANE)
                    }));

                    surfaces.Add(GetCompliment(GetIndex(Indices.AmLi.BWR.CADMIUM)));
                    surfaces.Add(GetCompliment(GetIndex(Indices.AmLi.BWR.POLY)));
                    surfaces.AddRange(MCNPformatHelper.ConvertIntListToStringList(amLiExteriorCells));
                    return surfaces;
                }


                private string GetCadimumCell()
                {
                    return MCNPformatHelper.GetCell(GetIndex(Indices.AmLi.BWR.CADMIUM), cadmiumMat,
                        GetCadimumCellSurfaces(),
                        "AmLi Cadmium Liner");
                }

                private List<string> GetCadimumCellSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.TOP_MIDDLE_PLANE).ToString());
                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.BOTTOM_MIDDLE_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.LEFT_SIDE_MIDDLE_PLANE).ToString());
                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.RIGHT_SIDE_MIDDLE_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.BACK_MIDDLE_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.FRONT_MIDDLE_PLANE).ToString());

                    surfaces.Add(GetUnion(new List<int>()
                    {
                        GetInteriorIndexBase(Indices.AmLi.BWR.MIDDLE_MIDDLE_PLANE),
                        GetInteriorIndexBase(Indices.AmLi.BWR.RIGHT_SLOPE_MIDDLE_PLANE)
                    }));

                    surfaces.Add(GetUnion(new List<int>()
                    {
                        GetInteriorIndexBase(Indices.AmLi.BWR.MIDDLE_MIDDLE_PLANE),
                        GetInteriorIndexBase(Indices.AmLi.BWR.LEFT_SLOPE_MIDDLE_PLANE)
                    }));

                    surfaces.Add(GetCompliment(GetIndex(Indices.AmLi.BWR.POLY)));
                    surfaces.AddRange(MCNPformatHelper.ConvertIntListToStringList(amLiExteriorCells));
                    return surfaces;
                }

                private string GetPolyBlockCell()
                {
                    return MCNPformatHelper.GetCell(GetIndex(Indices.AmLi.BWR.POLY), blockMat,
                        GetPolyBlockCellSurfaces(), "AmLi Poly Block");
                }

                private List<string> GetPolyBlockCellSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.TOP_INNER_PLANE).ToString());
                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.BOTTOM_INNER_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.LEFT_SIDE_INNER_PLANE).ToString());
                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.RIGHT_SIDE_INNER_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.BACK_INNER_PLANE).ToString());

                    surfaces.Add(GetInteriorIndexBase(Indices.AmLi.BWR.FRONT_INNER_PLANE).ToString());

                    surfaces.Add(GetUnion(new List<int>()
                    {
                        GetInteriorIndexBase(Indices.AmLi.BWR.MIDDLE_INNER_PLANE),
                        GetInteriorIndexBase(Indices.AmLi.BWR.RIGHT_SLOPE_INNER_PLANE)
                    }));

                    surfaces.Add(GetUnion(new List<int>()
                    {
                        GetInteriorIndexBase(Indices.AmLi.BWR.MIDDLE_INNER_PLANE),
                        GetInteriorIndexBase(Indices.AmLi.BWR.LEFT_SLOPE_INNER_PLANE)
                    }));

                    // this may cause an issue with the # operation
                    surfaces.AddRange(MCNPformatHelper.ConvertIntListToStringList(amLiExteriorCells));

                    return surfaces;
                }


                private List<string> GetSlopedSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    Point3D topRightOuterCorner = frontOuterFace;
                    topRightOuterCorner.X += Extents.AmLiSource.BWR.CavityLength / 2;

                    Point3D bottomRightOuterCorner = frontOuterFace;
                    bottomRightOuterCorner.Y -= Extents.AmLiSource.BWR.ExtensionLength;
                    bottomRightOuterCorner.X += Extents.AmLiSource.BWR.BlockLength / 2;

                    Point3D slopeVector = Point3DHelper.GetUnitVector(topRightOuterCorner - bottomRightOuterCorner);

                    Point3D rightNormal = Point3DHelper.GetUnitVector(
                        Point3DHelper.CrossProduct(slopeVector, Extents.AmLiSource.Axis));
                    // Right Side
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.RIGHT_SLOPE_OUTER_PLANE),
                        McnpSurfaces.GetPlane(topRightOuterCorner, rightNormal), "Outer Right Sloped"));

                    Point3D topRightMiddleCorner = topRightOuterCorner - Extents.ENCLOSURE_THICK * rightNormal;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.RIGHT_SLOPE_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(topRightMiddleCorner, rightNormal), "Middle Right Sloped"));

                    Point3D topRightInnerCorner = topRightMiddleCorner - Extents.CADMIUM_THICKNESS * rightNormal;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.RIGHT_SLOPE_INNER_PLANE),
                        McnpSurfaces.GetPlane(topRightInnerCorner, rightNormal), "Inner Right Sloped"));

                    // Left Side
                    Point3D leftNormal = Point3D.MirrorX(rightNormal);

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.LEFT_SLOPE_OUTER_PLANE),
                        McnpSurfaces.GetPlane(Point3D.MirrorX(topRightOuterCorner), leftNormal), "Outer Left Sloped"));

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.LEFT_SLOPE_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(Point3D.MirrorX(topRightMiddleCorner), leftNormal),
                        "Middle Left Sloped"));

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.LEFT_SLOPE_INNER_PLANE),
                        McnpSurfaces.GetPlane(Point3D.MirrorX(topRightInnerCorner), leftNormal), "Inner Left Sloped"));

                    return surfaces;
                }

                private List<string> GetTopBottomSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    Point3D outerTop = center;
                    outerTop.Z += blockExtents.Z / 2;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.TOP_OUTER_PLANE),
                        McnpSurfaces.GetPlane(outerTop, Extents.AmLiSource.Axis), "Top Outer Cut Plane"));

                    Point3D middleTop = outerTop;
                    middleTop.Z -= Extents.ENCLOSURE_THICK;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.TOP_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(outerTop, Extents.AmLiSource.Axis), "Top Middle Cut Plane"));

                    Point3D innerTop = middleTop;
                    innerTop.Z -= Extents.CADMIUM_THICKNESS;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.TOP_INNER_PLANE),
                        McnpSurfaces.GetPlane(innerTop, Extents.AmLiSource.Axis), "Top Inner Cut Plane"));

                    Point3D outerBottom = center;
                    outerBottom.Z -= blockExtents.Z / 2;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.BOTTON_OUTER_PLANE),
                        McnpSurfaces.GetPlane(outerBottom, Point3D.Mirror(Extents.AmLiSource.Axis)),
                        "Bottom Outer Cut Plane"));

                    Point3D middleBottom = outerBottom;
                    middleBottom.Z += Extents.ENCLOSURE_THICK;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.BOTTOM_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(middleBottom, Point3D.Mirror(Extents.AmLiSource.Axis)),
                        "Bottom Middle Cut Plane"));

                    Point3D innerBottom = middleBottom;
                    innerBottom.Z += Extents.CADMIUM_THICKNESS;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.BOTTOM_INNER_PLANE),
                        McnpSurfaces.GetPlane(innerBottom, Point3D.Mirror(Extents.AmLiSource.Axis)),
                        "Bottom Inner Cut Plane"));

                    return surfaces;
                }

                private List<string> GetMiddleSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    Point3D outerFace = frontOuterFace;
                    outerFace.Y -= Extents.AmLiSource.BWR.ExtensionLength;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.MIDDLE_OUTER_PLANE),
                        McnpSurfaces.GetPlane(outerFace, Extents.AmLiSource.IntoCavity), "Middle Outer"));

                    Point3D middleFace = outerFace;
                    middleFace.Y -= Extents.ENCLOSURE_THICK;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.MIDDLE_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(middleFace, Extents.AmLiSource.IntoCavity), "Middle Middle"));

                    Point3D insideFace = middleFace;
                    insideFace.Y -= Extents.CADMIUM_THICKNESS;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.MIDDLE_INNER_PLANE),
                        McnpSurfaces.GetPlane(insideFace, Extents.AmLiSource.IntoCavity), "Middle Inner"));

                    return surfaces;
                }

                private List<string> GetSideSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    Point3D outerFace = center;
                    outerFace.X += blockExtents.X / 2;
                    Point3D rightNormal = Extents.AmLiSource.SideCavity;
                    Point3D leftNormal = Point3D.Mirror(rightNormal);

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.RIGHT_SIDE_OUTER_PLANE),
                        McnpSurfaces.GetPlane(outerFace, rightNormal), "Right Side Outer"));

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.LEFT_SIDE_OUTER_PLANE),
                        McnpSurfaces.GetPlane(Point3D.Mirror(outerFace), leftNormal),
                        "Left Side Outer"));

                    Point3D middleFace = outerFace;
                    middleFace.X -= Extents.ENCLOSURE_THICK;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.RIGHT_SIDE_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(middleFace, rightNormal), "Right Side Middle"));

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.LEFT_SIDE_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(Point3D.Mirror(middleFace), leftNormal), "Left Side Middle"));


                    Point3D insideFace = middleFace;
                    insideFace.X -= Extents.CADMIUM_THICKNESS;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.RIGHT_SIDE_INNER_PLANE),
                        McnpSurfaces.GetPlane(insideFace, rightNormal), "Right Side Inner"));

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.LEFT_SIDE_INNER_PLANE),
                        McnpSurfaces.GetPlane(Point3D.Mirror(insideFace), leftNormal), "Left Side Inner"));

                    return surfaces;
                }

                private List<string> GetBackSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    Point3D backFace = center;
                    backFace.Y -= blockExtents.Y / 2;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.BACK_OUTER_PLANE),
                        McnpSurfaces.GetPlane(backFace, Point3D.Mirror(Extents.AmLiSource.IntoCavity)), "Back Outer"));


                    Point3D middleFace = backFace;
                    middleFace.Y += Extents.ENCLOSURE_THICK;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.BACK_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(middleFace, Point3D.Mirror(Extents.AmLiSource.IntoCavity)),
                        "Back Middle"));

                    Point3D frontFace = middleFace;
                    frontFace.Y += Extents.CADMIUM_THICKNESS;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.BACK_INNER_PLANE),
                        McnpSurfaces.GetPlane(frontFace, Point3D.Mirror(Extents.AmLiSource.IntoCavity)), "Back Inner"));

                    return surfaces;
                }

                private List<string> GetFrontSurfaces()
                {
                    List<string> surfaces = new List<string>();

                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.FRONT_OUTER_PLANE),
                        McnpSurfaces.GetPlane(frontOuterFace, Extents.AmLiSource.IntoCavity), "Front Outer"));

                    Point3D innerAlFace = frontOuterFace;
                    innerAlFace.Y -= Extents.ENCLOSURE_THICK;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.FRONT_MIDDLE_PLANE),
                        McnpSurfaces.GetPlane(innerAlFace, Extents.AmLiSource.IntoCavity), "Front Middle"));

                    Point3D cdFace = innerAlFace;
                    cdFace.Y -= Extents.CADMIUM_THICKNESS;
                    surfaces.Add(MCNPformatHelper.GetSurface(GetIndex(Indices.AmLi.BWR.FRONT_INNER_PLANE),
                        McnpSurfaces.GetPlane(cdFace, Extents.AmLiSource.IntoCavity), "Front Inner"));

                    return surfaces;
                }
            }
        }


        private class AmLiBlockVVER : AmLiBlock
        {
            public AmLiBlockVVER(int mcnpIndex, double RelativeMagnitudeRight, double RelativeMagnitudeLeft,
                bool ActiveInterrogation, double HeightDisplacement) : base(mcnpIndex, RelativeMagnitudeRight,
                RelativeMagnitudeLeft, ActiveInterrogation, HeightDisplacement, "AmLi VVER")
            {
            }

            protected override List<IComponentSpecification> AddShieldingBlocks(List<int> amLiExteriorCells)
            {
                return new List<IComponentSpecification>() {new VVERblock(primaryIndex, blockCenter)};
            }

            protected override void InitializeAmLi()
            {
                blockCenter = Extents.AmLiSource.VVER.BlockCenter;
                blockExtents = Extents.AmLiSource.VVER.BlockExtent;
                amLiCenter = Extents.AmLiSource.VVER.SourceCenter;
            }

            private class VVERblock : Component
            {
                public VVERblock(int primaryIndex, Point3D blockCenter) : base(primaryIndex, "VVER Block")
                {
                    center = blockCenter;
                }
            }
        }

        private class AmLiBlockPWR : AmLiBlock
        {
            public AmLiBlockPWR(int mcnpIndex, double RelativeMagnitudeRight, double RelativeMagnitudeLeft,
                bool ActiveInterrogation, double HeightDisplacement) : base(mcnpIndex, RelativeMagnitudeRight,
                RelativeMagnitudeLeft, ActiveInterrogation, HeightDisplacement, "AmLi PWR")
            {
            }

            protected override void InitializeAmLi()
            {
                blockCenter = Extents.AmLiSource.PWR.BlockCenter;
                blockExtents = Extents.AmLiSource.PWR.BlockExtent;
                amLiCenter = Extents.AmLiSource.PWR.SourceCenter;
            }

            protected override List<IComponentSpecification> AddShieldingBlocks(List<int> amLiExteriorCells)
            {
                return new List<IComponentSpecification> {AddCadmiumFilm(), AddEncapsulatingBlock(amLiExteriorCells)};
            }

            private IComponentSpecification AddCadmiumFilm()
            {
                return new CadmiumFilmPWR(primaryIndex, heightDisplacement);
            }

            private IComponentSpecification AddEncapsulatingBlock(List<int> interiorCells)
            {
                Encased<string> componentComment = new Encased<string>("HDPE", "Moderator Enclosure");
                return new EncasedBlock(primaryIndex, true, blockCenter, blockExtents, caseThickness,
                    blockMat, caseMat, componentComment, InteriorCells: interiorCells);
            }

            private class CadmiumFilmPWR : Component
            {
                private double heightOffset;

                public CadmiumFilmPWR(int mcnpIndex, double HeightOffset) : base(mcnpIndex + Indices.AmLi.BLOCK_OFFSET,
                    "Cadmium Film", true)
                {
                    heightOffset = HeightOffset;
                }

                protected override List<string> MakeCells()
                {
                    return new List<string>()
                    {
                        MCNPformatHelper.GetCell(primaryIndex, cadmiumMat, GetInteriorIndexBase())
                    };
                }

                protected override List<string> MakeSurfaces()
                {
                    Point3D cdCenter = Extents.AmLiSource.PWR.CadmiumCenter;
                    cdCenter.Z += heightOffset;
                    return new List<string>()
                    {
                        MCNPformatHelper.GetSurface(primaryIndex,
                            McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(
                                cdCenter, Extents.AmLiSource.PWR.CadmiumExtents))
                    };
                }

                protected override List<string> MakeExternalSurfaces()
                {
                    return new List<string>() {primaryIndex.ToString()};
                }
            }
        }

        private abstract class AmLiBlock : Component
        {
            protected Point3D blockCenter;
            protected Point3D blockExtents;
            protected Point3D amLiCenter;
            protected double caseThickness;
            protected static MaterialElement blockMat;
            protected static MaterialElement caseMat;
            protected static MaterialElement cadmiumMat;
            private double magnitudeRight;
            private double magnitudeLeft;
            private bool activeInterrogation;
            protected double heightDisplacement;

            protected AmLiBlock(int mcnpIndex, double RelativeMagnitudeRight,
                double RelativeMagnitudeLeft, bool ActiveInterrogation, double HeightDisplacement,
                string comment) : base(
                mcnpIndex, comment, true)
            {
                activeInterrogation = ActiveInterrogation;
                magnitudeRight = RelativeMagnitudeRight / (RelativeMagnitudeRight + RelativeMagnitudeLeft);
                magnitudeLeft = 1 - magnitudeRight;
                caseThickness = Extents.ENCLOSURE_THICK;
                InitializeAmLi();
                amLiCenter += blockCenter;
                heightDisplacement = HeightDisplacement;
                AdjustByHeight();
                SetMaterials();
            }

            private void SetMaterials()
            {
                cadmiumMat = MaterialManager.GetMaterial(Materials.CADMIUM);
                blockMat = MaterialManager.GetMaterial(Materials.HDPE);
                caseMat = MaterialManager.GetMaterial(Materials.ALUMINUM);
            }

            private void AdjustByHeight()
            {
                blockCenter.Z += heightDisplacement;
                amLiCenter.Z += heightDisplacement;
            }

            protected abstract void InitializeAmLi();

            protected override void InitializeSubComponents()
            {
                // we may want to consider non rectangular enclosures, like the ones for different fuel assemblies
                var amLiSource = new AmLiSources(primaryIndex, amLiCenter, magnitudeRight, magnitudeLeft,
                    activeInterrogation);
                subComponents.AddRange(AddShieldingBlocks(amLiSource.GetExteriorCells()));
                subComponents.Add(amLiSource);
            }

            protected abstract List<IComponentSpecification> AddShieldingBlocks(List<int> amLiExteriorCells);

            private class AmLiSources : Component
            {
                private readonly Point3D centerRight;
                private readonly Point3D centerLeft;
                private readonly Encased<MaterialElement> material;
                private Encased<CylinderExtent> extents;
                private const bool TOPLEVEL = false;
                private Encased<string> rightCells;
                private Encased<string> leftCells;
                private readonly double magnitudeLeft;
                private readonly double magnitudeRight;

                public AmLiSources(int mcnpIndex, Point3D amLiCenter, double MagnitudeLeft, double MagnitudeRight,
                    bool ActiveInterrogation) : base(mcnpIndex, "AmLi Source", TOPLEVEL)
                {
                    hasSourceTerm = ActiveInterrogation;
                    centerRight = amLiCenter;
                    centerLeft = Point3D.MirrorX(centerRight);
                    material.Inner = MaterialManager.GetMaterial(Materials.AMLI_SOURCE);
                    material.Outer = MaterialManager.GetMaterial(Materials.TUNGSTEN_ALLOY);
                    magnitudeLeft = MagnitudeLeft;
                    magnitudeRight = MagnitudeRight;
                    extents.Inner = new CylinderExtent(Extents.AmLiSource.InnerBottle.Height,
                        Extents.AmLiSource.InnerBottle.Radius, Extents.AmLiSource.Axis);
                    extents.Outer = new CylinderExtent(Extents.AmLiSource.OuterBottle.Height,
                        Extents.AmLiSource.OuterBottle.Radius, Extents.AmLiSource.Axis);
                }

                protected override List<string> MakeExternalSurfaces()
                {
                    return new List<string>();
                }

                public List<int> GetExteriorCells()
                {
                    return new List<int>()
                    {
                        GetIndex(Indices.AmLi.AMLI_RIGHT_OFFSET), GetIndex(Indices.AmLi.AMLI_LEFT_OFFSET)
                    };
                }

                protected override void InitializeSubComponents()
                {
                    Encased<string> componentComment = new Encased<string>("AmLi Source", "Tungsten Shell");
                    var rightAmLi = new EncasedCylinder(primaryIndex + Indices.AmLi.AMLI_RIGHT_OFFSET,
                        GetSharedEncased(centerRight), extents, material,
                        topLevel, componentComment, comment: "AmLi Right");
                    rightCells = rightAmLi.GetCellsLabels();

                    var leftAmLi = new EncasedCylinder(primaryIndex + Indices.AmLi.AMLI_LEFT_OFFSET,
                        GetSharedEncased(centerLeft), extents,
                        material, topLevel, componentComment, comment: "AmLi Left");
                    leftCells = leftAmLi.GetCellsLabels();

                    subComponents.Add(rightAmLi);
                    subComponents.Add(leftAmLi);
                }

                public override SourceSpecification GetSource() // MakeSources()
                {
                    SourceSpecification sourceSpecification = new SourceSpecification();

                    List<string> source = new List<string>();
                    source.Add(MCNPformatHelper.GetCommentLine("Based on page 15 of Shultis and Faw MCNP Primer"));
                    source.Add("sdef cel=d1 pos=fcel d2 axs=" + extents.Inner.Axis.ToString() +
                               " rad=fcel d5 ext=fcel d8");
                    source.Add("si1 L " + rightCells.Inner + " " + leftCells.Inner);
                    source.Add("sp1 " + magnitudeRight + " " + magnitudeLeft);

                    source.Add(MCNPformatHelper.GetCommentLine("set POS for each source"));
                    source.Add("ds2 s 3 4");
                    source.Add("si3 L " + centerRight.ToString());
                    source.Add("sp3 1");
                    source.Add("si4 L " + centerLeft.ToString());
                    source.Add("sp4 1");

                    source.Add(MCNPformatHelper.GetCommentLine("set RAD for each source"));
                    source.Add("ds5 s 6 7");
                    source.Add("si6 0 " + extents.Inner.Radius);
                    source.Add("sp6 -21 1");
                    source.Add("si7 0 " + extents.Inner.Radius);
                    source.Add("sp7 -21 1");

                    source.Add(MCNPformatHelper.GetCommentLine("set EXT for each source"));
                    double axisLow = -extents.Inner.Height / 2 +
                                     Point3DHelper.DotProduct(centerLeft, extents.Inner.Axis);
                    double axisHigh = extents.Inner.Height / 2 +
                                      Point3DHelper.DotProduct(centerLeft, extents.Inner.Axis);
                    source.Add("ds8 s 9 10");
                    source.Add("si9 " + axisLow + " " + axisHigh);
                    source.Add("sp9 -21 0");
                    source.Add("si10 " + axisLow + " " + axisHigh);
                    source.Add("sp10 -21 0");

                    sourceSpecification.SourceDefinition = source;
                    sourceSpecification.SourcePoliMi = poliMiSource;

                    return sourceSpecification;
                }

                private Encased<Point3D> GetSharedEncased(Point3D point)
                {
                    return new Encased<Point3D>(point, point);
                }
            }
        }
    }
}
