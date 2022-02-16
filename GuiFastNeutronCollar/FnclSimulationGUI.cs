using System;
using GuiInterface;
using Runner;

namespace GuiFastNeutronCollar
{
    public partial class FnclAnalysisGUI
    {
        private ModelManager model;
        private MPPostEditor mppostEditor;
        private FuelArrayEditor fuel;

        private void LaunchSelectedModel(object sender, EventArgs e)
        {
            model?.Close();
            model = new ModelManager();
            model.SetModel(this.modelSelector1.GetModelSelected());
            model.RunModels += RunMcnpModels;
            model.ShowFuelEditor += ShowFuelEditor;
            model.Show();
        }

        private void ShowFuelEditor(object sender, EventArgs e)
        {
            LaunchFuelEditor();
        }

        private void RunMcnpModels(object sender, EventArgs e)
        {
            var modelToRun = model.GetModel();
            var problems = model.GetProblemsToRun();

            GuiLogicSimulation.RunProblems(modelToRun, problems);
        }

        private void InitializeSimulationEvents()
        {
            this.modelSelector1.ModelSelected += LaunchSelectedModel;
         //   this.simConfig1.DataDirectoryUpdated += DataDirectoryChanged;
            this.simConfig1.PoliMiExePathUpdated += PoliMiExeChanged;
            this.simConfig1.MPPostExePathUpdated += MPPostExeChanged;
        }

        private void MPPostExeChanged(object sender, EventArgs e)
        {
            GuiLogicSimulation.SetMPPostExe(this.simConfig1.GetMPPostExe());
        }

        private void PoliMiExeChanged(object sender, EventArgs e)
        {
            GuiLogicSimulation.SetPoliMiExe(this.simConfig1.GetPoliMiExe());
        }

        //private void DataDirectoryChanged(object sender, EventArgs e)
        //{
        //    GuiLogicSimulation.SetDataDir(this.simConfig1.GetNewDataDirectory());
        //}

        private void LoadSimulationConfig()
        {
            GuiLogicSimulation.InitializeFromLastRun();
          //  this.simConfig1.SetDataDir(GuiLogicSimulation.GetDataDir());
            this.simConfig1.SetPoliMiPath(GuiLogicSimulation.GetPoliMiPath());
            this.simConfig1.SetMPPostPath(GuiLogicSimulation.GetMPPostPath());
            this.detectorSelector.SetDetectorType(GuiLogicSimulation.GetDetectorType());
        }

        private void CloseSimulationForms()
        {
            model?.Close();
        }

        private void bDetectorEditor_Click(object sender, EventArgs e)
        {
            mppostEditor?.Close();
            mppostEditor = new MPPostEditor();
            mppostEditor.DetectorSelectedChanged += MPPostDetectorSelectedChanged;
            mppostEditor.Show();
        }

        private void MPPostDetectorSelectedChanged(object sender, EventArgs e)
        {
            ChangeMPPostDetector();
        }

        private void ChangeMPPostDetector()
        {
            if (mppostEditor.IsHandleCreated)
            {
                mppostEditor.SetDetector(
                    DetectorFileMaker.GetDetectorDefaults((MPPostDefaultDetectors)mppostEditor.BaseDetector));
            }
        }

        private void fuelEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchFuelEditor();
        }

        private void LaunchFuelEditor()
        {
            fuel?.Close();
            fuel = new FuelArrayEditor();
            fuel.SetColsAndRows(DetectorDefaults.GetFuelRowCol());
            fuel.Show();
        }
    }
}
