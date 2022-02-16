using System;
using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets
{
    public partial class InputString : UserControl, IDetectorVariableGUI<string>, IGuiInputs<string, string>
    {
        private bool detectorVariableIsSet;
        private bool detectorVariable = false;
        public event EventHandler StringUpdated;
        private CustomValidator<string, string> validator;

        public string Label
        {
            get { return this.labelInput.Text; }
            set { this.labelInput.Text = value; }
        }

        public string Value { get; private set; }


        private bool raiseEvent;

        public InputString()
        {
            InitializeComponent();
            raiseEvent = true;
            detectorVariableIsSet = false;
        }

        private void SetReadonlyState(bool state)
        {
            this.tbString.ReadOnly = state;
        }

        public void SetReadonly()
        {
            SetReadonlyState(true);
        }

        public void SetNotReadonly()
        {
            SetReadonlyState(false);
        }

        public void SetValueRaiseNoEvent(string valueNew)
        {
            raiseEvent = false;
            SetValue(valueNew);
            raiseEvent = true;
        }

        public void SetValueRaiseEvent(string valueNew)
        {
            SetValue(valueNew);
        }

        public void SetLabel(string labelNew)
        {
            Label = labelNew;
        }

        private void tbString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SetValue(tbString.Text);
            }
        }

        private void SetValue(string newValue)
        {
            if (validator != null)
            {
                newValue = validator(newValue);
            }

            Value = newValue;
            tbString.Text = Value;
            if (raiseEvent)
            {
                RaiseValueChangedEvent();
            }
        }

        private void RaiseValueChangedEvent()
        {
            this.StringUpdated?.Invoke(this, new EventArgs());
        }

        private void tbString_Validated(object sender, EventArgs e)
        {
            SetValue(tbString.Text);
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

        private void labelInput_Click(object sender, EventArgs e)
        {
            if (detectorVariable)
            {
                detectorVariableIsSet = !detectorVariableIsSet;
                EnableVariable();
            }
        }

        private void EnableVariable()
        {
            this.tbString.Enabled = detectorVariableIsSet;
        }

        public void UseAsDetectorVariable()
        {
            detectorVariable = true;
        }

        public string GetValue()
        {
            return Value;
        }

        public void SetDetectorVariable(MPPostSpecification.DetectorVariable<string> detectorVariable)
        {
            SetValueRaiseNoEvent(detectorVariable.Value);
            SetDetectorVariableState(detectorVariable.VarIsSet);
        }

        public MPPostSpecification.DetectorVariableBase<string> GetDetectorVariable()
        {
            return new MPPostSpecification.DetectorVariableBase<string>(detectorVariableIsSet, Value);
        }

        public void SetCustomValidator(CustomValidator<string, string> customValidator)
        {
            validator = customValidator;
        }
    }
}
