// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Globalization;

namespace BaseIMEUI
{
    public partial class BIAboutPanel : UserControl
    {
        public static System.Drawing.Bitmap c_icon = null;
        private Form u_window;
        private bool m_init;

        public BIAboutPanel(Form window)
        {
            InitializeComponent();
            Bitmap logo = new Bitmap(c_icon);
            logo.MakeTransparent(logo.GetPixel(1, 1));
            this.u_pictureLogo.Image = (Image)logo;
            this.u_window = window;
			// We are now using a ruby script to change the text
			// value which will be displayed on the about window
			// automatically.
            this.u_version.Text = "Yahoo! KeyKey 1.1 (build 2528)";
            this.UpdateVersionInfo();
            this.UpdateWordCount();
        }

        public void UpdateVersionInfo()
        {
            this.m_init = true;
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                if (callback.isRunningUnderWow64())
                    this.u_version.Text += ", 64-bit";
                this.u_databaseVersion.Text = "Database version " + callback.databaseVersion();
            }
			else 
			{
				this.u_databaseVersion.Text = "";
			}
            this.m_init = false;
        }

        public void UpdateWordCount()
        {
            this.m_init = true;
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                string wordCountModuleName = "YKAFWordCount";
                if (callback.moduleWithWildcardNameExists(wordCountModuleName) == false)
                {
                    this.u_wordCountGroup.Enabled = false;
                    this.u_wordCountTodayCountLabel.Text = "0";
                    this.u_wordCountThisWeekCountLabel.Text = "0";
                    this.u_wordCountTotalCountLabel.Text = "0";
                    this.u_wordCountMessageLabel.Visible = true;
                }
                else
                {
                    this.u_wordCountGroup.Enabled = true;
                    this.u_wordCountMessageLabel.Visible = false;

                    if (callback.isAroundFilterEnabled(wordCountModuleName))
                    {
                        this.u_wordCountEnableCheckBox.Checked = true;
                        this.SetWordCountLabelsEnabled(true);
                    }
                    else
                    {
                        this.u_wordCountEnableCheckBox.Checked = false;
                        this.SetWordCountLabelsEnabled(false);
                    }

                    string todayCount = callback.stringValueForConfigKeyOfModule("TodayCount", wordCountModuleName);
                    if (todayCount.Length == 0)
                        todayCount = "0";
                    string weeklyCount = callback.stringValueForConfigKeyOfModule("WeeklyCount", wordCountModuleName);
                    if (weeklyCount.Length == 0)
                        weeklyCount = "0";
                    string totalCount = callback.stringValueForConfigKeyOfModule("TotalCount", wordCountModuleName);
                    if (totalCount.Length == 0)
                        totalCount = "0";
                    this.u_wordCountTodayCountLabel.Text = todayCount;
                    this.u_wordCountThisWeekCountLabel.Text = weeklyCount;
                    this.u_wordCountTotalCountLabel.Text = totalCount;
                }
            }
			else
			{
	            this.u_wordCountGroup.Enabled = false;
                this.u_wordCountTodayCountLabel.Text = "0";
                this.u_wordCountThisWeekCountLabel.Text = "0";
                this.u_wordCountTotalCountLabel.Text = "0";
                this.u_wordCountMessageLabel.Visible = true;
			}
            this.m_init = false;
        }

        private void SetWordCountLabelsEnabled(bool enabled)
        {
            this.u_wordCountTodayLabel.Enabled = enabled;
            this.u_wordCountTodayCountLabel.Enabled = enabled;
            this.u_wordCountThisWeekLabel.Enabled = enabled;
            this.u_wordCountThisWeekCountLabel.Enabled = enabled;
            this.u_wordCountTotalLabel.Enabled = enabled;
            this.u_wordCountTotalCountLabel.Enabled = enabled;
        }

        private void LaunchProcessInThread(object data)
        {
			string filename = (string)data;
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = filename;
            try
            {
                process.Start();
            }
            catch { }
            Thread.Sleep(1000);
            this.u_window.Close();
        }

        private void LaunchProcess(string filename)
        {
			// Although the name of the parameter is "filename", however,
			// it could be a string of URL and we can launch the default
			// Web browser to open the URL.
            // this.m_filename = filename;
            try
            {
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(LaunchProcessInThread);
                Thread thread = new Thread(threadStart);
                thread.Start(filename);
            }
            catch { }
        }

        private void u_linkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LaunchProcess("http://tw.media.yahoo.com/keykey/");
        }

        private void u_linkPrivacy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LaunchProcess("http://info.yahoo.com/privacy/tw/yahoo/");
        }

        private void u_linkAgreement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.LaunchProcess("http://tw.info.yahoo.com/legal/utos.html");
        }

        private void LaunchCustomCareInthread()
        {
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "ServiceUI.exe";
            bool rtn = false;
            try
            {
                ProcessStartInfo serviceStart = new ProcessStartInfo(filename, "customercare " + m_userInfoFile + " " + m_primaryInputMethod);
                Process serviceApp = new Process();
                serviceApp.StartInfo = serviceStart;
                rtn = serviceApp.Start();
            }
            catch { }
            if (rtn)
            {
                Thread.Sleep(1000);
                this.u_window.Close();
            }
        }

        private string m_userInfoFile = "";
        private string m_primaryInputMethod = "";

        private void WriteStringToFile(string myString, string myFilePath)
        {
            try
            {
                TextWriter textWriter = new StreamWriter(myFilePath);
                textWriter.Write(myString);
                textWriter.Close();
                textWriter.Dispose();
            }
            catch { }
        }

        private void LaunchCustomCare()
        {
            /*
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
            {
                MessageBox.Show("Error!");
                return;
            }
            this.m_userInfoText = callback.userInfoForPOST();
            this.m_userInfoFile = callback.temporaryFilename("ykkuserinfo.txt");
            this.m_primaryInputMethod = callback.primaryInputMethod();
            this.WriteStringToFile(m_userInfoText, m_userInfoFile);

            try
            {
                ThreadStart threadStart = new ThreadStart(LaunchCustomCareInthread);
                Thread thread = new Thread(threadStart);
                thread.Start();
            }
            catch { }
             */
        }

        private void u_feedback_Click(object sender, EventArgs e)
        {
            // this.LaunchCustomCare();
            
            // WARNING: THIS PART IS MESSED UP--REQUIRES CLIENT-SIDE ACTION
            this.LaunchProcess("http://tw.help.cc.yahoo.com/feedback.html?id=3430");
        }

        private void u_wordCountEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            this.m_init = true;
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                string wordCountModuleName = "YKAFWordCount";
                callback.toggleAroundFilter(wordCountModuleName);
                if (callback.isAroundFilterEnabled(wordCountModuleName))
                {
                    this.u_wordCountEnableCheckBox.Checked = true;
                    this.SetWordCountLabelsEnabled(true);
                }
                else
                {
                    this.u_wordCountEnableCheckBox.Checked = false;
                    this.SetWordCountLabelsEnabled(false);
                }
            }
            this.m_init = false;
        }

        private void ClearWordCount(object sender, EventArgs e)
        {

            string message = "Do you really want to clear word count?";
            string locale = CultureInfo.CurrentUICulture.Name;
            if (locale.Equals("zh-TW"))
                message = "\u60a8\u78ba\u5b9a\u8981\u6e05\u9664\u5b57\u6578\u7d71\u8a08\u55ce\uff1f";
            else if (locale.Equals("zh-CN"))
                message = "\u60a8\u786e\u5b9a\u8981\u6e05\u9664\u5b57\u6570\u7edf\u8ba1\u5417\uff1f";

            DialogResult result = MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No))
                return;

            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                string wordCountModuleName = "YKAFWordCount";
                callback.deleteAllKeysAndValuesInModuleConfig(wordCountModuleName);
                this.UpdateWordCount();
            }
        }
    }
}
