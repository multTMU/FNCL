using System;
using System.Collections.Generic;
using System.IO;
using GeometrySampling;
using Multiplicity.PulseFilters;

namespace Multiplicity
{
    public static partial class PulsesHelper
    {
        public struct PoliMiSimulations
        {
            public string PulseFile { get; set; }
            public double ActivityBqs { get; set; }
            public int McnpNPS { get; set; }

            private const string POLIMI_SPEC = "poliMiSpecs.txt";

            public PoliMiSimulations(string pulseFile, int mcnpNPS, double activityBqs)
            {
                PulseFile = pulseFile;
                McnpNPS = mcnpNPS;
                ActivityBqs = activityBqs;
            }

            public void WriteToFile()
            {
                using (StreamWriter sw = new StreamWriter(GetSaveFile()))
                {
                    sw.WriteLine(this.ActivityBqs);
                    sw.WriteLine(this.McnpNPS);
                    sw.WriteLine(this.PulseFile);
                }
            }

            public PoliMiSimulations(string poliMiPulseFile)
            {
                using (StreamReader sr = new StreamReader(GetSaveFile(poliMiPulseFile)))
                {
                    this.ActivityBqs = double.Parse(sr.ReadLine());
                    this.McnpNPS = int.Parse(sr.ReadLine());
                    this.PulseFile = sr.ReadLine();
                }
            }

            private string GetSaveFile()
            {
                return GetSaveFile(this.PulseFile);
            }

            private static string GetSaveFile(string poliMiFile)
            {
                return Path.Combine(Path.GetDirectoryName(poliMiFile), POLIMI_SPEC);
            }
        }

        public static Pulses<PoliMiPulse> GetCombinedPulses(List<PoliMiSimulations> Simulations, int Seed)
        {
            return new CombinedPoliMiPulses(Simulations, Seed);
        }

        public static Pulses<PoliMiPulse> GetFnclDefaultsCombinedPulses(List<PoliMiSimulations> Simulations, int Seed)
        {
            return new FnclDefaultsCombinedPoliMiPulses(Simulations, Seed);
        }

        private class FnclDefaultsCombinedPoliMiPulses : CombinedPoliMiPulses
        {
            public FnclDefaultsCombinedPoliMiPulses(List<PoliMiSimulations> Simulations, int Seed) : base(Simulations,
                Seed)
            {
            }

            protected override List<IPulseFilter<PoliMiPulse>> GetFilters()
            {
                return GetFnclPostHistoryFilters();
            }
        }

        public static double GetCountTimePoliMiNanoSec(List<PoliMiSimulations> Simulations)
        {
            return GetCountTimePoliMiNanoSec(Simulations, new Random());
        }

        private static double GetCountTimePoliMiNanoSec(List<PoliMiSimulations> Simulations, Random rand)
        {
            double maxValue = double.MaxValue;
            foreach (var s in Simulations)
            {
                double maxTemp =
                    PoliMiHistoryFilter.SampleMeasurementTimeNanoSec(s.ActivityBqs, s.McnpNPS, rand);
                if (maxTemp < maxValue)
                {
                    maxValue = maxTemp;
                }
            }

            return maxValue;
        }

        private class CombinedPoliMiPulses : Pulses<PoliMiPulse>
        {
            private const string NO_SINGLE_FILE = "";
            private const bool NOT_BIG_FILE = false;
            private readonly List<PoliMiSimulations> simulations;
            private readonly Bounds<double> timeBounds;
            private readonly Random rand;

            public CombinedPoliMiPulses(List<PoliMiSimulations> Simulations, int Seed) : base(NO_SINGLE_FILE,
                NOT_BIG_FILE, PulseFileType.PoliMi)
            {
                simulations = Simulations;
                rand = new Random(Seed);
                timeBounds = new Bounds<double>(0, GetMeasurementTime());
                CombinePulses();
            }

            private void CombinePulses()
            {
                foreach (var s in simulations)
                {
                    Pulses<PoliMiPulse> subPulses = GetPoliMiPulses(s.PulseFile);
                    subPulses.RunExternalFilter(new PoliMiHistoryFilter(s.ActivityBqs, s.McnpNPS, rand.Next()));
                    subPulses.RunExternalFilter(new TimeCutFilter<PoliMiPulse>(timeBounds));
                    this.AddPulses(subPulses.GetPulses());
                }
            }

            private double GetMeasurementTime()
            {
                return GetCountTimePoliMiNanoSec(simulations, rand);
            }
        }
    }
}
