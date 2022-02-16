using System;
using System.Collections.Generic;
using GlobalHelpersDefaults;

namespace GuiInterface
{
    public class CrossTalk
    {
        public bool Self;
        public bool OneTwo;
        public bool OneThree;
        public bool OneFour;
        public bool TwoThree;
        public bool TwoFour;
        public bool ThreeFour;

        private Dictionary<string, List<int>> crossDict;
        private List<int> selfTalk;

        public CrossTalk(bool state)
        {
            Self = state;
            OneTwo = state;
            OneThree = state;
            OneFour = state;
            TwoThree = state;
            TwoFour = state;
            ThreeFour = state;
        }

        public Dictionary<string, List<int>> GetCrossDictionary()
        {
            return crossDict;
        }

        public List<int> GetSelfTalk()
        {
            return selfTalk;
        }

        public void MakeDictionaries() //Dictionary<string, List<int>> GetDictionary()
        {
            crossDict = new Dictionary<string, List<int>>();
            selfTalk = new List<int>();
            List<string> panels = FnclHelpers.GetFnclPanelNames();

            int panelName = 0;
            foreach (var p in FnclHelpers.ListOfPanels)
            {
                string currentPanel = panels[panelName];
                panelName++;
                if (Self)
                {
                    AddSelfVetoForPanel(p, currentPanel);
                }

                if (OneTwo)
                {
                    AddDetectorPair("OneTwo" + currentPanel, p, FnclHelpers.DETECTOR_ONE, FnclHelpers.DETECTOR_TWO);
                }

                if (OneThree)
                {
                    AddDetectorPair("OneThree" + currentPanel, p, FnclHelpers.DETECTOR_ONE, FnclHelpers.DETECTOR_THREE);
                }

                if (OneFour)
                {
                    AddDetectorPair("OneFour" + currentPanel, p, FnclHelpers.DETECTOR_ONE, FnclHelpers.DETECTOR_FOUR);
                }

                if (TwoThree)
                {
                    AddDetectorPair("TwoThree" + currentPanel, p, FnclHelpers.DETECTOR_TWO, FnclHelpers.DETECTOR_THREE);
                }

                if (TwoFour)
                {
                    AddDetectorPair("TwoFour" + currentPanel, p, FnclHelpers.DETECTOR_TWO, FnclHelpers.DETECTOR_FOUR);
                }

                if (ThreeFour)
                {
                    AddDetectorPair("ThreeFour" + currentPanel, p, FnclHelpers.DETECTOR_THREE,
                        FnclHelpers.DETECTOR_FOUR);
                }
            }

            //return crossDict;
        }

        private void AddSelfVetoForPanel(int p, string currentPanel)
        {
            foreach (int d in FnclHelpers.ListOfDetectors)
            {
                int detector = GetDetector(p, d);
                // string selfLabel = "Self_" + currentPanel + "_Det" + detector;
                // crossDict.Add(selfLabel, new List<int>() {detector});
                selfTalk.Add(detector);
            }
        }

        private void AddDetectorPair(string dictKeyPrefix, int panel, int detA, int detB)
        {
            int detectorA = GetDetector(panel, detA);
            int detectorB = GetDetector(panel, detB);
            string label = dictKeyPrefix + "_Det" + detectorA + "_" + detectorB;
            crossDict.Add(label, new List<int>() {detectorA, detectorB});
        }

        private int GetDetector(int panel, int detector)
        {
            DetectorKey detKey = new DetectorKey(panel, detector);
            return FNCLdetectorDictionary.GetDetectorIndex(detKey);
        }
    }

    public class PanelDetectors
    {
        public bool DetectorOne;
        public bool DetectorTwo;
        public bool DetectorThree;
        public bool DetectorFour;

        public PanelDetectors(bool UniformState)
        {
            DetectorOne = UniformState;
            DetectorTwo = UniformState;
            DetectorThree = UniformState;
            DetectorFour = UniformState;
        }

