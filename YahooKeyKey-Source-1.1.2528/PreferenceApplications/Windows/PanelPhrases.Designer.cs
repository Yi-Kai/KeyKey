/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

namespace TakaoPreference
{
    partial class PanelPhrases
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelPhrases));
			this.u_labelTitle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.u_btnImport = new System.Windows.Forms.Button();
			this.u_btnExport = new System.Windows.Forms.Button();
			this.u_intro = new System.Windows.Forms.Label();
			this.u_importDialog = new System.Windows.Forms.OpenFileDialog();
			this.u_exportDialog = new System.Windows.Forms.SaveFileDialog();
			this.u_editorButton = new System.Windows.Forms.Button();
			this.u_editSymbolButton = new System.Windows.Forms.Button();
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
			// label1
			// 
			this.label1.AccessibleDescription = null;
			this.label1.AccessibleName = null;
			resources.ApplyResources(this.label1, "label1");
			this.label1.Font = null;
			this.label1.Name = "label1";
			// 
			// u_btnImport
			// 
			this.u_btnImport.AccessibleDescription = null;
			this.u_btnImport.AccessibleName = null;
			resources.ApplyResources(this.u_btnImport, "u_btnImport");
			this.u_btnImport.BackgroundImage = null;
			this.u_btnImport.Font = null;
			this.u_btnImport.Name = "u_btnImport";
			this.u_btnImport.UseVisualStyleBackColor = true;
			this.u_btnImport.Click += new System.EventHandler(this.Import);
			// 
			// u_btnExport
			// 
			this.u_btnExport.AccessibleDescription = null;
			this.u_btnExport.AccessibleName = null;
			resources.ApplyResources(this.u_btnExport, "u_btnExport");
			this.u_btnExport.BackgroundImage = null;
			this.u_btnExport.Font = null;
			this.u_btnExport.Name = "u_btnExport";
			this.u_btnExport.UseVisualStyleBackColor = true;
			this.u_btnExport.Click += new System.EventHandler(this.Export);
			// 
			// u_intro
			// 
			this.u_intro.AccessibleDescription = null;
			this.u_intro.AccessibleName = null;
			resources.ApplyResources(this.u_intro, "u_intro");
			this.u_intro.Font = null;
			this.u_intro.Name = "u_intro";
			// 
			// u_importDialog
			// 
			this.u_importDialog.FileName = "database.txt";
			resources.ApplyResources(this.u_importDialog, "u_importDialog");
			// 
			// u_exportDialog
			// 
			this.u_exportDialog.DefaultExt = "txt";
			this.u_exportDialog.FileName = "database.txt";
			resources.ApplyResources(this.u_exportDialog, "u_exportDialog");
			// 
			// u_editorButton
			// 
			this.u_editorButton.AccessibleDescription = null;
			this.u_editorButton.AccessibleName = null;
			resources.ApplyResources(this.u_editorButton, "u_editorButton");
			this.u_editorButton.BackgroundImage = null;
			this.u_editorButton.Font = null;
			this.u_editorButton.Name = "u_editorButton";
			this.u_editorButton.UseVisualStyleBackColor = true;
			this.u_editorButton.Click += new System.EventHandler(this.LaunchPhraseEditor);
			// 
			// u_editSymbolButton
			// 
			this.u_editSymbolButton.AccessibleDescription = null;
			this.u_editSymbolButton.AccessibleName = null;
			resources.ApplyResources(this.u_editSymbolButton, "u_editSymbolButton");
			this.u_editSymbolButton.BackgroundImage = null;
			this.u_editSymbolButton.Font = null;
			this.u_editSymbolButton.Name = "u_editSymbolButton";
			this.u_editSymbolButton.UseVisualStyleBackColor = true;
			this.u_editSymbolButton.Click += new System.EventHandler(this.EditSymbols);
			// 
			// PanelPhrases
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.u_editSymbolButton);
			this.Controls.Add(this.u_editorButton);
			this.Controls.Add(this.u_intro);
			this.Controls.Add(this.u_btnExport);
			this.Controls.Add(this.u_btnImport);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.u_labelTitle);
			this.Font = null;
			this.Name = "PanelPhrases";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label u_labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button u_btnImport;
        private System.Windows.Forms.Button u_btnExport;
        private System.Windows.Forms.Label u_intro;
        private System.Windows.Forms.OpenFileDialog u_importDialog;
        private System.Windows.Forms.SaveFileDialog u_exportDialog;
        private System.Windows.Forms.Button u_editorButton;
		private System.Windows.Forms.Button u_editSymbolButton;

    }
}
