using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeometrySampling;
using Multiplicity;

namespace Runner
{
    public struct HeatMap<T>
    {
        public List<List<T>> Map;
        public List<T> VerticalBounds;
        public List<T> HozizontalBounds;
    }

    public struct Spectrum<T>
    {
        public List<T> HorizontalBins;
        public List<int> Counts;
    }

    public class PulseHeightSpectrum
    {
        private List<IPulseHeight> pulses;
        private readonly int nBins;
        private Bounds<int>[] binBounds;

        private PulseHeightSpectrum(Pulses<IPulseHeight> Pulses, int NumberOfBins) : this(Pulses.GetPulses(),
            NumberOfBins)
        {
        }

        public PulseHeightSpectrum(List<IPulseHeight> Pulses, int NumberOfBins)
        {
            pulses = Pulses;
            nBins = NumberOfBins;
        }

        public Spectrum<double> GetSpectrum()
        {
            Spectrum<double> spectrum = new Spectrum<double>();
            binBounds = new Bounds<int>[nBins];


            return spectrum;
        }
    }


    public static class PulseHeightWaveHelper
    {
        private const char COMMENT = '#';
        private const char SEP = '\t';

        public static Spectrum<double> GetPulseHeightSpectrum<TPulse>(List<TPulse> pulses, int nBins)
            where TPulse : IPulseHeight
        {
            Bounds<double>[] binBounds = GetBounds(pulses, nBins);
            int[] counts = new int[nBins];
            foreach (var p in pulses)
            {
                counts[GetBin(p.GetPulseHeightKeVee(), binBounds)]++;
            }

            return new Spectrum<double> {HorizontalBins = ConvertBoundsToList(binBounds), Counts = counts.ToList()};
        }

        public static HeatMap<double> GetPulseWaveFormHeatMap<TPulse>(List<TPulse> pulses, int nBins)
            where TPulse : IPulseWaveform
        {
            double[,] heatMap = new double[FnclPulse.NSAMPLES, nBins];
            Bounds<double>[] binBounds = GetBounds(pulses, nBins);
            foreach (var p in pulses)
            {
                AddPulseToHeatMap(p, ref heatMap, binBounds);
            }

            return new HeatMap<double>()
            {
                Map = MakeList(heatMap),
                VerticalBounds = ConvertBoundsToList(binBounds),
                HozizontalBounds = GetFnclHorizontalBounds()
            };
        }

        private static Bounds<double>[] GetBounds<TPulse>(List<TPulse> pulses, int nBins) where TPulse : IPulseHeight
        {
            double maxBin = double.MinValue;
            double minBin = double.MaxValue;
            foreach (var p in pulses)
            {
                double temp = p.GetPulseHeightKeVee();
                if (temp > maxBin)
                {
                    maxBin = temp;
                }

                if (temp < minBin)
                {
                    minBin = temp;
                }
            }

            return MakeBins(minBin, maxBin, nBins);
        }


        private static Bounds<double>[] GetBounds(List<IPulseWaveform> pulses, int nBins)
        {
            int maxBin = int.MinValue;
            int minBin = int.MaxValue;

            foreach (var p in pulses)
            {
                int tempMax = (int)p.GetPulseHeightKeVee();
                int tempMin = (int)p.GetAdcPulseMin();
                if (tempMax > maxBin)
                {
                    maxBin = tempMax;
                }

                if (tempMin < minBin)
                {
                    minBin = tempMin;
                }
            }

            return MakeBins(minBin, maxBin, nBins);
        }

        private static Bounds<double>[] MakeBins(double minBin, double maxBin, int nBins)
        {
            Bounds<double>[] binBounds = new Bounds<double>[nBins];
            double deltaBin = (maxBin - minBin) / nBins;
            binBounds[0] = new Bounds<double>(minBin, minBin + deltaBin);
            for (int i = 1; i < nBins; i++)
            {
                binBounds[i] = new Bounds<double>(binBounds[i - 1].Upper, binBounds[i - 1].Upper + deltaBin);
            }

            return binBounds;
        }

        private static List<List<double>> MakeList(double[,] heatMap)
        {
            List<List<double>> heatMapList = new List<List<double>>();

            for (int i = 0; i < heatMap.GetLength(0); i++)
            {
                List<double> rowList = new List<double>();
                for (int j = 0; j < heatMap.GetLength(1); j++)
                {
                    rowList.Add(heatMap[i, j]);
                }

                heatMapList.Add(rowList);
            }

            return heatMapList;
        }

        private static List<double> GetFnclHorizontalBounds()
        {
            double[] hBounds = new double[FnclPulse.NSAMPLES + 1];
            hBounds[0] = 0;
            for (int i = 1; i <= FnclPulse.NSAMPLES; i++)
            {
                hBounds[i] = FnclPulse.SampleTimeNanoSec * i;
            }

            return hBounds.ToList();
        }

        private static List<double> ConvertBoundsToList(Bounds<double>[] binBounds)
        {
            double[] vBounds = new double[binBounds.Length + 1];
            for (int i = 0; i < binBounds.Length; i++)
            {
                vBounds[i] = binBounds[i].Lower;
            }

            vBounds[binBounds.Length] = binBounds.Last().Upper;
            return vBounds.ToList();
        }

        private static void AddPulseToHeatMap(IPulseWaveform fnclPulse, ref double[,] heatMap,
            Bounds<double>[] binBounds)
        {
            int horizIndex = 0;

            foreach (var h in fnclPulse.GetAdcWaveform())
            {
                heatMap[horizIndex, GetBin(h, binBounds)]++;
                horizIndex++;
            }
        }

        private static int GetBin(in double height, Bounds<double>[] binBounds)
        {
            for (int i = 0; i < binBounds.Length; i++)
            {
                if (binBounds[i].BoundsValue(height))
                {
                    return i;
                }
            }

            if (height > binBounds.Last().Upper)
            {
                return binBounds.Length - 1;
            }

            return 0;
        }

        public static void SaveHeatMap<T>(string file, HeatMap<T> heatMap, string comment = "")
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(CommentLine(comment));
                sw.WriteLine(CommentLine(DateTime.Now.ToString()));
                sw.WriteLine(CommentLine("Vertical Bounds"));
                WriteArray(sw, heatMap.VerticalBounds);
                sw.WriteLine(CommentLine("Horizontal Bounds"));
                WriteArray(sw, heatMap.HozizontalBounds);
                sw.WriteLine(CommentLine("Heat Map"));
                WriteMatrix(sw, heatMap.Map);
            }
        }

        public static void SavePulseHeightSpectrum<T>(string file, Spectrum<T> spectrum, string comment = "")
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(CommentLine(comment));
                sw.WriteLine(CommentLine(DateTime.Now.ToString()));
                sw.WriteLine(CommentLine("Pulse Height Bounds"));
                WriteArray(sw, spectrum.HorizontalBins);
                sw.WriteLine(CommentLine("Pulse Height Counts"));
                WriteArray(sw, spectrum.Counts);
            }
        }

        private static void WriteMatrix<T>(StreamWriter sw, List<List<T>> matrixList)
        {
            foreach (var row in matrixList)
            {
                WriteArray(sw, row);
            }
        }

        private static void WriteArray<T>(StreamWriter sw, List<T> list)
        {
            string line = string.Empty;
            foreach (var a in list)
            {
                line += a.ToString() + SEP;
            }

            sw.WriteLine(line.TrimEnd(SEP));
        }

        private static string CommentLine(string line)
        {
            return COMMENT.ToString() + " " + line;
        }
    }
}
