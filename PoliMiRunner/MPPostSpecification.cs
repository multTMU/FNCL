using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalHelpers;
using GlobalHelpersDefaults;

namespace PoliMiRunner
{
    public class MPPostSpecification
    {
        public CaptureEvents captureEvents;
        public CaptureGatedDetector captureGatedDetector;
        public PulseHeightCorrelation pulseHeightCorrelation;
        public Correlations correlations;
        public TimeResolution timeResolution;
        public LightResolution lightResolution;
        public OrganicScintillator organicScintillator;
        public DeadTimeNanoSeconds deadTimeNanoSeconds;
        public PulseGenerationTimeNanoSeconds pulseGenerationTime;
        public DetectorPulseHeight detectorPulseHeight;
        public DetectorInformation detectorInformation;
        public Memory memory;
        public FileIO fileIO;
        public GeneralInfo generalInfo;
        public He3Module he3Module;

        private string lastFile;
        private const int NUMBER_VARS = 15;
        private Dictionary<int, MPPostSection> fileIoDictionary;

        private static bool writeUnused;

        public MPPostSpecification()
        {
            writeUnused = false;
            RefreshAll();
            lastFile = string.Empty;
        }

        private void RefreshAll()
        {
            captureEvents = new CaptureEvents();
            captureGatedDetector = new CaptureGatedDetector();
            pulseGenerationTime = new PulseGenerationTimeNanoSeconds();
            correlations = new Correlations();
            pulseHeightCorrelation = new PulseHeightCorrelation();
            timeResolution = new TimeResolution();
            lightResolution = new LightResolution();
            organicScintillator = new OrganicScintillator();
            deadTimeNanoSeconds = new DeadTimeNanoSeconds();
            detectorPulseHeight = new DetectorPulseHeight();
            detectorInformation = new DetectorInformation();
            memory = new Memory();
            fileIO = new FileIO();
            generalInfo = new GeneralInfo();
            he3Module = new He3Module();

            PopulateFileDictionary();
        }

        private void PopulateFileDictionary()
        {
            fileIoDictionary = new Dictionary<int, MPPostSection>();
            fileIoDictionary.Add(organicScintillator.OrderIO, organicScintillator);
            fileIoDictionary.Add(captureEvents.OrderIO, captureEvents);
            fileIoDictionary.Add(captureGatedDetector.OrderIO, captureGatedDetector);
            fileIoDictionary.Add(pulseGenerationTime.OrderIO, pulseGenerationTime);
            fileIoDictionary.Add(correlations.OrderIO, correlations);
            fileIoDictionary.Add(pulseHeightCorrelation.OrderIO, pulseHeightCorrelation);
            fileIoDictionary.Add(timeResolution.OrderIO, timeResolution);
            fileIoDictionary.Add(he3Module.OrderIO, he3Module);
            fileIoDictionary.Add(generalInfo.OrderIO, generalInfo);
            fileIoDictionary.Add(fileIO.OrderIO, fileIO);
            fileIoDictionary.Add(memory.OrderIO, memory);
            fileIoDictionary.Add(detectorInformation.OrderIO, detectorInformation);
            fileIoDictionary.Add(deadTimeNanoSeconds.OrderIO, deadTimeNanoSeconds);
            fileIoDictionary.Add(lightResolution.OrderIO, lightResolution);
            fileIoDictionary.Add(detectorPulseHeight.OrderIO, detectorPulseHeight);
        }

        public void SetNPS(int nps)
        {
            detectorInformation.McnpNps.SetValue(nps);
        }

        public void SetDetectorCells(List<int> detectorCells)
        {
            detectorInformation.DetectorCells.SetValue(new List<List<int>>() {detectorCells});
        }

        public void WriteToFile(string detectorFile)
        {
            UpdateLastFile(detectorFile);
            using (StreamWriter sw = new StreamWriter(detectorFile))
            {
                HeaderWrite(sw);

                foreach (var variable in GetOrderedVariables())
                {
                    WriteSection(variable, sw);
                }
            }
        }

        private List<MPPostSection> GetOrderedVariables()
        {
            List<MPPostSection> variables = new List<MPPostSection>();
            for (int i = 0; i < NUMBER_VARS; i++)
            {
                variables.Add(fileIoDictionary[i]);
            }

            return variables;
        }

        public void ReadFromFile(string detectorFile)
        {
            RefreshAll();
            UpdateLastFile(detectorFile);
            using (StreamReader sr = new StreamReader(detectorFile))
            {
                foreach (var variable in GetOrderedVariables())
                {
                    variable.ReadSection(sr);
                }
            }
        }

        private void UpdateLastFile(string detectorFile)
        {
            lastFile = detectorFile;
        }

        private static void HeaderWrite(StreamWriter sw)
        {
            sw.WriteLine(MPPostSection.COMMENT_SECTION);
            sw.WriteLine(MPPostSection.COMMENT + " version: 2.1.0");
            sw.WriteLine(MPPostSection.COMMENT + " " + DateTime.Now.ToString());
            sw.WriteLine(MPPostSection.COMMENT + " " + Environment.UserName);
            sw.WriteLine(MPPostSection.COMMENT_SECTION);
        }

        private static void WriteSection(MPPostSection section, StreamWriter writer)
        {
            foreach (var s in section.GetTextForSection())
            {
                writer.WriteLine(s);
            }
        }

        public class He3Module : MPPostSection
        {
            public enum He3DeadTimeType
            {
                IndividualTube = 1,
                TubeIntoAmplifier = 2,
                AWCCstyle = 3
            }

            public enum He3TriggerType
            {
                Constant = 1,
                TriggerReverse = 2,
                TriggerForward = 3
            }

            public enum He3OutputStyle
            {
                All = 1,
                LastRates = 2,
                LateDistributions = 3
            }

            public DetectorVariable<bool> EnableHe3;
            public DetectorVariable<int> NumberWindows;
            public DetectorVariable<int> WindowIncrementMicroSec;

