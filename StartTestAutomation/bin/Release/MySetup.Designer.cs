﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    public sealed partial class MySetup : global::System.Configuration.ApplicationSettingsBase {
        
        private static MySetup defaultInstance = ((MySetup)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySetup())));
        
        public static MySetup Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("IEDriverServer_x64.2.47.0")]
        public string IEDriverFolder {
            get {
                return ((string)(this["IEDriverFolder"]));
            }
            set {
                this["IEDriverFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("chromedriver_win32")]
        public string ChromeDriverFolder {
            get {
                return ((string)(this["ChromeDriverFolder"]));
            }
            set {
                this["ChromeDriverFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ff-wires-0.3.0-windows")]
        public string FFDriverFolder {
            get {
                return ((string)(this["FFDriverFolder"]));
            }
            set {
                this["FFDriverFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SampleTestSet.xls")]
        public string TestSetxls_FileName {
            get {
                return ((string)(this["TestSetxls_FileName"]));
            }
            set {
                this["TestSetxls_FileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Drivers\\")]
        public string DriversFolder {
            get {
                return ((string)(this["DriversFolder"]));
            }
            set {
                this["DriversFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\TestData\\")]
        public string TestDataFolder {
            get {
                return ((string)(this["TestDataFolder"]));
            }
            set {
                this["TestDataFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Reports\\")]
        public string ReportsFolder {
            get {
                return ((string)(this["ReportsFolder"]));
            }
            set {
                this["ReportsFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Defects\\")]
        public string DefectsFolder {
            get {
                return ((string)(this["DefectsFolder"]));
            }
            set {
                this["DefectsFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TestSet")]
        public string NameOfTestSetTab {
            get {
                return ((string)(this["NameOfTestSetTab"]));
            }
            set {
                this["NameOfTestSetTab"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("00:00:05")]
        public global::System.TimeSpan DefaultTimeout {
            get {
                return ((global::System.TimeSpan)(this["DefaultTimeout"]));
            }
            set {
                this["DefaultTimeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IsToRunInGoogleChrome {
            get {
                return ((bool)(this["IsToRunInGoogleChrome"]));
            }
            set {
                this["IsToRunInGoogleChrome"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsToRunInFirefox {
            get {
                return ((bool)(this["IsToRunInFirefox"]));
            }
            set {
                this["IsToRunInFirefox"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsToRunInInternetExplorer {
            get {
                return ((bool)(this["IsToRunInInternetExplorer"]));
            }
            set {
                this["IsToRunInInternetExplorer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Element not found")]
        public string ElementNotFoundText {
            get {
                return ((string)(this["ElementNotFoundText"]));
            }
            set {
                this["ElementNotFoundText"] = value;
            }
        }
    }
}
