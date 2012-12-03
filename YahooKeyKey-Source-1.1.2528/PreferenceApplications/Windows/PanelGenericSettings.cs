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
    partial class PanelGenericSettings : UserControl
    {
        private Dictionary<string, string> m_genericDictionary;
        private Button u_applyButton;
        private string m_moduleName;
        private bool m_isLoading;

        public PanelGenericSettings(string moduleName, string localizedName, Dictionary<string, string> dictionary, Button button)
        {
            this.m_moduleName = moduleName;
            this.m_genericDictionary = dictionary;
            this.u_applyButton = button;
            InitializeComponent();
            this.u_labelTitle.Text = localizedName;
            this.SetUI();
        }

        private void SetUI()
        {
            this.m_isLoading = true;

            string buffer;

            this.m_genericDictionary.TryGetValue("MatchOneChar", out buffer);
			if (buffer != null)
            	this.u_textMatchOne.Text = buffer;

            this.m_genericDictionary.TryGetValue("MatchZeroOrMoreChar", out buffer);
			if (buffer != null)
	            this.u_textMatchMore.Text = buffer;
	
            this.m_genericDictionary.TryGetValue("MaximumRadicalLength", out buffer);
			if (buffer != null)
	            this.u_numericMax.Value = Convert.ToDecimal(buffer);

            this.m_genericDictionary.TryGetValue("ShouldCommitAtMaximumRadicalLength", out buffer);            
            if (buffer != null && buffer == "true")
                this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Checked = true;
            else
                this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Checked = false;
            
            this.m_genericDictionary.TryGetValue("ClearReadingBufferAtCompositionError", out buffer);
            if (buffer != null && buffer == "true")
                this.u_clearIfErrorCheckBox.Checked = true;
            else
                this.u_clearIfErrorCheckBox.Checked = false;

            this.m_genericDictionary.TryGetValue("ComposeWhileTyping", out buffer);
            if (buffer != null && buffer == "true")
                this.u_autoComposeCheckbox.Checked = true;
            else
                this.u_autoComposeCheckbox.Checked = false;
            
            this.m_genericDictionary.TryGetValue("UseDynamicFrequency", out buffer);
            if (buffer != null && buffer == "true")
                this.u_useDynamicFrequencyCheckBox.Checked = true;
            else
                this.u_useDynamicFrequencyCheckBox.Checked = false;
            
            this.m_genericDictionary.TryGetValue("UseSpaceAsFirstCandidateSelectionKey", out buffer);            
            if (buffer != null && buffer == "true")
                this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox.Checked = true;
            else
                this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox.Checked = false;

            this.m_isLoading = false;
        }

        private void ChangeSetting()
        {
            if (this.m_isLoading == true)
                return;

            try
            {
                this.m_genericDictionary.Remove("ShouldCommitAtMaximumRadicalLength");
            }
            catch { }

            if (this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Checked == true)
            
                this.m_genericDictionary.Add("ShouldCommitAtMaximumRadicalLength", "true");
            else
                this.m_genericDictionary.Add("ShouldCommitAtMaximumRadicalLength", "false");

            try
            {
                this.m_genericDictionary.Remove("ClearReadingBufferAtCompositionError");
            }
            catch { }

            if (this.u_clearIfErrorCheckBox.Checked == true)
                this.m_genericDictionary.Add("ClearReadingBufferAtCompositionError", "true");
            else
                this.m_genericDictionary.Add("ClearReadingBufferAtCompositionError", "false");

            try
            {
                this.m_genericDictionary.Remove("UseDynamicFrequency");
            }
            catch { }

            if (this.u_useDynamicFrequencyCheckBox.Checked == true)
                this.m_genericDictionary.Add("UseDynamicFrequency", "true");
            else
                this.m_genericDictionary.Add("UseDynamicFrequency", "false");

            try
            {
                this.m_genericDictionary.Remove("UseSpaceAsFirstCandidateSelectionKey");
            }
            catch { }

            if (this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox.Checked == true)
                this.m_genericDictionary.Add("UseSpaceAsFirstCandidateSelectionKey", "true");
            else
                this.m_genericDictionary.Add("UseSpaceAsFirstCandidateSelectionKey", "false");

            try
            {
                this.m_genericDictionary.Remove("ComposeWhileTyping");
            }
            catch { }

            if (this.u_autoComposeCheckbox.Checked == true)
                this.m_genericDictionary.Add("ComposeWhileTyping", "true");
            else
                this.m_genericDictionary.Add("ComposeWhileTyping", "false");

            try
            {
                this.m_genericDictionary.Remove("MatchOneChar");
            }
            catch { }

            this.m_genericDictionary.Add("MatchOneChar", u_textMatchOne.Text);

            try
            {
                this.m_genericDictionary.Remove("MatchZeroOrMoreChar");
            }
            catch { }
            this.m_genericDictionary.Add("MatchZeroOrMoreChar", u_textMatchMore.Text);

            try
            {
                this.m_genericDictionary.Remove("MaximumRadicalLength");
            }
            catch { }

            this.m_genericDictionary.Add("MaximumRadicalLength", this.u_numericMax.Value.ToString());
            this.u_applyButton.Enabled = true;
        }

        private void u_numericMax_ValueChanged(object sender, EventArgs e)
        {
            this.ChangeSetting();
        }

        #region Other private methods.
        private void u_shouldCommitAtMaximumRadicalLengthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSetting();
        }

        private void u_useDynamicFrequencyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSetting();
        }

        private void u_textMatchOne_TextChanged(object sender, EventArgs e)
        {
            this.ChangeSetting();
        }

        private void u_textMatchMore_TextChanged(object sender, EventArgs e)
        {
            this.ChangeSetting();
        }

        private void u_textMatchOne_MouseDown(object sender, MouseEventArgs e)
        {
            this.u_textMatchOne.SelectAll();
        }

        private void u_textMatchMore_MouseDown(object sender, MouseEventArgs e)
        {
            this.u_textMatchMore.SelectAll();
        }

        private void u_clearIfErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_isLoading == true)
                return;
            if (u_clearIfErrorCheckBox.Checked == true)
                this.u_autoComposeCheckbox.Checked = false;
            this.ChangeSetting();
        }

        private void u_autoComposeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_isLoading == true)
                return;
            if (u_autoComposeCheckbox.Checked == true)
                this.u_clearIfErrorCheckBox.Checked = false;
            this.ChangeSetting();
        }

        private void u_useSpaceAsFirstCandidateSelectionKeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSetting();
        } 
        #endregion
    }
}
