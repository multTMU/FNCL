using GuiInterface;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;

namespace GuiFastNeutronCollar
{
    public partial class ModelManager : Form
    {
        public event EventHandler RunModels;
        public event EventHandler ShowFuelEditor;
        private ModelTypes modelType;

        public ModelManager()
        {
            InitializeComponent();
            this.materialViewer1.ApplySelected += SelectedMaterialChanged;
            this.sourceSelection1.LaunchFuelEditor += LaunchFuelEditor;
            this.sourceSelection1.SourceChanged += SourceChanged;
            this.mcnpAndInterogator.ActivePassiveChanged += ActivePassiveChanged;
            this.mcnpAndInterogator.AddProblem += AddProblemToQueue;
            this.problemRunner1.RunCurrentModels += RunAllModels;
        }

        private void AddProblemToQueue(object sender, EventArgs e)
        {
            this.problemRunner1.AddProblem(CollectModel());
        }

        private SimulationSpecification CollectModel()
        {
            SimulationSpecification simulationSpecification = new SimulationSpecification
            {
                McnpInputDirectory = this.mcnpAndInterogator.GetMcnpInputFile(),
                NPS = this.mcnpAndInterogator.GetNPS(),
                Description = this.mcnpAndInterogator.GetDescription(),
                Activity = this.mcnpAndInterogator.GetActivity(),
                ActiveProblem = this.mcnpAndInterogator.GetActiveState(),
                FuelFile = this.sourceSelection1.GetFuelFile(),
                FuelHeightDisplacement = this.sourceSelection1.GetFuelHeightDisplacement(),
                InnerRadius = this.sourceSelection1.GetInnerRadius(),
                OutRadius = this.sourceSelection1.GetOuterRadius(),
                Center = this.sourceSelection1.GetCenter(),
                Axis = Point3DHelper.GetUnitVector(this.sourceSelection1.GetAxis()),
                Radius = this.sourceSelection1.GetRadius(),
                Height = this.sourceSelection1.GetHeightCylinder(),
                Material = this.sourceSelection1.GetMaterial(),
                SourcePoliMi = this.sourceSelection1.GetPoliMiSource(),
                SourceType = this.sourceSelection1.GetSourceType(),
                AmLiLeft = this.mcnpAndInterogator.GetAmLiLeft(),
                AmLiRight = this.mcnpAndInterogator.GetAmLiRight(),
                AmLiBlockType = this.mcnpAndInterogator.GetAmLiBlockType(),
                NeutronGeneratorType = this.mcnpAndInterogator.GetNeutronGeneratorType(),
                ModeratorThickness = this.mcnpAndInterogator.GetModeratorThickness(),
                UseCdShield = this.mcnpAndInterogator.GetUseCadmiumShield(),
                UsePbShield = this.mcnpAndInterogator.GetUseLeadShield(),
                PbThickness = this.mcnpAndInterogator.GetLeadThickness(),
                CdThickness = this.mcnpAndInterogator.GetCadmiumThickness(),
                TrackParticle = this.mcnpAndInterogator.GetParticle(),
                StandOff = this.mcnpAndInterogator.GetStandOff(),
                UseLeftPanelTwoShield = this.mcnpAndInterogator.GetUseExtraLeadLeftPanelTwo(),
                UseRightPanelOneShield = this.mcnpAndInterogator.GetUseExtraLeadRightPanelOne(),
                ExtraPbShieldDimensions = this.mcnpAndInterogator.GetExtraLeadSideShieldDimensions(),
                RotationDegrees = this.mcnpAndInterogator.GetGeneratorRotationDegrees(),
                GeneratorAxis = Point3DHelper.GetUnitVector(this.mcnpAndInterogator.GetGeneratorAxis()),
                GeneratorSourcePosistion = this.mcnpAndInterogator.GetGeneratorSourcePoint()
            };

            return simulationSpecification;
        }

        private void RunAllModels(object sender, EventArgs e)
        {
            OnRunModels();
        }

        protected virtual void OnRunModels()
        {
            RunModels?.Invoke(this, EventArgs.Empty);
        }

        private void ActivePassiveChanged(object sender, EventArgs e)
        {
            this.sourceSelection1.SetActiveState(this.mcnpAndInterogator.GetActiveState());
        }

        private void SourceChanged(object sender, EventArgs e)
        {
            this.materialViewer1.Enabled = this.sourceSelection1.EnableMaterialViewer();
        }

        private void LaunchFuelEditor(object sender, EventArgs e)
        {
            OnShowFuelEditor();
        }

        private void SelectedMaterialChanged(object sender, EventArgs e)
        {
            this.sourceSelection1.SetMaterial(this.materialViewer1.GetMaterialKey());
        }

        public void SetModel(ModelTypes modelSelected)
        {
            modelType = modelSelected;
            this.mcnpAndInterogator.SetModel(modelSelected);
        }

        public ModelTypes GetModel()
        {
            return modelType;
        }

        public List<SimulationSpecification> GetProblemsToRun()
        {
            return this.problemRunner1.GetSimulationsToRun();
        }

        protected virtual void OnShowFuelEditor()
        {
            ShowFuelEditor?.Invoke(this, EventArgs.Empty);
        }
    }
}
