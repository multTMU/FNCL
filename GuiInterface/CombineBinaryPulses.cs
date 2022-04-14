using System.Collections.Generic;
using System.IO;
using System.Linq;
using Multiplicity;
using Multiplicity.PulseFilters;

namespace GuiInterface
{
    public static class CombineBinaryPulses
    {
        private const int PULSES_PER_MB = 67971;
        private const string ACTIVE = "IM";
        private const string PASSIVE = "PB";
        private const string DATA = "DAQ";
        private const string FNCL_BASIS = "FNCL_DAQ_";
        private const string FNCL_EXTENSION = ".bin";

        private static int maxPulsesPerFile;
        private static double countTime;
        private static string topDirectory;
        private static string filePrefix;
        private static string currentDirectory;

        public static void SavePulses(string binaryPulseFile, string FilePrefix, double countTimeSec,
            double maxSizeMB, bool active, bool passive, List<IPulseFilter<FnclPulse>> filters = null)
        {
            SetCominationSpecification(binaryPulseFile, FilePrefix, countTimeSec, maxSizeMB);

            List<FnclPulse> pulsesToSave = new List<FnclPulse>();
            List<FnclPulse> currentPulses = new List<FnclPulse>();

            if (filters == null)
            {
                filters = new List<IPulseFilter<FnclPulse>>();
            }

            foreach (var w in GetWorkingDirectories(active, passive))
            {
                int nBatch = 0;
                int i = 0;
                pulsesToSave.Clear();
                currentDirectory = GetWorkingDirectory(w);
                currentPulses = GetNextPulses(MakeFnclFile(currentDirectory, i), filters);

                while (currentPulses.Count > 0)
                {
                    int pulsesAdded = 0;
                    while (fileCriteriaNotSatisfied(pulsesToSave))
                    {
                        if (pulsesAdded == currentPulses.Count)
                        {
                            i++;
                            string pulseFile = MakeFnclFile(currentDirectory, i);
                            if (PulsesHelper.FileExistsAndNotEmpty(pulseFile))
                            {
                                currentPulses = GetNextPulses(MakeFnclFile(currentDirectory, i), filters);
                                pulsesAdded = 0;
                            }
                            else
                            {
                                break;
                            }
                        }

                        pulsesToSave.Add(currentPulses[pulsesAdded]);
                        pulsesAdded++;
                    }

                    PulsesHelper.SavePulsesFlat(GetSaveFile(nBatch), pulsesToSave);
                    nBatch++;

                    for (int rp = 0; rp < pulsesAdded; rp++)
                    {
                        currentPulses.RemoveAt(0);
                    }

                    pulsesToSave.Clear();
                }

                if (nBatch == 0)
                {
                    PulsesHelper.SavePulsesFlat(GetSaveFile(nBatch), pulsesToSave);
                }
            }
        }

        private static List<FnclPulse> GetNextPulses(string pulseFile, List<IPulseFilter<FnclPulse>> filters)
        {
            Pulses<FnclPulse> currentPulses = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);
            currentPulses.RunExternalFilters(filters);
            return currentPulses.GetPulses();
        }

        private static List<string> GetWorkingDirectories(bool active, bool passive)
        {
            List<string> workingDirectories = new List<string>();

            if (active)
            {
                workingDirectories.Add(ACTIVE);
            }

            if (passive)
            {
                workingDirectories.Add(PASSIVE);
            }

            return workingDirectories;
        }

        private static bool fileCriteriaNotSatisfied(List<FnclPulse> pulses)
        {
            if (pulses.Count == 0)
            {
                return timeCriteria(0, 0) && numberCriteria(pulses.Count, 0);
            }

            return timeCriteria(GetTimeSpannedByPulses(pulses), 0) && numberCriteria(pulses.Count, 0);
        }

        private static void SetCominationSpecification(string binaryPulseFile, string FilePrefix, double countTimeSec,
            double maxSizeMB)
        {
            maxPulsesPerFile = (int)(maxSizeMB * PULSES_PER_MB);
            countTime = PulsesHelper.ConvertSecondsToNanoSeconds(countTimeSec);
            topDirectory = GetTopDataDirectory(binaryPulseFile);
            filePrefix = FilePrefix;
        }

        private static string GetSaveFile(int nBatch)
        {
            return Path.Combine(currentDirectory, filePrefix + "_" + nBatch + ".txt");
        }

        private static string GetWorkingDirectory(string directory)
        {
            return Path.Combine(topDirectory, Path.Combine(directory, DATA + Path.DirectorySeparatorChar));
        }

        private static bool fileCriteriaNotSatisfied(List<FnclPulse> fnclPulses, List<FnclPulse> currentPulses)
        {
            return timeCriteria(fnclPulses, currentPulses) && numberCriteria(fnclPulses, currentPulses);
        }

        private static bool numberCriteria(List<FnclPulse> fnclPulses, List<FnclPulse> currentPulses)
        {
            return numberCriteria(fnclPulses.Count, currentPulses.Count);
        }

        private static bool numberCriteria(int numberPulsesA, int numberPulsesB)
        {
            return (numberPulsesA + numberPulsesB) < maxPulsesPerFile;
        }

        private static bool timeCriteria(double pulseTimeA, double pulseTimeB)
        {
            return (pulseTimeA + pulseTimeB) < countTime;
        }

        private static bool timeCriteria(List<FnclPulse> fnclPulses, List<FnclPulse> currentPulses)
        {
            if (fnclPulses.Count == 0)
            {
                return timeCriteria(0, currentPulses.Last().GetTime());
            }

            return timeCriteria(GetTimeSpannedByPulses(fnclPulses), currentPulses.Last().GetTime());
        }

        private static double GetTimeSpannedByPulses(List<FnclPulse> fnclPulses)
        {
            return fnclPulses.Last().GetTime() - fnclPulses.First().GetTime();
        }

        private static string MakeFnclFile(string topDirectory, int i)
        {
            return Path.Combine(topDirectory, FNCL_BASIS + i.ToString() + FNCL_EXTENSION);
        }

        private static string GetTopDataDirectory(string binaryPulseFile)
        {
            string path = Path.GetDirectoryName(binaryPulseFile);
            DirectoryInfo par = Directory.GetParent(path);
            // par.GetDirectories()
            string[] directories = path.Split(Path.DirectorySeparatorChar);
            directories[0] += Path.DirectorySeparatorChar;
            string topDirectory = string.Empty;
            foreach (var d in directories)
            {
                if (FoundEndDirectory(d))
                {
                    break;
                }

                topDirectory = Path.Combine(topDirectory, d);
            }

            topDirectory += Path.DirectorySeparatorChar;
            return topDirectory;
        }

        private static bool FoundEndDirectory(string folder)
        {
            return string.Equals(folder, PASSIVE) || string.Equals(folder, ACTIVE);
        }
    }
}
