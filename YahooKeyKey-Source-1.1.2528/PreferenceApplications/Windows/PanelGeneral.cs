/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using BaseIMEUI;

namespace TakaoPreference
{
    /// <remarks>
    /// The general settings.
    /// </remarks>
    partial class PanelGeneral : UserControl
    {
        #region Memebers
        private Dictionary<string, string> m_generalDictionary;
        private Dictionary<string, string> m_oneKeyDictionary;
        private Dictionary<string, string> m_modulesDictionary;
        private Button u_applyButton;
        private bool m_init = false; 
        #endregion

        public PanelGeneral(Dictionary<string, string> dictionary, Dictionary<string, string> oneKeyDictionary, Dictionary<string, string>generalInputmethods,  Button button)
        {
            this.m_generalDictionary = dictionary;
			this.m_oneKeyDictionary = oneKeyDictionary;
            this.u_applyButton = button;
            InitializeComponent();

            this.m_modulesDictionary = new Dictionary<string,string>();

            string currentLocale = CultureInfo.CurrentUICulture.Name;
			if (currentLocale.Equals("zh-TW"))
			{
	            this.m_modulesDictionary.Add("SmartMandarin", "\u597d\u6253\u6ce8\u97f3");
	            this.m_modulesDictionary.Add("TraditionalMandarins","\u50b3\u7d71\u6ce8\u97f3");
	            this.m_modulesDictionary.Add("Generic-cj-cin","\u5009\u9821");
	            this.m_modulesDictionary.Add("Generic-simplex-cin","\u7c21\u6613");
			}
            else if (currentLocale.Equals("zh-CN"))
			{
	            this.m_modulesDictionary.Add("SmartMandarin", "\u597d\u6253\u6ce8\u97f3");
	            this.m_modulesDictionary.Add("TraditionalMandarins","\u4f20\u7edf\u6ce8\u97f3");
	            this.m_modulesDictionary.Add("Generic-cj-cin","\u4ed3\u9889");
	            this.m_modulesDictionary.Add("Generic-simplex-cin","\u7b80\u6613");				
			}
            else
			{
	            this.m_modulesDictionary.Add("SmartMandarin", "Smart Phontic");
	            this.m_modulesDictionary.Add("TraditionalMandarins","Traditional Phonetic");
	            this.m_modulesDictionary.Add("Generic-cj-cin","Cangjie");
	            this.m_modulesDictionary.Add("Generic-simplex-cin","Simplex");		
			}

            foreach (KeyValuePair<string, string> kvp in generalInputmethods)
            {
                this.m_modulesDictionary.Add(kvp.Key, kvp.Value);
            }

            this.InitUI();
            this.InitModules();
        }

