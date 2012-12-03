/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Resources;
using BaseIMEUI;

namespace TakaoPreference
{
    /// <summary>
    /// The main class od the Preference tool.
    /// </summary>
    public partial class TakaoPreference : Form
    {
        public static int InstanceCount = 0;

        #region Member Variables

        private string m_venderIdentifer = TakaoHelper.VenderIdentifer;
        private static string m_generalXMLpath = TakaoHelper.GeneralXMLpath;
        private static string m_traditionalPhoneticXMLpath = TakaoHelper.TraditionalPhoneticXMLpath;
        private static string m_smartPhoneticXMLpath = TakaoHelper.SmartPhoneticXMLpath;
        private static string m_cangjieXMLpath = TakaoHelper.CangjieXMLpath;
        private static string m_simplexXMLpath = TakaoHelper.SimplexXMLpath;
		private static string m_oneKeyXMLpath = TakaoHelper.OneKeyXMLpath;

        private Dictionary<string, string> m_generalDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> m_traditionalPhoneticDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> m_smartPhoneticDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> m_cangjieDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> m_simplexDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> m_searchDictionary = new Dictionary<string, string>();
        
        private Color toolbarButtonBackgroundColor;

        private bool m_hasGenericInputMethods;
        private Dictionary<string, string> m_genericInputMethods;
        private bool m_isLoading;

        private PanelGeneral u_panelGeneral;
        private PanelGeneric u_panelGeneric;
        private BIAboutPanel u_panelAbout;


        #endregion
        /// <summary>
        /// The constructor of the TakaoPrefence class.
        /// </summary>
        /// <param name="genericIMs">
        /// The Dictionary object which contains the informations of extra table-based input
        /// methods from the OpenVanilla Genetic Input Method module.
        /// </param>
        public TakaoPreference(Dictionary<string, string> genericInputMethods)
        {
            TakaoPreference.InstanceCount++;

            InitializeComponent();
            this.m_genericInputMethods = genericInputMethods;
            if (m_genericInputMethods.Count > 0)
                m_hasGenericInputMethods = true;
            this.LoadSettings();
            this.InitUI();
            this.SaveSettings();
            this.Focus();
            this.FormClosed += new FormClosedEventHandler(TakaoPreference_FormClosed);
            this.u_toolbar.Paint += new PaintEventHandler(u_toolbar_Paint);
        }

        void u_toolbar_Paint(object sender, PaintEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            Graphics g = e.Graphics;
            Rectangle toolBarRect = new Rectangle(this.u_toolbar.Location, this.u_toolbar.Size);
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(toolBarRect.Left, toolBarRect.Top),
                new Point(toolBarRect.Left, toolBarRect.Bottom),
                Color.LightGray, Color.White);
            g.FillRectangle(lgb, toolBarRect);
            lgb.Dispose();
        }

