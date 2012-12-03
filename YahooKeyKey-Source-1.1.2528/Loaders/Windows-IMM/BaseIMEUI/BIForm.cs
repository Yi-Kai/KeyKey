// [AUTO_HEADER]

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BaseIMEUI
{
    public partial class BIForm : Form
    {
        private Point lastPoint = new Point(0, 0);
        private bool m_isSetAlwaysOnTop;
        
        public BIForm()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TopLevel = true;
            this.TopMost = true;

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
        }

        #region Set window location.

		private delegate void SetLocationCallBack(Point newPoint);
        public void SetLocation(Point newPoint)
        {
			if (this.InvokeRequired)
			{
				this.Invoke(new SetLocationCallBack(SetLocation), newPoint);
			}
			else
			{
				if (newPoint.Equals(lastPoint))
					return;

				int x = newPoint.X;
				int y = newPoint.Y;

				if (x < 0)
					x = 0;
				if (y < 0)
					y = 0;

				Screen currentScreen;
				if (Screen.AllScreens.Length == 1)
					currentScreen = Screen.PrimaryScreen;
				else
					currentScreen = Screen.FromPoint(newPoint);

				if (x >= currentScreen.WorkingArea.Right)
					x = currentScreen.WorkingArea.Right - 10;
				if (y >= currentScreen.WorkingArea.Bottom)
					y = currentScreen.WorkingArea.Bottom - 10;

				this.Location = new System.Drawing.Point(x, y);
				lastPoint = newPoint;
			}
        }
		public void SetLocation(int x, int y)
		{
			this.SetLocation(new Point(x, y));
		}

        #endregion

        //@defgroup CreateParams overriding for a non-activatable form.
        //@{
        #region WS_EX_NOACTIVATE
        /// <summary>
        /// Sets CreateParams.ExStyle to WS_EX_NOACTIVATE to prevent it from
        /// gaining focus.
        /// Notices that this does NOT work on its child-controls; they have to
        /// be taken care separately.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= Win32FunctionHelper.ClassStyle.CS_IME
                    | Win32FunctionHelper.ClassStyle.CS_SAVEBITS;
                cp.ExStyle |=
                    Win32FunctionHelper.WindowExStyle.WS_EX_NOACTIVATE;
                return cp;
            }
        }
        #endregion
        //@}

        #region The shadowed Show()
        /// <summary>
        /// The shadowed Show() method.
        /// In order to be compatible with some softwares, we must apply some
 		/// extra property to the candidate window to let the canidate window
 		/// could be able to be on the top of other windows. For example,
 		/// Yahoo! Messanger and Yahoo! Widget may take over the focus and 
        /// cover the candidate window.
        /// </summary>
        public new void Show()
        {
            if (base.Visible == true)
                return;

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(this.Show));
            else {
                if (this.m_isSetAlwaysOnTop == false)
                {
                    Win32FunctionHelper.ShowWindowTopMost(base.Handle);
                    this.m_isSetAlwaysOnTop = true;
                }
                base.Visible = true;
            }
        }
        #endregion

        public void InvisibleShow()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(this.InvisibleShow));
            else
            {
                Win32FunctionHelper.ShowWindow(
                    base.Handle, Win32FunctionHelper.CmdShow.SW_HIDE);
            }

        }
        public new void Refresh()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.Refresh));
            }
            else
            {
                base.Refresh();
            }
        }
        public new void Hide()
        {
            if (base.Visible == false)
                return;

            if (this.InvokeRequired) 
			{
                this.Invoke(new MethodInvoker(this.Hide));
			}
            else
			{
				if (base.Visible == true)
                	base.Hide();
			}
        }
    }
}
