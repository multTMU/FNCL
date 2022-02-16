using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GlobalHelpersDefaults
{
    public static class FnclSettingsFileHelper
    {
        private const string SETTINGS_FILE = "settings.xml";

        public static void SetPsdCalibrationFromSettings(string binaryFile)
        {
            SetPsdCalibrationFromFnclSettings(GetSettingsFileFromBinary(binaryFile));
        }

        private static string GetSettingsFileFromBinary(string binaryFile)
        {
            return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(binaryFile)), SETTINGS_FILE);
        }

        public static void SetPsdCalibrationFromFnclSettings(string file)
        {
            const string PSD_SETTINGS = @"/project/dataProcessing/";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);

            XmlNode xNode = xDoc.DocumentElement.SelectSingleNode(PSD_SETTINGS + "psdFastInterval");
            int psdFast = (int)(double.Parse(xNode.InnerText));
            //int.Parse(xNode.InnerText);

            xNode = xDoc.DocumentElement.SelectSingleNode(PSD_SETTINGS + "psdSlowInterval");
            int psdSlow = (int)(double.Parse(xNode.InnerText));

            const string PSD_CALIBRATION = @"/project/psdCalibration";

            xNode = xDoc.DocumentElement.SelectSingleNode(PSD_CALIBRATION);

            PulseShapeDiscriminationCalibration.Refresh();

            foreach (XmlNode p in xNode.SelectNodes("polylines"))
            {
                PulseShapeDiscriminationCalibration.SetDetector(GetKey(p),
                    new PsdSpecification(psdSlow, psdFast, GetPolyLines(p), FnclHelpers.PSD_TYPE,
                        FnclHelpers.PSD_PEAKMAX_TRIGGER, FnclHelpers.DEFAULT_AMPLITUDE_SCALAR));
            }
        }

        private static List<PsdComponent> GetPolyLines(XmlNode xmlNode)
        {
            List<PsdComponent> polyLines =
                new List<PsdComponent>();

            foreach (XmlNode p in xmlNode.SelectNodes("points"))
            {
                polyLines.Add(new PsdComponent
                {
                    PSD = double.Parse(p.SelectSingleNode("y").InnerText),
                    Amplitude = double.Parse(p.SelectSingleNode("x").InnerText)
                });
            }

            return polyLines;
        }

        private static DetectorKey GetKey(XmlNode xmlNode)
        {
            int detIndex = int.Parse(xmlNode.SelectSingleNode("index").InnerText);
            return FNCLdetectorDictionary.GetKeyByIndex(detIndex);
        }
    }
}