        #region Initializing User Interface
        private void InitUI()
        {
            toolbarButtonBackgroundColor = Color.Transparent;
            this.u_panelGeneral = new PanelGeneral(this.m_generalDictionary, this.m_searchDictionary, this.m_genericInputMethods, this.u_applyButton);
            this.AddPreferencePane(u_panelGeneral, "General");
            PanelPhonetic panelPhonetic = new PanelPhonetic(this.m_traditionalPhoneticDictionary, this.m_smartPhoneticDictionary, this.u_applyButton);
            this.AddPreferencePane(panelPhonetic, "Phonetic");
            PanelCangjie panelCangjie = new PanelCangjie(this.m_cangjieDictionary, this.u_applyButton);
            this.AddPreferencePane(panelCangjie, "Cangjie");
            PanelSimplex panelSimplex = new PanelSimplex(this.m_simplexDictionary, this.u_applyButton);
            this.AddPreferencePane(panelSimplex, "Simplex");
            if (this.m_hasGenericInputMethods == false)
            {
                this.u_toolbarGeneric.Visible = false;
                this.u_toolbar.Controls.Remove(this.u_toolbarGeneric);
                this.u_settingsPanel.Left = 43;
                this.u_toolbar.Width = this.u_toolbar.Width - 56;
                this.Width = this.Width - 56;
            }
            else
            {
                this.u_panelGeneric = new PanelGeneric(m_venderIdentifer, m_genericInputMethods, u_applyButton);
                this.AddPreferencePane(u_panelGeneric, "Generic");
            }
            PanelMisc panelMisc = new PanelMisc(m_generalDictionary, u_applyButton);
            this.AddPreferencePane(panelMisc, "Misc");
            PanelPhrases panelPhrases = new PanelPhrases();
            this.AddPreferencePane(panelPhrases, "Phrases");
            PanelUpdate panelUpdate = new PanelUpdate(m_generalDictionary, u_applyButton);
            this.AddPreferencePane(panelUpdate, "Update");

            BIAboutPanel.c_icon = global::TakaoPreference.Properties.Resources.yahoo;
            this.u_panelAbout = new BIAboutPanel(this);
            this.AddPreferencePane(u_panelAbout, "About");
            this.u_toolbarGeneral.Checked = true;
            this.u_toolbarGeneral.BackColor = toolbarButtonBackgroundColor;
            this.u_applyButton.Enabled = false;

            System.Windows.Forms.Control.ControlCollection c = this.u_settingsPanel.Controls;
            int i = 0;
            foreach (Control item in c)
            {
                if (i == 0)
                    item.Visible = true;
                else
                    item.Visible = false;
                i++;
            }

        }
        /// <summary>
        /// Try to add a value into a dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void TryAddValueInDictionary(Dictionary<string, string> dictionary, string key, string value)
        {
            try
            {
                dictionary.Add(key, value);
            }
            catch { }
        }
        /// <summary>
        /// Initializing configurations from saved XML files.
        /// </summary>
        private void LoadSettings()
        {
            #region Loading properties
            // Load the settings from the XML files into Dictionary objects.
            this.m_generalDictionary = TakaoHelper.DictionaryFromFile(m_generalXMLpath);
            this.m_traditionalPhoneticDictionary = TakaoHelper.DictionaryFromFile(m_traditionalPhoneticXMLpath);
            this.m_smartPhoneticDictionary = TakaoHelper.DictionaryFromFile(m_smartPhoneticXMLpath);
            this.m_cangjieDictionary = TakaoHelper.DictionaryFromFile(m_cangjieXMLpath);
            this.m_simplexDictionary = TakaoHelper.DictionaryFromFile(m_simplexXMLpath);
			this.m_searchDictionary = TakaoHelper.DictionaryFromFile(m_oneKeyXMLpath);

            // If some important settings do not exist in the XML files, we add them here with the default value.
            try
            {
                // The default general settings
                this.TryAddValueInDictionary(this.m_generalDictionary, "ShouldUseNotifyWindow", "true");
                this.TryAddValueInDictionary(this.m_generalDictionary, "ShouldUseTransparentStatusBar", "false");
                this.TryAddValueInDictionary(this.m_generalDictionary, "ShouldPlaySoundOnTypingError", "true");
                this.TryAddValueInDictionary(this.m_generalDictionary, "SoundFilename", "Default");
                this.TryAddValueInDictionary(this.m_generalDictionary, "ShouldCheckUpdateOnLaunch", "true");
                this.TryAddValueInDictionary(this.m_generalDictionary, "IgnoreShiftAsAlphanumericModeToggleKey", "false");
                this.TryAddValueInDictionary(this.m_generalDictionary, "EnablesCapsLockAsAlphanumericModeToggle", "false");
                this.TryAddValueInDictionary(this.m_generalDictionary, "ToggleInputMethodWithControlBackslash", "true");
                this.TryAddValueInDictionary(this.m_generalDictionary, "HighlightColor", "Purple");
                this.TryAddValueInDictionary(this.m_generalDictionary, "BackgroundColor", "Black");
                this.TryAddValueInDictionary(this.m_generalDictionary, "TextColor", "White");
                this.TryAddValueInDictionary(this.m_generalDictionary, "BackgroundPattern", "false");
                this.TryAddValueInDictionary(this.m_generalDictionary, "ShouldUseSystemTray", "false");
                this.TryAddValueInDictionary(this.m_generalDictionary, "ChineseConverterToggleKey", "s");
                this.TryAddValueInDictionary(this.m_generalDictionary, "RepeatLastCommitTextKey", "g");
                this.TryAddValueInDictionary(this.m_generalDictionary, "KeyboardFormShouldFollowCursor", "false");

                this.TryAddValueInDictionary(this.m_generalDictionary, "ModulesSuppressedFromUI", "ARRAY:");

                // The default settings for the Traditional Phonetic Input Method
                this.TryAddValueInDictionary(this.m_traditionalPhoneticDictionary, "KeyboardLayout", "Standard");
                this.TryAddValueInDictionary(this.m_traditionalPhoneticDictionary, "UseCharactersSupportedByEncoding", "");

                // The default settings for the Smart Phonetic Input Method
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "KeyboardLayout", "Standard");
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "UseCharactersSupportedByEncoding", "");
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "ClearComposingTextWithEsc", "false");
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "ShowCandidateListWithSpace", "false");
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "UseCharactersSupportedByEncoding", "");
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "CandidateCursorAtEndOfTargetBlock", "false");
                this.TryAddValueInDictionary(this.m_smartPhoneticDictionary, "ComposingTextBufferSize", "10");

                // The default settings for CangJie Input Method
                this.TryAddValueInDictionary(this.m_cangjieDictionary, "ShouldCommitAtMaximumRadicalLength", "false");
                this.TryAddValueInDictionary(this.m_cangjieDictionary, "UseDynamicFrequency", "false");
                this.TryAddValueInDictionary(this.m_cangjieDictionary, "ClearReadingBufferAtCompositionError", "true");
                this.TryAddValueInDictionary(this.m_cangjieDictionary, "ComposeWhileTyping", "false");
                this.TryAddValueInDictionary(this.m_cangjieDictionary, "UseOverrideTable", "Punctuations-punctuations-cin");
                this.TryAddValueInDictionary(this.m_cangjieDictionary, "UseCharactersSupportedByEncoding", "");

                // The default settings for Simplex Input Method
                this.TryAddValueInDictionary(this.m_simplexDictionary, "ClearReadingBufferAtCompositionError", "true");
                this.TryAddValueInDictionary(this.m_simplexDictionary, "ComposeWhileTyping", "false");
                this.TryAddValueInDictionary(this.m_simplexDictionary, "UseCharactersSupportedByEncoding", "");

                this.TryAddValueInDictionary(this.m_searchDictionary, "ShortcutKey", "`");
            }
            catch (ArgumentException)
            {
                // @zonble
                // If some keys are already there, the Add() method will raise exceptions.
                // However, we ignore these exceptions.
            }

            #endregion
        }
        #endregion
        #region General functions
        private void AddPreferencePane(Control preferencePane, string nameOfPreferencePane)
        {
            Panel panel = new Panel();
            panel.Name = nameOfPreferencePane;
            panel.Controls.Add(preferencePane);
            this.u_settingsPanel.Controls.Add(panel);
            this.SetPreferencePaneToFit(preferencePane);
        }
        private void SetPreferencePaneToFit(Control preferencePane)
        {
            if (preferencePane == null) return;
            preferencePane.ClientSize = preferencePane.PreferredSize;

            while (preferencePane.Parent != null)
            {
                if (preferencePane.Parent.ClientSize.Width < preferencePane.PreferredSize.Width || preferencePane.Parent.ClientSize.Height < preferencePane.PreferredSize.Height)
                {
                    preferencePane.Parent.ClientSize = preferencePane.PreferredSize;
                    preferencePane.Parent.ClientSize = preferencePane.Parent.PreferredSize;
                }

                preferencePane = preferencePane.Parent;
            }
        }

        /// <summary>
        /// Write preference into XML files.
        /// </summary>
        private void SaveSettings()
        {
            #region Avoid keykey.plist changes by UI during setting preference.
            Dictionary<string, string> currenGeneralDictionary = TakaoHelper.DictionaryFromFile(m_generalXMLpath);
            if (currenGeneralDictionary.Count >0)
            {
                string ActivatedAroundFiltersStirng;
                currenGeneralDictionary.TryGetValue("ActivatedAroundFilters", out ActivatedAroundFiltersStirng);
                try
                {
                    if (ActivatedAroundFiltersStirng == null || ActivatedAroundFiltersStirng.Length == 0)
                    {
                        ActivatedAroundFiltersStirng = "ARRAY:";
                    }
                    else
                    {
                        string stringToExplode = ActivatedAroundFiltersStirng.Remove(0, 6);
                        string[] aroundFilters = stringToExplode.Split(", ".ToCharArray());
                        ActivatedAroundFiltersStirng = "ARRAY:";
                        int count = 0;
                        foreach (string aroundFilter in aroundFilters)
                        {
                            if (aroundFilter.StartsWith("ReverseLookup-"))
                                continue;
                            ActivatedAroundFiltersStirng += aroundFilter;
                            if (count < aroundFilters.Length - 1)
                                ActivatedAroundFiltersStirng += ", ";
                            count++;
                        }
                    }
                }
                catch { }

                try
                {
                    // If lookup is enabled;
                    if (this.u_panelGeneral.ReverseLookupMethod.Length > 0)
                    {
                        if (ActivatedAroundFiltersStirng == "ARRAY:")
                            ActivatedAroundFiltersStirng = "ARRAY:" + this.u_panelGeneral.ReverseLookupMethod;
                        else
                            ActivatedAroundFiltersStirng += ", " + this.u_panelGeneral.ReverseLookupMethod;
                    }
                }
                catch { }

                string ActivatedOutputFiltersString;
                currenGeneralDictionary.TryGetValue("ActivatedOutputFilters", out ActivatedOutputFiltersString);
                try
                {
                    if (ActivatedOutputFiltersString == null || ActivatedOutputFiltersString.Length == 0)
                        ActivatedOutputFiltersString = "ARRAY:";
                }
                catch { }
                string PrimaryInputMethod;
                currenGeneralDictionary.TryGetValue("PrimaryInputMethod", out PrimaryInputMethod);
                try
                {
                    m_generalDictionary.Remove("ActivatedAroundFilters");
                    m_generalDictionary.Remove("ActivatedOutputFilters");
                    m_generalDictionary.Remove("PrimaryInputMethod");
                    m_generalDictionary.Add("ActivatedAroundFilters", ActivatedAroundFiltersStirng);
                    m_generalDictionary.Add("ActivatedOutputFilters", ActivatedOutputFiltersString);
                    m_generalDictionary.Add("PrimaryInputMethod", PrimaryInputMethod);
                }
                catch { }
            } 
            #endregion

            TakaoHelper.DictionaryToFile(m_generalDictionary, m_generalXMLpath);
            TakaoHelper.DictionaryToFile(m_traditionalPhoneticDictionary, m_traditionalPhoneticXMLpath);
            TakaoHelper.DictionaryToFile(m_smartPhoneticDictionary, m_smartPhoneticXMLpath);
            TakaoHelper.DictionaryToFile(m_cangjieDictionary, m_cangjieXMLpath);
            TakaoHelper.DictionaryToFile(m_simplexDictionary, m_simplexXMLpath);
			TakaoHelper.DictionaryToFile(m_searchDictionary, m_oneKeyXMLpath);
            if (this.m_hasGenericInputMethods)
            {
                this.u_panelGeneric.SaveSettings();
            }
        }
        #endregion
        #region Event Handlers
        void TakaoPreference_FormClosed(object sender, FormClosedEventArgs e)
        {
            TakaoPreference.InstanceCount--;
        }
        /// <summary>
        /// Handle the click event on the u_cancelButton button to close the preference utility.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handle the click event on the u_saveButton button to write preference into XML files and close the preference utility.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_saveButton_Click(object sender, EventArgs e)
        {
            this.SaveSettings();

            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback != null)
                callback.syncLoaderAndCurrentModuleConfig();

            this.Close();
        }
        /// <summary>
        /// handle the click event on the u_applyButton button to writer preference into XML files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_applyButton_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
            u_applyButton.Enabled = false;

            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback != null)
                callback.syncLoaderAndCurrentModuleConfig();
        }

        /// <summary>
        /// Handle the event to switch to another preference pane.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeTab(object sender, MouseEventArgs e)
        {
            string selectedOption = "";
            try
            {
                u_toolbarGeneral.Checked = false;
                u_toolbarPhonetic.Checked = false;
                u_toolbarCanjie.Checked = false;
                u_toolbarSimplex.Checked = false;
                u_toolbarPhrases.Checked = false;
                u_toolbarMisc.Checked = false;
                u_toolbarUpdate.Checked = false;
                u_toolbarAbout.Checked = false;

                u_toolbarGeneral.BackColor = u_toolbar.BackColor;
                u_toolbarPhonetic.BackColor = u_toolbar.BackColor;
                u_toolbarCanjie.BackColor = u_toolbar.BackColor;
                u_toolbarSimplex.BackColor = u_toolbar.BackColor;
                u_toolbarPhrases.BackColor = u_toolbar.BackColor;
                u_toolbarMisc.BackColor = u_toolbar.BackColor;
                u_toolbarUpdate.BackColor = u_toolbar.BackColor;
                u_toolbarAbout.BackColor = u_toolbar.BackColor;

                if (m_hasGenericInputMethods)
                {
                    u_toolbarGeneric.Checked = false;
                    u_toolbarGeneric.BackColor = u_toolbar.BackColor;
                }
            }
            catch
            {
            }

            if (sender == u_toolbarGeneral)
            {
                selectedOption = "General";
                u_toolbarGeneral.Checked = true;
                u_toolbarGeneral.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarPhonetic)
            {
                selectedOption = "Phonetic";
                u_toolbarPhonetic.Checked = true;
                u_toolbarPhonetic.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarCanjie)
            {
                selectedOption = "Cangjie";
                u_toolbarCanjie.Checked = true; //
                u_toolbarCanjie.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarSimplex)
            {
                selectedOption = "Simplex";
                u_toolbarSimplex.Checked = true;
                u_toolbarSimplex.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarGeneric)
            {
                selectedOption = "Generic";
                u_toolbarGeneric.Checked = true;
                u_toolbarGeneric.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarPhrases)
            {
                selectedOption = "Phrases";
                u_toolbarPhrases.Checked = true;
                u_toolbarPhrases.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarMisc)
            {
                selectedOption = "Misc";
                u_toolbarMisc.Checked = true;
                u_toolbarMisc.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarUpdate)
            {
                selectedOption = "Update";
                u_toolbarUpdate.Checked = true;
                u_toolbarUpdate.BackColor = toolbarButtonBackgroundColor;
            }
            else if (sender == u_toolbarAbout)
            {
                selectedOption = "About";
                u_toolbarAbout.Checked = true;
                u_toolbarAbout.BackColor = toolbarButtonBackgroundColor;
            }
            else
            {
                selectedOption = "General";
                u_toolbarGeneral.Checked = true;
                u_toolbarGeneral.BackColor = toolbarButtonBackgroundColor;
            }

            System.Windows.Forms.Control.ControlCollection c = this.u_settingsPanel.Controls;

            foreach (Control item in c)
            {
                if (item.Name == selectedOption)
                {
                    item.Visible = true;
                    if (item is BIAboutPanel)
                    {
                        BIAboutPanel aboutPanel = (BIAboutPanel)item;
                        aboutPanel.UpdateVersionInfo();
                        aboutPanel.UpdateWordCount();
                    }
                }
                else
                {
                    item.Visible = false;
                }
            }
        }
        #endregion

        private void ToolbarButtonsCheckedChanged(object sender, EventArgs e)
        {
            if (this.m_isLoading == true)
                return;
            this.m_isLoading = true;
            this.ChangeTab(sender, null);
            this.m_isLoading = false;
        }
    }
}
