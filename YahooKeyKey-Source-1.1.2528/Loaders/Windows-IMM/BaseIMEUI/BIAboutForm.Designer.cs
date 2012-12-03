// [AUTO_HEADER]

namespace BaseIMEUI
{
    partial class BIAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIAboutForm));
            this.u_btnOK = new System.Windows.Forms.Button();
            this.u_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // u_btnOK
            // 
            this.u_btnOK.AccessibleDescription = null;
            this.u_btnOK.AccessibleName = null;
            resources.ApplyResources(this.u_btnOK, "u_btnOK");
            this.u_btnOK.BackgroundImage = null;
            this.u_btnOK.Font = null;
            this.u_btnOK.Name = "u_btnOK";
            this.u_btnOK.UseVisualStyleBackColor = true;
            this.u_btnOK.Click += new System.EventHandler(this.u_btnOK_Click);
            // 
            // u_panel
            // 
            this.u_panel.AccessibleDescription = null;
            this.u_panel.AccessibleName = null;
            resources.ApplyResources(this.u_panel, "u_panel");
            this.u_panel.BackgroundImage = null;
            this.u_panel.Font = null;
            this.u_panel.Name = "u_panel";
            // 
            // BIAboutForm
            // 
            this.AcceptButton = this.u_btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.ControlBox = false;
            this.Controls.Add(this.u_panel);
            this.Controls.Add(this.u_btnOK);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BIAboutForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button u_btnOK;
        private System.Windows.Forms.Panel u_panel;
    }
}