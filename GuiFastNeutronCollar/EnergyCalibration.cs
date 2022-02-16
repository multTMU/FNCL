using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiFastNeutronCollar
{
    public partial class EnergyCalibration : Form
    {
        public EnergyCalibration()
        {
            InitializeComponent();
        }

        internal void InitializeECal(int panelOne, int panelTwo, int panelThree)
        {
            this.fnclEnergyCal1.InitializePanelOne(panelOne);
            this.fnclEnergyCal1.InitializePanelTwo(panelTwo);
            this.fnclEnergyCal1.InitializePanelThree(panelThree);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string saveFile = GetFile("Save E-Cal As...", true);
            if (!string.IsNullOrEmpty(saveFile))
            {
                DetectorEnergyCalibration.SaveEnergyCalibration(saveFile);
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            string loadFile = GetFile("Load E-Cal...", false);
            if (!string.IsNullOrEmpty(loadFile))
            {
                DetectorEnergyCalibration.LoadEnergyCalibration(loadFile);
            }
        }

        private string GetFile(string prompt, bool create = false, string filter = "")
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Title = prompt;
            openFile.CheckFileExists = !create;
            if (!string.IsNullOrEmpty(filter))
            {
                openFile.Filter = filter;
            }

            string file = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                file = openFile.FileName;
            }

            return file;
        }
    }
}
