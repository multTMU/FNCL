using System.Windows.Forms;
using GeometrySampling;

namespace GuiWidgets.Source
{
    public partial class Set3D : UserControl
    {
        public double X => inX.Value;
        public double Y => inY.Value;
        public double Z => inZ.Value;

        public Set3D()
        {
            InitializeComponent();
            inX.DataIsInteger = false;
            inY.DataIsInteger = false;
            inZ.DataIsInteger = false;
        }

        public void SetGroupBoxLabel(string newText)
        {
            gbPointOrAxis.Text = newText;
        }

        public void DisplayForPoint()
        {
            UpdateGroupBoxLabel(true);
        }

        public void DisplayForAxis()
        {
            UpdateGroupBoxLabel(false);
        }

        private void UpdateGroupBoxLabel(bool isPointNotAxis)
        {
            if (isPointNotAxis)
            {
                gbPointOrAxis.Text = "Set Point (cm)";
            }
            else
            {
                gbPointOrAxis.Text = "Set Axis";
            }
        }

        public void SetAll(MyPoint3D vector)
        {
            SetAll(vector.X, vector.Y, vector.Z);
        }

        public void SetAll(double xNew, double yNew, double zNew)
        {
            SetX(xNew);
            SetY(yNew);
            SetZ(zNew);
        }

        public void SetX(double val)
        {
            inX.SetValueRaiseNoEvent(val);
        }

        public void SetY(double val)
        {
            inY.SetValueRaiseNoEvent(val);
        }

        public void SetZ(double val)
        {
            inZ.SetValueRaiseNoEvent(val);
        }

        public void SetXYZtext(string xLabel, string yLabel, string zLabel)
        {
            inX.Label = xLabel;
            inY.Label = yLabel;
            inZ.Label = zLabel;
        }

        public MyPoint3D GetPoint()
        {
            return new MyPoint3D(inX.Value, inY.Value, inZ.Value);
        }

        public void SetCustomValidator(CustomValidator<string, double> customValidator)
        {
            inX.SetCustomValidator(customValidator);
            inY.SetCustomValidator(customValidator);
            inZ.SetCustomValidator(customValidator);
        }
    }
}
