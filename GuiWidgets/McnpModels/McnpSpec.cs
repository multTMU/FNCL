using System.Windows.Forms;
using GlobalHelpers;

namespace GuiWidgets.FnclModels
{
    public partial class McnpSpec : UserControl
    {
        public McnpSpec()
        {
            InitializeComponent();
            this.inSaveDir.SetOpenDirectories();
            this.inSaveDir.SetPrompt("Choose/Create MCNP-PoliMi Problem Directory");
            this.inSaveDir.SetInitialDirectory(GlobalHelpers.ConfigureDictionaries.GetStartingMcnpSaveDir());
            this.inNPS.SetValueRaiseNoEvent(GlobalDefaults.MCNP_PARTILCES_TO_RUN);
            this.inActivity.SetCustomValidator(GuiWidgets.CustomValidatorHelper.ConvertCuriesToBq);
        }

        public string GetMcnpFile()
        {
            return System.IO.Path.Combine(this.inSaveDir.FileFullPath, this.inProblemDirectory.Value);
        }

        public string GetMcnpDescription()
        {
            return this.inDescription.Value;
        }

        public int GetNPS()
        {
            return (int)this.inNPS.Value;
        }

        public double GetActivity()
        {
            return this.inActivity.Value;
        }
    }
}
