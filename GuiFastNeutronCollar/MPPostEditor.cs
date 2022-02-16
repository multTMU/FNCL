using PoliMiRunner;
using System;
using System.Windows.Forms;

namespace GuiFastNeutronCollar
{
    public partial class MPPostEditor : Form
    {
        public event EventHandler DetectorSelectedChanged;

        public int BaseDetector => this.mpPostIO1.DetectorDefault;

        public MPPostEditor()
        {
            InitializeComponent();
            this.mpPostIO1.DefaultDetectorChanged += DetectorChanged;
        }

        private void DetectorChanged(object sender, EventArgs e)
        {
            OnDetectorSelectedChanged();
        }

        protected virtual void OnDetectorSelectedChanged()
        {
            DetectorSelectedChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SetDetector(MPPostSpecification detector)
        {
            this.mpPostSpecificationPanels1.SetDetector(detector);
        }
    }
}
