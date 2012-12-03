/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace TakaoPreference
{
    partial class PanelPhrases : UserControl
    {
        public PanelPhrases()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the Open Dialog Window to start import phrases.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Import(object sender, EventArgs e)
        {
            DialogResult result =  this.u_importDialog.ShowDialog();
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            if (result == DialogResult.OK)
            {
                string filename = this.u_importDialog.FileName;
                bool importResult = PreferenceConnector.SharedInstance.importPhraseDB(filename);

                if (importResult)
                {
                    if (currentLocale == "zh-TW")
                        MessageBox.Show("\u8a5e\u5f59\u5df2\u7d93\u6210\u529f\u532f\u5165\u3002", "\u5b8c\u6210", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (currentLocale == "zh-CN")
                        MessageBox.Show("\u8bcd\u6c47\u5df2\u7ecf\u6210\u529f\u6c47\u5165\u3002", "\u5b8c\u6210", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Your phrases are successfully imported", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (currentLocale == "zh-TW")
                        MessageBox.Show("\u8a5e\u5f59\u532f\u5165\u5931\u6557\u3002", "\u932f\u8aa4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (currentLocale == "zh-CN")
						MessageBox.Show("\u8bcd\u6c47\u6c47\u5165\u5931\u8d25\u3002", "\u9519\u8bef", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Your phrases could not be imported.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Opens the Save Dialog Window to start export phrases.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export(object sender, EventArgs e)
        {
            DialogResult result = this.u_exportDialog.ShowDialog();
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            if (result == DialogResult.OK)
            {
                string filename = this.u_exportDialog.FileName;
                bool exportResult = PreferenceConnector.SharedInstance.exportPhraseDB(filename);

                if (exportResult)
                {
                    if (currentLocale == "zh-TW")
						MessageBox.Show("\u8a5e\u5f59\u5df2\u7d93\u6210\u529f\u532f\u51fa\u3002", "\u5b8c\u6210", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (currentLocale == "zh-CN")
						MessageBox.Show("\u8bcd\u6c47\u5df2\u7ecf\u6210\u529f\u6c47\u51fa\u3002", "\u5b8c\u6210", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Your phrases are successfully exported", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (currentLocale == "zh-TW")
						MessageBox.Show("\u8a5e\u5f59\u532f\u51fa\u5931\u6557\u3002", "\u932f\u8aa4", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (currentLocale == "zh-CN")
						MessageBox.Show("\u8bcd\u6c47\u6c47\u51fa\u5931\u8d25\u3002", "\u9519\u8bef", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Your phrases could not be exported.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LaunchProcessInThread()
        {	
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "PhraseEditor.exe";
	
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = filename;
            try
            {
                process.Start();
            }
            catch { }

        }

        private void LaunchPhraseEditor(object sender, EventArgs e)
        {
            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "PhraseEditor.exe";

            if (!File.Exists(filename))
            {
                MessageBox.Show("The Phrase Editor does not exists! Please check your installation.", "Error!");

                return;
            }

            try
            {
                ThreadStart threadStart = new ThreadStart(LaunchProcessInThread);
                Thread thread = new Thread(threadStart);
                thread.Start();
            }
            catch { }
            Thread.Sleep(1000);
			Application.Exit();
        }

		private void EditSymbolsInThread()
		{
		    PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback != null)
            {
    			string filename = callback.userFreeCannedMessagePath();
    			Process process = new Process();
    			process.StartInfo.FileName = "Notepad.exe";
    			process.StartInfo.Arguments = filename;
    			process.Start();
	        }
		}

		private void EditSymbols(object sender, EventArgs e)
		{
			try
			{
				ThreadStart threadStart = new ThreadStart(EditSymbolsInThread);
				Thread thread = new Thread(threadStart);
				thread.Start();
			}
			catch { }
            Thread.Sleep(1000);
			Application.Exit();

		}
    }
}
