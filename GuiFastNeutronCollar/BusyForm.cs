using System.Windows.Forms;

namespace GuiFastNeutronCollar
{
    public partial class BusyForm : Form
    {
        private const string DEFAULT_TEXT = "Busy...Please Wait...";

        public BusyForm()
        {
            InitializeComponent();
            this.label1.Text = DEFAULT_TEXT;
        }

        public void SetText(string busyText)
        {
            this.label1.Text = busyText;
        }
    }
}
