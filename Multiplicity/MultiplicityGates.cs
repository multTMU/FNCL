using System;
using GeometrySampling;


namespace Multiplicity
{
    public enum MultiplicityGateType
    {
        Sequential,
        TriggeredNotShift,
        ShiftRegister
    }

    public interface IMultiplicityGate
    {
        double GetCountTime();
        double GetGateWidth();
        MultiplicityGateType GetGateType();

        void RunForGateWidth(double gateWidthNanoSeconds);

        MultiplicityDistribution GetReals();
        MultiplicityDistribution GetRealsAccidentals();
        MultiplicityDistribution GetAccidentals();
        double GetSinglesRate();
        double GetDoublesRate();
        double GetTriplesRate();
    }

    public static partial class MultiplicityGatesHelper
    {
        public const int END_OF_PULSE_FLAG = -1;

        public static IMultiplicityGate GetMultiplicityGate<TPulse>(Pulses<TPulse> pulses, int preDelayNanoSec,
            int longDelayNanoSec) where TPulse : IPulse
        {
            return GetMultiplicityGate(MultiplicityGateType.ShiftRegister, pulses, preDelayNanoSec,
                longDelayNanoSec);
        }

        public static IMultiplicityGate GetMultiplicityGate<TPulse>(MultiplicityGateType gateType,
            Pulses<TPulse> pulses)
            where TPulse : IPulse
        {
            return GetMultiplicityGate(gateType, pulses, 0, 0);
        }

        public static IMultiplicityGate GetMultiplicityGate<TPulse>(MultiplicityGateType gateType,
            Pulses<TPulse> pulses,
            GateSettings gateSettings) where TPulse : IPulse
        {
            return GetMultiplicityGate(gateType, pulses, gateSettings.PreDelay, gateSettings.LongDelay);
        }


        public static IMultiplicityGate GetMultiplicityGate<TPulse>(MultiplicityGateType gateType,
            Pulses<TPulse> pulses,
            double preDelayNanoSec, double longDelayNanoSec) where TPulse : IPulse
        {
            switch (gateType)
            {
                case MultiplicityGateType.Sequential:
                    return new SequentialGates<TPulse>(pulses);
                case MultiplicityGateType.TriggeredNotShift:
                    return new TriggeredGates<TPulse>(pulses);
                case MultiplicityGateType.ShiftRegister:
                    return new ShiftRegister<TPulse>(pulses, preDelayNanoSec, longDelayNanoSec);
            }

            throw new Exception("Type of Multiplicity Gate Not Found");
        }

        private abstract class MultiplicityGate<TPulse> : IMultiplicityGate where TPulse : IPulse
        {
            protected readonly Pulses<TPulse> pulseTrain;
            protected double gateWidth;
            protected Bounds<double> gateInterval;
            private double pulse;
            private int multiplicity;
            protected MultiplicityDistribution distribution;

            private readonly double CountTime;
            private readonly int fixedSize;
            protected bool KEEP_READING;

            protected MultiplicityGate(Pulses<TPulse> pulses,
                int fixedSizeDistribution = GetMultiplicityDistributions.UNBOUND_FLAG)
            {
                pulseTrain = pulses;
                CountTime = pulseTrain.GetDuration();
                fixedSize = fixedSizeDistribution;
                KEEP_READING = true;
            }

            public double GetCountTime()
            {
                return CountTime;
            }

            public abstract MultiplicityGateType GetGateType();

            public void RunForGateWidth(double gateWidthNanoSeconds)
            {
                gateWidth = gateWidthNanoSeconds;
                pulseTrain.StartReadingPulseTrain(END_OF_PULSE_FLAG);
                distribution = GetMultiplicityDistributions.GetDistribution(fixedSize);

                SetFirstInterval();
                multiplicity = SetInitialMultiplicity();
                while (CanReadNextPulse())
                {
                    AddPulseToDistribution();
                }

                FinalizeGate();
            }

            public MultiplicityDistribution GetReals()
            {
                return new MultiplicityDistribution();
            }

            public MultiplicityDistribution GetRealsAccidentals()
            {
                return distribution;
            }

            public MultiplicityDistribution GetAccidentals()
            {
                return new MultiplicityDistribution();
            }

            protected abstract void SetFirstInterval();
            protected abstract void NextGate();

            private bool CanReadNextPulse()
            {
                double testPulse = pulseTrain.GetNextPulseTime();
                if (EndOfPulseFlagNotEncountered(testPulse))
                {
                    pulse = testPulse;
                    return true;
                }

                return false;
            }

            protected bool PulseFallsWithinGate()
            {
                return gateInterval.BoundsValue(pulse);
            }

            protected bool EndOfPulseFlagNotEncountered(double testPulse)
            {
                return testPulse != END_OF_PULSE_FLAG;
            }

            private void AddPulseToDistribution()
            {
                if (PulseFallsWithinGate())
                {
                    multiplicity++;
                }
                else
                {
                    if (KEEP_READING)
                    {
                        FinalizeGate();
                    }
                }
            }

