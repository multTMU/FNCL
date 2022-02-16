using System.Collections.Generic;
using System.Linq;

namespace GlobalHelpersDefaults
{
    public struct DetectorKey
    {
        public int Panel;
        public int Detector;
        private static char SEP = ' ';

        public DetectorKey(string line)
        {
            var splitLine = line.Split(SEP);
            Panel = int.Parse(splitLine[0]);
            Detector = int.Parse(splitLine[1]);
        }

        public DetectorKey(int panel, int detector)
        {
            Panel = panel;
            Detector = detector;
        }

        public override string ToString()
        {
            return Panel + SEP.ToString() + Detector;
        }

        public string ToStringHuman()
        {
            return "Panel: " + Panel + SEP.ToString() + "Detector: " + Detector;
        }

        public static bool operator ==(DetectorKey detectorA, DetectorKey detectorB)
        {
            return (detectorA.Panel == detectorB.Panel) && (detectorA.Detector == detectorB.Detector);
        }

        public static bool operator !=(DetectorKey detectorA, DetectorKey detectorB)
        {
            return !(detectorA == detectorB);
        }
    }

    public static class FNCLdetectorDictionary
    {
        private static Dictionary<DetectorKey, int> FnclDetectors;
        private static int StartingIndex;

        static FNCLdetectorDictionary()
        {
            RefreshDictionary();
        }

        private static void RefreshDictionary()
        {
            FnclDetectors = new Dictionary<DetectorKey, int>();
        }

        public static void MakeDictionary(int FirstIndex)
        {
            RefreshDictionary();
            int detIndex = FirstIndex;
            foreach (var p in FnclHelpers.ListOfPanels)
            {
                foreach (int d in FnclHelpers.ListOfDetectors)
                {
                    FnclDetectors.Add(new DetectorKey(p, d), detIndex);
                    detIndex++;
                }
            }
        }

        public static DetectorKey GetKeyByIndex(int detector)
        {
            return FnclDetectors.FirstOrDefault(x => x.Value == detector).Key;
        }

        public static int GetDetectorIndex(DetectorKey key)
        {
            return FnclDetectors[key];
        }

        internal static List<int> GetAllDetectorIndices()
        {
            List<int> detectors = new List<int>();
            foreach (var d in FnclDetectors)
            {
                detectors.Add(d.Value);
            }

            return detectors;
        }
    }
}
