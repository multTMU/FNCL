using System.Collections.Generic;
using GlobalHelpers;
using GeometrySampling;

namespace FastNeutronCollar
{
    public partial class FNCLcomponent
    {
        private class Panel : Component
        {
            private const string COMMENT = "Panel";
            private readonly PanelTransform transform;
            private readonly int panelIndex;

            public Panel(int mcnpIndex, PanelTransform transformPanel) : base(mcnpIndex,
                COMMENT + " " + transformPanel.GetExtraComment(), true)
            {
                panelIndex = mcnpIndex;
                center = transformPanel.GetPanelCenter();
                transform = transformPanel;
            }

            protected override void InitializeSubComponents()
            {
                List<int> detectorExternalSurfaces = new List<int>();
                List<int> externalCells = new List<int>();

                int detIndex = GetDetectorIndexForPanel(Indices.FNCL.DETECTOR1);
                detectorExternalSurfaces.Add(detIndex);
                externalCells.Add(detIndex);
                externalCells.Add((detIndex + Indices.FNCL.PMTOFFSET));
                subComponents.Add(new DetectorWithPMT(detIndex,
                    new DetectorOne(transform, Extents.FNCL.DETECTOR_CENTER,
                        Extents.FNCL.DETECTOR_EXTENT)));

                detIndex = GetDetectorIndexForPanel(Indices.FNCL.DETECTOR2);
                detectorExternalSurfaces.Add(detIndex);
                externalCells.Add(detIndex);
                externalCells.Add((detIndex + Indices.FNCL.PMTOFFSET));
                subComponents.Add(new DetectorWithPMT(detIndex,
                    new DetectorTwo(transform, Extents.FNCL.DETECTOR_CENTER,
                        Extents.FNCL.DETECTOR_EXTENT)));

                detIndex = GetDetectorIndexForPanel(Indices.FNCL.DETECTOR3);
                detectorExternalSurfaces.Add(detIndex);
                externalCells.Add(detIndex);
                externalCells.Add((detIndex + Indices.FNCL.PMTOFFSET));
                subComponents.Add(new DetectorWithPMT(detIndex,
                    new DetectorThree(transform, Extents.FNCL.DETECTOR_CENTER,
                        Extents.FNCL.DETECTOR_EXTENT)));

                detIndex = GetDetectorIndexForPanel(Indices.FNCL.DETECTOR4);
                detectorExternalSurfaces.Add(detIndex);
                externalCells.Add(detIndex);
                externalCells.Add((detIndex + Indices.FNCL.PMTOFFSET));
                subComponents.Add(new DetectorWithPMT(detIndex,
                    new DetectorFour(transform, Extents.FNCL.DETECTOR_CENTER,
                        Extents.FNCL.DETECTOR_EXTENT)));

                // add panel housing which contains the lead and cadmium shielding
                PanelShield panelShield = new PanelShield(panelIndex, transform);
                externalCells.AddRange(panelShield.GetOuterCells());
                subComponents.Add(panelShield);

                // add PE between detectors
                DetectorSideShields detectorSideShields =
                    new DetectorSideShields(panelIndex, transform, detectorExternalSurfaces);
                externalCells.AddRange(detectorSideShields.GetOuterCells());
                subComponents.Add(detectorSideShields);

                // add outer most cells inside panel enclosure
                subComponents.Add(new PanelEnclosure(primaryIndex, center,
                    transform.TransformExtents(Extents.FNCL.PANEL_ENCLOSURE_EXTENT), Extents.ENCLOSURE_THICK,
                    externalCells));
            }

            private int GetDetectorIndexForPanel(int detectorIndex)
            {
                return panelIndex + detectorIndex;
            }

            private class DetectorSideShields : Component
            {
                private const int SHIELD_INDEX_OFFSET = 3;
                private MyPoint3D shieldExtent;
                private MaterialElement shieldMat;
                private readonly List<int> detSurfaces;

                public DetectorSideShields(int mcnpIndex, PanelTransform transform, List<int> detectorSurfaces) : base(
                    mcnpIndex + Indices.FNCL.SIDE_SHIELD, "Detector HDPE Side Shield")
                {
                    center = transform.TransformPoint(Extents.FNCL.GetDetectorSideShieldCenter());
                    shieldExtent = transform.TransformExtents(Extents.FNCL.GetDetectorSideShieldExtents());
                    shieldMat = MaterialManager.GetMaterial(Materials.HDPE);
                    detSurfaces = detectorSurfaces;
                }

                protected override List<string> MakeSurfaces()
                {
                    List<string> surfaces = new List<string>();
                    string macroBody = McnpSurfaces.GetRectangularParallelepipedFromCenterExtents(center, shieldExtent);
                    surfaces.Add(primaryIndex.ToString() + " " + macroBody + " " + GetComments());
                    return surfaces;
                }

                protected override List<string> MakeCells()
                {
                    List<string> cells = new List<string>();
                    string cellSpec = primaryIndex.ToString() + " " + shieldMat.ToCell() + " " +
                                      GetInside(primaryIndex) +
                                      " " + GetDetectorSurfaces() + GetCellImportanceAndComments();
                    cells.Add(cellSpec);
                    return cells;
                }

                private string GetDetectorSurfaces()
                {
                    string detSurfs = "";
                    foreach (var d in detSurfaces)
                    {
                        detSurfs += d.ToString() + " ";
                    }

                    return detSurfs.Trim();
                }

                protected override List<string> MakeExternalSurfaces()
                {
                    return new List<string>() {primaryIndex.ToString()};
                }