            public DetectorVariable<He3DeadTimeType>
                DeadTimeType;

            public DetectorVariable<double> DeadTimeMicroSec;

            public DetectorVariable<double>
                AmplifierDeadTimeMicroSec;

            public DetectorVariable<double>
                AmplifierTwoDeadTimeMicroSec;

            public DetectorVariable<int> MaxExpectedMultiplicity;

            public DetectorVariable<He3TriggerType>
                TriggerType;

            public DetectorVariable<double> PreDelayMicroSec;
            public DetectorVariable<double> LongDelayMicroSec;
            public DetectorVariable<double> RunTimeSec;

            public DetectorVariable<He3OutputStyle>
                OutputStyle;

            public DetectorVariable<bool> IsParalyzable;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnableHe3 = new DetectorVariable<bool>("he3_multiplicity");
                NumberWindows = new DetectorVariable<int>("number_of_windows");
                WindowIncrementMicroSec = new DetectorVariable<int>("window_increment");
                DeadTimeType = new DetectorVariable<He3DeadTimeType>("deadtime_type");
                DeadTimeMicroSec = new DetectorVariable<double>("detector_deadtime");
                AmplifierDeadTimeMicroSec = new DetectorVariable<double>("amplifier_deadtime");
                AmplifierTwoDeadTimeMicroSec = new DetectorVariable<double>("amp_2_deadtime");
                MaxExpectedMultiplicity = new DetectorVariable<int>("max_multiplicity");
                TriggerType = new DetectorVariable<He3TriggerType>("trigger_type");
                PreDelayMicroSec = new DetectorVariable<double>("pre_delay");
                LongDelayMicroSec = new DetectorVariable<double>("long_delay");
                RunTimeSec = new DetectorVariable<double>("run_time");
                OutputStyle = new DetectorVariable<He3OutputStyle>("output_style");
                IsParalyzable = new DetectorVariable<bool>("paralyzable");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnableHe3);
                AddSingle(NumberWindows);
                AddSingle(WindowIncrementMicroSec);
                AddEnum(DeadTimeType);
                AddSingle(DeadTimeMicroSec);
                AddSingle(AmplifierDeadTimeMicroSec);
                AddSingle(AmplifierTwoDeadTimeMicroSec);
                AddSingle(MaxExpectedMultiplicity);
                AddEnum(TriggerType);
                AddSingle(PreDelayMicroSec);
                AddSingle(LongDelayMicroSec);
                AddSingle(RunTimeSec);
                AddEnum(OutputStyle);
                AddBoolean(IsParalyzable);
            }

            protected override string GetSectionName()
            {
                return "He3 MODULE";
            }

            public He3Module() : base(14)
            {
            }

