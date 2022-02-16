using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalHelpersDefaults;

namespace Multiplicity
{
    public static partial class PulsesHelper
    {
        private static bool FileExistsAndNotEmpty(string pulseFile)
        {
            return File.Exists(pulseFile) && (new FileInfo(pulseFile).Length > 0);
        }

        public static class PoliMiFileHelper
        {
            private enum PoliMiPulseIndices
            {
                CellIndex = 0,
                TimeNanoSecIndex = 1,
                PulseTypeIndex = 2,
                HistoryIndex = 3,
                PulseHeightIndex = 4,
                EventTypeIndex = 5,
                ParticleNumberIndex = 6,
                NumberInteractionsIndex = 7,
                WeightIndex = 8
            }

            public static PoliMiPulse GetPulse(string line)
            {
                string[] d = line.Split(DEL);
                return new PoliMiPulse(ParsePoliMiInt(d[(int) PoliMiPulseIndices.CellIndex]),
                    double.Parse(d[(int) PoliMiPulseIndices.TimeNanoSecIndex].Trim()),
                    (Particle) ParsePoliMiInt(d[(int) PoliMiPulseIndices.PulseTypeIndex]),
                    ParsePoliMiInt(d[(int) PoliMiPulseIndices.HistoryIndex]),
                    double.Parse(d[(int) PoliMiPulseIndices.PulseHeightIndex]),
                    (Interaction) ParsePoliMiInt(d[(int) PoliMiPulseIndices.EventTypeIndex]),
                    ParsePoliMiInt(d[(int) PoliMiPulseIndices.ParticleNumberIndex]),
                    ParsePoliMiInt(d[(int) PoliMiPulseIndices.NumberInteractionsIndex]),
                    double.Parse(d[(int) PoliMiPulseIndices.WeightIndex].Trim())
                );
            }

            private static int ParsePoliMiInt(string poliMiString)
            {
                string fixString = poliMiString.Trim();
                return int.Parse(fixString.TrimEnd('.'));
            }

            public static void AddPulses(Pulses<PoliMiPulse> pulses)
            {
                if (FileExistsAndNotEmpty(pulses.PulseFile))
                {
                    using (StreamReader sr = new StreamReader(pulses.PulseFile))
                    {
                        sr.ReadLine(); // Read Header
                        while (!sr.EndOfStream)
                        {
                            pulses.AddPulse(GetPulse(sr.ReadLine()));
                        }
                    }
                }
            }
        }

        public static class BinaryFileHelper
        {
            private const int EVENT_SIZE = 265;
            private const int TIMESPAMP_SIZE = 8;
            private const int CHANEL_SIZE = 1;
            private const int WAVEFORM_SIZE = 2;
            private const int NRESESRVED = 2;
            private const int ARRAY_START = 0;
            private const int ADC_BITS = 14;

            private const bool RESERVED_LAST = true;

            private static FnclPulse GetPulse(byte[] buffer)
            {
                List<byte> subBuff = new List<byte>();

                int start = 0;
                int end = TIMESPAMP_SIZE - 1;
                subBuff = GetSubByteList(buffer, start, end);
                int timeStamp = (int) Math.Abs(BitConverter.ToUInt32(subBuff.ToArray(), ARRAY_START));

                subBuff.Clear();
                start = end + 1;
                end = start + CHANEL_SIZE - 1;
                // this case of start == end
                subBuff.Add(buffer[start]);
                int cell = (int) subBuff.First();

                subBuff.Clear();
                start = end + 1;
                end = start + WAVEFORM_SIZE - 1;
                subBuff = GetSubByteList(buffer, start, end);
                int baseLine = GetADCvalue(subBuff);
                subBuff.Clear();

                start = end + 1;
                end = start + WAVEFORM_SIZE - 1;

                List<int> wave = new List<int>();
                while (end < EVENT_SIZE)
                {
                    subBuff = GetSubByteList(buffer, start, end);
                    wave.Add(GetADCvalue(subBuff));
                    subBuff.Clear();
                    start = end + 1;
                    end = start + WAVEFORM_SIZE - 1;
                }

                return new FnclPulse(cell, timeStamp, baseLine, wave);
            }

            private static int GetADCvalue(List<byte> adc)
            {
                BitArray adcRawBits = new BitArray(adc.ToArray());
                BitArray adcBits = new BitArray(ADC_BITS + NRESESRVED);
                // from the Caen Manual (UM7098 pg 21), each sample is 2-byte uInt(uint16_t), the flash adc chips
                // have a resolution of 14 bits, the remaining two bits are reserved 
                // ignore reserved ADC bits
                // adcBits[0] = false;
                //adcBits[1] = false;
                // reserved are last
                if (RESERVED_LAST)
                {
                    for (int i = 0; i < ADC_BITS; i++)
                    {
                        //adcBits[i + NRESESRVED] = adcRawBits[i];
                        adcBits[i] = adcRawBits[i];
                    }
                }
                else
                {
                    // reserved are first
                    for (int i = NRESESRVED; i < ADC_BITS + NRESESRVED; i++)
                    {
                        adcBits[i] = adcRawBits[i];
                    }
                }

                //
                byte[] adcWithoutReserved = new byte[WAVEFORM_SIZE];
                adcBits.CopyTo(adcWithoutReserved, 0);
                return (int) BitConverter.ToUInt16(adcWithoutReserved, ARRAY_START);
            }

            public static void AddPulses(Pulses<FnclPulse> pulses)
            {
                List<FnclPulse> pulseList = GetPulses(pulses.PulseFile);
                foreach (var p in pulseList)
                {
                    pulses.AddPulse(p);
                }
            }

            private static List<byte> GetSubByteList(byte[] buffer, int start, int end)
            {
                List<byte> subBytes = new List<byte>();
                for (int i = start; i <= end; i++)
                {
                    subBytes.Add(buffer[i]);
                }

                return subBytes;
            }

            public static List<FnclPulse> GetPulses(string binaryFile)
            {
                List<FnclPulse> pulses = new List<FnclPulse>();
                if (FileExistsAndNotEmpty(binaryFile))
                {
                    byte[] buffer = new byte[EVENT_SIZE];
                    using (FileStream sr = new FileStream(binaryFile, FileMode.Open))
                    {
                        while (sr.Position != sr.Length)
                        {
                            sr.Read(buffer, 0, EVENT_SIZE);
                            pulses.Add(GetPulse(buffer));
                        }
                    }
                }

                return pulses;
            }
        }

        public static class FlatFileHelper
        {
            public static Pulse GetPulse(string line)
            {
                var splitLine = line.Split();
                return new Pulse(int.Parse(splitLine[0]), double.Parse(splitLine[1]), Particle.Neutron);
            }

            public static void AddPulses(Pulses<Pulse> pulses)
            {
                if (FileExistsAndNotEmpty(pulses.PulseFile))
                {
                    using (StreamReader sr = new StreamReader(pulses.PulseFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            pulses.AddPulse(GetPulse(sr.ReadLine()));
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException(pulses.PulseFile);
                }
            }
        }
    }
}