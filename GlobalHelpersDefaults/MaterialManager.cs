using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalHelpers
{
    //[Serializable]
    public struct MaterialElement
    {
        private const string MAT = "m";
        private const string THERMAL = "mt";

        public int MaterialIndex { get; set; }
        public string Density { get; set; }
        public List<string> Specification { get; set; }
        public string Comment { get; set; }

        public string ToCell()
        {
            return MaterialIndex + " " + Density;
        }

        public string ToCard()
        {
            bool passedFirstLine = false;
            string card = MAT + MaterialIndex;
            foreach (var s in Specification)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if (!passedFirstLine)
                    {
                        card += " " + s;
                        passedFirstLine = true;
                    }
                    else
                    {
                        card += Environment.NewLine + (s.Contains(THERMAL) ? "" : MCNPformatHelper.GetNewLineBuffer()) +
                                s;
                    }
                }
            }

            return card;
        }
    }

    public static class MaterialManager
    {
        private static Dictionary<int, MaterialElement> Materials = new Dictionary<int, MaterialElement>();
        private static List<int> MaterialsUsed = new List<int>();
        private static string userMaterialFile = "";

        public const int VOID = 0;

        private static MaterialElement voidMaterial = new MaterialElement
        {
            MaterialIndex = VOID, Density = " ", Specification = new List<string>() {""}, Comment = "* Void"
        };

        public static void ClearMaterialsUsed()
        {
            MaterialsUsed.Clear();
        }

        public static void
            InitializeDictionary(string materialFile,
                string UserMaterialFile) // = GlobalHelpers.Materials.DEFAULT_FILE)
        {
            userMaterialFile = UserMaterialFile;
            if (File.Exists(materialFile))
            {
                ClearMaterialsUsed();
                Materials = MaterialFileReader.ReadMaterials(materialFile);
                Materials.Add(VOID, voidMaterial);
                if (File.Exists(GlobalHelpers.Materials.USER_FILE))
                {
                    try
                    {
                        foreach (var um in MaterialFileReader.ReadMaterials(userMaterialFile))
                        {
                            Materials.Add(um.Key, um.Value);
                        }
                    }
                    catch
                    {
                        throw new Exception("Error Reading UserMaterialDefinitions.txt");
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Material Dictionary file not found: " + materialFile);
            }
        }

        public static MaterialElement GetMaterial(int key)
        {
            LogThatThisMaterialWasUsed(key);
            return Materials[key];
        }

        public static List<int> GetMaterialsUsed()
        {
            return MaterialsUsed;
        }

        private static List<MaterialElement> GetAllMaterials()
        {
            List<MaterialElement> mats = new List<MaterialElement>();
            foreach (var m in Materials)
            {
                mats.Add(m.Value);
            }

            return mats;
        }

        public static Dictionary<int, MaterialElement> GetClone()
        {
            Dictionary<int, MaterialElement> dict = new Dictionary<int, MaterialElement>();
            foreach (var m in GetAllMaterials())
            {
                dict.Add(m.MaterialIndex, m);
            }

            return dict;
        }


        private static void LogThatThisMaterialWasUsed(int key)
        {
            if (key != VOID)
            {
                MaterialsUsed.Add(key);
                MaterialsUsed = MaterialsUsed.Distinct().ToList();
            }
        }

        private static class MaterialFileReader
        {
            // private static string MaterialFile;
            private static bool OldFormat;
            private const char SPEC = ' ';
            private const int PAIR = 2;

            private const char DEL = ',';
            private const string COMMENT = "#";
            private const int KEY = 0;
            private const int MCNP = 1;
            private const int DENSITY = 3;
            private const int DESCRIPTION = 2;
            private const int MAT_COMMENT = 4;

            private const int OLD_FORMAT_LENGTH = 5;
            private const int NEW_FORMAT_INDEX_OFFSET = -1;

            public static void SaveMaterials(string materialFile, Dictionary<int, MaterialElement> materials)
            {
                //   MaterialFile = materialFile;
                using (StreamWriter sw = new StreamWriter(materialFile))
                {
                    sw.WriteLine(COMMENT + "MCNP Materials Date Modified " + DateTime.Now);
                    foreach (var m in materials)
                    {
                        sw.WriteLine(GetLineForMaterial(m.Value));
                    }
                }
            }

            private static string GetLineForMaterial(MaterialElement mat)
            {
                string spec = string.Empty;
                foreach (var s in mat.Specification)
                {
                    spec += s + SPEC.ToString();
                }

                return mat.MaterialIndex.ToString() + DEL.ToString() +
                       spec.TrimEnd(SPEC) + DEL.ToString() + mat.Density + DEL.ToString() + mat.Comment;
            }


            public static Dictionary<int, MaterialElement> ReadMaterials(string materialFile)
            {
                //  MaterialFile = materialFile;
                Dictionary<int, MaterialElement> dict = new Dictionary<int, MaterialElement>();
                OldFormat = false;
                bool formatNotSet = true;
                using (StreamReader sr = new StreamReader(materialFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string curLine = sr.ReadLine();
                        if (NoComment(curLine))
                        {
                            try
                            {
                                var splitLine = curLine.Split(DEL);

                                if (formatNotSet)
                                {
                                    OldFormat = (splitLine.Length == OLD_FORMAT_LENGTH);
                                    formatNotSet = false;
                                }

                                int key = int.Parse(splitLine[KEY]);
                                var material = GetMaterialElement(splitLine, key);
                                try
                                {
                                    if (key != VOID && material.MaterialIndex != VOID)
                                    {
                                        dict.Add(key, material);
                                    }
                                    else
                                    {
                                        throw new Exception("Cannot add a Material with indices of " + VOID +
                                                            " is reserved for VOID");
                                    }
                                }
                                catch
                                {
                                    throw new Exception("Potential Non-Unique Dictionary Key: " + key.ToString());
                                }
                            }
                            catch
                            {
                                throw new FileLoadException("Error in line (check no comma in description): " +
                                                            curLine);
                            }
                        }
                    }
                }

                if (OldFormat)
                {
                    SaveMaterials(materialFile, dict);
                }

                return dict;
            }

            public static void AddMaterial(string userMaterialFile, MaterialElement material)
            {
                using (StreamWriter sw = new StreamWriter(userMaterialFile, true))
                {
                    string materialLine = string.Empty;
                }
            }

            private static MaterialElement GetMaterialElement(string[] splitLine, int key)
            {
                int offset = OldFormat ? 0 : NEW_FORMAT_INDEX_OFFSET;
                return new MaterialElement
                {
                    MaterialIndex = key,
                    Density = splitLine[DENSITY + offset].Trim(),
                    Specification =
                        GetSpecification(splitLine[DESCRIPTION + offset]),
                    Comment = splitLine[MAT_COMMENT + offset].Trim()
                };
            }

            // MCNP doesn't like it when a material specification is line wrapped, wants one spec per line
            private static List<string> GetSpecification(string spec)
            {
                //spec = spec.Replace("  ", " ");
                var split = spec.Split(SPEC);
                List<string> specification = new List<string>();
                string chunk = string.Empty;
                int nPair = 0;
                foreach (var s in split)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        nPair++;
                        chunk += s.Trim() + SPEC;

                        if (nPair == PAIR)
                        {
                            specification.Add(chunk.Trim());
                            chunk = string.Empty;
                            nPair = 0;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(chunk))
                {
                    specification.Add(chunk);
                }

                return specification;
            }

            private static bool NoComment(string line)
            {
                return !line.Contains(COMMENT);
            }
        }
    }
}
