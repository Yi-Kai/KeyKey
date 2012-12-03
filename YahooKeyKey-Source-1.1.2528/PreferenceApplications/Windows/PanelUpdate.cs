/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Web;
using System.Xml;
using System.Globalization;
using System.Threading;

namespace TakaoPreference
{
    /// <remarks>
    /// The panel for checking software update
    /// </remarks>
    public partial class PanelUpdate : UserControl
    {
        private Dictionary<string, string> m_takaoDictionary;
        private Button u_applyButton;

        public PanelUpdate(Dictionary<string, string> dictionary, Button button)
        {
            InitializeComponent();
            this.m_takaoDictionary = dictionary;
            this.u_applyButton = button;
            this.InitUI();
        }

        private void InitUI()
        {
            string buffer;
            this.m_takaoDictionary.TryGetValue("ShouldCheckUpdateOnLaunch", out buffer);
            if (buffer == "true")
                this.u_chkUpdateOnLaunch.Checked = true;
            else
                this.u_chkUpdateOnLaunch.Checked = false;
        }

        private void ChangeUpdateOnLaunch(object sender, EventArgs e)
        {
            try
            {
                this.m_takaoDictionary.Remove("ShouldCheckUpdateOnLaunch");
            }
            catch { }
            if (this.u_chkUpdateOnLaunch.Checked == true)

                this.m_takaoDictionary.Add("ShouldCheckUpdateOnLaunch", "true");
            else
                this.m_takaoDictionary.Add("ShouldCheckUpdateOnLaunch", "false");

            this.u_applyButton.Enabled = true;
        }


