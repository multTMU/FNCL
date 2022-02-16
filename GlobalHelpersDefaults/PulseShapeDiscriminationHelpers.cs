using System;
using System.Collections.Generic;
using System.IO;

namespace GlobalHelpersDefaults
{
    public struct PsdWaveformGui
    {
        public double FastTimeLow;
        public double FastTimeHigh;

        public double SlowTimeLow;
        public double SlowTimeHigh;

        public double TriggerTime;
        public List<int> Waveform;
        public PsdComponent PSD;
        public Particle PsdParticle;
    }

    public struct PsdComponent
    {
        private const char SEP = ',';
        public double PSD; // (1+S/F)
        public double Amplitude; // S+F

        public PsdComponent(double slow, double fast, double amplitudeDivisor)
        {
            Amplitude = (slow + fast) / amplitudeDivisor;
            PSD = 1.0 + (slow / fast);
        }

        public PsdComponent(string line)
        {
            var split = line.Split(SEP);
            Amplitude = double.Parse(split[0]);
            PSD = double.Parse(split[1]);
        }

        public override string ToString()
        {
            return Amplitude.ToString() + SEP.ToString() + PSD.ToString();
        }
    }

    public enum PsdTriggerTypes
    {
        NotDefined,
        Fixed,
        PeakOffset,
        PeakHeight
    }


    public struct PsdSpecification
    {
        public PsdTriggerTypes TriggerType;
        public int Slow;
        public double Trigger;
        public int Fast;
        public List<PsdComponent> PolyLine;
        public double AmplitudeDivisor;

        public PsdSpecification(int psdSlow, int psdFast,
            List<PsdComponent> psdPolyLine,
            PsdTriggerTypes triggerType, double trigger, double amplitudeDivisor)
        {
            Slow = psdSlow;
            Fast = psdFast;
            PolyLine = psdPolyLine;
            TriggerType = triggerType;
            Trigger = trigger;
            AmplitudeDivisor = (amplitudeDivisor > 0) ? amplitudeDivisor : 1.0;
        }

        public List<string> ToFile(char sep, char comment)
        {
            List<string> lines = new List<string>();
            lines.Add(comment + " Trigger Type");
            lines.Add(TriggerType.ToString());

            lines.Add(comment + " Trigger");
            lines.Add(Trigger.ToString());

            lines.Add(comment + " Slow(ns)");
            lines.Add(Slow.ToString());

            lines.Add(comment + " Fast(ns)");
            lines.Add(Fast.ToString());

            lines.Add(comment + " Amplitude Divisor");
            lines.Add(AmplitudeDivisor.ToString());

            lines.Add(comment + " Amplitude and PSD");
            string psdCurve = "";
            foreach (var p in PolyLine)
            {
                psdCurve += p.Amplitude + sep.ToString() + p.PSD + sep.ToString();
            }

            psdCurve = psdCurve.TrimEnd(sep);
            lines.Add(psdCurve);

            return lines;
        }
    }

    public static class PulseShapeDiscriminationCalibration
    {
        private static Dictionary<DetectorKey, PsdSpecification> calibrations;
        private const char COMMENT = '#';
        private const char SEP = ',';
        private static string lastFile;

        static PulseShapeDiscriminationCalibration()
        {
            lastFile = string.Empty;
            Refresh();
        }

        public static void Refresh()
        {
            calibrations = new Dictionary<DetectorKey, PsdSpecification>();
        }

        public static void SetDetector(DetectorKey detectorKey, PsdSpecification psdCalibration)
        {
            if (calibrations.ContainsKey(detectorKey))
            {
                calibrations[detectorKey] = psdCalibration;
            }
            else
            {
                calibrations.Add(detectorKey, psdCalibration);
            }
        }

        public static PsdSpecification GetCalibrationByDetector(DetectorKey detectorKey)
        {
            return calibrations[detectorKey];
        }

        public static void LoadPsdCalibrationFromFile(string file, bool updateLastSave = true)
        {
            if (updateLastSave)
            {
                lastFile = file;
            }

            if (Path.GetExtension(file) == ".xml")
            {
                FnclSettingsFileHelper.SetPsdCalibrationFromFnclSettings(file);
            }
            else if (File.Exists(file))
            {
                Refresh();
                loadFromFile(file);
            }
        }

        private static void loadFromFile(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    AddCalibration(sr);
                }
            }
        }

        private static void AddCalibration(StreamReader sr)
        {
            DetectorKey key = new DetectorKey(GetLine(sr));
            PsdSpecification cal = new PsdSpecification
            {
                TriggerType =
                    (PsdTriggerTypes)Enum.Parse(
                        typeof(PsdTriggerTypes), GetLine(sr)),
                Trigger = double.Parse(GetLine(sr)),
                Slow = int.Parse(GetLine(sr)),
                Fast = int.Parse(GetLine(sr)),
                AmplitudeDivisor = double.Parse(GetLine(sr)),
                PolyLine = GetPolyLine(GetLine(sr))
            };
            SetDetector(key, cal);
        }

        private static List<PsdComponent> GetPolyLine(string line)
        {
            List<PsdComponent> polyLine = new List<PsdComponent>();

            string[] splitLine = line.Split(SEP);

            int index = 0;
            while (index < splitLine.Length)
            {
                PsdComponent psd = new PsdComponent
                {
                    Amplitude = double.Parse(splitLine[index]), PSD = double.Parse(splitLine[index + 1])
                };
                index += 2;
                polyLine.Add(psd);
            }

            return polyLine;
        }

        private static string GetLine(StreamReader sr)
        {
            string line = string.Empty;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine().TrimStart();
                if (!line.StartsWith(COMMENT.ToString()))
                {
                    return line;
                }
            }

            return line;
        }

        public static void SaveCurrentPsdCalibration(string file)
        {
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.WriteLine(writeHeader());
                foreach (KeyValuePair<DetectorKey, PsdSpecification> p in calibrations)
                {
                    writeKey(sw, p.Key);
                    writePsdCal(sw, p.Value);
                }
            }
        }

        private static void writePsdCal(StreamWriter sw, PsdSpecification calibration)
        {
            foreach (var c in calibration.ToFile(SEP, COMMENT))
            {
                sw.WriteLine(c);
            }
        }

        private static void writeKey(StreamWriter sw, DetectorKey key)
        {
            sw.WriteLine(COMMENT + " " + key.ToStringHuman());
            sw.WriteLine(key.ToString());
        }

        private static string writeHeader()
        {
            return COMMENT + " " + DateTime.Now.ToString() + " " + Environment.UserName;
        }

        public static Dictionary<DetectorKey, PsdSpecification> GetDictionary()
        {
            return calibrations;
        }

        public static void RestoreLastForDetector(DetectorKey detectorKey)
        {
            Dictionary<DetectorKey, PsdSpecification> saveDictionary = new Dictionary<DetectorKey, PsdSpecification>();

            foreach (var c in calibrations)
            {
                saveDictionary.Add(c.Key, c.Value);
            }

            LoadPsdCalibrationFromFile(lastFile, false);

            saveDictionary[detectorKey] = calibrations[detectorKey];
            calibrations = saveDictionary;
        }
    }
}