        #region Init
        private void InitUI()
        {
            this.m_init = true;
            string buffer;
            #region IgnoreShiftAsAlphanumericModeToggleKey
            this.m_generalDictionary.TryGetValue("IgnoreShiftAsAlphanumericModeToggleKey", out buffer);
            if (buffer == "true")
                this.u_shiftKeyCheckBox.Checked = false;
            else 
                this.u_shiftKeyCheckBox.Checked = true;

            this.m_generalDictionary.TryGetValue("EnablesCapsLockAsAlphanumericModeToggle", out buffer);
            if (buffer == "true")
                this.u_capslockCheckBox.Checked = true;
            else
                this.u_capslockCheckBox.Checked = false;

            this.m_generalDictionary.TryGetValue("ToggleInputMethodWithControlBackslash", out buffer);
            if (buffer == "true")
                this.u_ctrlBackslashCheckBox.Checked = true;
            else
                this.u_ctrlBackslashCheckBox.Checked = false;

            this.m_generalDictionary.TryGetValue("ShouldUseNotifyWindow", out buffer);
            if (buffer == "true")
                this.u_notifyCheckBox.Checked = true;
            else
                this.u_notifyCheckBox.Checked = false;

			this.m_oneKeyDictionary.TryGetValue("ShortcutKey", out buffer);
			if (buffer == "~") 
			{
				this.u_shortcutComboBox.SelectedIndex = 1;
				this.u_shortcutComboBox.Text = "~";
			}
			else 
			{
				this.u_shortcutComboBox.SelectedIndex = 0;
				this.u_shortcutComboBox.Text = "`";
			}

            int i = 0;

			//Chinese converter

            this.m_generalDictionary.TryGetValue("ChineseConverterToggleKey", out buffer);
            string chineseConverterToggleKey = "";

            if (buffer != null && buffer.Length > 0)
            {
                if (buffer.Length > 1)
                     buffer = buffer.Remove(1);
                 chineseConverterToggleKey = buffer;
            }

            string noneString = "None";
		 	string locale = CultureInfo.CurrentCulture.Name;
            if (locale.Equals("zh-TW"))
                locale = "\u7121";
			else if (locale.Equals("zh-CN"))
                locale = "\u65e0";

            this.u_chineseConverterToggleComboBox.Items.Add(noneString);

            for (i = 0; i < 26; i++)
            {
                char aChar = (char)('a' + i);
                this.u_chineseConverterToggleComboBox.Items.Add(aChar);
            }
            if (chineseConverterToggleKey.Length > 0)
            {
                this.u_chineseConverterToggleComboBox.Text = chineseConverterToggleKey;
            }
            else
            {
                this.u_chineseConverterToggleComboBox.SelectedIndex = 0;
                this.u_chineseConverterToggleComboBox.Text = noneString;
            }

			// Repeat last

            this.m_generalDictionary.TryGetValue("RepeatLastCommitTextKey", out buffer);
            string repeatKey = "";

            if (buffer != null && buffer.Length > 0)
            {
                if (buffer.Length > 1)
                    buffer = buffer.Remove(1);
                repeatKey = buffer;
            }

			this.u_repeatComboBox.Items.Add(noneString);

            for (i = 0; i < 26; i++)
            {
                char aChar = (char)('a' + i);
                this.u_repeatComboBox.Items.Add(aChar);
            }
            if (repeatKey.Length > 0)
            {
                this.u_repeatComboBox.Text = repeatKey;
            }
            else
            {
                this.u_repeatComboBox.SelectedIndex = 0;
                this.u_repeatComboBox.Text = noneString;
            }

            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                if (callback.moduleWithWildcardNameExists("ReverseLookup-*") == false)
                {
                    this.u_reverseLookupComboBox.Enabled = false;
                    this.u_lookupLabel.Enabled = false;
                    this.ReverseLookupMethod = "";
                }
                else
                {
                    this.u_reverseLookupComboBox.Enabled = true;
                    this.u_lookupLabel.Enabled = true;

                    this.u_reverseLookupComboBox.SelectedIndex = 0;
                    this.ReverseLookupMethod = "";

                    this.m_generalDictionary.TryGetValue("ActivatedAroundFilters", out buffer);
                    if (buffer != null && buffer.Length > 0 && buffer.StartsWith("ARRAY:"))
                    {
                        string stringToExplode = buffer.Remove(0, 6);
                        string[] aroundFilters = stringToExplode.Split(", ".ToCharArray());
                        foreach (string aroundFilter in aroundFilters)
                        {
                            if (aroundFilter == "ReverseLookup-Generic-cj-cin")
                            {
                                this.u_reverseLookupComboBox.SelectedIndex = 1;
                                this.ReverseLookupMethod = aroundFilter;
                                break;
                            }
                            else if (aroundFilter == "ReverseLookup-Mandarin-bpmf-cin")
                            {
                                this.u_reverseLookupComboBox.SelectedIndex = 2;
                                this.ReverseLookupMethod = aroundFilter;
                                break;
                            }
                            else if (aroundFilter == "ReverseLookup-Mandarin-bpmf-cin-HanyuPinyin")
                            {
                                this.u_reverseLookupComboBox.SelectedIndex = 3;
                                this.ReverseLookupMethod = aroundFilter;
                                break;
                            }
                        }
                    }
                }
            }

