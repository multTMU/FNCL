using System;
using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets
{
    public partial class InputNumber : UserControl, IDetectorVariableGUI<double>, IGuiInputs<string, double>
    {
        public event EventHandler NumberUpdated;
        public double Value { get; private set; }
        private bool raiseEvent;
        private bool detectorVariableIsSet;
        private bool detectorVariable = false;
        public bool DataIsInteger { get; set; }

        private CustomValidator<string, double> validator;

        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public InputNumber()
        {
            InitializeComponent();
            DataIsInteger = true;
            raiseEvent = true;
        }

        public void SetCustomValidator(CustomValidator<string, double> customValidator)
        {
            validator = customValidator;
        }

        public void SetReadonly()
        {
            SetReadonlyState(true);
        }

        private void SetReadonlyState(bool state)
        {
            this.tbInput.ReadOnly = state;
        }

        public void SetNotReadonly()
        {
            SetReadonlyState(false);
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CheckInput();
            }
        }

        private void tbInput_Validated(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void CheckInput()
        {
            string testText = tbInput.Text;
            if (validator != null)
            {
                SetValue(validator(testText));
            }
            else
            {
                if (DataIsInteger)
                {
                    SetValue(MultiplicityInterfaceHelper.ValidateInt(testText));
                }
                else
                {
                    SetValue(MultiplicityInterfaceHelper.ValidateDouble(testText));
                }
            }
        }

        private void SetValue(double number)
        {
            Value = number;
            tbInput.Text = MultiplicityInterfaceHelper.FormatNumber(number);
            if (raiseEvent)
            {
                RaiseNumberUpdated();
            }
        }

        private void RaiseNumberUpdated()
        {
            this.NumberUpdated?.Invoke(this, new EventArgs());
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (detectorVariable)
            {
                detectorVariableIsSet = !detectorVariableIsSet;
                EnableVariable();
            }
        }

        private void EnableVariable()
        {
            this.tbInput.Enabled = detectorVariableIsSet;
        }

        public bool IsDetectorVariableSet()
        {
            return detectorVariableIsSet;
        }

        public void SetDetectorVariableState(bool varIsSet)
        {
            detectorVariableIsSet = varIsSet;
            EnableVariable();
        }

        public void UseAsDetectorVariable()
        {
            detectorVariable = true;
        }

        public double GetValue()
        {
            return Value;
        }

        public void SetDetectorVariable(MPPostSpecification.DetectorVariable<double> detectorVariable)
        {
            SetValueRaiseNoEvent(detectorVariable.Value);
            SetDetectorVariableState(detectorVariable.VarIsSet);
        }

        public void SetDetectorVariable(MPPostSpecification.DetectorVariable<int> detectorVariable)
        {
            SetValueRaiseNoEvent(detectorVariable.Value);
            SetDetectorVariableState(detectorVariable.VarIsSet);
        }

        public MPPostSpecification.DetectorVariableBase<double> GetDetectorVariable()
        {
            return new MPPostSpecification.DetectorVariableBase<double>(detectorVariableIsSet, Value);
        }

        public void SetValueRaiseNoEvent(double valueNew)
        {
            raiseEvent = false;
            SetValue(valueNew);
            raiseEvent = true;
        }

        public void SetValueRaiseEvent(double valueNew)
        {
            SetValue(valueNew);
        }

        public void SetLabel(string labelNew)
        {
            label.Text = labelNew;
        }
    }
}
