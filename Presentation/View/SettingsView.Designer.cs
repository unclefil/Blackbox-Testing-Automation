namespace Presentation.View
{
    partial class SettingsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkIsToRunInInternetExplorer = new System.Windows.Forms.CheckBox();
            this.chkIsToRunInFirefox = new System.Windows.Forms.CheckBox();
            this.chkIsToRunInGoogleChrome = new System.Windows.Forms.CheckBox();
            this.groupTimeout = new System.Windows.Forms.GroupBox();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.txtDefaultTimeoutSeconds = new System.Windows.Forms.NumericUpDown();
            this.txtDefaultTimeoutMinutes = new System.Windows.Forms.NumericUpDown();
            this.groupFolders = new System.Windows.Forms.GroupBox();
            this.txtDriversFolder = new System.Windows.Forms.TextBox();
            this.txtDefectsFolder = new System.Windows.Forms.TextBox();
            this.txtReportsFolder = new System.Windows.Forms.TextBox();
            this.txtTestDataFolder = new System.Windows.Forms.TextBox();
            this.btnDriversFolder = new System.Windows.Forms.Button();
            this.btnDefectsFolder = new System.Windows.Forms.Button();
            this.btnReportsFolder = new System.Windows.Forms.Button();
            this.btnTestDataFolder = new System.Windows.Forms.Button();
            this.groupDrivers = new System.Windows.Forms.GroupBox();
            this.txtIExplorerDriverFolder = new System.Windows.Forms.TextBox();
            this.txtFirefoxDriverFolder = new System.Windows.Forms.TextBox();
            this.txtChromeDriverFolder = new System.Windows.Forms.TextBox();
            this.labelChrome = new System.Windows.Forms.Label();
            this.labelFirefox = new System.Windows.Forms.Label();
            this.labelIExplorer = new System.Windows.Forms.Label();
            this.txtElementNotFoundText = new System.Windows.Forms.TextBox();
            this.txtTestSetxls_FileName = new System.Windows.Forms.TextBox();
            this.txtNameOfTestSetTab = new System.Windows.Forms.TextBox();
            this.btnTestSetFileName = new System.Windows.Forms.Button();
            this.labelNameOfTestSetTab = new System.Windows.Forms.Label();
            this.labelElementNotFoundText = new System.Windows.Forms.Label();
            this.groupMain.SuspendLayout();
            this.groupTimeout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultTimeoutSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultTimeoutMinutes)).BeginInit();
            this.groupFolders.SuspendLayout();
            this.groupDrivers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.btnRun);
            this.groupMain.Controls.Add(this.chkIsToRunInInternetExplorer);
            this.groupMain.Controls.Add(this.chkIsToRunInFirefox);
            this.groupMain.Controls.Add(this.chkIsToRunInGoogleChrome);
            this.groupMain.Controls.Add(this.groupTimeout);
            this.groupMain.Location = new System.Drawing.Point(12, 12);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(462, 97);
            this.groupMain.TabIndex = 21;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "Execution";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnRun.Location = new System.Drawing.Point(269, 15);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(169, 63);
            this.btnRun.TabIndex = 20;
            this.btnRun.Text = "Start";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkIsToRunInInternetExplorer
            // 
            this.chkIsToRunInInternetExplorer.AutoSize = true;
            this.chkIsToRunInInternetExplorer.Location = new System.Drawing.Point(6, 65);
            this.chkIsToRunInInternetExplorer.Name = "chkIsToRunInInternetExplorer";
            this.chkIsToRunInInternetExplorer.Size = new System.Drawing.Size(103, 17);
            this.chkIsToRunInInternetExplorer.TabIndex = 2;
            this.chkIsToRunInInternetExplorer.Text = "Internet Explorer";
            this.chkIsToRunInInternetExplorer.UseVisualStyleBackColor = true;
            // 
            // chkIsToRunInFirefox
            // 
            this.chkIsToRunInFirefox.AutoSize = true;
            this.chkIsToRunInFirefox.Location = new System.Drawing.Point(6, 42);
            this.chkIsToRunInFirefox.Name = "chkIsToRunInFirefox";
            this.chkIsToRunInFirefox.Size = new System.Drawing.Size(57, 17);
            this.chkIsToRunInFirefox.TabIndex = 1;
            this.chkIsToRunInFirefox.Text = "Firefox";
            this.chkIsToRunInFirefox.UseVisualStyleBackColor = true;
            // 
            // chkIsToRunInGoogleChrome
            // 
            this.chkIsToRunInGoogleChrome.AutoSize = true;
            this.chkIsToRunInGoogleChrome.Location = new System.Drawing.Point(6, 19);
            this.chkIsToRunInGoogleChrome.Name = "chkIsToRunInGoogleChrome";
            this.chkIsToRunInGoogleChrome.Size = new System.Drawing.Size(99, 17);
            this.chkIsToRunInGoogleChrome.TabIndex = 0;
            this.chkIsToRunInGoogleChrome.Text = "Google Chrome";
            this.chkIsToRunInGoogleChrome.UseVisualStyleBackColor = true;
            // 
            // groupTimeout
            // 
            this.groupTimeout.Controls.Add(this.labelSeconds);
            this.groupTimeout.Controls.Add(this.labelMinutes);
            this.groupTimeout.Controls.Add(this.txtDefaultTimeoutSeconds);
            this.groupTimeout.Controls.Add(this.txtDefaultTimeoutMinutes);
            this.groupTimeout.Location = new System.Drawing.Point(150, 11);
            this.groupTimeout.Name = "groupTimeout";
            this.groupTimeout.Size = new System.Drawing.Size(94, 80);
            this.groupTimeout.TabIndex = 22;
            this.groupTimeout.TabStop = false;
            this.groupTimeout.Text = "Timeout";
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(62, 52);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(26, 13);
            this.labelSeconds.TabIndex = 24;
            this.labelSeconds.Text = "Sec";
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(63, 25);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(24, 13);
            this.labelMinutes.TabIndex = 23;
            this.labelMinutes.Text = "Min";
            // 
            // txtDefaultTimeoutSeconds
            // 
            this.txtDefaultTimeoutSeconds.Location = new System.Drawing.Point(15, 45);
            this.txtDefaultTimeoutSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtDefaultTimeoutSeconds.Name = "txtDefaultTimeoutSeconds";
            this.txtDefaultTimeoutSeconds.Size = new System.Drawing.Size(41, 20);
            this.txtDefaultTimeoutSeconds.TabIndex = 4;
            // 
            // txtDefaultTimeoutMinutes
            // 
            this.txtDefaultTimeoutMinutes.Location = new System.Drawing.Point(15, 19);
            this.txtDefaultTimeoutMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtDefaultTimeoutMinutes.Name = "txtDefaultTimeoutMinutes";
            this.txtDefaultTimeoutMinutes.Size = new System.Drawing.Size(41, 20);
            this.txtDefaultTimeoutMinutes.TabIndex = 3;
            // 
            // groupFolders
            // 
            this.groupFolders.Controls.Add(this.txtDriversFolder);
            this.groupFolders.Controls.Add(this.txtDefectsFolder);
            this.groupFolders.Controls.Add(this.txtReportsFolder);
            this.groupFolders.Controls.Add(this.txtTestDataFolder);
            this.groupFolders.Controls.Add(this.btnDriversFolder);
            this.groupFolders.Controls.Add(this.btnDefectsFolder);
            this.groupFolders.Controls.Add(this.btnReportsFolder);
            this.groupFolders.Controls.Add(this.btnTestDataFolder);
            this.groupFolders.Location = new System.Drawing.Point(12, 115);
            this.groupFolders.Name = "groupFolders";
            this.groupFolders.Size = new System.Drawing.Size(462, 144);
            this.groupFolders.TabIndex = 25;
            this.groupFolders.TabStop = false;
            this.groupFolders.Text = "Folder locations";
            // 
            // txtDriversFolder
            // 
            this.txtDriversFolder.Location = new System.Drawing.Point(87, 108);
            this.txtDriversFolder.Name = "txtDriversFolder";
            this.txtDriversFolder.Size = new System.Drawing.Size(371, 20);
            this.txtDriversFolder.TabIndex = 12;
            // 
            // txtDefectsFolder
            // 
            this.txtDefectsFolder.Location = new System.Drawing.Point(87, 79);
            this.txtDefectsFolder.Name = "txtDefectsFolder";
            this.txtDefectsFolder.Size = new System.Drawing.Size(371, 20);
            this.txtDefectsFolder.TabIndex = 10;
            // 
            // txtReportsFolder
            // 
            this.txtReportsFolder.Location = new System.Drawing.Point(87, 50);
            this.txtReportsFolder.Name = "txtReportsFolder";
            this.txtReportsFolder.Size = new System.Drawing.Size(371, 20);
            this.txtReportsFolder.TabIndex = 8;
            // 
            // txtTestDataFolder
            // 
            this.txtTestDataFolder.Location = new System.Drawing.Point(87, 21);
            this.txtTestDataFolder.Name = "txtTestDataFolder";
            this.txtTestDataFolder.Size = new System.Drawing.Size(371, 20);
            this.txtTestDataFolder.TabIndex = 6;
            // 
            // btnDriversFolder
            // 
            this.btnDriversFolder.Location = new System.Drawing.Point(6, 106);
            this.btnDriversFolder.Name = "btnDriversFolder";
            this.btnDriversFolder.Size = new System.Drawing.Size(75, 23);
            this.btnDriversFolder.TabIndex = 11;
            this.btnDriversFolder.Text = "Drivers";
            this.btnDriversFolder.UseVisualStyleBackColor = true;
            this.btnDriversFolder.Click += new System.EventHandler(this.btnDriversFolder_Click);
            // 
            // btnDefectsFolder
            // 
            this.btnDefectsFolder.Location = new System.Drawing.Point(6, 77);
            this.btnDefectsFolder.Name = "btnDefectsFolder";
            this.btnDefectsFolder.Size = new System.Drawing.Size(75, 23);
            this.btnDefectsFolder.TabIndex = 9;
            this.btnDefectsFolder.Text = "Defects";
            this.btnDefectsFolder.UseVisualStyleBackColor = true;
            this.btnDefectsFolder.Click += new System.EventHandler(this.btnDefectsFolder_Click);
            // 
            // btnReportsFolder
            // 
            this.btnReportsFolder.Location = new System.Drawing.Point(6, 48);
            this.btnReportsFolder.Name = "btnReportsFolder";
            this.btnReportsFolder.Size = new System.Drawing.Size(75, 23);
            this.btnReportsFolder.TabIndex = 7;
            this.btnReportsFolder.Text = "Reports";
            this.btnReportsFolder.UseVisualStyleBackColor = true;
            this.btnReportsFolder.Click += new System.EventHandler(this.btnReportsFolder_Click);
            // 
            // btnTestDataFolder
            // 
            this.btnTestDataFolder.Location = new System.Drawing.Point(6, 19);
            this.btnTestDataFolder.Name = "btnTestDataFolder";
            this.btnTestDataFolder.Size = new System.Drawing.Size(75, 23);
            this.btnTestDataFolder.TabIndex = 5;
            this.btnTestDataFolder.Text = "TestData";
            this.btnTestDataFolder.UseVisualStyleBackColor = true;
            this.btnTestDataFolder.Click += new System.EventHandler(this.btnTestDataFolder_Click);
            // 
            // groupDrivers
            // 
            this.groupDrivers.Controls.Add(this.labelIExplorer);
            this.groupDrivers.Controls.Add(this.labelFirefox);
            this.groupDrivers.Controls.Add(this.labelChrome);
            this.groupDrivers.Controls.Add(this.txtIExplorerDriverFolder);
            this.groupDrivers.Controls.Add(this.txtChromeDriverFolder);
            this.groupDrivers.Controls.Add(this.txtFirefoxDriverFolder);
            this.groupDrivers.Location = new System.Drawing.Point(12, 265);
            this.groupDrivers.Name = "groupDrivers";
            this.groupDrivers.Size = new System.Drawing.Size(462, 115);
            this.groupDrivers.TabIndex = 26;
            this.groupDrivers.TabStop = false;
            this.groupDrivers.Text = "Selenium driver folder names";
            // 
            // txtIExplorerDriverFolder
            // 
            this.txtIExplorerDriverFolder.Location = new System.Drawing.Point(83, 80);
            this.txtIExplorerDriverFolder.Name = "txtIExplorerDriverFolder";
            this.txtIExplorerDriverFolder.Size = new System.Drawing.Size(371, 20);
            this.txtIExplorerDriverFolder.TabIndex = 15;
            // 
            // txtFirefoxDriverFolder
            // 
            this.txtFirefoxDriverFolder.Location = new System.Drawing.Point(83, 54);
            this.txtFirefoxDriverFolder.Name = "txtFirefoxDriverFolder";
            this.txtFirefoxDriverFolder.Size = new System.Drawing.Size(371, 20);
            this.txtFirefoxDriverFolder.TabIndex = 14;
            // 
            // txtChromeDriverFolder
            // 
            this.txtChromeDriverFolder.Location = new System.Drawing.Point(83, 28);
            this.txtChromeDriverFolder.Name = "txtChromeDriverFolder";
            this.txtChromeDriverFolder.Size = new System.Drawing.Size(371, 20);
            this.txtChromeDriverFolder.TabIndex = 13;
            // 
            // labelChrome
            // 
            this.labelChrome.AutoSize = true;
            this.labelChrome.Location = new System.Drawing.Point(21, 31);
            this.labelChrome.Name = "labelChrome";
            this.labelChrome.Size = new System.Drawing.Size(43, 13);
            this.labelChrome.TabIndex = 27;
            this.labelChrome.Text = "Chrome";
            // 
            // labelFirefox
            // 
            this.labelFirefox.AutoSize = true;
            this.labelFirefox.Location = new System.Drawing.Point(21, 57);
            this.labelFirefox.Name = "labelFirefox";
            this.labelFirefox.Size = new System.Drawing.Size(38, 13);
            this.labelFirefox.TabIndex = 28;
            this.labelFirefox.Text = "Firefox";
            // 
            // labelIExplorer
            // 
            this.labelIExplorer.AutoSize = true;
            this.labelIExplorer.Location = new System.Drawing.Point(21, 83);
            this.labelIExplorer.Name = "labelIExplorer";
            this.labelIExplorer.Size = new System.Drawing.Size(48, 13);
            this.labelIExplorer.TabIndex = 29;
            this.labelIExplorer.Text = "IExplorer";
            // 
            // txtElementNotFoundText
            // 
            this.txtElementNotFoundText.Location = new System.Drawing.Point(162, 438);
            this.txtElementNotFoundText.Name = "txtElementNotFoundText";
            this.txtElementNotFoundText.Size = new System.Drawing.Size(312, 20);
            this.txtElementNotFoundText.TabIndex = 19;
            // 
            // txtTestSetxls_FileName
            // 
            this.txtTestSetxls_FileName.Location = new System.Drawing.Point(162, 386);
            this.txtTestSetxls_FileName.Name = "txtTestSetxls_FileName";
            this.txtTestSetxls_FileName.Size = new System.Drawing.Size(312, 20);
            this.txtTestSetxls_FileName.TabIndex = 17;
            // 
            // txtNameOfTestSetTab
            // 
            this.txtNameOfTestSetTab.Location = new System.Drawing.Point(162, 412);
            this.txtNameOfTestSetTab.Name = "txtNameOfTestSetTab";
            this.txtNameOfTestSetTab.Size = new System.Drawing.Size(312, 20);
            this.txtNameOfTestSetTab.TabIndex = 18;
            // 
            // btnTestSetFileName
            // 
            this.btnTestSetFileName.Location = new System.Drawing.Point(12, 386);
            this.btnTestSetFileName.Name = "btnTestSetFileName";
            this.btnTestSetFileName.Size = new System.Drawing.Size(144, 23);
            this.btnTestSetFileName.TabIndex = 16;
            this.btnTestSetFileName.Text = "TestSet.xls file name";
            this.btnTestSetFileName.UseVisualStyleBackColor = true;
            this.btnTestSetFileName.Click += new System.EventHandler(this.btnTestSetFileName_Click);
            // 
            // labelNameOfTestSetTab
            // 
            this.labelNameOfTestSetTab.AutoSize = true;
            this.labelNameOfTestSetTab.Location = new System.Drawing.Point(15, 415);
            this.labelNameOfTestSetTab.Name = "labelNameOfTestSetTab";
            this.labelNameOfTestSetTab.Size = new System.Drawing.Size(124, 13);
            this.labelNameOfTestSetTab.TabIndex = 30;
            this.labelNameOfTestSetTab.Text = "TabName of TestSet tab";
            // 
            // labelElementNotFoundText
            // 
            this.labelElementNotFoundText.AutoSize = true;
            this.labelElementNotFoundText.Location = new System.Drawing.Point(15, 441);
            this.labelElementNotFoundText.Name = "labelElementNotFoundText";
            this.labelElementNotFoundText.Size = new System.Drawing.Size(131, 13);
            this.labelElementNotFoundText.TabIndex = 31;
            this.labelElementNotFoundText.Text = "Text for ElementNotFound";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 471);
            this.Controls.Add(this.labelElementNotFoundText);
            this.Controls.Add(this.labelNameOfTestSetTab);
            this.Controls.Add(this.btnTestSetFileName);
            this.Controls.Add(this.txtElementNotFoundText);
            this.Controls.Add(this.groupDrivers);
            this.Controls.Add(this.txtTestSetxls_FileName);
            this.Controls.Add(this.txtNameOfTestSetTab);
            this.Controls.Add(this.groupFolders);
            this.Controls.Add(this.groupMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Automation";
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
            this.groupTimeout.ResumeLayout(false);
            this.groupTimeout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultTimeoutSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaultTimeoutMinutes)).EndInit();
            this.groupFolders.ResumeLayout(false);
            this.groupFolders.PerformLayout();
            this.groupDrivers.ResumeLayout(false);
            this.groupDrivers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox chkIsToRunInInternetExplorer;
        private System.Windows.Forms.CheckBox chkIsToRunInFirefox;
        private System.Windows.Forms.CheckBox chkIsToRunInGoogleChrome;
        private System.Windows.Forms.GroupBox groupTimeout;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.NumericUpDown txtDefaultTimeoutSeconds;
        private System.Windows.Forms.NumericUpDown txtDefaultTimeoutMinutes;
        private System.Windows.Forms.GroupBox groupFolders;
        private System.Windows.Forms.GroupBox groupDrivers;
        private System.Windows.Forms.Button btnDriversFolder;
        private System.Windows.Forms.Button btnDefectsFolder;
        private System.Windows.Forms.Button btnReportsFolder;
        private System.Windows.Forms.Button btnTestDataFolder;
        private System.Windows.Forms.TextBox txtDriversFolder;
        private System.Windows.Forms.TextBox txtDefectsFolder;
        private System.Windows.Forms.TextBox txtReportsFolder;
        private System.Windows.Forms.TextBox txtTestDataFolder;
        private System.Windows.Forms.Label labelIExplorer;
        private System.Windows.Forms.Label labelFirefox;
        private System.Windows.Forms.Label labelChrome;
        private System.Windows.Forms.TextBox txtIExplorerDriverFolder;
        private System.Windows.Forms.TextBox txtChromeDriverFolder;
        private System.Windows.Forms.TextBox txtFirefoxDriverFolder;
        private System.Windows.Forms.TextBox txtElementNotFoundText;
        private System.Windows.Forms.TextBox txtTestSetxls_FileName;
        private System.Windows.Forms.TextBox txtNameOfTestSetTab;
        private System.Windows.Forms.Button btnTestSetFileName;
        private System.Windows.Forms.Label labelNameOfTestSetTab;
        private System.Windows.Forms.Label labelElementNotFoundText;
    }
}