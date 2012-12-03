// [AUTO_HEADER]

namespace BaseIMEUI
{
    partial class BIDictionaryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIDictionaryForm));
            this.u_editMenuStrip = new BaseIMEUI.BIContextMenuStrip(this.components);
            this.u_copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.u_historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_historyMenuStrip = new BaseIMEUI.BIContextMenuStrip(this.components);
            this.u_fileMenuStrip = new BaseIMEUI.BIContextMenuStrip(this.components);
            this.u_closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.u_output = new System.Windows.Forms.WebBrowser();
            this.u_editMenuStrip.SuspendLayout();
            this.u_fileMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // u_editMenuStrip
            // 
            this.u_editMenuStrip.AccessibleDescription = null;
            this.u_editMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.u_editMenuStrip, "u_editMenuStrip");
            this.u_editMenuStrip.BackgroundImage = null;
            this.u_editMenuStrip.Font = null;
            this.u_editMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.u_copyToolStripMenuItem,
            this.u_selectAllToolStripMenuItem,
            this.u_toolStripSeparator,
            this.u_historyToolStripMenuItem});
            this.u_editMenuStrip.Name = "u_contextMenuStrip";
            // 
            // u_copyToolStripMenuItem
            // 
            this.u_copyToolStripMenuItem.AccessibleDescription = null;
            this.u_copyToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.u_copyToolStripMenuItem, "u_copyToolStripMenuItem");
            this.u_copyToolStripMenuItem.BackgroundImage = null;
            this.u_copyToolStripMenuItem.Name = "u_copyToolStripMenuItem";
            this.u_copyToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.u_copyToolStripMenuItem.Click += new System.EventHandler(this.CopyHTMLContent);
            // 
            // u_selectAllToolStripMenuItem
            // 
            this.u_selectAllToolStripMenuItem.AccessibleDescription = null;
            this.u_selectAllToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.u_selectAllToolStripMenuItem, "u_selectAllToolStripMenuItem");
            this.u_selectAllToolStripMenuItem.BackgroundImage = null;
            this.u_selectAllToolStripMenuItem.Name = "u_selectAllToolStripMenuItem";
            this.u_selectAllToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.u_selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllHTMLContent);
            // 
            // u_toolStripSeparator
            // 
            this.u_toolStripSeparator.AccessibleDescription = null;
            this.u_toolStripSeparator.AccessibleName = null;
            resources.ApplyResources(this.u_toolStripSeparator, "u_toolStripSeparator");
            this.u_toolStripSeparator.Name = "u_toolStripSeparator";
            // 
            // u_historyToolStripMenuItem
            // 
            this.u_historyToolStripMenuItem.AccessibleDescription = null;
            this.u_historyToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.u_historyToolStripMenuItem, "u_historyToolStripMenuItem");
            this.u_historyToolStripMenuItem.BackgroundImage = null;
            this.u_historyToolStripMenuItem.DropDown = this.u_historyMenuStrip;
            this.u_historyToolStripMenuItem.Name = "u_historyToolStripMenuItem";
            this.u_historyToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // u_historyMenuStrip
            // 
            this.u_historyMenuStrip.AccessibleDescription = null;
            this.u_historyMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.u_historyMenuStrip, "u_historyMenuStrip");
            this.u_historyMenuStrip.BackgroundImage = null;
            this.u_historyMenuStrip.Font = null;
            this.u_historyMenuStrip.Name = "u_historyContextMenu";
            this.u_historyMenuStrip.OwnerItem = this.u_historyToolStripMenuItem;
            // 
            // u_fileMenuStrip
            // 
            this.u_fileMenuStrip.AccessibleDescription = null;
            this.u_fileMenuStrip.AccessibleName = null;
            resources.ApplyResources(this.u_fileMenuStrip, "u_fileMenuStrip");
            this.u_fileMenuStrip.BackgroundImage = null;
            this.u_fileMenuStrip.Font = null;
            this.u_fileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.u_closeToolStripMenuItem});
            this.u_fileMenuStrip.Name = "u_fileMenuStrip";
            // 
            // u_closeToolStripMenuItem
            // 
            this.u_closeToolStripMenuItem.AccessibleDescription = null;
            this.u_closeToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.u_closeToolStripMenuItem, "u_closeToolStripMenuItem");
            this.u_closeToolStripMenuItem.BackgroundImage = null;
            this.u_closeToolStripMenuItem.Name = "u_closeToolStripMenuItem";
            this.u_closeToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.u_closeToolStripMenuItem.Click += new System.EventHandler(this.u_closeToolStripMenuItem_Click);
            // 
            // u_output
            // 
            this.u_output.AccessibleDescription = null;
            this.u_output.AccessibleName = null;
            resources.ApplyResources(this.u_output, "u_output");
            this.u_output.ContextMenuStrip = this.u_editMenuStrip;
            this.u_output.MinimumSize = new System.Drawing.Size(20, 20);
            this.u_output.Name = "u_output";
            // 
            // BIDictionaryForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.u_output);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BIDictionaryForm";
            this.u_editMenuStrip.ResumeLayout(false);
            this.u_fileMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private BaseIMEUI.BIContextMenuStrip u_historyMenuStrip;
        private BaseIMEUI.BIContextMenuStrip u_editMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem u_copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem u_selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator u_toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem u_historyToolStripMenuItem;
        private System.Windows.Forms.WebBrowser u_output;
        private BaseIMEUI.BIContextMenuStrip u_fileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem u_closeToolStripMenuItem;
    }
}

