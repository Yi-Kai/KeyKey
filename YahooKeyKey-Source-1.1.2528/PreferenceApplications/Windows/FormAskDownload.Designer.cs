/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class FormAskDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAskDownload));
            this.u_Yes = new System.Windows.Forms.Button();
            this.u_No = new System.Windows.Forms.Button();
            this.u_chk = new System.Windows.Forms.CheckBox();
            this.u_title = new System.Windows.Forms.Label();
            this.u_browser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // u_Yes
            // 
            resources.ApplyResources(this.u_Yes, "u_Yes");
            this.u_Yes.Name = "u_Yes";
            this.u_Yes.UseVisualStyleBackColor = true;
            this.u_Yes.Click += new System.EventHandler(this.u_Yes_Click);
            // 
            // u_No
            // 
            this.u_No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.u_No, "u_No");
            this.u_No.Name = "u_No";
            this.u_No.UseVisualStyleBackColor = true;
            this.u_No.Click += new System.EventHandler(this.u_No_Click);
            // 
            // u_chk
            // 
            resources.ApplyResources(this.u_chk, "u_chk");
            this.u_chk.Name = "u_chk";
            this.u_chk.UseVisualStyleBackColor = true;
            // 
            // u_title
            // 
            resources.ApplyResources(this.u_title, "u_title");
            this.u_title.Name = "u_title";
            // 
            // u_browser
            // 
            this.u_browser.AllowWebBrowserDrop = false;
            this.u_browser.IsWebBrowserContextMenuEnabled = false;
            resources.ApplyResources(this.u_browser, "u_browser");
            this.u_browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.u_browser.Name = "u_browser";
            this.u_browser.TabStop = false;
            this.u_browser.WebBrowserShortcutsEnabled = false;
            // 
            // FormAskDownload
            // 
            this.AcceptButton = this.u_Yes;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.u_No;
            this.Controls.Add(this.u_browser);
            this.Controls.Add(this.u_title);
            this.Controls.Add(this.u_chk);
            this.Controls.Add(this.u_No);
            this.Controls.Add(this.u_Yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAskDownload";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button u_Yes;
        private System.Windows.Forms.Button u_No;
        private System.Windows.Forms.CheckBox u_chk;
        private System.Windows.Forms.Label u_title;
        private System.Windows.Forms.WebBrowser u_browser;
    }
}
