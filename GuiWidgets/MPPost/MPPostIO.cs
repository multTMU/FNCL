using System;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets.MPPost
{
    public partial class MPPostIO : UserControl
    {
        public event EventHandler SaveFileEvent;
        public event EventHandler LoadFileEvent;
        public event EventHandler DefaultDetectorChanged;

        public int DetectorDefault => inMPPostHardDefaults.GetValue();
        public string LoadFile => inLoadFile.GetValue();
        public string SaveFile { get; private set; }

        public MPPostIO()
        {
            InitializeComponent();
            inMPPostHardDefaults.SetEnum(EnumGuiHelpers.GetMPPostDefaultDetectors());
            inMPPostHardDefaults.ComboxSelectionUpdated += MPPostDefaultChanged;
            inLoadFile.FileChanged += LoadFileChanged;
        }

        private void MPPostDefaultChanged(object sender, EventArgs e)
        {
            OnDefaultDetectorChanged();
        }

        private void LoadFileChanged(object sender, EventArgs e)
        {
            OnLoadFileEvent();
        }

        private void bSaveAs_Click(object sender, System.EventArgs e)
        {
            SaveFile = MultiplicityInterfaceHelper.GetFile("Save Detector As...", true);
            if (!string.IsNullOrEmpty(SaveFile))
            {
                OnSaveFileEvent();
            }
        }

        protected virtual void OnSaveFileEvent()
        {
            SaveFileEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLoadFileEvent()
        {
            LoadFileEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDefaultDetectorChanged()
        {
            DefaultDetectorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
