// [AUTO_HEADER]

namespace BaseIMEUI
{
    partial class BISymbolForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BISymbolForm));
			this.u_panelButtons = new System.Windows.Forms.Panel();
			this.u_toolStrip = new System.Windows.Forms.ToolStrip();
			this.u_symbolList = new System.Windows.Forms.ToolStripDropDownButton();
			this.u_ToolStripDropDown = new BaseIMEUI.BIToolStripDropDown(this.components);
			this.u_toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// u_panelButtons
			// 
			resources.ApplyResources(this.u_panelButtons, "u_panelButtons");
			this.u_panelButtons.Name = "u_panelButtons";
			// 
			// u_toolStrip
			// 
			this.u_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.u_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.u_symbolList});
			resources.ApplyResources(this.u_toolStrip, "u_toolStrip");
			this.u_toolStrip.Name = "u_toolStrip";
			this.u_toolStrip.ShowItemToolTips = false;
			// 
			// u_symbolList
			// 
			resources.ApplyResources(this.u_symbolList, "u_symbolList");
			this.u_symbolList.AutoToolTip = false;
			this.u_symbolList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.u_symbolList.DropDown = this.u_ToolStripDropDown;
			this.u_symbolList.Name = "u_symbolList";
			// 
			// u_ToolStripDropDown
			// 
			this.u_ToolStripDropDown.DropShadowEnabled = false;
			this.u_ToolStripDropDown.Name = "u_ToolStripDropDown";
			this.u_ToolStripDropDown.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			resources.ApplyResources(this.u_ToolStripDropDown, "u_ToolStripDropDown");
			// 
			// BISymbolForm
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.u_toolStrip);
			this.Controls.Add(this.u_panelButtons);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BISymbolForm";
			this.u_toolStrip.ResumeLayout(false);
			this.u_toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel u_panelButtons;
        private System.Windows.Forms.ToolStrip u_toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton u_symbolList;
		private BIToolStripDropDown u_ToolStripDropDown;


    }
}

