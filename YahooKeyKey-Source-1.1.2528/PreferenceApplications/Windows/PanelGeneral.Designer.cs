/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelGeneral));
            this.u_titleLabel = new System.Windows.Forms.Label();
            this.u_shiftKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.u_ctrlBackslashCheckBox = new System.Windows.Forms.CheckBox();
            this.u_notifyCheckBox = new System.Windows.Forms.CheckBox();
            this.u_labelShorcut = new System.Windows.Forms.Label();
            this.u_shortcutComboBox = new System.Windows.Forms.ComboBox();
            this.u_moduleCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.u_moduleLabel = new System.Windows.Forms.Label();
            this.u_labelChineseToggle = new System.Windows.Forms.Label();
            this.u_labelRepeat = new System.Windows.Forms.Label();
            this.u_chineseConverterToggleComboBox = new System.Windows.Forms.ComboBox();
            this.u_repeatComboBox = new System.Windows.Forms.ComboBox();
            this.u_labelCtrlAlt1 = new System.Windows.Forms.Label();
            this.u_labelCtrlAlt2 = new System.Windows.Forms.Label();
            this.u_lookupLabel = new System.Windows.Forms.Label();
            this.u_reverseLookupComboBox = new System.Windows.Forms.ComboBox();
            this.u_shortcutGroup = new System.Windows.Forms.GroupBox();
            this.u_basicGroup = new System.Windows.Forms.GroupBox();
            this.u_capslockCheckBox = new System.Windows.Forms.CheckBox();
            this.u_shortcutGroup.SuspendLayout();
            this.u_basicGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // u_titleLabel
            // 
            this.u_titleLabel.AccessibleDescription = null;
            this.u_titleLabel.AccessibleName = null;
            resources.ApplyResources(this.u_titleLabel, "u_titleLabel");
            this.u_titleLabel.Font = null;
            this.u_titleLabel.Name = "u_titleLabel";
            // 
            // u_shiftKeyCheckBox
            // 
            this.u_shiftKeyCheckBox.AccessibleDescription = null;
            this.u_shiftKeyCheckBox.AccessibleName = null;
            resources.ApplyResources(this.u_shiftKeyCheckBox, "u_shiftKeyCheckBox");
            this.u_shiftKeyCheckBox.BackgroundImage = null;
            this.u_shiftKeyCheckBox.Font = null;
            this.u_shiftKeyCheckBox.Name = "u_shiftKeyCheckBox";
            this.u_shiftKeyCheckBox.UseVisualStyleBackColor = true;
            this.u_shiftKeyCheckBox.CheckedChanged += new System.EventHandler(this.u_chkAssociatedPhrases_CheckedChanged);
            // 
            // u_ctrlBackslashCheckBox
            // 
            this.u_ctrlBackslashCheckBox.AccessibleDescription = null;
            this.u_ctrlBackslashCheckBox.AccessibleName = null;
            resources.ApplyResources(this.u_ctrlBackslashCheckBox, "u_ctrlBackslashCheckBox");
            this.u_ctrlBackslashCheckBox.BackgroundImage = null;
            this.u_ctrlBackslashCheckBox.Font = null;
            this.u_ctrlBackslashCheckBox.Name = "u_ctrlBackslashCheckBox";
            this.u_ctrlBackslashCheckBox.UseVisualStyleBackColor = true;
            this.u_ctrlBackslashCheckBox.CheckedChanged += new System.EventHandler(this.u_chkCtrlBackslash_CheckedChanged);
            // 
            // u_notifyCheckBox
            // 
            this.u_notifyCheckBox.AccessibleDescription = null;
            this.u_notifyCheckBox.AccessibleName = null;
            resources.ApplyResources(this.u_notifyCheckBox, "u_notifyCheckBox");
            this.u_notifyCheckBox.BackgroundImage = null;
            this.u_notifyCheckBox.Font = null;
            this.u_notifyCheckBox.Name = "u_notifyCheckBox";
            this.u_notifyCheckBox.UseVisualStyleBackColor = true;
            this.u_notifyCheckBox.CheckedChanged += new System.EventHandler(this.u_chkNotify_CheckedChanged);
            // 
            // u_labelShorcut
            // 
            this.u_labelShorcut.AccessibleDescription = null;
            this.u_labelShorcut.AccessibleName = null;
            resources.ApplyResources(this.u_labelShorcut, "u_labelShorcut");
            this.u_labelShorcut.Font = null;
            this.u_labelShorcut.Name = "u_labelShorcut";
            // 
            // u_shortcutComboBox
            // 
            this.u_shortcutComboBox.AccessibleDescription = null;
            this.u_shortcutComboBox.AccessibleName = null;
            resources.ApplyResources(this.u_shortcutComboBox, "u_shortcutComboBox");
            this.u_shortcutComboBox.BackgroundImage = null;
            this.u_shortcutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.u_shortcutComboBox.Font = null;
            this.u_shortcutComboBox.FormattingEnabled = true;
            this.u_shortcutComboBox.Items.AddRange(new object[] {
            resources.GetString("u_shortcutComboBox.Items"),
            resources.GetString("u_shortcutComboBox.Items1")});
            this.u_shortcutComboBox.Name = "u_shortcutComboBox";
            this.u_shortcutComboBox.SelectedIndexChanged += new System.EventHandler(this.u_shortcut_SelectedIndexChanged);
            // 
            // u_moduleCheckListBox
            // 
            this.u_moduleCheckListBox.AccessibleDescription = null;
            this.u_moduleCheckListBox.AccessibleName = null;
            resources.ApplyResources(this.u_moduleCheckListBox, "u_moduleCheckListBox");
            this.u_moduleCheckListBox.BackgroundImage = null;
            this.u_moduleCheckListBox.CheckOnClick = true;
            this.u_moduleCheckListBox.Font = null;
            this.u_moduleCheckListBox.FormattingEnabled = true;
            this.u_moduleCheckListBox.Name = "u_moduleCheckListBox";
            this.u_moduleCheckListBox.UseCompatibleTextRendering = true;
            this.u_moduleCheckListBox.SelectedValueChanged += new System.EventHandler(this.u_moduleCheckListBox_SelectedValueChanged);
            // 
            // u_moduleLabel
            // 
            this.u_moduleLabel.AccessibleDescription = null;
            this.u_moduleLabel.AccessibleName = null;
            resources.ApplyResources(this.u_moduleLabel, "u_moduleLabel");
            this.u_moduleLabel.Font = null;
            this.u_moduleLabel.Name = "u_moduleLabel";
            // 
            // u_labelChineseToggle
            // 
            this.u_labelChineseToggle.AccessibleDescription = null;
            this.u_labelChineseToggle.AccessibleName = null;
            resources.ApplyResources(this.u_labelChineseToggle, "u_labelChineseToggle");
            this.u_labelChineseToggle.Font = null;
            this.u_labelChineseToggle.Name = "u_labelChineseToggle";
            // 
            // u_labelRepeat
            // 
            this.u_labelRepeat.AccessibleDescription = null;
            this.u_labelRepeat.AccessibleName = null;
            resources.ApplyResources(this.u_labelRepeat, "u_labelRepeat");
            this.u_labelRepeat.Font = null;
            this.u_labelRepeat.Name = "u_labelRepeat";
            // 
            // u_chineseConverterToggleComboBox
            // 
            this.u_chineseConverterToggleComboBox.AccessibleDescription = null;
            this.u_chineseConverterToggleComboBox.AccessibleName = null;
            resources.ApplyResources(this.u_chineseConverterToggleComboBox, "u_chineseConverterToggleComboBox");
            this.u_chineseConverterToggleComboBox.BackgroundImage = null;
            this.u_chineseConverterToggleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.u_chineseConverterToggleComboBox.Font = null;
            this.u_chineseConverterToggleComboBox.FormattingEnabled = true;
            this.u_chineseConverterToggleComboBox.Name = "u_chineseConverterToggleComboBox";
            this.u_chineseConverterToggleComboBox.SelectedIndexChanged += new System.EventHandler(this.u_comboChineseConverterToggle_SelectedIndexChanged);
            // 
            // u_repeatComboBox
            // 
            this.u_repeatComboBox.AccessibleDescription = null;
            this.u_repeatComboBox.AccessibleName = null;
            resources.ApplyResources(this.u_repeatComboBox, "u_repeatComboBox");
            this.u_repeatComboBox.BackgroundImage = null;
            this.u_repeatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.u_repeatComboBox.Font = null;
            this.u_repeatComboBox.FormattingEnabled = true;
            this.u_repeatComboBox.Name = "u_repeatComboBox";
            this.u_repeatComboBox.SelectedIndexChanged += new System.EventHandler(this.u_comboRepeat_SelectedIndexChanged);
            // 
            // u_labelCtrlAlt1
            // 
            this.u_labelCtrlAlt1.AccessibleDescription = null;
            this.u_labelCtrlAlt1.AccessibleName = null;
            resources.ApplyResources(this.u_labelCtrlAlt1, "u_labelCtrlAlt1");
            this.u_labelCtrlAlt1.Font = null;
            this.u_labelCtrlAlt1.Name = "u_labelCtrlAlt1";
            // 
            // u_labelCtrlAlt2
            // 
            this.u_labelCtrlAlt2.AccessibleDescription = null;
            this.u_labelCtrlAlt2.AccessibleName = null;
            resources.ApplyResources(this.u_labelCtrlAlt2, "u_labelCtrlAlt2");
            this.u_labelCtrlAlt2.Font = null;
            this.u_labelCtrlAlt2.Name = "u_labelCtrlAlt2";
            // 
            // u_lookupLabel
            // 
            this.u_lookupLabel.AccessibleDescription = null;
            this.u_lookupLabel.AccessibleName = null;
            resources.ApplyResources(this.u_lookupLabel, "u_lookupLabel");
            this.u_lookupLabel.Font = null;
            this.u_lookupLabel.Name = "u_lookupLabel";
            // 
            // u_reverseLookupComboBox
            // 
            this.u_reverseLookupComboBox.AccessibleDescription = null;
            this.u_reverseLookupComboBox.AccessibleName = null;
            resources.ApplyResources(this.u_reverseLookupComboBox, "u_reverseLookupComboBox");
            this.u_reverseLookupComboBox.BackgroundImage = null;
            this.u_reverseLookupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.u_reverseLookupComboBox.Font = null;
            this.u_reverseLookupComboBox.FormattingEnabled = true;
            this.u_reverseLookupComboBox.Items.AddRange(new object[] {
            resources.GetString("u_reverseLookupComboBox.Items"),
            resources.GetString("u_reverseLookupComboBox.Items1"),
            resources.GetString("u_reverseLookupComboBox.Items2"),
            resources.GetString("u_reverseLookupComboBox.Items3")});
            this.u_reverseLookupComboBox.Name = "u_reverseLookupComboBox";
            this.u_reverseLookupComboBox.SelectedIndexChanged += new System.EventHandler(this.u_reverseLookupComboBox_SelectedIndexChanged);
            // 
            // u_shortcutGroup
            // 
            this.u_shortcutGroup.AccessibleDescription = null;
            this.u_shortcutGroup.AccessibleName = null;
            resources.ApplyResources(this.u_shortcutGroup, "u_shortcutGroup");
            this.u_shortcutGroup.BackgroundImage = null;
            this.u_shortcutGroup.Controls.Add(this.u_labelShorcut);
            this.u_shortcutGroup.Controls.Add(this.u_shortcutComboBox);
            this.u_shortcutGroup.Controls.Add(this.u_labelChineseToggle);
            this.u_shortcutGroup.Controls.Add(this.u_labelCtrlAlt2);
            this.u_shortcutGroup.Controls.Add(this.u_labelRepeat);
            this.u_shortcutGroup.Controls.Add(this.u_labelCtrlAlt1);
            this.u_shortcutGroup.Controls.Add(this.u_chineseConverterToggleComboBox);
            this.u_shortcutGroup.Controls.Add(this.u_repeatComboBox);
            this.u_shortcutGroup.Font = null;
            this.u_shortcutGroup.Name = "u_shortcutGroup";
            this.u_shortcutGroup.TabStop = false;
            // 
            // u_basicGroup
            // 
            this.u_basicGroup.AccessibleDescription = null;
            this.u_basicGroup.AccessibleName = null;
            resources.ApplyResources(this.u_basicGroup, "u_basicGroup");
            this.u_basicGroup.BackgroundImage = null;
            this.u_basicGroup.Controls.Add(this.u_capslockCheckBox);
            this.u_basicGroup.Controls.Add(this.u_moduleLabel);
            this.u_basicGroup.Controls.Add(this.u_shiftKeyCheckBox);
            this.u_basicGroup.Controls.Add(this.u_ctrlBackslashCheckBox);
            this.u_basicGroup.Controls.Add(this.u_notifyCheckBox);
            this.u_basicGroup.Controls.Add(this.u_moduleCheckListBox);
            this.u_basicGroup.Font = null;
            this.u_basicGroup.Name = "u_basicGroup";
            this.u_basicGroup.TabStop = false;
            // 
            // u_capslockCheckBox
            // 
            this.u_capslockCheckBox.AccessibleDescription = null;
            this.u_capslockCheckBox.AccessibleName = null;
            resources.ApplyResources(this.u_capslockCheckBox, "u_capslockCheckBox");
            this.u_capslockCheckBox.BackgroundImage = null;
            this.u_capslockCheckBox.Font = null;
            this.u_capslockCheckBox.Name = "u_capslockCheckBox";
            this.u_capslockCheckBox.UseVisualStyleBackColor = true;
            this.u_capslockCheckBox.CheckedChanged += new System.EventHandler(this.u_capslockCheckBox_CheckedChanged);
            // 
            // PanelGeneral
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.u_basicGroup);
            this.Controls.Add(this.u_shortcutGroup);
            this.Controls.Add(this.u_reverseLookupComboBox);
            this.Controls.Add(this.u_lookupLabel);
            this.Controls.Add(this.u_titleLabel);
            this.Font = null;
            this.Name = "PanelGeneral";
            this.u_shortcutGroup.ResumeLayout(false);
            this.u_shortcutGroup.PerformLayout();
            this.u_basicGroup.ResumeLayout(false);
            this.u_basicGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label u_titleLabel;
        private System.Windows.Forms.CheckBox u_shiftKeyCheckBox;
        private System.Windows.Forms.CheckBox u_ctrlBackslashCheckBox;
        private System.Windows.Forms.CheckBox u_notifyCheckBox;
        private System.Windows.Forms.Label u_labelShorcut;
        private System.Windows.Forms.ComboBox u_shortcutComboBox;
        private System.Windows.Forms.CheckedListBox u_moduleCheckListBox;
        private System.Windows.Forms.Label u_moduleLabel;
        private System.Windows.Forms.Label u_labelChineseToggle;
        private System.Windows.Forms.Label u_labelRepeat;
        private System.Windows.Forms.ComboBox u_chineseConverterToggleComboBox;
        private System.Windows.Forms.ComboBox u_repeatComboBox;
        private System.Windows.Forms.Label u_labelCtrlAlt1;
        private System.Windows.Forms.Label u_labelCtrlAlt2;
        private System.Windows.Forms.Label u_lookupLabel;
        private System.Windows.Forms.ComboBox u_reverseLookupComboBox;
        private System.Windows.Forms.GroupBox u_shortcutGroup;
        private System.Windows.Forms.GroupBox u_basicGroup;
        private System.Windows.Forms.CheckBox u_capslockCheckBox;
    }
}
