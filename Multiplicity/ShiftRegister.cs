using System.Linq;
using GeometrySampling;

namespace Multiplicity
{
    public static partial class MultiplicityGatesHelper
    {
        // ShiftRegister Classes based on:
        //
        // msr_analysis_lge.cpp
        // author: Louise G. Worrall(Evans)
        // last modified: 27/11/08
        // worralllg@ornl.gov
        //
        // Translated into C# by Sean O'Brien obriense@ornl.gov

        private class ShiftRegister<TPulse> : IMultiplicityGate where TPulse : IPulse
        {
            private readonly Pulses<TPulse> pulseTrain;
            private readonly double preDelay;
            private readonly double longDelay;
            private double gateWidth;

            private MultiplicityDistribution realsAndAccidentals;
            private MultiplicityDistribution accidentals;
            private MultiplicityDistribution reals;

            private double pulse;
            private int counterRA;
            private int counterA;
            private Bounds<double> gateRA;
            private Bounds<double> gateA;

            private double CountTime;
            private readonly int fixedSize = 0;

            public ShiftRegister(Pulses<TPulse> pulses, double preDelayNanoSec, double longDelayNanoSec,
                int fixedSizeDistribution = GetMultiplicityDistributions.UNBOUND_FLAG)
            {
                preDelay = preDelayNanoSec;
                longDelay = longDelayNanoSec;
                fixedSize = fixedSizeDistribution;
                pulseTrain = pulses;
            }

            public void RunForGateWidth(double gateWidthNanoSeconds)
            {
                gateWidth = gateWidthNanoSeconds;
                InitializeDistributions();
                pulseTrain.StartReadingPulseTrain(END_OF_PULSE_FLAG);
                CountTime = pulseTrain.GetDuration(); // needs to be here after all pulse filters have been run
                while (TriggerNextGates()
                ) // allows loading of next batch of pulses from file. Not sure how to smoothly handle edge
                {
                    for (int k = pulseTrain.CurrentIndex; k < pulseTrain.NumberOfPulses; k++)
                    {
                        pulse = pulseTrain.GetPulseTimeByIndex(k);
                        TestGates(); // put some logic to break out if we've passed the end of the A-gate
                        if (ExceededAccidentalsGate())
                        {
                            break;
                        }
                    }

                    SaveMultiplicities();
                }

                SetRealsDistribution();
            }

            public MultiplicityDistribution GetReals()
            {
                return reals;
            }

            public MultiplicityDistribution GetRealsAccidentals()
            {
                return realsAndAccidentals;
            }

            public MultiplicityDistribution GetAccidentals()
            {
                return accidentals;
            }

            public double GetSinglesRate()
            {
                double sumQi = GetAccidentals().NonNormalizedDistribution.Sum(); // corresponds to Louise's notation
                return sumQi / GetCountTime();
            }

            public MultiplicityGateType GetGateType()
            {
                return MultiplicityGateType.ShiftRegister;
            }

            public double GetCountTime()
            {
                return CountTime;
            }

            public double GetGateWidth()
            {
                return gateWidth;
            }

            private bool CanReadNextPulse(double nextPulse)
            {
                return nextPulse != END_OF_PULSE_FLAG;
            }

            private bool ExceededAccidentalsGate()
            {
                return gateA.AboveBounds(pulse);
            }

            private void InitializeDistributions()
            {
                realsAndAccidentals = GetMultiplicityDistributions.GetDistribution(fixedSize);
                accidentals = GetMultiplicityDistributions.GetDistribution(fixedSize);
            }

            private void SetRealsDistribution()
            {
                reals = realsAndAccidentals - accidentals;
            }

            private void SaveMultiplicities()
            {
                realsAndAccidentals.AddMultiplicity(counterRA);
                accidentals.AddMultiplicity(counterA);
            }

            private void TestGates()
            {
                TestRealsAndAccidentalsGate();
                TestAccidentalGate();
            }

            private void TestAccidentalGate()
            {
                if (gateA.BoundsValue(pulse))
                {
                    counterA++;
                }
            }

            private void TestRealsAndAccidentalsGate()
            {
                if (gateRA.BoundsValue(pulse))
                {
                    counterRA++;
                }
            }

            private bool TriggerNextGates()
            {
                double triggerPulse = pulseTrain.GetNextPulseTime();
                counterRA = 0;
                counterA = 0;

                double startTimeRandAgate = triggerPulse + preDelay;
                double endTimeRandAgate = startTimeRandAgate + gateWidth;
                gateRA = new Bounds<double> {Lower = startTimeRandAgate, Upper = endTimeRandAgate};

                double startTimeAgate = endTimeRandAgate + longDelay;
                double endTimeAgate = startTimeAgate + gateWidth;
                gateA = new Bounds<double> {Lower = startTimeAgate, Upper = endTimeAgate};

                return CanReadNextPulse(triggerPulse);
            }

            public double GetDoublesRate()
            {
                int i = 0;
                double sumA = 0;
                foreach (var c in GetAccidentals().NonNormalizedDistribution)
                {
                    sumA += i * c;
                    i++;
                }

                i = 0;
                double sumRA = 0;
                foreach (var c in GetRealsAccidentals().NonNormalizedDistribution)
                {
                    sumRA += i * c;
                    i++;
                }

                return (sumRA - sumA) / GetCountTime();
            }

            public double GetTriplesRate()
            {
                double sumTmi = 0;
                int i = 0;
                foreach (var c in GetReals().NonNormalizedDistribution)
                {
                    sumTmi += ((i * (i - 1)) / 2) * c;
                    i++;
                }

                return (sumTmi / GetCountTime()) - GetSinglesRate() * GetDoublesRate() * GetGateWidth();
            }
        }
    }
}
