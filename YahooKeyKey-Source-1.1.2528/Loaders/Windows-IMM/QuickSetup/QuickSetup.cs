// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Globalization;
using BrendanGrant.Helpers.FileAssociation;

namespace QuickSetup
{
    /// <remarks>
    /// The main window form of the QuickSetup utility.
    /// </remarks>
    public partial class QuickSetup : Form
    {
        private Dictionary<string, string> m_generalDictionary;
        private string m_generalXMLpath;
        private string m_systemFolderPath;

        /// <summary>
        /// The URL of the homepage of Yahoo! Taiwan
        /// </summary>
        public static string StartPageURL = "http://tw.yahoo.com/";

        /// <summary>
        /// The URL of the customized search engine of Yahoo! Taiwan
        /// </summary>
        public static string CustomizedSearchURL = "http://tw.rd.yahoo.com/referurl/keykey/client/s/ie/*http://tw.search.yahoo.com";

        /// <summary>
        /// The URL of the customized search engine of Yahoo! Taiwan for IE7
        /// </summary>
        public static string CustomizedSearchURLForIE7 = "http://tw.rd.yahoo.com/referurl/keykey/client/s/ie/*http://tw.search.yahoo.com/search?p={searchTerms}&ei=utf-8&fr=yfp";

        /// <summary>
        /// The URL of the help page of Yahoo! KeyKey. After the main window is closed,
		/// the tool will launch the default web browser and open the page immediately.
        /// </summary>
        public static string KeyKeyHelpURL = "http://tw.media.yahoo.com/keykey/help/";
        public static string KeyKeyExtraHelpURL = "http://tw.media.yahoo.com/keykey/help/ykey_pg_13.html";

        public static string LocalizedYahooSearchEngineName
        {
            get
            {
                string currentLocale = CultureInfo.CurrentUICulture.Name;

                if (currentLocale.Equals("zh-TW"))
                    return "Yahoo! \u5947\u6469\u641c\u5c0b";
                else if (currentLocale.Equals("zh-CN"))
                    return "Yahoo! \u5947\u6469\u641c\u5bfb";
                return "Yahoo! Taiwan";
            }
        }

        public QuickSetup(string systemFolderPath)
        {
			//Dictionary<string, string> m_generalDictionary;
			this.m_generalXMLpath = TakaoPreference.TakaoHelper.GeneralXMLpath;
			this.m_generalDictionary = TakaoPreference.TakaoHelper.DictionaryFromFile(m_generalXMLpath);

			//this.m_generalDictionary = generalDictionary;
			//this.m_generalXMLpath = generalXMLpath;
            this.m_systemFolderPath = systemFolderPath;
            InitializeComponent();
            this.u_radioSmartPhonetic.Checked = true;

            string ActivatedAroundFiltersStirng;
            m_generalDictionary.TryGetValue("ActivatedAroundFilters", out ActivatedAroundFiltersStirng);
            if (ActivatedAroundFiltersStirng == null|| ActivatedAroundFiltersStirng.Length == 0)
            {
                try
                {
                    this.m_generalDictionary.Remove("ActivatedAroundFilters");
                }
                catch { }
                this.m_generalDictionary.Add("ActivatedAroundFilters", "ARRAY:Evaluator, Search");
            }
            TakaoPreference.TakaoHelper.DictionaryToFile(m_generalDictionary, m_generalXMLpath);
			this.MergeLagacySearchSetting();
        }

		private void MergeLagacySearchSetting()
		{
			string legacySearchXMLpath = TakaoPreference.TakaoHelper.LegacySearchXMLpath;
			string oneKeySearchXMLPath = TakaoPreference.TakaoHelper.OneKeyXMLpath;
			if (File.Exists(legacySearchXMLpath))
			{
				try
				{
					File.Copy(legacySearchXMLpath, oneKeySearchXMLPath);
					File.Delete(legacySearchXMLpath);
				}
				catch { }
			}

		}

        /// <summary>
        /// Set the primary input method by clicking on the radio buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_CheckedChanged(object sender, EventArgs e)
        {
        }

        #region "Set Home" and "Set Search"

        // "Set Home" and "Set Search" are internal terminologies of Yahoo! Taiwan.
		// "Set Home" means, to set user's homepage to Yahoo! Taiwan.
		// "Set Search" means, to set user's default search engine to Yahoo! Taiwan.
		
