using System.IO;

namespace Multiplicity
{
    public static partial class PulsesHelper
    {
        private const char DEL = ',';
        private const long LARGE_FILE_THRESHOLD_BYTES = (long)1.1e8; // 110MB
        private static long largeFileBytes = LARGE_FILE_THRESHOLD_BYTES;

        public static void OverrideLargeFileThreshold(long fileThreshold)
        {
            largeFileBytes = fileThreshold;
        }

        public static double ConvertActivityToPerNanoSec(double activity)
        {
            return (1e-9) * activity;
        }

        public static double ConvertCuriesToActivity(double curies)
        {
            return curies * (3.7e10);
        }

        public static double ConvertSecondsToNanoSeconds(double seconds)
        {
            return seconds * (1e9);
        }

        public static double ConvertNanoSecondsToSeconds(double nanoSeconds)
        {
            return nanoSeconds * (1e-9);
        }

        private static bool fileIsToBigToReadAtOnce(string file)
        {
            if (File.Exists(file))
            {
                var fileInfo = new FileInfo(file);
                return (fileInfo.Length > largeFileBytes);
            }

            // Is possible to have no pulse file, in DRF calculations where detector is completely insensitive
            return false;
        }

        public static bool isFlatFile(string firstLine)
        {
            return NGamSnlFileHelper.isFlatFile(firstLine);
        }
    }
}
