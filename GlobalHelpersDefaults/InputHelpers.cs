using System;
using System.Collections.Generic;
using System.Linq;
using GlobalHelpersDefaults;

namespace GlobalHelpers
{
    public enum ParticleImportance
    {
        NeutronOnly,
        GammaOnly,
        NeutronAndGamma,
        NoNeutron,
        NoGamma,
        Neither
    }

    public enum PoliMiSource
    {
        None = 0,
        U238Sf = 2,
        Pu240Sf = 3,
        Pu242Sf = 4,
        Cm242Sf = 5,
        Cm244Sf = 6,
        Pu238Sf = 7,
        Cf252Sf = 10,
        AmBe = 11,
        AmLi = 13,
        DT = 14,
        DD = 15,
        Pu238O2 = 38,
        Pu239O2 = 39,
        Pu240O2 = 40,
        Am241O2 = 41,
        U232UF6 = 62,
        U234UF6 = 64,
        U235UF6 = 65,
        U236UF6 = 66,
        U238UF6 = 68
    }

    public enum MPPostDetectorTypes
    {
        NonActiveVolume = 0, // (i.e. PMT)
        LiquidOrganicScintillator = 1,
        He3 = 2, //(Cannot be run with other types)
        PlasticOrganicScintillator = 3,
        NaI = 4,
        CaF2 = 5,
        LaBr3 = 6
    }

    public static class DataCardHelper
    {
        private const string COMMENT = "RUN SPECIFICATION";
        private const string MODE = "mode";
        private const string PHYSICS = "phys:n j 20.0";
        private const string NUM_PARTICLES = "nps";

        public static List<string> GetDataCard(int numberParticles, ParticleImportance particleImportance)
        {
            List<string> card = new List<string>();
            card.Add(MCNPformatHelper.GetCommentLine(COMMENT));
            string particle = GetParticle(particleImportance);
            card.Add(MODE + " " + particle);
            card.Add(PHYSICS);
            card.Add(NUM_PARTICLES + " " + numberParticles);
            return card;
        }

        private static string GetParticle(ParticleImportance particleImportance)
        {
            switch (particleImportance)
            {
                case ParticleImportance.NeutronOnly:
                    return "n";
                case ParticleImportance.GammaOnly:
                    return "p";
                case ParticleImportance.NeutronAndGamma:
                    return "n p";
                default:
                    return "n";
            }
        }
    }

    public static class PoliMiMPPostInputHelper
    {
        private const double MIN_NEUTRON_ENERGY_MEV = 0.001;
        private const double MIN_GAMMA_ENERGY_MEV = 0.001;

        private const string HEADER = " PoliMi Cards";
        private const string IPOL1 = "ipol";
        private const string IPOL_NEUTRON = "2 0 0 2J";
        private const string IPOL_GAMMA = "1 1 1 j 1"; // was used by Kyle Pollacks's models
        private const string RPOL = "rpol";
        private const string FILES = "files 21 dumn1";

        private const string HE3_OUTPUT_FILE = "He3Mp320";
        private const string FNCL_OUTPUT_FILE = "FnclLiquidScint";
        private const string NGAM12_OUTPUT_FILE = "NGam12";
        private const string NGEN350_FLUX_OUTPUT_FILE = "NGen350";
        private const string DETECTOR_FILE_POSTFIX = "Detector.txt";

        private const string HE3_DETECTOR_FILE = HE3_OUTPUT_FILE + DETECTOR_FILE_POSTFIX;
        private const string FNCL_DETECTOR_FILE = FNCL_OUTPUT_FILE + DETECTOR_FILE_POSTFIX;
        private const string NGAM12_DETECTOR_FILE = NGAM12_OUTPUT_FILE + DETECTOR_FILE_POSTFIX;
        private const string NGEN350_FLUX_MONITOR_DETECTOR_FILE = NGEN350_FLUX_OUTPUT_FILE + DETECTOR_FILE_POSTFIX;

        private static bool addSecondDetector;
        private static List<int> Detectors;

        static PoliMiMPPostInputHelper()
        {
            Detectors = new List<int>();
            addSecondDetector = false;
        }

        public static void AddDetectorCell(int detector)
        {
            Detectors.Add(detector);
            Detectors = Detectors.Distinct().ToList();
        }

        public static List<int> GetDetectors()
        {
            return Detectors;
        }

        public static List<string> GetPoliMiLinesSource(PoliMiSource source,
            double neutronThreshold = MIN_NEUTRON_ENERGY_MEV, double gammaThreshold = MIN_GAMMA_ENERGY_MEV)
        {
            List<string> poliMi = new List<string>();

            poliMi.Add(MCNPformatHelper.GetCommentLine(HEADER));
            poliMi.Add(GetIPOLline(source));
            poliMi.Add(GetRPOLline(neutronThreshold, gammaThreshold));
            poliMi.Add(FILES);

            return poliMi;
        }

