// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    public partial class BIStatusBarForm
    {
        /// <summary>
        /// Ask the status bar to reload all settings and reset the user
 		/// interface.
        /// </summary>
        public void Reload()
        {
			this.u_smartPhoneticToolStripMenuItem.Checked = false;
            this.u_terminateServerToolStripMenuItem.Checked = false;
            this.u_cangjieToolStripMenuItem.Checked = false;
            this.u_simplexToolStripMenuItem.Checked = false;

            this.u_toolStrip.Items.Clear();
            this.u_toolStrip.Items.AddRange(this.m_defaultToolStripItems);
            this.SetMiniModeByConfig();
            this.SetMiniModeTypeByConfig();
            this.InitUI();
        }

        #region Initialize User Interface
        /// <summary>
        /// Initialize User Interface
        /// </summary>
        private void InitUI()
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            Dictionary<string, string> extraInputMethods = new Dictionary<string, string>();
            Dictionary<string, string> outputFilters = new Dictionary<string, string>();
            Dictionary<string, string> aroundFilters = new Dictionary<string, string>();
            List<string> modulesSuppressedFromUI = new List<string>();

            string currentInputMethod = "";
            bool useFullWidth = true;
            bool useSimplifiedChinese = false;
            bool useEnglishKeyboard = false;

            if (callback != null)
            {
                currentInputMethod = callback.stringValueForLoaderConfigKey("PrimaryInputMethod");
                if (currentInputMethod.Length == 0)
                    currentInputMethod = callback.primaryInputMethod();

                useSimplifiedChinese = callback.isOutputFilterEnabled("ChineseCharacterConvertor-TC2SC");
                useFullWidth = callback.isFullWidthCharacterMode();
                extraInputMethods = callback.allInputMethodIdentifiersAndNames();
                outputFilters = callback.allOutputFilterIdentifiersAndNames();
                aroundFilters = callback.allAroundFilterIdentifiersAndNames();
                modulesSuppressedFromUI = callback.arrayValueForLoaderConfigKey("ModulesSuppressedFromUI");

                if (callback.isLoaderConfigKeyTrue("EnablesCapsLockAsAlphanumericModeToggle"))
                    this.u_toolStrip.Items.Remove(u_toggleAlphanumericMode);
            }

			// Load extra Input Method modules.
			
			this.u_toggleInputMethodDropDownMenu.Items.Clear();
            this.u_toggleInputMethodDropDownMenu.Items.AddRange(this.m_defualtInputMethodMenuItems);           

            if (modulesSuppressedFromUI.Contains("SmartMandarin"))
                this.u_toggleInputMethodDropDownMenu.Items.Remove(this.u_smartPhoneticToolStripMenuItem);                
            if (modulesSuppressedFromUI.Contains("TraditionalMandarins"))
                this.u_toggleInputMethodDropDownMenu.Items.Remove(this.u_traditionalPhoneticToolStripMenuItem);
            if (modulesSuppressedFromUI.Contains("Generic-cj-cin"))
                this.u_toggleInputMethodDropDownMenu.Items.Remove(this.u_cangjieToolStripMenuItem);
            if (modulesSuppressedFromUI.Contains("Generic-simplex-cin"))
                this.u_toggleInputMethodDropDownMenu.Items.Remove(this.u_simplexToolStripMenuItem);
			
            if (extraInputMethods.Count > 0)
            {
                ToolStrip tempStrip = new ToolStrip();
                ToolStripItem[] tempItems = new ToolStripItem[] { };
                ToolStripItemCollection genericInputMethodMenuItems = new ToolStripItemCollection(tempStrip, tempItems);

                foreach (KeyValuePair<string, string> genericInputMethod in extraInputMethods)
                {
                    string moduleID = genericInputMethod.Key;
                    string moduleName = genericInputMethod.Value;

					if (modulesSuppressedFromUI.Contains(moduleID))
					    continue;

                    System.Windows.Forms.ToolStripMenuItem newItem = new System.Windows.Forms.ToolStripMenuItem();

                    if (moduleID.Equals(currentInputMethod))
                        newItem.CheckState = CheckState.Checked;

                    newItem.AutoSize = true;
                    newItem.Image = global::BaseIMEUI.Properties.Resources.generic;
                    newItem.Name = moduleID;
                    newItem.Text = moduleName;
                    newItem.ToolTipText = moduleName;
                    newItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newItem.Click += new System.EventHandler(this.SelectInputMethod);
					genericInputMethodMenuItems.Add(newItem);
                }

                if (u_toggleInputMethodDropDownMenu.Items.Count > 0 && genericInputMethodMenuItems.Count > 0)
                    this.u_toggleInputMethodDropDownMenu.Items.Add(new ToolStripSeparator());
				if (genericInputMethodMenuItems.Count > 0)
                   this.u_toggleInputMethodDropDownMenu.Items.AddRange(genericInputMethodMenuItems);
                tempStrip.Dispose();
            }

			// Avoids that there is no input method in the menu.
			if (this.u_toggleInputMethodDropDownMenu.Items.Count == 0)
				this.u_toggleInputMethodDropDownMenu.Items.Add(this.u_smartPhoneticToolStripMenuItem);

            this.u_configsDropDownMenu.Items.Clear();

			// Loads Around Filters.
            if (aroundFilters.Count > 0)
            {
                foreach (KeyValuePair<string, string> aroundFilter in aroundFilters)
                {
                    string moduleID = aroundFilter.Key;
                    string moduleName = aroundFilter.Value;

					// Makes the search and evanuator module always enabled.
                    if (moduleID.Equals("OneKey") || moduleID.Equals("Evaluator"))
                    {
                        if (callback != null && !callback.isAroundFilterEnabled(moduleID))
                            callback.toggleAroundFilter(moduleID);
                        continue;
                    }
					// Leaves the ReverseLookup Modules hidden.
                    if (moduleID.StartsWith("ReverseLookup"))
                    {						
                        continue;
                    }

                    System.Windows.Forms.ToolStripMenuItem newItem = new System.Windows.Forms.ToolStripMenuItem();
                    newItem.AutoSize = true;
                    if (callback != null && callback.isAroundFilterEnabled(moduleID) == true)
                    {
                        newItem.Image = global::BaseIMEUI.Properties.Resources.menuCheck;
                        newItem.Checked = true;
                    }
                    else
                    {
                        newItem.Image = global::BaseIMEUI.Properties.Resources.menuUncheck;
                        newItem.Checked = false;
                    }
                    newItem.Name = moduleID;
                    newItem.Text = moduleName;
                    newItem.ToolTipText = moduleName;
                    newItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newItem.Click += new System.EventHandler(this.aroundFilterToolStripMenuItem_Click);
                    this.u_configsDropDownMenu.Items.Add(newItem);
                }
                this.u_configsDropDownMenu.Items.Add(new ToolStripSeparator());
            }

			// Load Output Filters.

            if (outputFilters.Count > 0)
            {
                foreach (KeyValuePair<string, string> outputFilter in outputFilters)
                {
                    string ID = outputFilter.Key;
                    string Name = outputFilter.Value;

                    System.Windows.Forms.ToolStripMenuItem newItem = new System.Windows.Forms.ToolStripMenuItem();
                    newItem.AutoSize = true;
                    if (callback != null && callback.isOutputFilterEnabled(ID) == true)
                    {
                        newItem.Image = global::BaseIMEUI.Properties.Resources.menuCheck;
                        newItem.Checked = true;
                    }
                    else
                    {
                        newItem.Image = global::BaseIMEUI.Properties.Resources.menuUncheck;
                        newItem.Checked = false;
                    }
                    newItem.Name = ID;
                    newItem.Text = Name;
                    newItem.ToolTipText = Name;
                    newItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    newItem.Click += new System.EventHandler(this.outputFilterToolStripMenuItem_Click);
                    u_configsDropDownMenu.Items.Add(newItem);
                }
                this.u_configsDropDownMenu.Items.Add(new ToolStripSeparator());
            }

            this.u_configsDropDownMenu.Items.AddRange(this.m_defualtConfigItems);

            #region Init the default input method

            ToolStripMenuItem targetItem = null;
			bool found = false;
            foreach (object item in this.u_toggleInputMethodDropDownMenu.Items)
			{
                if (item is ToolStripMenuItem)
				{
                    ToolStripMenuItem currentItem = (ToolStripMenuItem)item;
                    if (currentItem.Name.Equals(currentInputMethod)) 
					{
						found = true;
                        targetItem = currentItem;
						break;
					}
				}
			}

			if (!found) 
	            targetItem = (ToolStripMenuItem)this.u_toggleInputMethodDropDownMenu.Items[0];

			if (targetItem != null)
			{
				this.u_toggleInputMethod.Image = targetItem.Image;
	            this.u_toggleInputMethod.Text = targetItem.Text;
                if (callback != null)
	                callback.setPrimaryInputMethod(targetItem.Name, false);
	            targetItem.CheckState = CheckState.Checked;
			}

            #endregion

            if (useEnglishKeyboard == true)
                this.u_toggleAlphanumericMode.Image = global::BaseIMEUI.Properties.Resources.english;
            else
                this.u_toggleAlphanumericMode.Image = global::BaseIMEUI.Properties.Resources.chinese;

            if (useFullWidth == true)
                this.u_toggleFullWidthCharacterMode.Image = global::BaseIMEUI.Properties.Resources.fullwidth;
            else
                this.u_toggleFullWidthCharacterMode.Image = global::BaseIMEUI.Properties.Resources.halfwidth;

            if (useSimplifiedChinese == true)
                this.u_toggleChineseCharacterConverter.Image = global::BaseIMEUI.Properties.Resources.zh_CN;
            else
                this.u_toggleChineseCharacterConverter.Image = global::BaseIMEUI.Properties.Resources.zh_TW;
        }
        #endregion
    }
}
