/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class TakaoPreference
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakaoPreference));
            this.u_saveButton = new System.Windows.Forms.Button();
            this.u_cancelButton = new System.Windows.Forms.Button();
            this.u_settingsPanel = new System.Windows.Forms.Panel();
            this.u_applyButton = new System.Windows.Forms.Button();
            this.u_toolbar = new System.Windows.Forms.Panel();
            this.u_toolbarGeneral = new System.Windows.Forms.CheckBox();
            this.u_toolbarPhonetic = new System.Windows.Forms.CheckBox();
            this.u_toolbarCanjie = new System.Windows.Forms.CheckBox();
            this.u_toolbarSimplex = new System.Windows.Forms.CheckBox();
            this.u_toolbarGeneric = new System.Windows.Forms.CheckBox();
            this.u_toolbarPhrases = new System.Windows.Forms.CheckBox();
            this.u_toolbarMisc = new System.Windows.Forms.CheckBox();
            this.u_toolbarUpdate = new System.Windows.Forms.CheckBox();
            this.u_toolbarAbout = new System.Windows.Forms.CheckBox();
            this.u_toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // u_saveButton
            // 
            resources.ApplyResources(this.u_saveButton, "u_saveButton");
            this.u_saveButton.Name = "u_saveButton";
            this.u_saveButton.UseVisualStyleBackColor = true;
            this.u_saveButton.Click += new System.EventHandler(this.u_saveButton_Click);
            // 
            // u_cancelButton
            // 
            this.u_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.u_cancelButton, "u_cancelButton");
            this.u_cancelButton.Name = "u_cancelButton";
            this.u_cancelButton.UseVisualStyleBackColor = true;
            this.u_cancelButton.Click += new System.EventHandler(this.u_cancelButton_Click);
            // 
            // u_settingsPanel
            // 
            resources.ApplyResources(this.u_settingsPanel, "u_settingsPanel");
            this.u_settingsPanel.Name = "u_settingsPanel";
            // 
            // u_applyButton
            // 
            this.u_applyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.u_applyButton, "u_applyButton");
            this.u_applyButton.Name = "u_applyButton";
            this.u_applyButton.UseVisualStyleBackColor = true;
            this.u_applyButton.Click += new System.EventHandler(this.u_applyButton_Click);
            // 
            // u_toolbar
            // 
            this.u_toolbar.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.u_toolbar.Controls.Add(this.u_toolbarGeneral);
            this.u_toolbar.Controls.Add(this.u_toolbarPhonetic);
            this.u_toolbar.Controls.Add(this.u_toolbarCanjie);
            this.u_toolbar.Controls.Add(this.u_toolbarSimplex);
            this.u_toolbar.Controls.Add(this.u_toolbarGeneric);
            this.u_toolbar.Controls.Add(this.u_toolbarPhrases);
            this.u_toolbar.Controls.Add(this.u_toolbarMisc);
            this.u_toolbar.Controls.Add(this.u_toolbarUpdate);
            this.u_toolbar.Controls.Add(this.u_toolbarAbout);
            resources.ApplyResources(this.u_toolbar, "u_toolbar");
            this.u_toolbar.Name = "u_toolbar";
            // 
            // u_toolbarGeneral
            // 
            resources.ApplyResources(this.u_toolbarGeneral, "u_toolbarGeneral");
            this.u_toolbarGeneral.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarGeneral.FlatAppearance.BorderSize = 0;
            this.u_toolbarGeneral.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarGeneral.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarGeneral.Image = global::TakaoPreference.Properties.Resources.general;
            this.u_toolbarGeneral.Name = "u_toolbarGeneral";
            this.u_toolbarGeneral.UseVisualStyleBackColor = false;
            this.u_toolbarGeneral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarGeneral.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarPhonetic
            // 
            resources.ApplyResources(this.u_toolbarPhonetic, "u_toolbarPhonetic");
            this.u_toolbarPhonetic.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarPhonetic.FlatAppearance.BorderSize = 0;
            this.u_toolbarPhonetic.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarPhonetic.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarPhonetic.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarPhonetic.Image = global::TakaoPreference.Properties.Resources.zhuyin;
            this.u_toolbarPhonetic.Name = "u_toolbarPhonetic";
            this.u_toolbarPhonetic.UseVisualStyleBackColor = false;
            this.u_toolbarPhonetic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarPhonetic.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarCanjie
            // 
            resources.ApplyResources(this.u_toolbarCanjie, "u_toolbarCanjie");
            this.u_toolbarCanjie.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarCanjie.FlatAppearance.BorderSize = 0;
            this.u_toolbarCanjie.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarCanjie.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarCanjie.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarCanjie.Image = global::TakaoPreference.Properties.Resources.cangjie;
            this.u_toolbarCanjie.Name = "u_toolbarCanjie";
            this.u_toolbarCanjie.UseVisualStyleBackColor = false;
            this.u_toolbarCanjie.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarCanjie.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarSimplex
            // 
            resources.ApplyResources(this.u_toolbarSimplex, "u_toolbarSimplex");
            this.u_toolbarSimplex.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarSimplex.FlatAppearance.BorderSize = 0;
            this.u_toolbarSimplex.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarSimplex.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarSimplex.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarSimplex.Image = global::TakaoPreference.Properties.Resources.simplex;
            this.u_toolbarSimplex.Name = "u_toolbarSimplex";
            this.u_toolbarSimplex.UseVisualStyleBackColor = false;
            this.u_toolbarSimplex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarSimplex.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarGeneric
            // 
            resources.ApplyResources(this.u_toolbarGeneric, "u_toolbarGeneric");
            this.u_toolbarGeneric.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarGeneric.FlatAppearance.BorderSize = 0;
            this.u_toolbarGeneric.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarGeneric.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarGeneric.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarGeneric.Image = global::TakaoPreference.Properties.Resources.generic;
            this.u_toolbarGeneric.Name = "u_toolbarGeneric";
            this.u_toolbarGeneric.UseVisualStyleBackColor = false;
            this.u_toolbarGeneric.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarGeneric.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarPhrases
            // 
            resources.ApplyResources(this.u_toolbarPhrases, "u_toolbarPhrases");
            this.u_toolbarPhrases.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarPhrases.FlatAppearance.BorderSize = 0;
            this.u_toolbarPhrases.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarPhrases.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarPhrases.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarPhrases.Image = global::TakaoPreference.Properties.Resources.phrase;
            this.u_toolbarPhrases.Name = "u_toolbarPhrases";
            this.u_toolbarPhrases.UseVisualStyleBackColor = false;
            this.u_toolbarPhrases.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarPhrases.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarMisc
            // 
            resources.ApplyResources(this.u_toolbarMisc, "u_toolbarMisc");
            this.u_toolbarMisc.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarMisc.FlatAppearance.BorderSize = 0;
            this.u_toolbarMisc.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarMisc.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarMisc.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarMisc.Image = global::TakaoPreference.Properties.Resources.misc;
            this.u_toolbarMisc.Name = "u_toolbarMisc";
            this.u_toolbarMisc.UseVisualStyleBackColor = false;
            this.u_toolbarMisc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarMisc.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarUpdate
            // 
            resources.ApplyResources(this.u_toolbarUpdate, "u_toolbarUpdate");
            this.u_toolbarUpdate.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarUpdate.FlatAppearance.BorderSize = 0;
            this.u_toolbarUpdate.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarUpdate.Image = global::TakaoPreference.Properties.Resources.update;
            this.u_toolbarUpdate.Name = "u_toolbarUpdate";
            this.u_toolbarUpdate.UseVisualStyleBackColor = false;
            this.u_toolbarUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarUpdate.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // u_toolbarAbout
            // 
            resources.ApplyResources(this.u_toolbarAbout, "u_toolbarAbout");
            this.u_toolbarAbout.BackColor = System.Drawing.Color.Transparent;
            this.u_toolbarAbout.FlatAppearance.BorderSize = 0;
            this.u_toolbarAbout.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.u_toolbarAbout.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.u_toolbarAbout.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.u_toolbarAbout.Image = global::TakaoPreference.Properties.Resources.about;
            this.u_toolbarAbout.Name = "u_toolbarAbout";
            this.u_toolbarAbout.UseVisualStyleBackColor = false;
            this.u_toolbarAbout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTab);
            this.u_toolbarAbout.CheckedChanged += new System.EventHandler(this.ToolbarButtonsCheckedChanged);
            // 
            // TakaoPreference
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.u_toolbar);
            this.Controls.Add(this.u_applyButton);
            this.Controls.Add(this.u_cancelButton);
            this.Controls.Add(this.u_saveButton);
            this.Controls.Add(this.u_settingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TakaoPreference";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.u_toolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button u_saveButton;
        private System.Windows.Forms.Button u_cancelButton;
        private System.Windows.Forms.Panel u_settingsPanel;
        private System.Windows.Forms.Button u_applyButton;
        private System.Windows.Forms.Panel u_toolbar;
        private System.Windows.Forms.CheckBox u_toolbarAbout;
        private System.Windows.Forms.CheckBox u_toolbarMisc;
        private System.Windows.Forms.CheckBox u_toolbarUpdate;
        private System.Windows.Forms.CheckBox u_toolbarPhrases;
        private System.Windows.Forms.CheckBox u_toolbarSimplex;
        private System.Windows.Forms.CheckBox u_toolbarCanjie;
        private System.Windows.Forms.CheckBox u_toolbarPhonetic;
        private System.Windows.Forms.CheckBox u_toolbarGeneral;
        private System.Windows.Forms.CheckBox u_toolbarGeneric;
    }
}

