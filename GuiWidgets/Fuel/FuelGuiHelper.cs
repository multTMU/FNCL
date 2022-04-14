using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FastNeutronCollar;
using GlobalHelpers;
using static FastNeutronCollar.FuelArray;

namespace GuiWidgets.Fuel
{
    //public struct PinKey
    //{
    //    public int Row;
    //    public int Col;

    //    public PinKey(int row, int col)
    //    {
    //        Row = row;
    //        Col = col;
    //    }
    //}

    public class FuelHelper
    {
        private int nRows;
        private int nColumns;
        private Size pinSize;
        private Dictionary<FuelAssemblyComponent.PinKey, FuelPin> fuelPins;
        private const bool DEFAULT_FUELPIN = true;

        public FuelHelper(int numberRows, int numberCols)
        {
            nRows = numberRows;
            nColumns = numberCols;
            pinSize = FuelPin.GetSize();
            MakePins();
        }

        public void SetFromArray(string fuelArrayFile)
        {
            SetFromArray(new FuelArray(fuelArrayFile));
        }

        public void SetFromArray(FuelArray fuelArray)
        {
            fuelPins = new Dictionary<FuelAssemblyComponent.PinKey, FuelPin>();
            nColumns = fuelArray.MaxColumn;
            nRows = fuelArray.MaxRow;
            foreach (var p in fuelArray.Fuel)
            {
                fuelPins.Add(new FuelAssemblyComponent.PinKey(p.RowIndex, p.ColIndex),
                    new FuelPin(p.RowIndex, p.ColIndex, GetLocation(p.RowIndex, p.ColIndex), p.Material, p.FuelPin));
            }
        }

        private void MakePins()
        {
            fuelPins = new Dictionary<FuelAssemblyComponent.PinKey, FuelPin>();

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    fuelPins.Add(new FuelAssemblyComponent.PinKey(i, j),
                        new FuelPin(i, j, GetLocation(i, j), MaterialManager.VOID, DEFAULT_FUELPIN));
                }
            }
        }

        public List<Control> GetControls()
        {
            List<Control> controls = new List<Control>();
            foreach (var p in fuelPins.Values)
            {
                controls.Add(p as Control);
            }

            return controls;
        }

        private Point GetLocation(int row, int col)
        {
            return new Point(row * pinSize.Width, col * pinSize.Height);
        }

        public void SelectAll()
        {
            foreach (var p in fuelPins.Values)
            {
                p.SetSelected();
            }
        }

        public void DeSelectAll()
        {
            foreach (var p in fuelPins.Values)
            {
                p.DeSelect();
            }
        }

        public void InvertSelection()
        {
            foreach (var p in fuelPins.Values)
            {
                p.Invert();
            }
        }

        public void SetAllFuelPin()
        {
            foreach (var p in fuelPins.Values)
            {
                p.SetAsPin();
            }
        }

        public void SetAllChannel()
        {
            foreach (var p in fuelPins.Values)
            {
                p.SetAsChannel();
            }
        }

        public int GetNumberRows()
        {
            return nRows;
        }

        public int GetNumberColumns()
        {
            return nColumns;
        }

        public void SaveFile(string saveFile, string comment)
        {
            FuelArray fuelArray = new FuelArray();
            foreach (var f in fuelPins)
            {
                fuelArray.AddPin(new FuelArrayElement
                {
                    Material = f.Value.Material,
                    RowIndex = f.Value.Row,
                    ColIndex = f.Value.Column,
                    FuelPin = f.Value.IsFuel
                });
            }

            FuelMaterialHelpers.WriteFuelArrayFile(saveFile, fuelArray, comment);
        }

        public void SetMaterialForSelected(int selectedMaterial)
        {
            foreach (var p in fuelPins)
            {
                if (p.Value.IsSelected)
                {
                    p.Value.SetMaterial(selectedMaterial);
                }
            }
        }
    }
}
