using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.DieAwayTime
{
    public partial class SingleExponentFit : UserControl, IDieAwayFitGui
    {
        public SingleExponentFit()
        {
            InitializeComponent();
            inScalar.SetReadonly();
            inDieAway.SetReadonly();
        }

        public void UpdateFitParameters(List<double> fitParameters)
        {
            inScalar.SetValueRaiseNoEvent(fitParameters[0]);
            inDieAway.SetValueRaiseNoEvent(1.0 / fitParameters[1]);
        }
    }
}
