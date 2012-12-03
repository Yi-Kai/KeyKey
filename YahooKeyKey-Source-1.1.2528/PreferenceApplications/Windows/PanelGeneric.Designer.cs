/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelGeneric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelGeneric));
            this.u_modulesListBox = new System.Windows.Forms.ListBox();
            this.u_labelTitle = new System.Windows.Forms.Label();
            this.u_settingsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // u_modulesListBox
            // 
            this.u_modulesListBox.FormattingEnabled = true;
            resources.ApplyResources(this.u_modulesListBox, "u_modulesListBox");
            this.u_modulesListBox.Name = "u_modulesListBox";
            this.u_modulesListBox.SelectedIndexChanged += new System.EventHandler(this.ToggleActiveModuleSettingPane);
            // 
            // u_labelTitle
            // 
            resources.ApplyResources(this.u_labelTitle, "u_labelTitle");
            this.u_labelTitle.Name = "u_labelTitle";
            // 
            // u_settingsPanel
            // 
            resources.ApplyResources(this.u_settingsPanel, "u_settingsPanel");
            this.u_settingsPanel.Name = "u_settingsPanel";
            // 
            // PanelGeneric
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.u_settingsPanel);
            this.Controls.Add(this.u_labelTitle);
            this.Controls.Add(this.u_modulesListBox);
            this.Name = "PanelGeneric";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox u_modulesListBox;
        private System.Windows.Forms.Label u_labelTitle;
        private System.Windows.Forms.Panel u_settingsPanel;
    }
}
