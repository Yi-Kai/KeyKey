/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelPhonetic
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelPhonetic));
			this.u_smartPhoneticGroup = new System.Windows.Forms.GroupBox();
			this.u_invisibleSmartLabel = new System.Windows.Forms.Label();
			this.u_smartPhonetickeyboardLayoutComboBox = new System.Windows.Forms.ComboBox();
			this.u_buferSizeNotelabel = new System.Windows.Forms.Label();
			this.u_bufferSizeUnitLabel = new System.Windows.Forms.Label();
			this.u_bufferSizeLabel = new System.Windows.Forms.Label();
			this.u_bufferSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.u_selectionKeyComboBox = new System.Windows.Forms.ComboBox();
			this.u_selectionKeyLabel = new System.Windows.Forms.Label();
			this.u_smartPhoneticExtraSettinglabel = new System.Windows.Forms.Label();
			this.u_smartPhoneticTypingLabel = new System.Windows.Forms.Label();
			this.u_clearWithEscCheckBox = new System.Windows.Forms.CheckBox();
			this.u_showCandidateWithSpaceCheckBox = new System.Windows.Forms.CheckBox();
			this.u_smartPhoneticKeyboardLayoutLabel = new System.Windows.Forms.Label();
			this.u_smartPhoneticNonBig5CheckBox = new System.Windows.Forms.CheckBox();
			this.u_titleLabel = new System.Windows.Forms.Label();
			this.u_traditionalPhoneticGroup = new System.Windows.Forms.GroupBox();
			this.u_invisibleTraditionalLabel = new System.Windows.Forms.Label();
			this.u_traditionalPhoneticKeyboardLayoutComboBox = new System.Windows.Forms.ComboBox();
			this.u_traditionalPhoneticExtraSettingLabel = new System.Windows.Forms.Label();
			this.u_traditionalPhoneticKeyboardLayoutLabel = new System.Windows.Forms.Label();
			this.u_traditionalPhoneticNonBig5CheckBox = new System.Windows.Forms.CheckBox();
			this.u_smartPhoneticGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.u_bufferSizeNumericUpDown)).BeginInit();
			this.u_traditionalPhoneticGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// u_smartPhoneticGroup
			// 
			this.u_smartPhoneticGroup.AccessibleDescription = null;
			this.u_smartPhoneticGroup.AccessibleName = null;
			resources.ApplyResources(this.u_smartPhoneticGroup, "u_smartPhoneticGroup");
			this.u_smartPhoneticGroup.BackgroundImage = null;
			this.u_smartPhoneticGroup.Controls.Add(this.u_invisibleSmartLabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_smartPhonetickeyboardLayoutComboBox);
			this.u_smartPhoneticGroup.Controls.Add(this.u_buferSizeNotelabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_bufferSizeUnitLabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_bufferSizeLabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_bufferSizeNumericUpDown);
			this.u_smartPhoneticGroup.Controls.Add(this.u_selectionKeyComboBox);
			this.u_smartPhoneticGroup.Controls.Add(this.u_selectionKeyLabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_smartPhoneticExtraSettinglabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_smartPhoneticTypingLabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_clearWithEscCheckBox);
			this.u_smartPhoneticGroup.Controls.Add(this.u_showCandidateWithSpaceCheckBox);
			this.u_smartPhoneticGroup.Controls.Add(this.u_smartPhoneticKeyboardLayoutLabel);
			this.u_smartPhoneticGroup.Controls.Add(this.u_smartPhoneticNonBig5CheckBox);
			this.u_smartPhoneticGroup.Font = null;
			this.u_smartPhoneticGroup.Name = "u_smartPhoneticGroup";
			this.u_smartPhoneticGroup.TabStop = false;
			// 
			// u_invisibleSmartLabel
			// 
			this.u_invisibleSmartLabel.AccessibleDescription = null;
			this.u_invisibleSmartLabel.AccessibleName = null;
			resources.ApplyResources(this.u_invisibleSmartLabel, "u_invisibleSmartLabel");
			this.u_invisibleSmartLabel.Font = null;
			this.u_invisibleSmartLabel.Name = "u_invisibleSmartLabel";
			this.u_invisibleSmartLabel.Click += new System.EventHandler(this.ShowExtraKeyboardLayouts);
			// 
			// u_smartPhonetickeyboardLayoutComboBox
			// 
			this.u_smartPhonetickeyboardLayoutComboBox.AccessibleDescription = null;
			this.u_smartPhonetickeyboardLayoutComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_smartPhonetickeyboardLayoutComboBox, "u_smartPhonetickeyboardLayoutComboBox");
			this.u_smartPhonetickeyboardLayoutComboBox.BackgroundImage = null;
			this.u_smartPhonetickeyboardLayoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_smartPhonetickeyboardLayoutComboBox.Font = null;
			this.u_smartPhonetickeyboardLayoutComboBox.FormattingEnabled = true;
			this.u_smartPhonetickeyboardLayoutComboBox.Items.AddRange(new object[] {
            resources.GetString("u_smartPhonetickeyboardLayoutComboBox.Items"),
            resources.GetString("u_smartPhonetickeyboardLayoutComboBox.Items1"),
            resources.GetString("u_smartPhonetickeyboardLayoutComboBox.Items2")});
			this.u_smartPhonetickeyboardLayoutComboBox.Name = "u_smartPhonetickeyboardLayoutComboBox";
			this.u_smartPhonetickeyboardLayoutComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeSmartPhoneticKeyboardLayout);
			// 
			// u_buferSizeNotelabel
			// 
			this.u_buferSizeNotelabel.AccessibleDescription = null;
			this.u_buferSizeNotelabel.AccessibleName = null;
			resources.ApplyResources(this.u_buferSizeNotelabel, "u_buferSizeNotelabel");
			this.u_buferSizeNotelabel.Font = null;
			this.u_buferSizeNotelabel.Name = "u_buferSizeNotelabel";
			// 
			// u_bufferSizeUnitLabel
			// 
			this.u_bufferSizeUnitLabel.AccessibleDescription = null;
			this.u_bufferSizeUnitLabel.AccessibleName = null;
			resources.ApplyResources(this.u_bufferSizeUnitLabel, "u_bufferSizeUnitLabel");
			this.u_bufferSizeUnitLabel.Font = null;
			this.u_bufferSizeUnitLabel.Name = "u_bufferSizeUnitLabel";
			// 
			// u_bufferSizeLabel
			// 
			this.u_bufferSizeLabel.AccessibleDescription = null;
			this.u_bufferSizeLabel.AccessibleName = null;
			resources.ApplyResources(this.u_bufferSizeLabel, "u_bufferSizeLabel");
			this.u_bufferSizeLabel.Font = null;
			this.u_bufferSizeLabel.Name = "u_bufferSizeLabel";
			// 
			// u_bufferSizeNumericUpDown
			// 
			this.u_bufferSizeNumericUpDown.AccessibleDescription = null;
			this.u_bufferSizeNumericUpDown.AccessibleName = null;
			resources.ApplyResources(this.u_bufferSizeNumericUpDown, "u_bufferSizeNumericUpDown");
			this.u_bufferSizeNumericUpDown.Font = null;
			this.u_bufferSizeNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.u_bufferSizeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.u_bufferSizeNumericUpDown.Name = "u_bufferSizeNumericUpDown";
			this.u_bufferSizeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.u_bufferSizeNumericUpDown.ValueChanged += new System.EventHandler(this.ChangeBufferSize);
			// 
			// u_selectionKeyComboBox
			// 
			this.u_selectionKeyComboBox.AccessibleDescription = null;
			this.u_selectionKeyComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_selectionKeyComboBox, "u_selectionKeyComboBox");
			this.u_selectionKeyComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("u_selectionKeyComboBox.AutoCompleteCustomSource"),
            resources.GetString("u_selectionKeyComboBox.AutoCompleteCustomSource1"),
            resources.GetString("u_selectionKeyComboBox.AutoCompleteCustomSource2")});
			this.u_selectionKeyComboBox.BackgroundImage = null;
			this.u_selectionKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_selectionKeyComboBox.Font = null;
			this.u_selectionKeyComboBox.FormattingEnabled = true;
			this.u_selectionKeyComboBox.Items.AddRange(new object[] {
            resources.GetString("u_selectionKeyComboBox.Items"),
            resources.GetString("u_selectionKeyComboBox.Items1"),
            resources.GetString("u_selectionKeyComboBox.Items2")});
			this.u_selectionKeyComboBox.Name = "u_selectionKeyComboBox";
			this.u_selectionKeyComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeSelectionKey);
			this.u_selectionKeyComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyInNewSelectionKey);
			// 
			// u_selectionKeyLabel
			// 
			this.u_selectionKeyLabel.AccessibleDescription = null;
			this.u_selectionKeyLabel.AccessibleName = null;
			resources.ApplyResources(this.u_selectionKeyLabel, "u_selectionKeyLabel");
			this.u_selectionKeyLabel.Font = null;
			this.u_selectionKeyLabel.Name = "u_selectionKeyLabel";
			this.u_selectionKeyLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowExtraSelectionKeySets);
			// 
			// u_smartPhoneticExtraSettinglabel
			// 
			this.u_smartPhoneticExtraSettinglabel.AccessibleDescription = null;
			this.u_smartPhoneticExtraSettinglabel.AccessibleName = null;
			resources.ApplyResources(this.u_smartPhoneticExtraSettinglabel, "u_smartPhoneticExtraSettinglabel");
			this.u_smartPhoneticExtraSettinglabel.Font = null;
			this.u_smartPhoneticExtraSettinglabel.Name = "u_smartPhoneticExtraSettinglabel";
			// 
			// u_smartPhoneticTypingLabel
			// 
			this.u_smartPhoneticTypingLabel.AccessibleDescription = null;
			this.u_smartPhoneticTypingLabel.AccessibleName = null;
			resources.ApplyResources(this.u_smartPhoneticTypingLabel, "u_smartPhoneticTypingLabel");
			this.u_smartPhoneticTypingLabel.Font = null;
			this.u_smartPhoneticTypingLabel.Name = "u_smartPhoneticTypingLabel";
			// 
			// u_clearWithEscCheckBox
			// 
			this.u_clearWithEscCheckBox.AccessibleDescription = null;
			this.u_clearWithEscCheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_clearWithEscCheckBox, "u_clearWithEscCheckBox");
			this.u_clearWithEscCheckBox.BackgroundImage = null;
			this.u_clearWithEscCheckBox.Font = null;
			this.u_clearWithEscCheckBox.Name = "u_clearWithEscCheckBox";
			this.u_clearWithEscCheckBox.UseVisualStyleBackColor = true;
			this.u_clearWithEscCheckBox.CheckedChanged += new System.EventHandler(this.ChangeClearWithEscCheckBox);
			// 
			// u_showCandidateWithSpaceCheckBox
			// 
			this.u_showCandidateWithSpaceCheckBox.AccessibleDescription = null;
			this.u_showCandidateWithSpaceCheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_showCandidateWithSpaceCheckBox, "u_showCandidateWithSpaceCheckBox");
			this.u_showCandidateWithSpaceCheckBox.BackgroundImage = null;
			this.u_showCandidateWithSpaceCheckBox.Font = null;
			this.u_showCandidateWithSpaceCheckBox.Name = "u_showCandidateWithSpaceCheckBox";
			this.u_showCandidateWithSpaceCheckBox.UseVisualStyleBackColor = true;
			this.u_showCandidateWithSpaceCheckBox.CheckedChanged += new System.EventHandler(this.ChangeShowCandidateWithSpaceCheckBox);
			// 
			// u_smartPhoneticKeyboardLayoutLabel
			// 
			this.u_smartPhoneticKeyboardLayoutLabel.AccessibleDescription = null;
			this.u_smartPhoneticKeyboardLayoutLabel.AccessibleName = null;
			resources.ApplyResources(this.u_smartPhoneticKeyboardLayoutLabel, "u_smartPhoneticKeyboardLayoutLabel");
			this.u_smartPhoneticKeyboardLayoutLabel.Font = null;
			this.u_smartPhoneticKeyboardLayoutLabel.Name = "u_smartPhoneticKeyboardLayoutLabel";
			// 
			// u_smartPhoneticNonBig5CheckBox
			// 
			this.u_smartPhoneticNonBig5CheckBox.AccessibleDescription = null;
			this.u_smartPhoneticNonBig5CheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_smartPhoneticNonBig5CheckBox, "u_smartPhoneticNonBig5CheckBox");
			this.u_smartPhoneticNonBig5CheckBox.BackgroundImage = null;
			this.u_smartPhoneticNonBig5CheckBox.Font = null;
			this.u_smartPhoneticNonBig5CheckBox.Name = "u_smartPhoneticNonBig5CheckBox";
			this.u_smartPhoneticNonBig5CheckBox.UseVisualStyleBackColor = true;
			this.u_smartPhoneticNonBig5CheckBox.CheckedChanged += new System.EventHandler(this.ChangeSmartPhoneticUseNonBig5);
			// 
			// u_titleLabel
			// 
			this.u_titleLabel.AccessibleDescription = null;
			this.u_titleLabel.AccessibleName = null;
			resources.ApplyResources(this.u_titleLabel, "u_titleLabel");
			this.u_titleLabel.Font = null;
			this.u_titleLabel.Name = "u_titleLabel";
			// 
			// u_traditionalPhoneticGroup
			// 
			this.u_traditionalPhoneticGroup.AccessibleDescription = null;
			this.u_traditionalPhoneticGroup.AccessibleName = null;
			resources.ApplyResources(this.u_traditionalPhoneticGroup, "u_traditionalPhoneticGroup");
			this.u_traditionalPhoneticGroup.BackgroundImage = null;
			this.u_traditionalPhoneticGroup.Controls.Add(this.u_invisibleTraditionalLabel);
			this.u_traditionalPhoneticGroup.Controls.Add(this.u_traditionalPhoneticKeyboardLayoutComboBox);
			this.u_traditionalPhoneticGroup.Controls.Add(this.u_traditionalPhoneticExtraSettingLabel);
			this.u_traditionalPhoneticGroup.Controls.Add(this.u_traditionalPhoneticKeyboardLayoutLabel);
			this.u_traditionalPhoneticGroup.Controls.Add(this.u_traditionalPhoneticNonBig5CheckBox);
			this.u_traditionalPhoneticGroup.Font = null;
			this.u_traditionalPhoneticGroup.Name = "u_traditionalPhoneticGroup";
			this.u_traditionalPhoneticGroup.TabStop = false;
			// 
			// u_invisibleTraditionalLabel
			// 
			this.u_invisibleTraditionalLabel.AccessibleDescription = null;
			this.u_invisibleTraditionalLabel.AccessibleName = null;
			resources.ApplyResources(this.u_invisibleTraditionalLabel, "u_invisibleTraditionalLabel");
			this.u_invisibleTraditionalLabel.Font = null;
			this.u_invisibleTraditionalLabel.Name = "u_invisibleTraditionalLabel";
			this.u_invisibleTraditionalLabel.Click += new System.EventHandler(this.ShowExtraKeyboardLayouts);
			// 
			// u_traditionalPhoneticKeyboardLayoutComboBox
			// 
			this.u_traditionalPhoneticKeyboardLayoutComboBox.AccessibleDescription = null;
			this.u_traditionalPhoneticKeyboardLayoutComboBox.AccessibleName = null;
			resources.ApplyResources(this.u_traditionalPhoneticKeyboardLayoutComboBox, "u_traditionalPhoneticKeyboardLayoutComboBox");
			this.u_traditionalPhoneticKeyboardLayoutComboBox.BackgroundImage = null;
			this.u_traditionalPhoneticKeyboardLayoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.u_traditionalPhoneticKeyboardLayoutComboBox.Font = null;
			this.u_traditionalPhoneticKeyboardLayoutComboBox.FormattingEnabled = true;
			this.u_traditionalPhoneticKeyboardLayoutComboBox.Items.AddRange(new object[] {
            resources.GetString("u_traditionalPhoneticKeyboardLayoutComboBox.Items"),
            resources.GetString("u_traditionalPhoneticKeyboardLayoutComboBox.Items1"),
            resources.GetString("u_traditionalPhoneticKeyboardLayoutComboBox.Items2")});
			this.u_traditionalPhoneticKeyboardLayoutComboBox.Name = "u_traditionalPhoneticKeyboardLayoutComboBox";
			this.u_traditionalPhoneticKeyboardLayoutComboBox.SelectedIndexChanged += new System.EventHandler(this.ChangeTraditionalPhoneticKeyboardLayout);
			// 
			// u_traditionalPhoneticExtraSettingLabel
			// 
			this.u_traditionalPhoneticExtraSettingLabel.AccessibleDescription = null;
			this.u_traditionalPhoneticExtraSettingLabel.AccessibleName = null;
			resources.ApplyResources(this.u_traditionalPhoneticExtraSettingLabel, "u_traditionalPhoneticExtraSettingLabel");
			this.u_traditionalPhoneticExtraSettingLabel.Font = null;
			this.u_traditionalPhoneticExtraSettingLabel.Name = "u_traditionalPhoneticExtraSettingLabel";
			// 
			// u_traditionalPhoneticKeyboardLayoutLabel
			// 
			this.u_traditionalPhoneticKeyboardLayoutLabel.AccessibleDescription = null;
			this.u_traditionalPhoneticKeyboardLayoutLabel.AccessibleName = null;
			resources.ApplyResources(this.u_traditionalPhoneticKeyboardLayoutLabel, "u_traditionalPhoneticKeyboardLayoutLabel");
			this.u_traditionalPhoneticKeyboardLayoutLabel.Font = null;
			this.u_traditionalPhoneticKeyboardLayoutLabel.Name = "u_traditionalPhoneticKeyboardLayoutLabel";
			// 
			// u_traditionalPhoneticNonBig5CheckBox
			// 
			this.u_traditionalPhoneticNonBig5CheckBox.AccessibleDescription = null;
			this.u_traditionalPhoneticNonBig5CheckBox.AccessibleName = null;
			resources.ApplyResources(this.u_traditionalPhoneticNonBig5CheckBox, "u_traditionalPhoneticNonBig5CheckBox");
			this.u_traditionalPhoneticNonBig5CheckBox.BackgroundImage = null;
			this.u_traditionalPhoneticNonBig5CheckBox.Font = null;
			this.u_traditionalPhoneticNonBig5CheckBox.Name = "u_traditionalPhoneticNonBig5CheckBox";
			this.u_traditionalPhoneticNonBig5CheckBox.UseVisualStyleBackColor = true;
			this.u_traditionalPhoneticNonBig5CheckBox.CheckedChanged += new System.EventHandler(this.ChangeTraditionalPhoneticUseNonBig5);
			// 
			// PanelPhonetic
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.u_traditionalPhoneticGroup);
			this.Controls.Add(this.u_titleLabel);
			this.Controls.Add(this.u_smartPhoneticGroup);
			this.Font = null;
			this.Name = "PanelPhonetic";
			this.u_smartPhoneticGroup.ResumeLayout(false);
			this.u_smartPhoneticGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.u_bufferSizeNumericUpDown)).EndInit();
			this.u_traditionalPhoneticGroup.ResumeLayout(false);
			this.u_traditionalPhoneticGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox u_smartPhoneticGroup;
        private System.Windows.Forms.Label u_titleLabel;
        private System.Windows.Forms.GroupBox u_traditionalPhoneticGroup;
        private System.Windows.Forms.CheckBox u_smartPhoneticNonBig5CheckBox;
        private System.Windows.Forms.CheckBox u_traditionalPhoneticNonBig5CheckBox;
        private System.Windows.Forms.Label u_smartPhoneticKeyboardLayoutLabel;
        private System.Windows.Forms.Label u_traditionalPhoneticKeyboardLayoutLabel;
        private System.Windows.Forms.CheckBox u_showCandidateWithSpaceCheckBox;
        private System.Windows.Forms.CheckBox u_clearWithEscCheckBox;
        private System.Windows.Forms.Label u_smartPhoneticExtraSettinglabel;
        private System.Windows.Forms.Label u_smartPhoneticTypingLabel;
        private System.Windows.Forms.Label u_traditionalPhoneticExtraSettingLabel;
        private System.Windows.Forms.Label u_selectionKeyLabel;
        private System.Windows.Forms.ComboBox u_selectionKeyComboBox;
        private System.Windows.Forms.Label u_bufferSizeLabel;
        private System.Windows.Forms.NumericUpDown u_bufferSizeNumericUpDown;
        private System.Windows.Forms.Label u_bufferSizeUnitLabel;
        private System.Windows.Forms.Label u_buferSizeNotelabel;
        private System.Windows.Forms.ComboBox u_smartPhonetickeyboardLayoutComboBox;
        private System.Windows.Forms.ComboBox u_traditionalPhoneticKeyboardLayoutComboBox;
		private System.Windows.Forms.Label u_invisibleSmartLabel;
		private System.Windows.Forms.Label u_invisibleTraditionalLabel;

    }
}