        public List<int> GetSelectedDetectors()
        {
            List<int> detectors = new List<int>();
            if (DetectorOne)
            {
                detectors.Add(FnclHelpers.DETECTOR_ONE);
            }

            if (DetectorTwo)
            {
                detectors.Add(FnclHelpers.DETECTOR_TWO);
            }

            if (DetectorThree)
            {
                detectors.Add(FnclHelpers.DETECTOR_THREE);
            }

            if (DetectorFour)
            {
                detectors.Add(FnclHelpers.DETECTOR_FOUR);
            }

            return detectors;
        }
    }

    public class SelectedDetectors
    {
        public PanelDetectors PanelOne;
        public PanelDetectors PanelTwo;
        public PanelDetectors PanelThree;

        private const bool DEFAULT_STATE = true;

        public SelectedDetectors()
        {
            SetUniform(DEFAULT_STATE);
        }

        public List<int> GetSelectedDetectors()
        {
            List<int> detectors = new List<int>();

            foreach (var d in PanelOne.GetSelectedDetectors())
            {
                detectors.Add(FNCLdetectorDictionary.GetDetectorIndex(new DetectorKey(FnclHelpers.PANEL_ONE, d)));
            }

            foreach (var d in PanelTwo.GetSelectedDetectors())
            {
                detectors.Add(FNCLdetectorDictionary.GetDetectorIndex(new DetectorKey(FnclHelpers.PANEL_TWO, d)));
            }

            foreach (var d in PanelThree.GetSelectedDetectors())
            {
                detectors.Add(FNCLdetectorDictionary.GetDetectorIndex(new DetectorKey(FnclHelpers.PANEL_THREE, d)));
            }

            return detectors;
        }

        private void SetUniform(bool state)
        {
            PanelOne = new PanelDetectors(state);
            PanelTwo = new PanelDetectors(state);
            PanelThree = new PanelDetectors(state);
        }

        public void SetFromList(List<int> detectors)
        {
            foreach (var d in detectors)
            {
                SetFromKey(FNCLdetectorDictionary.GetKeyByIndex(d));
            }
        }

        private void SetFromKey(DetectorKey detectorKey)
        {
            SetUniform(false);
            if (detectorKey.Panel == FnclHelpers.PANEL_ONE)
            {
                SetDetectorFromKey(PanelOne, detectorKey);
            }
            else if (detectorKey.Panel == FnclHelpers.PANEL_TWO)
            {
                SetDetectorFromKey(PanelTwo, detectorKey);
            }
            else if (detectorKey.Panel == FnclHelpers.PANEL_THREE)
            {
                SetDetectorFromKey(PanelThree, detectorKey);
            }
            else
            {
                throw new Exception("Invalid Panel");
            }
        }

        private void SetDetectorFromKey(PanelDetectors panel, DetectorKey detectorKey)
        {
            if (detectorKey.Detector == FnclHelpers.DETECTOR_ONE)
            {
                panel.DetectorOne = true;
            }
            else if (detectorKey.Detector == FnclHelpers.DETECTOR_TWO)
            {
                panel.DetectorTwo = true;
            }
            else if (detectorKey.Detector == FnclHelpers.DETECTOR_THREE)
            {
                panel.DetectorThree = true;
            }
            else if (detectorKey.Detector == FnclHelpers.DETECTOR_FOUR)
            {
                panel.DetectorFour = true;
            }
            else
            {
                throw new Exception("Invalid Detector");
            }
        }
    }

    public static class DetectorDictionariesHelper
    {
        public static int GetDetectorIndexByKey(DetectorKey key, DetectorType detector)
        {
            switch (detector)
            {
                case DetectorType.None:
                    return 0;
                case DetectorType.FastNeutronCollar:
                    return FNCLdetectorDictionary.GetDetectorIndex(key);
                case DetectorType.NGammaPrototype:
                    return NGammaHelpers.GetDetectorIndex(key);
                default:
                    throw new ArgumentOutOfRangeException(nameof(detector), detector, null);
            }
        }
    }
}
