using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace GlobalHelpersDefaults
{
    public enum Particle
    {
        // Do not change these values!!!
        // PoliMi particle designation # in pulse File, which we cast from

        Undetermined = 0, // had 3 show up in MPPost AllPulses file what!?
        Neutron = 1,
        Photon = 2,
        Electron = 3, // According to PoliMi manual, doesn't appear in MPPost Manual
        NeutronAndPhoton = 4
    }

    public static class NGammaHelpers
    {
        public const int COINCIDENCE_INTERVAL = 1028;
        public const int NUMBER_DETECTORS = NUMBER_ROWS * NUMBER_COLUMNS;
        public const int NUMBER_ROWS = 4;
        public const int NUMBER_COLUMNS = 3;
        public static Particle PARTICLE = Particle.Photon;
        public static readonly List<int> ListOfDetectors;

        static NGammaHelpers()
        {
            ListOfDetectors = new List<int>();
            for (int i = 0; i < NUMBER_DETECTORS; i++)
            {
                ListOfDetectors.Add(i + 1);
            }
        }

        public static List<int> GetPoliMiDetectors()
        {
            List<int> detectors = new List<int>();
            for (int i = GlobalDefaults.FIRST_POLIMI_DETECTOR_INDEX;
                i < GlobalDefaults.FIRST_POLIMI_DETECTOR_INDEX + NUMBER_DETECTORS;
                i++)
            {
                detectors.Add(i);
            }

            return detectors;
        }

        public static int GetDetectorIndex(DetectorKey key)
        {
            throw new System.NotImplementedException();
        }
    }

    public static class FnclHelpers
    {
        public const int FIRST_DETECTOR_INDEX = 0;

        public const double PULSE_AMPLITUDE_DISCRIMINATOR_KEVEE = 72.0;
        public const int COINCIDENCE_INTERVAL = 60;
        public const int PSD_FAST_INTERVAL = 50;
        public const int PSD_SLOW_INTERVAL = 140;
        public const double PSD_AMPLITUDE_SCALAR = 500.0;
        public const int ADC_TRIGGER = 200;
        public const double PILEUP_INTERVAL = 14;
        public const double PILEUP_SENSITIVITY = 88.0; // just grabbed from Manual, not sure how this is applied
        public const int PREDELAY_SEO = 0;
        public const int PSD_PEAKMAX_TRIGGER = -7 * WAVEFORM_TIMESTEP;
        public const int LONGDELAY_SEO = 100 * COINCIDENCE_INTERVAL;
        public const int NUMBER_DETECTORS = NUMBER_PANELS * DETECTORS_PER_PANEL;
        public const bool FITLER_CROSSTALK = true;
        public const int WAVEFORM_TIMESTEP = 2;

        public const int POLIMI_NPS = (int)1e7;
        public const double POLIMI_ACTIVITY = 1;

        public static Particle PARTICLE = Particle.Neutron;

        public const int DETECTORS_PER_PANEL = 4;
        public const int DETECTOR_ONE = 1;
        public const int DETECTOR_TWO = 2;
        public const int DETECTOR_THREE = 3;
        public const int DETECTOR_FOUR = 4;

        public const int NUMBER_PANELS = 3;
        public const int PANEL_ONE = 1;
        public const int PANEL_TWO = 2;
        public const int PANEL_THREE = 3;

        public const int NUMBER_NGEN350_DETECTORS = 6;

        public static readonly List<int> ListOfDetectors;
        public static readonly List<int> ListOfPanels;
        public static MPPostDetectorTypes NGen350DetectorMaterial = MPPostDetectorTypes.PlasticOrganicScintillator;

        public const int CROSSTALK_VETO_TIME = 14;
        public const int CORRELATED_PULSE_TIME = 100;

        public const double FLATTOP_DURATION = 6;
        public const double FLATTOP_MAX_PEAK_PERCENT = 95;

        public const PsdTriggerTypes PSD_TYPE =
            PsdTriggerTypes.PeakOffset;

        public const double DEFAULT_AMPLITUDE_SCALAR = 1;

        //private static long largeFileBytes = LARGE_FILE_THRESHOLD_BYTES;

        static FnclHelpers()
        {
            ListOfDetectors = new List<int>() {DETECTOR_ONE, DETECTOR_TWO, DETECTOR_THREE, DETECTOR_FOUR};
            ListOfPanels = new List<int>() {PANEL_ONE, PANEL_TWO, PANEL_THREE};
        }

        public static Dictionary<string, List<int>> GetDefaultCrossTalkDictionary()
        {
            return GetDefaultCrossTalkDictionary(FIRST_DETECTOR_INDEX);
        }

        public static Dictionary<string, List<int>> GetDefaultCrossTalkDictionaryPoliMi()
        {
            return GetDefaultCrossTalkDictionary(GlobalDefaults.FIRST_POLIMI_DETECTOR_INDEX);
        }

        public static List<int> GetPoliMiDetectors()
        {
            List<int> detectors = new List<int>();
            for (int i = GlobalDefaults.FIRST_POLIMI_DETECTOR_INDEX;
                i < GlobalDefaults.FIRST_POLIMI_DETECTOR_INDEX + NUMBER_DETECTORS;
                i++)
            {
                detectors.Add(i);
            }

            return detectors;
        }

        public static List<string> GetFnclPanelNames()
        {
            return new List<string>() {"PanelOne", "PanelTwo", "PanelThree"};
        }

        private static Dictionary<string, List<int>> GetDefaultCrossTalkDictionary(int startingIndex)
        {
            Dictionary<string, List<int>> crossTalk = new Dictionary<string, List<int>>();
            List<string> panels = GetFnclPanelNames();

            int d = startingIndex;
            foreach (var p in panels)
            {
                List<int> dets = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    dets.Add(d);
                    d++;
                }

                crossTalk.Add(p, dets);
            }

            return crossTalk;
        }

        public static List<Bounds<double>> GetDefaultPulseHeightBounds()
        {
            return new List<Bounds<double>>()
            {
                new Bounds<double>(PULSE_AMPLITUDE_DISCRIMINATOR_KEVEE, double.MaxValue)
            };
        }

        public static List<DetectorKey> GetDetectorKeys()
        {
            List<DetectorKey> detectorKeys = new List<DetectorKey>();

            foreach (var p in ListOfPanels)
            {
                foreach (var d in ListOfDetectors)
                {
                    detectorKeys.Add(new DetectorKey(p, d));
                }
            }

            return detectorKeys;
        }
    }
}
