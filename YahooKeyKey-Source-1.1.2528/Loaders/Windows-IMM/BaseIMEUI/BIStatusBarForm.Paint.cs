// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BaseIMEUI
{
    public partial class BIStatusBarForm
    {
        private void PaintToolStrip(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int rightBorder = this.u_toolStrip.Width - 3;

            Rectangle rect = new Rectangle(0, 0, 
				this.u_toolStrip.Width - 1, this.u_toolStrip.Height - 2);

            using (Region tooltipRegion = new Region(rect))
            {
                this.u_toolStrip.Region = tooltipRegion;
            }

            Pen blackPen = new Pen(Color.Black);
            Pen grayPen = new Pen(Color.Gray);

            g.DrawLine(blackPen, new Point(rightBorder, 0),
            	new Point(rightBorder, this.u_toolStrip.Height));
            g.DrawLine(blackPen, new Point(0, 0),
				new Point(0, this.u_toolStrip.Height));
            g.DrawLine(grayPen, new Point(1, 0), 
				new Point(1, this.u_toolStrip.Height));
            blackPen.Dispose();
            grayPen.Dispose();
        }

       /// <summary>
        /// Paint the appearance of the status bar in the mini mode.
        /// </summary>
        /// <param name="e"></param>
        private void PaintMiniMode(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.u_toolStrip.Visible = false;

            Size windowSize = new Size(this.u_toolStrip.Size.Width + this.u_toolStrip.Left + 10, this.u_toolStrip.Size.Height - 2);
            this.m_windowRect = new Rectangle(new Point(0, 0), windowSize);
            Rectangle windowRect = new Rectangle(0, 0, 64, windowSize.Height);
            Rectangle outside = windowRect;

            outside.Height += 1;
            outside.Width += 1;

            Region windowRegion = new Region(outside);
            this.Region = windowRegion;
            windowRegion.Dispose();
            // Paint the header of the status bar with a Yahoo! logo.
            g.DrawImage(this.m_barhead, 0, 0, 36, outside.Height);

            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
				// If we are now in the Alphanumeric mode, the icon on the status bar
				// in the mini mode should be a icon title "EN", otherwise, it should
				// be the icon of the current Chinese Input Method.

                Image i;
                if (callback.isAlphanumericMode())
                    i = this.u_toggleAlphanumericMode.Image;
                else
                    i = this.u_toggleInputMethod.Image;
                g.DrawImage(i, 40, 3, 20, 20);
            }

            Pen blackPen = new Pen(Color.Black);
            g.DrawRectangle(blackPen, windowRect);
            g.DrawLine(blackPen, new Point(36, 0), new Point(36, this.Height));
            blackPen.Dispose();
        }

        /// <summary>
        /// Paint the appearance of the status bar in the normal mode.
        /// </summary>
        /// <param name="e"></param>
        private void PaintNormalMode(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.u_toolStrip.Visible = true;

            Size windowSize = new Size(this.u_toolStrip.Size.Width + this.u_toolStrip.Left + 10, this.u_toolStrip.Size.Height - 2);
            this.m_windowRect = new Rectangle(new Point(0, 0), windowSize);
            this.Height = windowSize.Height + 10;
            this.Width = windowSize.Width + 10;
            Rectangle outside = this.m_windowRect;
            outside.Height += 1;
            outside.Width += 1;

            Region windowRegion = new Region(outside);
            this.Region = windowRegion;
            windowRegion.Dispose();

            // Paint the header of the status bar with a Yahoo! logo.
            g.DrawImage(this.m_barhead, 0, 0, 36, outside.Height);
            g.DrawImage(this.m_bartail, this.u_toolStrip.Right - 2, 0, 20, outside.Height);

            Pen blackPen = new Pen(Color.Black);
            Pen grayPen = new Pen(Color.Gray);

            g.DrawRectangle(blackPen, this.m_windowRect);
            g.DrawLine(grayPen, new Point(1, 0), new Point(1, this.Height));

            blackPen.Dispose();
            grayPen.Dispose();
        }

        void BIStatusBar_Paint(object sender, PaintEventArgs e)
        {
			// If the status bar is not visible, we do not need to refresh
			// the appearance of the status bar.
			
            if (!this.Visible)
                return;

            if (this.m_isMiniMode == true && this.m_isUsingSystemTrayMode == false)
                this.PaintMiniMode(e);
            else
                this.PaintNormalMode(e);

            if (!this.m_isLocationInitialized)
                this.InitLocation();
        }

        private void BIStatusBar_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                Win32FunctionHelper.ReleaseCapture();
                Win32FunctionHelper.SendMessage(Handle, Win32FunctionHelper.MouseMove.WM_NCLBUTTONDOWN,
                    Win32FunctionHelper.MouseMove.HT_CAPTION, 0);
            }
        }

        private void BIStatusBarForm_Move(object sender, System.EventArgs e)
        {
            if (this.m_isMiniMode == true && this.m_isUsingSystemTrayMode == false)
            {
	            Screen currentScreen = Screen.FromPoint(this.Location);	
                int currentLeft = currentScreen.WorkingArea.Right - 64;
                this.Left = currentLeft;
            }
			
            if (this.u_symbolForm.Visible == true && this.m_isMiniMode == false)
            {
                int x = this.Left;
                int y = this.Top - this.u_symbolForm.Height - 10;
                if (y < 0)
                    y = this.Bottom;
                this.u_symbolForm.Location = new Point(x, y);
            }

            if (this.Top - this.u_toggleInputMethodDropDownMenu.Height < 0 ||
                this.Top - this.u_configsDropDownMenu.Height < 0)
            {
                this.u_toggleInputMethod.DropDownDirection = ToolStripDropDownDirection.BelowRight;
                this.u_configs.DropDownDirection = ToolStripDropDownDirection.BelowLeft;
            }
            else
            {
                this.u_toggleInputMethod.DropDownDirection = ToolStripDropDownDirection.AboveRight;
                this.u_configs.DropDownDirection = ToolStripDropDownDirection.AboveLeft;
            }

        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32FunctionHelper.MouseMove.WM_MOVING:
                case Win32FunctionHelper.MouseMove.WM_SIZING:
                    {
	                    if (this.Visible)
                        {
		                    RECT prc = (RECT)m.GetLParam(typeof(RECT));

	                        if (this.m_isMiniMode == true && this.m_isUsingSystemTrayMode == false)
	                        {
	                            Screen currentScreen = Screen.FromPoint(this.Location);
	                            int currentLeft = currentScreen.WorkingArea.Right - 64;
	                            Win32FunctionHelper.SetWindowPos(m.HWnd, (IntPtr)Win32FunctionHelper.CmdShow.HWND_TOP,
	                                currentLeft, prc.Top, 64, prc.Bottom - prc.Top, 0);
	                        }
	                        else
	                        {
	                            Win32FunctionHelper.SetWindowPos(m.HWnd, (IntPtr)Win32FunctionHelper.CmdShow.HWND_TOP,
	                                prc.Left, prc.Top, prc.Right - prc.Left, prc.Bottom - prc.Top, 0);
	                        }
						}
                    }

                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
    }
}