            public He3Module(DetectorVariableBase<double> ampDeadTime,
                DetectorVariableBase<double> amp2, DetectorVariableBase<double> deadTime,
                DetectorVariableBase<He3DeadTimeType> deadTimeType, DetectorVariableBase<bool> enable,
                DetectorVariableBase<double> longDelay, DetectorVariableBase<int> maxMultiplicity,
                DetectorVariableBase<int> numberWindows, DetectorVariableBase<He3OutputStyle> outputStyle,
                DetectorVariableBase<bool> paralyzeable, DetectorVariableBase<double> preDelay,
                DetectorVariableBase<double> runTime, DetectorVariableBase<He3TriggerType> triggerType,
                DetectorVariableBase<int> windowIncrement) : this()
            {
                AmplifierDeadTimeMicroSec.SetValueAndState(ampDeadTime);
                AmplifierTwoDeadTimeMicroSec.SetValueAndState(amp2);
                DeadTimeMicroSec.SetValueAndState(deadTime);
                DeadTimeType.SetValueAndState(deadTimeType);
                MaxExpectedMultiplicity.SetValueAndState(maxMultiplicity);
                EnableHe3.SetValueAndState(enable);
                NumberWindows.SetValueAndState(numberWindows);
                TriggerType.SetValueAndState(triggerType);
                PreDelayMicroSec.SetValueAndState(preDelay);
                LongDelayMicroSec.SetValueAndState(longDelay);
                RunTimeSec.SetValueAndState(runTime);
                OutputStyle.SetValueAndState(outputStyle);
                IsParalyzable.SetValueAndState(paralyzeable);
                WindowIncrementMicroSec.SetValueAndState(windowIncrement);
            }
        }

        public class CaptureEvents : MPPostSection
        {
            public DetectorVariable<bool> PrintSortedEventFile;
            public DetectorVariable<Particle> SortParticleType;
            public DetectorVariable<int> SortMaterial;
            public DetectorVariable<int> SortInteraction;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                PrintSortedEventFile = new DetectorVariable<bool>("output_sort_file");
                SortParticleType = new DetectorVariable<Particle>("sort_ipt");
                SortMaterial = new DetectorVariable<int>("sort_nxs");
                SortInteraction = new DetectorVariable<int>("sort_ntyn");
            }

            protected override void GetSectionText()
            {
                AddBoolean(PrintSortedEventFile);
                AddEnum(SortParticleType);
                AddSingle(SortMaterial);
                AddSingle(SortInteraction);
            }

            protected override string GetSectionName()
            {
                return "Capture Events";
            }

            public CaptureEvents() : base(12)
            {
            }

            public CaptureEvents(DetectorVariableBase<Particle> particle, DetectorVariableBase<int> sortMaterial,
                DetectorVariableBase<int> sortInteraction, DetectorVariableBase<bool> printSorted) : this()
            {
                SortParticleType.SetValueAndState(particle);
                SortInteraction.SetValueAndState(sortInteraction);
                SortMaterial.SetValueAndState(sortInteraction);
                PrintSortedEventFile.SetValueAndState(printSorted);
            }
        }

        public class CaptureGatedDetector : MPPostSection
        {
            public DetectorVariable<bool> EnableCaptureGating;
            public DetectorVariable<double> StartTimeNanoSec;
            public DetectorVariable<double> StopTimeNanoSec;
            public DetectorVariable<double> BinSize;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnableCaptureGating = new DetectorVariable<bool>("capture_gate_on");
                StartTimeNanoSec = new DetectorVariable<double>("cap_low");
                StopTimeNanoSec = new DetectorVariable<double>("cap_high");
                BinSize = new DetectorVariable<double>("cap_incr");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnableCaptureGating);
                AddSingle(StartTimeNanoSec);
                AddSingle(StopTimeNanoSec);
                AddSingle(BinSize);
            }

            protected override string GetSectionName()
            {
                return "Capture Gated Detector";
            }

            public CaptureGatedDetector() : base(13)
            {
            }

            public CaptureGatedDetector(DetectorVariableBase<bool> enableCaptureGate,
                DetectorVariableBase<double> start, DetectorVariableBase<double> stop,
                DetectorVariableBase<double> binSize) : this()
            {
                EnableCaptureGating.SetValueAndState(enableCaptureGate);
                StartTimeNanoSec.SetValueAndState(start);
                StopTimeNanoSec.SetValueAndState(stop);
                BinSize.SetValueAndState(binSize);
            }
        }

        public class PulseHeightCorrelation : MPPostSection
        {
            public DetectorVariable<bool>
                EnablePulseHeightCorrelation;

            public DetectorVariable<double> MinBinMeVee;
            public DetectorVariable<double> MaxBinMeVee;
            public DetectorVariable<double> BinIncrementMeVee;
            public DetectorVariable<bool> IgnoreStartDetectorPulse;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnablePulseHeightCorrelation = new DetectorVariable<bool>("pulse_correlation_on");

                MinBinMeVee = new DetectorVariable<double>("pc_min");
                MaxBinMeVee = new DetectorVariable<double>("pc_max");
                BinIncrementMeVee = new DetectorVariable<double>("pc_incr");
                IgnoreStartDetectorPulse = new DetectorVariable<bool>("stop_pulse_only");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnablePulseHeightCorrelation);
                AddSingle(MinBinMeVee);
                AddSingle(MaxBinMeVee);
                AddSingle(BinIncrementMeVee);
                AddBoolean(IgnoreStartDetectorPulse);
            }

            protected override string GetSectionName()
            {
                return "Pulse Height Correlations";
            }

            public PulseHeightCorrelation() : base(7)
            {
            }

            public PulseHeightCorrelation(DetectorVariableBase<double> binSize, DetectorVariableBase<double> minBin,
                DetectorVariableBase<double> maxBin, DetectorVariableBase<bool> ignoreStart,
                DetectorVariableBase<bool> enablePulseHeight) : this()
            {
                EnablePulseHeightCorrelation.SetValueAndState(enablePulseHeight);
                BinIncrementMeVee.SetValueAndState(binSize);
                MinBinMeVee.SetValueAndState(minBin);
                MaxBinMeVee.SetValueAndState(maxBin);
                IgnoreStartDetectorPulse.SetValueAndState(ignoreStart);
            }
        }

        public class Correlations : MPPostSection
        {
            public DetectorVariable<bool> EnableTimeOfFlight;

            public DetectorVariable<bool>
                EnableCrossCorrelation;

            public DetectorVariable<bool> EnableAutoCorrelation;

            public DetectorVariable<int>
                CellOfStartDetector_BlankForTOF;

            public DetectorVariable<double> StartTimeNanoSec;
            public DetectorVariable<double> StopTimeNanoSec;
            public DetectorVariable<double> BinIncrementNanoSec;

            public DetectorVariable<double>
                CorrelationTimeWindowNanoSec;


            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnableTimeOfFlight = new DetectorVariable<bool>("tof_on");
                EnableCrossCorrelation = new DetectorVariable<bool>("cross_correlation_on");
                EnableAutoCorrelation = new DetectorVariable<bool>("auto_correlation_on");
                CellOfStartDetector_BlankForTOF = new DetectorVariable<int>("start_detector");
                StartTimeNanoSec = new DetectorVariable<double>(" time_start");
                StopTimeNanoSec = new DetectorVariable<double>("time_stop");
                BinIncrementNanoSec = new DetectorVariable<double>("time_increment");
                CorrelationTimeWindowNanoSec =
                    new DetectorVariable<double>("cc_window_incr");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnableTimeOfFlight);
                AddBoolean(EnableCrossCorrelation);
                AddBoolean(EnableAutoCorrelation);
                AddSingle(CellOfStartDetector_BlankForTOF);
                AddSingle(StartTimeNanoSec);
                AddSingle(StopTimeNanoSec);
                AddSingle(BinIncrementNanoSec);
                AddSingle(CorrelationTimeWindowNanoSec);
            }

            protected override string GetSectionName()
            {
                return "Correlations";
            }

            public Correlations() : base(11)
            {
            }

            public Correlations(DetectorVariableBase<double> start,
                DetectorVariableBase<double> stop, DetectorVariableBase<bool> auto,
                DetectorVariableBase<double> bin, DetectorVariableBase<int> cell,
                DetectorVariableBase<bool> cross, DetectorVariableBase<bool> timeOfFlight,
                DetectorVariableBase<double> timeWindow) : this()
            {
                StartTimeNanoSec.SetValueAndState(start);
                StopTimeNanoSec.SetValueAndState(stop);
                EnableAutoCorrelation.SetValueAndState(auto);
                CellOfStartDetector_BlankForTOF.SetValueAndState(cell);
            }
        }

        public class TimeResolution : MPPostSection
        {
            public DetectorVariable<bool> EnableTimeBroadening;
            public DetectorVariable<double> OrganicLiquid_FWHM;
            public DetectorVariable<double> OrganicPlastic_FWHM;
            public DetectorVariable<double> NaI_FWHM;
            public DetectorVariable<double> CaF2_FWHM;
            public DetectorVariable<double> LaBr3_FWHM;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnableTimeBroadening = new DetectorVariable<bool>("tme_resolution_on");
                OrganicLiquid_FWHM = new DetectorVariable<double>("organic_liq_tme");
                OrganicPlastic_FWHM = new DetectorVariable<double>("organic_pl_tme");
                NaI_FWHM = new DetectorVariable<double>("nai_tme");
                CaF2_FWHM = new DetectorVariable<double>("caf2_tme");
                LaBr3_FWHM = new DetectorVariable<double>("labr3_tme");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnableTimeBroadening);
                AddSingle(OrganicLiquid_FWHM);
                AddSingle(OrganicPlastic_FWHM);
                AddSingle(NaI_FWHM);
                AddSingle(CaF2_FWHM);
                AddSingle(LaBr3_FWHM);
            }

            protected override string GetSectionName()
            {
                return "Time Resolution";
            }

            public TimeResolution() : base(10)
            {
            }

            public TimeResolution(DetectorVariableBase<double> organicPlasticFWHM,
                DetectorVariableBase<double> organicLiquidFWHM, DetectorVariableBase<double> caf2FWHM,
                DetectorVariableBase<double> labr3FWHM, DetectorVariableBase<double> naiFWHM,
                DetectorVariableBase<bool> enableTimeBroad) : this()
            {
                OrganicPlastic_FWHM.SetValueAndState(organicPlasticFWHM);
                OrganicLiquid_FWHM.SetValueAndState(organicLiquidFWHM);
                NaI_FWHM.SetValueAndState(naiFWHM);
                CaF2_FWHM.SetValueAndState(caf2FWHM);
                LaBr3_FWHM.SetValueAndState(labr3FWHM);
                EnableTimeBroadening.SetValueAndState(enableTimeBroad);
            }
        }

        public class LightResolution : MPPostSection
        {
            public DetectorVariable<bool> EnableLightResolution;

            public DetectorVariable<GaussianBroadening>
                OrganicLiquidPhoton;

            public DetectorVariable<GaussianBroadening>
                OrganicLiquidNeutron;

            public DetectorVariable<GaussianBroadening>
                OrganicPlasticPhoton;

            public DetectorVariable<GaussianBroadening>
                OrganicPlasticNeutron;

            public DetectorVariable<GaussianBroadening> NaI;
            public DetectorVariable<GaussianBroadening> CaF2;

            public DetectorVariable<GaussianBroadening>
                LaBr3SubTenthMeVee;

            public DetectorVariable<GaussianBroadening>
                LaBr3SupTenthMeVee;

            public struct GaussianBroadening
            {
                //A*LO+B*Sqrt(LO)+C
                public double P0;
                public double P1;
                public double Exponent;
                public bool DetectorVariableIsSet;

                public GaussianBroadening(double p0, double p1, double exp, bool detectorVariableIsSet) : this()
                {
                    P0 = p0;
                    P1 = p1;
                    Exponent = exp;
                    DetectorVariableIsSet = detectorVariableIsSet;
                }

                public override string ToString()
                {
                    return P0 + SEP.ToString() + P1 + SEP.ToString() + Exponent;
                }
            }

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnableLightResolution = new DetectorVariable<bool>("light_resolution_on");
                OrganicLiquidPhoton = new DetectorVariable<GaussianBroadening>("organic_liq_p_lgt");
                OrganicLiquidNeutron = new DetectorVariable<GaussianBroadening>("organic_liq_n_lgt");
                OrganicPlasticPhoton = new DetectorVariable<GaussianBroadening>("organic_pl_p_lgt");
                OrganicPlasticNeutron = new DetectorVariable<GaussianBroadening>("organic_pl_n_lgt");
                NaI = new DetectorVariable<GaussianBroadening>("nai_lgt");
                CaF2 = new DetectorVariable<GaussianBroadening>("caf2_lgt");
                LaBr3SubTenthMeVee = new DetectorVariable<GaussianBroadening>("labr3_low_lgt");
                LaBr3SupTenthMeVee = new DetectorVariable<GaussianBroadening>("labr3_high_lgt");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnableLightResolution);
                AddSingle(OrganicLiquidNeutron);
                AddSingle(OrganicLiquidPhoton);
                AddSingle(OrganicPlasticNeutron);
                AddSingle(OrganicPlasticPhoton);
                AddSingle(NaI);
                AddSingle(CaF2);
                AddSingle(LaBr3SubTenthMeVee);
                AddSingle(LaBr3SupTenthMeVee);
            }

            protected override string GetSectionName()
            {
                return "Light Resolution";
            }

            public LightResolution() : base(9)
            {
            }

            public LightResolution(DetectorVariableBase<GaussianBroadening> orgLiqPhoton,
                DetectorVariableBase<GaussianBroadening> orgLiqNeutron, DetectorVariableBase<GaussianBroadening> nai,
                DetectorVariableBase<GaussianBroadening> caf2, DetectorVariableBase<bool> enableLightRes,
                DetectorVariableBase<GaussianBroadening> labr3Below,
                DetectorVariableBase<GaussianBroadening> labr3Above,
                DetectorVariableBase<GaussianBroadening> orgPlasticNeutron,
                DetectorVariableBase<GaussianBroadening> orgPlasticPhoton) : this()
            {
                EnableLightResolution.SetValueAndState(enableLightRes);
                OrganicLiquidNeutron.SetValueAndState(orgLiqNeutron);
                OrganicLiquidPhoton.SetValueAndState(orgLiqPhoton);
                OrganicPlasticNeutron.SetValueAndState(orgPlasticNeutron);
                OrganicPlasticPhoton.SetValueAndState(orgPlasticPhoton);
                NaI.SetValueAndState(nai);
                CaF2.SetValueAndState(caf2);
                LaBr3SubTenthMeVee.SetValueAndState(labr3Below);
                LaBr3SupTenthMeVee.SetValueAndState(labr3Above);
            }
        }

        public class OrganicScintillator : MPPostSection
        {
            public DetectorVariable<int> CalibrationRegions;

            public DetectorVariable<PoliMiOrganicNeutronEnergyCal>
                NeutronRegionType;

            public DetectorVariable<List<List<double>>>
                NeutronCalibration;

            public DetectorVariable<List<double>>
                PhotonCalibrationLinear;

            public DetectorVariable<double>
                CarbonLightConstant;

            public DetectorVariable<List<double>>
                DeuteriumCalibrationFourthPoly;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                CalibrationRegions = new DetectorVariable<int>("calibration_regions");
                NeutronRegionType =
                    new DetectorVariable<PoliMiOrganicNeutronEnergyCal>("region_type");
                NeutronCalibration =
                    new DetectorVariable<List<List<double>>>(
                        "neutron_calibration");
                PhotonCalibrationLinear =
                    new DetectorVariable<List<double>>("photon_calibration");
                CarbonLightConstant = new DetectorVariable<double>("carbon_light_constant");
                DeuteriumCalibrationFourthPoly =
                    new DetectorVariable<List<double>>("deuterium_calibration");
            }

            protected override void GetSectionText()
            {
                AddSingle(CalibrationRegions);
                AddEnum(NeutronRegionType);
                AddGroupedList(NeutronCalibration, " ", " &");
                AddList(PhotonCalibrationLinear);
                AddSingle(CarbonLightConstant);
                AddList(DeuteriumCalibrationFourthPoly);
            }

            protected override string GetSectionName()
            {
                return "Organic Scintillator";
            }

            public OrganicScintillator() : base(6)
            {
            }
        }

        public class DeadTimeNanoSeconds : MPPostSection
        {
            public DetectorVariable<double> OrganicLiquid;
            public DetectorVariable<double> OrganicPlastic;
            public DetectorVariable<double> NaI;
            public DetectorVariable<double> CaF2;
            public DetectorVariable<double> LaBr3;
            public DetectorVariable<int> HistogramStartMeVee;
            public DetectorVariable<int> HistogramEndMeVee;
            public DetectorVariable<double> BinStepMeVee;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                OrganicLiquid = new DetectorVariable<double>("organic_liq_dt");
                OrganicPlastic = new DetectorVariable<double>("organic_pl_dt");
                NaI = new DetectorVariable<double>("nai_dt");
                CaF2 = new DetectorVariable<double>("caf2_dt");
                LaBr3 = new DetectorVariable<double>("labr3_dt");

                HistogramStartMeVee = new DetectorVariable<int>("histogram_start");
                HistogramEndMeVee = new DetectorVariable<int>("histogram_stop");
                BinStepMeVee = new DetectorVariable<double>("bin_step");
            }

            protected override void GetSectionText()
            {
                AddSingle(OrganicLiquid);
                AddSingle(OrganicPlastic);
                AddSingle(NaI);
                AddSingle(CaF2);
                AddSingle(LaBr3);
                AddSingle(HistogramStartMeVee);
                AddSingle(HistogramEndMeVee);
                AddSingle(BinStepMeVee);
            }

            protected override string GetSectionName()
            {
                return "Dead Time ns";
            }

            public DeadTimeNanoSeconds() : base(5)
            {
            }

            public DeadTimeNanoSeconds(DetectorVariableBase<double> caf2,
                DetectorVariableBase<double> histoBin, DetectorVariableBase<int> histoEnd,
                DetectorVariableBase<int> histoStart, DetectorVariableBase<double> labr3,
                DetectorVariableBase<double> nai, DetectorVariableBase<double> orgLiquid,
                DetectorVariableBase<double> orgPlastic) : this()
            {
                CaF2.SetValueAndState(caf2);
                BinStepMeVee.SetValueAndState(histoBin);
                HistogramStartMeVee.SetValueAndState(histoStart);
                HistogramEndMeVee.SetValueAndState(histoEnd);
                LaBr3.SetValueAndState(labr3);
                NaI.SetValueAndState(nai);
                OrganicLiquid.SetValueAndState(orgLiquid);
                OrganicPlastic.SetValueAndState(orgPlastic);
            }
        }

        public class PulseGenerationTimeNanoSeconds : MPPostSection
        {
            public DetectorVariable<double> OrganicLiquid;
            public DetectorVariable<double> OrganicPlastic;
            public DetectorVariable<double> NaI;
            public DetectorVariable<double> CaF2;
            public DetectorVariable<double> LaBr3;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                OrganicLiquid = new DetectorVariable<double>("organic_liq_pgt");
                OrganicPlastic = new DetectorVariable<double>("organic_pl_pgt");
                NaI = new DetectorVariable<double>("nai_pgt");
                CaF2 = new DetectorVariable<double>("caf2_pgt");
                LaBr3 = new DetectorVariable<double>("labr3_pgt");
            }

            protected override void GetSectionText()
            {
                AddSingle(OrganicLiquid);
                AddSingle(OrganicPlastic);
                AddSingle(NaI);
                AddSingle(CaF2);
                AddSingle(LaBr3);
            }

            protected override string GetSectionName()
            {
                return "Pulse Generation Time ns";
            }

            public PulseGenerationTimeNanoSeconds() : base(8)
            {
            }

            public PulseGenerationTimeNanoSeconds(DetectorVariableBase<double> caf2,
                DetectorVariableBase<double> labr3, DetectorVariableBase<double> nai,
                DetectorVariableBase<double> organicLiquid,
                DetectorVariableBase<double> organicPlastic) : this()
            {
                CaF2.SetValueAndState(caf2);
                LaBr3.SetValueAndState(labr3);
                NaI.SetValueAndState(nai);
                OrganicPlastic.SetValueAndState(organicPlastic);
                OrganicLiquid.SetValueAndState(organicLiquid);
            }
        }

        public class DetectorPulseHeight : MPPostSection
        {
            public DetectorVariable<bool> EnablePulseHeight;

            public DetectorVariable<bool>
                SumAllParticleEnergyToLight;

            public DetectorVariable<bool>
                EliminateCrosstalkParticles;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                EnablePulseHeight = new DetectorVariable<bool>("pulse_height_on");
                SumAllParticleEnergyToLight = new DetectorVariable<bool>("sum_then_light");
                EliminateCrosstalkParticles = new DetectorVariable<bool>("cross_talk_sub_on");
            }

            protected override void GetSectionText()
            {
                AddBoolean(EnablePulseHeight);
                AddBoolean(SumAllParticleEnergyToLight);
                AddBoolean(EliminateCrosstalkParticles);
            }

            protected override string GetSectionName()
            {
                return "Detector Pulse Height";
            }

            public DetectorPulseHeight() : base(4)
            {
            }

            public DetectorPulseHeight(DetectorVariableBase<bool> crossTalk,
                DetectorVariableBase<bool> enablePulseHeight, DetectorVariableBase<bool> sumEnergyToLight) : this()
            {
                EliminateCrosstalkParticles.SetValueAndState(crossTalk);
                EnablePulseHeight.SetValueAndState(enablePulseHeight);
                SumAllParticleEnergyToLight.SetValueAndState(sumEnergyToLight);
            }
        }

        public class DetectorInformation : MPPostSection
        {
            public DetectorVariable<bool> AnalyzeByTimeNotHistory;
            public DetectorVariable<int> McnpNps;
            public DetectorVariable<List<MPPostDetectorTypes>> DetectorTypes;
            public DetectorVariable<List<double>> LowerThresholdMeVee;
            public DetectorVariable<List<double>> UpperThresholdMeVee;
            public DetectorVariable<List<List<int>>> DetectorCells;

            private const string START_GROUP = " (";
            private const string END_GROUP = ") ";

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                AnalyzeByTimeNotHistory = new DetectorVariable<bool>("time_dependent");
                McnpNps = new DetectorVariable<int>("NPS");
                DetectorTypes =
                    new DetectorVariable<List<MPPostDetectorTypes>>("detector_type");
                LowerThresholdMeVee = new DetectorVariable<List<double>>("threshold");
                UpperThresholdMeVee = new DetectorVariable<List<double>>("upper_threshold");
                DetectorCells = new DetectorVariable<List<List<int>>>("detector_cell_numbers");
            }

            protected override void GetSectionText()
            {
                AddBoolean(AnalyzeByTimeNotHistory);
                AddSingle(McnpNps);
                AddListEnum(DetectorTypes);
                AddList(LowerThresholdMeVee);
                AddList(UpperThresholdMeVee);
                AddGroupedList(DetectorCells, START_GROUP, END_GROUP);
            }

            protected override string GetSectionName()
            {
                return "Detector Information";
            }

            public DetectorInformation() : base(3)
            {
            }

            public DetectorInformation(DetectorVariableBase<bool> analyzeByTimeNotHistory,
                DetectorVariableBase<string> detectorCells,
                DetectorVariableBase<List<MPPostDetectorTypes>> detectorTypes,
                DetectorVariableBase<List<double>> lldMeV, DetectorVariableBase<List<double>> uldMeV,
                DetectorVariableBase<int> mcnpNPS) : this()
            {
                AnalyzeByTimeNotHistory.SetValueAndState(analyzeByTimeNotHistory);
                LowerThresholdMeVee.SetValueAndState(lldMeV);
                UpperThresholdMeVee.SetValueAndState(uldMeV);
                McnpNps.SetValueAndState(mcnpNPS);
                DetectorTypes.SetValueAndState(detectorTypes);
                DetectorCells.SetValueAndState(ConvertCellsToNestedList(detectorCells));
            }

            private DetectorVariableBase<List<List<int>>> ConvertCellsToNestedList(
                DetectorVariableBase<string> detectorCells)
            {
                throw new NotImplementedException();
            }

            public static DetectorVariable<string> ToGroupedList(DetectorVariable<List<List<int>>> detectorCells)
            {
                throw new NotImplementedException();
            }
        }

        public class Memory : MPPostSection
        {
            public DetectorVariable<int> FileSizeMB;
            public DetectorVariable<int> OverstepBuffer;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                FileSizeMB = new DetectorVariable<int>("division_size");
                OverstepBuffer = new DetectorVariable<int>("cushion");
            }

            protected override void GetSectionText()
            {
                AddSingle(FileSizeMB);
                AddSingle(OverstepBuffer);
            }

            protected override string GetSectionName()
            {
                return "Memory";
            }

            public Memory() : base(2)
            {
            }

            public Memory(DetectorVariableBase<int> fileSizeMB, DetectorVariableBase<int> overStepBuffer) : this()
            {
                FileSizeMB.SetValueAndState(fileSizeMB);
                OverstepBuffer.SetValueAndState(overStepBuffer);
            }
        }

        public class FileIO : MPPostSection
        {
            public DetectorVariable<string> DetectorFileName;
            public DetectorVariable<string> OutputFileName;
            public DetectorVariable<bool> LabelOutput;

            public DetectorVariable<bool>
                SeparateDetectorResponse;

            public DetectorVariable<bool> PrintListModeFile;
            public DetectorVariable<bool> PrintSummaryTable;
            public DetectorVariable<bool> CollisionHistory;
            public DetectorVariable<bool> OverWriteFiles;
            public DetectorVariable<bool> CommaDelimited;

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                throw new NotImplementedException();
            }

            public override void Refresh()
            {
                DetectorFileName = new DetectorVariable<string>("polimi_det_in");
                OutputFileName = new DetectorVariable<string>("output_file");
                LabelOutput = new DetectorVariable<bool>("label_output");
                SeparateDetectorResponse = new DetectorVariable<bool>("seperate_det_response");
                PrintListModeFile = new DetectorVariable<bool>("list_of_pulses");
                PrintSummaryTable = new DetectorVariable<bool>("event_inventory_on");
                CollisionHistory = new DetectorVariable<bool>("collision_history");
                OverWriteFiles = new DetectorVariable<bool>("overwrite_files");
                CommaDelimited = new DetectorVariable<bool>("comma_delimited");
            }

            protected override void GetSectionText()
            {
                AddSingle(DetectorFileName);
                AddSingle(OutputFileName);
                AddBoolean(LabelOutput);
                AddBoolean(SeparateDetectorResponse);
                AddBoolean(PrintListModeFile);
                AddBoolean(PrintSummaryTable);
                AddBoolean(CollisionHistory);
                AddBoolean(OverWriteFiles);
                AddBoolean(CommaDelimited);
            }

            protected override string GetSectionName()
            {
                return "File I/O";
            }

            public FileIO() : base(1)
            {
            }

            public FileIO(DetectorVariableBase<bool> collisionHistory,
                DetectorVariableBase<bool> commaDel, DetectorVariableBase<string> detectorFile,
                DetectorVariableBase<bool> labelOutput, DetectorVariableBase<string> outputFiles,
                DetectorVariableBase<bool> overwriteFiles, DetectorVariableBase<bool> printListMode,
                DetectorVariableBase<bool> printSummaryTable, DetectorVariableBase<bool> separateDRFs) : this()
            {
                CollisionHistory.SetValueAndState(collisionHistory);
                CommaDelimited.SetValueAndState(commaDel);
                DetectorFileName.SetValueAndState(detectorFile);
                LabelOutput.SetValueAndState(labelOutput);
                OutputFileName.SetValueAndState(outputFiles);
                OverWriteFiles.SetValueAndState(overwriteFiles);
                PrintListModeFile.SetValueAndState(printListMode);
                PrintSummaryTable.SetValueAndState(printSummaryTable);
                SeparateDetectorResponse.SetValueAndState(separateDRFs);
            }
        }

        public class GeneralInfo : MPPostSection
        {
            public DetectorVariable<string> Title;
            public DetectorVariable<string> Username;

            public override void Refresh()
            {
                Title = new DetectorVariable<string>("title");
                Username = new DetectorVariable<string>("username");
            }

            protected override void GetSectionText()
            {
                AddSingle(Title);
                AddSingle(Username);
            }

            protected override string GetSectionName()
            {
                return "General Info";
            }

            protected override void parseFromLine(string curLine, StreamReader sr)
            {
                if (Title.FoundVariableName(curLine))
                {
                    Readers.ReadSingle(ref Title, curLine);
                }

                if (Username.FoundVariableName(curLine))
                {
                    Readers.ReadSingle(ref Username, curLine);
                }
            }

            public GeneralInfo() : base(0)
            {
            }

            public GeneralInfo(DetectorVariableBase<string> title, DetectorVariableBase<string> userName) : this()
            {
                Title.SetValueAndState(title);
                Username.SetValueAndState(userName);
            }
        }


        public abstract class MPPostSection
        {
            public readonly int OrderIO;
            protected const char SEP = ' ';
            protected const string YES = "yes";
            protected const string NO = "no";
            protected List<string> sectionText;

            internal const string COMMENT_SECTION = COMMENT + "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            internal const string COMMENT = "# ";
            internal const string END_SECTION = COMMENT + "END ";

            protected readonly string endOfSection;

            protected MPPostSection(int OrderInFile)
            {
                OrderIO = OrderInFile;
                Refresh();
                endOfSection = END_SECTION + GetSectionName();
            }

            public void ReadSection(StreamReader sr)
            {
                Refresh();
                while (true)
                {
                    string curLine = sr.ReadLine();
                    if (GetEndOfSection(curLine))
                    {
                        break;
                    }
                    else if (notCommentLine(curLine))
                    {
                        parseFromLine(curLine, sr);
                    }
                }
            }

            protected abstract void parseFromLine(string curLine, StreamReader sr);

            private bool notCommentLine(string line)
            {
                return !line.Contains(COMMENT);
            }

            private bool GetEndOfSection(string line)
            {
                return string.Equals(line, endOfSection);
            }

            public List<string> GetTextForSection()
            {
                InitializeSection();
                GetSectionText();
                return sectionText;
            }

            public abstract void Refresh();
            protected abstract void GetSectionText();

            protected string GetGroupedList<T>(DetectorVariable<List<List<T>>> variable, string startGroup = "",
                string endGroup = "")
            {
                string groupList = string.Empty;

                return groupList;
            }

            protected void AddGroupedList<T>(DetectorVariable<List<List<T>>> variable, string startGroup = "",
                string endGroup = "")
            {
                if (variable.VarIsSet)
                {
                    if (variable.Value.Count == 1)
                    {
                        AddSingleCalibrationRegion(variable);
                    }
                    else
                    {
                        AddMultipleCalibrationRegion(variable, startGroup, endGroup);
                    }
                }
                else
                {
                    AddUnused(variable);
                }
            }

            private void AddMultipleCalibrationRegion<T>(DetectorVariable<List<List<T>>> variable, string startGroup,
                string endGroup)
            {
                sectionText.Add(variable.VarName);
                foreach (var group in variable.Value)
                {
                    string line = startGroup;
                    foreach (var c in group)
                    {
                        line += SEP.ToString() + c;
                    }

                    sectionText.Add(line + SEP + endGroup);
                }
            }

            private void AddSingleCalibrationRegion<T>(DetectorVariable<List<List<T>>> variable)
            {
                string cal = variable.VarName;
                foreach (var c in variable.Value.First())
                {
                    cal += SEP.ToString() + c;
                }

                sectionText.Add(cal);
            }

            private static string YesOrNo(bool yesOrNo)
            {
                return yesOrNo ? YES : NO;
            }

            protected void AddList<T>(DetectorVariable<List<T>> variable)
            {
                if (variable.VarIsSet)
                {
                    string varString = variable.VarName;
                    foreach (var v in variable.Value)
                    {
                        varString += SEP + v.ToString();
                    }

                    sectionText.Add(varString);
                }
                else
                {
                    AddUnused(variable);
                }
            }

            protected void InitializeSection()
            {
                sectionText = new List<string>();
                sectionText.Add(COMMENT_SECTION);
                sectionText.Add(COMMENT + GetSectionName());
                sectionText.Add(COMMENT_SECTION);
            }

            protected abstract string GetSectionName();

            protected void AddSingle<T>(DetectorVariable<T> variable)
            {
                if (variable.VarIsSet)
                {
                    sectionText.Add(GetVariableString(variable.VarName, variable.Value.ToString()));
                }
                else
                {
                    AddUnused(variable);
                }
            }

            protected void AddEnum<T>(DetectorVariable<T> variable) where T : Enum
            {
                if (variable.VarIsSet)
                {
                    object value = Convert.ChangeType(variable.Value, variable.Value.GetTypeCode());
                    sectionText.Add(GetVariableString(variable.VarName, value.ToString()));
                }
            }

            protected void AddListEnum<T>(DetectorVariable<List<T>> variable) where T : Enum
            {
                if (variable.VarIsSet)
                {
                    string enumString = "";
                    foreach (var v in variable.Value)
                    {
                        object value = Convert.ChangeType(v, v.GetTypeCode());
                        enumString += SEP.ToString() + value;
                    }

                    sectionText.Add(GetVariableString(variable.VarName, enumString));
                }
                else
                {
                    AddUnused(variable);
                }
            }

            protected void AddBoolean(DetectorVariable<bool> variable)
            {
                if (variable.VarIsSet)
                {
                    sectionText.Add(GetVariableString(variable.VarName, YesOrNo(variable.Value)));
                }
                else
                {
                    AddUnused(variable);
                }
            }

            private void AddUnused<T>(DetectorVariable<T> variable)
            {
                if (writeUnused)
                {
                    sectionText.Add(COMMENT + variable.VarName);
                }
            }

            protected string GetVariableString(string varName, string varValue)
            {
                return varName + SEP + varValue;
            }

            protected static class Readers
            {
                public static void ReadBoolean(ref DetectorVariable<bool> variable, string line)
                {
                    variable.SetValue(BoolFromYesOrNo(line));
                }

                public static void ReadListEnum<T>(ref DetectorVariable<List<T>> variable, string line) where T : Enum
                {
                    var split = line.Split(SEP);
                    List<T> enums = new List<T>();
                    foreach (var s in split)
                    {
                        enums.Add(ParseEnum<T>(s));
                    }

                    variable.SetValue(enums);
                }

                private static T ParseEnum<T>(string line) where T : Enum
                {
                    return (T)Enum.Parse(typeof(T), line);
                }

                public static void ReadEnum<T>(ref DetectorVariable<T> variable, string line) where T : Enum
                {
                    variable.SetValue(ParseEnum<T>(line));
                }

                public static bool BoolFromYesOrNo(string line)
                {
                    line = line.Trim().ToLower();
                    if (string.Equals(line, YES.ToLower()))
                    {
                        return true;
                    }
                    else if (string.Equals(line, NO.ToLower()))
                    {
                        return false;
                    }
                    else
                    {
                        throw new Exception("Line: " + line + " .Must either be " + YES + " or  " + NO);
                    }
                }

                public static void ReadSingle<T>(ref DetectorVariable<T> variable, string line)
                {
                    variable.SetValue(ParseFromLine<T>(line));
                }

                private static T ParseFromLine<T>(string line)
                {
                    return (T)Convert.ChangeType(line, typeof(T));
                }

                public static void ReadList<T>(ref DetectorVariable<List<T>> variable, string line)
                {
                    List<T> varList = new List<T>();
                    List<string> split = SplitLine(line);
                    foreach (var s in split)
                    {
                        varList.Add(ParseFromLine<T>(s));
                    }

                    variable.SetValue(varList);
                }

                private static List<string> SplitLine(string line, bool removeName = true)
                {
                    string[] split = line.Split(SEP);
                    int startIndex = (removeName ? 1 : 0);
                    List<string> listLine = new List<string>();
                    for (int i = startIndex; i < split.Length; i++)
                    {
                        listLine.Add(split[i]);
                    }

                    return listLine;
                }

                public static void ReadMultipleCalibrationRegion<T>(ref DetectorVariable<List<List<T>>> variable,
                    List<string> lines)
                {
                }

                public static void ReadSingleCalibrationRegion<T>(ref DetectorVariable<List<List<T>>> variable,
                    List<string> lines)
                {
                }
            }
        }

        // Need this to Not have to set name of variable in more than one place
        public struct DetectorVariableBase<T>
        {
            public bool VarIsSet;
            public T Value;

            public DetectorVariableBase(bool isSet, T value)
            {
                VarIsSet = isSet;
                Value = value;
            }
        }

        public struct DetectorVariable<T>
        {
            public readonly string VarName;

            private DetectorVariableBase<T> Variable;
            public bool VarIsSet => Variable.VarIsSet;
            public T Value => Variable.Value;

            public DetectorVariable(string varName)
            {
                VarName = varName;
                Variable.Value = default;
                Variable.VarIsSet = false;
            }

            public void SetValue(T newValue)
            {
                Variable.Value = newValue;
                Variable.VarIsSet = true;
            }

            public bool FoundVariableName(string line)
            {
                return line.Contains(VarName);
            }

            public void SetValueAndState(DetectorVariableBase<T> variableBase)
            {
                Variable = variableBase;
            }

            public void SetValueAndState(bool state, T value)
            {
                SetValueAndState(new DetectorVariableBase<T>(state, value));
            }
        }

        public static DetectorVariableBase<int> ConvertDoubleToInt(DetectorVariableBase<double> detectorDouble)
        {
            return new DetectorVariableBase<int>(detectorDouble.VarIsSet, (int)detectorDouble.Value);
        }

        public static DetectorVariable<TOut> ToListOfLists<TIn, TOut>(
            DetectorVariable<List<List<TIn>>> specsDetectorCells)
        {
            throw new NotImplementedException();
        }
    }
}
