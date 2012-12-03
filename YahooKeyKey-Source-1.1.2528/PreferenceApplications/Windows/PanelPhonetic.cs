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

namespace TakaoPreference
{
    partial class PanelPhonetic : UserControl
    {
        private Dictionary<string, string> m_phoneticDictionary;
        private Dictionary<string, string> m_smartPhoneticDictionary;

        private Button u_applyButton;
        private bool m_isLoading = false;

        public PanelPhonetic(Dictionary<string, string> dictionary, Dictionary<string, string> smartPhoneticDictionary, Button button)
        {
            InitializeComponent();
            this.m_phoneticDictionary = dictionary;
            this.m_smartPhoneticDictionary = smartPhoneticDictionary;
            this.u_applyButton = button;
            this.InitUI();
        }
        #region Init
        /// <summary>
        /// Initailizing the User Interface of the Phonetic Input Method Setting preferencePane;
        /// </summary>
        private void InitUI()
        {
            this.m_isLoading = true;
			string locale = CultureInfo.CurrentCulture.Name;

            string selectionKeys;
            this.m_smartPhoneticDictionary.TryGetValue("CandidateSelectionKeys", out selectionKeys);
            if ((selectionKeys == null )|| (selectionKeys.Length == 0))
                selectionKeys = "12345678";

            bool found = false;
            for (int i = 0; i < this.u_selectionKeyComboBox.Items.Count; i++)
            {
                if (this.u_selectionKeyComboBox.Items[i].ToString() == selectionKeys)
                {
                    this.u_selectionKeyComboBox.SelectedIndex = i;
                    this.u_selectionKeyComboBox.Text = selectionKeys;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                this.u_selectionKeyComboBox.SelectedIndex = 0;
                this.u_selectionKeyComboBox.Text = "12345678";
            }

            string keyboardLayout;
            this.m_smartPhoneticDictionary.TryGetValue("KeyboardLayout", out keyboardLayout);

            if (keyboardLayout.Equals("ETen"))
            {
                this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 1;
                this.u_smartPhonetickeyboardLayoutComboBox.Text = this.u_smartPhonetickeyboardLayoutComboBox.Items[1].ToString();
            }
			else if (keyboardLayout.Equals("Hanyu Pinyin"))
			{
				this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 2;
				this.u_smartPhonetickeyboardLayoutComboBox.Text = this.u_smartPhonetickeyboardLayoutComboBox.Items[2].ToString();
			}
            else if (keyboardLayout.Equals("bpmfdtnlvkhgvcgycjqwsexuaorwiqzpmntlhfjkd") || 
				keyboardLayout.Equals("ETen26"))
            {
				string other = "Other";
				if (locale.Equals("zh-TW"))
					other = "\u5176\u4ed6";
				else if (locale.Equals("zh-CN"))
					other = "\u5176\u4ed6";
				this.u_smartPhonetickeyboardLayoutComboBox.Items.Add(other);
				this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 3;
				this.u_smartPhonetickeyboardLayoutComboBox.Text = other;
            }
            else if (keyboardLayout.Equals("bpmfdtnlgkhjvcjvcrzasexuyhgeiawomnklldfjs") ||
				keyboardLayout.Equals("Hsu"))
            {
				string other = "Other";
				if (locale.Equals("zh-TW"))
					other = "\u5176\u4ed6";
				else if (locale.Equals("zh-CN"))
					other = "\u5176\u4ed6";
				this.u_smartPhonetickeyboardLayoutComboBox.Items.Add(other);
				this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 3;
				this.u_smartPhonetickeyboardLayoutComboBox.Text = other;
            }
            else if (keyboardLayout.Equals("Standard"))
            {
                this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 0;
                this.u_smartPhonetickeyboardLayoutComboBox.Text = this.u_smartPhonetickeyboardLayoutComboBox.Items[0].ToString();
            }
            else
            {
                this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 0;
                this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = this.u_traditionalPhoneticKeyboardLayoutComboBox.Items[0].ToString();
            }

           this. m_phoneticDictionary.TryGetValue("KeyboardLayout", out keyboardLayout);

            if (keyboardLayout.Equals("ETen"))
            {
                this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 1;
                this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = this.u_traditionalPhoneticKeyboardLayoutComboBox.Items[1].ToString();

            }
			else if (keyboardLayout.Equals("Hanyu Pinyin"))
			{
				this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 2;
				this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = this.u_traditionalPhoneticKeyboardLayoutComboBox.Items[2].ToString();
			}
            else if (keyboardLayout.Equals("bpmfdtnlvkhgvcgycjqwsexuaorwiqzpmntlhfjkd") || 
				keyboardLayout.Equals("ETen26"))
            {
				string other = "Other";
				if (locale.Equals("zh-TW"))
					other = "\u5176\u4ed6";
				else if (locale.Equals("zh-CN"))
					other = "\u5176\u4ed6";
				this.u_traditionalPhoneticKeyboardLayoutComboBox.Items.Add(other);
				this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 3;
				this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = other;
            }
            else if (keyboardLayout.Equals("bpmfdtnlgkhjvcjvcrzasexuyhgeiawomnklldfjs") ||
				keyboardLayout.Equals("Hsu"))
            {
				string other = "Other";
				if (locale.Equals("zh-TW"))
					other = "\u5176\u4ed6";
				else if (locale.Equals("zh-CN"))
					other = "\u5176\u4ed6";
				this.u_traditionalPhoneticKeyboardLayoutComboBox.Items.Add(other);
				this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 3;
				this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = other;
            }

            else if (keyboardLayout.Equals("Standard"))
            {
                this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 0;
                this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = this.u_traditionalPhoneticKeyboardLayoutComboBox.Items[0].ToString();
            }
            else
            {
                this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 0;
                this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = this.u_traditionalPhoneticKeyboardLayoutComboBox.Items[0].ToString();
            }

            string buffer;
            this.m_smartPhoneticDictionary.TryGetValue("ShowCandidateListWithSpace", out buffer);

            if (buffer != null && buffer == "true")
                this.u_showCandidateWithSpaceCheckBox.Checked = true;
            else
                this.u_showCandidateWithSpaceCheckBox.Checked = false;

            this.m_smartPhoneticDictionary.TryGetValue("ClearComposingTextWithEsc", out buffer);
            if (buffer != null && buffer == "true")
                this.u_clearWithEscCheckBox.Checked = true;
            else
                this.u_clearWithEscCheckBox.Checked = false;

            string allUnicode;
            this.m_smartPhoneticDictionary.TryGetValue("UseCharactersSupportedByEncoding", out allUnicode);
            if (allUnicode != null && allUnicode == "")
                this.u_smartPhoneticNonBig5CheckBox.Checked = true;
            else
                this.u_smartPhoneticNonBig5CheckBox.Checked = false;

            this.m_phoneticDictionary.TryGetValue("UseCharactersSupportedByEncoding", out allUnicode);
            if (allUnicode != null && allUnicode == "")
                this.u_traditionalPhoneticNonBig5CheckBox.Checked = true;
            else
                this.u_traditionalPhoneticNonBig5CheckBox.Checked = false;

            this.m_smartPhoneticDictionary.TryGetValue("ComposingTextBufferSize", out buffer);
            this.u_bufferSizeNumericUpDown.Value = Convert.ToDecimal(buffer);

            if (this.u_bufferSizeNumericUpDown.Value < 10)
                this.u_bufferSizeNumericUpDown.Value = 10;

            this.m_isLoading = false;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handle toggling enable or disable full unicode support.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeSmartPhoneticUseNonBig5(object sender, EventArgs e)
        {
            try
            {
                this.m_smartPhoneticDictionary.Remove("UseCharactersSupportedByEncoding");
            }
            catch { }

            if (this.u_smartPhoneticNonBig5CheckBox.Checked == true)
                this.m_smartPhoneticDictionary.Add("UseCharactersSupportedByEncoding", "");
            else
                this.m_smartPhoneticDictionary.Add("UseCharactersSupportedByEncoding", "BIG-5");

            this.u_applyButton.Enabled = true;
        }

        private void ChangeTraditionalPhoneticUseNonBig5(object sender, EventArgs e)
        {
            try
            {
                this.m_phoneticDictionary.Remove("UseCharactersSupportedByEncoding");
            }
            catch { }

            if (this.u_traditionalPhoneticNonBig5CheckBox.Checked == true)
                this.m_phoneticDictionary.Add("UseCharactersSupportedByEncoding", "");
            else
                this.m_phoneticDictionary.Add("UseCharactersSupportedByEncoding", "BIG-5");

            this.u_applyButton.Enabled = true;
        }

        private void ChangeClearWithEscCheckBox(object sender, EventArgs e)
        {
            try
            {
                this.m_smartPhoneticDictionary.Remove("ClearComposingTextWithEsc");
            }
            catch { }
            if (this.u_clearWithEscCheckBox.Checked == true)
                this.m_smartPhoneticDictionary.Add("ClearComposingTextWithEsc", "true");
            else
                this.m_smartPhoneticDictionary.Add("ClearComposingTextWithEsc", "false");

            this.u_applyButton.Enabled = true;
        }

        private void ChangeShowCandidateWithSpaceCheckBox(object sender, EventArgs e)
        {
            try
            {
                this.m_smartPhoneticDictionary.Remove("ShowCandidateListWithSpace");
            }
            catch
            { }
            if (this.u_showCandidateWithSpaceCheckBox.Checked == true)
                this.m_smartPhoneticDictionary.Add("ShowCandidateListWithSpace", "true");
            else
                this.m_smartPhoneticDictionary.Add("ShowCandidateListWithSpace", "false");

            this.u_applyButton.Enabled = true;
        }

        private bool ValidateSelectionKeySet(string selectionKey)
        {
            int i;
            for (i = 0; i < selectionKey.Length - 1; i++)
            {
                char currentChar = selectionKey[i];
                int j;
                for (j = i + 1; j < selectionKey.Length; j++)
                {
                    char checkChar = selectionKey[j];
                    if (currentChar == checkChar)
                        return false;
                }
            }
            return true;
        }

        private void UpdateSelectionKey()
        {
            string selectionKey = u_selectionKeyComboBox.Text;
            if (this.ValidateSelectionKeySet(selectionKey) == false)
                selectionKey = "12345678";
            else if (selectionKey.Length < 8)
                selectionKey = "12345678";
            else if (selectionKey.Length > 8)
                selectionKey = selectionKey.Remove(8, selectionKey.Length - 8);

            this.u_selectionKeyComboBox.Text = selectionKey;

            try
            {
                this.m_smartPhoneticDictionary.Remove("CandidateSelectionKeys");
            }
            catch { }
            this.m_smartPhoneticDictionary.Add("CandidateSelectionKeys", selectionKey);
            this.u_applyButton.Enabled = true;
        }

        private void ChangeSelectionKey(object sender, EventArgs e)
        {
            this.UpdateSelectionKey();
        }

        private void KeyInNewSelectionKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                this.UpdateSelectionKey();
        }

        #endregion

        private void ShowExtraSelectionKeySets(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.u_selectionKeyComboBox.Items.Clear();
                this.u_selectionKeyComboBox.Items.AddRange(new object[] { 
                "12345678", "asdfghjk", "asdfzxcv", "aoeuidht", "aoeu;qjk"
                });
				this.u_selectionKeyComboBox.SelectedIndex = 0;
				this.u_selectionKeyComboBox.Text = u_selectionKeyComboBox.Items[0].ToString();
            }
        }

