using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Multiplicity;

namespace GuiFastNeutronCollar
{
    public partial class AddPoliMi : Form
    {
        public event EventHandler UpdatedPoliMiProblems;
        public event EventHandler UpdatedPoliMiFile;
        private bool editing;

        public AddPoliMi()
        {
            InitializeComponent();
            this.poliMiFiles1.EditPoliMiSpecs += EditPoliMi;
            editing = false;
            this.poliMiSpecification1.SubmitPoliMiSpecs += SubmittedPoliMiSpecs;
            this.poliMiSpecification1.PoliMiFileSelected += PoliMiFileSelected;

            UpdateSeed(Guid.NewGuid().GetHashCode());
        }

        private void PoliMiFileSelected(object sender, EventArgs e)
        {
            OnUpdatedPoliMiFile();
        }

        public void UpdateSeed(int seed)
        {
            this.poliMiSpecification1.SetSeed(seed);
        }

        private void SubmittedPoliMiSpecs(object sender, EventArgs e)
        {
            CaptureNewPoliMiSpecs();
        }

        private void CaptureNewPoliMiSpecs()
        {
            if (editing)
            {
                this.poliMiFiles1.Edited(new PulsesHelper.PoliMiSimulations(poliMiSpecification1.GetFile(),
                    poliMiSpecification1.NPS, poliMiSpecification1.Activity));
                editing = false;
            }
            else
            {
                this.poliMiFiles1.AddNew(new PulsesHelper.PoliMiSimulations(poliMiSpecification1.GetFile(),
                    poliMiSpecification1.NPS, poliMiSpecification1.Activity));
            }
        }

        private void EditPoliMi(object sender, EventArgs e)
        {
            editing = true;
            PopulatePoliMiSpecs(this.poliMiFiles1.GetEditingProblem());
        }

        private void PopulatePoliMiSpecs(PulsesHelper.PoliMiSimulations poliMiProblem)
        {
            this.poliMiSpecification1.SetActivity(poliMiProblem.ActivityBqs);
            this.poliMiSpecification1.SetNPS(poliMiProblem.McnpNPS);
            this.poliMiSpecification1.SetFile(poliMiProblem.PulseFile);
        }

        public void SetInitialFiles(List<PulsesHelper.PoliMiSimulations> PoliMiProblems)
        {
            this.poliMiFiles1.SetInitialProblems(PoliMiProblems);
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (this.poliMiFiles1.GetProblems().Count > 0)
            {
                UpdatedProblems();
                this.Close();
            }
        }

        private void UpdatedProblems()
        {
            HandleProblemUpdate(EventArgs.Empty);
        }

        protected virtual void HandleProblemUpdate(EventArgs e)
        {
            EventHandler handler = this.UpdatedPoliMiProblems;
            handler?.Invoke(this, e);
        }

        public List<PulsesHelper.PoliMiSimulations> GetProblems()
        {
            return this.poliMiFiles1.GetProblems();
        }

        public void SetStartingFile(string initialFile)
        {
            this.poliMiSpecification1.SetFile(initialFile);
        }

        public int GetSeed()
        {
            return poliMiSpecification1.Seed;
        }

        protected virtual void OnUpdatedPoliMiFile()
        {
            UpdatedPoliMiFile?.Invoke(this, EventArgs.Empty);
        }

        public string GetCurrentFile()
        {
            return poliMiSpecification1.GetFile();
        }

        public void SetFromPoliMiSpecFile(double poliMiActivity, int poliMiMcnpNps)
        {
            poliMiSpecification1.SetActivity(poliMiActivity);
            poliMiSpecification1.SetNPS(poliMiMcnpNps);
        }
    }
}
