/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TakaoPreference
{
    partial class PanelMisc : UserControl
    {
        #region Members
        private Dictionary<string, string> m_generalDictionary;
        private Button u_applyButton;
        private bool m_isInit = false;
        private string m_mediaPath; 
        #endregion

        public PanelMisc(Dictionary<string, string> dictionary, Button button)
        {
            InitializeComponent();
            this.m_generalDictionary = dictionary;
            this.u_applyButton = button;
            this.m_isInit = true;
            this.InitUI();
            this.m_isInit = false;
        }

        #region Get the information about the current version of Windows.
        public static bool IsVistaOrLater
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT
                    && Environment.OSVersion.Version.Major >= 6;
            }
        }

        public static bool IsXp
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT
                    && Environment.OSVersion.Version.Major >= 5;
            }
        } 
        #endregion

        /// <summary>
        /// Initialize the state of the user interface by the
        /// saved preference.
        /// </summary>
        private void InitUI()
        {
            string buffer;

            this.m_generalDictionary.TryGetValue("ShouldUseTransparentStatusBar", out buffer);
            if (buffer == "true")
                this.u_transparentStatusBarCheckBox.Checked = true;
            else
                this.u_transparentStatusBarCheckBox.Checked = false;

            this.m_generalDictionary.TryGetValue("ShouldUseSystemTray", out buffer);
            if (buffer == "true")
                this.u_minimizeToSystemTrayCheckBox.Checked = true;
            else
                this.u_minimizeToSystemTrayCheckBox.Checked = false;

            this.m_generalDictionary.TryGetValue("KeyboardFormShouldFollowCursor", out buffer);
            if (buffer == "true")
                this.u_chkKeyboardFormShouldFollowCursor.Checked = true;
            else
                this.u_chkKeyboardFormShouldFollowCursor.Checked = false;

            this.m_generalDictionary.TryGetValue("HighlightColor", out buffer);
            if (buffer == "Green")
                this.u_highlightColorComboBox.SelectedIndex = 1;
            else if (buffer == "Yellow")
                this.u_highlightColorComboBox.SelectedIndex = 2;
            else if (buffer == "Red")
                this.u_highlightColorComboBox.SelectedIndex = 3;
            else if (buffer.StartsWith("Color "))
                this.u_highlightColorComboBox.SelectedIndex = 4;
            else
                this.u_highlightColorComboBox.SelectedIndex = 0;

            this.m_generalDictionary.TryGetValue("BackgroundColor", out buffer);
            if (buffer == "White")
                this.u_backgroundColorComboBox.SelectedIndex = 1;
            else if (buffer.StartsWith("Color "))
                this.u_backgroundColorComboBox.SelectedIndex = 2;
            else
                this.u_backgroundColorComboBox.SelectedIndex = 0;

            this.m_generalDictionary.TryGetValue("TextColor", out buffer);
            if (buffer == "Black")
                this.u_textColorComboBox.SelectedIndex = 1;
            else if (buffer.StartsWith("Color "))
                this.u_textColorComboBox.SelectedIndex = 2;
            else
                this.u_textColorComboBox.SelectedIndex = 0;

            this.m_generalDictionary.TryGetValue("BackgroundPattern", out buffer);
            if (buffer == "true")
                this.u_backgroundPatternCheckBox.Checked = true;
            else
                this.u_backgroundPatternCheckBox.Checked = false;

            this.m_generalDictionary.TryGetValue("ShouldPlaySoundOnTypingError", out buffer);
            if (buffer == "true")
                this.u_beepCheckBox.Checked = true;
            else
                this.u_beepCheckBox.Checked = false;

            this.m_generalDictionary.TryGetValue("SoundFilename", out buffer);
            
            // @zonble
            // You know what? The information of the media path 
            // (C:\Windows\Media is restored in registry,
            // and there is no better way to obtain this information! 

            #region Get the media file path.
            if (IsVistaOrLater)
            {
                try
                {
                    RegistryKey registryKey = Registry.LocalMachine;
                    registryKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion", false);
                    if (registryKey != null)
                    {
                        string MediaPathUnexpanded = registryKey.GetValue("MediaPathUnexpanded").ToString();
                        m_mediaPath = Environment.ExpandEnvironmentVariables(MediaPathUnexpanded);
                    }
                }
                catch { }

            }
            else if (IsXp)
            {
                try
                {
                    RegistryKey registryKey = Registry.LocalMachine;
                    registryKey = registryKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion", false);
                    if (registryKey != null)
                        m_mediaPath = registryKey.GetValue("MediaPath").ToString();
                }
                catch { }
            } 
            #endregion

            #region Set the sound list.
            if (Directory.Exists(m_mediaPath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(m_mediaPath);
                FileInfo[] fileInfo = dirInfo.GetFiles("*.wav");
                if (fileInfo.Length > 0)
                {

                    foreach (FileInfo f in fileInfo)
                    {
                        string name = f.Name;
                        u_soundListComboBox.Items.Add(f);
                        if (buffer != "Default")
                        {
                            if (buffer == f.FullName)
                            {
                                this.u_soundListComboBox.Text = name;
                            }
                        }
                    }
                }
                else
                {
                    this.u_radioCustomizedSound.Enabled = false;
                    this.u_soundListComboBox.Enabled = false;
                    this.u_radioDefaultSound.Checked = true;
                }
            }
            else
            {
                this.u_radioCustomizedSound.Enabled = false;
                this.u_soundListComboBox.Enabled = false;
                this.u_radioDefaultSound.Checked = true;
            }

            if (buffer == "Default" || buffer.Length == 0)
                this.u_radioDefaultSound.Checked = true;
            else
                this.u_radioCustomizedSound.Checked = true;

            #endregion

			this.u_pluginComboBox.Enabled = false;
			this.u_removePluginButton.Enabled = false;
			PreferenceConnector callback = PreferenceConnector.SharedInstance;
			if (callback != null)
			{
				int count = callback.numberOfUnloadableSignedModules();
				if (count > 0)
				{
					this.u_pluginComboBox.Enabled = true;
					for (int i = 0; i < count; i++)
					{
						string name = callback.localizedNameOfUnloadableSignedModulesAtIndex(i);
						this.u_pluginComboBox.Items.Add(name);
					}
				}
			}
        }

		private void u_transparentStatusBarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_generalDictionary.Remove("ShouldUseTransparentStatusBar");
            }
            catch { }
            if (u_transparentStatusBarCheckBox.Checked == true)
                this.m_generalDictionary.Add("ShouldUseTransparentStatusBar", "true");
            else
                this.m_generalDictionary.Add("ShouldUseTransparentStatusBar", "false");
            this.u_applyButton.Enabled = true;
        }

        private void u_minimizeToSystemTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_generalDictionary.Remove("ShouldUseSystemTray");
            }
            catch { }
            if (u_minimizeToSystemTrayCheckBox.Checked == true)
                this.m_generalDictionary.Add("ShouldUseSystemTray", "true");
            else
                this.m_generalDictionary.Add("ShouldUseSystemTray", "false");
            this.u_applyButton.Enabled = true;
        }

        #region Set the highlight color in the candidate window
        private void u_colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_isInit)
                return;

            try
            {
                this.m_generalDictionary.Remove("HighlightColor");
            }
            catch { }

            switch (this.u_highlightColorComboBox.SelectedIndex)
            {
                case 1:
                    this.m_generalDictionary.Add("HighlightColor", "Green");
                    break;
                case 2:
                    this.m_generalDictionary.Add("HighlightColor", "Yellow");
                    break;
                case 3:
                    this.m_generalDictionary.Add("HighlightColor", "Red");
                    break;
                case 4:
                    DialogResult result = this.u_colorDialog.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        this.m_isInit = true;
                        this.u_highlightColorComboBox.SelectedIndex = 0;
                        this.m_isInit = false;
                        this.m_generalDictionary.Add("HighlightColor", "Purple");
                    }
                    else
                    {
                        Color aColor = u_colorDialog.Color;
                        string colorString = "Color " + aColor.ToArgb().ToString();
                        this.m_generalDictionary.Add("HighlightColor", colorString);
                    }
                    break;
                default:
                    this.m_generalDictionary.Add("HighlightColor", "Purple");
                    break;
            }
            this.u_applyButton.Enabled = true;
        } 
        #endregion

        #region Set the background color in the candidate window
        private void u_backgroundColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_isInit)
                return;

            try
            {
                this.m_generalDictionary.Remove("BackgroundColor");
            }
            catch { }

            switch (this.u_backgroundColorComboBox.SelectedIndex)
            {
                case 1:
                    this.m_generalDictionary.Add("BackgroundColor", "White");
                    break;
                case 2:
                    DialogResult result = this.u_colorDialog.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        this.m_isInit = true;
                        this.u_backgroundColorComboBox.SelectedIndex = 0;
                        this.m_isInit = false;
                        this.m_generalDictionary.Add("BackgroundColor", "Black");
                    }
                    else
                    {
                        Color aColor = u_colorDialog.Color;
                        string colorString = "Color " + aColor.ToArgb().ToString();
                        this.m_generalDictionary.Add("BackgroundColor", colorString);
                    }
                    break;
                default:
                    this.m_generalDictionary.Add("BackgroundColor", "Black");
                    break;
            }
            this.u_applyButton.Enabled = true;
        } 
        #endregion

        private void u_textColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_isInit)
                return;

            try
            {
                this.m_generalDictionary.Remove("TextColor");
            }
            catch { }

            switch (this.u_textColorComboBox.SelectedIndex)
            {
                case 1:
                    this.m_generalDictionary.Add("TextColor", "Black");
                    break;
                case 2:
                    DialogResult result = this.u_colorDialog.ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        this.m_isInit = true;
                        this.u_backgroundColorComboBox.SelectedIndex = 0;
                        this.m_isInit = false;
                        this.m_generalDictionary.Add("TextColor", "White");
                    }
                    else
                    {
                        Color aColor = u_colorDialog.Color;
                        string colorString = "Color " + aColor.ToArgb().ToString();
                        this.m_generalDictionary.Add("TextColor", colorString);
                    }
                    break;
                default:
                    this.m_generalDictionary.Add("TextColor", "White");
                    break;
            }
            this.u_applyButton.Enabled = true;
        }

        private void u_backgroundPatternCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_generalDictionary.Remove("BackgroundPattern");
            }
            catch { }
            if (this.u_backgroundPatternCheckBox.Checked == true)
                this.m_generalDictionary.Add("BackgroundPattern", "true");
            else
                this.m_generalDictionary.Add("BackgroundPattern", "false");
            this.u_applyButton.Enabled = true;
        }

        private void u_beepCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_generalDictionary.Remove("ShouldPlaySoundOnTypingError");
            }
            catch { }
            if (this.u_beepCheckBox.Checked == true)
                this.m_generalDictionary.Add("ShouldPlaySoundOnTypingError", "true");
            else
                this.m_generalDictionary.Add("ShouldPlaySoundOnTypingError", "false");
            this.u_applyButton.Enabled = true;
        }

        private void setAsDefaultSound()
        {
            try
            {
                this.m_generalDictionary.Remove("SoundFilename");
            }
            catch { }
            this.m_generalDictionary.Add("SoundFilename", "Default");
            this.u_applyButton.Enabled = true;
        }

        private void setAsCustomSound(string filename)
        {
            try
            {
                this.m_generalDictionary.Remove("SoundFilename");
            }
            catch { }
            this.m_generalDictionary.Add("SoundFilename", filename);
            this.u_applyButton.Enabled = true;
        }


        private void u_radioDefaultSound_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_isInit)
                return;
            if (this.u_radioDefaultSound.Checked != true)
                return;
            this.setAsDefaultSound();
        }

        private void u_radioCustomizedSound_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_isInit)
                return;
            if (this.u_radioCustomizedSound.Checked != true)
                return;
            if (u_soundListComboBox.SelectedIndex < 0)
                u_soundListComboBox.SelectedIndex = 0;
            string filename = this.m_mediaPath + Path.DirectorySeparatorChar + this.u_soundListComboBox.SelectedItem.ToString();
            this.setAsCustomSound(filename);
        }

        private void u_soundListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_isInit)
                return;
            this.u_radioCustomizedSound.Checked = true;
            if (this.u_soundListComboBox.SelectedIndex < 0)
                return;
            string filename = this.m_mediaPath + Path.DirectorySeparatorChar + this.u_soundListComboBox.SelectedItem.ToString();
            this.setAsCustomSound(filename);
        }

        private void u_testSoundButton_Click(object sender, EventArgs e)
        {
            if (this.u_radioDefaultSound.Checked == true)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                if (this.u_soundListComboBox.SelectedIndex > 0 && this.u_soundListComboBox.SelectedItem.ToString().Length > 0)
                {
                    string mySoundfile = m_mediaPath + Path.DirectorySeparatorChar + this.u_soundListComboBox.SelectedItem.ToString();
                    if (!File.Exists(mySoundfile))
                        return;

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(mySoundfile);
                    try
                    {
                        player.Play();
                    }
                    catch
                    {
						string locale = CultureInfo.CurrentUICulture.Name;
						string message = "Error: Your media file is invalid!";
						if (locale.Equals("zh-TW"))
							message = "\u932f\u8aa4\uff1a\u60a8\u7684\u5a92\u9ad4\u6a94\u6848\u4e0d\u6b63\u78ba\uff01";
						else if (locale.Equals("zh-CN"))
							message = "\u9519\u8bef\uff1a\u60a8\u7684\u5a92\u4f53\u6863\u6848\u4e0d\u6b63\u786e\uff01";
                        MessageBox.Show(message);
                    }
                }
            }
        }

        private void u_chkKeyboardFormShouldFollowCursor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_generalDictionary.Remove("KeyboardFormShouldFollowCursor");
            }
            catch { }
            if (this.u_chkKeyboardFormShouldFollowCursor.Checked == true)
                this.m_generalDictionary.Add("KeyboardFormShouldFollowCursor", "true");
            else
                this.m_generalDictionary.Add("KeyboardFormShouldFollowCursor", "false");
            this.u_applyButton.Enabled = true;
        }

		private void u_pluginComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.u_pluginComboBox.SelectedIndex > -1)
				this.u_removePluginButton.Enabled = true;
		}

		private void u_removePluginButton_Click(object sender, EventArgs e)
		{
			PreferenceConnector callback = PreferenceConnector.SharedInstance;
			if (callback == null) 
			{
				// Show alert.
				return;
			}
			
			int index = this.u_pluginComboBox.SelectedIndex;
			string locale = CultureInfo.CurrentUICulture.Name;

			if (index > -1 && index < callback.numberOfUnloadableSignedModules() )
			{
				string name = callback.localizedNameOfUnloadableSignedModulesAtIndex(index);
				string message = "Do you really want to unload \"" + name + "\"?";
				if (locale.Equals("zh-TW"))
					message = "\u60a8\u78ba\u5b9a\u8981\u89e3\u9664\u5b89\u88dd\u300c" + name + "\u300d\u55ce\uff1f";
				else if (locale.Equals("zh-CN"))
					message = "\u60a8\u786e\u5b9a\u8981\u89e3\u9664\u5b89\u88c5\u201c" + name + "\u201d\u5417\uff1f";

				DialogResult dialogResult = MessageBox.Show(message, string.Empty, MessageBoxButtons.YesNo);
				if (dialogResult.Equals(DialogResult.Yes))
				{
					bool result = callback.unloadSignedModuleAtIndex(index);
					if (result)
					{
						string title = "Successfully unloaded the plugin!";
						if (locale.Equals("zh-TW"))
							title = "\u6210\u529f\u89e3\u9664\u5b89\u88dd";
						else if (locale.Equals("zh-CN"))
							title = "\u6210\u529f\u89e3\u9664\u5b89\u88c5";

						message = "Since your software is changed, we have to quit the preference program";
						if (locale.Equals("zh-TW"))
							message = "\u56e0\u70ba\u60a8\u7684\u8f38\u5165\u6cd5\u7cfb\u7d71\u8a2d\u5b9a\u5df2\u7d93\u6539\u8b8a\uff0c\u6211\u5011\u73fe\u5728\u5fc5\u9808\u95dc\u9589\u504f\u597d\u8a2d\u5b9a\u5de5\u5177\u3002";
						else if (locale.Equals("zh-CN"))
							message = "\u56e0\u4e3a\u60a8\u7684\u8f93\u5165\u6cd5\u7cfb\u7edf\u8bbe\u5b9a\u5df2\u7ecf\u6539\u53d8\uff0c\u6211\u4eec\u73b0\u5728\u5fc5\u987b\u5173\u95ed\u504f\u597d\u8bbe\u5b9a\u5de5\u5177\u3002";

						MessageBox.Show(message, title);
						Application.Exit();
					}
					else
					{
						string title = "Faild to unload this plugin!";
						if (locale.Equals("zh-TW"))
							title = "\u7121\u6cd5\u89e3\u9664\u5b89\u88dd\u9019\u500b\u5916\u639b\u7a0b\u5f0f\uff01";
						else if (locale.Equals("zh-CN"))
							title = "\u65e0\u6cd5\u89e3\u9664\u5b89\u88c5\u8fd9\u4e2a\u63d2\u4ef6\uff01";

						message = "You may need System Administrator permission.";
						if (locale.Equals("zh-TW"))
							message = "\u5982\u679c\u5728 Windows Vista \u4e0b\uff0c\u60a8\u9700\u8981\u7cfb\u7d71\u7ba1\u7406\u54e1\u6b0a\u9650\uff0c\u624d\u80fd\u522a\u9664\u5916\u639b\u7a0b\u5f0f\u3002";
						else if (locale.Equals("zh-CN"))
							message = "\u5982\u679c\u5728 Windows Vista \u4e0b\uff0c\u60a8\u9700\u8981\u7cfb\u7edf\u7ba1\u7406\u5458\u6743\u9650\uff0c\u624d\u80fd\u5220\u9664\u63d2\u4ef6\u3002";

						MessageBox.Show(message, title);
					}
				}
			}
		}
    }
}
