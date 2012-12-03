/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelCangjie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelCangjie));
            this.u_titleLabel = new System.Windows.Forms.Label();
            this.u_typingGroup = new System.Windows.Forms.GroupBox();
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox = new System.Windows.Forms.CheckBox();
            this.u_noteLabel = new System.Windows.Forms.Label();
            this.u_autoComposeCheckbox = new System.Windows.Forms.CheckBox();
            this.u_clearIfErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.u_useDynamicFrequencyCheckBox = new System.Windows.Forms.CheckBox();
            this.u_extraGroup = new System.Windows.Forms.GroupBox();
            this.u_nonBig5CheckBox = new System.Windows.Forms.CheckBox();
            this.u_punctuationStyleGroup = new System.Windows.Forms.GroupBox();
            this.u_radioHalf = new System.Windows.Forms.RadioButton();
            this.u_radioMix = new System.Windows.Forms.RadioButton();
            this.u_radioFull = new System.Windows.Forms.RadioButton();
            this.u_typingGroup.SuspendLayout();
            this.u_extraGroup.SuspendLayout();
            this.u_punctuationStyleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // u_titleLabel
            // 
            resources.ApplyResources(this.u_titleLabel, "u_titleLabel");
            this.u_titleLabel.Name = "u_titleLabel";
            // 
            // u_typingGroup
            // 
            this.u_typingGroup.Controls.Add(this.u_shouldCommitAtMaximumRadicalLengthCheckBox);
            this.u_typingGroup.Controls.Add(this.u_noteLabel);
            this.u_typingGroup.Controls.Add(this.u_autoComposeCheckbox);
            this.u_typingGroup.Controls.Add(this.u_clearIfErrorCheckBox);
            this.u_typingGroup.Controls.Add(this.u_useDynamicFrequencyCheckBox);
            resources.ApplyResources(this.u_typingGroup, "u_typingGroup");
            this.u_typingGroup.Name = "u_typingGroup";
            this.u_typingGroup.TabStop = false;
            // 
            // u_shouldCommitAtMaximumRadicalLengthCheckBox
            // 
            resources.ApplyResources(this.u_shouldCommitAtMaximumRadicalLengthCheckBox, "u_shouldCommitAtMaximumRadicalLengthCheckBox");
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox.Name = "u_shouldCommitAtMaximumRadicalLengthCheckBox";
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox.UseVisualStyleBackColor = true;
            this.u_shouldCommitAtMaximumRadicalLengthCheckBox.CheckedChanged += new System.EventHandler(this.u_shouldCommitAtMaximumRadicalLengthCheckBox_CheckedChanged);
            // 
            // u_noteLabel
            // 
            resources.ApplyResources(this.u_noteLabel, "u_noteLabel");
            this.u_noteLabel.Name = "u_noteLabel";
            // 
            // u_autoComposeCheckbox
            // 
            resources.ApplyResources(this.u_autoComposeCheckbox, "u_autoComposeCheckbox");
            this.u_autoComposeCheckbox.Name = "u_autoComposeCheckbox";
            this.u_autoComposeCheckbox.UseVisualStyleBackColor = true;
            this.u_autoComposeCheckbox.CheckedChanged += new System.EventHandler(this.toggleComposeWhenTyping);
            // 
            // u_clearIfErrorCheckBox
            // 
            resources.ApplyResources(this.u_clearIfErrorCheckBox, "u_clearIfErrorCheckBox");
            this.u_clearIfErrorCheckBox.Name = "u_clearIfErrorCheckBox";
            this.u_clearIfErrorCheckBox.UseVisualStyleBackColor = true;
            this.u_clearIfErrorCheckBox.CheckedChanged += new System.EventHandler(this.ToggleClearRadicalsIfError);
            // 
            // u_useDynamicFrequencyCheckBox
            // 
            resources.ApplyResources(this.u_useDynamicFrequencyCheckBox, "u_useDynamicFrequencyCheckBox");
            this.u_useDynamicFrequencyCheckBox.Name = "u_useDynamicFrequencyCheckBox";
            this.u_useDynamicFrequencyCheckBox.UseVisualStyleBackColor = true;
            this.u_useDynamicFrequencyCheckBox.CheckedChanged += new System.EventHandler(this.toggleUseDynamicFrequency);
            // 
            // u_extraGroup
            // 
            this.u_extraGroup.Controls.Add(this.u_nonBig5CheckBox);
            resources.ApplyResources(this.u_extraGroup, "u_extraGroup");
            this.u_extraGroup.Name = "u_extraGroup";
            this.u_extraGroup.TabStop = false;
            // 
            // u_nonBig5CheckBox
            // 
            resources.ApplyResources(this.u_nonBig5CheckBox, "u_nonBig5CheckBox");
            this.u_nonBig5CheckBox.Name = "u_nonBig5CheckBox";
            this.u_nonBig5CheckBox.UseVisualStyleBackColor = true;
            this.u_nonBig5CheckBox.CheckedChanged += new System.EventHandler(this.ToggleShouldUseAllUnicodePlanes);
            // 
            // u_punctuationStyleGroup
            // 
            this.u_punctuationStyleGroup.Controls.Add(this.u_radioHalf);
            this.u_punctuationStyleGroup.Controls.Add(this.u_radioMix);
            this.u_punctuationStyleGroup.Controls.Add(this.u_radioFull);
            resources.ApplyResources(this.u_punctuationStyleGroup, "u_punctuationStyleGroup");
            this.u_punctuationStyleGroup.Name = "u_punctuationStyleGroup";
            this.u_punctuationStyleGroup.TabStop = false;
            // 
            // u_radioHalf
            // 
            resources.ApplyResources(this.u_radioHalf, "u_radioHalf");
            this.u_radioHalf.Name = "u_radioHalf";
            this.u_radioHalf.TabStop = true;
            this.u_radioHalf.UseVisualStyleBackColor = true;
            this.u_radioHalf.CheckedChanged += new System.EventHandler(this.u_toogleOverrideTable);
            // 
            // u_radioMix
            // 
            resources.ApplyResources(this.u_radioMix, "u_radioMix");
            this.u_radioMix.Name = "u_radioMix";
            this.u_radioMix.TabStop = true;
            this.u_radioMix.UseVisualStyleBackColor = true;
            this.u_radioMix.CheckedChanged += new System.EventHandler(this.u_toogleOverrideTable);
            // 
            // u_radioFull
            // 
            resources.ApplyResources(this.u_radioFull, "u_radioFull");
            this.u_radioFull.Name = "u_radioFull";
            this.u_radioFull.TabStop = true;
            this.u_radioFull.UseVisualStyleBackColor = true;
            this.u_radioFull.CheckedChanged += new System.EventHandler(this.u_toogleOverrideTable);
            // 
            // PanelCangjie
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.u_punctuationStyleGroup);
            this.Controls.Add(this.u_extraGroup);
            this.Controls.Add(this.u_titleLabel);
            this.Controls.Add(this.u_typingGroup);
            this.Name = "PanelCangjie";
            resources.ApplyResources(this, "$this");
            this.u_typingGroup.ResumeLayout(false);
            this.u_typingGroup.PerformLayout();
            this.u_extraGroup.ResumeLayout(false);
            this.u_extraGroup.PerformLayout();
            this.u_punctuationStyleGroup.ResumeLayout(false);
            this.u_punctuationStyleGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label u_titleLabel;
        private System.Windows.Forms.GroupBox u_typingGroup;
        private System.Windows.Forms.GroupBox u_extraGroup;
        private System.Windows.Forms.CheckBox u_nonBig5CheckBox;
        private System.Windows.Forms.CheckBox u_autoComposeCheckbox;
        private System.Windows.Forms.CheckBox u_clearIfErrorCheckBox;
        private System.Windows.Forms.CheckBox u_useDynamicFrequencyCheckBox;
        private System.Windows.Forms.GroupBox u_punctuationStyleGroup;
        private System.Windows.Forms.RadioButton u_radioFull;
        private System.Windows.Forms.RadioButton u_radioHalf;
        private System.Windows.Forms.RadioButton u_radioMix;
        private System.Windows.Forms.Label u_noteLabel;
        private System.Windows.Forms.CheckBox u_shouldCommitAtMaximumRadicalLengthCheckBox;
    }
}
