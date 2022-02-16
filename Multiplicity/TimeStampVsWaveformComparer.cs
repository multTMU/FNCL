using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Multiplicity
{
    public static class TimeStampVsWaveformComparer
    {
        private const string WAVE_FILE = "FNCL_DAQ_";
        private const string WAVE_DIR = "DAQ";
        private const string WAVE_EXT = ".bin";
        private const string TIMESTAMP = "TimestampList.txt";
        private const string DIFF_FILE = "TimeStampVsWaveDiff.txt";
        private const string COMP_FILE = "TimeStampVsWaveSideBySide.txt";
        private const string SEP = "\t";
        private const double TOL = 1e-3;

        private static List<Pulse> timeStampPulses;
        private static int timeStampIndex;
        private static StreamWriter writeSideBySide;
        private static StreamWriter writeDiff;
        private static double timeOffset;
        private static int numberWavePulses;

        public static void WriteToFile(string dataDirectory)
        {
            string waveFileBase = Path.Combine(dataDirectory, Path.Combine(WAVE_DIR, WAVE_FILE));

            timeStampPulses = PulsesHelper.GetFnclFlatFilePulses(Path.Combine(dataDirectory, TIMESTAMP)).GetPulses();
            int numberTimeStampPulses = timeStampPulses.Count;
            timeStampIndex = 0;
            numberWavePulses = 0;
            writeSideBySide = new StreamWriter(Path.Combine(dataDirectory, COMP_FILE));
            writeDiff = new StreamWriter(Path.Combine(dataDirectory, DIFF_FILE));
            //writeSideBySide.
            writeSideBySide.WriteLine("# Stamp Det" + SEP + "Wave Det" + SEP + "Stamp Time" + SEP + "Wave Time");
            int i = 0;
            bool fileExists = true;
            while (fileExists)
            {
                string waveFile = waveFileBase + i.ToString() + WAVE_EXT;
                writeDiff.WriteLine("WaveFile: " + i);
                writeSideBySide.WriteLine("WaveFile: " + i);
                i++;
                if (File.Exists(waveFile))
                {
                    CompareWaveToTimeStamp(PulsesHelper.GetFnclBinaryFilePulses(waveFile).GetPulses());
                }
                else
                {
                    fileExists = false;
                }
            }

            writeSideBySide.Close();
            writeDiff.Close();
            int pulseDiff = numberTimeStampPulses - numberWavePulses;
        }

        private static void CompareWaveToTimeStamp(List<FnclPulse> wave)
        {
            numberWavePulses += wave.Count;
            timeOffset = timeStampPulses[timeStampIndex].GetTime() - wave.First().GetTime();
            foreach (var w in wave)
            {
                var timePulse = timeStampPulses[timeStampIndex];
                double waveFormTime = w.GetTime() + timeOffset;
                if (Math.Abs(waveFormTime - timePulse.GetTime()) > TOL)
                {
                    writeDiff.WriteLine(timePulse.GetTime() - waveFormTime);
                }

                writeSideBySide.WriteLine(timePulse.GetDetector() + SEP + w.GetDetector() + SEP + timePulse.GetTime() +
                                          SEP + waveFormTime);
                timeStampIndex++;
            }

            //if (wave.Count > 0)
            //{
            //    lastWaveFormTime = wave.Last().GetTime();
            //}
        }
    }
}
