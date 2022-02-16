using System;
using System.Windows.Forms;
using GlobalHelpers;
using GuiInterface;

namespace GuiFastNeutronCollar
{
    public partial class FuelArrayEditor : Form
    {
        public FuelArrayEditor()
        {
            InitializeComponent();

            this.inFuelArrayFile.FileChanged += LoadFuelFile;
            this.inRows.NumberUpdated += NumberRowsOrColsChanged;
            this.inCols.NumberUpdated += NumberRowsOrColsChanged;
            this.materialViewer1.ApplySelected += ApplySelectedMaterial;

            inCols.DataIsInteger = true;
            inRows.DataIsInteger = true;
        }

        private void ApplySelectedMaterial(object sender, EventArgs e)
        {
            int selectedKey = this.materialViewer1.GetMaterialKey();
            this.fuelArrayGui1.SetMaterialForSelected(selectedKey);
        }

        private void NumberRowsOrColsChanged(object sender, EventArgs e)
        {
            if (NumberOfRowsOrColumnsChanged())
            {
                this.fuelArrayGui1.SetRowsAndColumns((int)inRows.Value, (int)inCols.Value);
            }
        }

        private bool NumberOfRowsOrColumnsChanged()
        {
            return (this.fuelArrayGui1.GetNumberRows() != (int)inRows.Value) ||
                   (this.fuelArrayGui1.GetNumberColumns() != (int)inCols.Value);
        }

        private void LoadFuelFile(object sender, EventArgs e)
        {
            this.fuelArrayGui1.SetFromArrayFile(this.inFuelArrayFile.FileFullPath);
            //SetColsAndRows(fuelArrayGui1.GetNumberRows(), fuelArrayGui1.GetNumberColumns());
            DisplayRowsAndColumns();
        }

        private void DisplayRowsAndColumns()
        {
            this.inRows.SetValueRaiseNoEvent(this.fuelArrayGui1.GetNumberRows());
            this.inCols.SetValueRaiseNoEvent(this.fuelArrayGui1.GetNumberColumns());
        }

        public void SetColsAndRows(int nRows, int nCols)
        {
            this.fuelArrayGui1.SetRowsAndColumns(nRows, nCols);
            DisplayRowsAndColumns();
        }

        public void SetColsAndRows(int nRowsCols)
        {
            SetColsAndRows(nRowsCols, nRowsCols);
        }

        private void bSelectAll_Click(object sender, EventArgs e)
        {
            this.fuelArrayGui1.SelectAll();
        }

        private void bDeSelect_Click(object sender, EventArgs e)
        {
            this.fuelArrayGui1.DeSelectAll();
        }

        private void bSetAllFuel_Click(object sender, EventArgs e)
        {
            this.fuelArrayGui1.SetAllAsFuelPins();
        }

        private void bInChannels_Click(object sender, EventArgs e)
        {
            this.fuelArrayGui1.SetAllAsChannels();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string saveFile = MultiplicityInterfaceHelper.GetFile("Save Fuel As...", true);
            if (!string.IsNullOrWhiteSpace(saveFile))
            {
                fuelArrayGui1.SaveFile(saveFile, this.inComment.Value);
            }
        }

        private void bFuelSpecs_Click(object sender, EventArgs e)
        {
            FuelSpecsEditor specs = new FuelSpecsEditor();
            specs.SetSpecs(FuelAssemblyManager.GetFuelAssemblySpecification(this.fuelArrayGui1.GetNumberRows(),
                this.fuelArrayGui1.GetNumberColumns()));
            specs.Show();
        }

        private void bInvert_Click(object sender, EventArgs e)
        {
            this.fuelArrayGui1.InvertSelection();
        }
    }
}
