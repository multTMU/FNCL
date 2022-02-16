using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using FastNeutronCollar;
using GeometrySampling;
using GlobalHelpers;
using GlobalHelpersDefaults;
using GuiInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multiplicity;
using Multiplicity.PulseFilters;
using PoliMiRunner;
using Runner;

namespace Tests
{
    public static class Helpers
    {
        public const double TOL = 1e-1;

        public const string TEST_DATA_DIR =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles";

        public const string CONFIG_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\Config.xml";

        public const string PULSE_FILE = "BeRPdetOrgScint_All_pulses.o";
        public const string DETECTOR_FILE = "detectorLiqScint.txt";
        public const string BASIS_FILE = "UnclLiquidBasis.inp";

        public const string POLIMI_EXE = @"C:\ornldev\code\MCNPpolimi\bin\Win\mcnpx_polimi_v270_v200.exe";
        public const string MPPOST_EXE = @"C:\MPPost\bin\MPPost_win64.exe";

        public const string SETTINGS_FILE =
            @"C:\Users\9eo\OneDrive - Oak Ridge National Laboratory\FNCLdocs\Cf252_6081\PB\settings.xml";

        public static string GetFullPathToTestData(string file)
        {
            return Path.Combine(TEST_DATA_DIR, file);
        }
    }

    [TestClass]
    public class PulseTests
    {
        public string pulseFile = Helpers.GetFullPathToTestData(Helpers.PULSE_FILE);


        [TestMethod]
        public void AllPulsesFileExists()
        {
            Assert.IsTrue(File.Exists(pulseFile));
        }

        [TestMethod]
        public void Read_PhotonPulsesFile()
        {
            Pulses<PoliMiPulse> pulses = PulsesHelper.GetPhotonPulsesFromPoliMi(pulseFile);
            Assert.IsTrue(pulses != null);
        }

        [TestMethod]
        public void Read_NeutronPulsesFile_MultiplePulses()
        {
            Pulses<PoliMiPulse> pulses = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile);
            Assert.IsTrue(pulses.NumberOfPulses > 0);
        }


        [TestMethod]
        public void GetNeutronMultiplicityDistribution_FixedGate()
        {
            Pulses<PoliMiPulse> neutron = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile);
            int gateWidth = 128;
            IMultiplicityGate
                multDist = MultiplicityGatesHelper.GetMultiplicityGate(MultiplicityGateType.Sequential,
                    neutron); // new SequentialGates<PoliMiPulse>(neutron));
            multDist.RunForGateWidth(gateWidth);
            MultiplicityDistribution distribution = multDist.GetRealsAccidentals();

