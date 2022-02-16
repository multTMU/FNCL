using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;

namespace Runner
{
    public class DUCylSelFNCL : SelFNCL
    {
        private UraniumHollowCylinderSpec specs;
        private readonly bool UraniumSource;

        public DUCylSelFNCL(string configurationFile, bool UseAmLiSources, UraniumHollowCylinderSpec specifications,
            AmLiBlockTypes AmLiBlock, string additionalComment = "") : base(configurationFile, UseAmLiSources,
            AmLiBlock, additionalComment)
        {
            UraniumSource = !UseAmLiSources;
            specs = specifications;
        }

        protected override void InitializeComponents()
        {
            if (UraniumSource)
            {
                AddComponent(new NonEmbeddedSources.HollowCylinder(Indices.SOURCE, getCenterOfDU(), specs.Axis,
                    specs.Height,
                    specs.InnerRadius, specs.OuterRadius, MaterialManager.GetMaterial(specs.InnerMat),
                    UraniumHollowCylinderModels.UraniumHelper.GetMaterial(specs.Enrichment), true,
                    PoliMiSource.U238Sf));
            }
            else
            {
                AddComponent(new NonEmbeddedSources.HollowCylinder(Indices.SOURCE, getCenterOfDU(), specs.Axis,
                    specs.Height,
                    specs.InnerRadius, specs.OuterRadius, MaterialManager.GetMaterial(specs.InnerMat),
                    UraniumHollowCylinderModels.UraniumHelper.GetMaterial(specs.Enrichment), false));
            }

            base.InitializeComponents();
        }

        private Point3D getCenterOfDU()
        {
            return SelMeasurementComponents.GetCenterOfTopOfPucksAndPost(nPucks) + (specs.Height / 2) * specs.Axis;
        }
    }

    public interface ISelMeasurement
    {
        Point3D GetTopOfPostPucks();
        int GetNumberOfPucks();
        void SetNumberOfPucks(int pucks);
        void InitializeSelFncl();
    }


    public class SelFNCL : AmLiFNCL, ISelMeasurement
    {
        protected int nPucks;
        protected Point3D topOfPostPucks;

        public SelFNCL(string configurationFile, bool UseAmLiSources, AmLiBlockTypes AmLiBlock,
            string additionalComment = "") : base(
            configurationFile, UseAmLiSources, AmLiBlock, additionalComment)
        {
            InitializeSelFncl();
        }

        public SelFNCL(ProblemConfig Config, bool UseAmLiSources, AmLiBlockTypes AmLiBlock,
            string additionalComment = "") : base(
            Config, UseAmLiSources, AmLiBlock, additionalComment)
        {
            InitializeSelFncl();
        }

        protected override void SetUpFromSpecs(SimulationSpecification specs)
        {
            nPucks = specs.NumberOfSelPucks;
            base.SetUpFromSpecs(specs);
        }

        protected override void InitializeComponents()
        {
            AddComponent(new SelMeasurementComponents(Indices.FNCL.SEL_COMPONENTS, nPucks));
            base.InitializeComponents();
        }

        public int GetNumberOfPucks()
        {
            return nPucks;
        }

        public void SetNumberOfPucks(int pucks)
        {
            nPucks = pucks;
        }

        public void InitializeSelFncl()
        {
            nPucks = 0;
            topOfPostPucks = SelMeasurementComponents.GetCenterOfTopOfPucksAndPost(nPucks);
        }

        public Point3D GetTopOfPostPucks()
        {
            return SelMeasurementComponents.GetCenterOfTopOfPucksAndPost(nPucks);
        }
    }
}
