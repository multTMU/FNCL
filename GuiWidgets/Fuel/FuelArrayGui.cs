using System.Windows.Forms;

namespace GuiWidgets.Fuel
{
    public partial class FuelArrayGui : UserControl
    {
        private FuelHelper fuel;

        public FuelArrayGui()
        {
            InitializeComponent();
        }

        public void SetRowsAndColumns(int nRows, int nCols)
        {
            fuel = new FuelHelper(nRows, nCols);
            UpdateControls();
        }

        public int GetNumberColumns()
        {
            return fuel.GetNumberColumns();
        }

        public int GetNumberRows()
        {
            return fuel.GetNumberRows();
        }

        private void UpdateControls()
        {
            this.Cursor = Cursors.WaitCursor;

            this.Controls.Clear();
            foreach (Control c in fuel.GetControls())
            {
                this.Controls.Add(c);
            }

            this.Cursor = Cursors.Default;
        }

        public void SelectAll()
        {
            fuel.SelectAll();
        }

        public void DeSelectAll()
        {
            fuel.DeSelectAll();
        }

        public void SetAllAsFuelPins()
        {
            fuel.SetAllFuelPin();
        }

        public void SetAllAsChannels()
        {
            fuel.SetAllChannel();
        }

        public void SetFromArrayFile(string fuelArrayFile)
        {
            fuel.SetFromArray(fuelArrayFile);
            UpdateControls();
        }

        public void SaveFile(string saveFile, string comment)
        {
            fuel.SaveFile(saveFile, comment);
        }

        public void SetMaterialForSelected(int selectedMaterial)
        {
            fuel.SetMaterialForSelected(selectedMaterial);
        }

        public void InvertSelection()
        {
            fuel.InvertSelection();
        }
    }
}
