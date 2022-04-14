using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GlobalHelpers;
using GlobalHelpersDefaults;
using Multiplicity;
using PoliMiRunner;
using Runner;

namespace GuiInterface
{
    public static class EnumGuiHelpers
    {
        // https://stackoverflow.com/questions/6454950/passing-an-enum-type-as-an-argument
        // Why not just use generic for everything? Keeps the dependencies here and not all over the GUI

        private static IDictionary<string, int> convertEnumToDictionary<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>()
                .ToDictionary(currentItem => Enum.GetName(typeof(T), currentItem));
        }

        public static IDictionary<string, int> GetMPPostDefaultDetectors()
        {
            return convertEnumToDictionary<MPPostDefaultDetectors>();
        }

        public static IDictionary<string, int> GetParticles()
        {
            return convertEnumToDictionary<Particle>();
        }

        public static IDictionary<string, int> GetMPPostDetectorTypes()
        {
            return convertEnumToDictionary<MPPostDetectorTypes>();
        }

        public static IDictionary<string, int> GetHe3OutputStyle()
        {
            return convertEnumToDictionary<MPPostSpecification.He3Module.He3OutputStyle>();
        }

        public static IDictionary<string, int> GetHe3TriggerType()
        {
            return convertEnumToDictionary<MPPostSpecification.He3Module.He3TriggerType>();
        }

        public static IDictionary<string, int> GetHe3DeadTimeType()
        {
            return convertEnumToDictionary<MPPostSpecification.He3Module.He3DeadTimeType>();
        }

        public static IDictionary<string, int> GetNeutronRegionType()
        {
            return convertEnumToDictionary<PoliMiOrganicNeutronEnergyCal>();
        }

        public static MPPostSpecification.DetectorVariable<int> ConvertDetectorVariableEnumToInt<T>(
            MPPostSpecification.DetectorVariable<T> detectorEnum) where T : Enum
        {
            MPPostSpecification.DetectorVariable<int> detectorInt =
                new MPPostSpecification.DetectorVariable<int>(detectorEnum.VarName);
            detectorInt.SetValueAndState(detectorEnum.VarIsSet, (int)(object)detectorEnum.Value);
            return detectorInt;
        }

