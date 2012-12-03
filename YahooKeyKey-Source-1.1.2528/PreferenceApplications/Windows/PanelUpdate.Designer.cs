/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelUpdate));
            this.u_labelTitle = new System.Windows.Forms.Label();
            this.u_chkUpdateOnLaunch = new System.Windows.Forms.CheckBox();
            this.u_btnCheckNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // u_labelTitle
            // 
            this.u_labelTitle.AccessibleDescription = null;
            this.u_labelTitle.AccessibleName = null;
            resources.ApplyResources(this.u_labelTitle, "u_labelTitle");
            this.u_labelTitle.Font = null;
            this.u_labelTitle.Name = "u_labelTitle";
            // 
            // u_chkUpdateOnLaunch
            // 
            this.u_chkUpdateOnLaunch.AccessibleDescription = null;
            this.u_chkUpdateOnLaunch.AccessibleName = null;
            resources.ApplyResources(this.u_chkUpdateOnLaunch, "u_chkUpdateOnLaunch");
            this.u_chkUpdateOnLaunch.BackgroundImage = null;
            this.u_chkUpdateOnLaunch.Font = null;
            this.u_chkUpdateOnLaunch.Name = "u_chkUpdateOnLaunch";
            this.u_chkUpdateOnLaunch.UseVisualStyleBackColor = true;
            this.u_chkUpdateOnLaunch.CheckedChanged += new System.EventHandler(this.ChangeUpdateOnLaunch);
            // 
            // u_btnCheckNow
            // 
            this.u_btnCheckNow.AccessibleDescription = null;
            this.u_btnCheckNow.AccessibleName = null;
            resources.ApplyResources(this.u_btnCheckNow, "u_btnCheckNow");
            this.u_btnCheckNow.BackgroundImage = null;
            this.u_btnCheckNow.Font = null;
            this.u_btnCheckNow.Name = "u_btnCheckNow";
            this.u_btnCheckNow.UseVisualStyleBackColor = true;
            this.u_btnCheckNow.Click += new System.EventHandler(this.ClickCheckNow);
            // 
            // PanelUpdate
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.u_btnCheckNow);
            this.Controls.Add(this.u_chkUpdateOnLaunch);
            this.Controls.Add(this.u_labelTitle);
            this.Font = null;
            this.Name = "PanelUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label u_labelTitle;
        private System.Windows.Forms.CheckBox u_chkUpdateOnLaunch;
        private System.Windows.Forms.Button u_btnCheckNow;
    }
}
