using System;
using System.Windows.Forms;

namespace GuiWidgets.Materials
{
    public partial class MaterialAdder : UserControl
    {
        public MaterialAdder()
        {
            InitializeComponent();
            this.materialViewer1.ChangeApplyLabel("Save To File");
            this.materialViewer1.ChangeGroupBoxLabel("Materials To Save");
            SetUpEvents();
        }

        private void SetUpEvents()
        {
            throw new NotImplementedException();
        }
    }
}
