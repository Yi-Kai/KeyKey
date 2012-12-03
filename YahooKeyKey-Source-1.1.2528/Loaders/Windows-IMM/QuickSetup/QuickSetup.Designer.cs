namespace QuickSetup
{
    partial class QuickSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickSetup));
            this.Finish = new System.Windows.Forms.Button();
            this.u_labelAsk = new System.Windows.Forms.Label();
            this.u_grpInputMethod = new System.Windows.Forms.Panel();
            this.u_radioOther = new System.Windows.Forms.RadioButton();
            this.u_radioSimplex = new System.Windows.Forms.RadioButton();
            this.u_radioCangjie = new System.Windows.Forms.RadioButton();
            this.u_radioTraditionalPhonetic = new System.Windows.Forms.RadioButton();
            this.u_radioSmartPhonetic = new System.Windows.Forms.RadioButton();
            this.u_checkHomepage = new System.Windows.Forms.CheckBox();
            this.u_checkSearchEngine = new System.Windows.Forms.CheckBox();
            this.u_checkInstallOthers = new System.Windows.Forms.CheckBox();
            this.u_grpInputMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // Finish
            // 
            resources.ApplyResources(this.Finish, "Finish");
            this.Finish.Name = "Finish";
            this.Finish.UseVisualStyleBackColor = true;
            this.Finish.Click += new System.EventHandler(this.Finish_Click);
            // 
            // u_labelAsk
            // 
            resources.ApplyResources(this.u_labelAsk, "u_labelAsk");
            this.u_labelAsk.Name = "u_labelAsk";
            // 
            // u_grpInputMethod
            // 
            this.u_grpInputMethod.Controls.Add(this.u_radioOther);
            this.u_grpInputMethod.Controls.Add(this.u_radioSimplex);
            this.u_grpInputMethod.Controls.Add(this.u_radioCangjie);
            this.u_grpInputMethod.Controls.Add(this.u_radioTraditionalPhonetic);
            this.u_grpInputMethod.Controls.Add(this.u_radioSmartPhonetic);
            this.u_grpInputMethod.Controls.Add(this.u_labelAsk);
            resources.ApplyResources(this.u_grpInputMethod, "u_grpInputMethod");
            this.u_grpInputMethod.Name = "u_grpInputMethod";
            // 
            // u_radioOther
            // 
            resources.ApplyResources(this.u_radioOther, "u_radioOther");
            this.u_radioOther.Name = "u_radioOther";
            this.u_radioOther.TabStop = true;
            this.u_radioOther.UseVisualStyleBackColor = true;
            // 
            // u_radioSimplex
            // 
            resources.ApplyResources(this.u_radioSimplex, "u_radioSimplex");
            this.u_radioSimplex.Name = "u_radioSimplex";
            this.u_radioSimplex.TabStop = true;
            this.u_radioSimplex.UseVisualStyleBackColor = true;
            this.u_radioSimplex.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // u_radioCangjie
            // 
            resources.ApplyResources(this.u_radioCangjie, "u_radioCangjie");
            this.u_radioCangjie.Name = "u_radioCangjie";
            this.u_radioCangjie.TabStop = true;
            this.u_radioCangjie.UseVisualStyleBackColor = true;
            this.u_radioCangjie.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // u_radioTraditionalPhonetic
            // 
            resources.ApplyResources(this.u_radioTraditionalPhonetic, "u_radioTraditionalPhonetic");
            this.u_radioTraditionalPhonetic.Name = "u_radioTraditionalPhonetic";
            this.u_radioTraditionalPhonetic.TabStop = true;
            this.u_radioTraditionalPhonetic.UseVisualStyleBackColor = true;
            this.u_radioTraditionalPhonetic.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // u_radioSmartPhonetic
            // 
            resources.ApplyResources(this.u_radioSmartPhonetic, "u_radioSmartPhonetic");
            this.u_radioSmartPhonetic.Name = "u_radioSmartPhonetic";
            this.u_radioSmartPhonetic.TabStop = true;
            this.u_radioSmartPhonetic.UseVisualStyleBackColor = true;
            this.u_radioSmartPhonetic.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // u_checkHomepage
            // 
            resources.ApplyResources(this.u_checkHomepage, "u_checkHomepage");
            this.u_checkHomepage.Checked = true;
            this.u_checkHomepage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.u_checkHomepage.Name = "u_checkHomepage";
            this.u_checkHomepage.UseVisualStyleBackColor = true;
            // 
            // u_checkSearchEngine
            // 
            resources.ApplyResources(this.u_checkSearchEngine, "u_checkSearchEngine");
            this.u_checkSearchEngine.Checked = true;
            this.u_checkSearchEngine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.u_checkSearchEngine.Name = "u_checkSearchEngine";
            this.u_checkSearchEngine.UseVisualStyleBackColor = true;
            // 
            // u_checkInstallOthers
            // 
            resources.ApplyResources(this.u_checkInstallOthers, "u_checkInstallOthers");
            this.u_checkInstallOthers.Checked = true;
            this.u_checkInstallOthers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.u_checkInstallOthers.Name = "u_checkInstallOthers";
            this.u_checkInstallOthers.UseVisualStyleBackColor = true;
            // 
            // QuickSetup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.u_checkInstallOthers);
            this.Controls.Add(this.u_checkSearchEngine);
            this.Controls.Add(this.u_checkHomepage);
            this.Controls.Add(this.u_grpInputMethod);
            this.Controls.Add(this.Finish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickSetup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuickSetup_FormClosing);
            this.u_grpInputMethod.ResumeLayout(false);
            this.u_grpInputMethod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Finish;
        private System.Windows.Forms.Label u_labelAsk;
        private System.Windows.Forms.Panel u_grpInputMethod;
        private System.Windows.Forms.RadioButton u_radioSimplex;
        private System.Windows.Forms.RadioButton u_radioCangjie;
        private System.Windows.Forms.RadioButton u_radioTraditionalPhonetic;
        private System.Windows.Forms.RadioButton u_radioSmartPhonetic;
        private System.Windows.Forms.CheckBox u_checkHomepage;
        private System.Windows.Forms.CheckBox u_checkSearchEngine;
        private System.Windows.Forms.RadioButton u_radioOther;
        private System.Windows.Forms.CheckBox u_checkInstallOthers;
    }
}

