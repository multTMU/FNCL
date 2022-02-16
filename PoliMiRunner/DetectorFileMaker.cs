using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using GlobalHelpers;
using GlobalHelpersDefaults;
using PoliMiRunner;

namespace Runner
{
    public enum MPPostDefaultDetectors
    {
        Defaults,
        FNCL,
        NGam12,
        He3FluxMonitor,
        OranicFluxMonitor
    }

    public static class DetectorFileMaker
    {
        private static MPPostSpecification detector;

        public static MPPostSpecification GetDetectorDefaults(MPPostDefaultDetectors defaultDetector)
        {
            switch (defaultDetector)
            {
                case MPPostDefaultDetectors.Defaults:
                    return GetDefaultsOnly();
                case MPPostDefaultDetectors.FNCL:
                    return GetFnclDetectorDefault();
                case MPPostDefaultDetectors.NGam12:
                    return GetNGam12DetectorDefault();
                case MPPostDefaultDetectors.He3FluxMonitor:
                    return GetHe3DetectorDefault();
                case MPPostDefaultDetectors.OranicFluxMonitor:
                    return GetNgen350Monitors();
                default:
                    throw new ArgumentOutOfRangeException(nameof(defaultDetector), defaultDetector, null);
            }
        }

        private static MPPostSpecification GetDefaultsOnly()
        {
            detector = new MPPostSpecification();
            SetGeneralDefaults();
            return detector;
        }

        public static MPPostSpecification GetHe3DetectorDefault()
        {
            detector = new MPPostSpecification();
            SetDefaultsHe3();
            return detector;
        }

        public static MPPostSpecification GetFnclDetectorDefault()
        {
            detector = new MPPostSpecification();
            SetDefaultsFncl();
            return detector;
        }

        public static MPPostSpecification GetNGam12DetectorDefault()
        {
            detector = new MPPostSpecification();
            SetDefaultsNGamma();
            return detector;
        }

        private static MPPostDetectorTypes GetHe3Active()
        {
            return MPPostDetectorTypes.He3;
        }

        private static List<MPPostDetectorTypes> GetNGen350Active()
        {
            List<MPPostDetectorTypes> detectorTypes = new List<MPPostDetectorTypes>();
            for (int i = 0; i < FnclHelpers.NUMBER_NGEN350_DETECTORS; i++)
            {
                detectorTypes.Add(FnclHelpers.NGen350DetectorMaterial);
            }

            return detectorTypes;
        }

        private static MPPostDetectorTypes GetHe3NotActive()
        {
            return MPPostDetectorTypes.NonActiveVolume;
        }

        private static List<MPPostDetectorTypes> GetFnclDetectorsActive()
        {
            return GetFnclDetectors(MPPostDetectorTypes.LiquidOrganicScintillator);
        }

        private static List<MPPostDetectorTypes> GetFnclDetectors(MPPostDetectorTypes detectorType)
        {
            List<MPPostDetectorTypes> detectors = new List<MPPostDetectorTypes>();
            for (int i = 0; i < FnclHelpers.NUMBER_DETECTORS; i++)
            {
                detectors.Add(detectorType);
            }

            return detectors;
        }

        internal static MPPostSpecification GetNgen350Monitors()
        {
            detector = new MPPostSpecification();
            SetDefaultsNGenMonitors();
            return detector;
        }

        private static void SetDefaultsNGenMonitors()
        {
            SetGeneralDefaults();
            detector.fileIO.OutputFileName.SetValue(PoliMiMPPostInputHelper.GetNGen350DetectorputPrefix());
            detector.detectorInformation.DetectorTypes.SetValue(GetNgen350Detectors());
        }

        private static List<MPPostDetectorTypes> GetNgen350Detectors()
        {
            var detectorTemp = new List<MPPostDetectorTypes>();
            detectorTemp.AddRange(GetFnclDetectorsNotActive());
            detectorTemp.AddRange(GetNGen350Active());
            return detectorTemp;
        }

        private static List<MPPostDetectorTypes> GetFnclDetectorsNotActive()
        {
            return GetFnclDetectors(MPPostDetectorTypes.NonActiveVolume);
        }

        private static void SetDefaultsHe3()
        {
            SetGeneralDefaults();
            detector.fileIO.OutputFileName.SetValue(PoliMiMPPostInputHelper.GetHe3DetectorOutputPrefix());
            detector.detectorInformation.DetectorTypes.SetValue(GetHe3Detectors());
            detector.he3Module.EnableHe3.SetValue(false); // true is incompatible with history based pulses
            detector.pulseHeightCorrelation.EnablePulseHeightCorrelation.SetValue(false);
            detector.detectorPulseHeight.EnablePulseHeight.SetValue(false);
        }

        private static List<MPPostDetectorTypes> GetHe3Detectors()
        {
            var detectorTemp = new List<MPPostDetectorTypes>();
            detectorTemp.AddRange(GetFnclDetectorsNotActive());
            detectorTemp.Add(GetHe3Active());
            return detectorTemp;
        }

