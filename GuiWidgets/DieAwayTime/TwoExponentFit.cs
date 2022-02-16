using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.DieAwayTime
{
    public partial class TwoExponentFit : UserControl, IDieAwayFitGui
    {
        public TwoExponentFit()
        {
            InitializeComponent();
            inScalar.SetReadonly();
            inDieAwayOne.SetReadonly();
            inDieAwayTwo.SetReadonly();
        }

        public void UpdateFitParameters(List<double> fitParameters)
        {
            inScalar.SetValueRaiseNoEvent(fitParameters[0]);
            inDieAwayOne.SetValueRaiseNoEvent(1.0 / fitParameters[1]);
            inDieAwayTwo.SetValueRaiseNoEvent(1.0 / fitParameters[2]);
        }
    }
}