        private void ChangeBufferSize(object sender, EventArgs e)
        {
            string bufferSize = u_bufferSizeNumericUpDown.Value.ToString();
            try
            {
                this.m_smartPhoneticDictionary.Remove("ComposingTextBufferSize");
            }
            catch { }
            try
            {
                this.m_smartPhoneticDictionary.Add("ComposingTextBufferSize", bufferSize);
            }
            catch { }

            this.u_applyButton.Enabled = true;
        }

        private void ChangeSmartPhoneticKeyboardLayout(object sender, EventArgs e)
        {
            if (this.m_isLoading)
                return;

            if (sender != this.u_smartPhonetickeyboardLayoutComboBox)
                return;

            try
            {
                this.m_smartPhoneticDictionary.Remove("KeyboardLayout");
            }
            catch { }
            string keyboardLayout = "";
            switch (this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex)
            {
                case 0:
                    keyboardLayout = "Stanard";
                    break;
                case 1:
                    keyboardLayout = "ETen";
                    break;
                case 2:
					keyboardLayout = "Hanyu Pinyin";
                    break;
                case 3:
					if (this.u_smartPhonetickeyboardLayoutComboBox.Items.Count < 5)
						return;

					keyboardLayout = "ETen26";
                    break;
                case 4:
					keyboardLayout = "Hsu";
                    break;
                default:
                    break;
            }
            try
            {
                this.m_smartPhoneticDictionary.Add("KeyboardLayout", keyboardLayout);
            }
            catch { }
            this.u_applyButton.Enabled = true;
        }

