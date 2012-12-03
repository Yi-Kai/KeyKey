// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
    /// <remarks>
    /// The About Window
    /// This Window shows the about information and provides hyper links to relative web pages.
    /// </remarks>
    public partial class BIAboutForm : BIForm
    {
        private BIAboutPanel u_aboutPanel;
        public BIAboutForm()
        {
            InitializeComponent();

            BIAboutPanel.c_icon = global::BaseIMEUI.Properties.Resources.yahoo;
            this.u_aboutPanel = new BIAboutPanel(this);
            this.u_panel.Controls.Add(this.u_aboutPanel);
        }
        /// <summary>
        /// The shadowed ShowDialog()
        /// </summary>
        public new void ShowDialog()
        {
            this.u_aboutPanel.UpdateVersionInfo();
            this.u_aboutPanel.UpdateWordCount();
            this.u_btnOK.Focus();
            base.ShowDialog();
        }
        /// <summary>
        /// Handle the click event on u_btnOK to hide the About Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void u_btnOK_Click(object sender, EventArgs e)
        {
            base.Hide();
        }
    }
}