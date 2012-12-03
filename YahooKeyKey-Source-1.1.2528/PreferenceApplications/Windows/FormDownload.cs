/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Win32;

namespace TakaoPreference
{
    /// <remark>
    /// The form to download Yahoo! KeyKey updates from the Internet.
    /// </remark>
    public partial class FormDownload : Form
    {
        private bool m_isFailed = false;
        private bool m_isComplete = false;
        private string m_ActionURL;
        private string m_ActionFilename;
        private string m_SignatureURL;
        private string m_SignatureFilename;
        private string m_ChangeLogURL;
        private WebClient m_webClient;
        private FormAskDownload u_askDownload;

        /// <summary>
        /// The constructor of a update download form
        /// </summary>
        /// <param name="actionURL">The URL of the requested file.</param>
        /// <param name="actionFilename">The target path of the downloaded file of the requested file.</param>
        /// <param name="signatureURL">The URL of the signature of the requested file</param>
        /// <param name="signatureFilename">The target path of the signature of the requested file.</param>
        /// <param name="showCheck">Should display "do not notify me in a week" or not.</param>
        public FormDownload(string actionURL, string actionFilename, string signatureURL, string signatureFilename, string changelogURL,bool showCheck)
        {
            InitializeComponent();
            this.Hide();
            this.m_ActionURL = actionURL;
            this.m_ActionFilename = actionFilename;
            this.m_SignatureURL = signatureURL;
            this.m_SignatureFilename = signatureFilename;
            this.m_ChangeLogURL = changelogURL;
            this.m_webClient = new WebClient();
            this.m_webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            this.m_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            u_askDownload = new FormAskDownload(this, showCheck);
            u_askDownload.ShowDialog();
        }