        private void SetYahooAsHomepage()
        {
            try
            {
                RegistryKey userKey = Registry.CurrentUser;
                RegistryKey mainUserKey = userKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main", true);
                mainUserKey.SetValue("Start Page", StartPageURL);
            }
            catch { }
        }

        private void SetYahooAsDefaultSearchEngine()
        {
            try
            {
                RegistryKey userKey = Registry.CurrentUser;
                RegistryKey mainUserKey = userKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main", true);
                mainUserKey.SetValue("Search Page", CustomizedSearchURL);
            }
            catch { }

            try
            {
                RegistryKey machineKey = Registry.LocalMachine;
                RegistryKey mainMachineKey = machineKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main", true);
                mainMachineKey.SetValue("Default_Search_URL", CustomizedSearchURL);
                mainMachineKey.SetValue("Search Page", CustomizedSearchURL);
            }
            catch { }
        }

        private string YahooSearchEngineForIE7Exists
        {
            get
            {
                try
                {
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey engines = currentUserKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\SearchScopes", true);
                    string[] subKeynames = engines.GetSubKeyNames();

                    if (subKeynames.Length < 1)
                        return "";

                    foreach (string subKeyName in subKeynames)
                    {
                        RegistryKey subKey = engines.OpenSubKey(subKeyName, false);
                        try
                        {
                            string URL = (string)subKey.GetValue("URL");
                            if (URL == CustomizedSearchURLForIE7)
                            {
                                return subKeyName;
                            }
                        }
                        catch { }
                    }
                }
                catch { }
                return "";
            }
        }

        private string AddYahooSearchEngineForIE7()
        {
            string existSearchEngine = this.YahooSearchEngineForIE7Exists;
            if (existSearchEngine.Length > 0)
                return existSearchEngine;

            try
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey engines = currentUserKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\SearchScopes", true);
                string keyName = "{" + System.Guid.NewGuid().ToString() + "}";
                RegistryKey newKey = engines.CreateSubKey(keyName);
                if (newKey != null)
                {
                    newKey.SetValue("DisplayName", LocalizedYahooSearchEngineName);
                    newKey.SetValue("URL", CustomizedSearchURLForIE7);
					return keyName;
                }
            }
            catch { }

			return "";
        } 

        private void SetYahooAsDefaultSearchEngineForIE7()
		{
			try 
			{
				string subKeyName = this.AddYahooSearchEngineForIE7();
			
	            RegistryKey currentUserKey = Registry.CurrentUser;
	            RegistryKey engines = currentUserKey.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\SearchScopes", true);
				engines.SetValue("DefaultScope", subKeyName);
			}
			catch { }
		}
        /// <summary>
        /// Install more Yahoo! Softwares (if users want to)
        /// </summary>
        private void InstallMoreYahooSoftware()
        {
            string tempPath = Path.GetTempPath();
        }

        #endregion

        private void QuickSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
                        try
            {
                this.m_generalDictionary.Remove("PrimaryInputMethod");
            }
            catch { }

            if (this.u_radioSmartPhonetic.Checked == true)
                this.m_generalDictionary.Add("PrimaryInputMethod", "SmartMandarin");
            else if (this.u_radioTraditionalPhonetic.Checked == true)
                this.m_generalDictionary.Add("PrimaryInputMethod", "TraditionalMandarin");
            else if (this.u_radioCangjie.Checked == true)
                this.m_generalDictionary.Add("PrimaryInputMethod", "Generic-cj-cin");
            else if (this.u_radioSimplex.Checked == true)
                this.m_generalDictionary.Add("PrimaryInputMethod", "Generic-simplex-cin");

            TakaoPreference.TakaoHelper.DictionaryToFile(m_generalDictionary, m_generalXMLpath);

            if (this.u_checkHomepage.Checked == true)
                this.SetYahooAsHomepage();

            if (this.u_checkSearchEngine.Checked == true)
            {
                this.SetYahooAsDefaultSearchEngine();
                this.SetYahooAsDefaultSearchEngineForIE7();
            }
			else 
			{
				// Otherwise, add a search engine setting for IE7.
				this.AddYahooSearchEngineForIE7();
			}