            this.m_init = false;

            #endregion
        }
        private void InitModules()
        {
            string modulesSuppressedFromUI;
            this.m_generalDictionary.TryGetValue("ModulesSuppressedFromUI", out modulesSuppressedFromUI);
            List<string> modulesSuppressed = new List<string>();

            if (modulesSuppressedFromUI != null && modulesSuppressedFromUI.Length > 0 && modulesSuppressedFromUI.StartsWith("ARRAY:"))
            {
                string stringToExplode = modulesSuppressedFromUI.Remove(0, 6);
                string[] explodedStrings = stringToExplode.Split(", ".ToCharArray());
                foreach (string item in explodedStrings)
                {
                    modulesSuppressed.Add(item);
                }
            }


            foreach (KeyValuePair<string, string> kvp in m_modulesDictionary)
            {
                bool shouldShow = true;
                string moduleName = kvp.Key;
                if (modulesSuppressed.Contains(moduleName))
                    shouldShow = false;

                this.u_moduleCheckListBox.Items.Add(kvp.Value, shouldShow);
            }
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handle enabling or disabling associted-phrases.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_chkAssociatedPhrases_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            try
            {
                this.m_generalDictionary.Remove("IgnoreShiftAsAlphanumericModeToggleKey");
            }
            catch { }

            if (u_shiftKeyCheckBox.Checked == true)
            {
                this.m_generalDictionary.Add("IgnoreShiftAsAlphanumericModeToggleKey", "false");
                this.u_capslockCheckBox.Checked = false;
            }
            else
            {
                this.m_generalDictionary.Add("IgnoreShiftAsAlphanumericModeToggleKey", "true");
            }
            this.u_applyButton.Enabled = true;
        }

        private void u_capslockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            try
            {
                this.m_generalDictionary.Remove("EnablesCapsLockAsAlphanumericModeToggle");
            }
            catch { }

