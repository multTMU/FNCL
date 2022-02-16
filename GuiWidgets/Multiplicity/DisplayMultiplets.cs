using System.Windows.Forms;

namespace GuiWidgets
{
    public partial class DisplayMultiplets : UserControl
    {
        public DisplayMultiplets()
        {
            InitializeComponent();
        }

        public void SetValues(double S, double D, double T)
        {
            singlesValue.Text = S.ToString();
            doublesValue.Text = D.ToString();
            triplesValue.Text = T.ToString();
        }

        public void SetUncertainties(double S, double D, double T)
        {
            singlesUncert.Text = S.ToString();
            doublesUncert.Text = D.ToString();
            triplesUncert.Text = T.ToString();
        }
    }
}
