/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelGenericSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelGenericSettings));
            this.u_group = new System.Windows.Forms.GroupBox();
            this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.u_autoComposeCheckbox = new System.Windows.Forms.CheckBox();
            this.u_useDynamicFrequencyCheckBox = new System.Windows.Forms.CheckBox();
            this.u_clearIfErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox = new System.Windows.Forms.CheckBox();
            this.u_groupBasic = new System.Windows.Forms.GroupBox();
            this.u_numericMax = new System.Windows.Forms.NumericUpDown();
            this.u_labelMax = new System.Windows.Forms.Label();
            this.u_labelTitle = new System.Windows.Forms.Label();
            this.u_grpWildcard = new System.Windows.Forms.GroupBox();
            this.u_textMatchMore = new System.Windows.Forms.TextBox();
            this.u_labelMatchMore = new System.Windows.Forms.Label();
            this.u_textMatchOne = new System.Windows.Forms.TextBox();
            this.u_labelOneChar = new System.Windows.Forms.Label();
            this.u_group.SuspendLayout();
            this.u_groupBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.u_numericMax)).BeginInit();
            this.u_grpWildcard.SuspendLayout();
            this.SuspendLayout();
            // 
            // u_group
            // 
            this.u_group.Controls.Add(this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox);
            this.u_group.Controls.Add(this.u_autoComposeCheckbox);
            this.u_group.Controls.Add(this.u_useDynamicFrequencyCheckBox);
            this.u_group.Controls.Add(this.u_clearIfErrorCheckBox);
            this.u_group.Controls.Add(this.u_shouldCommitAtMaximumRadicalLengthCheckBox);
            resources.ApplyResources(this.u_group, "u_group");
            this.u_group.Name = "u_group";
            this.u_group.TabStop = false;
            // 
            // u_useSpaceAsFirstCandidateSelectionKeyCheckBox
            // 
            resources.ApplyResources(this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox, "u_useSpaceAsFirstCandidateSelectionKeyCheckBox");
            this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox.Name = "u_useSpaceAsFirstCandidateSelectionKeyCheckBox";
            this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox.UseVisualStyleBackColor = true;
            this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox.CheckedChanged += new System.EventHandler(this.u_useSpaceAsFirstCandidateSelectionKeyCheckBox_CheckedChanged);
            // 
            // u_autoComposeCheckbox
            // 
            resources.ApplyResources(this.u_autoComposeCheckbox, "u_autoComposeCheckbox");
            this.u_autoComposeCheckbox.Name = "u_autoComposeCheckbox";
            this.u_autoComposeCheckbox.UseVisualStyleBackColor = true;
            this.u_autoComposeCheckbox.CheckedChanged += new System.EventHandler(this.u_autoComposeCheckbox_CheckedChanged);
            // 
            // u_useDynamicFrequencyCheckBox
            // 
            resources.ApplyResources(this.u_useDynamicFrequencyCheckBox, "u_useDynamicFrequencyCheckBox");
            this.u_useDynamicFrequencyCheckBox.Name = "u_useDynamicFrequencyCheckBox";
            this.u_useDynamicFrequencyCheckBox.UseVisualStyleBackColor = true;
            this.u_useDynamicFrequencyCheckBox.CheckedChanged += new System.EventHandler(this.u_useDynamicFrequencyCheckBox_CheckedChanged);
            // 
            // u_clearIfErrorCheckBox
            // 
            resources.ApplyResources(this.u_clearIfErrorCheckBox, "u_clearIfErrorCheckBox");
            this.u_clearIfErrorCheckBox.Name = "u_clearIfErrorCheckBox";
            this.u_clearIfErrorCheckBox.UseVisualStyleBackColor = true;
            this.u_clearIfErrorCheckBox.CheckedChanged += new System.EventHandler(this.u_clearIfErrorCheckBox_CheckedChanged);
            // 
            // u_shouldCommitAtMaximumRadicalLengthCheckBox
            // 
            resources.ApplyResources(this.u_shouldCommitAtMaximumRadicalLengthCheckBox, "u_shouldCommitAtMaximumRadicalLengthCheckBox");
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Name = "u_shouldCommitAtMaximumRadicalLengthCheckBox";
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox.UseVisualStyleBackColor = true;
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox.CheckedChanged += new System.EventHandler(this.u_shouldCommitAtMaximumRadicalLengthCheckBox_CheckedChanged);
            // 
            // u_groupBasic
            // 
            this.u_groupBasic.Controls.Add(this.u_numericMax);
            this.u_groupBasic.Controls.Add(this.u_labelMax);
            resources.ApplyResources(this.u_groupBasic, "u_groupBasic");
            this.u_groupBasic.Name = "u_groupBasic";
            this.u_groupBasic.TabStop = false;
            // 
            // u_numericMax
            // 
            resources.ApplyResources(this.u_numericMax, "u_numericMax");
            this.u_numericMax.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.u_numericMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.u_numericMax.Name = "u_numericMax";
            this.u_numericMax.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.u_numericMax.ValueChanged += new System.EventHandler(this.u_numericMax_ValueChanged);
            // 
            // u_labelMax
            // 
            resources.ApplyResources(this.u_labelMax, "u_labelMax");
            this.u_labelMax.Name = "u_labelMax";
            // 
            // u_labelTitle
            // 
            resources.ApplyResources(this.u_labelTitle, "u_labelTitle");
            this.u_labelTitle.Name = "u_labelTitle";
            // 
            // u_grpWildcard
            // 
            this.u_grpWildcard.Controls.Add(this.u_textMatchMore);
            this.u_grpWildcard.Controls.Add(this.u_labelMatchMore);
            this.u_grpWildcard.Controls.Add(this.u_textMatchOne);
            this.u_grpWildcard.Controls.Add(this.u_labelOneChar);
            resources.ApplyResources(this.u_grpWildcard, "u_grpWildcard");
            this.u_grpWildcard.Name = "u_grpWildcard";
            this.u_grpWildcard.TabStop = false;
            // 
            // u_textMatchMore
            // 
            resources.ApplyResources(this.u_textMatchMore, "u_textMatchMore");
            this.u_textMatchMore.Name = "u_textMatchMore";
            this.u_textMatchMore.TextChanged += new System.EventHandler(this.u_textMatchMore_TextChanged);
            this.u_textMatchMore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.u_textMatchMore_MouseDown);
            // 
            // u_labelMatchMore
            // 
            resources.ApplyResources(this.u_labelMatchMore, "u_labelMatchMore");
            this.u_labelMatchMore.Name = "u_labelMatchMore";
            // 
            // u_textMatchOne
            // 
            resources.ApplyResources(this.u_textMatchOne, "u_textMatchOne");
            this.u_textMatchOne.Name = "u_textMatchOne";
            this.u_textMatchOne.TextChanged += new System.EventHandler(this.u_textMatchOne_TextChanged);
            this.u_textMatchOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.u_textMatchOne_MouseDown);
            // 
            // u_labelOneChar
            // 
            resources.ApplyResources(this.u_labelOneChar, "u_labelOneChar");
            this.u_labelOneChar.Name = "u_labelOneChar";
            // 
            // PanelGenericSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.u_grpWildcard);
            this.Controls.Add(this.u_labelTitle);
            this.Controls.Add(this.u_groupBasic);
            this.Controls.Add(this.u_group);
            this.Name = "PanelGenericSettings";
            resources.ApplyResources(this, "$this");
            this.u_group.ResumeLayout(false);
            this.u_group.PerformLayout();
            this.u_groupBasic.ResumeLayout(false);
            this.u_groupBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.u_numericMax)).EndInit();
            this.u_grpWildcard.ResumeLayout(false);
            this.u_grpWildcard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox u_group;
        private System.Windows.Forms.CheckBox u_useDynamicFrequencyCheckBox;
        private System.Windows.Forms.CheckBox u_clearIfErrorCheckBox;
        private System.Windows.Forms.CheckBox u_shouldCommitAtMaximumRadicalLengthCheckBox;
        private System.Windows.Forms.GroupBox u_groupBasic;
        private System.Windows.Forms.NumericUpDown u_numericMax;
        private System.Windows.Forms.Label u_labelMax;
        private System.Windows.Forms.Label u_labelTitle;
        private System.Windows.Forms.GroupBox u_grpWildcard;
        private System.Windows.Forms.Label u_labelOneChar;
        private System.Windows.Forms.TextBox u_textMatchOne;
        private System.Windows.Forms.TextBox u_textMatchMore;
        private System.Windows.Forms.Label u_labelMatchMore;
        private System.Windows.Forms.CheckBox u_autoComposeCheckbox;
        private System.Windows.Forms.CheckBox u_useSpaceAsFirstCandidateSelectionKeyCheckBox;
    }
}