        private void CheckNow()
        {
            string versionInfo = UpdateHelper.GetVersionInfo();
            string signature = UpdateHelper.GetVersionInfoSignature();
            string locale = CultureInfo.CurrentCulture.Name;

            IWin32Window h = new WindowWrapper(this.Parent.Handle);

            if (versionInfo.Length == 0 || signature.Length == 0)
            {
                if (locale == "zh-TW")
                    MessageBox.Show(h, "\u7121\u6cd5\u900f\u904e\u7db2\u8def\u6aa2\u67e5\u66f4\u65b0\uff0c\u8acb\u6aa2\u67e5\u7db2\u8def\u662f\u5426\u6b63\u5e38\u3002\u5982\u679c\u60a8\u6709\u5b89\u88dd\u9632\u6bd2\u8edf\u9ad4\uff0c\u4e5f\u8acb\u6aa2\u67e5\u9632\u706b\u7246\u8a2d\u5b9a\u3002", "Yahoo! \u5947\u6469\u8f38\u5165\u6cd5", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				else if (locale == "zh-CN")
					MessageBox.Show(h, "\u65e0\u6cd5\u900f\u8fc7\u7f51\u7edc\u68c0\u67e5\u66f4\u65b0\uff0c\u8bf7\u68c0\u67e5\u7f51\u7edc\u662f\u5426\u6b63\u5e38\u3002\u5982\u679c\u60a8\u88c5\u4e86\u9632\u6bd2\u8f6f\u4ef6\uff0c\u4e5f\u8bf7\u68c0\u67e5\u9632\u706b\u5899\u8bbe\u7f6e\u3002", "Yahoo! \u5947\u6469\u8f93\u5165\u6cd5", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show(h, "Unable to check for updates via the Internet. Please check your Internet connection settings or if you ever installed Anti-virus softwares, please check your firewall settings.", "Yahoo! KeyKey", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            bool valid = UpdateHelper.ValidateFile(versionInfo, signature);
            if (valid == false)
            {
                if (locale == "zh-TW")
                    MessageBox.Show(h, "\u7121\u6cd5\u900f\u904e\u7db2\u8def\u6aa2\u67e5\u66f4\u65b0\uff0c\u53ef\u80fd\u662f\u56e0\u70ba\u60a8\u5b89\u88dd\u7684\u662f\u820a\u7248\u7684 Yahoo! \u5947\u6469\u8f38\u5165\u6cd5\uff0c\u8acb\u76f4\u63a5\u5728 Yahoo! \u5947\u6469\u7db2\u7ad9\u4e0a\uff0c\u4e0b\u8f09\u65b0\u7684\u7248\u672c\u3002", "Yahoo! \u5947\u6469\u8f38\u5165\u6cd5", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				else if (locale == "zh-CN")
					MessageBox.Show(h, "\u65e0\u6cd5\u900f\u8fc7\u7f51\u8def\u68c0\u67e5\u66f4\u65b0\uff0c\u53ef\u80fd\u662f\u56e0\u4e3a\u60a8\u5b89\u88c5\u7684\u662f\u65e7\u7248\u7684 Yahoo! \u5947\u6469\u8f93\u5165\u6cd5\uff0c\u8bf7\u76f4\u63a5\u5728 Yahoo! \u5947\u6469\u7ad9\u70b9\u4e0a\uff0c\u4e0b\u8f7d\u65b0\u7684\u7248\u672c\u3002", "Yahoo! \u5947\u6469\u8f93\u5165\u6cd5", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show(h, "Unable to check for updates via the Internet. You may use an old version of Yahoo! KeyKey, please download the new installer package from the Yahoo! web site.", "Yahoo! KeyKey", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (UpdateHelper.ShouldUpdate(versionInfo) == true)
            {
                LaunchDownloadUpdateApp();
            }
            else
            {
                if (locale == "zh-TW")
                    MessageBox.Show(h, "\u60a8\u73fe\u5728\u4f7f\u7528\u7684\u5df2\u7d93\u662f\u6700\u65b0\u7248\u672c\uff0c\u4e0d\u9700\u8981\u4e0b\u8f09\u66f4\u65b0\u3002", "Yahoo! \u5947\u6469\u8f38\u5165\u6cd5", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else if (locale == "zh-CN")
                    MessageBox.Show(h, "\u60a8\u73b0\u5728\u4f7f\u7528\u7684\u5df2\u7ecf\u662f\u6700\u65b0\u7248\u672c\uff0c\u4e0d\u9700\u8981\u4e0b\u8f7d\u66f4\u65b0\u3002", "Yahoo! \u5947\u6469\u8f93\u5165\u6cd5", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(h, "You are now using the newest version. You need not to upgrade your software.", "Yahoo! KeyKey", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClickCheckNow(object sender, EventArgs e)
        {
            // @zonble
            // The network connection may be slow and it can cause the KeyKey 
			// server stop to responce, so we had better to perform the check 
			// in another thread.
            // ThreadStart threadStart = new ThreadStart(CheckNow);
            // Thread thread = new Thread(threadStart);
            // thread.Start();
			this.CheckNow();
        }

        private static void LaunchDownloadUpdateAppInThread()
        {
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "ServiceUI.exe";
            string locale = CultureInfo.CurrentCulture.Name;
            try
            {
                string sourceURL = UpdateHelper.ActionURL();
                string signatureURL = UpdateHelper.SignatureURL();
                string sourceFile = TakaoHelper.GetTempFilePathFromURL(sourceURL);
                string sigantureFile = TakaoHelper.GetTempFilePathFromURL(signatureURL);
                string changeLogURL = UpdateHelper.LocaleTaggedChangeLogURL();
                if (changeLogURL.Length == 0)
                    changeLogURL = "(null)";

                string args = "download " + sourceURL + " " + sourceFile + " " + signatureURL + " " + sigantureFile + " " + changeLogURL+ " false";
                Process serviceApp = Process.Start(filename, args);
            }
            catch (Exception)
            {             
                if (locale == "zh-TW")
                    MessageBox.Show("\u7121\u6cd5\u4e0b\u8f09\u66f4\u65b0\u6a94\u6848\uff0c\u8acb\u6aa2\u67e5\u60a8\u7684 Yahoo! \u5947\u6469\u8f38\u5165\u6cd5\u662f\u5426\u5b89\u88dd\u6b63\u78ba\u3002", "\u932f\u8aa4\uff01");
				else if (locale == "zh-CN")
                    MessageBox.Show("\u65e0\u6cd5\u4e0b\u8f7d\u66f4\u65b0\u6863\u6848\uff0c\u8bf7\u68c0\u67e5\u60a8\u7684 Yahoo! \u5947\u6469\u8f93\u5165\u6cd5\u662f\u5426\u5b89\u88c5\u6b63\u786e\u3002", "\u9519\u8bef\uff01");
                else
                    MessageBox.Show("Unable to download update! Please check your installation of Yahoo! Keykey. ", "Error!");
            }
        }

        public static void LaunchDownloadUpdateApp()
        {
            ThreadStart threadStart = new ThreadStart(LaunchDownloadUpdateAppInThread);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        private static void LaunchDownloadUpdateAppMuteInThread()
        {
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "ServiceUI.exe";
            string locale = CultureInfo.CurrentCulture.Name;
            try
            {
                string sourceURL = UpdateHelper.ActionURL();
                string signatureURL = UpdateHelper.SignatureURL();
                string sourceFile = TakaoHelper.GetTempFilePathFromURL(sourceURL);
                string sigantureFile = TakaoHelper.GetTempFilePathFromURL(signatureURL);
                string changeLogURL = UpdateHelper.LocaleTaggedChangeLogURL();
                if (changeLogURL.Length == 0)
                    changeLogURL = "(null)";

                string args = "download " + sourceURL + " " + sourceFile + " " + signatureURL + " " + sigantureFile + " " + changeLogURL+ " false";
                Process serviceApp = Process.Start(filename, args);
            }
            catch (Exception)
            { }
        }

        public static void LaunchDownloadUpdateAppMute()
        {
            ThreadStart threadStart = new ThreadStart(LaunchDownloadUpdateAppMuteInThread);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
    }

    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private IntPtr _hwnd;
    }
}
