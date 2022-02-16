using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiWidgets.SampleParameters
{
    public partial class FissionParameters : UserControl
    {
        public event EventHandler UpdatedFissionEnum;

        public FissionParameters()
        {
            InitializeComponent();
            Set3DLabels();
        }

        private void Set3DLabels()
        {
            inNuBar.SetGroupBoxLabel("Moments of Nu-Bar");
            inNuBar.SetXYZtext("nu", "nu(nu-1)", "nu(nu-1)(nu-2)");
        }

        public void SetFissionEnum(IDictionary<string, int> enumDictionary)
        {
            inFissionEnum.SetEnum(enumDictionary);
        }

        public int GetSelectedFissionEnum()
        {
            return inFissionEnum.GetValue();
        }

        public double GetNuFirst()
        {
            return inNuBar.X;
        }

        public double GetNuSecond()
        {
            return inNuBar.Y;
        }

        public double GetNuThird()
        {
            return inNuBar.Z;
        }
    }
}