        private static List<MPPostDetectorTypes> GetFnclDetectors()
        {
            var detectorTemp = new List<MPPostDetectorTypes>();
            detectorTemp.AddRange(GetFnclDetectorsActive());
            detectorTemp.Add(GetHe3NotActive());
            return detectorTemp;
        }

        private static void SetDefaultsNGamma()
        {
            SetGeneralDefaults();
            detector.fileIO.OutputFileName.SetValue(PoliMiMPPostInputHelper.GetNGamOutputPrefix());
            detector.detectorInformation.DetectorTypes.SetValue(new List<MPPostDetectorTypes>()
            {
                MPPostDetectorTypes.NaI
            });

            detector.detectorInformation.LowerThresholdMeVee.SetValue(MakeList(0.07));
            detector.detectorInformation.UpperThresholdMeVee.SetValue(MakeList(20.0));

            detector.deadTimeNanoSeconds.NaI.SetValue(0);
            detector.pulseGenerationTime.NaI.SetValue(10);
        }

        private static void SetDefaultsFncl()
        {
            SetGeneralDefaults();
            detector.fileIO.OutputFileName.SetValue(PoliMiMPPostInputHelper.GetFnclOutputPrefix());
            detector.detectorInformation.DetectorTypes.SetValue(GetFnclDetectors());
            detector.detectorInformation.LowerThresholdMeVee.SetValue(MakeList(0.07));
            detector.detectorInformation.UpperThresholdMeVee.SetValue(MakeList(20.0));
            detector.deadTimeNanoSeconds.OrganicLiquid.SetValue(0);
            detector.pulseGenerationTime.OrganicLiquid.SetValue(10);
        }

        private static List<T> MakeList<T>(T value)
        {
            return new List<T>() {value};
        }

        private static void SetGeneralDefaults()
        {
            detector.generalInfo.Username.SetValue(Environment.UserName);
            detector.fileIO.DetectorFileName.SetValue("dumn1");

            detector.detectorInformation.LowerThresholdMeVee.SetValue(MakeList(0.07));
            detector.detectorInformation.UpperThresholdMeVee.SetValue(MakeList(20.0));

            detector.detectorInformation.AnalyzeByTimeNotHistory.SetValue(false);

            detector.detectorPulseHeight.EliminateCrosstalkParticles.SetValue(false);
            detector.detectorPulseHeight.SumAllParticleEnergyToLight.SetValue(false);
            detector.detectorPulseHeight.EnablePulseHeight.SetValue(true);

            detector.deadTimeNanoSeconds.HistogramEndMeVee.SetValue(20);
            detector.deadTimeNanoSeconds.HistogramStartMeVee.SetValue(0);
            detector.deadTimeNanoSeconds.BinStepMeVee.SetValue(0.1);
            detector.pulseHeightCorrelation.EnablePulseHeightCorrelation.SetValue(true);

            detector.captureGatedDetector.EnableCaptureGating.SetValue(false);
            detector.captureEvents.PrintSortedEventFile.SetValue(true);

            detector.he3Module.EnableHe3.SetValue(false);

            detector.fileIO.PrintListModeFile.SetValue(true);
            detector.fileIO.CommaDelimited.SetValue(true);
            detector.fileIO.OverWriteFiles.SetValue(true);
            detector.fileIO.CollisionHistory.SetValue(false);
            detector.fileIO.LabelOutput.SetValue(true);
            detector.fileIO.SeparateDetectorResponse.SetValue(false);
            detector.fileIO.PrintSummaryTable.SetValue(false);

            detector.memory.FileSizeMB.SetValue(1000);
            detector.memory.OverstepBuffer.SetValue(200);

            detector.timeResolution.EnableTimeBroadening.SetValue(false);
            detector.lightResolution.EnableLightResolution.SetValue(false);

            detector.correlations.EnableAutoCorrelation.SetValue(false);
            detector.correlations.EnableCrossCorrelation.SetValue(false);
            detector.correlations.EnableTimeOfFlight.SetValue(false);

            // apparently you always need Organic liquid defined for MPPost even if all your detector are NaI
            detector.organicScintillator.PhotonCalibrationLinear.SetValue(new List<double>() {1, 0});
            detector.organicScintillator.NeutronCalibration.SetValue(MakeList(new List<double>()
            {
                0,
                50,
                0.03495,
                0.1424,
                -0.036
            }));
            detector.organicScintillator.CalibrationRegions.SetValue(1);
            detector.organicScintillator.NeutronRegionType.SetValue(PoliMiOrganicNeutronEnergyCal.Quadratic);
            detector.organicScintillator.CarbonLightConstant.SetValue(0.02);
            detector.organicScintillator.DeuteriumCalibrationFourthPoly.SetValue(new List<double>()
            {
                0,
                0,
                0.0131,
                0.2009,
                -0.0331
            });
        }
    }
}
