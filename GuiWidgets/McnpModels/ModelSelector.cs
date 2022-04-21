using System;
using System.Windows.Forms;

namespace GuiWidgets
{
    public partial class ModelSelector : UserControl
    {
        public event EventHandler ModelSelected;

        private GuiInterface.ModelTypes model;

        public ModelSelector()
        {
            InitializeComponent();
            model = GuiInterface.ModelTypes.Undefined;
        }

        public GuiInterface.ModelTypes GetModelSelected()
        {
            return model;
        }

        private void bAmLi_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.AmLi;
            ModelTypeSelected();
        }

        private void bAmLiSEL_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.AmLiSel;
            ModelTypeSelected();
        }

        private void bMP320_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.MP320;
            ModelTypeSelected();
        }

        private void bMP320SEL_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.MP320Sel;
            ModelTypeSelected();
        }

        private void bStarfire_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.Starfire;
            ModelTypeSelected();
        }

        private void bStarfireSEL_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.StarfireSel;
            ModelTypeSelected();
        }

        protected virtual void ModelTypeSelected()
        {
            EventHandler handler = this.ModelSelected;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void bNGam12Array_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.NGamArray12;
            ModelTypeSelected();
        }

        private void bNGamSnl_Click(object sender, EventArgs e)
        {
            model = GuiInterface.ModelTypes.NGamSnl;
            ModelTypeSelected();
        }
    }
}