            Assert.IsTrue(distribution.MaxMultiplicity > 0);
        }

        [TestMethod]
        public void GetNeutronMultiplicityDistribution_Triggered()
        {
            Pulses<PoliMiPulse> neutron = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile);
            int gateWidth = 128000;
            IMultiplicityGate multDist =
                MultiplicityGatesHelper.GetMultiplicityGate(MultiplicityGateType.ShiftRegister, neutron);
            multDist.RunForGateWidth(gateWidth);
            MultiplicityDistribution distribution = multDist.GetRealsAccidentals();

            Assert.IsTrue(distribution.MaxMultiplicity > 0);
        }

        [TestMethod]
        public void GetNeutronMultiplicityDistribution_ShiftRegister()
        {
            Pulses<PoliMiPulse> neutron = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile);
            int gateWidth = 16000;
            int preDelay = 500;
            int longDelay = 128000;
            IMultiplicityGate multDist = MultiplicityGatesHelper.GetMultiplicityGate(neutron, preDelay, longDelay);

            MultiplicityRates rates = MultiplicityRatesHelper<PoliMiPulse>.GetMultiplicityRates(multDist, gateWidth);
            MultiplicityDistribution distribution = multDist.GetRealsAccidentals();

            Assert.IsTrue(distribution.MaxMultiplicity > 0);
            Assert.IsTrue(rates.Singles != 0);
            Assert.IsTrue(rates.Doubles != 0);
            Assert.IsTrue(rates.Triples != 0);
        }

        [TestMethod]
        public void GetDoublesMatrix()
        {
            Pulses<PoliMiPulse> neutron = PulsesHelper.GetNeutronPulsesFromPoliMi(
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\liquidNotGrouped_All_pulses.o");
            int gateWidth = 16000;
            int preDelay = 500;
            int longDelay = 128000;

            List<int> detectors = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                detectors.Add(i);
            }

            var dMatrix =
                MultipletMatricesHelper<PoliMiPulse>.GetMultipletRatesMatrix(neutron, detectors, preDelay, longDelay,
                    gateWidth);

            var dKeyA = dMatrix[new DoublesKey(1, 2)];
            var dKeyB = dMatrix[new DoublesKey(2, 1)];

            Assert.AreEqual(dKeyA, dKeyB);
            Assert.IsTrue(dMatrix.Count == 6);
        }

        [TestMethod]
        public void MultipletRateSubraction()
        {
            MultiplicityRates A = new MultiplicityRates
            {
                GateWidth = 10,
                CountTime = 10,
                Singles = 10,
                Doubles = 10,
                Triples = 10
            };
            MultiplicityRates B = new MultiplicityRates
            {
                GateWidth = 1,
                CountTime = 1,
                Singles = 1,
                Doubles = 1,
                Triples = 1
            };

            MultiplicityRates C = A - B;
            Assert.IsTrue(C.Singles == 9);
            string testString = C.ToString();
        }

        [TestMethod]
        public void ReadFNCLpulsesTimeStampFile()
        {
            string pulseFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCLdata\JANY\PB\TimestampList.txt";
            Pulses<Pulse> fncl = PulsesHelper.GetFnclFlatFilePulses(pulseFile);
            //
            int gateWidth = (int)1.6e4;
            int preDelay = (int)5.0e2;
            int longDelay = (int)2.56e5;
            IMultiplicityGate multDist = MultiplicityGatesHelper.GetMultiplicityGate(fncl, preDelay, longDelay);

            MultiplicityRates rates = MultiplicityRatesHelper<Pulse>.GetMultiplicityRates(multDist, gateWidth);
            MultiplicityDistribution distribution = multDist.GetReals();

            Assert.IsTrue(distribution.MaxMultiplicity > 0);
            Assert.IsTrue(rates.Singles != 0);
            Assert.IsTrue(rates.Doubles != 0);
            Assert.IsTrue(rates.Triples != 0);
        }

        [TestMethod]
        public void ReadFNCLpulsesFromBinaryFile()
        {
            string pulseFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCL_DAQ_0.bin";
            Pulses<FnclPulse> fncl = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);
            Assert.IsTrue(fncl.NumberOfPulses > 100);
        }

        [TestMethod]
        public void MakePulseHeatMap()
        {
            string pulseFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCL_DAQ_0.bin";
            HeatMap<double> heatMap =
                PulseHeightWaveHelper.GetPulseWaveFormHeatMap(PulsesHelper.BinaryFileHelper.GetPulses(pulseFile), 50);
            string waveFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCL_DAQ_0WAVE.txt";
            PulseHeightWaveHelper.SaveHeatMap(waveFile, heatMap, "UNIT TEST");
        }

        [TestMethod]
        public void MakePulseHeightSpectrum()
        {
            string pulseFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCL_DAQ_0.bin";

            var spectrum =
                PulseHeightWaveHelper.GetPulseHeightSpectrum(PulsesHelper.BinaryFileHelper.GetPulses(pulseFile), 100);
            string file =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCL_DAQ_0SPECTRUM.txt";
            PulseHeightWaveHelper.SavePulseHeightSpectrum(file, spectrum, "UNIT TEST");
        }

        [TestMethod]
        public void MakePulseShapeDiscriminations()
        {
            string pulseFile =
                @"E:\FNCLdata\mp320ExtraPE7_8_21\SESSION_0\EXAM\NBL\IM\DAQ\FNCL_DAQ_5.bin";
            Pulses<FnclPulse> pulses = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);

            double firstTime = pulses.GetTimeOfFirstPulse();
            double lastPulse = pulses.GetTimeOfLastPulse();
            int i = 0;
            int j = 0;
            foreach (var p in pulses.GetPulses())
            {
                double curTime = p.GetTime();
                if (curTime < firstTime)
                {
                    //  Assert.Inconclusive("Time stamp madness on pulse " + i);
                    j++;
                }

                i++;
            }

            Assert.Inconclusive("Time stamp madness on pulses happened " + j);
        }

        [TestMethod]
        public void FnclWavePulseTimeLoopsMaxTime()
        {
            string pulseFile =
                @"E:\FNCLdata\mp320ExtraPE7_8_21\SESSION_0\EXAM\NBL\IM\DAQ\FNCL_DAQ_2.bin";
            Pulses<FnclPulse> pulses = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);

            double maxTime = -1;
            foreach (var p in pulses.GetPulses())
            {
                double time = p.GetTime();
                if (time > maxTime)
                {
                    maxTime = time;
                }
            }

            Assert.IsTrue(maxTime > UInt32.MaxValue);
        }

        [TestMethod]
        public void FnclPositiveTimesOnly()
        {
            string pulseFile =
                @"E:\FNCLdata\mp320ExtraPE7_8_21\SESSION_0\EXAM\NBL\IM\DAQ\FNCL_DAQ_1.bin";
            Pulses<FnclPulse> pulses = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);
            int i = 0;
            foreach (var p in pulses.GetPulses())
            {
                if (p.GetTime() < 0)
                {
                    Assert.IsTrue(false);
                }

                i++;
            }

            Assert.IsTrue(true);
        }


        [TestMethod]
        public void FnclMonotonicTimes()
        {
            string pulseFile =
                @"E:\FNCLdata\mp320ExtraPE7_8_21\SESSION_0\EXAM\NBL\IM\DAQ\FNCL_DAQ_1.bin";
            Pulses<FnclPulse> pulses = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);

            double last = double.MinValue;
            int i = 0;
            foreach (var p in pulses.GetPulses())
            {
                double time = p.GetTime();
                if (time < last)
                {
                    Assert.IsTrue(false);
                }
                else
                {
                    last = time;
                }

                i++;
            }

            Assert.IsTrue(true);
        }

        //[TestMethod]
        //public void TestSaveFnclPulsesAsFlat()
        //{
        //    string pulseDir =
        //        @"E:\FNCLdata\mp320ExtraPE7_8_21\SESSION_0\EXAM\NblBlank\PB\DAQ\";
        //    string saveFile = Path.Combine(pulseDir, "TestSaveFlat.txt");
        //    PulsesHelper.SaveBinaryFilesAsFlat(pulseDir, saveFile, new List<IPulseFilter<FnclPulse>>());
        //    Assert.IsTrue(File.Exists(saveFile));
        //}


        [TestMethod]
        public void ReadPoliMiForSingleNeutronMultiplieEvents()
        {
            string pulseFile = Helpers.GetFullPathToTestData("FakeMultipleEvents.txt");
            Pulses<Pulse> pulses = PulsesHelper.GetNeutronSingleDetectorEventsFromFnclFlat(pulseFile, timeVeto: 100);
            int gateWidth = (int)1.6e4;
            int preDelay = (int)5.0e2;
            int longDelay = (int)2.56e5;
            IMultiplicityGate multDist = MultiplicityGatesHelper.GetMultiplicityGate(pulses, preDelay, longDelay);

            MultiplicityRates rates = MultiplicityRatesHelper<Pulse>.GetMultiplicityRates(multDist, gateWidth);
            MultiplicityDistribution distribution = multDist.GetReals();

            Assert.IsTrue(distribution.MaxMultiplicity > 0);
            Assert.IsTrue(rates.Singles != 0);
            Assert.IsTrue(rates.Doubles != 0);
            Assert.IsTrue(rates.Triples != 0);
        }


        [TestMethod]
        public void ReadPoliMiForSingleNeutronMultiplieEventsInMultipleDetectors()
        {
            string pulseFile = Helpers.GetFullPathToTestData("FakeMultipleEventsCrossTalk.txt");

            Dictionary<string, List<int>> detectorPulsesBuffer = new Dictionary<string, List<int>>();
            detectorPulsesBuffer.Add("one", new List<int>() {0});
            detectorPulsesBuffer.Add("two", new List<int>() {1, 2});

            Pulses<Pulse> pulses =
                PulsesHelper.GetNeutronNoCrossTalkFnclFlat(pulseFile, detectorPulsesBuffer, timeVeto: 100);
            int gateWidth = (int)1.6e4;
            int preDelay = (int)5.0e2;
            int longDelay = (int)2.56e5;
            IMultiplicityGate multDist = MultiplicityGatesHelper.GetMultiplicityGate(pulses, preDelay, longDelay);

            MultiplicityRates rates = MultiplicityRatesHelper<Pulse>.GetMultiplicityRates(multDist, gateWidth);
            MultiplicityDistribution distribution = multDist.GetRealsAccidentals();

            Assert.IsTrue(distribution.MaxMultiplicity > 0);
            Assert.IsTrue(rates.Singles != 0);
            Assert.IsTrue(rates.Doubles != 0);
            Assert.IsTrue(rates.Triples != 0);
        }

        [TestMethod]
        public void FNCLcrosstalkFlatTest()
        {
            string pulseFile = @"E:\FNCLdata\FromOBrienTest2\EXAM\JANY3\IM\TimestampList.txt";
            //MultiplicityRates passive = GetRatesFlatFileCrosstalkFilter(GetPassiveFlatFile(dataDir), gateWidth, preDelay, longDelay, vetoGate, flatDictionary);
            Pulses<Pulse> pulses = PulsesHelper.GetNeutronNoCrossTalkFnclFlat(pulseFile,
                FnclHelpers.GetDefaultCrossTalkDictionary(), 14);
            IMultiplicityGate shiftRegister = MultiplicityGatesHelper.GetMultiplicityGate(pulses, 1000, 10000);
            MultiplicityRates rates = MultiplicityRatesHelper<Pulse>.GetMultiplicityRates(shiftRegister, 320);
            Assert.IsTrue(rates.Singles > 0);
        }

        [TestMethod]
        public void FlatTopFilter()
        {
            string pulseFile = @"E:\FNCLdata\mp320ExtraPE\SESSION_0\EXAM\NBL_Blank\IM\DAQ\FNCL_DAQ_199.bin";

            Pulses<FnclPulse> pulses = PulsesHelper.GetFnclBinaryFilePulses(pulseFile);

            Multiplicity.PulseFilters.PulseFlatTopFilter<FnclPulse> flatTop = new PulseFlatTopFilter<FnclPulse>(6, 95);
            var filtered = flatTop.GetFilteredPulses(pulses.GetPulses());

            Assert.IsTrue(filtered.Count < pulses.NumberOfPulses);
        }

        [TestMethod]
        public void TimeShiftDetectorTest()
        {
            string pulseFile = @"E:\FNCLdata\FromOBrienTest2\EXAM\JANY3\IM\TimestampList.txt";
            //MultiplicityRates passive = GetRatesFlatFileCrosstalkFilter(GetPassiveFlatFile(dataDir), gateWidth, preDelay, longDelay, vetoGate, flatDictionary);
            Pulses<Pulse> pulses = PulsesHelper.GetFnclFlatFilePulses(pulseFile);
            int nPulses = pulses.NumberOfPulses;
            List<Multiplicity.PulseFilters.DetectorTimeShift> shifts =
                new List<Multiplicity.PulseFilters.DetectorTimeShift>()
                {
                    new Multiplicity.PulseFilters.DetectorTimeShift(1, 100),
                    new Multiplicity.PulseFilters.DetectorTimeShift(2, -100)
                };
            Multiplicity.PulseFilters.TimeShiftDetectors<Pulse> timeShift =
                new Multiplicity.PulseFilters.TimeShiftDetectors<Pulse>(shifts);
            pulses.RunExternalFilter(timeShift);

            Assert.AreEqual(nPulses, pulses.NumberOfPulses);
        }


        [TestMethod]
        public void HistorySortedPoliMi()
        {
            string pulseFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\BeRPdetOrgScint_All_pulses.o";
            //double activityCi = 1e-3;
            double activity = 1e6; // PulsesHelper.ConvertCuriesToActivity(activityCi);
            Pulses<PoliMiPulse> pulses = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile);
            Multiplicity.PulseFilters.PoliMiHistoryFilter filter =
                new Multiplicity.PulseFilters.PoliMiHistoryFilter(activity, (int)1e6);
            pulses.RunExternalFilter(filter);
            IMultiplicityGate shift = MultiplicityGatesHelper.GetMultiplicityGate(pulses, 1, 10000);
            MultiplicityRates rates = MultiplicityRatesHelper<PoliMiPulse>.GetMultiplicityRates(shift, 1000);
            var newRates = rates.ConvertToSeconds();
            Assert.IsTrue(rates.Singles > 0);
        }

        [TestMethod]
        public void DefaultFnclPoliMiPulses()
        {
            // TODO needs to be real FNCL data, as only has 1 cell
            string pulseFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\BeRPdetOrgScint_All_pulses.o";
            double activity = 1e6;
            int mcnpNPS = (int)1e6;
            int seed = 5;
            Pulses<PoliMiPulse> pulses = PulsesHelper.GetDefaultFncLPoliMiPulses(pulseFile, activity, mcnpNPS, seed);
            var rates = MultiplicityRatesHelper<PoliMiPulse>.GetMultiplicityRates(
                MultiplicityGatesHelper.GetMultiplicityGate(pulses, FnclHelpers.PREDELAY_SEO,
                    FnclHelpers.LONGDELAY_SEO),
                (int)FnclHelpers.COINCIDENCE_INTERVAL);
            Assert.IsTrue(rates.Singles > 0);
        }

        [TestMethod]
        public void CombinePoliMiPulses()
        {
            List<PulsesHelper.PoliMiSimulations> problemsToCombine = new List<PulsesHelper.PoliMiSimulations>();
            PulsesHelper.PoliMiSimulations problemA = new PulsesHelper.PoliMiSimulations("fileA", (int)1e6, (int)1e6);
            PulsesHelper.PoliMiSimulations problemB = new PulsesHelper.PoliMiSimulations("fileB", (int)1e6, (int)1e5);
            problemsToCombine.Add(problemA);
            problemsToCombine.Add(problemB);
            Pulses<PoliMiPulse> pulses = PulsesHelper.GetCombinedPulses(problemsToCombine, (int)DateTime.Now.Ticks);
            var rates = MultiplicityRatesHelper<PoliMiPulse>.GetMultiplicityRates(
                MultiplicityGatesHelper.GetMultiplicityGate(pulses, FnclHelpers.PREDELAY_SEO,
                    FnclHelpers.LONGDELAY_SEO),
                (int)FnclHelpers.COINCIDENCE_INTERVAL);
            Assert.IsTrue(rates.Singles > 0);
        }

        [TestMethod]
        public void CombineFnclPoliMiPulses()
        {
            List<PulsesHelper.PoliMiSimulations> problemsToCombine = new List<PulsesHelper.PoliMiSimulations>();
            PulsesHelper.PoliMiSimulations problemA = new PulsesHelper.PoliMiSimulations("fileA", (int)1e6, (int)1e6);
            PulsesHelper.PoliMiSimulations problemB = new PulsesHelper.PoliMiSimulations("fileB", (int)1e6, (int)1e5);
            problemsToCombine.Add(problemA);
            problemsToCombine.Add(problemB);
            Pulses<PoliMiPulse> pulses =
                PulsesHelper.GetFnclDefaultsCombinedPulses(problemsToCombine, (int)DateTime.Now.Ticks);
            var rates = MultiplicityRatesHelper<PoliMiPulse>.GetMultiplicityRates(
                MultiplicityGatesHelper.GetMultiplicityGate(pulses, FnclHelpers.PREDELAY_SEO,
                    FnclHelpers.LONGDELAY_SEO),
                (int)FnclHelpers.COINCIDENCE_INTERVAL);
            Assert.IsTrue(rates.Singles > 0);
        }

        [TestMethod]
        public void RossiAlphaTest()
        {
            string pulseFile = @"E:\FNCLdata\FromOBrienTest2\EXAM\JANY3\IM\TimestampList.txt";
            //MultiplicityRates passive = GetRatesFlatFileCrosstalkFilter(GetPassiveFlatFile(dataDir), gateWidth, preDelay, longDelay, vetoGate, flatDictionary);
            Pulses<Pulse> pulses = PulsesHelper.GetFnclFlatFilePulses(pulseFile);
            var dist = TimeDistributions<Pulse>.GetIntervalDistribution(pulses);
        }
    }

    [TestClass]
    public class MultiplicityTests
    {
        [TestMethod]
        public void NoDistribution()
        {
            MultiplicityDistribution dist = new MultiplicityDistribution();
            Assert.IsTrue(dist.MaxMultiplicity == 0);
        }

        [TestMethod]
        public void AllZeroDistribution_MaxMultZero()
        {
            MultiplicityDistribution dist = new MultiplicityDistribution();
            for (int i = 1; i < 10; i++)
            {
                dist.AddMultiplicity(0);
            }

            Assert.IsTrue(dist.MaxMultiplicity == 0);
        }

        [TestMethod]
        public void DistributionGiven50_MaxMultIs50()
        {
            MultiplicityDistribution dist = new MultiplicityDistribution();
            for (int i = 1; i < 10; i++)
            {
                dist.AddMultiplicity(0);
            }

            dist.AddMultiplicity(50);
            Assert.IsTrue(dist.MaxMultiplicity == 50);
        }

        [TestMethod]
        public void DistributionGiven50_MaxMultIs50_DontAddMore()
        {
            MultiplicityDistribution dist = new MultiplicityDistribution();
            for (int i = 1; i < 10; i++)
            {
                dist.AddMultiplicity(0);
            }

            dist.AddMultiplicity(50);
            dist.AddMultiplicity(30);
            Assert.IsTrue(dist.MaxMultiplicity == 50);
        }

        [TestMethod]
        public void KnownDistriubtionsFromFile()
        {
            MultiplicityDistribution knownDistribution = new MultiplicityDistribution();
            using (StreamReader sr =
                new StreamReader(Helpers.GetFullPathToTestData("TestMultiplicityDistribution.txt")))
            {
                while (!sr.EndOfStream)
                {
                    knownDistribution.AddMultiplicity(int.Parse(sr.ReadLine()));
                }
            }

            FactorialMoments moments = FactorialMomentsHelper.GetFactorialMoments(knownDistribution);
            Assert.IsTrue(Math.Abs(moments.Mean - 2) < Helpers.TOL);
        }


        [TestMethod]
        public void PlotDistTest()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("n", typeof(int));
            dataTable.Columns.Add("p(n)", typeof(double));

            string pulseFile = Helpers.GetFullPathToTestData(Helpers.PULSE_FILE);
            Pulses<PoliMiPulse> neutron = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile);
            int gateWidth = 128;
            IMultiplicityGate multDist =
                MultiplicityGatesHelper.GetMultiplicityGate(MultiplicityGateType.ShiftRegister, neutron);
            multDist.RunForGateWidth(gateWidth);
            MultiplicityDistribution distribution = multDist.GetRealsAccidentals();

            var normDist = distribution.NormalizedDistribution;
            int n = 0;
            foreach (var d in normDist)
            {
                dataTable.Rows.Add(n, d);
                n++;
            }
        }

        [TestMethod]
        public void DieawayFitLinear()
        {
            int intercept = 2;
            int slope = -1;
            List<Tuple<double, double>> curve = new List<Tuple<double, double>>();
            for (int i = 0; i < 10; i++)
            {
                curve.Add(new Tuple<double, double>(i, intercept + slope * i));
            }

            var fit = CurveFitHelper.GetFit(CurveFitType.Linear, curve);
            List<double> fitParams = fit.GetFitParameters();
            Assert.AreEqual((int)fitParams.First(), intercept);
            Assert.AreEqual((int)fitParams.Last(), slope);
        }

        [TestMethod]
        public void DieawayFitExponent()
        {
            int amp = 2;
            int exp = -3;
            List<Tuple<double, double>> curve = new List<Tuple<double, double>>();
            for (int i = 0; i < 10; i++)
            {
                curve.Add(new Tuple<double, double>(i, amp * Math.Exp(exp * i)));
            }

            var fit = CurveFitHelper.GetFit(CurveFitType.SingleExponent, curve);
            List<double> fitParams = fit.GetFitParameters();
            Assert.AreEqual((int)fitParams.First(), amp);
            Assert.AreEqual((int)fitParams.Last(), exp);
        }

        [TestMethod]
        public void DieawayFitExponentNoise()
        {
            int amp = 2;
            int exp = 3;
            Random rand = new Random();

            double GetNoise()
            {
                return rand.NextDouble() * (1.01 - .99) + 0.99;
            }

            List<Tuple<double, double>> curve = new List<Tuple<double, double>>();
            for (int i = 0; i < 10; i++)
            {
                curve.Add(new Tuple<double, double>(i, amp * GetNoise() * Math.Exp(exp * i * GetNoise())));
            }

            var fit = CurveFitHelper.GetFit(CurveFitType.SingleExponent, curve);
            List<double> fitParams = fit.GetFitParameters();
            Assert.AreEqual((int)fitParams.First(), amp);
            Assert.AreEqual((int)fitParams.Last(), exp);
        }
    }

    [TestClass]
    public class TestPolimiRunner
    {
        private string basisFileWithPath = Helpers.GetFullPathToTestData(Helpers.BASIS_FILE);
        private string detectorFile = Helpers.GetFullPathToTestData(Helpers.DETECTOR_FILE);

        [TestMethod]
        public void FileExists()
        {
            Assert.IsTrue(File.Exists(basisFileWithPath));
        }

        [TestMethod]
        public void FileHasOneModRegion()
        {
            PoliMiInput runner = new PoliMiInput(basisFileWithPath, detectorFile);
            Assert.IsTrue(runner.NumberReplacementSections == 1);
        }

        //[TestMethod] // Passed but Made a method private
        //public void WriteToGap()
        //{
        //    PoliMiInput runner = new PoliMiInput(file);
        //    string outTest = Helpers.GetFullPathToTestData("writeToGap.inp");
        //    string fakeFill = "Sdef TEST";
        //    List<List<string>> fillText = new List<List<string>>();
        //    fillText.Add(new List<string>() { fakeFill });
        //    runner.WriteFile(outTest,fillText );
        //    Assert.IsTrue(File.Exists(outTest));
        //    bool foundFillText = false;
        //    using (StreamReader sr = new StreamReader(outTest))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            if (sr.ReadLine().Contains(fakeFill))
        //            {
        //                foundFillText = true;
        //                break;
        //            }
        //        }
        //    }
        //    Assert.IsTrue(foundFillText);
        //}

        [TestMethod]
        public void ReadReplacementFile()
        {
            string testFile = Helpers.GetFullPathToTestData("twoZoneReplacement.txt");
            var replacements = ReplacementFileHelper.GetReplacements(testFile);
            Assert.IsTrue(replacements.Count == 4);
        }

        [TestMethod]
        public void WritePoliMiInputs()
        {
            PoliMiInput runner = new PoliMiInput(basisFileWithPath, detectorFile);
            var filesMade = runner.WritePoliMiInputFiles(Helpers.GetFullPathToTestData("testFile_"),
                Helpers.GetFullPathToTestData("zoneOneReplacement.txt"));
            foreach (var f in filesMade)
            {
                Assert.IsTrue(File.Exists(f));
            }
        }

        [TestMethod]
        public void WritePoliMiInputsToOwnDirectories()
        {
            string saveDir = "RunTestTop";
            string topDir = Helpers.GetFullPathToTestData(saveDir);
            PoliMiInput runner = new PoliMiInput(basisFileWithPath, detectorFile);
            // var filesMade = runner.WritePoliMiInputFiles(Helpers.GetFullPathToTestData("testFile_"), Helpers.GetFullPathToTestData("zoneOneReplacement.txt"));
            var filesMade =
                runner.WriteEachInputFileToOwnDirectory(topDir,
                    Helpers.GetFullPathToTestData("zoneOneReplacement.txt"));
            foreach (var f in filesMade)
            {
                Assert.IsTrue(File.Exists(f));
            }
        }
    }

    [TestClass]
    public class PointCollectionTests
    {
        [TestMethod]
        public void GetPointsWithEndPoints()
        {
            DimensionRanger ranger = new DimensionRanger(0, 10, 3);
            var rangerPoints = ranger.GetValues();
            Assert.IsTrue(rangerPoints.Count == 5);
            Assert.IsTrue(rangerPoints.First() == 0);
            Assert.IsTrue(rangerPoints.Last() == 10);
        }

        [TestMethod]
        public void GetCartessianPoints()
        {
            CuboidRanger ranger = new CuboidRanger(new DimensionRanger(0, 10, 3), new DimensionRanger(0, 10, 3),
                new DimensionRanger(0, 10, 3));
            Assert.IsTrue(ranger.GetPointCollection().Count == 5 * 5 * 5);
        }
    }

    [TestClass]
    public class TopLevelTests
    {
        private const string WORK_DIR =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles";

        private const string BASIS_FILE = "UnclLiquidBasis.inp";
        private const string DETECTOR_FILE = "detector.txt";
        private const string POLIMI_EXE = @"C:\ornldev\code\MCNPpolimi\bin\Win\mcnpx_polimi_v270_v200.exe";
        private const string MPPOST_EXE = @"C:\MPPost\bin\MPPost_win64.exe";

        [TestMethod]
        public void RunSymmetricPointGeneratorOneReplacement()
        {
            string top = "c Source ";
            string bottom = "c source is PoliMi DD";
            CuboidRanger ddGeneratorBlockRanges = new CuboidRanger(new DimensionRanger(.1, 9.9, 3),
                new DimensionRanger(10.1, 19.9, 3), new DimensionRanger(.1, 9.9, 3));

            string nameBase = "DDlocation_";
            int i = 0;
            List<ReplacementText> replacements = new List<ReplacementText>();
            foreach (var s in SourcesHelper.GetPoliMiPointSourcePositions(ddGeneratorBlockRanges))
            {
                i++;
                ReplacementText replaceElement = new ReplacementText();
                replaceElement.Name = nameBase + i;

                List<string> replacementLines = new List<string>();
                replacementLines.Add(top);
                replacementLines.Add(s);
                replacementLines.Add(bottom);
                replaceElement.TextLists = new List<List<string>>();
                replaceElement.TextLists.Add(replacementLines);
                replacements.Add(replaceElement);
            }

            //  Assert.IsTrue(RunPoliMiAnalysis.RunEverything(WORK_DIR, RunPoliMiAnalysis.MakeFullPaths(WORK_DIR , BASIS_FILE), replacements, RunPoliMiAnalysis.MakeFullPaths(WORK_DIR, DETECTOR_FILE), POLIMI_EXE,
            //     MPPOST_EXE));
        }

        [TestMethod]
        public void ReadFnclSettingsFileForPSD()
        {
            try
            {
                FnclSettingsFileHelper.SetPsdCalibrationFromFnclSettings(Helpers.SETTINGS_FILE);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        //[TestMethod]
        //public void GetSettingsFileFromBinary()
        //{
        //    string binaryFile =
        //        @"C:\Users\9eo\OneDrive - Oak Ridge National Laboratory\FNCLdocs\Cf252_6081\PB\DAQ\FNCL_DAQ_0.bin";

        //    string settingsFile =
        //        @"C:\Users\9eo\OneDrive - Oak Ridge National Laboratory\FNCLdocs\Cf252_6081\PB\settings.xml";

        //    Assert.AreEqual(settingsFile, FnclSettingsFileHelper.GetSettingsFileFromBinary(binaryFile));
        //}
    }

    [TestClass]
    public class MaterialsTest
    {
        private const string ARRAY_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FuelArray.txt";

        private const string FUELCELL_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FuelCells.txt";

        private const string ALLFUELCELL_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\AllFuelCells.txt";

        [TestMethod]
        public void CorrectNumberOfFuelElemets()
        {
            FuelArray fuel = new FuelArray(ARRAY_FILE);
            Assert.AreEqual(fuel.NumberOfFuelElements, 17 * 17);
        }


        [TestMethod]
        public void WriteFuelCellsToFile()
        {
            FuelAssemblyComponent fuel = new FuelAssemblyComponent(ARRAY_FILE, false);
            //  FuelCellReplacements cells = new FuelCellReplacements(ARRAY_FILE);
            fuel.MakeCells();
            fuel.SaveCells(FUELCELL_FILE);
            Assert.IsTrue(File.Exists(FUELCELL_FILE));
        }

        [TestMethod]
        public void WriteFuelCellSpecToFile()
        {
            FuelAssemblyComponent fuel = new FuelAssemblyComponent(ARRAY_FILE, false);
            //FuelCellReplacements cells = new FuelCellReplacements(ARRAY_FILE);
            fuel.MakeCells();
            fuel.SaveCells(ALLFUELCELL_FILE);
            Assert.IsTrue(File.Exists(ALLFUELCELL_FILE));
        }
    }

    [TestClass]
    public class FormatMCNPoutput
    {
        [TestMethod]
        public void HandleShortLine()
        {
            string test = "This string is less than 80 characters long";
            List<string> formatTest = MCNPformatHelper.FormatLines(test);
            Assert.IsTrue(string.Equals(test, formatTest[0]));
        }

        [TestMethod]
        public void HandleStartComment()
        {
            List<string> test = new List<string>() {"c this string is a comment"};
            List<string> formatTest = MCNPformatHelper.FormatLines(test);
            Assert.IsTrue(test.Count == formatTest.Count);
            Assert.IsTrue(string.Equals(test[0], formatTest[0]));
        }

        [TestMethod]
        public void HandleInlineCommentShort()
        {
            List<string> test = new List<string>() {"this string has a comment $ that is within the character limit"};
            List<string> formatTest = MCNPformatHelper.FormatLines(test);
            Assert.IsTrue(test.Count == formatTest.Count);
            Assert.IsTrue(string.Equals(test[0], formatTest[0]));
        }

        [TestMethod]
        public void HandleInlineCommentLong()
        {
            List<string> test = new List<string>()
            {
                "this string has a comment that is outside the character limit but the text after it is beyond the max character range $ TOO LONG"
            };
            List<string> formatTest = MCNPformatHelper.FormatLines(test);
            Assert.IsTrue(test.Count != formatTest.Count);
        }

        [TestMethod]
        public void WrapLineWithoutComments()
        {
            List<string> test = new List<string>()
            {
                "this line is too long, it needs to be wrapped into two lines that does not interrupt a block of text"
            };

            List<string> desired = new List<string>()
            {
                "this line is too long, it needs to be wrapped into two lines that does not ",
                "     interrupt a block of text"
            };

            List<string> formatTest = MCNPformatHelper.FormatLines(test);
            Assert.IsTrue(string.Equals(desired[0], formatTest[0]) && string.Equals(desired[1], formatTest[1]));
        }

        [TestMethod]
        public void WrapLineWithComments()
        {
            List<string> test = new List<string>()
            {
                "this line is too long, it needs to be wrapped into two lines that does not interrupt a block of text",
                "c abcd",
                "this line is too long, it needs to be wrapped into two lines that does not interrupt a block of text $ this line is too long, it needs to be wrapped into two lines that does not interrupt a block of text"
            };

            List<string> desired = new List<string>()
            {
                "this line is too long, it needs to be wrapped into two lines that does not ",
                "     interrupt a block of text",
                "c abcd",
                "this line is too long, it needs to be wrapped into two lines that does not ",
                "     interrupt a block of text $ this line is too long, it needs to be wrapped into two lines that does not interrupt a block of text"
            };

            List<string> formatTest = MCNPformatHelper.FormatLines(test);
            Assert.IsTrue(string.Equals(desired[0], formatTest[0]) && string.Equals(desired[1], formatTest[1]));
        }
    }

    [TestClass]
    public class MaterialManager
    {
        private const string CONFIG_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\Config.xml";

        private const string MATCARD_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\MaterialCard.txt";

        [TestMethod]
        public void GetMaterial()
        {
            var mat = GlobalHelpers.MaterialManager.GetMaterial(1);
            Assert.IsTrue(mat.MaterialIndex == 200);
        }

        [TestMethod]
        public void WriteMaterialCard()
        {
            var config = ProblemConfigurationHelper.GetConfig(CONFIG_FILE);
            ConfigureDictionaries.InitializeDictionaries();//config.DataDirectory);
            GlobalHelpers.MaterialManager.ClearMaterialsUsed();
            var mat = GlobalHelpers.MaterialManager.GetMaterial(1);
            mat = GlobalHelpers.MaterialManager.GetMaterial(2);
            mat = GlobalHelpers.MaterialManager.GetMaterial(3);
            mat = GlobalHelpers.MaterialManager.GetMaterial(4);

            var matCard = WriterHelper.GetMaterialCard();
            MCNPformatHelper.FormatThenWriteToFile(MATCARD_FILE, matCard);
            Assert.IsTrue(File.Exists(MATCARD_FILE));
        }
    }

    [TestClass]
    public class FuelAssemblies
    {
        public const string ARRAY_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FuelArray.txt";

        private const string SURFACE_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\SurfaceTest.txt";

        private const string CELL_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\CellsTest.txt";


        [TestMethod]
        public void GetAssembly()
        {
            var fuel = FuelAssemblyManager.GetFuelAssemblySpecification(17);
            Assert.IsTrue(fuel.ArrayPitch == 1.278);
        }

        [TestMethod]
        public void GetFuelSurfaces()
        {
            var fuel = new FuelAssemblyComponent(ARRAY_FILE, false);
            fuel.MakeSurfaces();
            fuel.SaveSurfaces(SURFACE_FILE);
            Assert.IsTrue(File.Exists(SURFACE_FILE));
        }

        [TestMethod]
        public void GetFuelCells()
        {
            var fuel = new FuelAssemblyComponent(ARRAY_FILE, false);
            fuel.MakeCells();
            fuel.SaveCells(CELL_FILE);
            Assert.IsTrue(File.Exists(CELL_FILE));
        }
    }

    [TestClass]
    public class MakeFNCL
    {
        private const string FNCL_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\FNCLwriteTest.txt";

        private const string INPUT_FILE =
            @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\mcnpInputTest.txt";

        [TestMethod]
        public void MakeFNCLDetector()
        {
            FNCLcomponent fncl = new FNCLcomponent();
            fncl.MakeComponent();
            var sur = fncl.GetSurfaces();
            var cel = fncl.GetCells();
            var fuel = new FuelAssemblyComponent(FuelAssemblies.ARRAY_FILE, false);
            fuel.MakeSurfaces();
            fuel.MakeCells();
            WriteComponent(cel, sur, fuel);


            Assert.IsTrue(sur.Count > 0 && cel.Count > 0);
            Assert.IsTrue(File.Exists(FNCL_FILE));
        }

        private static void WriteComponent(List<string> cel, List<string> sur, FuelAssemblyComponent fuel = null)
        {
            using (StreamWriter sw = new StreamWriter(FNCL_FILE))
            {
                foreach (var c in cel)
                {
                    sw.WriteLine(c);
                }

                foreach (var c in fuel.GetCells())
                {
                    sw.WriteLine(c);
                }

                sw.WriteLine("c ----------------------------");
                foreach (var s in sur)
                {
                    sw.WriteLine(s);
                }

                if (fuel != null)
                {
                    foreach (var s in fuel.GetSurfaces())
                    {
                        sw.WriteLine(s);
                    }
                }
            }
        }

        [TestMethod]
        public void MakeMp320Fncl()
        {
            Mp320Fncl fncl = new Mp320Fncl(Helpers.CONFIG_FILE, true);
            fncl.SetExtraPEthickness(5);
            fncl.SetShield(true, 1, true, 2);
            fncl.MakeMCNPfiles(Helpers.TEST_DATA_DIR, 100,
                Particle.Neutron, 100);
            //    Assert.IsTrue(File.Exists(FNCL_FILE));
        }


        private Point3D Center = new Point3D {X = 0, Y = -15, Z = 0};

        private Point3D Axis = new Point3D {X = 0, Y = 0, Z = 1};

        //[TestMethod]
        //public void WriteMCNPinputFile()
        //{
        //    List<string> description = new List<string>();
        //    description.Add("Test to Make Complete Input file");
        //    description.Add("Want to be able to specify fuel array and location/orientation of neutron generator");

        //    List<IComponentSpecification> components = new List<IComponentSpecification>();
        //    components.Add(new FNCLcomponent());
        //    components.Add(new Mp320WithFixedModerator(Center, Axis));
        //    components.Add(new FuelAssemblyComponent(FuelAssemblies.ARRAY_FILE, false));

        //    MakeInputFile mcnp = new MakeInputFile(INPUT_FILE, description, components, 10000);
        //    mcnp.WriteFile();
        //    Assert.IsTrue(File.Exists(INPUT_FILE));
        //}
    }

    [TestClass]
    public class RunFNCLtests
    {
        [TestMethod]
        public void SerializeConfigTest()
        {
            ProblemConfig config = new ProblemConfig
            {
                // Description = "Problem Description",
                DataDirectory = @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles",
                ResultsDirectory =
                    @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\RunTestTop",
                // MCNPfile = "MCNPinput.inp",
                //  FuelArrayFile = "FuelArray.txt",
                DetectorBasisFile = "DetectorBasisFNCL.txt",
                DetectorOutPutFile = "DetectorDefault",
                FullPathToPoliMiExe = @"C:\ornldev\code\MCNPpolimi\bin\Win\mcnpx_polimi_v270_v200.exe",
                FullPathToMPPostExe = @"C:\MPPost\bin\MPPost_win64.exe",
                //  LogFile = "FNCL_LOG.txt",
                //MultiplicityResultFile = "Multiplets.txt",
                GateWidthNanoSeconds = new List<int>()
                {
                    16,
                    32,
                    64,
                    128,
                    256,
                    512,
                    1024,
                    2048
                },
                PreDelay = 8,
                LongDelay = 4096
            };

            ProblemConfigurationHelper.WriteConfig(Helpers.CONFIG_FILE, config);
            Assert.IsTrue(File.Exists(Helpers.CONFIG_FILE));
        }

        [TestMethod]
        public void ReadConfigTest()
        {
            var config = ProblemConfigurationHelper.GetConfig(Helpers.CONFIG_FILE);
            ConfigureDictionaries.InitializeDictionaries();//config.DataDirectory);
            Assert.IsTrue(config.PreDelay == 8);
        }

        public const string CONFIG_FILE = @"C:\Users\9eo\Documents\SourceCode\FNCL\FNCL_PoliMi\DataFiles\Config.xml";


        [TestMethod]
        public void NGen350Fncl()
        {
            string name = "ngen350Test";
            nGen350Fncl nGen = new nGen350Fncl(CONFIG_FILE, true);
            //   nGen.SetSourcePoint(new Point3D(0, 0, 0));
            nGen.MakeMCNPfiles(name + "UNIT_TEST", (int)1e5, Particle.Neutron);
            nGen.RunPoliMiandMPPost();
        }

        //[TestMethod]
        //public void RunFNCLfuel()
        //{
        //    string name = "nGenFuel";
        //    MP320FNCLfuel nGen = new MP320FNCLfuel(CONFIG_FILE, true);
        //    nGen.SetFuelFile("FuelArray.txt");
        //    // nGen.DisplaceHeightFromCenter(100);
        //    nGen.SetNeutronGeneratorAxis(Extents.Mp320.Axis);
        //    nGen.SetNeutronGeneratorCenter(Extents.Mp320.CenterRelativeToModeratorBulkFace);

        //    // nGen.DisplaceHeightFromCenter(50);

        //    nGen.MakeMCNPfiles(name + "UNIT_TEST", 1000, Particle.Neutron);

        //    nGen.RunPoliMiPostAndAnalysis();
        //}

        [TestMethod]
        public void RunFNCLnoFuel()
        {
            string name = "nGenNoFuel";
            Mp320Fncl nGen = new Mp320Fncl(CONFIG_FILE, false);
            //nGen.DisplaceHeightFromCenter(100);
            nGen.SetNeutronGeneratorAxis(Extents.Mp320.Axis);
            nGen.SetNeutronGeneratorCenter(Extents.Mp320.CenterRelativeToModeratorBulkFace);
            // nGen.OverrideComponentSource();
            // nGen.DisplaceHeightFromCenter(50);

            nGen.MakeMCNPfiles(name + "UNIT_TEST_PMT2", 1000000, Particle.Neutron);

            nGen.RunPoliMiPostAndAnalysis();
        }

        [TestMethod]
        public void RunFNCLnoFuelAmli()
        {
            string name = "AmLiNoFuel";
            AmLiFNCL amLi = new AmLiFNCL(CONFIG_FILE, true, AmLiBlockTypes.PWR);
            //amLi.DisplaceHeightFromCenter(100);
            //amLi.SetNeutronGeneratorAxis(Defaults.Extents.NeutronGenerator.Axis);
            //amLi.SetNeutronGeneratorCenter(Defaults.Extents.NeutronGenerator.Center);
            //amLi.
            //amLi.DisplaceHeightFromCenter(50);

            amLi.MakeMCNPfiles(name + "UNIT_TEST_AMLI2", 1000000, Particle.Neutron);

            amLi.RunPoliMiPostAndAnalysis();
        }

        //[TestMethod]
        //public void RunAmLiFNCL_UraniumCylSF()
        //{
        //    string name = "DepletedUCylNoSF";

        //    var uCyl = new UraniumHollowCylinderModels.UraniumHollowCylinderNoInterrogator(configFile);
        //    uCyl.SetEnrichment(UraniumEnrichment.Depleted);
        //    uCyl.SetCenter(new Point3D(0, 0, 0));
        //    uCyl.SetCylinderAxis(new Point3D(0, 0, 1));
        //    uCyl.SetHeight(10.0);
        //    uCyl.SetInnerRadius(1);
        //    uCyl.SetOuterRadius(5);
        //    uCyl.MakeMCNPfiles(name, 1000);
        //    uCyl.RunPoliMiPostAndAnalysis();
        //}

        //[TestMethod]
        //public void RunAmLiFNCL_UraniumCylAmLi()
        //{
        //    string name = "DepletedUCylAmLi";
        //    var uCyl = new UraniumHollowCylinderModels.UraniumHollowCylinderAmLiInterrogator(configFile);
        //    uCyl.SetEnrichment(UraniumEnrichment.Depleted);
        //    uCyl.SetCenter(new Point3D(0, 0, 0));
        //    uCyl.SetCylinderAxis(new Point3D(0, 0, 1));
        //    uCyl.SetHeight(10.0);
        //    uCyl.SetInnerRadius(1);
        //    uCyl.SetOuterRadius(5);
        //    uCyl.MakeMCNPfiles(name, 1000);
        //    uCyl.RunPoliMiPostAndAnalysis();
        //}

        //[TestMethod]
        //public void RunFNCLFuelAmli()
        //{
        //    string name = "AmLiFuel";
        //    // AmLiFNCL amLi = new AmLiFNCL(configFile);
        //    AmLiFuelFNCL amLi = new AmLiFuelFNCL(CONFIG_FILE, true, AmLiBlockTypes.PWR, name);
        //    amLi.SetFuelFile("FuelArray.txt");
        //    //amLi.DisplaceHeightFromCenter(100);
        //    //amLi.SetNeutronGeneratorAxis(Defaults.Extents.NeutronGenerator.Axis);
        //    //amLi.SetNeutronGeneratorCenter(Defaults.Extents.NeutronGenerator.Center);
        //    //amLi.
        //    //amLi.DisplaceHeightFromCenter(50);

        //    amLi.MakeMCNPfiles(name + "UNIT_TEST", 1000, Particle.Neutron);

        //    amLi.RunPoliMiPostAndAnalysis();
        //}

        //[TestMethod]
        //public void RunFNCLFuelAmliWithSFsource()
        //{
        //    string name = "AmLiFuel";
        //    // AmLiFNCL amLi = new AmLiFNCL(configFile);
        //    AmLiFuelFNCL amLi = new AmLiFuelFNCL(CONFIG_FILE, false, AmLiBlockTypes.PWR, name);
        //    amLi.SetFuelFile("FuelArray.txt");

        //    amLi.MakeMCNPfiles(name + "UNIT_TEST_FUEL", 1000, Particle.Neutron);

        //    amLi.RunPoliMiPostAndAnalysis(false);
        //}

        [TestMethod]
        public void MakeBwrAmLi()
        {
            // IComponentSpecification amLi = AmLiBlockHelper.GetAmLiBlock(AmLiBlockTypes.BWR, 0, 0, 1, 1, true);
            AmLiFNCL amLi = new AmLiFNCL(CONFIG_FILE, true, AmLiBlockTypes.BWR);
            amLi.MakeMCNPfiles(Path.Combine(Helpers.TEST_DATA_DIR, "TestBWR"), (int)1e3, Particle.Neutron, 1.0);
        }

        [TestMethod]
        public void RunSEL()
        {
            SelFNCL sel = new SelFNCL(CONFIG_FILE, true, AmLiBlockTypes.PWR, "DEBUG");
            sel.SetNumberOfPucks(3);
            sel.MakeMCNPfiles("SEL_UNIT_TEST", 1000, Particle.Neutron);
            sel.RunPoliMiPostAndAnalysis();
        }


        [TestMethod]
        public void RunSELJapo()
        {
            DUCylSelFNCL sel = new DUCylSelFNCL(CONFIG_FILE, false, Extents.JAPO, AmLiBlockTypes.PWR, "JAPO");
            //  sel.AddMeasurementPucks(3);
            sel.MakeMCNPfiles("SEL_UNIT_TEST_JAPO", 1000, Particle.Neutron);
            sel.RunPoliMiPostAndAnalysis();
        }

        [TestMethod]
        public void RunSELJany()
        {
            DUCylSelFNCL sel = new DUCylSelFNCL(CONFIG_FILE, true, Extents.JANY, AmLiBlockTypes.PWR, "JANY");
            // sel.AddMeasurementPucks(3);
            sel.MakeMCNPfiles("SEL_UNIT_TEST_JANY", 1000, Particle.Neutron);
            sel.RunPoliMiPostAndAnalysis();
        }


        [TestMethod]
        public void NGammaDetector()
        {
            RunNGammaDetector nGam = new RunNGammaDetector(CONFIG_FILE, "NGammaDetTest", 50, 0.1);

            for (int i = 1; i <= 6; i++)
            {
                NonEmbeddedSources.PointSourceInSphericalShell shellSource =
                    new NonEmbeddedSources.PointSourceInSphericalShell(new Point3D(0, 0, 0), 3.794, i * 2.54,
                        PoliMiSource.Cf252Sf, Materials.HDPE, false);
                nGam.AddSourceModel(shellSource);
                nGam.MakeMCNPfiles("Cf252_" + i.ToString() + "_InchesHDPEthin", (int)1e7, Particle.Photon, 1e5);
            }

            // nGam.R();
        }

        [TestMethod]
        public void MakeDetectorResponseFunction()
        {
            SelFNCL selFncl = new SelFNCL(CONFIG_FILE, false, AmLiBlockTypes.PWR, "DRF");
            Point3D drfPoint = selFncl.GetTopOfPostPucks();
            drfPoint.Z += SelMeasurementComponents.HEIGHT_ABOVE_PUCK;
            string energyBoundsFile =
                @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\neutronEnergyBounds.txt";

            List<Bounds<double>> energyBounds = new List<Bounds<double>>();
            energyBounds.Add(new Bounds<double>(0, 1));
            energyBounds.Add(new Bounds<double>(1, 20));

            DetectorResponseFunction drf = new DetectorResponseFunction(selFncl, drfPoint,
                energyBoundsFile, "UnitTest");
            //energyBounds);
            drf.RunMCNPandMPPost((int)1e6,
                Helpers.TEST_DATA_DIR, true);
            Dictionary<string, List<DetectorResponse>> detectorResponse =
                drf.GetDetectorResponseFunctions(DetectorResponseFunctionHelper.GetDictionaryForDetectorSummed());
            string drfFile = @"C:\Users\9eo\Documents\SourceCode\FNCL\polimi_multpilicity\TestDataFiles\drf.txt";
            DetectorResponseFunctionHelper.WriteDRFtoFile(drfFile, detectorResponse);
            Assert.IsTrue(detectorResponse.ContainsKey("All Detectors"));
        }

        [TestMethod]
        public void ReadFnclNoFilters()
        {
            string timeStampFile = @"D:\FNCLdata\NoFilters\AllFiltersOff\SESSION_0\ENERGY\TimestampList.txt";
            Pulses<Pulse> pulses = PulsesHelper.GetFnclFlatFilePulses(timeStampFile);
            int gateWidth = 60;
            int preDelay = 0;
            int longDelay = 1000;
            IMultiplicityGate multDist = MultiplicityGatesHelper.GetMultiplicityGate(pulses, preDelay, longDelay);
            MultiplicityDistribution distribution = multDist.GetRealsAccidentals();
            MultiplicityRates rates = MultiplicityRatesHelper<Pulse>.GetMultiplicityRates(multDist, gateWidth);
            rates = rates.ConvertToSeconds();
        }

        [TestMethod]
        public void CompareTimeStampsListVsWave()
        {
            string dataDir = @"E:\FNCLdata\mp320Cf252April16\SESSION_0\EXAM\Cf252_6081\PB";
            //string timeStampFile = @"E:\FNCLdata\mp320Cf252April16\SESSION_0\EXAM\Cf252_6081\PB\TimestampList.txt";
            //string waveDir = @"E:\FNCLdata\mp320Cf252April16\SESSION_0\EXAM\Cf252_6081\PB\DAQ";
            //const string WAVE_FILE = "FNCL_DAQ_";
            //const string WAVE_EXT = "bin";
            TimeStampVsWaveformComparer.WriteToFile(dataDir);
        }

        [TestMethod]
        public void PoliMiDetector()
        {
            var detector = DetectorFileMaker.GetFnclDetectorDefault();
            detector.SetNPS((int)1e4);
            detector.SetDetectorCells(new List<int>() {1, 2, 3, 4});

            string file = @"C:\Users\9eo\Documents\Projects\FNCL\detTest.txt";

            detector.WriteToFile(file);
        }
    }

    [TestClass]
    public class GuiInterfaceTests
    {
        [TestMethod]
        public void CombineBinaryFiles()
        {
            string pulseFile = @"E:\FNCLdata\mp320ExtraPE\SESSION_0\EXAM\NBL_Blank\IM\DAQ\FNCL_DAQ_0.bin";
            CombineBinaryPulses.SavePulses(pulseFile, "testCombineSmall",
                30, 500, true, false);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SaveSimulationSpecifications()
        {
            string saveFile = @"C:\FNCL\DeleteMeUnitTest.txt";
            SimulationSpecification simSpec = new SimulationSpecification
            {
                AmLiBlockType = AmLiBlockTypes.PWR,
                NeutronGeneratorType = NeutronGeneratorTypes.MP320,
                StandOff = 8675309,
                McnpInputDirectory = "C://mcnpInputDir//test//",
                NPS = 12345,
                Activity = 99,
                ActiveProblem = false,
                Description = "It is what it is",
                FuelFile = "C://fuelFile.txt",
                FuelHeightDisplacement = 77,
                InnerRadius = 1,
                OutRadius = 2,
                Center = new Point3D(1, 2, 3),
                Axis = new Point3D(1, 0, 0),
                Radius = 4,
                Height = 5,
                Material = 6,
                SourcePoliMi = PoliMiSource.Am241O2,
                SourceType = Sources.Cylinder,
                AmLiLeft = 0.7,
                AmLiRight = 0.3,
                //NumberOfSelPucks = 2,
                ModeratorThickness = 3,
                UseCdShield = false,
                UsePbShield = false,
                PbThickness = 0.1,
                CdThickness = 0.2,
                UseLeftPanelTwoShield = false,
                UseRightPanelOneShield = false,
                ExtraPbShieldDimensions = new Point3D(3, 4, 5),
                TrackParticle = Particle.NeutronAndPhoton
            };

            SimulationSpecificationHelper.SaveSimulationSpecsToFile(saveFile,
                new List<SimulationSpecification>() {simSpec});
        }
    }

    [TestClass]
    public class SolveEquations
    {
        [TestMethod]
        public void Solve()
        {
            List<string> files = new List<string>();

            files.Add(@"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\BerpPeak.txt");
            files.Add(@"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\BerpFull.txt");
            files.Add(@"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\BerpAboveMeV.txt");
            files.Add(@"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\Berp2kgPeak.txt");
            files.Add(@"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\Berp2kgFull.txt");
            files.Add(@"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\Berp2kgAboveMeV.txt");

            foreach (var f in files)
            {
                string fileOut = f.Replace(".txt", "OUT_thisOne.txt");
                PointKineticsParameters pointKinetics = new PointKineticsParameters(f, fileOut);
            }
        }


        [TestMethod]
        public void SolveCubic()
        {
            string fileIn = @"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\coeffsToGetMult.txt";
            string fileOut = @"C:\Users\9eo\Documents\Projects\NGamLDRD\LDRDreportRuns\multiplication.txt";
            // var roots = Multiplicity.EquationSolver.SolveCubic(-7.03e3, 1.25e2, 3.0e2, 1);

            using (StreamReader sr = new StreamReader(fileIn))
            using (StreamWriter sw = new StreamWriter(fileOut))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    i++;
                    string curLine = sr.ReadLine();
                    if (curLine.Contains('#'))
                    {
                        sw.WriteLine(curLine);
                    }
                    else
                    {
                        string[] split = curLine.Split();
                        List<double> coeffs = new List<double>();
                        foreach (var s in split)
                        {
                            coeffs.Add(double.Parse(s));
                        }

                        var roots = EquationSolver.SolvePolynomial(coeffs);
                        string rootLine = "";
                        foreach (var r in roots)
                        {
                            rootLine += " ( " + r.Real + " , " + r.Imaginary + " ) ";
                        }

                        sw.WriteLine(rootLine);
                    }
                }
            }
        }
    }

    [TestClass]
    public class TestInputValidators
    {
        [TestMethod]
        public void TestInchToCm()
        {
            string test = "5i";
            double testOut = GuiWidgets.CustomValidatorHelper.GetDistanceToCm(test);
            Assert.AreEqual(testOut, 5 * 2.54);
        }
    }
}
