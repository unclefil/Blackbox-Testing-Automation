using System;
using Application;

namespace Presentation.Model
{
    public class SettingsModel
    {
        public bool IsToRunInGoogleChrome
        {
            get
            {
                return MySetup.Default.IsToRunInGoogleChrome;
            }
            set
            {
                MySetup.Default.IsToRunInGoogleChrome = value;
            }
        }
        public bool IsToRunInFirefox
        {
            get
            {
                return MySetup.Default.IsToRunInFirefox;
            }
            set
            {
                MySetup.Default.IsToRunInFirefox = value;
            }
        }
        public bool IsToRunInInternetExplorer
        {
            get
            {
                return MySetup.Default.IsToRunInInternetExplorer;
            }
            set
            {
                MySetup.Default.IsToRunInInternetExplorer = value;
            }
        }

        public TimeSpan DefaultTimeout
        {
            get
            {
                return MySetup.Default.DefaultTimeout;
            }
            set
            {
                MySetup.Default.DefaultTimeout = value;
            }
        }
        public int DefaultTimeoutMinutes
        {
            get
            {
                return MySetup.Default.DefaultTimeout.Minutes;
            }
        }
        public int DefaultTimeoutSeconds
        {
            get
            {
                return MySetup.Default.DefaultTimeout.Seconds;
            }
        }

        public string TestDataFolder
        {
            get
            {
                return MySetup.Default.TestDataFolder;
            }
            set
            {
                MySetup.Default.TestDataFolder = value;
            }
        }
        public string ReportsFolder
        {
            get
            {
                return MySetup.Default.ReportsFolder;
            }
            set
            {
                MySetup.Default.ReportsFolder = value;
            }
        }
        public string DefectsFolder
        {
            get
            {
                return MySetup.Default.DefectsFolder;
            }
            set
            {
                MySetup.Default.DefectsFolder = value;
            }
        }
        public string DriversFolder
        {
            get
            {
                return MySetup.Default.DriversFolder;
            }
            set
            {
                MySetup.Default.DriversFolder = value;
            }
        }

        public string ChromeDriverFolder
        {
            get
            {
                return MySetup.Default.ChromeDriverFolder;
            }
            set
            {
                MySetup.Default.ChromeDriverFolder = value;
            }
        }
        public string FFDriverFolder
        {
            get
            {
                return MySetup.Default.FFDriverFolder;
            }
            set
            {
                MySetup.Default.FFDriverFolder = value;
            }
        }
        public string IEDriverFolder
        {
            get
            {
                return MySetup.Default.IEDriverFolder;
            }
            set
            {
                MySetup.Default.IEDriverFolder = value;
            }
        }

        public string TestSetxls_FileName
        {
            get
            {
                return MySetup.Default.TestSetxls_FileName;
            }
            set
            {
                MySetup.Default.TestSetxls_FileName = value;
            }
        }
        public string NameOfTestSetTab
        {
            get
            {
                return MySetup.Default.NameOfTestSetTab;
            }
            set
            {
                MySetup.Default.NameOfTestSetTab = value;
            }
        }
        public string ElementNotFoundText
        {
            get
            {
                return MySetup.Default.ElementNotFoundText;
            }
            set
            {
                MySetup.Default.ElementNotFoundText = value;
            }
        }
    
        public void SaveChanges()
        {
            MySetup.Default.Save();
        }
    }
}
