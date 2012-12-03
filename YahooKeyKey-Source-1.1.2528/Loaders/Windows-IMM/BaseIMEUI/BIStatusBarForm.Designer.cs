namespace BaseIMEUI
{
    partial class BIStatusBarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
		        m_barhead.Dispose();
		        m_bartail.Dispose();	
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIStatusBarForm));
            this.u_toggleInputMethodDropDownMenu = new BaseIMEUI.BIToolStripDropDown(this.components);
            this.u_smartPhoneticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_traditionalPhoneticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_cangjieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_simplexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_toggleInputMethod = new System.Windows.Forms.ToolStripDropDownButton();
            this.u_configsDropDownMenu = new BaseIMEUI.BIToolStripDropDown(this.components);
            this.u_oneKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_preferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_helptoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_terminateServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_configs = new System.Windows.Forms.ToolStripDropDownButton();
            this.u_toggleAlphanumericMode = new System.Windows.Forms.ToolStripButton();
            this.u_toggleChineseCharacterConverter = new System.Windows.Forms.ToolStripButton();
            this.u_toggleFullWidthCharacterMode = new System.Windows.Forms.ToolStripButton();
            this.u_showSymbol = new System.Windows.Forms.ToolStripButton();
            this.u_toolStrip = new System.Windows.Forms.ToolStrip();
            this.u_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.u_toggleInputMethodDropDownMenu.SuspendLayout();
            this.u_configsDropDownMenu.SuspendLayout();
            this.u_toolStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // u_toggleInputMethodDropDownMenu
            // 
            this.u_toggleInputMethodDropDownMenu.DropShadowEnabled = false;
            this.u_toggleInputMethodDropDownMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.u_smartPhoneticToolStripMenuItem,
            this.u_traditionalPhoneticToolStripMenuItem,
            this.u_cangjieToolStripMenuItem,
            this.u_simplexToolStripMenuItem});
            this.u_toggleInputMethodDropDownMenu.Name = "u_toggleInputMethodDropDown";
            this.u_toggleInputMethodDropDownMenu.OwnerItem = this.u_toggleInputMethod;
            resources.ApplyResources(this.u_toggleInputMethodDropDownMenu, "u_toggleInputMethodDropDownMenu");
            this.u_toggleInputMethodDropDownMenu.Opened += new System.EventHandler(this.u_toggleInputMethodDropDown_Opened);
            this.u_toggleInputMethodDropDownMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.u_toggleInputMethodDropDown_Closed);
            // 
            // u_smartPhoneticToolStripMenuItem
            // 
            this.u_smartPhoneticToolStripMenuItem.Image = global::BaseIMEUI.Properties.Resources.smart;
            resources.ApplyResources(this.u_smartPhoneticToolStripMenuItem, "u_smartPhoneticToolStripMenuItem");
            this.u_smartPhoneticToolStripMenuItem.Name = "u_smartPhoneticToolStripMenuItem";
            this.u_smartPhoneticToolStripMenuItem.Click += new System.EventHandler(this.SelectInputMethod);
            // 
            // u_traditionalPhoneticToolStripMenuItem
            // 
            this.u_traditionalPhoneticToolStripMenuItem.Image = global::BaseIMEUI.Properties.Resources.phonetic;
            resources.ApplyResources(this.u_traditionalPhoneticToolStripMenuItem, "u_traditionalPhoneticToolStripMenuItem");
            this.u_traditionalPhoneticToolStripMenuItem.Name = "u_traditionalPhoneticToolStripMenuItem";
            this.u_traditionalPhoneticToolStripMenuItem.Click += new System.EventHandler(this.SelectInputMethod);
            // 
            // u_cangjieToolStripMenuItem
            // 
            this.u_cangjieToolStripMenuItem.Image = global::BaseIMEUI.Properties.Resources.cangjie;
            resources.ApplyResources(this.u_cangjieToolStripMenuItem, "u_cangjieToolStripMenuItem");
            this.u_cangjieToolStripMenuItem.Name = "u_cangjieToolStripMenuItem";
            this.u_cangjieToolStripMenuItem.Click += new System.EventHandler(this.SelectInputMethod);
            // 
            // u_simplexToolStripMenuItem
            // 
            this.u_simplexToolStripMenuItem.Image = global::BaseIMEUI.Properties.Resources.simplex;
            resources.ApplyResources(this.u_simplexToolStripMenuItem, "u_simplexToolStripMenuItem");
            this.u_simplexToolStripMenuItem.Name = "u_simplexToolStripMenuItem";
            this.u_simplexToolStripMenuItem.Click += new System.EventHandler(this.SelectInputMethod);
            // 
            // u_toggleInputMethod
            // 
            this.u_toggleInputMethod.DropDown = this.u_toggleInputMethodDropDownMenu;
            resources.ApplyResources(this.u_toggleInputMethod, "u_toggleInputMethod");
            this.u_toggleInputMethod.ForeColor = System.Drawing.Color.White;
            this.u_toggleInputMethod.Image = global::BaseIMEUI.Properties.Resources.phonetic;
            this.u_toggleInputMethod.Margin = new System.Windows.Forms.Padding(0);
            this.u_toggleInputMethod.Name = "u_toggleInputMethod";
            this.u_toggleInputMethod.MouseLeave += new System.EventHandler(this.u_toggleInputMethod_MouseLeave);
            this.u_toggleInputMethod.MouseEnter += new System.EventHandler(this.u_toggleInputMethod_MouseEnter);
            // 
            // u_configsDropDownMenu
            // 
            this.u_configsDropDownMenu.DropShadowEnabled = false;
            this.u_configsDropDownMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.u_oneKeyToolStripMenuItem,
            this.u_preferenceToolStripMenuItem,
            this.u_helptoolStripMenuItem,
            this.u_aboutToolStripMenuItem,
            this.u_cancelToolStripMenuItem,
            this.u_terminateServerToolStripMenuItem});
            this.u_configsDropDownMenu.Name = "u_ConfigsDropDown";
            this.u_configsDropDownMenu.OwnerItem = this.u_configs;
            resources.ApplyResources(this.u_configsDropDownMenu, "u_configsDropDownMenu");
            // 
            // u_preferenceToolStripMenuItem
            // 
            resources.ApplyResources(this.u_preferenceToolStripMenuItem, "u_preferenceToolStripMenuItem");
            this.u_preferenceToolStripMenuItem.Name = "u_preferenceToolStripMenuItem";
            this.u_preferenceToolStripMenuItem.Click += new System.EventHandler(this.ClickPreferenceToolStripMenuItem);
            // 
            // u_oneKeyToolStripMenuItem
            // 
            this.u_oneKeyToolStripMenuItem.Name = "u_oneKeyToolStripMenuItem";
            resources.ApplyResources(this.u_oneKeyToolStripMenuItem, "u_oneKeyToolStripMenuItem");
            this.u_oneKeyToolStripMenuItem.Click += new System.EventHandler(this.SendOneKey);
            // 
            // u_helptoolStripMenuItem
            // 
            resources.ApplyResources(this.u_helptoolStripMenuItem, "u_helptoolStripMenuItem");
            this.u_helptoolStripMenuItem.Name = "u_helptoolStripMenuItem";
            this.u_helptoolStripMenuItem.Click += new System.EventHandler(this.ShowHelp);
            // 
            // u_aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.u_aboutToolStripMenuItem, "u_aboutToolStripMenuItem");
            this.u_aboutToolStripMenuItem.Name = "u_aboutToolStripMenuItem";
            this.u_aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAboutForm);
            // 
            // u_cancelToolStripMenuItem
            // 
            this.u_cancelToolStripMenuItem.Name = "u_cancelToolStripMenuItem";
            resources.ApplyResources(this.u_cancelToolStripMenuItem, "u_cancelToolStripMenuItem");
            this.u_cancelToolStripMenuItem.Click += new System.EventHandler(this.CancelConfigMenu);
            // 
            // u_terminateServerToolStripMenuItem
            // 
            resources.ApplyResources(this.u_terminateServerToolStripMenuItem, "u_terminateServerToolStripMenuItem");
            this.u_terminateServerToolStripMenuItem.Name = "u_terminateServerToolStripMenuItem";
            this.u_terminateServerToolStripMenuItem.Click += new System.EventHandler(this.TerminateServer);
            // 
            // u_configs
            // 
            this.u_configs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.u_configs.DropDown = this.u_configsDropDownMenu;
            resources.ApplyResources(this.u_configs, "u_configs");
            this.u_configs.Image = global::BaseIMEUI.Properties.Resources.config;
            this.u_configs.Margin = new System.Windows.Forms.Padding(0);
            this.u_configs.Name = "u_configs";
            this.u_configs.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            // 
            // u_toggleAlphanumericMode
            // 
            this.u_toggleAlphanumericMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.u_toggleAlphanumericMode, "u_toggleAlphanumericMode");
            this.u_toggleAlphanumericMode.Image = global::BaseIMEUI.Properties.Resources.chinese;
            this.u_toggleAlphanumericMode.Margin = new System.Windows.Forms.Padding(0);
            this.u_toggleAlphanumericMode.Name = "u_toggleAlphanumericMode";
            this.u_toggleAlphanumericMode.Click += new System.EventHandler(this.ToggleAlphanumericMode);
            // 
            // u_toggleChineseCharacterConverter
            // 
            this.u_toggleChineseCharacterConverter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.u_toggleChineseCharacterConverter, "u_toggleChineseCharacterConverter");
            this.u_toggleChineseCharacterConverter.Image = global::BaseIMEUI.Properties.Resources.zh_TW;
            this.u_toggleChineseCharacterConverter.Margin = new System.Windows.Forms.Padding(0);
            this.u_toggleChineseCharacterConverter.Name = "u_toggleChineseCharacterConverter";
            this.u_toggleChineseCharacterConverter.Click += new System.EventHandler(this.ToggleChineseCharacterConverter);
            // 
            // u_toggleFullWidthCharacterMode
            // 
            this.u_toggleFullWidthCharacterMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.u_toggleFullWidthCharacterMode, "u_toggleFullWidthCharacterMode");
            this.u_toggleFullWidthCharacterMode.Image = global::BaseIMEUI.Properties.Resources.fullwidth;
            this.u_toggleFullWidthCharacterMode.Margin = new System.Windows.Forms.Padding(0);
            this.u_toggleFullWidthCharacterMode.Name = "u_toggleFullWidthCharacterMode";
            this.u_toggleFullWidthCharacterMode.Click += new System.EventHandler(this.ToggleFullWidthCharacterMode);
            // 
            // u_showSymbol
            // 
            this.u_showSymbol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.u_showSymbol, "u_showSymbol");
            this.u_showSymbol.Image = global::BaseIMEUI.Properties.Resources.symbolOpen;
            this.u_showSymbol.Name = "u_showSymbol";
            this.u_showSymbol.Click += new System.EventHandler(this.ToggleSymbolForm);
            // 
            // u_toolStrip
            // 
            this.u_toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.u_toolStrip.CanOverflow = false;
            resources.ApplyResources(this.u_toolStrip, "u_toolStrip");
            this.u_toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.u_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.u_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.u_toggleInputMethod,
            this.u_toggleAlphanumericMode,
            this.u_toggleChineseCharacterConverter,
            this.u_toggleFullWidthCharacterMode,
            this.u_showSymbol,
            this.u_configs});
            this.u_toolStrip.Name = "u_toolStrip";
            this.u_toolStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintToolStrip);
            this.u_toolStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BIStatusBar_MouseMove);
            // 
            // u_notifyIcon
            // 
            resources.ApplyResources(this.u_notifyIcon, "u_notifyIcon");
            this.u_notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.u_notifyIcon_MouseDoubleClick);
            this.u_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.u_notifyIcon_MouseDoubleClick);
            // 
            // BIStatusBarForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::BaseIMEUI.Properties.Resources.barbg;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.u_toolStrip);
            this.Name = "BIStatusBarForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BIStatusBar_Paint);
            this.DoubleClick += new System.EventHandler(this.BIStatusBarForm_DoubleClick);
            this.Move += new System.EventHandler(this.BIStatusBarForm_Move);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BIStatusBar_MouseMove);
            this.u_toggleInputMethodDropDownMenu.ResumeLayout(false);
            this.u_configsDropDownMenu.ResumeLayout(false);
            this.u_toolStrip.ResumeLayout(false);
            this.u_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private BIToolStripDropDown u_toggleInputMethodDropDownMenu;
        private System.Windows.Forms.ToolStripDropDownButton u_toggleInputMethod;
        private System.Windows.Forms.ToolStripMenuItem u_smartPhoneticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_traditionalPhoneticToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_cangjieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_simplexToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton u_toggleAlphanumericMode;
        private System.Windows.Forms.ToolStripButton u_toggleChineseCharacterConverter;
        private System.Windows.Forms.ToolStripButton u_toggleFullWidthCharacterMode;
        private System.Windows.Forms.ToolStripDropDownButton u_configs;
        private BIToolStripDropDown u_configsDropDownMenu;
        private System.Windows.Forms.ToolStripMenuItem u_preferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_helptoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_oneKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_terminateServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton u_showSymbol;
        private System.Windows.Forms.ToolStrip u_toolStrip;
        private System.Windows.Forms.NotifyIcon u_notifyIcon;

    }
}
