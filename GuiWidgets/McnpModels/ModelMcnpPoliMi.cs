using System;
using System.Windows.Forms;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;
using GuiInterface;

namespace GuiWidgets.FnclModels
{
    public partial class Model : UserControl, IModelConfigGui
    {
        private IModelConfigGui model;
        private bool activeMeasurement;
        public event EventHandler ActivePassiveChanged;
        public event EventHandler AddProblem;

        public Model()
        {
            InitializeComponent();
            model = ModelSelectionGuiHelper.GetModel(ModelTypes.Undefined);
            this.particleSelector1.SetDefault(Particle.Neutron);
        }

        public void SetModel(ModelTypes modelSelected)
        {
            this.uniPanelModel.Controls.Clear();
            model = ModelSelectionGuiHelper.GetModel(modelSelected);
            this.uniPanelModel.Controls.Add(model as Control);
            this.particleSelector1.SetParticle(ModelSelectionGuiHelper.GetModelDefaultParticle(modelSelected));
            EnableDisableBasedOnModel(modelSelected);
        }

        private void EnableDisableBasedOnModel(ModelTypes modelSelected)
        {
            this.cbActive.Enabled = ModelSelectionGuiHelper.ModelCanBeActive(modelSelected);
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            activeMeasurement = cbActive.Checked;
            OnActivePassiveChanged();
        }

        public string GetMcnpInputFile()
        {
            return this.mcnpSpec1.GetMcnpFile();
        }

        protected virtual void OnActivePassiveChanged()
        {
            ActivePassiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool GetActiveState()
        {
            return activeMeasurement;
        }

        private void OnAddProblem()
        {
            AddProblem?.Invoke(this, EventArgs.Empty);
        }

        public int GetNPS()
        {
            return this.mcnpSpec1.GetNPS();
        }

        public string GetDescription()
        {
            return this.mcnpSpec1.GetMcnpDescription();
        }

        public double GetActivity()
        {
            return this.mcnpSpec1.GetActivity();
        }

        public ModelTypes GetModelType()
        {
            return this.model.GetModelType();
        }

        public double GetAmLiLeft()
        {
            return this.model.GetAmLiLeft();
        }

        public double GetAmLiRight()
        {
            return this.model.GetAmLiRight();
        }

        private void bAddProblem_Click(object sender, EventArgs e)
        {
            OnAddProblem();
        }

        public double GetModeratorThickness()
        {
            return this.model.GetModeratorThickness();
        }

        public bool GetUseLeadShield()
        {
            return this.model.GetUseLeadShield();
        }

        public bool GetUseCadmiumShield()
        {
            return this.model.GetUseCadmiumShield();
        }

        public double GetLeadThickness()
        {
            return this.model.GetLeadThickness();
        }

        public double GetCadmiumThickness()
        {
            return this.model.GetCadmiumThickness();
        }

        public AmLiBlockTypes GetAmLiBlockType()
        {
            return this.model.GetAmLiBlockType();
        }

        public NeutronGeneratorTypes GetNeutronGeneratorType()
        {
            return this.model.GetNeutronGeneratorType();
        }

        public Point3D GetExtraLeadSideShieldDimensions()
        {
            return this.model.GetExtraLeadSideShieldDimensions();
        }

        public bool GetUseExtraLeadRightPanelOne()
        {
            return this.model.GetUseExtraLeadRightPanelOne();
        }

        public bool GetUseExtraLeadLeftPanelTwo()
        {
            return this.model.GetUseExtraLeadLeftPanelTwo();
        }

        public Point3D GetGeneratorAxis()
        {
            return this.model.GetGeneratorAxis();
        }

        public Point3D GetGeneratorSourcePoint()
        {
            return this.model.GetGeneratorSourcePoint();
        }

        public double GetGeneratorRotationDegrees()
        {
            return this.model.GetGeneratorRotationDegrees();
        }

        public Particle GetParticle()
        {
            return this.particleSelector1.GetParticle();
        }

        public double GetStandOff()
        {
            return this.model.GetStandOff();
        }
    }
}
