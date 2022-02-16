using System;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class FnclAnalysisGUI
    {
        private PulseShapeDiscrimination psd;

        private void bPsd_Click(object sender, EventArgs e)
        {
            LaunchPsdEditor();
        }

        private void LaunchPsdEditor()
        {
            psd?.Close();
            psd = new PulseShapeDiscrimination();

            psd.SendNewPsdPlot += HandleUpdatePSDviewer;
            psd.LoadPSD += HandleReloadPsd;
            psd.DetectorChanged += HandlePsdDetectorChanged;
            psd.LaunchPsdWaveformViewer += HandlePsdViewWaveforms;
            psd.PsdFormClosing += HandlePsdFormClosing;

            psd.SetDefaults(DetectorDefaults.GetPSDfast(), DetectorDefaults.GetPSDslow(),
                DetectorDefaults.GetPsdAmplitudeScalar(),
                DetectorDefaults.GetPsdPeakMaxTriggerOffset(),
                DetectorDefaults.GetPsdTriggerType());
            psd.InitializePanels(DetectorDefaults.GetPanelOne(), DetectorDefaults.GetPanelTwo(),
                DetectorDefaults.GetPanelThree());

            psd.Show();
        }

        private void HandlePsdFormClosing(object sender, EventArgs e)
        {
            psdWaveform?.Close();
        }

        private void HandlePsdDetectorChanged(object sender, EventArgs e)
        {
            UpdatePsdDetectorChanged();
        }

        private void UpdatePsdDetectorChanged()
        {
            if (psd.IsHandleCreated)
            {
                psd.SetPsd(guiLogicAnalysis.GetPsdSpecification(psd.GetSelectedDetector()));
                psd.SetMaxNumberOfPulses(guiLogicAnalysis.GetNumberUnfilteredPulses(psd.GetSelectedDetector()));
            }
        }

        private void HandleUpdatePSDviewer(object sender, EventArgs e)
        {
            UpdatePSDviewer();
        }

        private void UpdatePSDviewer()
        {
            if (psd.IsHandleCreated)
            {
                StartBusy("Running Pulse Shape...");
                var currentDetector = psd.GetSelectedDetector();
                guiLogicAnalysis.SetPSD(currentDetector, psd.PsdSpecification);
                psd.Plot(guiLogicAnalysis.GetPSD(currentDetector, psd.NumberPulses));
                EndBusy();
            }
        }


        private void HandleReloadPsd(object sender, EventArgs e)
        {
            ReloadPsd();
        }

        private void ReloadPsd()
        {
            if (psd.IsHandleCreated)
            {
                psd.SetPsd(guiLogicAnalysis.GetPsdSpecification(psd.GetSelectedDetector()));
            }
        }

        private void EditCurrentPsd(object sender, EventArgs e)
        {
            LaunchPsdEditor();
        }
    }
}