        public void StartProcess()
        {
            string locale = CultureInfo.CurrentCulture.Name;
            if (this.StartDownloadSignature() == false)
            {
                if (locale == "zh-TW")
                    MessageBox.Show("\u7121\u6cd5\u5f9e\u7db2\u8def\u4e0a\u4e0b\u8f09\u66f4\u65b0\u6a94\u6848\uff0c\u8acb\u6aa2\u67e5\u7db2\u8def\u8a2d\u5b9a\u662f\u5426\u6b63\u78ba\u3002", "Yahoo! \u5947\u6469\u597d\u6253", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (locale == "zh-CN")
                    MessageBox.Show("\u65e0\u6cd5\u4ece\u7f51\u7edc\u4e0a\u4e0b\u8f7d\u66f4\u65b0\u6863\u6848\uff0c\u8bf7\u68c0\u67e5\u7f51\u7edc\u8bbe\u7f6e\u662f\u5426\u6b63\u786e\u3002", "Yahoo! \u5947\u6469\u597d\u6253", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Unable to download the requested file from the Internet.", "Yahoo! KeyKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            this.StartDownload();
            this.Show();
        }

        public string ChangeLogURL
        {
            get { return m_ChangeLogURL; }
        }

        public bool StartDownloadSignature()
        {
            WebClient webclient = new WebClient();
            try
            {
                webclient.DownloadFile(this.m_SignatureURL, this.m_SignatureFilename);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void StartDownload()
        {
            string displayName = m_ActionFilename.Remove(0, m_ActionFilename.LastIndexOf(Path.DirectorySeparatorChar) + 1);
            try
            {
                this.m_webClient.DownloadFileAsync(new Uri(m_ActionURL), m_ActionFilename);
            }
            catch (Exception e)
            {
                if (e.Message == "")
                {
                    //@ zonble:
                    //What kind of exception may happen here?
                }

                this.m_isFailed = true;
                webClient_DownloadFileCompleted(null, null);
            }
            string locale = CultureInfo.CurrentCulture.Name;
            if (locale == "zh-TW")
                this.u_labelTitle.Text = "\u6b63\u5728\u4e0b\u8f09\u6a94\u6848 \"" + displayName + "\"\u2026";
            else
                this.u_labelTitle.Text = "Downloading file - \"" + displayName + "\".";
        }

        public void StartDownload(string newURL, string newFilename)
        {
            this.m_ActionURL = newURL;
            this.m_ActionFilename = newFilename;
            string displayName = m_ActionFilename.Remove(0, m_ActionFilename.LastIndexOf(Path.DirectorySeparatorChar) + 1);
            try
            {
                this.m_webClient.DownloadFileAsync(new Uri(m_ActionURL), m_ActionFilename);
            }
            catch (Exception e)
            {
                if (e.Message == "")
                { }

                this.m_isFailed = true;
                webClient_DownloadFileCompleted(null, null);
            }
            string locale = CultureInfo.CurrentCulture.Name;
            if (locale == "zh-TW")
                this.u_labelTitle.Text = "\u6b63\u5728\u4e0b\u8f09\u6a94\u6848 \"" + displayName + "\"\u2026";
            else
                this.u_labelTitle.Text = "Downloading file - \"" + displayName + "\".";
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error.Message.Length > 0)
                    this.m_isFailed = true;
            }
            catch { }
            string locale = CultureInfo.CurrentCulture.Name;

            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
            {
                if (locale == "zh-TW")
                    this.u_labelTitle.Text = "\u767c\u751f\u4e0d\u77e5\u540d\u7684\u932f\u8aa4";
                else
                    this.u_labelTitle.Text = "Unknown errors happened.";
                return;
            }

            bool valid = callback.validateFile(m_ActionFilename, m_SignatureFilename);
            if (valid == false)
            {
                if (locale == "zh-TW")
                    this.u_labelTitle.Text = "\u60a8\u4e0b\u8f09\u7684\u6a94\u6848\u5df2\u7d93\u640d\u6bc0\uff0c\u7121\u6cd5\u7e7c\u7e8c\u5b89\u88dd\u3002";
                else
                    this.u_labelTitle.Text = "The downloaded file is corruped, unable to continue installation.";
                return;
            }

            this.u_progressBar.Value = 100;
            this.u_labelDownload.Visible = false;

            if (this.m_isFailed == true)
            {
                string error;
                if (locale == "zh-TW")
                    error = "\u4e0d\u77e5\u540d\u7684\u932f\u8aa4";
				else if (locale == "zh-CN")
                    error = "\u4e0d\u8be6\u7684\u9519\u8bef";				
                else
                    error = "Unknown error.";
                try
                {
                    error = e.Error.Message;
                }
                catch
                {}

                if (locale == "zh-TW")
                    this.u_labelTitle.Text = "\u4e0b\u8f09\u5931\u6557\u3002\u539f\u56e0\u662f\uff1a " + error;
				else if (locale == "zh-CN")
					this.u_labelTitle.Text = "\u4e0b\u8f7d\u5931\u8d25\uff0c\u539f\u56e0\u662f\uff1a " + error;                    
                else
                    this.u_labelTitle.Text = "Download failed. Error: " + error;
                this.u_btnRetry.Show();
            }
            else
            {
                this.m_isComplete = true;
                if (locale == "zh-TW")
				{
                    this.u_Btn.Text = "\u7a0d\u5f8c(&L)";
                    this.u_labelTitle.Text = "\u6210\u529f\u5b8c\u6210\u4e0b\u8f09\uff0c\u8acb\u554f\u60a8\u8981\u7acb\u523b\u5b89\u88dd\u66f4\u65b0\uff0c\u9084\u662f\u7a0d\u5f8c\u5728\u91cd\u65b0\u958b\u6a5f\u4e4b\u5f8c\u5b89\u88dd\uff1f";
				}
				else if (locale == "zh-CN")
				{
                    this.u_Btn.Text = "\u7a0d\u540e(&L)";
                    this.u_labelTitle.Text = "\u6210\u529f\u5b8c\u6210\u4e0b\u8f7d\uff0c\u8bf7\u95ee\u60a8\u8981\u7acb\u523b\u5b89\u88c5\u66f4\u65b0\uff0c\u8fd8\u662f\u7a0d\u540e\u5728\u91cd\u65b0\u542f\u52a8\u540e\u5b89\u88c5\uff1f";
					
				}
                else 
				{
                    this.u_Btn.Text = "&Later";
                    this.u_labelTitle.Text = "Download complete. Do you want to install now, or installer later after reboot?";
				}
                this.u_btnInstall.Show();
            }
        }

        /// <summary>
        /// Covert Bytes to Human readable size text
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        string HumanReadableSizeFromBytes(long Bytes)
        {
            if (Bytes > 1000 * 1000)
            {
                double num = Math.Round((double)Bytes / (1000 * 1000), 2);
                return num + "MB";
            }
            else if (Bytes > 1000)
            {
                double num = Math.Round((double)Bytes / 1000);
                return num + "KB";
            }
            return Bytes + "B";
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            string locale = CultureInfo.CurrentCulture.Name;

            if (e.TotalBytesToReceive >= 0)
            {
                int percentage = e.ProgressPercentage;
                this.u_progressBar.Value = percentage;

                if (locale == "zh-TW")
                    this.u_labelDownload.Text = "\u5171" + HumanReadableSizeFromBytes(e.TotalBytesToReceive) + "\uff0c\u76ee\u524d\u4e0b\u8f09" + HumanReadableSizeFromBytes(e.BytesReceived);
                else if (locale == "zh-CN")
                    this.u_labelDownload.Text = "\u5171" + HumanReadableSizeFromBytes(e.TotalBytesToReceive) + "\uff0c\u76ee\u524d\u4e0b\u8f7d" + HumanReadableSizeFromBytes(e.BytesReceived);
                else
                    this.u_labelDownload.Text = HumanReadableSizeFromBytes(e.BytesReceived) + "/" + HumanReadableSizeFromBytes(e.TotalBytesToReceive);
            }
            else
            {
                //Because we may not be able to obtain the size of the remote
                //file, we suggest that the file size should be about 20Mb.

                long recieved = e.BytesReceived;
                long estimatedTotal = 20 * 1000 * 1000; //20MB
                this.u_progressBar.Value = (int)((float)recieved / (float)estimatedTotal * (float)100);

                if (locale == "zh-TW")
                    this.u_labelDownload.Text = "\u76ee\u524d\u4e0b\u8f09" + HumanReadableSizeFromBytes(e.BytesReceived);
                else if (locale == "zh-CN")
                    this.u_labelDownload.Text = "\u76ee\u524d\u4e0b\u8f7d" + HumanReadableSizeFromBytes(e.BytesReceived);
                else
                    this.u_labelDownload.Text = "Received " + HumanReadableSizeFromBytes(e.BytesReceived);
            }
        }

        private void SaveRunOnceRegistry()
        {
            try
            {
                RegistryKey registryKey = Registry.LocalMachine;
                registryKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce", true);
                registryKey.SetValue("UpdateKeykey", m_ActionFilename);
            }
            catch { }
        }

        /// <summary>
        /// Click on "Cancel" or "Install Later"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_Btn_Click(object sender, EventArgs e)
        {
            if (m_isComplete)
            {
                this.SaveRunOnceRegistry();
                this.Close();
                return;
            }
            this.Close();
            m_webClient.Dispose();
        }

        /// <summary>
        /// Click on "Retry"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_btnRetry_Click(object sender, EventArgs e)
        {
            this.u_progressBar.Value = 0;
            this.u_btnRetry.Hide();
            string locale = CultureInfo.CurrentCulture.Name;
            if (locale == "zh-TW")
                this.u_Btn.Text = "\u53d6\u6d88(&C)";
			else if (locale == "zh-CN")
                this.u_Btn.Text = "\u53d6\u6d88(&C)";
            else
                this.u_Btn.Text = "&Cancel";
            this.StartDownload();
        }

        /// <summary>
        /// Click on "Install"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                PreferenceConnector callback = PreferenceConnector.SharedInstance;
                if (callback != null)
                {
                    callback.closePreferencesPanel();
                }
                
                Process process = new Process();
                process.StartInfo.FileName = this.m_ActionFilename;
                process.Start();
            }
            catch
            {
                string locale = CultureInfo.CurrentCulture.Name;
                if (locale == "zh-TW")
                    MessageBox.Show("\u767c\u751f\u4e0d\u77e5\u540d\u7684\u932f\u8aa4", "Yahoo! \u5947\u6469\u597d\u6253", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (locale == "zh-CN")
					MessageBox.Show("\u53d1\u751f\u4e0d\u8be6\u7684\u9519\u8bef", "Yahoo! \u5947\u6469\u597d\u6253", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
                else
                    MessageBox.Show("Unknown errors happened", "Yahoo! KeyKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Exit();
        }
    }
}
