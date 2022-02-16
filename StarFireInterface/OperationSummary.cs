using System;
using System.Collections.Generic;
using System.IO;

namespace StarFireInterface
{
    public struct nGen350RunLog
    {
        public double ElapsedTimeSec;
        public DateTime Time;
        public double HoursRan;
        public double CalculationsCurrentRatio;

        public AnodenGen350 Anode;
        public GetternGen350 Getter;
        public NeutronnGen350 Neutron;
        public RadioFrequencynGen350 RF;
        public SensorsnGen350 Sensors;
        public SuppressornGen350 Suppressor;
        public StateMachinenGen350 StateMachine;

        public struct AnodenGen350
        {
            public double DutyCycle;
            public double Current;
            public double Voltage;
        }

        public struct GetternGen350
        {
            public double DutyCycle;
            public double Current;
        }

        public struct NeutronnGen350
        {
            public double Counts;
            public double CountRateRaw;
            public double CountRateAvg;
            public double CountRateRawStandardDevPercent;
        }

        public struct RadioFrequencynGen350
        {
            public double FreqSynth;
            public double Current;
            public double Voltage;
        }

        public struct SensorsnGen350
        {
            public double Temperature;
            public double SF6Pressure;
        }

        public struct SuppressornGen350
        {
            public double Current;
            public double Voltage;
        }


        public struct StateMachinenGen350
        {
            public double State;
            public int Source;
            public int Destination;
            public bool Fault;
        }
    }

    public class OperationSummary
    {
        private static class OperationSummaryReader
        {
            private const char SEP = ',';
            private const int NUMBER_ELEMENTS = 24;
            private const string OKAY = "[ OK ]";

            public static List<nGen350RunLog> ReadCsv(string file)
            {
                List<nGen350RunLog> runLog = new List<nGen350RunLog>();

                using (StreamReader sr = new StreamReader(file))
                {
                    sr.ReadLine(); // Read Header
                    while (!sr.EndOfStream)
                    {
                        string curLine = sr.ReadLine();
                        if (!string.IsNullOrEmpty(curLine))
                        {
                            runLog.Add(GetRunLogFromLine(curLine));
                        }
                    }
                }

                return runLog;
            }

            private static nGen350RunLog GetRunLogFromLine(string line)
            {
                string[] splitLine = line.Split(SEP);
                if (splitLine.Length == NUMBER_ELEMENTS)
                {
                    return new nGen350RunLog()
                    {
                        ElapsedTimeSec = double.Parse(splitLine[0]),
                        Time = DateTime.Parse(splitLine[1]),
                        HoursRan = double.Parse(splitLine[2]),
                        CalculationsCurrentRatio = double.Parse(splitLine[19]),
                        Anode =
                            new nGen350RunLog.AnodenGen350
                            {
                                DutyCycle = double.Parse(splitLine[3]),
                                Current = double.Parse(splitLine[4]),
                                Voltage = double.Parse(splitLine[5])
                            },
                        Getter =
                            new nGen350RunLog.GetternGen350
                            {
                                DutyCycle = double.Parse(splitLine[6]), Current = double.Parse(splitLine[7])
                            },
                        Neutron =
                            new nGen350RunLog.NeutronnGen350
                            {
                                Counts = double.Parse(splitLine[8]),
                                CountRateRaw = double.Parse(splitLine[9]),
                                CountRateAvg = double.Parse(splitLine[10]),
                                CountRateRawStandardDevPercent = double.Parse(splitLine[11])
                            },
                        RF = new nGen350RunLog.RadioFrequencynGen350
                        {
                            FreqSynth = double.Parse(splitLine[12]),
                            Current = double.Parse(splitLine[13]),
                            Voltage = double.Parse(splitLine[14])
                        },
                        Sensors =
                            new nGen350RunLog.SensorsnGen350
                            {
                                Temperature = double.Parse(splitLine[15]), SF6Pressure = double.Parse(splitLine[16])
                            },
                        Suppressor =
                            new nGen350RunLog.SuppressornGen350
                            {
                                Current = double.Parse(splitLine[17]), Voltage = double.Parse(splitLine[18])
                            },
                        StateMachine = new nGen350RunLog.StateMachinenGen350
                        {
                            State = double.Parse(splitLine[20]),
                            Source = int.Parse(splitLine[21]),
                            Destination = int.Parse(splitLine[22]),
                            Fault = splitLine[23].Equals(OKAY)
                        }
                    };
                }
                else
                {
                    throw new Exception("Incomplete data in StarFire Operations CSV");
                }
            }
        }
    }
}
