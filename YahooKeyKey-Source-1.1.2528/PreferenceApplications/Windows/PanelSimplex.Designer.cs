/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelSimplex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelSimplex));
            this.u_titleLabel = new System.Windows.Forms.Label();
            this.u_group = new System.Windows.Forms.GroupBox();
            this.u_noteLabel = new System.Windows.Forms.Label();
            this.u_autoComposeCheckbox = new System.Windows.Forms.CheckBox();
            this.u_clearIfErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.u_extraGroup = new System.Windows.Forms.GroupBox();
            this.u_nonBig5CheckBox = new System.Windows.Forms.CheckBox();
            this.u_group.SuspendLayout();
            this.u_extraGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // u_titleLabel
            // 
            resources.ApplyResources(this.u_titleLabel, "u_titleLabel");
            this.u_titleLabel.Name = "u_titleLabel";
            // 
            // u_group
            // 
            this.u_group.Controls.Add(this.u_noteLabel);
            this.u_group.Controls.Add(this.u_autoComposeCheckbox);
            this.u_group.Controls.Add(this.u_clearIfErrorCheckBox);
            resources.ApplyResources(this.u_group, "u_group");
            this.u_group.Name = "u_group";
            this.u_group.TabStop = false;
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
            this.u_autoComposeCheckbox.CheckedChanged += new System.EventHandler(this.ToggleAutoComposeWhenTyping);
            // 
            // u_clearIfErrorCheckBox
            // 
            resources.ApplyResources(this.u_clearIfErrorCheckBox, "u_clearIfErrorCheckBox");
            this.u_clearIfErrorCheckBox.Name = "u_clearIfErrorCheckBox";
            this.u_clearIfErrorCheckBox.UseVisualStyleBackColor = true;
            this.u_clearIfErrorCheckBox.CheckedChanged += new System.EventHandler(this.ToggleClearRadicalsIfError);
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
            // PanelSimplex
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.u_extraGroup);
            this.Controls.Add(this.u_titleLabel);
            this.Controls.Add(this.u_group);
            this.Name = "PanelSimplex";
            resources.ApplyResources(this, "$this");
            this.u_group.ResumeLayout(false);
            this.u_group.PerformLayout();
            this.u_extraGroup.ResumeLayout(false);
            this.u_extraGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label u_titleLabel;
        private System.Windows.Forms.GroupBox u_group;
        private System.Windows.Forms.GroupBox u_extraGroup;
        private System.Windows.Forms.CheckBox u_nonBig5CheckBox;
        private System.Windows.Forms.CheckBox u_autoComposeCheckbox;
        private System.Windows.Forms.CheckBox u_clearIfErrorCheckBox;
        private System.Windows.Forms.Label u_noteLabel;
    }
}