            private void FinalizeGate()
            {
                distribution.AddMultiplicity(multiplicity);
                NextGate();
                multiplicity = SetInitialMultiplicity();
                if (AddTriggerPulseToDistribution())
                {
                    AddPulseToDistribution();
                }
            }

            protected virtual int SetInitialMultiplicity()
            {
                return 0;
            }

            protected abstract bool AddTriggerPulseToDistribution();

            public double GetGateWidth()
            {
                return gateWidth;
            }

            public MultiplicityDistribution GetRealsAccidentalDistributionForGateWidth(int gateWidthNanoSeconds)
            {
                return new MultiplicityDistribution();
            }

            public abstract double GetSinglesRate();
            public abstract double GetDoublesRate();
            public abstract double GetTriplesRate();
        }

        private class TriggeredGates<TPulse> : MultiplicityGate<TPulse> where TPulse : IPulse
        {
            private int gateIndex;

            public TriggeredGates(Pulses<TPulse> pulses) :
                base(pulses)
            {
            }

            public override MultiplicityGateType GetGateType()
            {
                return MultiplicityGateType.TriggeredNotShift;
            }

            protected override void SetFirstInterval()
            {
                double firstPulse = pulseTrain.GetTimeOfFirstPulse();
                gateInterval = new Bounds<double> {Lower = firstPulse, Upper = firstPulse + gateWidth};
                gateIndex = 1;
            }

            protected override int SetInitialMultiplicity()
            {
                return 1;
            }

            protected override void NextGate()
            {
                double gatePulse = pulseTrain.GetPulseTimeByIndex(gateIndex);
                if (EndOfPulseFlagNotEncountered(gatePulse))
                {
                    gateInterval = new Bounds<double> {Lower = gatePulse, Upper = gatePulse + gateWidth};
                    pulseTrain.SetCurrentPulseIndex(gateIndex);
                    gateIndex++;
                }
                else
                {
                    // garbage gate
                    gateInterval = new Bounds<double>(int.MinValue, 0);
                    KEEP_READING = false;
                }
            }

            protected override bool AddTriggerPulseToDistribution()
            {
                return false;
            }

            public override double GetSinglesRate()
            {
                double n = 0;
                foreach (var d in distribution.NonNormalizedDistribution)
                {
                    n += d;
                }

                return n / GetCountTime();
            }

            public override double GetDoublesRate()
            {
                int i = -1;
                double sumRA = 0;
                foreach (var c in GetRealsAccidentals().NonNormalizedDistribution)
                {
                    sumRA += i * c;
                    i++;
                }

                return sumRA / GetCountTime();
            }

            public override double GetTriplesRate()
            {
                double sumTmi = 0;
                int i = -1;
                foreach (var c in GetRealsAccidentals().NonNormalizedDistribution)
                {
                    sumTmi += (i * (i - 1)) * c / 2.0;
                    i++;
                }

                return (sumTmi / GetCountTime()) - GetSinglesRate() * GetDoublesRate() * GetGateWidth();
            }
        }

        private class SequentialGates<TPulse> : MultiplicityGate<TPulse> where TPulse : IPulse
        {
            public SequentialGates(Pulses<TPulse> pulses) : base(pulses)
            {
            }

            protected override void SetFirstInterval()
            {
                double firstPulse = pulseTrain.GetTimeOfFirstPulse();
                gateInterval = new Bounds<double>() {Lower = firstPulse, Upper = firstPulse + gateWidth};
            }

            protected override void NextGate()
            {
                while (!PulseFallsWithinGate())
                {
                    gateInterval.Lower = gateInterval.Upper;
                    gateInterval.Upper += gateWidth;
                }
            }

            public override MultiplicityGateType GetGateType()
            {
                return MultiplicityGateType.Sequential;
            }

            protected override bool AddTriggerPulseToDistribution()
            {
                return true;
            }

            public override double GetSinglesRate()
            {
                double sumQi = 0;
                int i = 0;
                foreach (var d in distribution.NonNormalizedDistribution)
                {
                    sumQi += i * d;
                    i++;
                }

                return sumQi / GetCountTime();
            }

            public override double GetDoublesRate()
            {
                int i = 0;
                double sumRA = 0;
                foreach (var c in GetRealsAccidentals().NonNormalizedDistribution)
                {
                    sumRA += (i * (i - 1)) * c / 2.0;
                    i++;
                }

                return sumRA / GetCountTime();
            }

            public override double GetTriplesRate()
            {
                double sumTmi = 0;
                int i = 0;
                foreach (var c in GetRealsAccidentals().NonNormalizedDistribution)
                {
                    sumTmi += ((i * (i - 1) * (i - 2))) * c / 6.0;
                    i++;
                }

                return (sumTmi / GetCountTime()) - GetSinglesRate() * GetDoublesRate() * GetGateWidth();
            }
        }
    }
}
