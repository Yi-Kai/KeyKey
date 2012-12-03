// [AUTO_HEADER]

namespace BaseIMEUI
{
    partial class BISmileyPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BISmileyPanel));
			this.u_listBox = new System.Windows.Forms.ListBox();
			this.u_sendBtn = new System.Windows.Forms.Button();
			this.u_editButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// u_listBox
			// 
			this.u_listBox.AccessibleDescription = null;
			this.u_listBox.AccessibleName = null;
			resources.ApplyResources(this.u_listBox, "u_listBox");
			this.u_listBox.BackgroundImage = null;
			this.u_listBox.Name = "u_listBox";
			this.u_listBox.DoubleClick += new System.EventHandler(this.u_listBox_DoubleClick);
			// 
			// u_sendBtn
			// 
			this.u_sendBtn.AccessibleDescription = null;
			this.u_sendBtn.AccessibleName = null;
			resources.ApplyResources(this.u_sendBtn, "u_sendBtn");
			this.u_sendBtn.BackgroundImage = null;
			this.u_sendBtn.Font = null;
			this.u_sendBtn.Name = "u_sendBtn";
			this.u_sendBtn.UseVisualStyleBackColor = true;
			this.u_sendBtn.Click += new System.EventHandler(this.u_sendBtn_Click);
			// 
			// u_editButton
			// 
			this.u_editButton.AccessibleDescription = null;
			this.u_editButton.AccessibleName = null;
			resources.ApplyResources(this.u_editButton, "u_editButton");
			this.u_editButton.BackgroundImage = null;
			this.u_editButton.Font = null;
			this.u_editButton.Name = "u_editButton";
			this.u_editButton.UseVisualStyleBackColor = true;
			this.u_editButton.Click += new System.EventHandler(this.u_editButton_Click);
			// 
			// BISmileyPanel
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			resources.ApplyResources(this, "$this");
			this.BackgroundImage = null;
			this.Controls.Add(this.u_editButton);
			this.Controls.Add(this.u_sendBtn);
			this.Controls.Add(this.u_listBox);
			this.Font = null;
			this.MaximumSize = new System.Drawing.Size(250, 324);
			this.MinimumSize = new System.Drawing.Size(250, 276);
			this.Name = "BISmileyPanel";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox u_listBox;
        private System.Windows.Forms.Button u_sendBtn;
		private System.Windows.Forms.Button u_editButton;
    }
}
