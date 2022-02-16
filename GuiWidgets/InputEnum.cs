using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GuiInterface;
using PoliMiRunner;

namespace GuiWidgets
{
    public partial class InputEnum : UserControl, IDetectorVariableGUI<int>, IGuiInputs<int, int>
    {
        public event EventHandler ComboxSelectionUpdated;
        private bool raiseEvent;
        private bool detectorVariableIsSet;
        private bool detectorVariable = false;
        private int Value => GetSelectedEnum();
        private CustomValidator<int, int> validator;

        public string Label
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        private IDictionary<string, int> enumDictionary;

        public InputEnum()
        {
            InitializeComponent();
            enumDictionary = new Dictionary<string, int>();
            raiseEvent = true;
        }

        public void SetEnum(IDictionary<string, int> enumDictionary)
        {
            // set using GuiInterface.WhenEnumsCantBeGenericsHelper
            this.enumDictionary = enumDictionary;
            this.comboBox1.Items.Clear();
            foreach (var e in this.enumDictionary)
            {
                comboBox1.Items.Add(e.Key);
            }
        }

        private int GetSelectedEnum()
        {
            if (enumDictionary.TryGetValue((string)comboBox1.SelectedItem, out int enumValue))
            {
                return enumValue;
            }

            return 0;
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
            this.comboBox1.Enabled = detectorVariableIsSet;
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnComboxSelectionUpdated();
        }

        protected virtual void OnComboxSelectionUpdated()
        {
            if (raiseEvent)
            {
                ComboxSelectionUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SetReadonly()
        {
            SetReadonlyState(false);
        }

        private void SetReadonlyState(bool state)
        {
            this.comboBox1.Enabled = state;
        }

        public void SetNotReadonly()
        {
            SetReadonlyState(true);
        }

        public void SetValueRaiseNoEvent(int valueNew)
        {
            raiseEvent = false;
            SetValue(valueNew);
            raiseEvent = true;
        }

        public void SetValueRaiseEvent(int valueNew)
        {
            SetValue(valueNew);
        }

        private void SetValue(int indexNew)
        {
            if (validator != null)
            {
                indexNew = validator(indexNew);
            }

            if (indexNew < comboBox1.Items.Count)
            {
                this.comboBox1.SelectedIndex = indexNew;
                OnComboxSelectionUpdated();
            }
        }

        public void SetLabel(string labelNew)
        {
            Label = labelNew;
        }

        public int GetValue()
        {
            return Value;
        }

        public void SetCustomValidator(CustomValidator<int, int> customValidator)
        {
            validator = customValidator;
        }

        public void SetDetectorVariable(MPPostSpecification.DetectorVariable<int> detectorVariable)
        {
            SetDetectorVariableState(detectorVariable.VarIsSet);
            SetValueRaiseNoEvent(detectorVariable.Value);
        }

        public MPPostSpecification.DetectorVariableBase<int> GetDetectorVariable()
        {
            return new MPPostSpecification.DetectorVariableBase<int>(detectorVariableIsSet, Value);
        }
    }
}
