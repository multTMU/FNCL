using System;
using System.Windows.Forms;

namespace GuiWidgets
{
    public partial class SimConfig : UserControl
    {
        public event EventHandler PoliMiExePathUpdated;
        public event EventHandler MPPostExePathUpdated;

        public SimConfig()
        {
            InitializeComponent();
            InitializeInputs();
            InitializeEvents();
        }

        private void InitializeInputs()
        {
            inPoliMiPath.SetPrompt("Choose MCNP-PoliMi Exe");
            inMPPostPath.SetPrompt("Choose MPPost Exe");
        }

        private void InitializeEvents()
        {
            inPoliMiPath.FileChanged += PoliMiExePathChanged;
            inMPPostPath.FileChanged += MPPostExePathChanged;
        }
        
        private void PoliMiExePathChanged(object sender, EventArgs e)
        {
            OnPoliMiUpdated();
        }

        private void MPPostExePathChanged(object sender, EventArgs e)
        {
            OnMPPostUpdated();
        }

        public void SetPoliMiPath(string poliMiPath)
        {
            this.inPoliMiPath.SetFullFilePath(poliMiPath);
        }

        public void SetMPPostPath(string mppostPath)
        {
            this.inMPPostPath.SetFullFilePath(mppostPath);
        }
        
        protected virtual void OnPoliMiUpdated()
        {
            PoliMiExePathUpdated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnMPPostUpdated()
        {
            MPPostExePathUpdated?.Invoke(this, EventArgs.Empty);
        }

        public string GetMPPostExe()
        {
            return inMPPostPath.FileFullPath;
        }

        public string GetPoliMiExe()
        {
            return inPoliMiPath.FileFullPath;
        }
    }
}
