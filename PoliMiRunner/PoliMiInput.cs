using System.Collections.Generic;
using System.IO;
using GlobalHelpers;

namespace Runner
{
    public class PoliMiInput
    {
        public int NumberReplacementSections
        {
            get { return basisFileZones.Count - 1; }
        }

        private const string OUT_EXT = ".inp";
        private readonly string basisFile;
        private List<List<string>> basisFileZones;
        private readonly string detectorFile;
        private readonly string detectorFileName;

        public PoliMiInput(string basisInputFile, string detectorFileForAllCases)
        {
            basisFile = basisInputFile;
            detectorFile = detectorFileForAllCases;
            detectorFileName = Path.GetFileName(detectorFile);
            if (!File.Exists(basisFile))
            {
                throw new FileNotFoundException(basisInputFile);
            }

            basisFileZones = ReplacementFileHelper.GetFileZones(basisFile);
        }

        public List<string> WritePoliMiInputFiles(string fullPathWithRootNameNoExtension, string replacementDataFile)
        {
            return WriteInputFiles(fullPathWithRootNameNoExtension,
                ReplacementFileHelper.GetReplacements(replacementDataFile));
        }

        public List<string> WritePoliMiInputFiles(string fullPathWithRootNameNoExtension,
            List<ReplacementText> replacements)
        {
            return WriteInputFiles(fullPathWithRootNameNoExtension, replacements);
        }

        private List<string> WriteInputFiles(string fullPathWithRootNameNoExtension, List<ReplacementText> replacements)
        {
            List<string> filesMade = new List<string>();
            foreach (var r in replacements)
            {
                string outFile = fullPathWithRootNameNoExtension + r.Name + OUT_EXT;
                ReplacementFileHelper.WriteFile(basisFile, outFile, r);
                filesMade.Add(outFile);
            }

            return filesMade;
        }

        public List<string> WriteEachInputFileToOwnDirectory(string topDir, List<ReplacementText> replacements)
        {
            return WriteInputsToDirectories(topDir, replacements);
        }

        private List<string> WriteInputsToDirectories(string topDir, List<ReplacementText> replacements)
        {
            List<string> filesMade = new List<string>();
            foreach (var r in replacements)
            {
                string outDir = Path.Combine(topDir + @"\", r.Name);
                string outFile = Path.Combine(outDir, r.Name + OUT_EXT);
                CreateDirectoryAndCopyDetector(outDir);
                ReplacementFileHelper.WriteFile(basisFile, outFile, r);
                filesMade.Add(outFile);
            }

            return filesMade;
        }

        public List<string> WriteEachInputFileToOwnDirectory(string topDir, string replacementDataFile)
        {
            return WriteInputsToDirectories(topDir, ReplacementFileHelper.GetReplacements(replacementDataFile));
        }

        private void CreateDirectoryAndCopyDetector(string outDir)
        {
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            File.Copy(detectorFile, Path.Combine(outDir, detectorFileName), true);
        }
    }
}
