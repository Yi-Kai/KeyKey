/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class FormDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDownload));
            this.u_progressBar = new System.Windows.Forms.ProgressBar();
            this.u_labelDownload = new System.Windows.Forms.Label();
            this.u_Btn = new System.Windows.Forms.Button();
            this.u_btnRetry = new System.Windows.Forms.Button();
            this.u_labelTitle = new System.Windows.Forms.Label();
            this.u_btnInstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // u_progressBar
            // 
            this.u_progressBar.AccessibleDescription = null;
            this.u_progressBar.AccessibleName = null;
            resources.ApplyResources(this.u_progressBar, "u_progressBar");
            this.u_progressBar.BackgroundImage = null;
            this.u_progressBar.Font = null;
            this.u_progressBar.Name = "u_progressBar";
            // 
            // u_labelDownload
            // 
            this.u_labelDownload.AccessibleDescription = null;
            this.u_labelDownload.AccessibleName = null;
            resources.ApplyResources(this.u_labelDownload, "u_labelDownload");
            this.u_labelDownload.Font = null;
            this.u_labelDownload.Name = "u_labelDownload";
            // 
            // u_Btn
            // 
            this.u_Btn.AccessibleDescription = null;
            this.u_Btn.AccessibleName = null;
            resources.ApplyResources(this.u_Btn, "u_Btn");
            this.u_Btn.BackgroundImage = null;
            this.u_Btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.u_Btn.Font = null;
            this.u_Btn.Name = "u_Btn";
            this.u_Btn.UseVisualStyleBackColor = true;
            this.u_Btn.Click += new System.EventHandler(this.u_Btn_Click);
            // 
            // u_btnRetry
            // 
            this.u_btnRetry.AccessibleDescription = null;
            this.u_btnRetry.AccessibleName = null;
            resources.ApplyResources(this.u_btnRetry, "u_btnRetry");
            this.u_btnRetry.BackgroundImage = null;
            this.u_btnRetry.Font = null;
            this.u_btnRetry.Name = "u_btnRetry";
            this.u_btnRetry.UseVisualStyleBackColor = true;
            this.u_btnRetry.Click += new System.EventHandler(this.u_btnRetry_Click);
            // 
            // u_labelTitle
            // 
            this.u_labelTitle.AccessibleDescription = null;
            this.u_labelTitle.AccessibleName = null;
            resources.ApplyResources(this.u_labelTitle, "u_labelTitle");
            this.u_labelTitle.Font = null;
            this.u_labelTitle.Name = "u_labelTitle";
            // 
            // u_btnInstall
            // 
            this.u_btnInstall.AccessibleDescription = null;
            this.u_btnInstall.AccessibleName = null;
            resources.ApplyResources(this.u_btnInstall, "u_btnInstall");
            this.u_btnInstall.BackgroundImage = null;
            this.u_btnInstall.Font = null;
            this.u_btnInstall.Name = "u_btnInstall";
            this.u_btnInstall.UseVisualStyleBackColor = true;
            this.u_btnInstall.Click += new System.EventHandler(this.u_btnInstall_Click);
            // 
            // FormDownload
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.CancelButton = this.u_Btn;
            this.Controls.Add(this.u_btnInstall);
            this.Controls.Add(this.u_labelTitle);
            this.Controls.Add(this.u_btnRetry);
            this.Controls.Add(this.u_Btn);
            this.Controls.Add(this.u_labelDownload);
            this.Controls.Add(this.u_progressBar);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormDownload";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar u_progressBar;
        private System.Windows.Forms.Label u_labelDownload;
        private System.Windows.Forms.Button u_Btn;
        private System.Windows.Forms.Button u_btnRetry;
        private System.Windows.Forms.Label u_labelTitle;
        private System.Windows.Forms.Button u_btnInstall;
    }
}

