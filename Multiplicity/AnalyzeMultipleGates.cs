namespace Multiplicity
{
    //public class AnalyzeMultipleGates
    //{
    //    private readonly IMultiplicityGate gate;
    //    private readonly Particle particle;
    //    private readonly string pulseFile;

    //    public AnalyzeMultipleGates(string poliMiFile, Particle particleType,
    //        TypeOfGate gateType = TypeOfGate.Sequential,
    //        bool timeSorted = false, List<Bounds<double>> pulseHeightBounds = null, double preDelayNanoSec = 0,
    //        double longDelayNanoSec = 0)
    //    {
    //        Pulses<IPulse> pulses;
    //        particle = particleType;
    //        pulseFile = poliMiFile;
    //        if (particle == Particle.Neutron)
    //        {
    //            pulses = PulsesHelper.GetNeutronPulsesFromPoliMi(pulseFile, timeSorted);
    //        }
    //        else
    //        {
    //            pulses = PulsesHelper.GetPhotonPulsesFromPoliMi(pulseFile, timeSorted);
    //        }

    //        gate = MultiplicityGateFactory.GetMultiplicityGate(gateType, pulses, preDelayNanoSec, longDelayNanoSec);
    //    }

    //    public FactorialMoments GetStatsForGate(int gateInNanoSec)
    //    {
    //        return FactorialMomentsHelper.GetFactorialMoments(gate.GetDistributionForGateWidth(gateInNanoSec));
    //    }

    //    public List<GateMoments> GetStatsForMultipleGates(List<int> gatesInNanoSec)
    //    {
    //        List<GateMoments> moments = new List<GateMoments>();
    //        foreach (var g in gatesInNanoSec)
    //        {
    //            moments.Add(new GateMoments(g, GetStatsForGate(g)));
    //        }

    //        return moments;
    //    }

    //    public void WriteStatsForMultipleGatesToFile(List<int> gatesInNanoSec, string fileFullPath)
    //    {
    //        SaveGateStatistics.SaveMomentsToFile(fileFullPath, GetStatsForMultipleGates(gatesInNanoSec), particle,
    //            pulseFile);
    //    }
    //}

    //public static class SaveGateStatistics
    //{
    //    private const char DEL = ',';

    //    public static void SaveMomentsToFile(string fileFullPath, List<GateMoments> gateMoments, Particle particle,
    //        string pulseFile)
    //    {
    //        using (StreamWriter sw = new StreamWriter(fileFullPath))
    //        {
    //            sw.WriteLine("Pulse file: {0}", pulseFile);
    //            sw.WriteLine("Time Run: {0}", DateTime.Now);
    //            //sw.WriteLine("Particle: {0}", Enum.GetName(typeof(Particle), particle));
    //            sw.WriteLine("Gate(ns){0}Mean{0}Second{0}SecondExcess{0}Third{0}ThidExcess{0}FeynmanY", DEL);
    //            foreach (var g in gateMoments)
    //            {
    //                sw.WriteLine(GetLine(g));
    //            }
    //        }
    //    }

    //    private static string GetLine(GateMoments gateMoment)
    //    {
    //        string line = gateMoment.GateWidthNanoSec.ToString() + DEL;
    //        line += gateMoment.Moments.Mean.ToString() + DEL;
    //        line += gateMoment.Moments.Second.ToString() + DEL;
    //        line += gateMoment.Moments.SecondExcess.ToString() + DEL;
    //        line += gateMoment.Moments.Third.ToString() + DEL;
    //        line += gateMoment.Moments.ThirdExcess.ToString() + DEL;
    //        line += gateMoment.Moments.FeynmanY.ToString();
    //        return line;
    //    }
    //}

    //public struct GateMoments
    //{
    //    public int GateWidthNanoSec;
    //    public FactorialMoments Moments;

    //    public GateMoments(int gate, FactorialMoments moment)
    //    {
    //        GateWidthNanoSec = gate;
    //        Moments = moment;
    //    }
    //}
}