            if (this.u_checkInstallOthers.Checked == true)
                this.InstallMoreYahooSoftware();

            this.Hide();
            LaunchServer(this.m_systemFolderPath);
            if (this.u_radioOther.Checked == true)
                ShowExtraHelp();
            else
                ShowTutorial();

        }

        private void Finish_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Launch the KeyKey Server after using the QuickSetup Wizard.
        /// </summary>
        public static void LaunchServer(string systemFolderPath)
        {
            Process[] processes = Process.GetProcessesByName("KeyKeyServer");
            if (processes.Length > 0)
                return;
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "KeyKeyServer.exe";            
            string tool = Application.StartupPath + Path.DirectorySeparatorChar + "KeyKeyTool.exe";

            string systemPath = Environment.SpecialFolder.System.ToString();
            if (systemFolderPath.Length > 0)
                systemPath = systemFolderPath;

            string ime = systemPath + Path.DirectorySeparatorChar + "KeyKey.ime";
            
            try
            {
                Process toolRun = Process.Start(tool, "install" + " " + ime);
                Process serviceApp = Process.Start(filename, "-skipversioncheck");
            }
            catch (Exception) { }
        }

        public static void ShowTutorial()
        {
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = KeyKeyHelpURL;
            try
            {
                process.Start();
            }
            catch { }
        }

        public static void ShowExtraHelp()
        {
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = KeyKeyExtraHelpURL;
            try
            {
                process.Start();
            }
            catch { }
        }

        public static void RegisterFileAssociation()
        {
            FileAssociationInfo fileInfo = new FileAssociationInfo(".cin");

            if (fileInfo.Exists)
                fileInfo.Delete();

            if (!fileInfo.Exists)
            {
				fileInfo.Create("YahooKeyKeyCin");
                fileInfo.ContentType = "text/plain";
                fileInfo.OpenWithList = new string[] {
                    "CinInstaller.exe", "notepad.exe", "winword.exe"
                };
            }

			string currentLocale = CultureInfo.CurrentUICulture.Name;

            ProgramAssociationInfo programInfo = new ProgramAssociationInfo(fileInfo.ProgID);

            if (programInfo.Exists)
                programInfo.Delete();

            if (!programInfo.Exists)
            {
	            string cinInstallerFilename = Application.StartupPath +
            		Path.DirectorySeparatorChar + "CinInstaller.exe";
                
                string command = cinInstallerFilename + " %1";                
                string description = "Yahoo! KeyKey Input Method Table";                

                if (currentLocale.Equals("zh-TW"))
                    description = "Yahoo! \u5947\u6469\u8f38\u5165\u6cd5\u8868\u683c";
                else if (currentLocale.Equals("zh-CN"))
                    description = "Yahoo! \u5947\u6469\u8f93\u5165\u6cd5\u8868\u683c";

                programInfo.Create(description, new ProgramVerb("Open", @command));
                programInfo.DefaultIcon = new ProgramIcon(cinInstallerFilename, 1);
                programInfo.AlwaysShowExtension = true;
            }

			ProgramAssociationInfo uriInfo = new ProgramAssociationInfo("ykeykey");

			if (uriInfo.Exists)
				uriInfo.Delete();

			if (!uriInfo.Exists)
			{
				string urlHandlerFilename = Application.StartupPath +
					Path.DirectorySeparatorChar + "PhraseEditor.exe";

				string command = urlHandlerFilename + " %1";
				string description = "URL:Yahoo! KeyKey User Phrase Protocol";

				if (currentLocale.Equals("zh-TW"))
					description = "URL:Yahoo! \u5947\u6469\u8f38\u5165\u6cd5\u52a0\u5b57\u52a0\u8a5e\u5354\u5b9a";
				else if (currentLocale.Equals("zh-CN"))
					description = "URL:Yahoo! \u5947\u6469\u8f93\u5165\u6cd5\u52a0\u5b57\u52a0\u8bcd\u534f\u5b9a";

				uriInfo.Create(description, new ProgramVerb("Open", @command));
				// uriInfo.DefaultIcon = new ProgramIcon(urlHandlerFilename, 1);
				uriInfo.IsURLProtocol = true;
			}
        }

    }
}