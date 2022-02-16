using System;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class FnclAnalysisGUI
    {
        private PulseWaveFormViewer waveform;
        private PulseWaveFormViewer psdWaveform;
        private PulseWaveFormViewer pileUpWaveform;

        private void bWaveform_Click(object sender, EventArgs e)
        {
            waveform?.Close();
            waveform = new PulseWaveFormViewer();
            waveform.SetNumberOfPulses(guiLogicAnalysis.GetNumberFilteredPulses());
            waveform.SetTimeStep(DetectorDefaults.GetPulseWaveTimeStep());
            waveform.PulseIndexChanged += this.SendPulseToWaveForm;
            waveform.Show();
        }

        private void HandlePsdViewWaveforms(object sender, EventArgs e)
        {
            if (psd.IsHandleCreated)
            {
                psdWaveform?.Close();
                psdWaveform = new PulseWaveFormViewer();
                psdWaveform.SetNumberOfPulses(guiLogicAnalysis.GetNumberFilteredPulses(psd.GetSelectedDetector()));
                psdWaveform.ConfigureForPSD();
                psdWaveform.PulseIndexChanged += HandleWaveformPsdPulseChanged;

                psdWaveform.Show();
            }
        }

        private void bPileUp_Click(object sender, EventArgs e)
        {
            pileUpWaveform?.Close();
            pileUpWaveform = new PulseWaveFormViewer();
            pileUpWaveform.ConfigureForPileUp();
            pileUpWaveform.SetNumberOfPulses(guiLogicAnalysis.GetNumberFilteredPulses());
            pileUpWaveform.PulseIndexChanged += HandleWaveformPileUpPulseChanged;
            pileUpWaveform.SetPileUpDefaults(DetectorDefaults.GetPileUpInterval(), DetectorDefaults.GetPileUpScalar());

            pileUpWaveform.Show();
        }

        private void HandleWaveformPileUpPulseChanged(object sender, EventArgs e)
        {
            int pulseIndex = pileUpWaveform.GetPulseIndex();
            pileUpWaveform.SetIsPileUp(guiLogicAnalysis.GetIsPileUp(pulseIndex,
                pileUpWaveform.GetPileUpScalar(),
                pileUpWaveform.GetPileUpInterval()));
            pileUpWaveform.SetPulseWaveForm(guiLogicAnalysis.GetPulseWaveForm(pulseIndex));
        }

        private void SendPulseToWaveForm(object sender, EventArgs e)
        {
            waveform.SetPulseWaveForm(guiLogicAnalysis.GetPulseWaveForm(waveform.GetPulseIndex()));
        }

        private void HandleWaveformPsdPulseChanged(object sender, EventArgs e)
        {
            int pulseIndex = psdWaveform.GetPulseIndex();
            if (pulseIndex >= 0)
            {
                psdWaveform.SetPsdPulseWaveForm(guiLogicAnalysis.GetPsdPulseWaveform(pulseIndex,
                    psd.PsdSpecification, psd.GetSelectedDetector()));
            }
        }
    }
}
