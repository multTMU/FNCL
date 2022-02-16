using System;
using System.Windows.Forms;

namespace GuiWidgets.Materials
{
    public partial class MaterialManager : UserControl
    {
        public event EventHandler NewMaterial;
        public string MaterialName { get; private set; }
        public int Index { get; private set; }
        public double Density { get; private set; }
        public string Specs { get; private set; }

        public MaterialManager()
        {
            InitializeComponent();
            inIndex.DataIsInteger = true;
        }

        public void editMaterial(string materialName, int index, double density, string specs)
        {
            inComment.SetValueRaiseNoEvent(materialName);
            inIndex.SetValueRaiseNoEvent(index);
            inDensity.SetValueRaiseNoEvent(density);
            rtSpecs.Text = specs;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            MaterialName = inComment.Value;
            Index = (int)inIndex.Value;
            Density = inDensity.Value;
            Specs = rtSpecs.Text;
            if (validMaterial())
            {
                OnNewMaterial();
            }
        }

        private bool validMaterial()
        {
            return (!string.IsNullOrWhiteSpace(MaterialName) && Index > 0 && Density != 0 &&
                    !string.IsNullOrWhiteSpace(Specs));
        }

        protected virtual void OnNewMaterial()
        {
            NewMaterial?.Invoke(this, EventArgs.Empty);
        }
    }
}
