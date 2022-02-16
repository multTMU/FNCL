using System.Collections.Generic;
using System.IO;

namespace Multiplicity
{
    public static partial class PulsesHelper
    {
        public static Pulses<FnclPulse> GetFnclBinaryFilePulses(string file)
        {
            Pulses<FnclPulse> fncl = new FnclWaveformPulses(file);
            BinaryFileHelper.AddBinaryPulses(fncl);
            return fncl;
        }

        private class FnclWaveformPulses : Pulses<FnclPulse>
        {
            public FnclWaveformPulses(string file) : base(file, false, PulseFileType.FnclBinary)
            {
            }

            public FnclWaveformPulses() : base(string.Empty, false, PulseFileType.FnclBinary)
            {
            }
        }

        public static void SavePulsesFlat<TPulse>(string saveFile, List<TPulse> pulses, bool append = false)
            where TPulse : IPulse
        {
            using (StreamWriter sw = new StreamWriter(saveFile, append))
            {
                foreach (var p in pulses)
                {
                    sw.WriteLine(FlatFileHelper.GetFileLine(p));
                }
            }
        }
    }
}