        public static MPPostSpecification.DetectorVariableBase<T> ConvertDetectorVariableBaseIntToEnum<T>(
            MPPostSpecification.DetectorVariableBase<int> intDetector) where T : Enum
        {
            return new MPPostSpecification.DetectorVariableBase<T>(intDetector.VarIsSet,
                (T)Enum.ToObject(typeof(T), intDetector.Value));
        }
    }


    public interface IDetectorVariableGUI<T>
    {
        bool IsDetectorVariableSet();
        void SetDetectorVariableState(bool varIsSet);
        void UseAsDetectorVariable();
        T GetValue();
        void SetDetectorVariable(MPPostSpecification.DetectorVariable<T> detectorVariable);
        MPPostSpecification.DetectorVariableBase<T> GetDetectorVariable();
    }

    public enum ModelTypes
    {
        Undefined,
        AmLi,
        AmLiSel,
        MP320,
        MP320Sel,
        Starfire,
        StarfireSel,
        NGamArray12
    }

    public enum AppliedPulseFilters
    {
        Particle,
        Detectors,
        ADC,
        PileUp,
        Offset,
        Energy,
        Correlated,
        CrossTalk,
        Stream,
        FlatTop
    }

    public enum PlotScaleType
    {
        Log,
        Linear
    }

    public enum PulseAmplitudeType
    {
        ADC,
        KeVee
    }

    public static class MultiplicityInterfaceHelper
    {
        public const string EXT_TIMESTAMP = ".txt"; // this is also used for SnlNGam files
        public const string EXT_POLIMI = ".o";
        public const string EXT_FNCLBINARY = ".bin";
        private const int DEAULT_NUMBER = 0;
        private const double SMALL_NUMBER = 0.001;
        private const double BIG_NUMBER = 1000;
        private const string EXP_FORMAT = "E3";

        public static string GetPulseFileFilter()
        {
            return string.Empty;
        }

        public static IGuiInterface GetMulitiplicityGUIhelper(string pulseFile)
        {
            switch (Path.GetExtension(pulseFile))
            {
                case EXT_TIMESTAMP:
                    if (isFlatFile(pulseFile))
                    {
                        return new FnclTimeStampMultiplicityGui(pulseFile);
                    }
                    return new NGamSnlMultiplicityGui(pulseFile);

                case EXT_POLIMI:
                    return new FnlcPoliMiMultiplicityGui(pulseFile);
                case EXT_FNCLBINARY:
                    return new FnclBinaryMultiplicityGui(pulseFile);
                default:
                    return new UndefinedPulsesForGui();
            }
        }

        private static bool isFlatFile(string pulseFile)
        {
            using (StreamReader sr = new StreamReader(pulseFile))
            {
                string firstLine = sr.ReadLine();
                return PulsesHelper.isFlatFile(firstLine);
            }
        }

        public static IGuiInterface GetMulitiplicityGUIhelper(List<PulsesHelper.PoliMiSimulations> poliMiProblems,
            int seed)
        {
            return new FnlcPoliMiMultiplicityGui(poliMiProblems, seed);
        }

        public static double GetPlotSafeLog(double value)
        {
            if (value < 0)
            {
                return -1.0 * Math.Log10(-1.0 * value);
            }

            if (value == 0)
            {
                return 0;
            }

            return Math.Log10(value);
        }

        public static string FormatNumber(double number)
        {
            if (NumberIsSmallOrLarge(number))
            {
                return number.ToString(EXP_FORMAT);
            }

            return number.ToString();
        }

        private static bool NumberIsSmallOrLarge(double number)
        {
            number = Math.Abs(number);
            return (number > BIG_NUMBER) || (number < SMALL_NUMBER);
        }

        public static string GetPulseTypeToString(PulseFileType pulseType)
        {
            switch (pulseType)
            {
                case PulseFileType.PoliMi:
                    return "Mcnp PoliMi";
                case PulseFileType.FnclFlat:
                    return "Fncl TimeStamp";
                case PulseFileType.FnclBinary:
                    return "Fncl Binary";
                default:
                    return "Undefined";
            }
        }

        public static double ValidateDouble(string text, double defaultNumber = DEAULT_NUMBER)
        {
            try
            {
                return double.Parse(text, NumberStyles.Any);
            }
            catch
            {
                return defaultNumber;
            }
        }

        public static int ValidateInt(string testValue, int defaultNumber = DEAULT_NUMBER)
        {
            try
            {
                return int.Parse(testValue, NumberStyles.Any);
            }
            catch
            {
                return defaultNumber;
            }
        }

        public static double ConvertNanoSecToSeconds(double timeNanoSec)
        {
            return PulsesHelper.ConvertNanoSecondsToSeconds(timeNanoSec);
        }

        public static List<Multiplicity.PulseFilters.DetectorTimeShift> GeTimeShiftsForPanel(List<int> panelOne,
            List<int> panelTwo,
            List<int> panelThree)
        {
            List<Multiplicity.PulseFilters.DetectorTimeShift> shift =
                new List<Multiplicity.PulseFilters.DetectorTimeShift>();
            shift.AddRange(AddPanel(panelOne, FnclHelpers.PANEL_ONE));
            shift.AddRange(AddPanel(panelTwo, FnclHelpers.PANEL_TWO));
            shift.AddRange(AddPanel(panelThree, FnclHelpers.PANEL_THREE));

            return shift;
        }

        private static List<Multiplicity.PulseFilters.DetectorTimeShift> AddPanel(List<int> detectors, int panel)
        {
            List<Multiplicity.PulseFilters.DetectorTimeShift> shift =
                new List<Multiplicity.PulseFilters.DetectorTimeShift>();

            for (int d = 0; d < detectors.Count; d++)
            {
                if (detectors[d] != 0)
                {
                    shift.Add(new Multiplicity.PulseFilters.DetectorTimeShift(
                        FNCLdetectorDictionary.GetDetectorIndex(new DetectorKey(panel, d)), detectors[d]));
                }
            }

            return shift;
        }

        public static List<string> GetFiles(string prompt, bool create = false, string filter = "")
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            openFile.Title = prompt;
            openFile.CheckFileExists = !create;
            if (!string.IsNullOrEmpty(filter))
            {
                openFile.Filter = filter;
            }

            List<string> files = new List<string>();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                files = openFile.FileNames.ToList();
            }

            return files;
        }

        public static string GetFile(string prompt, bool create = false, string filter = "")
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Title = prompt;
            openFile.CheckFileExists = !create;

            if (!string.IsNullOrEmpty(filter))
            {
                openFile.Filter = filter;
            }

            string file = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                file = openFile.FileName;
            }

            return file;
        }
    }
}