                public List<int> GetOuterCells()
                {
                    List<int> outerCells = new List<int>();
                    outerCells.Add(primaryIndex);
                    return outerCells;
                }
            }

            private class PanelShield : Component
            {
                private const string COMMENT = "Panel Shield";
                private const bool TOP_LEVEL = true;
                private MyPoint3D shieldExtent;
                private MyPoint3D shieldNormal;
                private MyPoint3D planeCutPoint;

                private const int BLOCK_INDEX_OFFSET = 2;
                private const int PLANE_INDEX_OFFSET = 1;

                private MaterialElement leadMat;
                private MaterialElement cadmiumMat;

                private int blockAndCdIndex;
                private int cutPlaneAndLeadIndex;

                public PanelShield(int PanelIndex, PanelTransform transform) : base(PanelIndex,
                    COMMENT + " " + transform.GetExtraComment(), TOP_LEVEL)
                {
                    shieldExtent = transform.TransformExtents(Extents.FNCL.PANEL_SHIELD_EXTENT);
                    shieldNormal = transform.TransformPoint(Extents.FNCL.PANEL_SHIELD_NORMAL);
                    center = transform.TransformPoint(Extents.FNCL.PANEL_SHIELD_CENTER);

                    planeCutPoint = Extents.FNCL.PANEL_SHIELD_CENTER;
                    planeCutPoint.X += (Extents.CADMIUM_THICKNESS - Extents.LEAD_THICKNESS) / 2;
                    planeCutPoint = transform.TransformPoint(planeCutPoint);

                    blockAndCdIndex = primaryIndex + Indices.FNCL.SHIELD + BLOCK_INDEX_OFFSET;
                    cutPlaneAndLeadIndex = primaryIndex + Indices.FNCL.SHIELD + PLANE_INDEX_OFFSET;

                    leadMat = MaterialManager.GetMaterial(Materials.LEAD);
                    cadmiumMat = MaterialManager.GetMaterial(Materials.CADMIUM);
                }

                public List<int> GetOuterCells()
                {
                    List<int> outerCells = new List<int>();
                    outerCells.Add(blockAndCdIndex);
                    // outerCells.Add(cutPlaneAndLeadIndex.ToString());
                    return outerCells;
                }

                protected override List<string> MakeCells()
                {
                    List<string> cells = new List<string>();
                    cells.Add(GetLeadCell());
                    cells.Add(GetCadmiumCell());
                    return cells;
                }

                private string GetCadmiumCell()
                {
                    return blockAndCdIndex.ToString() + " " + cadmiumMat.ToCell() + " " + GetInside(blockAndCdIndex) +
                           " " + cutPlaneAndLeadIndex + GetCellImportanceAndComments("Cadmium");
                }

                private string GetLeadCell()
                {
                    return cutPlaneAndLeadIndex.ToString() + " " + leadMat.ToCell() + " " + GetInside(blockAndCdIndex) +
                           " " + GetInside(cutPlaneAndLeadIndex) + GetCellImportanceAndComments("Lead");
                }

                protected override List<string> MakeSurfaces()
                {
                    List<string> surfaces = new List<string>();
                    surfaces.Add(GetShieldBox());
                    surfaces.Add(GetShieldCutPlane());
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
                    return new List<string>() {blockAndCdIndex.ToString()};
                }
            }

            private class DetectorWithPMT : Component
            {
                private const string COMMENT = "Detector";
                private readonly DetectorTransform transform;

                public DetectorWithPMT(int index, DetectorTransform detectorTransform) : base(index,
                    COMMENT + " " + detectorTransform.GetComment())
                {
                    transform = detectorTransform;
                    PoliMiMPPostInputHelper.AddDetectorCell(primaryIndex + Indices.EnclosedIndexOffsets.Inner);
                }

                protected override void InitializeSubComponents()
                {
                    Encased<string> componentCommentDet = new Encased<string>("Liquid Scint", "Enclosure");

                    subComponents.Add(new EncasedBlock(primaryIndex, false, transform.GetDetectorCenter(),
                        transform.GetDetectorExtents(), Extents.ENCLOSURE_THICK, liqScintMat,
                        enclosureMat, componentCommentDet, comment: COMMENT + " " + transform.GetComment()));

                    Encased<string> componentCommentPMT = new Encased<string>("Inside PMT", "PMT Shell");
                    subComponents.Add(new EncasedCylinder(primaryIndex + Indices.FNCL.PMTOFFSET,
                        transform.GetPmtCenter(Extents.FNCL.GetPmtCenter()),
                        transform.GetPmtExtents(Extents.FNCL.PMT_EXTENTS), pmtMat, false, componentCommentPMT,
                        comment: COMMENT + " " + transform.GetComment()));
                }
            }
        }

        private class PanelEnclosure : Component
        {
            private readonly MyPoint3D externalExtents;
            private readonly double enclosureThickness;
            private readonly List<int> interiorCells;

            public PanelEnclosure(int PrimaryIndex, MyPoint3D centerPanel, MyPoint3D extents, double EnclosureThick,
                List<int> InteriorCells) : base(PrimaryIndex, "Enclosure")
            {
                center = centerPanel;
                externalExtents = extents;
                enclosureThickness = EnclosureThick;
                interiorCells = InteriorCells;
            }

            protected override void InitializeSubComponents()
            {
                Encased<string> componentComment = new Encased<string>("Inside Panel Enclosure", "Enclosure");
                subComponents.Add(new EncasedBlock(primaryIndex, true, center, externalExtents, enclosureThickness,
                    Materials.AIR, Materials.ALUMINUM, componentComment, comment: "Panel",
                    InteriorCells: interiorCells));
            }
        }
    }
}