        private void ChangeTraditionalPhoneticKeyboardLayout(object sender, EventArgs e)
        {
            if (this.m_isLoading)
                return;

            if (sender != this.u_traditionalPhoneticKeyboardLayoutComboBox)
                return;

            try
            {
                this.m_phoneticDictionary.Remove("KeyboardLayout");
            }
            catch { }
            string keyboardLayout = "";
            switch (this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex)
            {
                case 0:
                    keyboardLayout = "Stanard";
                    break;
                case 1:
                    keyboardLayout = "ETen";
                    break;
                case 2:
					keyboardLayout = "Hanyu Pinyin";
                    break;
                case 3:
					if (this.u_traditionalPhoneticKeyboardLayoutComboBox.Items.Count < 5)
						return;
					keyboardLayout = "ETen26";
                    break;
                case 4:
					keyboardLayout = "Hsu";
                    break;
                default:
                    keyboardLayout = "Stanard";
                    break;
            }
            try
            {
                this.m_phoneticDictionary.Add("KeyboardLayout", keyboardLayout);
            }
            catch { }
            this.u_applyButton.Enabled = true;
        }

		private void ShowExtraKeyboardLayouts(object sender, EventArgs e)
		{
			string locale = CultureInfo.CurrentCulture.Name;
			List<string> extraKeyboardLayoutList = new List<string>();
			if (locale.Equals("zh-TW"))
				extraKeyboardLayoutList.AddRange(new string[] { "\u6a19\u6e96", "\u501a\u5929", "\u6f22\u8a9e\u62fc\u97f3", "\u501a\u5929 26 \u9375", "\u8a31\u6c0f\u9375\u76e4" });
			else if (locale.Equals("zh-CN"))
				extraKeyboardLayoutList.AddRange(new string[] { "\u6807\u51c6", "\u501a\u5929", "\u6c49\u8bed\u62fc\u97f3", "\u501a\u5929 26 \u952e", "\u8bb8\u6c0f\u952e\u76d8" });
			else
				extraKeyboardLayoutList.AddRange(new string[] { "Standard", "Eten", "Hanyu Pinyin", "Eten 26", "Hsu" });
			this.u_smartPhonetickeyboardLayoutComboBox.Items.Clear();
			this.u_smartPhonetickeyboardLayoutComboBox.Items.AddRange(extraKeyboardLayoutList.ToArray());
			this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndex = 0;
			this.u_smartPhonetickeyboardLayoutComboBox.Text = this.u_smartPhonetickeyboardLayoutComboBox.Items[0].ToString();

			this.u_traditionalPhoneticKeyboardLayoutComboBox.Items.Clear();
			this.u_traditionalPhoneticKeyboardLayoutComboBox.Items.AddRange(extraKeyboardLayoutList.ToArray());
			this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndex = 0;
			this.u_traditionalPhoneticKeyboardLayoutComboBox.Text = this.u_traditionalPhoneticKeyboardLayoutComboBox.Items[0].ToString();

		}


    }
}
