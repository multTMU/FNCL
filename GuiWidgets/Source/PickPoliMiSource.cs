using System;
using System.Windows.Forms;

namespace GuiWidgets.Source
{
    public partial class PickPoliMiSource : UserControl
    {
        private GlobalHelpers.PoliMiSource source;

        public PickPoliMiSource()
        {
            InitializeComponent();
            cbPoliMi.DataSource = Enum.GetValues((typeof(GlobalHelpers.PoliMiSource)));
            cbPoliMi.SelectedItem = GlobalHelpers.PoliMiSource.None;
        }

        public GlobalHelpers.PoliMiSource GetSource()
        {
            return source;
        }

        public void SetSource(GlobalHelpers.PoliMiSource sourceNew)
        {
            cbPoliMi.SelectedItem = sourceNew;
        }

        private void cbPoliMi_SelectedIndexChanged(object sender, EventArgs e)
        {
            source = (GlobalHelpers.PoliMiSource)cbPoliMi.SelectedItem;
        }
    }
}
