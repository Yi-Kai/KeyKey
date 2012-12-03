/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace TakaoPreference
{
    partial class PanelGeneric : UserControl
    {
        private string m_venderIdentifer;
        private Button u_applyButton;
        private string[] m_moduleNames;
        private string[] m_moduleXMLFilePaths;
        private Dictionary<string, string>[] m_moduleDictionaries;
        private Dictionary<string, string> m_genericInputMethods;

        public PanelGeneric(string venderIdentifer, Dictionary<string, string> genericInputMethods, Button button)
        {
            this.m_venderIdentifer = venderIdentifer;
            this.u_applyButton = button;
            this.m_genericInputMethods = genericInputMethods;
            InitializeComponent();
            this.LoadSettings();
        }

        private void LoadSettings()
        {
            this.m_moduleNames = new string[this.m_genericInputMethods.Count];
            this.m_moduleXMLFilePaths = new string[this.m_genericInputMethods.Count];
            this.m_moduleDictionaries = new Dictionary<string, string>[this.m_genericInputMethods.Count];

            int i = 0;
            foreach (KeyValuePair<string, string> kvp in m_genericInputMethods)
            {
                string cin = kvp.Key;

                this.m_moduleNames[i] = cin;
                this.m_moduleXMLFilePaths[i] = TakaoHelper.GetXMLFullPath(m_venderIdentifer + "." + cin + ".plist");
                this.m_moduleDictionaries[i] = TakaoHelper.DictionaryFromFile(m_moduleXMLFilePaths[i]);
                try
                {
                    // The default values;
                    this.m_moduleDictionaries[i].Add("MaximumRadicalLength", "20");
                    this.m_moduleDictionaries[i].Add("ShouldCommitAtMaximumRadicalLength", "false");
                    this.m_moduleDictionaries[i].Add("ClearReadingBufferAtCompositionError", "false");
                    this.m_moduleDictionaries[i].Add("MatchOneChar", "?");
                    this.m_moduleDictionaries[i].Add("MatchZeroOrMoreChar", "*");
                    this.m_moduleDictionaries[i].Add("UseDynamicFrequency", "false");
                }
                catch { }
                this.u_modulesListBox.Items.Add(kvp.Value);
                PanelGenericSettings setting = new PanelGenericSettings(cin, kvp.Value, m_moduleDictionaries[i], u_applyButton);
                this.AddPanel(setting, cin);
                i++;
            }
            this.u_modulesListBox.SelectedIndex = 0;
        }

        #region UI
        private void AddPanel(Control panel, string name)
        {
            Panel tp = new Panel();
            tp.Name = name;
            tp.Controls.Add(panel);
            this.u_settingsPanel.Controls.Add(tp);
            this.SetSize(panel);
        }
        private void SetSize(Control innerControl)
        {
            if (innerControl == null) return;
            innerControl.ClientSize = innerControl.PreferredSize;

            while (innerControl.Parent != null)
            {
                if (innerControl.Parent.ClientSize.Width
                        < innerControl.PreferredSize.Width
                    ||
                    innerControl.Parent.ClientSize.Height
                        < innerControl.PreferredSize.Height)
                {
                    innerControl.Parent.ClientSize = innerControl.PreferredSize;
                    innerControl.Parent.ClientSize = innerControl.Parent.PreferredSize;
                }

                innerControl = innerControl.Parent;
            }
        } 
        #endregion

        public void SaveSettings()
        {
            int i = 0;
            foreach (string cin in m_moduleNames)
            {
                TakaoHelper.DictionaryToFile(m_moduleDictionaries[i], m_moduleXMLFilePaths[i]);
                i++;
            }     
        }

        private void ToggleActiveModuleSettingPane(object sender, EventArgs e)
        {
            string selectedModule = m_moduleNames[u_modulesListBox.SelectedIndex];
            System.Windows.Forms.Control.ControlCollection c = this.u_settingsPanel.Controls;

            foreach (Control item in c)
            {
                if (item.Name == selectedModule)
                    item.Visible = true;
                else
                    item.Visible = false;
            }
        }
    }
}
