/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Globalization;

namespace TakaoPreference
{
    public partial class FormAskDownload : Form
    {
        private FormDownload m_formDownload;
		// If the "Download Now" button is pressed.
        private bool m_downloadNow;

        public FormAskDownload(FormDownload formDownload, bool showCheck)
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormAskDownload_FormClosed);
            this.u_chk.Visible = showCheck;
            this.m_formDownload = formDownload;
            if (formDownload.ChangeLogURL == "(null)")
            {
                string html = "<html><head><meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\"></head><body>";
                string locale = CultureInfo.CurrentCulture.Name;
                if (locale == "zh-TW")
                    html += "<p>Yahoo! \u5947\u6469\u5efa\u8b70\u60a8\u4e0b\u8f09\u66f4\u65b0\u7248\u672c</p>";
                else if (locale == "zh-CN")
                    html += "<p>Yahoo! \u5947\u6469\u5efa\u8bae\u60a8\u4e0b\u8f7d\u66f4\u65b0\u7248\u672c</p?";
                else
                    html += "<p>Please download the newest version of Yahoo! KeyKey.</p>";
                html += "</body></html>";
                this.u_browser.DocumentText = html;
            }
            else
            {
                try
                {
                    this.u_browser.Url = new Uri(formDownload.ChangeLogURL);
                }
                catch {}
            }
            this.FormClosing += new FormClosingEventHandler(FormAskDownload_FormClosing);
        }

        void FormAskDownload_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.m_downloadNow = false;
                Application.Exit();
            }
        }

        void FormAskDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.u_chk.Checked == true && this.m_downloadNow == false)
            {
                DateTime nextWeek = DateTime.Today.AddDays(7);
                RegistryKey registryKey = Registry.LocalMachine;
				// I have no idea about if it would cause exception, I just
				// think it would be more safe to do it so.
				try 
				{
                	registryKey = registryKey.OpenSubKey(@"SOFTWARE\Yahoo\KeyKey", true);
                	registryKey.SetValue("NextCheckDate", nextWeek);
				}
				catch { }
                Application.Exit();
            }
        }

        public bool CheckOptionVisible
        {
            set { u_chk.Visible = value; }
            get { return u_chk.Visible; }
        }

        private void u_Yes_Click(object sender, EventArgs e)
        {
			// If the "Yes" button is pressed, show the download window and
			// continue to download the update pachage.
            this.m_downloadNow = true;
            this.Hide();
            this.m_formDownload.StartProcess();
        }

        private void u_No_Click(object sender, EventArgs e)
        {
			// If the "No" button is pressed, hide download window and exit
			// this application.
            this.m_downloadNow = false;
            this.Close();
            Application.Exit();
        }
    }
}