        private static string GetRPOLline(double neutronThreshold, double gammaThreshold)
        {
            return RPOL + " " + neutronThreshold.ToString() + " " + gammaThreshold.ToString();
        }

        private static string GetIPOLline(PoliMiSource source, Particle particle = Particle.Neutron)
        {
            string detectors = IPOL1 + " " + (int)source + " " + GetIPOLforParticle(particle) + " " +
                               GetAllDetectorsForPoliMi().Count.ToString() + " ";
            foreach (var d in GetAllDetectorsForPoliMi())
            {
                detectors += d.ToString() + " ";
            }

            return detectors;
        }

        private static string GetIPOLforParticle(Particle particle)
        {
            switch (particle)
            {
                case Particle.Neutron:
                    return IPOL_NEUTRON;
                case Particle.Photon:
                    return IPOL_GAMMA;
                case Particle.NeutronAndPhoton:
                    return IPOL_GAMMA;
                default:
                    throw new Exception("Must specify particle type to set PoliMi IPOL line");
            }
        }

        public static void AddSecondDetector(int detectorIndex)
        {
            addSecondDetector = true;
            AddDetectorCell(detectorIndex);
        }

        private static List<int> GetAllDetectorsForPoliMi()
        {
            return Detectors.Distinct().ToList();
        }

        public static bool IncludeAdditionalDetector()
        {
            return addSecondDetector;
        }

        public static string GetHe3DetectorOutputPrefix()
        {
            return HE3_OUTPUT_FILE;
        }

        public static string GetFnclOutputPrefix()
        {
            return FNCL_OUTPUT_FILE;
        }

        public static string GetNGamOutputPrefix()
        {
            return NGAM12_OUTPUT_FILE;
        }

        public static string GetHe3DetectorFile()
        {
            return HE3_DETECTOR_FILE;
        }

        public static string GetFnclDetectorFile()
        {
            return FNCL_DETECTOR_FILE;
        }

        public static string GetNGamDetectorFile()
        {
            return NGAM12_DETECTOR_FILE;
        }

        public static string GetNGen350DetectorFile()
        {
            return NGEN350_FLUX_MONITOR_DETECTOR_FILE;
        }

        public static string GetNGen350DetectorputPrefix()
        {
            return NGEN350_FLUX_OUTPUT_FILE;
        }
    }

    public static class UniverseAndImportanceHelper
    {
        public const int NO_UNIVERSE = 0;
        private const string UNIVERSE = "u=";
        private const string IMPORTANCE_NEUTRON = "imp:n=1";
        private const string IMPORTANCE_GAMMA = "imp:p=1";
        private const string IMPORTANCE_BOTH = "imp:n,p=1";
        private const string IMPORTANCE_NEITHER = "imp:n,p=0";
        private const string IMPROTANCE_NO_NEUTRON = "imp:n=0";
        private const string IMPROTANCE_NO_GAMMA = "imp:p=0";

        public static string UniverseAndImportance(ParticleImportance importance, int universe)
        {
            string Importance;
            switch (importance)
            {
                case ParticleImportance.GammaOnly:
                    Importance = IMPORTANCE_GAMMA;
                    break;
                case ParticleImportance.NeutronOnly:
                    Importance = IMPORTANCE_NEUTRON;
                    break;
                case ParticleImportance.NeutronAndGamma:
                    Importance = IMPORTANCE_BOTH;
                    break;
                case ParticleImportance.Neither:
                    Importance = IMPORTANCE_NEITHER;
                    break;
                case ParticleImportance.NoGamma:
                    Importance = IMPROTANCE_NO_GAMMA;
                    break;
                case ParticleImportance.NoNeutron:
                    Importance = IMPROTANCE_NO_NEUTRON;
                    break;
                default:
                    Importance = IMPORTANCE_NEITHER;
                    break;
            }

            string universeString = "";
            //if (universe != NO_UNIVERSE)
            //{
            //    universeString = UNIVERSE + universe;
            //} 

            return " " + universeString + " " + Importance;
        }

        public static string UniverseAndImportance(ParticleImportance importance)
        {
            return UniverseAndImportance(importance, NO_UNIVERSE);
        }

        public static string UniverseAndImportance()
        {
            return UniverseAndImportance(GlobalDefaults.ParticleInProblem, NO_UNIVERSE);
        }

        public static string UniverseAndImportance(int universe)
        {
            return UniverseAndImportance(GlobalDefaults.ParticleInProblem, universe);
        }
    }
}
