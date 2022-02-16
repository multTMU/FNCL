using System;
using System.Collections.Generic;
using System.IO;

namespace GlobalHelpersDefaults
{
    public class NoEnergyCalibration : DetectorEnergyCalibrationBase
    {
        public override DetectorType GetDetectorType()
        {
            return DetectorType.None;
        }

        protected override void MakeDefaultNoECal()
        {
            calibration.Clear();
        }

        protected override DetectorKey GetKeyFromDetectorIndex(int detectorIndex)
        {
            return new DetectorKey();
        }
    }

    // Stubs for now, that should be fleshed out, and derive from DetectorEnergyCalibrationBase, but this project is over
    public class He3FluxMonitorDetectorEnergyCalibration : FnclDetectorEnergyCalibration
    {
        public override DetectorType GetDetectorType()
        {
            return DetectorType.HeFluxMonitor;
        }
    }

    public class NGen350FluxMonitorsDetectorEnergyCalibration : FnclDetectorEnergyCalibration
    {
        public override DetectorType GetDetectorType()
        {
            return DetectorType.NGen350Monitors;
        }
    }

    public class NGamDetectorEnergyCalibration : FnclDetectorEnergyCalibration
    {
        public override DetectorType GetDetectorType()
        {
            return DetectorType.NGammaPrototype;
        }
    }

    public class FnclDetectorEnergyCalibration : DetectorEnergyCalibrationBase
    {
        public override DetectorType GetDetectorType()
        {
            return DetectorType.FastNeutronCollar;
        }

        protected override void MakeDefaultNoECal()
        {
            foreach (var detectorKey in FnclHelpers.GetDetectorKeys())
            {
                calibration.Add(detectorKey, new Channels());
            }

            //foreach (var p in FnclHelpers.ListOfPanels)
            //{
            //    foreach (var d in FnclHelpers.ListOfDetectors)
            //    {
            //        calibration.Add(new DetectorKey(p, d), new Channels());
            //    }
            //}
        }

        protected override DetectorKey GetKeyFromDetectorIndex(int detectorIndex)
        {
            return FNCLdetectorDictionary.GetKeyByIndex(detectorIndex);
        }
    }

    public abstract class DetectorEnergyCalibrationBase
    {
        protected Dictionary<DetectorKey, IEnergyCalibration> calibration;

        public abstract DetectorType GetDetectorType();

        protected DetectorEnergyCalibrationBase()
        {
            calibration = new Dictionary<DetectorKey, IEnergyCalibration>();
            MakeDefaultNoECal();
        }

        public void AddEnergyCalibration(DetectorKey key, IEnergyCalibration eCal)
        {
            if (calibration.ContainsKey(key))
            {
                calibration[key] = eCal;
            }
            else
            {
                calibration.Add(key, eCal);
            }
        }

        public void AddEnergyCalibration(int panel, int det, IEnergyCalibration eCal)
        {
            AddEnergyCalibration(new DetectorKey(panel, det), eCal);
        }

        protected abstract void MakeDefaultNoECal();

        public double GetEnergyKeVee(int panel, int detector, double pulse)
        {
            return GetEnergyKeVee(new DetectorKey(panel, detector), pulse);
        }

        private double GetEnergyKeVee(DetectorKey key, double pulse)
        {
            return calibration[key].GetPulseInKeVee(pulse);
        }

        public PoliMiOrganicNeutronEnergyCal GetCalibrationType(int panel, int detector)
        {
            return calibration[new DetectorKey(panel, detector)].GetPoliMiCalType();
        }

        public IEnergyCalibration GetEnergyCalibration(int panel, int detector)
        {
            return GetEnergyCalibration(new DetectorKey(panel, detector));
        }

        public IEnergyCalibration GetEnergyCalibration(DetectorKey key)
        {
            return calibration[key];
        }

        public double GetEnergyKeVee(int detectorIndex, double pulse)
        {
            return GetEnergyKeVee(GetKeyFromDetectorIndex(detectorIndex), pulse);
        }

        protected abstract DetectorKey GetKeyFromDetectorIndex(int detectorIndex);

        public Dictionary<DetectorKey, IEnergyCalibration> CloneDictionary()
        {
            Dictionary<DetectorKey, IEnergyCalibration> clone = new Dictionary<DetectorKey, IEnergyCalibration>();
            // dictionaries reference types
            foreach (var c in calibration)
            {
                clone.Add(c.Key, c.Value);
            }

            return clone;
        }
    }

    public static class DetectorEnergyCalibration
    {
        private static DetectorEnergyCalibrationBase energyCalibration;

        static DetectorEnergyCalibration()
        {
            energyCalibration = EnergyCalibrationHelper.GetEnergyCalibrationDefault();
        }

        public static void DetectorChagned(DetectorType detector)
        {
            energyCalibration = EnergyCalibrationHelper.GetEnergyCalibration(detector);
        }

        public static void SaveEnergyCalibration(string saveFile)
        {
            EnergyCalibrationHelper.WriteToFile(saveFile, energyCalibration);
        }

        public static void LoadEnergyCalibration(string loadFile)
        {
            energyCalibration = EnergyCalibrationHelper.LoadFromFile(loadFile);
        }

        public static void AddEnergyCalibration(DetectorKey key, IEnergyCalibration eCal)
        {
            energyCalibration.AddEnergyCalibration(key, eCal);
        }

        public static void AddEnergyCalibration(int panel, int det, IEnergyCalibration eCal)
        {
            energyCalibration.AddEnergyCalibration(panel, det, eCal);
        }

