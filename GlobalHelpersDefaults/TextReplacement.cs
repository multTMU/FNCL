using System;
using System.Collections.Generic;
using System.IO;

namespace GlobalHelpers
{
    public struct ReplacementText
    {
        public string Name;
        public List<List<string>> TextLists;
    }

    public static class ReplacementFileHelper
    {
        private const string START_FLAG = "<<<";
        private const string END_FLAG = ">>>";
        private const char NAME_FLAG = '#';

        public static List<ReplacementText> GetReplacements(string replacementFile)
        {
            List<ReplacementText> replacements = new List<ReplacementText>();
            using (StreamReader sr = new StreamReader(replacementFile))
            {
                bool firstAlreadyFound = false;
                bool foundStart = false;
                bool addToBuffer = false;
                List<string> buffer = new List<string>();
                ReplacementText replacementBuffer = new ReplacementText();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.StartsWith(NAME_FLAG.ToString()))
                    {
                        if (firstAlreadyFound)
                        {
                            replacements.Add(replacementBuffer);
                        }

                        firstAlreadyFound = true;

                        replacementBuffer = new ReplacementText
                        {
                            Name = line.Replace(NAME_FLAG, ' ').Trim(), TextLists = new List<List<string>>()
                        };
                    }

                    if (line.Contains(START_FLAG))
                    {
                        if (!foundStart)
                        {
                            foundStart = true;
                            addToBuffer = true;
                            continue;
                        }
                        else
                        {
                            throw new Exception("Found multiple Start Flags before an End Flag");
                        }
                    }
                    else if (line.Contains(END_FLAG))
                    {
                        if (!foundStart)
                        {
                            throw new Exception("Found End Flag First");
                        }

                        replacementBuffer.TextLists.Add(buffer);
                        buffer = new List<string>();
                        foundStart = false;
                        addToBuffer = false;
                        continue;
                    }

                    if (addToBuffer)
                    {
                        buffer.Add(line);
                    }
                }

                replacements.Add(replacementBuffer);
            }

            return replacements;
        }

        public static List<List<string>> GetFileZones(string basisFile)
        {
            List<List<string>> basisFileZones = new List<List<string>>();
            using (StreamReader sr = new StreamReader(basisFile))
            {
                bool foundStart = false;
                bool addToBuffer = true;
                List<string> buffer = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Contains(START_FLAG))
                    {
                        if (!foundStart)
                        {
                            foundStart = true;
                            addToBuffer = false;
                        }
                        else
                        {
                            throw new Exception("Found multiple Start Flags before an End Flag");
                        }
                    }
                    else if (line.Contains(END_FLAG))
                    {
                        if (!foundStart)
                        {
                            throw new Exception("Found End Flag First");
                        }

                        basisFileZones.Add(buffer);
                        buffer = new List<string>();
                        foundStart = false;
                        addToBuffer = true;
                        continue;
                    }

                    if (addToBuffer)
                    {
                        buffer.Add(line);
                    }
                }

                basisFileZones.Add(buffer);
            }

            return basisFileZones;
        }

        public static void WriteFile(string basisFile, string outputFile, ReplacementText replacement,
            bool MCNPformat = false)
        {
            List<List<string>> basisFileZones = GetFileZones(basisFile);
            int NumberReplacementSections = basisFileZones.Count - 1;
            List<List<string>> fillText = replacement.TextLists;

            if (fillText.Count != NumberReplacementSections)
            {
                throw new Exception("Default Detector: Too little/much fill text for found gaps");
            }

            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                for (int i = 0; i < NumberReplacementSections + 1; i++)
                {
                    foreach (var s in basisFileZones[i])
                    {
                        if (MCNPformat)
                        {
                            foreach (var f in MCNPformatHelper.FormatLines(s))
                            {
                                sw.WriteLine(f);
                            }
                        }
                        else
                        {
                            sw.WriteLine(s);
                        }
                    }

                    if (i < NumberReplacementSections)
                    {
                        foreach (var s in fillText[i])
                        {
                            if (MCNPformat)
                            {
                                foreach (var f in MCNPformatHelper.FormatLines(s))
                                {
                                    sw.WriteLine(f);
                                }
                            }
                            else
                            {
                                sw.WriteLine(s);
                            }
                        }
                    }
                }
            }
        }
    }
}
