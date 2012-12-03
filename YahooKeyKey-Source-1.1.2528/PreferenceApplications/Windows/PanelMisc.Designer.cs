/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelMisc
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
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.Label u_labelTitle;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelMisc));
			this.u_beepCheckBox = new System.Windows.Forms.CheckBox();
			this.u_beepPanel = new System.Windows.Forms.Panel();
			this.u_soundListComboBox = new System.Windows.Forms.ComboBox();
			this.u_testSoundButton = new System.Windows.Forms.Button();
			this.u_radioCustomizedSound = new System.Windows.Forms.RadioButton();
			this.u_radioDefaultSound = new System.Windows.Forms.RadioButton();
			this.u_highlightColorLabel = new System.Windows.Forms.Label();
			this.u_highlightColorComboBox = new System.Windows.Forms.ComboBox();
			this.u_backgroundPatternCheckBox = new System.Windows.Forms.CheckBox();
			this.u_colorDialog = new System.Windows.Forms.ColorDialog();
			this.u_transparentStatusBarCheckBox = new System.Windows.Forms.CheckBox();
			this.u_minimizeToSystemTrayCheckBox = new System.Windows.Forms.CheckBox();
			this.u_chkKeyboardFormShouldFollowCursor = new System.Windows.Forms.CheckBox();
			this.u_backgroundColorLabel = new System.Windows.Forms.Label();
			this.u_backgroundColorComboBox = new System.Windows.Forms.ComboBox();
			this.u_textColorLabel = new System.Windows.Forms.Label();
			this.u_textColorComboBox = new System.Windows.Forms.ComboBox();
			this.u_statusBarGroup = new System.Windows.Forms.GroupBox();
			this.u_candidateWindowGroup = new System.Windows.Forms.GroupBox();
			this.u_extraGroup = new System.Windows.Forms.GroupBox();
			this.u_removePluginButton = new System.Windows.Forms.Button();
			this.u_pluginLabel = new System.Windows.Forms.Label();
			this.u_pluginComboBox = new System.Windows.Forms.ComboBox();
			u_labelTitle = new System.Windows.Forms.Label();
			this.u_beepPanel.SuspendLayout();
			this.u_statusBarGroup.SuspendLayout();
			this.u_candidateWindowGroup.SuspendLayout();
			this.u_extraGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// u_labelTitle
			// 
			u_labelTitle.AccessibleDescription = null;
			u_labelTitle.AccessibleName = null;
			resources.ApplyResources(u_labelTitle, "u_labelTitle");
			u_labelTitle.Font = null;
			u_labelTitle.Name = "u_labelTitle";
			// 
			// u_beepCheckBox
			// 
			this.u_beepCheckBox.AccessibleDescription = null;
			this.u_beepCheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_beepCheckBox, "u_beepCheckBox");
			this.u_beepCheckBox.BackgroundImage = null;
			this.u_beepCheckBox.Font = null;
			this.u_beepCheckBox.Name = "u_beepCheckBox";
			this.u_beepCheckBox.UseVisualStyleBackColor = true;
			this.u_beepCheckBox.CheckedChanged += new System.EventHandler(this.u_beepCheckBox_CheckedChanged);
			// 
			// u_beepPanel
			// 
			this.u_beepPanel.AccessibleDescription = null;
			this.u_beepPanel.AccessibleName = null;
			resources.ApplyResources(this.u_beepPanel, "u_beepPanel");
			this.u_beepPanel.BackgroundImage = null;
			this.u_beepPanel.Controls.Add(this.u_soundListComboBox);
			this.u_beepPanel.Controls.Add(this.u_testSoundButton);
			this.u_beepPanel.Controls.Add(this.u_radioCustomizedSound);
			this.u_beepPanel.Controls.Add(this.u_radioDefaultSound);
			this.u_beepPanel.Font = null;
			this.u_beepPanel.Name = "u_beepPanel";
			// 
			// u_soundListComboBox
			// 
			this.u_soundListComboBox.AccessibleDescription = null;
			this.u_soundListComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_soundListComboBox, "u_soundListComboBox");
			this.u_soundListComboBox.BackgroundImage = null;
			this.u_soundListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_soundListComboBox.Font = null;
			this.u_soundListComboBox.FormattingEnabled = true;
			this.u_soundListComboBox.Name = "u_soundListComboBox";
			this.u_soundListComboBox.SelectedIndexChanged += new System.EventHandler(this.u_soundListComboBox_SelectedIndexChanged);
			// 
			// u_testSoundButton
			// 
			this.u_testSoundButton.AccessibleDescription = null;
			this.u_testSoundButton.AccessibleName = null;
			resources.ApplyResources(this.u_testSoundButton, "u_testSoundButton");
			this.u_testSoundButton.BackgroundImage = null;
			this.u_testSoundButton.Font = null;
			this.u_testSoundButton.Name = "u_testSoundButton";
			this.u_testSoundButton.UseVisualStyleBackColor = true;
			this.u_testSoundButton.Click += new System.EventHandler(this.u_testSoundButton_Click);
			// 
			// u_radioCustomizedSound
			// 
			this.u_radioCustomizedSound.AccessibleDescription = null;
			this.u_radioCustomizedSound.AccessibleName = null;
			resources.ApplyResources(this.u_radioCustomizedSound, "u_radioCustomizedSound");
			this.u_radioCustomizedSound.BackgroundImage = null;
			this.u_radioCustomizedSound.Font = null;
			this.u_radioCustomizedSound.Name = "u_radioCustomizedSound";
			this.u_radioCustomizedSound.UseVisualStyleBackColor = true;
			this.u_radioCustomizedSound.CheckedChanged += new System.EventHandler(this.u_radioCustomizedSound_CheckedChanged);
			// 
			// u_radioDefaultSound
			// 
			this.u_radioDefaultSound.AccessibleDescription = null;
			this.u_radioDefaultSound.AccessibleName = null;
			resources.ApplyResources(this.u_radioDefaultSound, "u_radioDefaultSound");
			this.u_radioDefaultSound.BackgroundImage = null;
			this.u_radioDefaultSound.Font = null;
			this.u_radioDefaultSound.Name = "u_radioDefaultSound";
			this.u_radioDefaultSound.UseVisualStyleBackColor = true;
			this.u_radioDefaultSound.CheckedChanged += new System.EventHandler(this.u_radioDefaultSound_CheckedChanged);
			// 
			// u_highlightColorLabel
			// 
			this.u_highlightColorLabel.AccessibleDescription = null;
			this.u_highlightColorLabel.AccessibleName = null;
			resources.ApplyResources(this.u_highlightColorLabel, "u_highlightColorLabel");
			this.u_highlightColorLabel.Font = null;
			this.u_highlightColorLabel.Name = "u_highlightColorLabel";
			// 
			// u_highlightColorComboBox
			// 
			this.u_highlightColorComboBox.AccessibleDescription = null;
			this.u_highlightColorComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_highlightColorComboBox, "u_highlightColorComboBox");
			this.u_highlightColorComboBox.BackgroundImage = null;
			this.u_highlightColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_highlightColorComboBox.Font = null;
			this.u_highlightColorComboBox.FormattingEnabled = true;
			this.u_highlightColorComboBox.Items.AddRange(new object[] {
            resources.GetString("u_highlightColorComboBox.Items"),
            resources.GetString("u_highlightColorComboBox.Items1"),
            resources.GetString("u_highlightColorComboBox.Items2"),
            resources.GetString("u_highlightColorComboBox.Items3"),
            resources.GetString("u_highlightColorComboBox.Items4")});
			this.u_highlightColorComboBox.Name = "u_highlightColorComboBox";
			this.u_highlightColorComboBox.SelectedIndexChanged += new System.EventHandler(this.u_colorComboBox_SelectedIndexChanged);
			// 
			// u_backgroundPatternCheckBox
			// 
			this.u_backgroundPatternCheckBox.AccessibleDescription = null;
			this.u_backgroundPatternCheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_backgroundPatternCheckBox, "u_backgroundPatternCheckBox");
			this.u_backgroundPatternCheckBox.BackgroundImage = null;
			this.u_backgroundPatternCheckBox.Font = null;
			this.u_backgroundPatternCheckBox.Name = "u_backgroundPatternCheckBox";
			this.u_backgroundPatternCheckBox.UseVisualStyleBackColor = true;
			this.u_backgroundPatternCheckBox.CheckedChanged += new System.EventHandler(this.u_backgroundPatternCheckBox_CheckedChanged);
			// 
			// u_colorDialog
			// 
			this.u_colorDialog.AnyColor = true;
			this.u_colorDialog.Color = System.Drawing.Color.Indigo;
			// 
			// u_transparentStatusBarCheckBox
			// 
			this.u_transparentStatusBarCheckBox.AccessibleDescription = null;
			this.u_transparentStatusBarCheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_transparentStatusBarCheckBox, "u_transparentStatusBarCheckBox");
			this.u_transparentStatusBarCheckBox.BackgroundImage = null;
			this.u_transparentStatusBarCheckBox.Font = null;
			this.u_transparentStatusBarCheckBox.Name = "u_transparentStatusBarCheckBox";
			this.u_transparentStatusBarCheckBox.UseVisualStyleBackColor = true;
			this.u_transparentStatusBarCheckBox.CheckedChanged += new System.EventHandler(this.u_transparentStatusBarCheckBox_CheckedChanged);
			// 
			// u_minimizeToSystemTrayCheckBox
			// 
			this.u_minimizeToSystemTrayCheckBox.AccessibleDescription = null;
			this.u_minimizeToSystemTrayCheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_minimizeToSystemTrayCheckBox, "u_minimizeToSystemTrayCheckBox");
			this.u_minimizeToSystemTrayCheckBox.BackgroundImage = null;
			this.u_minimizeToSystemTrayCheckBox.Font = null;
			this.u_minimizeToSystemTrayCheckBox.Name = "u_minimizeToSystemTrayCheckBox";
			this.u_minimizeToSystemTrayCheckBox.UseVisualStyleBackColor = true;
			this.u_minimizeToSystemTrayCheckBox.CheckedChanged += new System.EventHandler(this.u_minimizeToSystemTrayCheckBox_CheckedChanged);
			// 
			// u_chkKeyboardFormShouldFollowCursor
			// 
			this.u_chkKeyboardFormShouldFollowCursor.AccessibleDescription = null;
			this.u_chkKeyboardFormShouldFollowCursor.AccessibleName = null;
			resources.ApplyResources(this.u_chkKeyboardFormShouldFollowCursor, "u_chkKeyboardFormShouldFollowCursor");
			this.u_chkKeyboardFormShouldFollowCursor.BackgroundImage = null;
			this.u_chkKeyboardFormShouldFollowCursor.Font = null;
			this.u_chkKeyboardFormShouldFollowCursor.Name = "u_chkKeyboardFormShouldFollowCursor";
			this.u_chkKeyboardFormShouldFollowCursor.UseVisualStyleBackColor = true;
			this.u_chkKeyboardFormShouldFollowCursor.CheckedChanged += new System.EventHandler(this.u_chkKeyboardFormShouldFollowCursor_CheckedChanged);
			// 
			// u_backgroundColorLabel
			// 
			this.u_backgroundColorLabel.AccessibleDescription = null;
			this.u_backgroundColorLabel.AccessibleName = null;
			resources.ApplyResources(this.u_backgroundColorLabel, "u_backgroundColorLabel");
			this.u_backgroundColorLabel.Font = null;
			this.u_backgroundColorLabel.Name = "u_backgroundColorLabel";
			// 
			// u_backgroundColorComboBox
			// 
			this.u_backgroundColorComboBox.AccessibleDescription = null;
			this.u_backgroundColorComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_backgroundColorComboBox, "u_backgroundColorComboBox");
			this.u_backgroundColorComboBox.BackgroundImage = null;
			this.u_backgroundColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_backgroundColorComboBox.Font = null;
			this.u_backgroundColorComboBox.FormattingEnabled = true;
			this.u_backgroundColorComboBox.Items.AddRange(new object[] {
            resources.GetString("u_backgroundColorComboBox.Items"),
            resources.GetString("u_backgroundColorComboBox.Items1"),
            resources.GetString("u_backgroundColorComboBox.Items2")});
			this.u_backgroundColorComboBox.Name = "u_backgroundColorComboBox";
			this.u_backgroundColorComboBox.SelectedIndexChanged += new System.EventHandler(this.u_backgroundColorComboBox_SelectedIndexChanged);
			// 
			// u_textColorLabel
			// 
			this.u_textColorLabel.AccessibleDescription = null;
			this.u_textColorLabel.AccessibleName = null;
			resources.ApplyResources(this.u_textColorLabel, "u_textColorLabel");
			this.u_textColorLabel.Font = null;
			this.u_textColorLabel.Name = "u_textColorLabel";
			// 
			// u_textColorComboBox
			// 
			this.u_textColorComboBox.AccessibleDescription = null;
			this.u_textColorComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_textColorComboBox, "u_textColorComboBox");
			this.u_textColorComboBox.BackgroundImage = null;
			this.u_textColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_textColorComboBox.Font = null;
			this.u_textColorComboBox.FormattingEnabled = true;
			this.u_textColorComboBox.Items.AddRange(new object[] {
            resources.GetString("u_textColorComboBox.Items"),
            resources.GetString("u_textColorComboBox.Items1"),
            resources.GetString("u_textColorComboBox.Items2")});
			this.u_textColorComboBox.Name = "u_textColorComboBox";
			this.u_textColorComboBox.SelectedIndexChanged += new System.EventHandler(this.u_textColorComboBox_SelectedIndexChanged);
			// 
			// u_statusBarGroup
			// 
			this.u_statusBarGroup.AccessibleDescription = null;
			this.u_statusBarGroup.AccessibleName = null;
			resources.ApplyResources(this.u_statusBarGroup, "u_statusBarGroup");
			this.u_statusBarGroup.BackgroundImage = null;
			this.u_statusBarGroup.Controls.Add(this.u_transparentStatusBarCheckBox);
			this.u_statusBarGroup.Controls.Add(this.u_minimizeToSystemTrayCheckBox);
			this.u_statusBarGroup.Font = null;
			this.u_statusBarGroup.Name = "u_statusBarGroup";
			this.u_statusBarGroup.TabStop = false;
			// 
			// u_candidateWindowGroup
			// 
			this.u_candidateWindowGroup.AccessibleDescription = null;
			this.u_candidateWindowGroup.AccessibleName = null;
			resources.ApplyResources(this.u_candidateWindowGroup, "u_candidateWindowGroup");
			this.u_candidateWindowGroup.BackgroundImage = null;
			this.u_candidateWindowGroup.Controls.Add(this.u_highlightColorLabel);
			this.u_candidateWindowGroup.Controls.Add(this.u_highlightColorComboBox);
			this.u_candidateWindowGroup.Controls.Add(this.u_textColorLabel);
			this.u_candidateWindowGroup.Controls.Add(this.u_backgroundPatternCheckBox);
			this.u_candidateWindowGroup.Controls.Add(this.u_textColorComboBox);
			this.u_candidateWindowGroup.Controls.Add(this.u_backgroundColorComboBox);
			this.u_candidateWindowGroup.Controls.Add(this.u_backgroundColorLabel);
			this.u_candidateWindowGroup.Font = null;
			this.u_candidateWindowGroup.Name = "u_candidateWindowGroup";
			this.u_candidateWindowGroup.TabStop = false;
			// 
			// u_extraGroup
			// 
			this.u_extraGroup.AccessibleDescription = null;
			this.u_extraGroup.AccessibleName = null;
			resources.ApplyResources(this.u_extraGroup, "u_extraGroup");
			this.u_extraGroup.BackgroundImage = null;
			this.u_extraGroup.Controls.Add(this.u_beepCheckBox);
			this.u_extraGroup.Controls.Add(this.u_beepPanel);
			this.u_extraGroup.Controls.Add(this.u_chkKeyboardFormShouldFollowCursor);
			this.u_extraGroup.Font = null;
			this.u_extraGroup.Name = "u_extraGroup";
			this.u_extraGroup.TabStop = false;
			// 
			// u_removePluginButton
			// 
			this.u_removePluginButton.AccessibleDescription = null;
			this.u_removePluginButton.AccessibleName = null;
			resources.ApplyResources(this.u_removePluginButton, "u_removePluginButton");
			this.u_removePluginButton.BackgroundImage = null;
			this.u_removePluginButton.Font = null;
			this.u_removePluginButton.Name = "u_removePluginButton";
			this.u_removePluginButton.UseVisualStyleBackColor = true;
			this.u_removePluginButton.Click += new System.EventHandler(this.u_removePluginButton_Click);
			// 
			// u_pluginLabel
			// 
			this.u_pluginLabel.AccessibleDescription = null;
			this.u_pluginLabel.AccessibleName = null;
			resources.ApplyResources(this.u_pluginLabel, "u_pluginLabel");
			this.u_pluginLabel.Font = null;
			this.u_pluginLabel.Name = "u_pluginLabel";
			// 
			// u_pluginComboBox
			// 
			this.u_pluginComboBox.AccessibleDescription = null;
			this.u_pluginComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_pluginComboBox, "u_pluginComboBox");
			this.u_pluginComboBox.BackgroundImage = null;
			this.u_pluginComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_pluginComboBox.Font = null;
			this.u_pluginComboBox.FormattingEnabled = true;
			this.u_pluginComboBox.Name = "u_pluginComboBox";
			this.u_pluginComboBox.SelectedIndexChanged += new System.EventHandler(this.u_pluginComboBox_SelectedIndexChanged);
			// 
			// PanelMisc
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.u_removePluginButton);
			this.Controls.Add(this.u_pluginLabel);
			this.Controls.Add(this.u_extraGroup);
			this.Controls.Add(this.u_pluginComboBox);
			this.Controls.Add(this.u_candidateWindowGroup);
			this.Controls.Add(this.u_statusBarGroup);
			this.Controls.Add(u_labelTitle);
			this.Font = null;
			this.Name = "PanelMisc";
			this.u_beepPanel.ResumeLayout(false);
			this.u_beepPanel.PerformLayout();
			this.u_statusBarGroup.ResumeLayout(false);
			this.u_statusBarGroup.PerformLayout();
			this.u_candidateWindowGroup.ResumeLayout(false);
			this.u_candidateWindowGroup.PerformLayout();
			this.u_extraGroup.ResumeLayout(false);
			this.u_extraGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox u_beepCheckBox;
        private System.Windows.Forms.Panel u_beepPanel;
        private System.Windows.Forms.RadioButton u_radioDefaultSound;
        private System.Windows.Forms.RadioButton u_radioCustomizedSound;
        private System.Windows.Forms.Button u_testSoundButton;
        private System.Windows.Forms.ComboBox u_soundListComboBox;
        private System.Windows.Forms.Label u_highlightColorLabel;
        private System.Windows.Forms.ComboBox u_highlightColorComboBox;
        private System.Windows.Forms.CheckBox u_backgroundPatternCheckBox;
        private System.Windows.Forms.ColorDialog u_colorDialog;
        private System.Windows.Forms.CheckBox u_transparentStatusBarCheckBox;
        private System.Windows.Forms.CheckBox u_minimizeToSystemTrayCheckBox;
        private System.Windows.Forms.CheckBox u_chkKeyboardFormShouldFollowCursor;
        private System.Windows.Forms.Label u_backgroundColorLabel;
        private System.Windows.Forms.ComboBox u_backgroundColorComboBox;
        private System.Windows.Forms.Label u_textColorLabel;
        private System.Windows.Forms.ComboBox u_textColorComboBox;
        private System.Windows.Forms.GroupBox u_statusBarGroup;
        private System.Windows.Forms.GroupBox u_candidateWindowGroup;
        private System.Windows.Forms.GroupBox u_extraGroup;
        private System.Windows.Forms.Label u_pluginLabel;
        private System.Windows.Forms.ComboBox u_pluginComboBox;
        private System.Windows.Forms.Button u_removePluginButton;

    }
}
