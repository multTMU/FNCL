using GeometrySampling;
using GlobalHelpers;
using MaterialManager = GlobalHelpers.MaterialManager;

namespace FastNeutronCollar
{
    public partial class FNCLcomponent : Component
    {
        private static MaterialElement hdpeMat;
        private static MaterialElement liqScintMat;
        private static MaterialElement enclosureMat;

        private static Encased<int> pmtMat = new Encased<int>()
        {
            Inner = Materials.ELECTRONICS, Outer = Materials.AL_ALLOY
        };

        private static double enclosureThickness;


        public FNCLcomponent() : base(Indices.FNCL.DETECTOR_INDEX, "FNCL Detector")
        {
            hdpeMat = MaterialManager.GetMaterial(Materials.HDPE);
            liqScintMat = MaterialManager.GetMaterial(Materials.EJ309);
            enclosureMat = MaterialManager.GetMaterial(Materials.ALUMINUM);

            center = GlobalDefaults.CENTER;
            enclosureThickness = Extents.ENCLOSURE_THICK;
        }

        public void OverrideDefaultMaterials(int materialHDPEkey, int materialLiqScintKey, int materialEnclosureKey)
        {
            hdpeMat = MaterialManager.GetMaterial(materialHDPEkey);
            liqScintMat = MaterialManager.GetMaterial(materialLiqScintKey);
            enclosureMat = MaterialManager.GetMaterial(materialEnclosureKey);
        }

        public void OverrideDefaultCenter(Point3D newCenterPoint)
        {
            center = newCenterPoint;
        }

        public void OverrideDefaultEnclosureThickness(double thickness)
        {
            enclosureThickness = thickness;
        }

        public void RaiseOrLowerFNCL(double displaceHeightFromCenter)
        {
            center.Z += displaceHeightFromCenter;
        }

        protected override void InitializeSubComponents()
        {
            Point3D panelCenter = Extents.FNCL.PANEL_CENTER;

            subComponents.Add(new Panel(Indices.FNCL.PANEL1, new PanelOneHelper(center, panelCenter)));
            subComponents.Add(new Panel(Indices.FNCL.PANEL2, new PanelTwoHelper(center, panelCenter)));
            subComponents.Add(new Panel(Indices.FNCL.PANEL3, new PanelThreeHelper(center, panelCenter)));

            subComponents.Add(new EncasedBlockOfHDPE(Indices.FNCL.RIGHT_HDPE,
                Extents.FNCL.HDPE_BLOCK_CENTER + center, enclosureThickness, "Right"));
            subComponents.Add(new EncasedBlockOfHDPE(Indices.FNCL.LEFT_HDPE,
                Point3D.MirrorX(Extents.FNCL.HDPE_BLOCK_CENTER) + center, enclosureThickness, "Left"));
        }
    }
}
