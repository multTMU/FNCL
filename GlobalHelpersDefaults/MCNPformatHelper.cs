using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalHelpers
{
    public static class MCNPformatHelper
    {
        private const int MAX_CHARS = 80 - 2;
        private const char STARTLINE_COMMENT = 'c';
        private const char ENDLINE_COMMENT = '$';
        private const string CONTINUE = "     "; // 5 spaces (I visually prefer this over & )

        public static List<string> FormatLines(List<string> mcnpLines) //, bool trimLines = true)
        {
            List<string> formatedString = new List<string>();

#if DEBUG
            // sometimes null when a sourceless problem is made in testing and development
            // this should fail when really running
            if (mcnpLines != null)
            {
#endif
                foreach (var sOne in mcnpLines)
                {
                    // sometimes newLines are in strings
                    foreach (var s in sOne.Split(new[] {Environment.NewLine}, StringSplitOptions.None))
                    {
                        string format = s;
                        //if (trimLines)
                        //{
                        format = s.Replace('\t', ' ');
                        // format = format.Replace("  ", " ");
                        // }

                        // do not trim, for case when leading blank columns used for line continuation
                        if (LineIsNotEmpty(format))
                        {
                            if (SingleLine(format))
                            {
                                formatedString.Add(format);
                            }
                            else
                            {
                                formatedString.AddRange(GetWrappedString(format));
                            }
                        }
                    }
                }
#if DEBUG
            }
#endif
            return formatedString;
        }

        private static bool LineIsNotEmpty(string formatedString)
        {
            return !string.IsNullOrWhiteSpace(formatedString);
        }

        public static List<string> FormatLines(string mcnpLine)
        {
            return FormatLines(new List<string>() {mcnpLine});
        }

        public static void FormatThenWriteToFile(string file, List<string> mcnpLines)
        {
            List<string> formatedLines = FormatLines(mcnpLines);
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (var m in formatedLines)
                {
                    sw.WriteLine(m);
                }
            }
        }

        public static string GetCommentLine(string comment = "")
        {
            return STARTLINE_COMMENT.ToString() + " " + comment;
        }

        public static string GetInLineComment(string comment = "")
        {
            return ENDLINE_COMMENT.ToString() + " " + comment;
        }

        private static List<string> GetWrappedString(string line)
        {
            List<string> wrap = new List<string>();

            List<string> textBlocks = line.Split(' ').ToList();

            string subString = "";

            foreach (var s in textBlocks)
            {
                if (LineIsNotEmpty(s))
                {
                    if (SingleLine(subString + s))
                    {
                        subString += s + " ";
                    }
                    else
                    {
                        wrap.Add(subString);
                        subString = CONTINUE + s + " ";
                    }
                }
            }

            wrap.Add(subString.TrimEnd());
            return wrap;
        }

        private static bool SingleLine(string line)
        {
            return (lineLessThanMax(line) || lineLeadingComment(line) || lineEndComment(line));
        }

        private static bool lineEndComment(string line)
        {
            if (line.Contains(ENDLINE_COMMENT.ToString()))
            {
                return (line.IndexOf(ENDLINE_COMMENT) <= MAX_CHARS);
            }

            return false;
        }

        private static bool lineLessThanMax(string line)
        {
            return line.Length <= MAX_CHARS;
        }

        private static bool lineLeadingComment(string line)
        {
            if (line.Length == 1)
            {
                return line[0].Equals(STARTLINE_COMMENT);
            }
            else if (line.Length == 0)
            {
                return true;
            }
            else // test for "c abc..." for valid comment, "cabc" is invalid
            {
                return line[0].Equals(STARTLINE_COMMENT) && line[1].Equals(' ');
            }
        }

        public static string GetNewLineBuffer()
        {
            return CONTINUE;
        }

        public static string GetSurface(int index, string surfaceDefinition, string comment = "")
        {
            return index.ToString() + " " + surfaceDefinition + " " + GetInLineComment(comment);
        }

        public static string GetCell(int index, MaterialElement material, List<string> surfaces, string comment = "")
        {
            string cell = index + " " + material.ToCell() + " ";

            foreach (var s in surfaces)
            {
                cell += s + " ";
            }

            cell += UniverseAndImportanceHelper.UniverseAndImportance();
            cell += GetInLineComment(comment);
            return cell;
        }

        public static List<string> ConvertIntListToStringList(List<int> intList)
        {
            List<string> stringList = new List<string>();
            foreach (var s in intList)
            {
                stringList.Add(s.ToString());
            }

            return stringList;
        }

        public static string GetCell(int index, MaterialElement material, List<int> surfaces, string comment = "")
        {
            return GetCell(index, material, ConvertIntListToStringList(surfaces), comment);
            //string cell = index + " " + material.ToCell() + " ";

            //foreach (var s in surfaces)
            //{
            //    cell += s.ToString() + " ";
            //}

            //cell += UniverseAndImportanceHelper.UniverseAndImportance();
            //cell += GetInLineComment(comment);
            //return cell;
        }

        public static string ConvertListToSpacedString<T>(List<T> list)
        {
            string line = " ";
            foreach (var s in list)
            {
                line += s.ToString() + " ";
            }

            return line;
        }

        public static string GetCell(int index, MaterialElement material, int surface, string comment = "")
        {
            return GetCell(index, material, new List<int>() {surface}, comment);
        }


        //private static string GetComment(string comment)
        //{
        //    if (!string.IsNullOrEmpty(comment))
        //    {
        //        return " " + GetInLineComment(comment);
        //    }

        //    return string.Empty;
        //}
    }

    public static class WriterHelper
    {
        private const string MATERIALS_COMMENT = "MATERIALS";

        public static string GetFuelCellLine(int negativeIndex, int positiveIndex, int row, int col, int key,
            string importance, string numberFormat)
        {
            var mat = MaterialManager.GetMaterial(key);
            string cellStr = GetPinNumber(negativeIndex, row, col, numberFormat);
            string outStr = GetPinNumber(positiveIndex, row, col, numberFormat);
            string comment = MCNPformatHelper.GetInLineComment(mat.Comment.Trim()) +
                             GetRowColString(row, col, numberFormat);

            string final = cellStr + " " + mat.ToCell() + " -" + cellStr + " " + outStr + " " + importance + " " +
                           comment;
            return RemoveExtraSpace(final);
        }

        public static string GetFuelPinCellLine(int leadingIndex, int row, int col, int key, string importance,
            string numberFormat)
        {
            var mat = MaterialManager.GetMaterial(key);
            string cellStr = GetPinNumber(leadingIndex, row, col, numberFormat);
            string comment = MCNPformatHelper.GetInLineComment(mat.Comment.Trim()) +
                             GetRowColString(row, col, numberFormat);

            string final = cellStr + " " + mat.ToCell() + " -" + cellStr + " " + importance + " " + comment;
            return RemoveExtraSpace(final);
        }

        public static string RemoveExtraSpace(string line)
        {
            return line.Replace("  ", " ");
        }

        private static string GetRowColString(int row, int col, string numberFormat)
        {
            return "," + " row = " + row.ToString(numberFormat) + " col = " +
                   col.ToString(numberFormat);
        }

        public static string GetFuelPinSurfaceLine(int leadingIndex, int row, int col, string numberFormat)
        {
            return GetPinNumber(leadingIndex, row, col, numberFormat);
        }

        public static string GetPinNumber(int leadingIndex, int row, int col, string numberFormat)
        {
            return leadingIndex.ToString() + row.ToString(numberFormat) + col.ToString(numberFormat);
        }

        public static List<string> GetMaterialCardSpecification(int key)
        {
            return GetMaterialCardSpecification(MaterialManager.GetMaterial(key));
        }

        public static List<string> GetMaterialCardSpecification(MaterialElement material)
        {
            List<string> materialCard = new List<string>();
            materialCard.Add(MCNPformatHelper.GetCommentLine(material.Comment));
            materialCard.Add(material.ToCard());

            return MCNPformatHelper.FormatLines(materialCard); //, false);
        }

        public static string GetMaterialHeader()
        {
            return MCNPformatHelper.GetCommentLine(MATERIALS_COMMENT);
        }

        // MCNP doesn't like when the m# are non-ascending
        private static List<MaterialElement> GetSortedMaterialList(List<int> materialsUsed)
        {
            List<MaterialElement> sortedMatIndex = new List<MaterialElement>();
            foreach (var m in materialsUsed)
            {
                sortedMatIndex.Add(MaterialManager.GetMaterial(m));
            }

            sortedMatIndex.Sort((x, y) => x.MaterialIndex.CompareTo(y.MaterialIndex));
            return sortedMatIndex;
        }

        public static List<string> GetMaterialCard()
        {
            var materialsUsed = new List<int>(MaterialManager.GetMaterialsUsed());
            var sortedMaterials = GetSortedMaterialList(materialsUsed);
            List<string> materialCard = new List<string>();
            materialCard.Add(GetMaterialHeader());
            foreach (var key in sortedMaterials)
            {
                materialCard.AddRange(GetMaterialCardSpecification(key));
            }

            MaterialManager.ClearMaterialsUsed();
            return materialCard;
        }

        public static string GetFuelAssemblyInterior(Tuple<string, string> surfacesInsideAssembly, int gapMaterial,
            string importance)
        {
            var material = MaterialManager.GetMaterial(gapMaterial);
            return surfacesInsideAssembly.Item1 + " " + material.ToCell() + " " + surfacesInsideAssembly.Item2 + " " +
                   importance;
        }
    }
}
