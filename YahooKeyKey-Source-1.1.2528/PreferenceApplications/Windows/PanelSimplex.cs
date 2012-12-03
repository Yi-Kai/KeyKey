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
    partial class PanelSimplex : UserControl
    {
        private Dictionary<string, string> m_simplexDictionary;
        private Button u_applyButton;
        public PanelSimplex(Dictionary<string, string> dictionary, Button button)
        {
            InitializeComponent();
            this.m_simplexDictionary = dictionary;
            this.u_applyButton = button;
            this.InitUI();
        }
        #region Init
        /// <summary>
        /// Initializing the user interface for Cangjie input method settings.
        /// </summary>
        private void InitUI()
        {
            string buffer;
            this.m_simplexDictionary.TryGetValue("ClearReadingBufferAtCompositionError", out buffer);
            if (buffer == "true")
                this.u_clearIfErrorCheckBox.Checked = true;
            else
                this.u_clearIfErrorCheckBox.Checked = false;

            this.m_simplexDictionary.TryGetValue("ComposeWhenTyping", out buffer);
            if (buffer == "true")
                this.u_autoComposeCheckbox.Checked = true;
            else
                this.u_autoComposeCheckbox.Checked = false;

            this.m_simplexDictionary.TryGetValue("UseCharactersSupportedByEncoding", out buffer);
            if (buffer == "")
                this.u_nonBig5CheckBox.Checked = true;
            else
                this.u_nonBig5CheckBox.Checked = false;
        } 
        #endregion
        #region Event handlers

        /// <summary>
        /// Handle enabling or disabling the ShouldCommitAsPhrase option.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ToggleClearRadicalsIfError(object sender, EventArgs e)
        {
            try
			{
				
                this.m_simplexDictionary.Remove("ClearReadingBufferAtCompositionError");
			}
            catch { }

            if (this.u_clearIfErrorCheckBox.Checked == true)
            {
                this.m_simplexDictionary.Add("ClearReadingBufferAtCompositionError", "true");
                if (this.u_autoComposeCheckbox.Checked == true)
                {
                    this.u_autoComposeCheckbox.Checked = false;
                    this.ToggleAutoComposeWhenTyping(sender, e);
                }
            }
            else
            {
                this.m_simplexDictionary.Add("ClearReadingBufferAtCompositionError", "false");
            }
            this.u_applyButton.Enabled = true;
        }

        private void ToggleAutoComposeWhenTyping(object sender, EventArgs e)
        {
            try
            {
                this.m_simplexDictionary.Remove("ComposeWhenTyping");
            }
            catch { }

            if (this.u_autoComposeCheckbox.Checked == true)
            {
                this.m_simplexDictionary.Add("ComposeWhenTyping", "true");
                if (u_clearIfErrorCheckBox.Checked == true)
                {
                    this.u_clearIfErrorCheckBox.Checked = false;
                    this.ToggleClearRadicalsIfError(sender, e);
                }
            }
            else
            {
                this.m_simplexDictionary.Add("ComposeWhenTyping", "false");
            }
            this.u_applyButton.Enabled = true;
        }

        private void ToggleShouldUseAllUnicodePlanes(object sender, EventArgs e)
        {
            try
            {
                this.m_simplexDictionary.Remove("UseCharactersSupportedByEncoding");
            }
            catch { }

            if (this.u_nonBig5CheckBox.Checked == true)
                this.m_simplexDictionary.Add("UseCharactersSupportedByEncoding", "");
            else
                this.m_simplexDictionary.Add("UseCharactersSupportedByEncoding", "BIG-5");

            this.u_applyButton.Enabled = true;
        } 
        #endregion
    }
}
