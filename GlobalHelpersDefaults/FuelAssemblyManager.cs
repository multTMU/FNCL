using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobalHelpers
{
    public struct FuelAssemblySpecification
    {
        public int nRodsRow;
        public int nRodsColumn;

        public double ArrayPitch;
        public double FuelPinRadius;

        public double CladdingInnerRadius;
        public double CladdingOuterRadius;

        public double CoolingChannelInnerRadius;
        public double CoolingChannelOuterRadius;

        public double Length;
    }

    public static class FuelAssemblyManager
    {
        private const int DEFAULT_NUMBER_COLUMNS_ROWS = 17;

        public static int GetDefaultRowsAndColumns()
        {
            return DEFAULT_NUMBER_COLUMNS_ROWS;
        }

        private static Dictionary<Tuple<int, int>, FuelAssemblySpecification> Assemblies;

        public static void InitializeDictionary(string assemblyFile = FuelAssembly.DEFAULT_FILE)
        {
            if (File.Exists(assemblyFile))
            {
                Assemblies = AssembliesFileReader.ReadAssemblySpecifications(assemblyFile);
            }
            else
            {
                throw new FileNotFoundException("Assembly Dictionary file not found: " + assemblyFile);
            }
        }

        public static FuelAssemblySpecification GetFuelAssemblySpecification(int N)
        {
            return GetFuelAssemblySpecification(N, N);
        }

        public static FuelAssemblySpecification GetFuelAssemblySpecification(int nRows, int nColumns)
        {
            Tuple<int, int> key = new Tuple<int, int>(nRows, nColumns);
            try
            {
                return Assemblies[key];
            }
            catch
            {
                return Assemblies.Values.First();
            }
        }

        private static class AssembliesFileReader
        {
            private const char DEL = ',';
            private const string COMMENT = "#";

            private const int INDEX_nRodsRow = 0;
            private const int INDEX_nRodsColumn = 1;

            private const int INDEX_ArrayPitch = 2;

            private const int INDEX_FuelPinRadius = 3;

            private const int INDEX_CladdingInnerRadius = 4;
            private const int INDEX_CladdingOuterRadius = 5;

            private const int INDEX_CoolingChannelInnerRadius = 6;
            private const int INDEX_CoolingChannelOuterRadius = 7;

            private const int INDEX_Length = 8;

            public static Dictionary<Tuple<int, int>, FuelAssemblySpecification> ReadAssemblySpecifications(
                string assembliesFile)
            {
                Dictionary<Tuple<int, int>, FuelAssemblySpecification> dict =
                    new Dictionary<Tuple<int, int>, FuelAssemblySpecification>();
                using (StreamReader sr = new StreamReader(assembliesFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string curLine = sr.ReadLine();
                        if (NoComment(curLine))
                        {
                            try
                            {
                                var splitLine = curLine.Split(DEL);
                                FuelAssemblySpecification fuel = new FuelAssemblySpecification
                                {
                                    nRodsRow = int.Parse(splitLine[INDEX_nRodsRow]),
                                    nRodsColumn = int.Parse(splitLine[INDEX_nRodsColumn]),
                                    ArrayPitch = double.Parse(splitLine[INDEX_ArrayPitch]),
                                    FuelPinRadius = double.Parse(splitLine[INDEX_FuelPinRadius]),
                                    CladdingInnerRadius = double.Parse(splitLine[INDEX_CladdingInnerRadius]),
                                    CladdingOuterRadius = double.Parse(splitLine[INDEX_CladdingOuterRadius]),
                                    CoolingChannelInnerRadius =
                                        double.Parse(splitLine[INDEX_CoolingChannelInnerRadius]),
                                    CoolingChannelOuterRadius =
                                        double.Parse(splitLine[INDEX_CoolingChannelOuterRadius]),
                                    Length = double.Parse(splitLine[INDEX_Length])
                                };

                                Tuple<int, int> key = new Tuple<int, int>(fuel.nRodsRow, fuel.nRodsColumn);

                                try
                                {
                                    dict.Add(key, fuel);
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

                return dict;
            }

            private static bool NoComment(string line)
            {
                return !line.Contains(COMMENT);
            }
        }
    }
}
