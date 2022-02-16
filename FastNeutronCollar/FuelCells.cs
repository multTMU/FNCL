using System;
using System.Collections.Generic;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public partial class FuelAssemblyComponent
    {
        private class FuelCells
        {
            public List<string> Cells { get; private set; }
            public List<int> FuelOnlyCells { get; private set; }

            private readonly FuelArray fuel;
            private string importance;
            private int fuelIndex;
            private int gapIndex;
            private int cladIndex;
            private int gapMaterial;
            private int claddingMaterial;
            private int universe;
            private ParticleImportance particle;

            public FuelCells(FuelArray fuelArray)
            {
                fuel = fuelArray;

                fuelIndex = FuelAssembly.DefaultIndices.FUEL;
                gapIndex = FuelAssembly.DefaultIndices.GAP;
                cladIndex = FuelAssembly.DefaultIndices.CLAD;

                gapMaterial = Materials.AIR;
                claddingMaterial = Materials.CLAD;

                particle = GlobalDefaults.ParticleInProblem;
                universe = FuelAssembly.UNIVERSE;
            }

            public void OverrideParticle(ParticleImportance newParticle)
            {
                particle = newParticle;
            }

            public void OverrideUniverse(int newUniverse)
            {
                universe = newUniverse;
            }

            public void MakeFuelCells(Tuple<string, string> surfacesInsideBigBox,
                Tuple<string, string> surfacesInsideSmallBox)
            {
                Cells = new List<string>();
                FuelOnlyCells = new List<int>();

                var fuelCells = new List<string>();
                var claddingGapCells = new List<string>();
                var claddingCells = new List<string>();

                importance = UniverseAndImportanceHelper.UniverseAndImportance(particle, universe);
                fuelCells.Add(MCNPformatHelper.GetCommentLine());
                fuelCells.Add(MCNPformatHelper.GetCommentLine("Fuel Pins"));

                claddingGapCells.Add(MCNPformatHelper.GetCommentLine());
                claddingGapCells.Add(MCNPformatHelper.GetCommentLine("Cladding Gap"));

                claddingCells.Add(MCNPformatHelper.GetCommentLine());
                claddingCells.Add(MCNPformatHelper.GetCommentLine("Cladding"));

                foreach (var f in fuel.Fuel)
                {
                    if (f.ColIndex == 0)
                    {
                        fuelCells.Add(MCNPformatHelper.GetCommentLine());
                        claddingGapCells.Add(MCNPformatHelper.GetCommentLine());
                        claddingCells.Add(MCNPformatHelper.GetCommentLine());
                    }

                    fuelCells.Add(GetCellLine(f));
                    claddingGapCells.Add(GetGapLine(f, gapMaterial));
                    claddingCells.Add(GetCladLine(f, claddingMaterial));
                }

                Cells.AddRange(GetAssemblyInterior(surfacesInsideBigBox, surfacesInsideSmallBox));
                Cells.AddRange(fuelCells);
                Cells.AddRange(claddingGapCells);
                Cells.AddRange(claddingCells);
            }

            private List<string> GetAssemblyInterior(Tuple<string, string> surfacesInsideBigBox,
                Tuple<string, string> surfacesInsideSmallBox)
            {
                List<string> inside = new List<string>();
                inside.Add(MCNPformatHelper.GetCommentLine());
                inside.Add(MCNPformatHelper.GetCommentLine("Space Inside Assembly and Outside Pins"));
                inside.Add(MCNPformatHelper.GetCommentLine());

                inside.Add(WriterHelper.GetFuelAssemblyInterior(surfacesInsideBigBox, gapMaterial,
                    importance));

                inside.Add(MCNPformatHelper.GetCommentLine());
                inside.Add(MCNPformatHelper.GetCommentLine("Inside Box, to keep word count down"));
                inside.Add(MCNPformatHelper.GetCommentLine());

                inside.Add(WriterHelper.GetFuelAssemblyInterior(surfacesInsideSmallBox, gapMaterial,
                    importance));

                return inside;
            }

            public void SetMaterialIndices(int materialClad, int materialGap)
            {
                claddingMaterial = materialClad;
                gapMaterial = materialGap;
            }

            public void SetLeadingIndices(int fuel, int gap, int clad)
            {
                fuelIndex = fuel;
                gapIndex = gap;
                cladIndex = clad;
            }

            public void SaveAllToFile(string allFuelCellsFile)
            {
                MCNPformatHelper.FormatThenWriteToFile(allFuelCellsFile, Cells);
            }

            private string GetCellLine(FuelArray.FuelArrayElement pin)
            {
                if (pin.FuelPin)
                {
                    FuelOnlyCells.Add(
                        int.Parse(WriterHelper.GetPinNumber(fuelIndex, pin.RowIndex, pin.ColIndex, numberFormat)));
                }

                return WriterHelper.GetFuelPinCellLine(fuelIndex, pin.RowIndex, pin.ColIndex, pin.Material,
                    importance, numberFormat);
            }

            private string GetCladLine(FuelArray.FuelArrayElement pin, int claddingMaterial)
            {
                return WriterHelper.GetFuelCellLine(cladIndex, gapIndex, pin.RowIndex, pin.ColIndex,
                    claddingMaterial,
                    importance, numberFormat);
            }

            private string GetGapLine(FuelArray.FuelArrayElement pin, int gapMaterial)
            {
                return WriterHelper.GetFuelCellLine(gapIndex, fuelIndex, pin.RowIndex, pin.ColIndex, gapMaterial,
                    importance, numberFormat);
            }
        }
    }
}
