using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeometrySampling;
using Multiplicity;
using Multiplicity.PulseFilters;

namespace NGamSnlCli
{
    class Program
    {
        static void Main(string[] args)
        {
            string pulseFile = args[0];

            List<Bounds<double>> bounds = new List<Bounds<double>>();

            for (int i = 1; i < args.Length; i +=2)
            {
                bounds.Add(new Bounds<double>(double.Parse(args[i]), double.Parse(args[i])));
            }

            //double peakLow = double.Parse(args[1]);
            //double peakHigh = double.Parse(args[2]);

            //Bounds<double> peak = new Bounds<double>(peakLow, peakHigh);
            //Bounds<double> peakBelow = new Bounds<double>(0, peakLow);
            //Bounds<double> peakAbove = new Bounds<double>(peakHigh, double.MaxValue);
            
            //List<Bounds<double>> outsidePeak = new List<Bounds<double>>()
            //{
            //    peakBelow, peakAbove
            //};

         
                Pulses<NGamSnlPulse> pulses = PulsesHelper.GetNGamSnlPulses(pulseFile);
              pulses.RunExternalFilter(new PulseHeightKeVeeFilter<NGamSnlPulse>(bounds));

                //Pulses<NGamSnlPulse> belowPulses = allPulses.Clone();
                //boundPulses.RunExternalFilter(new PulseHeightKeVeeFilter<NGamSnlPulse>(peakBelow));

                //Pulses<NGamSnlPulse> abovePules = allPulses.Clone();
                //boundPulses.RunExternalFilter(new PulseHeightKeVeeFilter<NGamSnlPulse>(peakHigh));

                //Pulses<NGamSnlPulse> notPeakPulses = allPulses.Clone();
                //boundPulses.RunExternalFilter(new PulseHeightKeVeeFilter<NGamSnlPulse>(outsidePeak));

                List<double> gates = GetLogSpaced(1e4, 1e6, 10);
                double longGateMultiplier = 10;
                using (StreamWriter swShift = new StreamWriter(Path.ChangeExtension(pulseFile, "shift")))
                {
                    swShift.WriteLine("Shift Register file: " + pulseFile);
                    swShift.WriteLine("Long gate multiplier of gate: " + longGateMultiplier.ToString());

                    using (StreamWriter swTrig = new StreamWriter(Path.ChangeExtension(pulseFile, "trig")))
                    {
                        using (StreamWriter swSeq = new StreamWriter(Path.ChangeExtension(pulseFile, "seq")))
                        {
                            swTrig.WriteLine("Trigger Gate file: " + pulseFile);

                            //swTrig.WriteLine("Peak Bounds (keV) Low: " + peak.Lower + " High): " + peak.Upper);
                            //swShift.WriteLine("Peak Bounds (keV) Low: " + peak.Lower + " High): " + peak.Upper);

                            swTrig.WriteLine(MultiplicityRates.HEADER);
                            swShift.WriteLine(MultiplicityRates.HEADER);
                            foreach (var g in gates)
                            {
                                Console.WriteLine("Gate: " + g.ToString());

                                MultiplicityRates mult = RunShiftRegister(pulses, g, 0, longGateMultiplier * g);
                                swShift.WriteLine(mult.ToString());

                                //mult = RunShiftRegister(boundPulses, g, 0, longGateMultiplier * g);
                                //swShift.WriteLine("Peak " + mult.ToString());

                                //mult = RunShiftRegister(belowPulses, g, 0, longGateMultiplier * g);
                                //swShift.WriteLine("Below_Peak " + mult.ToString());

                                //RunShiftRegister(abovePules, g, 0, longGateMultiplier * g);
                                //swShift.WriteLine("Above_Peak " + mult.ToString());

                                //mult = RunShiftRegister(notPeakPulses, g, 0, longGateMultiplier * g);
                                //swShift.WriteLine("Not_Peak " + mult.ToString());
                                //swShift.WriteLine("");

                                //mult = RunTriggeredGate(pulses, g);
                                //swTrig.WriteLine("All " + mult.ToString());

                                //mult = RunTriggeredGate(boundPulses, g);
                                //swTrig.WriteLine("Peak " + mult.ToString());

                                //mult = RunTriggeredGate(belowPulses, g);
                                //swTrig.WriteLine("Below_Peak " + mult.ToString());

                                //mult = RunTriggeredGate(abovePules, g);
                                //swTrig.WriteLine("Above_Peak " + mult.ToString());

                                //mult = RunTriggeredGate(notPeakPulses, g);
                                //swTrig.WriteLine("Not_Peak " + mult.ToString());
                                //swTrig.WriteLine("");
                            }
                        }
                    }
                }
           // }

        }

        private static List<double> GetLogSpaced(double min, double max, int nSteps)
        {
            List<double> gates = new List<double>();
            double space = Math.Pow(max / min, 1.0 / nSteps);
            for (int i = 0; i <= nSteps; i++)
            {
                gates.Add(min * Math.Pow(space, i));
            }

            return gates;
        }

        private static MultiplicityRates RunTriggeredGate<T>(Pulses<T> pulses, double gate)
            where T : IPulse
        {
            IMultiplicityGate multgate =
                MultiplicityGatesHelper.GetMultiplicityGate(MultiplicityGateType.TriggeredNotShift, pulses, 0, 0);
            return GetRates<T>(multgate, gate); 
        }

        private static MultiplicityRates RunShiftRegister<T>(Pulses<T> pulses, double gate, double preDelay, double longDelay) where T:IPulse
        {
            IMultiplicityGate multgate = MultiplicityGatesHelper.GetMultiplicityGate(pulses, (int)preDelay, (int)longDelay);
            return GetRates<T>(multgate, gate);
        }

        private static MultiplicityRates GetRates<T>(IMultiplicityGate multGate, double gateWidth) where T:IPulse
        {
           return MultiplicityRatesHelper<T>.GetMultiplicityRates(multGate, gateWidth);
        }
    }
}
