using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public partial class FuelAssemblyComponent : IComponentSpecification
    {
        public struct PinKey
        {
            public int Row;
            public int Col;

            public PinKey(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }

        private const string BASE_FORMAT = "D";
        private static string numberFormat;

        private readonly FuelCells fuelCells;
        private readonly FuelSurfaces fuelSurfaces;
        private const PoliMiSource SOURCE_U238SF = PoliMiSource.U238Sf;
        public SourceSpecification FuelPinSource { get; private set; }
        private readonly bool hasSourceTerm;

        public FuelAssemblyComponent(string fuelArrayFile, bool useSpontaneousFissionSource) : this(
            new FuelArray(fuelArrayFile), useSpontaneousFissionSource)
        {
        }

        public FuelAssemblyComponent(FuelArray fuelArray, bool HasSourceTerm)
        {
            fuelCells = new FuelCells(fuelArray);
            fuelSurfaces = new FuelSurfaces(fuelArray);
            SetNumberFormat(fuelArray.MaxRow, fuelArray.MaxColumn);
            hasSourceTerm = HasSourceTerm;
        }

        public void OverrideDefaultFuelCenter(MyPoint3D fuelCenter)
        {
            fuelSurfaces.SetFuelCenter(fuelCenter);
        }

        public void OverrideDefaultBoxBuffer(double additionalSpacing)
        {
            fuelSurfaces.OverrideDefaultBoxBuffer(additionalSpacing);
        }

        public void OverrideDefaultLeadingIndices(int fuel, int gap, int clad)
        {
            fuelCells.SetLeadingIndices(fuel, gap, clad);
            fuelSurfaces.SetLeadingIndices(fuel, gap, clad);
        }

        public void OverrideDefaultMaterials(int newCladMaterial, int newGapMaterial)
        {
            fuelCells.SetMaterialIndices(newCladMaterial, newGapMaterial);
        }

        public void MakeCells()
        {
            fuelCells.MakeFuelCells(fuelSurfaces.GetSurfacesInsideAssemblyOutsidePins(),
                fuelSurfaces.GetSurfacesInsideOfSmallBoundingBox());
            MakeFuelPinSource();
        }

        private void MakeFuelPinSource()
        {
            FuelPinSource = new SourceSpecification(SOURCE_U238SF,
                SourcesHelper.GetBoundSourceForManyCells(fuelCells.FuelOnlyCells, fuelSurfaces.fuelBoundCuboid));
        }

        public void MakeSurfaces()
        {
            fuelSurfaces.MakeFuelSurfaces();
        }

        public void MakeComponent()
        {
            MakeSurfaces();
            MakeCells();
        }

        public void SaveCells(string cellFile)
        {
            fuelCells.SaveAllToFile(cellFile);
        }

        public void SaveSurfaces(string surfaceFile)
        {
            fuelSurfaces.SaveAllToFile(surfaceFile);
        }

        public List<string> GetSurfaces()
        {
            return fuelSurfaces.Surfaces;
        }

        public string GetComments(bool withInLineComment)
        {
            return "Fuel Assembly";
        }

        public List<string> GetCells()
        {
            return fuelCells.Cells;
        }

        private void SetNumberFormat(int maxRow, int maxCol)
        {
            int maxIndex = Math.Max(maxRow, maxCol);
            if (maxIndex >= 100 && maxIndex < 1000)
            {
                numberFormat = BASE_FORMAT + "3";
            }
            else
            {
                numberFormat = BASE_FORMAT + "2";
            }
        }

        public List<string> GetTransformations()
        {
            return new List<string>();
        }

        public List<string> GetExternalSurfaces()
        {
            return new List<string>() {fuelSurfaces.BoundingSurface};
        }

        public SourceSpecification GetSource()
        {
            return FuelPinSource;
        }

        public bool HasSourceTerm()
        {
            return hasSourceTerm;
        }
    }


    public class FuelArray
    {
        private const char IsNotFuelPin = '-';

        public struct FuelArrayElement
        {
            public int Material;
            public int RowIndex;
            public int ColIndex;
            public bool FuelPin;
        }

        public int NumberOfFuelElements
        {
            get { return Fuel.Count; }
        }

        public List<FuelArrayElement> Fuel { get; }

        public int MaxRow
        {
            get { return Fuel.Last().RowIndex + 1; }
        }

        public int MaxColumn
        {
            get { return Fuel.Last().ColIndex + 1; }
        }

        private readonly string fuelArrayFile;

        public FuelArray(string FuelArrayFile)
        {
            fuelArrayFile = FuelArrayFile;
            Fuel = FuelMaterialHelpers.ReadFuelArrayFile(fuelArrayFile);
        }

        public FuelArray()
        {
            fuelArrayFile = string.Empty;
            Fuel = new List<FuelArrayElement>();
        }

        private static bool IsFuelPin(string testMaterial)
        {
            return !testMaterial.Contains(IsNotFuelPin);
        }

        public static class FuelMaterialHelpers
        {
            private const char DEL = ',';
            private const string COMMENT = "#";

            public static List<FuelArrayElement> ReadFuelArrayFile(string arrayFile)
            {
                List<FuelArrayElement> fuel = new List<FuelArrayElement>();

                using (StreamReader sr = new StreamReader(arrayFile))
                {
                    int row = 0;
                    while (!sr.EndOfStream)
                    {
                        string curLine = sr.ReadLine();
                        if (NoComment(curLine))
                        {
                            var splitLine = curLine.Split(DEL);
                            for (int col = 0; col < splitLine.Length; col++)
                            {
                                fuel.Add(new FuelArrayElement
                                {
                                    Material = Math.Abs(int.Parse(splitLine[col])),
                                    RowIndex = row,
                                    ColIndex = col,
                                    FuelPin = IsFuelPin(splitLine[col])
                                });
                            }

                            row++;
                        }
                    }
                }

                return fuel;
            }

            public static void WriteFuelArrayFile(string arrayFile, FuelArray fuel,
                string comment = "")
            {
                var fuelDict = GetFuelPinDictionary(fuel.Fuel);

                using (StreamWriter sw = new StreamWriter(arrayFile))
                {
                    sw.WriteLine(COMMENT + " " + DateTime.Now);
                    sw.WriteLine(COMMENT + " " + comment);

                    for (int row = 0; row < fuel.MaxRow; row++)
                    {
                        string fuelRow = string.Empty;
                        for (int col = 0; col < fuel.MaxColumn; col++)
                        {
                            fuelRow += WritePin(fuelDict[new FuelAssemblyComponent.PinKey(row, col)]);
                        }

                        sw.WriteLine(fuelRow.TrimEnd(DEL));
                    }
                }
            }

            private static string WritePin(FuelArrayElement fuel)
            {
                string fuelLine = string.Empty;
                if (!fuel.FuelPin)
                {
                    fuelLine += IsNotFuelPin.ToString();
                }

                fuelLine += fuel.Material + DEL.ToString();
                return fuelLine;
            }

            public static Dictionary<FuelAssemblyComponent.PinKey, FuelArrayElement> GetFuelPinDictionary(
                List<FuelArrayElement> fuel)
            {
                Dictionary<FuelAssemblyComponent.PinKey, FuelArrayElement> fuelDict =
                    new Dictionary<FuelAssemblyComponent.PinKey, FuelArrayElement>();
                foreach (FuelArrayElement f in fuel)
                {
                    fuelDict.Add(new FuelAssemblyComponent.PinKey(f.RowIndex, f.ColIndex), f);
                }

                return fuelDict;
            }

            private static bool NoComment(string line)
            {
                return !line.Contains(COMMENT);
            }
        }

        public void AddPin(FuelArrayElement fuelArrayElement)
        {
            Fuel.Add(fuelArrayElement);
        }
    }
}
