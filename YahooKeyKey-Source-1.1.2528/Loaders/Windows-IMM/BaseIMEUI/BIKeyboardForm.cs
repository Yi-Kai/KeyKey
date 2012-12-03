using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseIMEUI
{
	public partial class BIKeyboardForm : BIForm
	{
		private Point m_targetPoint;

		public BIKeyboardForm()
		{
			InitializeComponent();
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BIForm_MouseMove);
			this.FormClosing += new FormClosingEventHandler(BIKeyboardForm_FormClosing);

			button1.KeyName = "1";
			button1.Symbol = "\u250c";
			button2.KeyName = "2";
			button2.Symbol = "\u252c";
			button3.KeyName = "3";
			button3.Symbol = "\u2510";
			button4.KeyName = "4";
			button4.Symbol = "\u301d";
			button5.KeyName = "5";
			button5.Symbol = "\u301e";
			button6.KeyName = "6";
			button6.Symbol = "\u2018";
			button7.KeyName = "7";
			button7.Symbol = "\u2019";
			button8.KeyName = "8";
			button8.Symbol = "\u201c";
			button9.KeyName = "9";
			button9.Symbol = "\u201d";
			button0.KeyName = "0";
			button0.Symbol = "\u300e";
			buttonMinus.KeyName = "-";
			buttonMinus.Symbol = "\u300f";
			buttonPlus.KeyName = "=";
			buttonPlus.Symbol = "\u300c";
			buttonBackSlash.KeyName = "\\";
			buttonBackSlash.Symbol = "\u300d";

			buttonQ.KeyName = "Q";
			buttonQ.Symbol = "\u251c";
			buttonW.KeyName = "W";
			buttonW.Symbol = "\u253c";
			buttonE.KeyName = "E";
			buttonE.Symbol = "\u2524";
			buttonR.KeyName = "R";
			buttonR.Symbol = "\u203b";
			buttonT.KeyName = "T";
			buttonT.Symbol = "\u3008";
			buttonY.KeyName = "Y";
			buttonY.Symbol = "\u3009";
			buttonU.KeyName = "U";
			buttonU.Symbol = "\u300a";
			buttonI.KeyName = "I";
			buttonI.Symbol = "\u300b";
			buttonO.KeyName = "O";
			buttonO.Symbol = "\u3010";
			buttonP.KeyName = "P";
			buttonP.Symbol = "\u3011";
			buttonBracketL.KeyName = "[";
			buttonBracketL.Symbol = "\ufe5d";
			buttonBracketR.KeyName = "]";
			buttonBracketR.Symbol = "\ufe5e";

			buttonA.KeyName = "A";
			buttonA.Symbol = "\u2514";
			buttonS.KeyName = "S";
			buttonS.Symbol = "\u2534";
			buttonD.KeyName = "D";
			buttonD.Symbol = "\u2518";
			buttonF.KeyName = "F";
			buttonF.Symbol = "\u25cb";
			buttonG.KeyName = "G";
			buttonG.Symbol = "\u25cf";
			buttonH.KeyName = "H";
			buttonH.Symbol = "\u2191";
			buttonJ.KeyName = "J";
			buttonJ.Symbol = "\u2193";
			buttonK.KeyName = "K";
			buttonK.Symbol = "\uff01";
			buttonL.KeyName = "L";
			buttonL.Symbol = "\uff1a";
			buttonSemiColon.KeyName = ";";
			buttonSemiColon.Symbol = "\uff1b";
			buttonQuote.KeyName = "'";
			buttonQuote.Symbol = "\u3001";

			buttonZ.KeyName = "Z";
			buttonZ.Symbol = "\u2500";
			buttonX.KeyName = "X";
			buttonX.Symbol = "\u2502";
			buttonC.KeyName = "C";
			buttonC.Symbol = "\u25ce";
			buttonV.KeyName = "V";
			buttonV.Symbol = "\u00a7";
			buttonB.KeyName = "B";
			buttonB.Symbol = "\u2190";
			buttonN.KeyName = "N";
			buttonN.Symbol = "\u2192";
			buttonM.KeyName = "M";
			buttonM.Symbol = "\u3002";
			buttonComma.KeyName = ",";
			buttonComma.Symbol = "\uff0c";
			buttonPeriod.KeyName = ".";
			buttonPeriod.Symbol = "\u2027";
			buttonSlash.KeyName = "/";
			buttonSlash.Symbol = "\uff1f";

			this.InitLocation();
		}
		
		/// <summary>
		/// Initialize the default location.
		/// </summary>
		private void InitLocation()
		{
			int x = Screen.PrimaryScreen.WorkingArea.Left + Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
			int y = Screen.PrimaryScreen.WorkingArea.Top + Screen.PrimaryScreen.WorkingArea.Height - this.Height - 70;
			this.Location = new Point(x, y);
		}

		private void BIKeyboardForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason.Equals(CloseReason.UserClosing))
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		public new void Show()
		{        
			this.AdjustLocation();
			this.PrepareToShow = false;
			base.Show();
		}

		public new void Hide()
		{
			base.Hide();
			
			// cancel the waiting state
			BIServerConnector callback = BIServerConnector.SharedInstance;
			if (callback != null)
				callback.cancelPunctuationKeyboardWaitingState();
		}

		private void sendString(object sender, EventArgs e)
		{
			BIKeyboardButton b = (BIKeyboardButton)sender;
			string symbol = b.Symbol;
			BIServerConnector callback = BIServerConnector.SharedInstance;
			if (callback != null)
				callback.sendString(symbol);
			this.Hide();
		}     

		private delegate void SetLocationCallBack(int x, int y);
		/// <summary>
		/// To set the location of the candidate window.
		/// The SetLocation() method is inherited from the BIForm class, however, the SetLocation()
		/// method of the candidate window do not move the window directly, but set a target location
		/// temporary, the window will move to the target location while re-drawing the window
		/// and the on-paint event is launched.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>        
		public new void SetLocation(int x, int y)
		{
			BIServerConnector callback = BIServerConnector.SharedInstance;
			if (callback != null)
			{
				if (callback.hasLoaderConfigKey("KeyboardFormShouldFollowCursor"))
				{
					if (callback.isLoaderConfigKeyTrue("KeyboardFormShouldFollowCursor"))
					{
						this.m_targetPoint = new Point(x, y);
						this.AdjustLocation();
					}
				}
			}
		}
		protected void AdjustLocation()
		{
			#region Window Position

			Screen currentScreen;
			if (Screen.AllScreens.Length == 1)
				currentScreen = Screen.PrimaryScreen;
			else
				currentScreen = Screen.FromPoint(this.m_targetPoint);

			Rectangle tmpRect = new Rectangle(this.m_targetPoint, this.Size);

			if (tmpRect.Top < 0)
				tmpRect.Y = 30;
			if (tmpRect.Bottom > currentScreen.WorkingArea.Bottom)
			{
				tmpRect.Y = tmpRect.Top - tmpRect.Height - 30;
				if (tmpRect.Bottom > currentScreen.WorkingArea.Bottom)
					tmpRect.Y = currentScreen.WorkingArea.Bottom - tmpRect.Height - 30;
			}
			if (tmpRect.Right > currentScreen.WorkingArea.Right)
				tmpRect.X = currentScreen.WorkingArea.Right - tmpRect.Width - 10;

			this.Location = tmpRect.Location;
			#endregion
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Graphics g = e.Graphics;
			SolidBrush borderBrush = new SolidBrush(Color.Black);
			Pen borderPen = new Pen(borderBrush);
			Size borderSize = new Size(this.Width - 1, this.Height - 1);
			g.DrawRectangle(borderPen, new Rectangle(new Point(0, 0), borderSize));
			borderBrush.Dispose();
			borderPen.Dispose();
		}

		public bool PrepareToShow;

		private void BIKeyboardForm_MouseEnter(object sender, EventArgs e)
		{
			this.Cursor = Cursors.SizeAll;
		}

		private void BIKeyboardForm_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		private void BIKeyboardForm_Move(object sender, EventArgs e)
		{
			this.m_targetPoint = this.Location;
		}

		private void BIForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button.Equals(MouseButtons.Left))
			{
				Win32FunctionHelper.ReleaseCapture();
				Win32FunctionHelper.SendMessage(Handle, Win32FunctionHelper.MouseMove.WM_NCLBUTTONDOWN,
					Win32FunctionHelper.MouseMove.HT_CAPTION, 0);
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
							Win32FunctionHelper.SetWindowPos(m.HWnd, (IntPtr)Win32FunctionHelper.CmdShow.HWND_TOP,
								prc.Left, prc.Top, prc.Right - prc.Left, prc.Bottom - prc.Top, 0);
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