            if (this.u_capslockCheckBox.Checked == true)
            {
                this.m_generalDictionary.Add("EnablesCapsLockAsAlphanumericModeToggle", "true");
                this.u_shiftKeyCheckBox.Checked = false;
            }
            else
            {
                this.m_generalDictionary.Add("EnablesCapsLockAsAlphanumericModeToggle", "false");
            }
            this.u_applyButton.Enabled = true;
        }

        private void u_chkCtrlBackslash_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            try
            {
                this.m_generalDictionary.Remove("ToggleInputMethodWithControlBackslash");
            }
            catch { }

            if (this.u_ctrlBackslashCheckBox.Checked == true)
                this.m_generalDictionary.Add("ToggleInputMethodWithControlBackslash", "true");
            else
                this.m_generalDictionary.Add("ToggleInputMethodWithControlBackslash", "false");
            this.u_applyButton.Enabled = true;
        }

        private void u_chkNotify_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            try
            {
                this.m_generalDictionary.Remove("ShouldUseNotifyWindow");
            }
            catch { }

            if (this.u_notifyCheckBox.Checked == true)
                this.m_generalDictionary.Add("ShouldUseNotifyWindow", "true");
            else
                this.m_generalDictionary.Add("ShouldUseNotifyWindow", "false");
            this.u_applyButton.Enabled = true;
        }
        

        private void u_shortcut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            try
            {
                this.m_oneKeyDictionary.Remove("ShortcutKey");
            }
            catch { }

            if (this.u_shortcutComboBox.SelectedIndex == 1)
                this.m_oneKeyDictionary.Add("ShortcutKey", "~");
            else
                this.m_oneKeyDictionary.Add("ShortcutKey", "`");
            this.u_applyButton.Enabled = true;
        }

        private void u_moduleCheckListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            if (this.u_moduleCheckListBox.CheckedItems.Count == 0)
                this.u_moduleCheckListBox.SetItemChecked(this.u_moduleCheckListBox.SelectedIndex, true);

            try
            {
                this.m_generalDictionary.Remove("ModulesSuppressedFromUI");
            }
            catch { }

            int i = 0;
            List<string> modules = new List<string>();
            foreach (KeyValuePair<string, string> kvp in m_modulesDictionary)
            {
                bool itemChecked = u_moduleCheckListBox.GetItemChecked(i);
                if (itemChecked == false)
                {
                    string moduleName = kvp.Key;
                    modules.Add(moduleName);
                }
                i++;
            }
            string serializedString = TakaoHelper.SerializeListToString(modules);
            this.m_generalDictionary.Add("ModulesSuppressedFromUI", serializedString);

            this.u_applyButton.Enabled = true;
        }



        private void u_comboChineseConverterToggle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            if (this.u_chineseConverterToggleComboBox.SelectedIndex != 0 &&
				this.u_chineseConverterToggleComboBox.Text == u_repeatComboBox.Text)
            {
                string buffer;
                this.m_oneKeyDictionary.TryGetValue("ChineseConverterToggleKey", out buffer);
                string chineseConverterToggleKey = "s";
                if (this.u_repeatComboBox.Text == "s")
                    chineseConverterToggleKey = "g";
                else if (buffer != null && buffer.Length > 0)
                    chineseConverterToggleKey = buffer.Remove(1);
                this.u_chineseConverterToggleComboBox.Text = chineseConverterToggleKey;
                return;
            }

            try
            {
                this.m_generalDictionary.Remove("ChineseConverterToggleKey");
            }
            catch { }

			if (this.u_chineseConverterToggleComboBox.SelectedIndex == 0)
	            this.m_generalDictionary.Add("ChineseConverterToggleKey", "");
			else
	            this.m_generalDictionary.Add("ChineseConverterToggleKey",
					this.u_chineseConverterToggleComboBox.Text);
            this.u_applyButton.Enabled = true;
        }

        private void u_comboRepeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_init)
                return;

            if (this.u_repeatComboBox.SelectedIndex != 0 &&
                this.u_repeatComboBox.Text == this.u_chineseConverterToggleComboBox.Text)
            {
                string buffer;
                this.m_oneKeyDictionary.TryGetValue("RepeatLastCommitTextKey", out buffer);
                string repeatKey = "g";
                if (this.u_chineseConverterToggleComboBox.Text == "g")
                    repeatKey = "s";
                else if (buffer != null && buffer.Length > 0)
                    repeatKey = buffer.Remove(1);
                this.u_repeatComboBox.Text = repeatKey;
                return;
            }

            try
            {
                this.m_generalDictionary.Remove("RepeatLastCommitTextKey");
            }
            catch { }
			if (this.u_repeatComboBox.SelectedIndex == 0)
	            this.m_generalDictionary.Add("RepeatLastCommitTextKey", "");
			else
	            this.m_generalDictionary.Add("RepeatLastCommitTextKey", this.u_repeatComboBox.Text);
            this.u_applyButton.Enabled = true;
        }

        public string ReverseLookupMethod = "";
        private void u_reverseLookupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.u_reverseLookupComboBox.SelectedIndex)
            {
                case 0:
                    this.ReverseLookupMethod = "";
                    break;
                case 1:
                    this.ReverseLookupMethod = "ReverseLookup-Generic-cj-cin";                    
                    break;
                case 2:
                    this.ReverseLookupMethod = "ReverseLookup-Mandarin-bpmf-cin";
                    break;
                case 3:
                    this.ReverseLookupMethod = "ReverseLookup-Mandarin-bpmf-cin-HanyuPinyin";
                    break;
                default:
                    this.ReverseLookupMethod = "";
                    break;
            }
            this.u_applyButton.Enabled = true;
        }

        #endregion

    }
}
