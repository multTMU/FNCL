using System;
using System.Collections.Generic;
using System.Linq;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public partial class FuelAssemblyComponent
    {
        private class FuelSurfaces
        {
            private const int NUM_EDGE_POINTS = 2;

            public string BoundingSurface
            {
                get { return GetFuelBoundingSurface(BOUNDBOX_BIG); }
            }

            public CuboidExtent fuelBoundCuboid { get; private set; }

            public List<string> Surfaces { get; private set; }

            private readonly FuelArray fuel;
            private int fuelIndex;
            private int gapIndex;
            private int cladIndex;

            private MyPoint3D Center;
            private MyPoint3D fuelBase;
            private MyPoint3D axisVector;

            private int transformation;

            private List<MyPoint3D> rowCenters;
            private List<MyPoint3D> columnCenters;

            private double boxBuffer;
            private const int BOUNDBOX_BIG = 99;
            private const int BOUNDBOX_SMALL = 98;
            private FuelAssemblySpecification fuelSpec;

            private int startPinCol;
            private int startPinRow;
            private int endPinCol;
            private int endPinRow;

            public FuelSurfaces(FuelArray fuelArray) // may want to pass a transformation index
            {
                fuel = fuelArray;
                Center = GlobalDefaults.CENTER;
                transformation = GlobalDefaults.NO_TRANSFORMATION;

                boxBuffer = FuelAssembly.BOX_BUFFER;

                fuelIndex = FuelAssembly.DefaultIndices.FUEL;
                gapIndex = FuelAssembly.DefaultIndices.GAP;
                cladIndex = FuelAssembly.DefaultIndices.CLAD;
            }

            private string GetFuelBoundingSurface(int index)
            {
                return WriterHelper.GetFuelPinSurfaceLine(fuelIndex, index, index, numberFormat);
            }

            public void SetTransformation(int transIndex)
            {
                transformation = transIndex;
            }

            public void OverrideDefaultBoxBuffer(double additionalSpacing)
            {
                boxBuffer = additionalSpacing;
            }

            public void SetLeadingIndices(int fuel, int gap, int clad)
            {
                fuelIndex = fuel;
                gapIndex = gap;
                cladIndex = clad;
            }

            public void SaveAllToFile(string surfaceFile)
            {
                MCNPformatHelper.FormatThenWriteToFile(surfaceFile, Surfaces);
            }

            public void SetFuelCenter(MyPoint3D center)
            {
                Center = center;
            }

            public void MakeFuelSurfaces()
            {
                Surfaces = new List<string>();

                GetFuelSpecifications();
                SetBigBoxAroundFuel();
                SetInsideBoxAroundFuel();

                List<string> fuelPins = new List<string>();
                fuelPins.Add(MCNPformatHelper.GetCommentLine());
                fuelPins.Add(MCNPformatHelper.GetCommentLine("Fuel Pins"));

                List<string> gaps = new List<string>();
                gaps.Add(MCNPformatHelper.GetCommentLine());
                gaps.Add(MCNPformatHelper.GetCommentLine("Cladding Gap"));

                List<string> clads = new List<string>();
                clads.Add(MCNPformatHelper.GetCommentLine());
                clads.Add(MCNPformatHelper.GetCommentLine("Cladding"));

                foreach (var f in fuel.Fuel)
                {
                    if (f.ColIndex == 0)
                    {
                        fuelPins.Add(MCNPformatHelper.GetCommentLine());
                        gaps.Add(MCNPformatHelper.GetCommentLine());
                        clads.Add(MCNPformatHelper.GetCommentLine());
                    }

                    fuelPins.Add(GetFuelMacroBody(f));
                    gaps.Add(GetGapMacroBody(f));
                    clads.Add(GetCladdingMacroBody(f));
                }

                Surfaces.AddRange(fuelPins);
                Surfaces.AddRange(gaps);
                Surfaces.AddRange(clads);
            }

            private string GetCladdingMacroBody(FuelArray.FuelArrayElement pin)
            {
                double radius = pin.FuelPin ? fuelSpec.CladdingOuterRadius : fuelSpec.CoolingChannelOuterRadius;
                return GetFuelLine(pin, cladIndex, radius);
            }

            private string GetGapMacroBody(FuelArray.FuelArrayElement pin)
            {
                double radius = pin.FuelPin ? fuelSpec.CladdingInnerRadius : fuelSpec.CoolingChannelInnerRadius;
                return GetFuelLine(pin, gapIndex, radius);
            }

            private string GetFuelMacroBody(FuelArray.FuelArrayElement pin)
            {
                return GetFuelLine(pin, fuelIndex, fuelSpec.FuelPinRadius);
            }

            private string GetPinName(FuelArray.FuelArrayElement pin, int leadingIndex)
            {
                return WriterHelper.RemoveExtraSpace(
                    WriterHelper.GetFuelPinSurfaceLine(leadingIndex, pin.RowIndex, pin.ColIndex, numberFormat)
                    + " " + ((transformation == GlobalDefaults.NO_TRANSFORMATION) ? "" : transformation.ToString()));
            }

            private string GetFuelLine(FuelArray.FuelArrayElement pin, int leadingIndex, double radius)
            {
                MyPoint3D cylinderBase = rowCenters[pin.RowIndex] + columnCenters[pin.ColIndex] + fuelBase;
                return WriterHelper.RemoveExtraSpace(GetPinName(pin, leadingIndex) + " " +
                                                     McnpSurfaces.GetRightCircularCylinder(cylinderBase,
                                                         axisVector, radius));
            }

            public Tuple<string, string> GetSurfacesInsideAssemblyOutsidePins()
            {
                string surfaces = "-" + GetFuelBoundingSurface(BOUNDBOX_BIG) + " ";
                surfaces += GetFuelBoundingSurface(BOUNDBOX_SMALL) + " ";
                foreach (var f in fuel.Fuel)
                {
                    if (!InInteriorBox(f.RowIndex, f.ColIndex))
                    {
                        surfaces += GetPinName(f, cladIndex) + " ";
                    }
                }

                return new Tuple<string, string>(GetFuelBoundingSurface(BOUNDBOX_BIG), surfaces);
            }

            public Tuple<string, string> GetSurfacesInsideOfSmallBoundingBox()
            {
                string surfaces = "-" + GetFuelBoundingSurface(BOUNDBOX_SMALL) + " ";
                foreach (var f in fuel.Fuel)
                {
                    if (InInteriorBox(f.RowIndex, f.ColIndex))
                    {
                        surfaces += GetPinName(f, cladIndex) + " ";
                    }
                }

                return new Tuple<string, string>(GetFuelBoundingSurface(BOUNDBOX_SMALL), surfaces);
            }

            private bool InInteriorBox(int row, int col)
            {
                return (row >= startPinRow && row <= endPinRow && col >= startPinCol && col <= endPinCol);
            }

            private void SetBigBoxAroundFuel()
            {
                Surfaces.Add(MCNPformatHelper.GetCommentLine());
                Surfaces.Add(MCNPformatHelper.GetCommentLine("Fuel Surfaces"));
                Surfaces.Add(MCNPformatHelper.GetCommentLine());
                Surfaces.Add(MCNPformatHelper.GetCommentLine("Imaginary Box Around Fuel"));
                Surfaces.Add(MCNPformatHelper.GetCommentLine());

                MyPoint3D bufferPoint = new MyPoint3D
                {
                    X = boxBuffer + fuelSpec.CoolingChannelOuterRadius,
                    Y = boxBuffer + fuelSpec.CoolingChannelOuterRadius,
                    Z = boxBuffer
                };

                MyPoint3D minPoint = rowCenters.First() + columnCenters.First();
                minPoint.Z = fuelBase.Z;
                MyPoint3D maxPoint = rowCenters.Last() + columnCenters.Last();
                maxPoint.Z = fuelBase.Z + fuelSpec.Length;

                minPoint -= bufferPoint;
                maxPoint += bufferPoint;
                fuelBoundCuboid =
                    new CuboidExtent(minPoint, maxPoint); // used to create box around fuel to source sample from

                string boxLine = GetFuelBoundingSurface(BOUNDBOX_BIG) + " " +
                                 McnpSurfaces.GetRectangularParallelepiped(minPoint, maxPoint);
                Surfaces.Add(boxLine);
            }

            private void SetInsideBoxAroundFuel()
            {
                Surfaces.Add(MCNPformatHelper.GetCommentLine());
                Surfaces.Add(MCNPformatHelper.GetCommentLine("Interior Imaginary Box Around Fuel, due too many words"));
                Surfaces.Add(MCNPformatHelper.GetCommentLine());

                int midPinRow = fuel.MaxRow / 2;
                startPinRow = midPinRow - fuel.MaxRow / 4;
                endPinRow = midPinRow + fuel.MaxRow / 4;

                int midPinCol = fuel.MaxColumn / 2;
                startPinCol = midPinCol - fuel.MaxColumn / 4;
                endPinCol = midPinCol + fuel.MaxColumn / 4;

                MyPoint3D minPoint = rowCenters[startPinRow] + columnCenters[startPinCol];
                minPoint.Z = fuelBase.Z;
                MyPoint3D maxPoint = rowCenters[endPinRow] + columnCenters[endPinCol];
                maxPoint.Z = fuelBase.Z + fuelSpec.Length;

                MyPoint3D insideBuffer = new MyPoint3D
                {
                    X = fuelSpec.ArrayPitch / 2, Y = fuelSpec.ArrayPitch / 2, Z = boxBuffer
                };

                minPoint -= insideBuffer;
                maxPoint += insideBuffer;

                string boxLine = GetFuelBoundingSurface(BOUNDBOX_SMALL) + " " +
                                 McnpSurfaces.GetRectangularParallelepiped(minPoint, maxPoint);
                Surfaces.Add(boxLine);
            }

            private void GetFuelSpecifications()
            {
                fuelSpec = FuelAssemblyManager.GetFuelAssemblySpecification(fuel.MaxRow, fuel.MaxColumn);

                rowCenters = GetSpacing(fuel.MaxRow, true);
                columnCenters = GetSpacing(fuel.MaxColumn, false);

                fuelBase = Center;
                fuelBase.Z -= fuelSpec.Length / 2;

                axisVector = new MyPoint3D {X = 0, Y = 0, Z = fuelSpec.Length};
            }

            private List<MyPoint3D> GetSpacing(int nPins, bool isRow)
            {
                double range = (fuelSpec.ArrayPitch * (nPins - 1)) / 2;
                MyPoint3D startPoint = Center;
                MyPoint3D endPoint = Center;

                if (isRow)
                {
                    startPoint.X -= range;
                    endPoint.X += range;
                }
                else
                {
                    startPoint.Y -= range;
                    endPoint.Y += range;
                }

                LineRanger ranger = new LineRanger(startPoint, endPoint, nPins - NUM_EDGE_POINTS);
                return ranger.GetPointCollection();
            }
        }
    }
}
