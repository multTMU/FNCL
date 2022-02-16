using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;
using Multiplicity;

namespace Runner
{
    public readonly struct DetectorResponse
    {
        public readonly double Response;
        public readonly Bounds<double> EnergyBounds;

        public DetectorResponse(Bounds<double> energyBounds, double response)
        {
            EnergyBounds = energyBounds;
            Response = response;
        }
    }

    public class DetectorResponseFunction
    {
        private struct DrfProblem
        {
            public string PulseFile;
            public Bounds<double> EnergyBounds;

            public DrfProblem(string pulseFile, Bounds<double> energyBounds)
            {
                PulseFile = pulseFile;
                EnergyBounds = energyBounds;
            }
        }

        private readonly struct DetectorResponseWithKey<TKey>
        {
            public readonly DetectorResponse Drf;
            public readonly TKey DrfKey;

            public DetectorResponseWithKey(TKey key, DetectorResponse drf)
            {
                DrfKey = key;
                Drf = drf;
            }
        }

        private readonly RunFnclDetector fnclModel;
        private readonly List<Bounds<double>> neutronBounds;
        private readonly Point3D sourceLocation;

        private const PoliMiSource Source = PoliMiSource.None;
        private const string DRF_DIR = "_DRFgroup_";

        private int nps;
        private List<DrfProblem> drfProblems;
        private readonly string basisName;

        public DetectorResponseFunction(RunFnclDetector FnclModel, Point3D PointSourceLocation,
            List<Bounds<double>> NeutronEnergyBounds, string BasisName)
        {
            fnclModel = FnclModel;
            sourceLocation = PointSourceLocation;
            neutronBounds = NeutronEnergyBounds;
            basisName = BasisName;
        }

        public DetectorResponseFunction(RunFnclDetector FnclModel, Point3D PointSourceLocation,
            string NeutronBoundaryFile, string BasisName) : this(FnclModel, PointSourceLocation,
            DetectorResponseFunctionHelper.GetNeutronBoundsFromFlatFile(NeutronBoundaryFile), BasisName)
        {
        }

        public void RunMCNPandMPPost(int mcnpNPS, string TopDirectory, bool runParallel,
            Particle particleInProbelm = Particle.Neutron)
        {
            nps = mcnpNPS;
            drfProblems = new List<DrfProblem>();
            int nBound = 0;
            foreach (var energies in neutronBounds)
            {
                fnclModel.OverrideComponentSource(GetSourceSpecifaction(energies));
                fnclModel.MakeMCNPfiles(Path.Combine(TopDirectory, basisName + DRF_DIR + nBound.ToString()), nps,
                    particleInProbelm);
                drfProblems.Add(new DrfProblem(fnclModel.GetLatestPulseFile(), energies));
                nBound++;
            }

            fnclModel.RunPoliMiandMPPost(runParallel);
        }

        public Dictionary<TKey, List<DetectorResponse>> GetDetectorResponseFunctions<TKey>(
            Dictionary<TKey, List<int>> drfCombinations)
        {
            List<DetectorResponseWithKey<TKey>> tempDrf = new List<DetectorResponseWithKey<TKey>>();

            foreach (var p in drfProblems)
            {
                Pulses<PoliMiPulse> pulsesBase = PulsesHelper.GetNeutronPulsesFromPoliMi(p.PulseFile);
                foreach (var kp in drfCombinations)
                {
                    Pulses<PoliMiPulse> pulses = pulsesBase.Clone();
                    pulses.RunExternalFilter(new Multiplicity.PulseFilters.FilterByDetector<PoliMiPulse>(kp.Value));
                    tempDrf.Add(new DetectorResponseWithKey<TKey>(kp.Key,
                        new DetectorResponse(p.EnergyBounds, GetEfficiency(pulses))));
                }
            }

            return GetDictionary(tempDrf);
        }

        private Dictionary<TKey, List<DetectorResponse>> GetDictionary<TKey>(
            List<DetectorResponseWithKey<TKey>> tempDrf)
        {
            Dictionary<TKey, List<DetectorResponse>> drf = new Dictionary<TKey, List<DetectorResponse>>();
            foreach (DetectorResponseWithKey<TKey> d in tempDrf)
            {
                if (drf.ContainsKey(d.DrfKey))
                {
                    drf[d.DrfKey].Add(d.Drf);
                }
                else
                {
                    drf.Add(d.DrfKey, new List<DetectorResponse>() {d.Drf});
                }
            }

            return drf;
        }

