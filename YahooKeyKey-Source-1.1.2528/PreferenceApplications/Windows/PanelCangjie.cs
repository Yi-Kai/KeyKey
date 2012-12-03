/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TakaoPreference
{
    partial class PanelCangjie : UserControl
    {
        private Dictionary<string, string> m_cangjieDictionary;
        private Button u_applyButton;
        private bool m_isloading;
        public PanelCangjie(Dictionary<string, string> dictionary, Button button)
        {
            InitializeComponent();
            this.m_cangjieDictionary = dictionary;
            this.u_applyButton = button;
            this.InitUI();
        }
        #region Init
        /// <summary>
        /// Initializing the user interface for Cangjie input method settings.
        /// </summary>
        private void InitUI()
        {
            this.m_isloading = true;

            string buffer;

            this.m_cangjieDictionary.TryGetValue("ShouldCommitAtMaximumRadicalLength", out buffer);
            if (buffer == "true")
                this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Checked = true;
            else
                this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Checked = false;

            this.m_cangjieDictionary.TryGetValue("UseDynamicFrequency", out buffer);
            if (buffer == "true")
                this.u_useDynamicFrequencyCheckBox.Checked = true;
            else
                this.u_useDynamicFrequencyCheckBox.Checked = false;

            this.m_cangjieDictionary.TryGetValue("ClearReadingBufferAtCompositionError", out buffer);
            if (buffer == "true")
                this.u_clearIfErrorCheckBox.Checked = true;
            else
                this.u_clearIfErrorCheckBox.Checked = false;

            this.m_cangjieDictionary.TryGetValue("ComposeWhileTyping", out buffer);
            if (buffer == "true")
                this.u_autoComposeCheckbox.Checked = true;
            else
                this.u_autoComposeCheckbox.Checked = false;

            this.m_cangjieDictionary.TryGetValue("UseCharactersSupportedByEncoding", out buffer);
            if (buffer == "")
                this.u_nonBig5CheckBox.Checked = true;
            else
                this.u_nonBig5CheckBox.Checked = false;

            this.m_cangjieDictionary.TryGetValue("UseOverrideTable", out buffer);
            if (buffer == "")
                this.u_radioFull.Checked = true;
            else if (buffer == "Punctuations-cj-mixedwidth-cin")
                this.u_radioMix.Checked = true;
            else if (buffer == "Punctuations-cj-halfwidth-cin")
                this.u_radioHalf.Checked = true;
            else
                this.u_radioFull.Checked = true;

            this.m_isloading = false; ;
        } 
        #endregion

        #region Event handlers
        private void u_shouldCommitAtMaximumRadicalLengthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_cangjieDictionary.Remove("ShouldCommitAtMaximumRadicalLength");
            }
            catch { }

            if (this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Checked == true)
                this.m_cangjieDictionary.Add("ShouldCommitAtMaximumRadicalLength", "true");
            else
                this.m_cangjieDictionary.Add("ShouldCommitAtMaximumRadicalLength", "false");

            this.u_applyButton.Enabled = true;
        }


        /// <summary>
        /// Handle enabling or disabling the ShouldCommitAsPhrase option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toggleUseDynamicFrequency(object sender, EventArgs e)
        {
            try
            {
                this.m_cangjieDictionary.Remove("UseDynamicFrequency");
            }
            catch{ }

            if (this.u_useDynamicFrequencyCheckBox.Checked == true)
                this.m_cangjieDictionary.Add("UseDynamicFrequency", "true");
            else
                this.m_cangjieDictionary.Add("UseDynamicFrequency", "false");
            this.u_applyButton.Enabled = true;
        }
        private void ToggleClearRadicalsIfError(object sender, EventArgs e)
        {
            try
            {
                this.m_cangjieDictionary.Remove("ClearReadingBufferAtCompositionError");
            }
            catch { }
            if (this.u_clearIfErrorCheckBox.Checked == true)
            {
                this.m_cangjieDictionary.Add("ClearReadingBufferAtCompositionError", "true");
                if (this.u_autoComposeCheckbox.Checked == true)
                {
                    this.u_autoComposeCheckbox.Checked = false;
                    this.toggleComposeWhenTyping(sender, e);
                }
            }
            else
            {
                this.m_cangjieDictionary.Add("ClearReadingBufferAtCompositionError", "false");
            }
            this.u_applyButton.Enabled = true;
        }

        private void toggleComposeWhenTyping(object sender, EventArgs e)
        {
            try
            {
                this.m_cangjieDictionary.Remove("ComposeWhileTyping");
            }
            catch { }
            if (this.u_autoComposeCheckbox.Checked == true)
            {
                this.m_cangjieDictionary.Add("ComposeWhileTyping", "true");
                if (this.u_clearIfErrorCheckBox.Checked == true)
                {
                    this.u_clearIfErrorCheckBox.Checked = false;
                    this.ToggleClearRadicalsIfError(sender, e);
                }
            }
            else
            {
                this.m_cangjieDictionary.Add("ComposeWhileTyping", "false");
            }
            this.u_applyButton.Enabled = true;
        }
        private void ToggleShouldUseAllUnicodePlanes(object sender, EventArgs e)
        {
            try
            {
                this.m_cangjieDictionary.Remove("UseCharactersSupportedByEncoding");
            }
            catch { }
            if (this.u_nonBig5CheckBox.Checked == true)
                this.m_cangjieDictionary.Add("UseCharactersSupportedByEncoding", "");
            else
                this.m_cangjieDictionary.Add("UseCharactersSupportedByEncoding", "BIG-5");

            this.u_applyButton.Enabled = true;
        } 
        #endregion

        private void u_toogleOverrideTable(object sender, EventArgs e)
        {
            if (this.m_isloading == true)
                return;

            try
            {
                this.m_cangjieDictionary.Remove("UseOverrideTable");
            }
            catch { }

            if (this.u_radioFull.Checked == true)
                this.m_cangjieDictionary.Add("UseOverrideTable", "");
            else if (this.u_radioMix.Checked == true)
                this.m_cangjieDictionary.Add("UseOverrideTable", "Punctuations-cj-mixedwidth-cin");
            else if (this.u_radioHalf.Checked == true)
                this.m_cangjieDictionary.Add("UseOverrideTable", "Punctuations-cj-halfwidth-cin");

            this.u_applyButton.Enabled = true;
        }

    }
}
