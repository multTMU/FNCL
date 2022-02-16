using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuiWidgets.Fuel
{
    public partial class FuelPin : UserControl
    {
        private bool isFuelNotChannel;
        private bool isSelected;

        public static Size GetSize()
        {
            return new Size(60, 20);
        }

        public int Material { get; private set; }

        public int Row { get; }

        public int Column { get; }

        public bool IsFuel => isFuelNotChannel;
        public bool IsSelected => isSelected;

        public FuelPin(int row, int col, Point point, int Material, bool isFuelPin)
        {
            InitializeComponent();
            isFuelNotChannel = isFuelPin;
            isSelected = false;
            Location = point;
            this.Material = Material;
            this.Row = row;
            Column = col;
            UpdateCheck();
            UpdateMaterialLabel();
            this.toolTip1.SetToolTip(this.matLabel, this.Row.ToString() + "," + Column.ToString());
        }

        public int GetMaterial()
        {
            return Material;
        }

        public void SetMaterial(int mat)
        {
            Material = mat;
            UpdateMaterialLabel();
        }

        private void UpdateMaterialLabel()
        {
            this.matLabel.Text = Material.ToString();
        }

        public bool GetIsFuelNotChannel()
        {
            return isFuelNotChannel;
        }

        public bool GetSelectionState()
        {
            return isSelected;
        }

        public void SetSelected()
        {
            isSelected = true;
            UpdateSelected();
        }

        public void DeSelect()
        {
            isSelected = false;
            UpdateSelected();
        }

        public void Invert()
        {
            isSelected = !isSelected;
            UpdateSelected();
        }

        public void SetAsPin()
        {
            UpdateFuelCheck(false);
        }

        public void SetAsChannel()
        {
            UpdateFuelCheck(true);
        }

        private void UpdateCheck()
        {
            cbFuel.Checked = !isFuelNotChannel;
        }

        private void FuelPin_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateSelected();
        }

        private void UpdateSelected()
        {
            if (isSelected)
            {
                this.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                this.BackColor = Color.Transparent;
            }
        }

        private void matLabel_MouseClick(object sender, MouseEventArgs e)
        {
            isSelected = !isSelected;
            UpdateSelected();
        }

        private void cbFuel_CheckedChanged(object sender, EventArgs e)
        {
            isFuelNotChannel = !cbFuel.Checked;
        }

        private void UpdateFuelCheck(bool state)
        {
            cbFuel.Checked = state;
        }
    }
}