        private double GetEfficiency(Pulses<PoliMiPulse> pulses)
        {
            return (double)pulses.NumberOfPulses / nps;
        }

        private SourceSpecification GetSourceSpecifaction(Bounds<double> energies)
        {
            return new SourceSpecification(Source,
                SourcesHelper.GetUniformRangePointSource(sourceLocation, energies.Lower, energies.Upper));
        }
    }

    public static class DetectorResponseFunctionHelper
    {
        private const string SEP = "\t";

        public static Dictionary<string, List<int>> GetDictionaryForDetectorSummed()
        {
            Dictionary<string, List<int>> drfDictionary = new Dictionary<string, List<int>>();
            drfDictionary.Add("All Detectors", FnclHelpers.GetPoliMiDetectors());
            return drfDictionary;
        }

        public static Dictionary<string, List<int>> GetDictionaryForeachDetector()
        {
            Dictionary<string, List<int>> drfDictionary = new Dictionary<string, List<int>>();
            foreach (var d in FnclHelpers.GetPoliMiDetectors())
            {
                drfDictionary.Add("Detector " + d, new List<int>() {d});
            }

            return drfDictionary;
        }

        public static Dictionary<string, List<int>> GetDictionaryForPanel()
        {
            return FnclHelpers.GetDefaultCrossTalkDictionaryPoliMi();
        }

        public static Dictionary<string, List<int>> GetDictionaryForTotalPanelDetector()
        {
            Dictionary<string, List<int>> totalDictionary = GetDictionaryForDetectorSummed();
            AppendToDictionary(GetDictionaryForPanel(), ref totalDictionary);
            AppendToDictionary(GetDictionaryForeachDetector(), ref totalDictionary);
            return totalDictionary;
        }

        private static void AppendToDictionary(Dictionary<string, List<int>> tempDictionary,
            ref Dictionary<string, List<int>> totalDictionary)
        {
            foreach (var d in tempDictionary)
            {
                totalDictionary.Add(d.Key, d.Value);
            }
        }

        public static List<Bounds<double>> GetNeutronBoundsFromFlatFile(string file)
        {
            List<double> energies = new List<double>();
            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        energies.Add(double.Parse(sr.ReadLine()));
                    }
                }
            }

            return ChangeListToBounds(energies);
        }

        public static void WriteDictionaryDRFtoFile<TKey>(string file, Dictionary<TKey, List<DetectorResponse>> drf)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var d in drf)
                {
                    sw.Write(d.Key + SEP);
                    foreach (var e in d.Value)
                    {
                        sw.Write("(" + e.EnergyBounds.Lower + "," + e.EnergyBounds.Upper + ")" + SEP + e.Response +
                                 SEP);
                    }

                    sw.Write(Environment.NewLine);
                }
            }
        }

        public static void WriteDRFtoFile<TKey>(string file, Dictionary<TKey, List<DetectorResponse>> drf)
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                List<Bounds<double>> energyBounds = new List<Bounds<double>>();

                foreach (var e in drf.First().Value)
                {
                    energyBounds.Add(e.EnergyBounds);
                }


                sw.Write("Energy Bounds");
                foreach (var e in ChangeBoundsToList(energyBounds))
                {
                    sw.Write(SEP + e.ToString());
                }

                sw.Write(Environment.NewLine);


                foreach (var d in drf)
                {
                    sw.Write(d.Key);
                    foreach (var e in d.Value)
                    {
                        sw.Write(SEP + e.Response);
                    }

                    sw.Write(Environment.NewLine);
                }
            }
        }

        private static List<double> ChangeBoundsToList(List<Bounds<double>> bounds)
        {
            List<double> energies = new List<double>();

            foreach (var b in bounds)
            {
                energies.Add(b.Lower);
            }

            energies.Add(bounds.Last().Upper);
            return energies;
        }

        private static List<Bounds<double>> ChangeListToBounds(List<double> energies)
        {
            List<Bounds<double>> bounds = new List<Bounds<double>>();
            energies.Sort();

            for (int i = 1; i < energies.Count; i++)
            {
                bounds.Add(new Bounds<double>(SourcesHelper.eVtoMeV(energies[i - 1]),
                    SourcesHelper.eVtoMeV(energies[i])));
            }

            return bounds;
        }
    }
}
