using System.Windows.Forms;

namespace GuiFastNeutronCollar
{
    public partial class HelpSplash : Form
    {
        public HelpSplash()
        {
            InitializeComponent();
            SetText();
        }

        private void SetText()
        {
            string text = "Multiplicity Analysis and Simulation, ver. 1.0a\n";
            text += "October 7, 2021\n";
            text += "Questions? Contact:\n";
            text += "\n";
            text += "Sean E. O'Brien\n";
            text += "Oak Ridge National Laboratory\n";
            text += "One Bethel Valley Road\n";
            text += "P.O. Box 2008, MS 6166\n";
            text += "Oak Ridge, TN 37831-6166\n";
            text += "\n";
            text += "obriense@ornl.gov";
            text += "\n";
            text += "Note: This alpha-release software is intended only as a research and development tool and is provided \"as is\" with no claims of accuracy nor reliability.";
            this.richTextBox1.Text = text;
        }

    }
}
