using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlobalHelpers;
using GlobalHelpersDefaults;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class FnclAnalysisGUI : Form
    {
        // Some members are defined in other files of this partial class
        private GuiLogicAnalysis guiLogicAnalysis;
        private EnergyCalibration eCal;
        private MultiplicityViewer multiplicity;
        private AddPoliMi poliMi;
        private PulseAmplitude pad;
        private DieAwayTime dieAway;
        private PulseStream pulseStream;
        private DetectorResponse drf;
        private BusyForm busy;

        public FnclAnalysisGUI()
        {
            InitializeComponent();
            guiLogicAnalysis = new GuiLogicAnalysis();
            InitializeSimulationEvents();
            LoadAnalysisConfig();
            LoadSimulationConfig();
            InitializeAnalysisEvents();
            HandleWorkingDetectorChanged(this.detectorSelector.GetSelectedDetectorType());
        }

        private void InitializeAnalysisEvents()
        {
            inPulseFile.FileChanged += PulseFileChanged;
            this.detectorSelector.DetectorChanged += WorkingDetectorChanged;
        }

        private void WorkingDetectorChanged(object sender, EventArgs e)
        {
            HandleWorkingDetectorChanged(this.detectorSelector.GetSelectedDetectorType());
        }

        private void HandleWorkingDetectorChanged(DetectorType selectedDetectorType)
        {
            guiLogicAnalysis.SelectedDetectorChanged(selectedDetectorType);
            bool state = selectedDetectorType != DetectorType.None;
            this.pulseInfo.Enabled = state;
            this.inPulseFile.Enabled = state;
            this.bFilter.Enabled = state;
            this.gbView.Enabled = state;
            this.gbAnalyze.Enabled = state;
        }

        private void PulseFileChanged(object sender, EventArgs e)
        {
            HandlePulseFileChanged(inPulseFile.FileFullPath);
        }

        private void LoadAnalysisConfig()
        {
            inPulseFile.SetPrompt("Choose Pulse File");
            inPulseFile.SetFileFilter(MultiplicityInterfaceHelper.GetPulseFileFilter());
            inPulseFile.SetInitialDirectory(ConfigureDictionaries.GetStartingMcnpSaveDir());
        }

        private void UpdateMainForm()
        {
            DisplayPulseFile();
            pulseInfo.SetCountTimeFiltered(guiLogicAnalysis.GetCountTimeFiltered());
            pulseInfo.SetNumberPulsesFiltered(guiLogicAnalysis.GetNumberFilteredPulses());
            UpdateOpenWindows();
        }

        private void UpdateOpenWindows()
        {
            if (pad != null)
            {
                UpdatePadViewer();
            }

            if (psd != null)
            {
                UpdatePSDviewer();
            }

            if (pulseStream != null)
            {
                UpdatePulseStreamView();
            }
        }

        private void StartBusy(string busyText)
        {
            busy?.Close();
            busy = new BusyForm();
            busy.SetText(busyText);
            busy.Show();
        }

        private void EndBusy()
        {
            busy?.Close();
        }

        private void ConfigureGuiForPulseType()
        {
            bWaveform.Enabled = guiLogicAnalysis.EnablePSD();
            bPsd.Enabled = guiLogicAnalysis.EnablePSD();
            bECal.Enabled = guiLogicAnalysis.EnablePAD();
            bPulseHeight.Enabled = guiLogicAnalysis.EnablePAD();
            bPileUp.Enabled = guiLogicAnalysis.EnablePileUpRejector();
        }

        private void DisplayPulseFile()
        {
            inPulseFile.SetFullFilePath(guiLogicAnalysis.PulseFile);
            pulseInfo.SetCountTime(guiLogicAnalysis.GetCountTime());
            pulseInfo.SetCreation(guiLogicAnalysis.GetCreation());
            pulseInfo.SetNumberPulses(guiLogicAnalysis.GetNumberUnfilteredPulses());
            pulseInfo.SetSize(guiLogicAnalysis.GetFileSize());
            pulseInfo.SetPulseType(guiLogicAnalysis.GetPulseTypeString());
            pulseInfo.SetCountTimeFiltered(guiLogicAnalysis.GetCountTime());
            pulseInfo.SetNumberPulsesFiltered(guiLogicAnalysis.GetNumberUnfilteredPulses());
        }

        private void HandlePulseFileChanged(string pulseFile)
        {
            if (!string.IsNullOrEmpty(pulseFile))
            {
                if (NotPoliMi(pulseFile))
                {
                    StartBusy("Loading File...");
                    guiLogicAnalysis.SetPulseFile(pulseFile);
                    EndBusy();
                }
                else
                {
                    ConfigurePoliMi(pulseFile);
                }
            }
            else
            {
                guiLogicAnalysis.SetPulseFile(string.Empty);
            }

            ConfigureGuiForPulseType();
            UpdateMainForm();
        }

        private bool NotPoliMi(string PulseFile)
        {
            return !string.Equals(Path.GetExtension(PulseFile), MultiplicityInterfaceHelper.EXT_POLIMI);
        }

        private void bECal_Click(object sender, EventArgs e)
        {
            eCal?.Close();
            eCal = new EnergyCalibration();
            eCal.InitializeECal(DetectorDefaults.GetPanelOne(), DetectorDefaults.GetPanelTwo(),
                DetectorDefaults.GetPanelThree());
            eCal.Show();
        }

        private void bMultiplicity_Click(object sender, EventArgs e)
        {
            multiplicity?.Close();
            multiplicity = new MultiplicityViewer();
            multiplicity.SetDefaultGates(DetectorDefaults.GetGate(), DetectorDefaults.GetPreDelay(),
                DetectorDefaults.GetLongDelay());
            multiplicity.UpdateMultiplicityViewer += UpdateMultiplicity;
            multiplicity.Show();
        }

        private void UpdateMultiplicity(object sender, EventArgs e)
        {
            RunMultiplicityGate();
        }

        private void RunMultiplicityGate()
        {
            StartBusy("Running Multiplicity...");
            guiLogicAnalysis.RunMultiplicityGate(multiplicity.GetMultiplicityGate());
            multiplicity.PlotRealAccs(guiLogicAnalysis.GetRandAHisto());
            multiplicity.PlotReals(guiLogicAnalysis.GetRealsHisto());
            multiplicity.DisplayMultiplets(guiLogicAnalysis.GetSingles(), guiLogicAnalysis.GetDoubles(),
                guiLogicAnalysis.GetTriples());
            multiplicity.DisplayMultipletsUncert(guiLogicAnalysis.GetSinglesUncert(),
                guiLogicAnalysis.GetDoubleUncert(),
                guiLogicAnalysis.GetTriplesUncert());
            EndBusy();
        }

        private void bPulseHeight_Click(object sender, EventArgs e)
        {
            pad?.Close();
            pad = new PulseAmplitude();
            pad.SendNewPadPlot += HandleUpdatePADviewer;
            pad.Show();
        }

        private void HandleUpdatePADviewer(object sender, EventArgs e)
        {
            UpdatePadViewer();
        }

        private void UpdatePadViewer()
        {
            if (pad.IsHandleCreated)
            {
                StartBusy("Recalculate Pulse Amplitudes...");
                guiLogicAnalysis.SetPAD(pad.GetAmplitudeType());
                pad.Plot(guiLogicAnalysis.GetPAD());
                EndBusy();
            }
        }

        private void UpdatePulseStreamView()
        {
            if (pulseStream.IsHandleCreated)
            {
                StartBusy("Fetching Pulse Stream Segment");
                pulseStream.ReplotPulses(guiLogicAnalysis.GetPulseTimes());
                EndBusy();
            }
        }

        private string GetFile(string initialDirectory, bool multiSelect, string prompt, bool createFile,
            string filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*")
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = initialDirectory;
            openFile.Multiselect = multiSelect;
            openFile.Title = prompt;
            openFile.CheckFileExists = !createFile;
            openFile.Filter = filter;

            string file = string.Empty;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                file = openFile.FileName;
            }

            return file;
        }

        private void ResetPulses(object sender, EventArgs e)
        {
            guiLogicAnalysis.ResetFilteredPulses();
            UpdateMainForm();
            UpdateOpenWindows();
        }

        private void bDieAway_Click(object sender, EventArgs e)
        {
            dieAway?.Close();

            dieAway = new DieAwayTime();
            dieAway.CalculateRates += DieAwayCalculateRates;
            dieAway.FitTypeChange += DieAwayFitTypeChanged;
            dieAway.Show();
        }

        private void bPulseStreamViewer_Click(object sender, EventArgs e)
        {
            pulseStream?.Close();
            pulseStream = new PulseStream();
            pulseStream.ReplotPulses(guiLogicAnalysis.GetPulseTimes());
            pulseStream.Show();
        }

        private void DieAwayFitTypeChanged(object sender, EventArgs e)
        {
            FitDieAwayCurve();
        }

        private void FitDieAwayCurve()
        {
            guiLogicAnalysis.CalculateDieAwayFit(dieAway.GetFitType(), dieAway.GetTimeIntervalHistorgram());
            dieAway.UpdateFitPlot(guiLogicAnalysis.GetDieAwayFitLine());
            dieAway.SetFitParameters(guiLogicAnalysis.GetDieAwayFitParameters(),
                guiLogicAnalysis.GetDieAwayGoodnessOfFit());
        }

        private void DieAwayCalculateRates(object sender, EventArgs e)
        {
            StartBusy("Running Die Away...");
            dieAway.UpdateRawPlot(guiLogicAnalysis.CalculateDieAwayRates(dieAway.GetMinTime(), dieAway.GetMaxTime()));
            FitDieAwayCurve();
            EndBusy();
        }

        private void ConfigurePoliMi(string initialFile = "")
        {
            poliMi = new AddPoliMi();
            poliMi.UpdatedPoliMiProblems += UpdatePoliMiProblems;
            poliMi.UpdatedPoliMiFile += UpdatedPoliMiFile;
            poliMi.SetInitialFiles(guiLogicAnalysis.GetPoliMiProblems());
            poliMi.SetStartingFile(initialFile);
            poliMi.ShowDialog();
        }

        private void UpdatedPoliMiFile(object sender, EventArgs e)
        {
            try
            {
                string poliMiFile = poliMi.GetCurrentFile();
                if (guiLogicAnalysis.AbleToSetPoliMiSpecs(poliMiFile))
                {
                    poliMi.SetFromPoliMiSpecFile(guiLogicAnalysis.GetPoliMiActivity, guiLogicAnalysis.GetPoliMiMcnpNPS);
                }
            }
            catch
            {
                // just in case form doesn't exist
            }
        }

        private void UpdatePoliMiProblems(object sender, EventArgs e)
        {
            StartBusy("Making Stream...");
            guiLogicAnalysis.SetPoliMiProblems(poliMi.GetProblems(), poliMi.GetSeed());
            EndBusy();
        }

        private void FnclAnalysisGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuiLogicSimulation.SaveLastConfiguration(guiLogicAnalysis.PulseFile);
            CloseAnalysisForms();
            CloseSimulationForms();
        }

        private void CloseAnalysisForms()
        {
            eCal?.Close();
            multiplicity?.Close();
            waveform?.Close();
            psd?.Close();
            filters?.Close();
            poliMi?.Close();
            pad?.Close();
            dieAway?.Close();
            pulseStream?.Close();
        }

        private void savePulsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePulses();
        }

        private void SavePulses()
        {
            string saveFile = MultiplicityInterfaceHelper.GetFile("File to Save Current Filtered Pulse Stream", true,
                "flat-file(*.txt) | *.txt");
            if (!string.IsNullOrEmpty(saveFile))
            {
                StartBusy("Saving file...");
                guiLogicAnalysis.WriteFilteredPulsesToFile(saveFile);
                EndBusy();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurePoliMi();
        }


        private void bDrf_Click(object sender, EventArgs e)
        {
            drf?.Close();
            drf = new DetectorResponse();
            drf.CalculateDrf += CalculateDrf;
            drf.Show();
        }

        private void CalculateDrf(object sender, EventArgs e)
        {
            if (drf.IsHandleCreated)
            {
                StartBusy("Calculating DRF...");
                drf.SetDrf(guiLogicAnalysis.CalculateDrf(drf.GetSourceRate()));
                EndBusy();
            }
        }

        private void saveCurrentPulsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePulses();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpSplash splash = new HelpSplash();
            splash.Show();
        }
    }
}
