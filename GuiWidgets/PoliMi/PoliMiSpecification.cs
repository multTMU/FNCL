using System;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets
{
    public partial class PoliMiSpecification : UserControl
    {
        public event EventHandler SubmitPoliMiSpecs;
        public event EventHandler PoliMiFileSelected;

        public double Activity => activity;
        public int Seed => seed;
        public int NPS => nps;

        private double activity;
        private int seed;
        private int nps;

        public PoliMiSpecification()
        {
            InitializeComponent();
            SetFileBrowser();
            SetInputDataTypes();
            SetEvents();
            inActivity.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertCuriesToBq);
        }

        private void SetFileBrowser()
        {
            inFile.SetLabel("MPPost File:");
            inFile.SetFileFilter("PoliMi (*" + MultiplicityInterfaceHelper.EXT_POLIMI + "|*" +
                                 MultiplicityInterfaceHelper.EXT_POLIMI);
            inFile.SetNoCreateFile();
            inFile.SetPrompt("Choose Pulse File");
        }

        private void SetInputDataTypes()
        {
            inActivity.DataIsInteger = false;
            inNPS.DataIsInteger = true;
            inSeed.DataIsInteger = true;
        }

        private void SetEvents()
        {
            inActivity.NumberUpdated += UpdateActivity;
            inNPS.NumberUpdated += UpdateNPS;
            inSeed.NumberUpdated += UpdateSeed;
        }

        private void UpdateSeed(object sender, EventArgs e)
        {
            SetSeed((int)inSeed.Value);
        }

        private void UpdateNPS(object sender, EventArgs e)
        {
            SetNPS((int)inNPS.Value);
        }

        private void UpdateActivity(object sender, EventArgs e)
        {
            SetActivity(inActivity.Value);
        }

        public void SetDefaults(string fullFile, double newActivity, int newNps, int newSeed)
        {
            SetFile(fullFile);
            SetActivity(newActivity);
            SetNPS(newNps);
            SetSeed(newSeed);
        }

        public void SetFile(string fullFile)
        {
            inFile.SetFullFilePath(fullFile);
            OnPoliMiFileSelected();
        }

        public void SetActivity(double newActivity)
        {
            activity = newActivity;
            inActivity.SetValueRaiseNoEvent(activity);
        }

        public void SetNPS(int newNPS)
        {
            nps = newNPS;
            inNPS.SetValueRaiseNoEvent(nps);
        }

        public void SetSeed(int newSeed)
        {
            seed = newSeed;
            inSeed.SetValueRaiseNoEvent(seed);
        }

        public string GetFile()
        {
            return inFile.FileFullPath;
        }

        private void bAddPoliMi_Click(object sender, EventArgs e)
        {
            OnSubmitPoliMiSpecs(EventArgs.Empty);
        }

        protected virtual void OnSubmitPoliMiSpecs(EventArgs e)
        {
            EventHandler handler = this.SubmitPoliMiSpecs;
            handler?.Invoke(this, e);
        }

        protected virtual void OnPoliMiFileSelected()
        {
            PoliMiFileSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