        public static double GetEnergyKeVee(int panel, int detector, double pulse)
        {
            return energyCalibration.GetEnergyKeVee(panel, detector, pulse);
        }

        public static PoliMiOrganicNeutronEnergyCal GetCalibrationType(int panel, int detector)
        {
            return energyCalibration.GetCalibrationType(panel, detector);
        }

        public static IEnergyCalibration GetEnergyCalibration(int panel, int detector)
        {
            return GetEnergyCalibration(new DetectorKey(panel, detector));
        }

        public static IEnergyCalibration GetEnergyCalibration(DetectorKey key)
        {
            return energyCalibration.GetEnergyCalibration(key);
        }

        public static double GetEnergyKeVee(int detectorIndex, double pulse)
        {
            return energyCalibration.GetEnergyKeVee(detectorIndex, pulse);
        }
    }

    public static class EnergyCalibrationHelper
    {
        public static DetectorEnergyCalibrationBase GetEnergyCalibrationDefault()
        {
            return new NoEnergyCalibration();
        }

        public static DetectorEnergyCalibrationBase GetEnergyCalibration(DetectorType detectorType)
        {
            DetectorEnergyCalibrationBase eCal;
            switch (detectorType)
            {
                case DetectorType.None:
                    eCal = new NoEnergyCalibration();
                    break;
                case DetectorType.FastNeutronCollar:
                    eCal = new FnclDetectorEnergyCalibration();
                    break;
                case DetectorType.NGammaPrototype:
                    // just a stub until we can write one
                    eCal = new NGamDetectorEnergyCalibration();
                    break;
                case DetectorType.HeFluxMonitor:
                    eCal = new He3FluxMonitorDetectorEnergyCalibration();
                    break;
                case DetectorType.NGen350Monitors:
                    eCal = new NGen350FluxMonitorsDetectorEnergyCalibration();
                    break;
                default:
                    eCal = new NoEnergyCalibration();
                    break;
            }

            // eCal.ResetCalibrations();

            return eCal;
        }

        public static IEnergyCalibration GetEnergyCalibration(PoliMiOrganicNeutronEnergyCal eCalType,
            List<double> eCalParams, bool convertToKeVee)
        {
            switch (eCalType)
            {
                case PoliMiOrganicNeutronEnergyCal.None:
                    return new Channels();
                case PoliMiOrganicNeutronEnergyCal.NotPoliMiLinear:
                    return new LinearEnergyCalibration(convertToKeVee, eCalParams);
                case PoliMiOrganicNeutronEnergyCal.Quadratic:
                    return new QuadraticEnergyCalibration(convertToKeVee, eCalParams);
                case PoliMiOrganicNeutronEnergyCal.Rational:
                    return new RationalEnergyCalibration(convertToKeVee, eCalParams);
                case PoliMiOrganicNeutronEnergyCal.Transcendental:
                    return new TranscendentalEnergyCalibration(convertToKeVee, eCalParams);
                default:
                    return new Channels();
            }
        }

        public static void WriteToFile(string saveFile, DetectorEnergyCalibrationBase eCal)
        {
            using (StreamWriter sw = new StreamWriter(saveFile))
            {
                sw.WriteLine(eCal.GetDetectorType().ToString());
                foreach (KeyValuePair<DetectorKey, IEnergyCalibration> p in eCal.CloneDictionary())
                {
                    sw.WriteLine(p.Key.ToString());
                    sw.WriteLine(p.Value.ToFile());
                }
            }
        }

        public static DetectorEnergyCalibrationBase LoadFromFile(string loadFile)
        {
            try
            {
                return ReadFromFile(loadFile);
            }
            catch
            {
                return GetEnergyCalibrationDefault();
            }
        }

        private static DetectorEnergyCalibrationBase ReadFromFile(string loadFile)
        {
            DetectorEnergyCalibrationBase eCal;
            using (StreamReader sr = new StreamReader(loadFile))
            {
                eCal = GetEnergyCalibration(
                    (DetectorType)Enum.Parse(typeof(DetectorType), sr.ReadLine()));

                while (!sr.EndOfStream)
                {
                    DetectorKey detKey = new DetectorKey(sr.ReadLine().Trim());
                    eCal.AddEnergyCalibration(detKey, GetIEnergyCalibration(sr));
                }
            }

            return eCal;
        }

        private static IEnergyCalibration GetIEnergyCalibration(StreamReader sr)
        {
            PoliMiOrganicNeutronEnergyCal eCalType =
                (PoliMiOrganicNeutronEnergyCal)Enum.Parse(typeof(PoliMiOrganicNeutronEnergyCal), sr.ReadLine().Trim());
            bool convertEnergy = bool.Parse(sr.ReadLine().Trim());
            return GetEnergyCalibration(eCalType, GetFitParams(sr.ReadLine().Trim()), convertEnergy);
        }

        private static List<double> GetFitParams(string line)
        {
            var splitLine = line.Split();
            List<double> fitParams = new List<double>();
            foreach (var s in splitLine)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    fitParams.Add(double.Parse(s));
                }
            }

            return fitParams;
        }

        public static string GetStringToWriteToFile(EnergyCalibration eCal)
        {
            string file = eCal.GetPoliMiCalType().ToString() + Environment.NewLine;
            file += eCal.GetConvertToKeVeeFromMeVee().ToString() + Environment.NewLine;
            foreach (var p in eCal.GetParameters())
            {
                file += p.ToString() + " ";
            }

            file.TrimEnd(' ');
            return file;
        }
    }
}
