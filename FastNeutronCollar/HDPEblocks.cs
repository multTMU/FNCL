using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public partial class FNCLcomponent
    {
        //private class BlockOfHDPE: Component
        //{
        //    private const string COMMENT = "HDPE Block";
        //    private readonly MyPoint3D centerOfHDPE;
        //    private readonly MyPoint3D extents;

        //    public BlockOfHDPE(int mcnpLabel, MyPoint3D CenterOfHDPE, string ExtraComment) : base(mcnpLabel, COMMENT + " " + ExtraComment)
        //    {
        //        centerOfHDPE = CenterOfHDPE;
        //        extents = Extents.FNCL.HDPE_BLOCK_EXTENT;
        //    }

        //    protected override List<string> MakeSurfaces()
        //    {
        //        string macroBody = MCNPsurfaces.GetRectangularParallelepiped(
        //            MCNPsurfacesHelpers.GetRectangleMinPoint(centerOfHDPE, extents),
        //            MCNPsurfacesHelpers.GetRectangleMaxPoint(centerOfHDPE, extents));

        //        List<string> surface = new List<string>(); 
        //        surface.Add(GetTopLevelComment());
        //        surface.Add(GetIndex() + " " + macroBody + " " +  GetComments());
        //        return surface.ToList();
        //    }

        //    protected override List<string> MakeExternalSurfaces()
        //    {
        //        List<string> external = new List<string>();
        //        external.Add(GetIndex().ToString());
        //        return external;
        //    }

        //    protected override List<string> MakeCells()
        //    {
        //        List<string> cells = new List<string>();
        //        cells.Add(GetTopLevelComment());
        //        cells.Add(GetIndex() + " " + hdpeMat.ToCell() + " " + GetInteriorIndex() + UniverseAndImportanceHelper.UniverseAndImportance() + " " + GetComments());
        //        return cells;
        //    }

        //}

        private class EncasedBlockOfHDPE : Component
        {
            private const bool TopLevel = true;
            private readonly double caseThickness;

            public EncasedBlockOfHDPE(int mcnpIndex, MyPoint3D CenterOfHDPE, double CaseThickness, string ExtraComment) :
                base(mcnpIndex, "Encased HDPE Block " + ExtraComment, TopLevel)
            {
                center = CenterOfHDPE;
                caseThickness = CaseThickness;
            }

            protected override void InitializeSubComponents()
            {
                Encased<string> componentComment = new Encased<string>("HDPE", "Enclosure");
                subComponents.Add(new EncasedBlock(primaryIndex, true, center, Extents.FNCL.HDPE_BLOCK_EXTENT,
                    caseThickness, hdpeMat, enclosureMat, componentComment, comment: "Corner Moderator Block"));
            }
        }
    }
}
