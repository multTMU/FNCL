using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets
{
    public partial class InputBoolean : UserControl, IDetectorVariableGUI<bool>, IGuiInputs<bool, bool>
    {
        public event EventHandler BoolUpdated;
        public bool Value => checkBox1.Checked;
        private bool detectorVariableIsSet;
        private bool detectorVariable = false;
        private bool raiseEvent;
        private CustomValidator<bool, bool> validator;

        public string Label
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        public InputBoolean()
        {
            InitializeComponent();
            raiseEvent = true;
        }

        private void RaiseBoolUpdated()
        {
            if (raiseEvent)
            {
                this.BoolUpdated?.Invoke(this, new EventArgs());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (detectorVariable)
            {
                detectorVariableIsSet = !detectorVariableIsSet;
                EnableVariable();
            }
        }

        private void EnableVariable()
        {
            SetReadonlyState(detectorVariableIsSet);
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

        public bool GetValue()
        {
            return Value;
        }

        public void SetDetectorVariable(MPPostSpecification.DetectorVariable<bool> detectorVariable)
        {
            SetValueRaiseNoEvent(detectorVariable.Value);
            SetDetectorVariableState(detectorVariable.VarIsSet);
        }

        public MPPostSpecification.DetectorVariableBase<bool> GetDetectorVariable()
        {
            return new MPPostSpecification.DetectorVariableBase<bool>(detectorVariableIsSet, Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RaiseBoolUpdated();
        }

        public void SetReadonly()
        {
            SetReadonlyState(false);
        }

        private void SetReadonlyState(bool state)
        {
            this.checkBox1.Enabled = state;
        }

        public void SetNotReadonly()
        {
            SetReadonlyState(true);
        }

        public void SetValueRaiseNoEvent(bool valueNew)
        {
            raiseEvent = false;
            SetValue(valueNew);
            raiseEvent = true;
        }

        private void SetValue(bool valueNew)
        {
            if (validator != null)
            {
                valueNew = validator(valueNew);
            }

            checkBox1.Checked = valueNew;
            RaiseBoolUpdated();
        }

        public void SetValueRaiseEvent(bool valueNew)
        {
            SetValue(valueNew);
        }

        public void SetLabel(string labelNew)
        {
            Label = labelNew;
        }

        public void SetCustomValidator(CustomValidator<bool, bool> customValidator)
        {
            validator = customValidator;
        }
    }
}
