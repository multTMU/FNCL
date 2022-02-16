using System;
using System.IO;
using System.Windows.Forms;

namespace GuiWidgets
{
    public partial class InputFile : UserControl, IGuiInputs<string, string>
    {
        public event EventHandler FileChanged;
        private CustomValidator<string, string> validator;

        public string Label
        {
            get => this.lbFile.Text;
            set => SetLabel(value);
        }

        public string FileFullPath { get; private set; }

        public string FileName
        {
            get { return GetValue(); }
        }

        private string prompt;
        private string filter;
        private bool createFile;
        private const bool ENABLE_MULTISELECT = false;
        private bool fileNotDirectory;
        private string initialDirectory;

        private bool raiseEvent;

        public InputFile()
        {
            InitializeComponent();
            FileFullPath = string.Empty;
            createFile = false;
            UpdateToolTip();
            fileNotDirectory = true;
            raiseEvent = true;
            SetInitialDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        }

        public void SetOpenFiles()
        {
            fileNotDirectory = true;
        }

        public void SetOpenDirectories()
        {
            fileNotDirectory = false;
        }

        private void UpdateToolTip()
        {
            toolTip1.SetToolTip(this.tbFile, FileFullPath);
        }

        public void SetFullFilePath(string newFullFilePath)
        {
            FileFullPath = newFullFilePath;
            DisplayFile();
        }

        public void SetPrompt(string Prompt)
        {
            prompt = Prompt;
        }

        public void SetFileFilter(string Filter)
        {
            filter = Filter;
        }

        public void SetAllowCreateFile()
        {
            createFile = true;
        }

        public void SetNoCreateFile()
        {
            createFile = false;
        }

        private void GetFileOrDirectory()
        {
            if (fileNotDirectory)
            {
                GetFile();
            }
            else
            {
                GetDirectory();
            }
        }

        private void GetDirectory()
        {
            FolderBrowserDialog openDir = new FolderBrowserDialog();
            openDir.Description = prompt;
            openDir.SelectedPath = initialDirectory;
            string dir = string.Empty;

            if (openDir.ShowDialog() == DialogResult.OK)
            {
                dir = openDir.SelectedPath;
            }

            UpdateFile(dir);
        }

        private void GetFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = initialDirectory;
            openFile.Multiselect = ENABLE_MULTISELECT;
            openFile.Title = prompt;
            openFile.CheckFileExists = !createFile;
            openFile.Filter = filter;

            string file = string.Empty;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                file = openFile.FileName;
            }

            UpdateFile(file);
        }

        private void UpdateFile(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                FileFullPath = file;
                DisplayFile();
                HandleFileChanged();
                initialDirectory = Path.GetDirectoryName(file);
            }
        }

        private void HandleFileChanged()
        {
            if (raiseEvent)
            {
                EventHandler handler = this.FileChanged;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DisplayFile()
        {
            tbFile.Text = FileName;
            UpdateToolTip();
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            GetFileOrDirectory();
        }

        public void SetLabel(string labelNew)
        {
            this.lbFile.Text = labelNew;
        }

        public void SetInitialDirectory(string startDir)
        {
            initialDirectory = startDir;
        }

        //
        public void SetReadonly()
        {
            SetReadonlyState(true);
        }

        private void SetReadonlyState(bool state)
        {
            this.tbFile.ReadOnly = state;
        }

        public void SetNotReadonly()
        {
            SetReadonlyState(false);
        }

        public void SetValueRaiseNoEvent(string valueNew)
        {
            raiseEvent = false;
            SetValue(valueNew);
            raiseEvent = true;
        }

        private void SetValue(string valueNew)
        {
            if (validator != null)
            {
                valueNew = validator(valueNew);
            }

            FileFullPath = valueNew;
            DisplayFile();
        }

        public void SetValueRaiseEvent(string valueNew)
        {
            SetValue(valueNew);
        }

        public string GetValue()
        {
            try
            {
                if (fileNotDirectory)
                {
                    return Path.GetFileName(FileFullPath);
                }
                else
                {
                    return new DirectoryInfo(FileFullPath).Name;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SetCustomValidator(CustomValidator<string, string> customValidator)
        {
            validator = customValidator;
        }
    }
}
