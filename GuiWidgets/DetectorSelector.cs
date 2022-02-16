using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets
{
    public partial class DetectorSelector : UserControl
    {
        public event EventHandler DetectorChanged;

        public DetectorSelector()
        {
            InitializeComponent();
            InitializeDropDown();
        }

        private void InitializeDropDown()
        {
            cbDetector.Items.Clear();
            foreach (var d in Enum.GetValues(typeof(DetectorType)))
            {
                cbDetector.Items.Add(d);
            }

            cbDetector.SelectedItem = DetectorType.None;
        }

        public DetectorType GetSelectedDetectorType()
        {
            return (DetectorType)cbDetector.SelectedItem;
        }

        private void cbDetector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnDetectorChanged();
        }

        protected virtual void OnDetectorChanged()
        {
            DetectorChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SetDetectorType(DetectorType detectorType)
        {
            cbDetector.SelectedItem = detectorType;
            OnDetectorChanged();
        }
    }
}
