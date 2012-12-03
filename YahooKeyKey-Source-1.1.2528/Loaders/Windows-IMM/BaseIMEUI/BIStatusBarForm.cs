//
// BIStatusBarForm.cs
//
// Distribution-specific code for the Takao Project
//
// The Takao Project
//
// Copyright (c) 2007-2008 Yahoo Taiwan Inc.
//
// Developed by Lithoglyph Inc. (http://lithoglyph.com)
//
// Part of the code is originally written by Lukhnos D. Liu and Weizhong Yang,
// Licensed to Yahoo Taiwan Inc. for use in the Takao Project.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace BaseIMEUI
{
    public partial class BIStatusBarForm : BIForm
    {
        #region Class members
        public static bool c_CheckUpdateOnStartUp = true;
        #endregion

        #region Instance members
        private Bitmap m_barhead;
        private Bitmap m_bartail;

        private Image m_imageChinese = global::BaseIMEUI.Properties.Resources.chinese;
        private Image m_imageEnglish = global::BaseIMEUI.Properties.Resources.english;
        private Image m_imageHalfWidth = global::BaseIMEUI.Properties.Resources.halfwidth;
        private Image m_imageZhCN = global::BaseIMEUI.Properties.Resources.zh_CN;
        private Image m_imageZhTW = global::BaseIMEUI.Properties.Resources.zh_TW;
        private Image m_imageFullWidth = global::BaseIMEUI.Properties.Resources.fullwidth;

        private bool m_isUsingSystemTrayMode = false;
        private bool m_shouldDisplay = false;
        private bool m_dictionaryFormShouldDisplay = false;
        private bool m_isInputMethodDropDownOpened = false;
        private bool m_isLocationInitialized = false;
        private bool m_isMiniMode = false;
        private bool m_keyboardFormShouldDisplay = false;
        private bool m_symbolFormShouldDisplay = false;

        private Rectangle m_windowRect;

        // forms
        private BIAboutForm u_aboutForm;
        private BIDictionaryForm u_dictionaryForm;
        private BIKeyboardForm u_keyboardForm;
        private BISymbolForm u_symbolForm;

        private ToolStripItemCollection m_defaultToolStripItems;
        private ToolStripItemCollection m_defualtConfigItems;
        private ToolStripItemCollection m_defualtInputMethodMenuItems;
        #endregion

        public BIStatusBarForm()
        {
            CheckForIllegalCrossThreadCalls = false;

            this.SetStyle(ControlStyles.UserPaint |
            	ControlStyles.AllPaintingInWmPaint |
            	ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            this.u_toolStrip.Location = new Point(36, 0);
            this.u_toolStrip.ShowItemToolTips = false;
            this.u_aboutForm = new BIAboutForm();
            this.u_symbolForm = new BISymbolForm(this);
            this.u_keyboardForm = new BIKeyboardForm();
            this.u_dictionaryForm = new BIDictionaryForm(this);

			this.RestoreOriginalControls();
            this.SetMiniModeByConfig();
            this.SetMiniModeTypeByConfig();
            this.InitUI();

            // check update
            if (c_CheckUpdateOnStartUp) {
                this.CheckUpdateOnLaunch();
            }
            this.InstallIdleTimer();
        }

		private void RestoreOriginalControls()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(this.RestoreOriginalControls));
                return;
			}

 			#region Remove the "teminate server" option in release mode.
			#if !DEBUG
				int lastItem = this.u_configsDropDownMenu.Items.Count -1;
				this.u_configsDropDownMenu.Items.Remove(this.u_configsDropDownMenu.Items[lastItem]);
			#endif
			#endregion

            // You know, the names of the toolstrip menu maybe overwrite by
            // the auto-generated code by Visual Studio in the bloody design
            // mode.
            this.u_smartPhoneticToolStripMenuItem.Name = "SmartMandarin";
            this.u_traditionalPhoneticToolStripMenuItem.Name = "TraditionalMandarin";
            this.u_cangjieToolStripMenuItem.Name = "Generic-cj-cin";
            this.u_simplexToolStripMenuItem.Name = "Generic-simplex-cin";
            this.m_barhead = global::BaseIMEUI.Properties.Resources.barhead;
            this.m_bartail = global::BaseIMEUI.Properties.Resources.bartail;

            this.m_defaultToolStripItems = new ToolStripItemCollection(this.u_toolStrip, new ToolStripItem[] { });
            this.m_defaultToolStripItems.AddRange(this.u_toolStrip.Items);
            this.m_defualtInputMethodMenuItems = new ToolStripItemCollection(this.u_toolStrip, new ToolStripItem[] { });
            this.m_defualtInputMethodMenuItems.AddRange(this.u_toggleInputMethodDropDownMenu.Items);
            this.m_defualtConfigItems = new ToolStripItemCollection(this.u_toolStrip, new ToolStripItem[] { });
            this.m_defualtConfigItems.AddRange(this.u_configsDropDownMenu.Items);

            this.u_notifyIcon.Visible = false;
		}

        /// <summary>
        /// Initialize the default location.
        /// </summary>
        private void InitLocation()
        {
            //@warning A trick to set Status Bar to the bottom-right corner.
            this.m_isLocationInitialized = true;

            int x = Screen.PrimaryScreen.WorkingArea.Left +
            		Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            int y = Screen.PrimaryScreen.WorkingArea.Top +
            		Screen.PrimaryScreen.WorkingArea.Height - this.Height - 20;

            this.Location = new Point(x, y);
            this.u_toggleInputMethod.DropDownDirection = ToolStripDropDownDirection.AboveRight;
            this.u_configs.DropDownDirection = ToolStripDropDownDirection.AboveLeft;
        }

        #region Override the hide and show events.
        /// <summary>
        /// Override the default Hide() method.
        /// The DropDown menus, Dictionary search window and the Symbol Table
 		/// window should be closed with the status bar in the same time.
        /// </summary>
        public new void Hide()
        {
            if (this.m_shouldDisplay == false)
                return;

            this.m_shouldDisplay = false;

            if (!(this.m_isUsingSystemTrayMode == true && this.m_isMiniMode == true))
            {
                base.Hide();
                base.Visible = false;
                this.u_configsDropDownMenu.Hide();
                this.u_toggleInputMethodDropDownMenu.Hide();
            }

            bool tmp;

            if (this.u_dictionaryForm != null)
            {
                tmp = this.m_dictionaryFormShouldDisplay;
                if (this.u_dictionaryForm.Visible == true)
                    this.u_dictionaryForm.Hide();
                this.m_dictionaryFormShouldDisplay = tmp;
            }

            if (this.u_symbolForm != null)
            {
                tmp = this.m_symbolFormShouldDisplay;
                if (this.u_symbolForm.Visible == true)
                    this.u_symbolForm.Hide();
                this.m_symbolFormShouldDisplay = tmp;
            }

            if (this.u_keyboardForm != null)
            {
                if (this.u_keyboardForm.Visible == true)
                    this.u_keyboardForm.Hide();
                this.m_keyboardFormShouldDisplay = false;
            }
        }

        private void SetMiniModeByConfig()
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                if (callback.hasLoaderConfigKey("ShouldUseMiniMode"))
                {
                    if (callback.isLoaderConfigKeyTrue("ShouldUseMiniMode"))
                        this.m_isMiniMode = true;
                    else
                        this.m_isMiniMode = false;
                }
            }
        }

        private void SetMiniModeTypeByConfig()
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                if (callback.hasLoaderConfigKey("ShouldUseSystemTray"))
                {
                    if (callback.isLoaderConfigKeyTrue("ShouldUseSystemTray"))
                        this.m_isUsingSystemTrayMode = true;
                    else
                        this.m_isUsingSystemTrayMode = false;
                }
            }
        }

        private void SaveMiniModeConfig()
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                string value = "true";
                if (this.m_isMiniMode == false)
                {
                    value = "false";
                }
                callback.setLoaderConfigKeyStringValue("ShouldUseMiniMode", value);
            }
        }

        private void SetOpacityByConfig()
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                if (callback.hasLoaderConfigKey("ShouldUseTransparentStatusBar"))
                {
                    if (callback.isLoaderConfigKeyTrue("ShouldUseTransparentStatusBar"))
                        this.Opacity = 0.5;
                    else
                        this.Opacity = 1.0;
                }
            }
        }
        /// <summary>
        /// Override the default Show() methos.
        /// If the Symbol Table window should keep on being opened, it should be visible when
        /// the status bar is shown.
        /// </summary>
        public new void Show()
        {
            if (this.m_shouldDisplay == true)
                return;

            this.m_shouldDisplay = true;

            if (!(this.m_isUsingSystemTrayMode == true && this.m_isMiniMode == true))
                base.Show();

            if (this.m_dictionaryFormShouldDisplay == true)
            {
                if (this.u_dictionaryForm != null)
                {
                    if (this.u_dictionaryForm.Visible == false)
                        this.u_dictionaryForm.Show();
                }
            }
            if (this.m_keyboardFormShouldDisplay == true)
            {
                if (this.u_keyboardForm != null)
                {
                    if (this.u_keyboardForm.Visible == false)
                        this.u_keyboardForm.Show();
                }
            }
            if (this.m_symbolFormShouldDisplay == true)
            {
                if (this.u_symbolForm != null)
                {
                    if (this.u_symbolForm.Visible == false)
                    {
                        this.u_symbolForm.Refresh();
                        this.u_symbolForm.Show();
                        this.SetSymbolFormVisible();
                    }
                }
            }
            this.SetOpacityByConfig();
        }
        #endregion

        #region Event Handlers

        #region ChangeInput Method

        private void ResetStatusBarLocation()
        {
            Screen currentScreen;
            if (Screen.AllScreens.Length == 1)
                currentScreen = Screen.PrimaryScreen;
            else
                currentScreen = Screen.FromPoint(this.Location);
            this.Refresh();

            if (this.Right > currentScreen.WorkingArea.Right)
                this.Left = currentScreen.WorkingArea.Right - this.Width - 10;
        }

        // public delegate void UseNextInputMethodCallBack();
        /// <summary>
        /// Jump to the next input method.
        /// </summary>
        public void UseNextInputMethod()
        {
            if (this.InvokeRequired)
            {
				//UseNextInputMethodCallBack aUseNextInputMethodCall = new UseNextInputMethodCallBack(UseNextInputMethod);
				//this.Invoke(aUseNextInputMethodCall, new object[] { });
				this.Invoke(new MethodInvoker(this.UseNextInputMethod));
                return;
            }

            // get current input method index...
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;

            if (callback != null)
            {
                int index = 0;
                int i = 0;
                foreach (object item in u_toggleInputMethodDropDownMenu.Items)
                {
                    if (!(item is ToolStripSeparator))
                    {
                        ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)item;
                        if (toolStripMenuItem.CheckState.Equals(CheckState.Checked))
                            index = i;
                        toolStripMenuItem.CheckState = CheckState.Unchecked;
                    }
                    i++;
                }

                index++;

                if (index >= this.u_toggleInputMethodDropDownMenu.Items.Count)
                    index = 0;

                for (i = index; i < this.u_toggleInputMethodDropDownMenu.Items.Count; i++)
                {	
                 	object item = this.u_toggleInputMethodDropDownMenu.Items[i];
                    if (item is ToolStripMenuItem)
                    {
                        ToolStripMenuItem currentItem = (ToolStripMenuItem)item;

                        this.u_toggleInputMethod.Image = currentItem.Image;
                        this.u_toggleInputMethod.AutoSize = true;
                        this.u_toggleInputMethod.Text = currentItem.Text;

                        currentItem.CheckState = CheckState.Checked;
                        string currentInputMethod = currentItem.Name;
                        callback.setPrimaryInputMethod(currentInputMethod, false);
                        if (this.m_isMiniMode == false && m_isUsingSystemTrayMode == false)
                            this.ResetStatusBarLocation();
                        else
                            this.Refresh();

                        if (currentLocale.Equals("zh-TW"))
                            this.Notify("\u9078\u7528" + currentItem.Text + "\u8f38\u5165\u6cd5");
                        else if (currentLocale.Equals("zh-CN"))
                            this.Notify("\u9009\u7528" + currentItem.Text + "\u8F93\u5165\u6CD5");
                        else
                            this.Notify("Current Input Method: " + currentItem.Text + ".");

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Switch to the selected input method in the menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInputMethod(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            if (callback != null)
            {
                ToolStripMenuItem currentItem = (ToolStripMenuItem)sender;
                this.u_toggleInputMethod.Image = currentItem.Image;
                this.u_toggleInputMethod.AutoSize = true;
                this.u_toggleInputMethod.Text = currentItem.Text;

                foreach (object item in u_toggleInputMethodDropDownMenu.Items)
                {
                    if (!(item is ToolStripSeparator))
                    {
                        ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)item;
                        toolStripMenuItem.CheckState = CheckState.Unchecked;
                    }
                }

                currentItem.CheckState = CheckState.Checked;

                string currentInputMethod = currentItem.Name;

                callback.setPrimaryInputMethod(currentInputMethod, true);
                this.ResetStatusBarLocation();

                if (currentLocale.Equals("zh-TW"))
                    this.Notify("\u9078\u7528" + currentItem.Text + "\u8f38\u5165\u6cd5");
                else if (currentLocale.Equals("zh-CN"))
                    this.Notify("\u9009\u7528" + currentItem.Text + "\u8F93\u5165\u6CD5");
                else
                    this.Notify("Current Input Method: " + currentItem.Text + ".");
            }
        }

        #endregion

        #region Enable and Disable Output Filters and Around Filters

        public void ToggleFullWidthCharacterMode()
        {
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(this.ToggleFullWidthCharacterMode));
                return;
			}
	
            ToggleFullWidthCharacterMode(null, null);
        }

        public void ToggleAlphanumericMode()
        {
			if (this.InvokeRequired)
			{
				this.Invoke(new MethodInvoker(this.ToggleAlphanumericMode));
                return;
			}
	
            ToggleAlphanumericMode(null, null);
        }

        /// <summary>
        /// Toggle English / Chinese mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleAlphanumericMode(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            if (callback != null)
            {
                if (callback.isAlphanumericMode())
                {
                    this.u_toggleAlphanumericMode.Image = this.m_imageChinese;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u4e2d\u6587\u6a21\u5f0f");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u4E2D\u6587\u6A21\u5F0F");
                    else
                        this.Notify("Switch to Chinese mode.");
                    callback.setAlphanumericMode(false);
                }
                else
                {
                    this.u_toggleAlphanumericMode.Image = this.m_imageEnglish;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u82f1\u6587\u6a21\u5f0f");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u82F1\u6587\u6A21\u5F0F");
                    else
                        this.Notify("Switch to English mode.");
                    callback.setAlphanumericMode(true);
                }
                if (this.m_isMiniMode == true && m_isUsingSystemTrayMode == false)
                    this.Refresh();
            }
        }
        /// <summary>
        /// Toggle full / half width roman letters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleFullWidthCharacterMode(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            if (callback != null)
            {
                callback.setFullWidthCharacterMode(!callback.isFullWidthCharacterMode());

                if (!callback.isFullWidthCharacterMode())
                {
                    this.u_toggleFullWidthCharacterMode.Image = this.m_imageHalfWidth;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u534a\u5f62\u82f1\u6578\u6a21\u5f0f");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u534a\u89d2\u82f1\u6570\u6a21\u5f0f");
                    else
                        this.Notify("Half-width roman letters mode.");
                }
                else
                {
                    this.u_toggleFullWidthCharacterMode.Image = this.m_imageFullWidth;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u5168\u5f62\u82f1\u6578\u6a21\u5f0f");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u5168\u89d2\u82f1\u6570\u6a21\u5f0f");
                    else
                        this.Notify("Full-width roman letters mode.");
                }
            }
        }

        public void ToggleChineseCharacterConverter()
        {
            if (this.InvokeRequired)
            {
				this.Invoke(new MethodInvoker(this.ToggleChineseCharacterConverter));
                return;
            }
            this.ToggleChineseCharacterConverter(this, null);
        }

        /// <summary>
        /// Toggle Traditional / Simplified Chinese mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleChineseCharacterConverter(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            if (callback != null)
            {
                callback.toggleOutputFilter("ChineseCharacterConvertor-TC2SC");
                if (!callback.isOutputFilterEnabled("ChineseCharacterConvertor-TC2SC"))
                {
                    this.u_toggleChineseCharacterConverter.Image = this.m_imageZhTW;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u7e41\u9ad4\u4e2d\u6587\u8f38\u51fa");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u7E41\u4F53\u4E2D\u6587\u6A21\u5F0F");
                    else
                        this.Notify("Traditional Chinese mode.");
                }
                else
                {
                    this.u_toggleChineseCharacterConverter.Image = this.m_imageZhCN;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u7c21\u9ad4\u4e2d\u6587\u8f38\u51fa");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u7B80\u4F53\u4E2D\u6587\u6A21\u5F0F");
                    else
                        this.Notify("Simplified Chinese mode.");
                }
            }
        }

        /// <summary>
        /// Enable or diable an extra around filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aroundFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            ToolStripMenuItem currentItem = (ToolStripMenuItem)sender;
            string aroundFilterName = currentItem.Name;
            string displayName = currentItem.Text;
            if (callback != null && aroundFilterName != "")
            {
                callback.toggleAroundFilter(aroundFilterName);
                if (currentItem.Checked == false)
                {
                    currentItem.Checked = true;
                    currentItem.Image = global::BaseIMEUI.Properties.Resources.menuCheck;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u300c" + displayName + "\u300d\u529f\u80fd\u5df2\u555f\u7528");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u301D" + displayName + "\u301E\u529F\u80FD\u5DF2\u542F\u7528");
                    else
                        this.Notify(displayName + " is on.");
                }
                else
                {
                    currentItem.Checked = false;
                    currentItem.Image = global::BaseIMEUI.Properties.Resources.menuUncheck;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u300c" + displayName + "\u300d\u529f\u80fd\u5df2\u505c\u7528");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u301D" + displayName + "\u301E\u529F\u80FD\u5DF2\u505C\u7528");
                    else
                        this.Notify(displayName + " is off.");
                }
            }
        }
        /// <summary>
        /// Enable or diable an extra output filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            string currentLocale = CultureInfo.CurrentUICulture.Name;
            ToolStripMenuItem currentItem = (ToolStripMenuItem)sender;
            string outputFilterName = currentItem.Name;
            string displayName = currentItem.Text;
            if (callback != null && outputFilterName != "")
            {
                callback.toggleOutputFilter(outputFilterName);
                if (currentItem.Checked == false)
                {
                    currentItem.Checked = true;
                    currentItem.Image = global::BaseIMEUI.Properties.Resources.menuCheck;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u300c" + displayName + "\u300d\u529f\u80fd\u5df2\u555f\u7528");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u301D" + displayName + "\u301E\u529F\u80FD\u5DF2\u542F\u7528");
                    else
                        this.Notify(displayName + " is on.");
                }
                else
                {
                    currentItem.Checked = false;
                    currentItem.Image = global::BaseIMEUI.Properties.Resources.menuUncheck;
                    if (currentLocale.Equals("zh-TW"))
                        this.Notify("\u300c" + displayName + "\u300d\u529f\u80fd\u5df2\u505c\u7528");
                    else if (currentLocale.Equals("zh-CN"))
                        this.Notify("\u301D" + displayName + "\u301E\u529F\u80FD\u5DF2\u505C\u7528");
                    else
                        this.Notify(displayName + " is off.");
                }
            }
        }
        #endregion

        #region Show Help
        private void ShowHelpInThread()
        {
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = Config.HelpURL;
            try
            {
                process.Start();
            }
            catch { }
        }
        /// <summary>
        /// To show the help file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHelp(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(ShowHelpInThread);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        #endregion

        #region Show Preference
        //private delegate void ShowPreferenceCallBack();
        /// <summary>
        /// To launch the preference tool.
        /// </summary>        
        public void ShowPreferences()
        {
            if (this.InvokeRequired)
            {
				this.Invoke(new MethodInvoker(this.ShowPreferences));
                return;
            }

            string filename = Application.StartupPath + Path.DirectorySeparatorChar + "PreferencesMain.exe";
            try
            {
                Process serviceApp = Process.Start(filename, "");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to start up Preferences app", "Error!");
            }
        }

        private void ClickPreferenceToolStripMenuItem(object sender, EventArgs e)
        {
            this.ShowPreferences();
        }
        #endregion

        #region Show About Window
        private void ShowAboutForm(object sender, EventArgs e)
        {
            this.u_aboutForm.ShowDialog();
            this.u_aboutForm.Focus();
        }
        #endregion

        #region Terminate the Input Method Server
        private void TerminateServer(object sender, EventArgs e)
        {
            // @zonble
            // When terminating server in the debug mode may cause 
            // exceptions about
            // the sqlite connections, however, we ignore it.
            try
            {
                Application.Exit();
            }
            catch { }
        }
        #endregion

        #region The behaviours which affect text color of the input method menu.
        private void u_toggleInputMethodDropDown_Opened(object sender, System.EventArgs e)
        {
            this.u_toggleInputMethod.ForeColor = Color.Black;
            this.m_isInputMethodDropDownOpened = true;
        }
        private void u_toggleInputMethodDropDown_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
        {
            this.u_toggleInputMethod.ForeColor = Color.White;
            this.m_isInputMethodDropDownOpened = false;
        }
        void u_toggleInputMethod_MouseEnter(object sender, System.EventArgs e)
        {
            this.u_toggleInputMethod.ForeColor = Color.Black;
        }
        void u_toggleInputMethod_MouseLeave(object sender, System.EventArgs e)
        {
            if (m_isInputMethodDropDownOpened == false)
                this.u_toggleInputMethod.ForeColor = Color.White;
            else
                this.u_toggleInputMethod.ForeColor = Color.Black;
        }
        #endregion

        #region The Symbol Table window
        /// <summary>
        /// Let the status bar know the Symbol Window is currently hidden.
        /// </summary>
        public void SetSymbolFormHidden()
        {
            this.u_showSymbol.Image = global::BaseIMEUI.Properties.Resources.symbolOpen;
            this.m_symbolFormShouldDisplay = false;
        }
        /// <summary>
        /// Let the status bar know the Symbol Window is currently visible.
        /// </summary>
        public void SetSymbolFormVisible()
        {
            this.u_showSymbol.Image = global::BaseIMEUI.Properties.Resources.symbolClose;
            this.m_symbolFormShouldDisplay = true;
        }

        public bool KeyboardFormVisible
        {
            get { return this.u_keyboardForm.PrepareToShow; }
            set { this.u_keyboardForm.PrepareToShow = value; }
        }

        public void SetKeyboardFormLocation(int x, int y)
        {
            this.u_keyboardForm.SetLocation(x, y);
        }

        public void ShowKeyboardForm()
        {
            if (this.InvokeRequired)
            {
				this.Invoke(new MethodInvoker(this.ShowKeyboardForm));
                return;
            }

            if (this.u_keyboardForm.Visible == false)
            {
                this.u_keyboardForm.Refresh();
                this.u_keyboardForm.Show();
                this.m_keyboardFormShouldDisplay = true;
				this.u_keyboardForm.PrepareToShow = false;
            }

			if (this.u_symbolForm != null && this.u_symbolForm.Visible)
			{
                this.u_symbolForm.Hide();	
	            this.u_showSymbol.Image = global::BaseIMEUI.Properties.Resources.symbolOpen;
	            this.m_symbolFormShouldDisplay = false;
			}
        }

        public void HideKeyboardForm()
        {
            if (this.InvokeRequired)
            {
				this.Invoke(new MethodInvoker(this.HideKeyboardForm));
                return;
            }
            if (this.u_keyboardForm != null)
			{
				this.u_keyboardForm.Hide();
				this.u_keyboardForm.PrepareToShow = false;
	            this.m_keyboardFormShouldDisplay = false;
			}
        }

        public void ToggleSymbolForm()
        {
            if (this.InvokeRequired)
            {
				this.Invoke(new MethodInvoker(this.ToggleSymbolForm));
                return;
            }
            this.ToggleSymbolForm(this, null);
        }

        private void ToggleSymbolForm(object sender, EventArgs e)
        {
            if (this.u_symbolForm.Visible == false)
            {
                Screen currentScreen = Screen.FromControl(this);
                if (this.Left + this.u_symbolForm.Width + 10 > currentScreen.WorkingArea.Right)
                    this.Left = currentScreen.WorkingArea.Right - this.u_symbolForm.Width - 10;
                int x = this.Left;
                int y = this.Top - this.u_symbolForm.Height - 10;
                if (y < 0)
                    y = this.Bottom;
                this.u_symbolForm.Location = new Point(x, y);

                // TO DO: Remove this and put this in the refresh mechanism
                this.u_symbolForm.LoadSymbols();
                this.u_symbolForm.Refresh();
                this.u_symbolForm.Show();
                this.u_showSymbol.Image = global::BaseIMEUI.Properties.Resources.symbolClose;
                this.m_symbolFormShouldDisplay = true;

				if (this.u_keyboardForm != null && this.u_keyboardForm.Visible)
				{
	                this.u_keyboardForm.Hide();	
		            this.m_keyboardFormShouldDisplay = false; 
				}
            }
            else
            {
				if (this.u_symbolForm != null)
				{
	                this.u_symbolForm.Hide();	
				}
                this.u_showSymbol.Image = global::BaseIMEUI.Properties.Resources.symbolOpen;
                this.m_symbolFormShouldDisplay = false;
            }
        }
        #endregion

        #region Search Yahoo! English/Chinese Dictionary

        public void SetDictionaryFormHide()
        {
            this.m_dictionaryFormShouldDisplay = false;
        }

        private delegate void SearchDictionaryCallBack(string Keyword);
        public void SearchDictionary(string Keyword)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SearchDictionaryCallBack(SearchDictionary), new object[] { Keyword });
                return;
            }
            this.u_dictionaryForm.Search(Keyword);
            this.m_dictionaryFormShouldDisplay = true;
        }
        #endregion

        #region Double click on the status bar to switch between normal and mini mode.
        private void BIStatusBarForm_DoubleClick(object sender, EventArgs e)
        {
            this.SetMiniModeTypeByConfig();

            if (this.m_isUsingSystemTrayMode == true)
            {
                this.Hide();
                this.m_shouldDisplay = true;
                this.u_notifyIcon.Visible = true;
                this.m_isMiniMode = true;
            }
            else
            {
                if (this.m_isMiniMode == true)
                {
                    this.m_isMiniMode = false;
                    this.ResetStatusBarLocation();
                }
                else
                {
                    this.m_isMiniMode = true;
                    Screen currentScreen = Screen.FromPoint(this.Location);
                    this.Left = currentScreen.WorkingArea.Right - 64;
                }

                this.m_shouldDisplay = true;
                this.u_configsDropDownMenu.Hide();
                this.u_toggleInputMethodDropDownMenu.Hide();
                this.Invalidate();
            }
            this.SaveMiniModeConfig();
        }

        private void u_notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.u_notifyIcon.Visible = false;
            this.m_isMiniMode = false;
            if (this.m_shouldDisplay == true)
                this.Show();
            this.SaveMiniModeConfig();
        }
        #endregion

        #region Perform One-Click
        private void SendOneKey(object sender, EventArgs e)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
                callback.sendOneKeyChar();
        }
        #endregion

        #region Hides the config menu.
        private void CancelConfigMenu(object sender, EventArgs e)
        {
            this.u_configsDropDownMenu.Hide();
        } 
        #endregion

        #endregion

		public string LocalizedNameOfCurrentInputMethod()
		{
			return this.u_toggleInputMethod.Text;
		}
    }
}