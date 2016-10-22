using System;
using System.IO;
using System.Windows.Forms;
using Presentation.Controller;
using Presentation.Model;
using IoCNinja;

namespace Presentation.View
{
    public partial class SettingsView : Form, ISettingsView, IImplement<ISettingsView>
    {
        #region ISettingsView Members
        SettingsController _controller;
        SettingsModel _model;

        public void SetController(SettingsController controller)
        {
            _controller = controller;
        }

        public void ShowForm(SettingsModel model)
        {
            _model = model;

            InitializeComponent();

            LoadSettingsFromModel();

            ShowDialog();
        }

        public void CloseForm()
        {
            Close();
        }

        public bool IsVisible
        {
            get
            {
                return Visible;
            }
            set
            {
                Visible = value;
            }
        }
        #endregion

        private void TryStart()
        {
            try
            {
                CheckSettings();
                SetSettingsModel();
                _controller.SaveAndStartExecution();
            }
            catch (Exception ex)
            {
                UIMessages.ShowMessage(ex.Message.ToString());
            }
        }

        #region LoadSettingsFromModel
        private void LoadSettingsFromModel()
        {
            LoadBrowsers();
            LoadTimeout();
            LoadFolders();
            LoadDriverFolders();

            txtTestSetxls_FileName.Text = _model.TestSetxls_FileName;
            txtNameOfTestSetTab.Text    = _model.NameOfTestSetTab;
            txtElementNotFoundText.Text = _model.ElementNotFoundText;
        }

        private void LoadBrowsers()
        {
            chkIsToRunInGoogleChrome.Checked     = _model.IsToRunInGoogleChrome;
            chkIsToRunInFirefox.Checked          = _model.IsToRunInFirefox;
            chkIsToRunInInternetExplorer.Checked = _model.IsToRunInInternetExplorer;
        }

        private void LoadTimeout()
        {
            txtDefaultTimeoutMinutes.Value = _model.DefaultTimeoutMinutes;
            txtDefaultTimeoutSeconds.Value = _model.DefaultTimeoutSeconds;
        }

        private void LoadFolders()
        {
            txtTestDataFolder.Text = _model.TestDataFolder;
            txtReportsFolder.Text  = _model.ReportsFolder;
            txtDefectsFolder.Text  = _model.DefectsFolder;
            txtDriversFolder.Text  = _model.DriversFolder;
        }

        private void LoadDriverFolders()
        {
            txtChromeDriverFolder.Text    = _model.ChromeDriverFolder;
            txtFirefoxDriverFolder.Text   = _model.FFDriverFolder;
            txtIExplorerDriverFolder.Text = _model.IEDriverFolder;
        }
        #endregion LoadSettingsFromModel

        #region SaveSettingsToModel
        private void SetSettingsModel()
        {
            SetBrowsers();
            SetTimeout();
            SetFolders();
            SetDriverFolders();

            _model.TestSetxls_FileName = txtTestSetxls_FileName.Text;
            _model.NameOfTestSetTab    = txtNameOfTestSetTab.Text.Trim();
            _model.ElementNotFoundText = txtElementNotFoundText.Text.Trim();
        }

        private void SetBrowsers()
        {
            _model.IsToRunInGoogleChrome     = chkIsToRunInGoogleChrome.Checked;
            _model.IsToRunInFirefox          = chkIsToRunInFirefox.Checked;
            _model.IsToRunInInternetExplorer = chkIsToRunInInternetExplorer.Checked;
        }

        private void SetTimeout()
        {
            var min = Convert.ToDouble(txtDefaultTimeoutMinutes.Value);
            var sec = Convert.ToDouble(txtDefaultTimeoutSeconds.Value);

            _model.DefaultTimeout = TimeSpan.FromSeconds(min * 60 + sec);
        }

        private void SetFolders()
        {
            _model.TestDataFolder = AddBackSlash(txtTestDataFolder);
            _model.ReportsFolder = AddBackSlash(txtReportsFolder);
            _model.DefectsFolder = AddBackSlash(txtDefectsFolder);
            _model.DriversFolder = AddBackSlash(txtDriversFolder);
        }

        private void SetDriverFolders()
        {
            _model.ChromeDriverFolder = txtChromeDriverFolder.Text;
            _model.FFDriverFolder = txtFirefoxDriverFolder.Text;
            _model.IEDriverFolder = txtIExplorerDriverFolder.Text;
        }
        #endregion SaveSettingsToModel

        #region Utils
        private string DoOpenFolder(string folderName, string actualPath)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Find your " + folderName + " folder.";

            if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return folder.SelectedPath + @"\";
            else
                return actualPath;
        }

        private string DoOpenXlsFile(string actualSafeFileName)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel XLS|*.xls*";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return file.SafeFileName; // FileName = path, SafeFileName = fileName only
            else
                return actualSafeFileName;
        }

        private string AddBackSlash(TextBox textBox)
        {
            return textBox.Text.EndsWith(@"\") ? textBox.Text : textBox.Text + @"\";
        }

        private void CheckSettings()
        {
            CheckDirectoryExists(AddBackSlash(txtTestDataFolder));
            CheckDirectoryExists(AddBackSlash(txtReportsFolder));
            CheckDirectoryExists(AddBackSlash(txtDefectsFolder));
            CheckDirectoryExists(AddBackSlash(txtDriversFolder));

            CheckDirectoryExists(AddBackSlash(txtDriversFolder) + txtChromeDriverFolder.Text);
            CheckDirectoryExists(AddBackSlash(txtDriversFolder) + txtIExplorerDriverFolder.Text);
            //CheckDirectoryExists(AddBackSlash(txtDriversFolder) + txtFirefoxDriverFolder.Text);

            CheckFileExists(AddBackSlash(txtTestDataFolder) + txtTestSetxls_FileName.Text);

            CheckTextIsEmpty(txtNameOfTestSetTab.Text);
            CheckTextIsEmpty(txtElementNotFoundText.Text);
        }

        private void CheckDirectoryExists(string path)
        {
            if (!System.IO.Directory.Exists(path))
                throw new DirectoryNotFoundException("Directory not found: " + path);
        }

        private void CheckFileExists(string fullPath)
        {
            if (!System.IO.File.Exists(fullPath))
                throw new FileNotFoundException("File not found: " + fullPath);
        }

        private void CheckTextIsEmpty(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new Exception("One or more textboxes have no information.");
        }
        #endregion Utils

        #region Events
        private void btnRun_Click(object sender, EventArgs e)
        {
            TryStart();
        }

        private void btnTestDataFolder_Click(object sender, EventArgs e)
        {
            txtTestDataFolder.Text = DoOpenFolder(btnTestDataFolder.Text, txtTestDataFolder.Text);
        }

        private void btnReportsFolder_Click(object sender, EventArgs e)
        {
            txtReportsFolder.Text = DoOpenFolder(btnReportsFolder.Text, txtReportsFolder.Text);
        }

        private void btnDefectsFolder_Click(object sender, EventArgs e)
        {
            txtDefectsFolder.Text = DoOpenFolder(btnDefectsFolder.Text, txtDefectsFolder.Text);
        }

        private void btnDriversFolder_Click(object sender, EventArgs e)
        {
            txtDriversFolder.Text = DoOpenFolder(btnDriversFolder.Text, txtDriversFolder.Text);
        }

        private void btnTestSetFileName_Click(object sender, EventArgs e)
        {
            txtTestSetxls_FileName.Text = DoOpenXlsFile(txtTestSetxls_FileName.Text);
        }
        #endregion Events
    }
}
