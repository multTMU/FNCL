using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GlobalHelpersDefaults;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class PulseFilters : Form
    {
        public event EventHandler RunFilters;
        public event EventHandler ResetPulses;
        public event EventHandler EditCurrentPsd;
        public event EventHandler BatchCombinePulses;
        public event EventHandler SaveCurrentToFlat;
        public event EventHandler SaveFiltersToFile;
        private bool combiningPulses;

        public string SaveFiltersFile => saveFiltersFile;
        private string saveFiltersFile;

        public PulseFilters()
        {
            InitializeComponent();
            combiningPulses = false;
            this.particleSelector1.DisableBothOption();
            this.pulseFilters1.EditPsd += HandleOnEditCurrentPsd;
        }

        private void HandleOnEditCurrentPsd(object sender, EventArgs e)
        {
            OnEditCurrentPsd();
        }

        protected virtual void HandelFilterEvent()
        {
            EventHandler handler = this.RunFilters;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public List<AppliedPulseFilters> GetFilterOrder()
        {
            return this.filterOrdering1.PulseFilterOrder;
        }

        public Particle GetParticle()
        {
            return this.particleSelector1.GetParticle();
        }

        public int GetAdcLLD()
        {
            return this.pulseProcessing1.AdcLLD;
        }

        public int GetAdcULD()
        {
            return this.pulseProcessing1.AdcULD;
        }

        public List<int> GetPanelOneOffSets()
        {
            return this.pulseProcessing1.GetPanelOneOffSets();
        }

        public List<int> GetPanelTwoOffSets()
        {
            return this.pulseProcessing1.GetPanelTwoOffSets();
        }

        public List<int> GetPanelThreeOffSets()
        {
            return this.pulseProcessing1.GetPanelThreeOffSets();
        }

        public List<int> GetSelectedDetectors()
        {
            return this.fnclDetectorSelect1.GetSelectedDetectors();
        }

        public double GetPulseHeightLLDKeVee()
        {
            return this.pulseFilters1.PulseHeightLLD;
        }

        public double GetPulseHeightULDKeVee()
        {
            return this.pulseFilters1.PulseHeightULD;
        }

        public int GetMaxTimeBetweenPulses()
        {
            return this.pulseFilters1.MaxTimeInterval;
        }

        public int GetPileUp()
        {
            return this.pulseFilters1.PileUp;
        }

        public CrossTalk GetDetectorCrossTalk()
        {
            return this.pulseFilters1.DetectorCrossTalk;
        }

        public void SetDefaults(double pulseHeightLLD, double pulseHeightULD, int pileUpTime, bool crosstalk,
            int adcLLD, double startTime, double endTime, int correlatedPulseTime,
            List<AppliedPulseFilters> filterOrder, Particle particle, double pileUpInterval, double pileUpScalar,
            double flatTopDuration, double flatTopMaxPercentTol)
        {
            this.pulseFilters1.SetDefaults(pulseHeightLLD, pulseHeightULD, pileUpTime, crosstalk, correlatedPulseTime);
            this.pulseProcessing1.SetAdcTrigger(adcLLD, int.MaxValue);
            this.pulseStreamControl1.SetDefaults(startTime, endTime);
            this.filterOrdering1.SetDefaultFilterOrder(filterOrder);
            this.particleSelector1.SetDefault(particle);
            this.pileUpFilter1.SetDefault(pileUpInterval, pileUpScalar);
            this.flatTopPulseFilter1.SetDefaults(flatTopDuration, flatTopMaxPercentTol);
        }

        public void EnableParticleSelector(bool state)
        {
            this.particleSelector1.Enabled = state;
        }

        public void EnablePileUpRejection(bool state)
        {
            this.pileUpFilter1.Enabled = state;
        }

        public void EnablePulseHeight(bool state)
        {
            this.pulseFilters1.EnablePulseHeight(state);
        }

        public void EnablePSD(bool state)
        {
            this.pulseFilters1.EnablePSD(state);
        }

        public void EnableADCtrigger(bool state)
        {
            this.pulseProcessing1.EnableADCtrigger(state);
            this.flatTopPulseFilter1.EnableFlatTop(state);
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            HandelFilterEvent();
        }

        public double GetStartTime()
        {
            return this.pulseStreamControl1.StartTime;
        }

        public double GetEndTime()
        {
            return this.pulseStreamControl1.EndTime;
        }

        public void ConfigureForPulseCombine()
        {
            combiningPulses = true;
            EnableOrDisableAll(true);
            this.bApply.Enabled = false;
            this.pulseStreamControl1.Enabled = false;
        }

        private void EnableOrDisableAll(bool state)
        {
            this.particleSelector1.Enabled = state;
            this.pulseFilters1.EnablePulseHeight(state);
            this.pulseFilters1.EnablePSD(state);
            this.pulseProcessing1.EnableADCtrigger(state);
            this.pulseStreamControl1.Enabled = state;
        }

        public void EnableCorrelatedPulseTime(bool state)
        {
            this.pulseFilters1.EnableCorrelatedPulseTime(state);
        }

        public string GetPsdFile()
        {
            return this.pulseFilters1.PsdFile;
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            OnResetPulses();
        }

        protected virtual void OnResetPulses()
        {
            ResetPulses?.Invoke(this, EventArgs.Empty);
        }

        private void bSaveFlat_Click(object sender, EventArgs e)
        {
            OnSaveCurrentToFlat();
        }

        private void bBatchSaveFlat_Click(object sender, EventArgs e)
        {
            OnBatchCombinePulses();
        }

        public double GetPileUpScalar()
        {
            return this.pileUpFilter1.Scalar;
        }

        public double GetPileUpInterval()
        {
            return this.pileUpFilter1.Interval;
        }

        protected virtual void OnEditCurrentPsd()
        {
            EditCurrentPsd?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnBatchCombinePulses()
        {
            BatchCombinePulses?.Invoke(this, EventArgs.Empty);
        }

        public double GetFlatTopDuration()
        {
            return flatTopPulseFilter1.Duration;
        }

        public double GetFlatTopPeakMaxPercent()
        {
            return flatTopPulseFilter1.PeakMaxTolerancePercent;
        }

        public void EnableBatchCombinePulses(bool enableBatchCombinePulses)
        {
            this.bBatchSaveFlat.Enabled = enableBatchCombinePulses;
        }

        protected virtual void OnSaveCurrentToFlat()
        {
            SaveCurrentToFlat?.Invoke(this, EventArgs.Empty);
        }

        private void bSaveFilters_Click(object sender, EventArgs e)
        {
            SaveFilters();
        }

        private void SaveFilters()
        {
            saveFiltersFile = MultiplicityInterfaceHelper.GetFile("Save Current Filters As...", true);
            if (!string.IsNullOrEmpty(saveFiltersFile))
            {
                OnSaveFiltersToFile();
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
        }

        protected virtual void OnSaveFiltersToFile()
        {
            SaveFiltersToFile?.Invoke(this, EventArgs.Empty);
        }
    }
}
