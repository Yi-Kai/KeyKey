// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseIMEUI;

namespace BaseIMEUI
{    
	public partial class BISymbolForm : BIForm
	{
		private int m_lastHeight;
		private BIStatusBarForm u_statusBarForm;
        private bool m_init;

		public BISymbolForm(BIStatusBarForm statusBarForm)
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			this.u_statusBarForm = statusBarForm;
			this.FormClosing += new FormClosingEventHandler(BISymbolForm_FormClosing);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BIForm_MouseMove);
			this.LoadSymbols();            
		}

		public void LoadSymbols()
		{
            this.m_init = true;

			this.u_panelButtons.Controls.Clear();
			this.u_ToolStripDropDown.Items.Clear();

			this.LoadBasicSymbols();
			this.LoadCannedMessages();

			this.m_lastHeight = this.Height;

			if (this.u_ToolStripDropDown.Items.Count > 0)
			{
                int index = this.IndexOfLastUsedPage();
                if (index >= this.u_panelButtons.Controls.Count)
                {
                    index = 0;
                }
                this.u_panelButtons.Controls[index].Visible = true;
                this.ToolStripMenuItem_Click(this.u_ToolStripDropDown.Items[index], null);
			}

            this.m_init = false;
		}

		private void LoadBasicSymbols()
		{
			BIServerConnector callback = BIServerConnector.SharedInstance;
			if (callback != null)
			{
				List<string> symbolButtonCategories = callback.symbolButtonCategories();
				if (symbolButtonCategories.Count == 0)
					return;
				int i = 0;
				foreach (string symbolButtonName in symbolButtonCategories)
				{
					string symbolButtonTag = "pSymbolButton_" + i;
					List<string> buttons = callback.symbolButtonsOfCategory(i);
					this.CreateButtonPanel(symbolButtonTag, buttons.ToArray());

					ToolStripMenuItem menuItem = new ToolStripMenuItem();
					menuItem.Text = symbolButtonName;
					menuItem.Name = symbolButtonTag;
					menuItem.Tag = symbolButtonTag;
					menuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
					this.u_ToolStripDropDown.Items.Add(menuItem);
					i++;
				}
			}
		}

        private int IndexOfLastUsedPage()
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                if (callback.hasLoaderConfigKey("ShouldUseMiniMode") == false)
                {
                    return 0;
                }
                string lastUsedPage = callback.stringValueForLoaderConfigKey("LastSymbolTablePage");
                for (int i = 0; i < this.u_panelButtons.Controls.Count; i++)
                {
                    Control c = this.u_panelButtons.Controls[i];
                    if (c.Name.Equals(lastUsedPage))
                        return i;
                }
            }
            return 0;
        }

        private void SaveLastUsedPage(string  page)
        {
            if (this.m_init)
                return;

            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                callback.setLoaderConfigKeyStringValue("LastSymbolTablePage", page);
            }
        }

		private void LoadCannedMessages()
		{
			BIServerConnector callback = BIServerConnector.SharedInstance;
			if (callback != null)
			{
				List<string> cannedMessageCategories = callback.cannedMessageCategories();
				if (cannedMessageCategories.Count == 0)
					return;
				int i = 0;
				foreach (string categoryName in cannedMessageCategories)
				{
					string categoryTag = "pCannedMessage_" + i;
					List<KeyValuePair<string, string>> list = callback.cannedMessagesOfCategory(i);

					bool editButtonVisible = false;
					if (i == cannedMessageCategories.Count - 1)
						editButtonVisible = true;

					this.CreateSmileyPanel(categoryTag, list, editButtonVisible);
					ToolStripMenuItem menuItem = new ToolStripMenuItem();
					menuItem.Text = categoryName;
					menuItem.Name = categoryTag;                    
					menuItem.Tag = categoryTag;
					menuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
					this.u_ToolStripDropDown.Items.Add(menuItem);
					i++;
				}
			}
		}

		/// <summary>
		/// The shadowed Hide()
		/// The Status Bar should react with the hide event of the Symbol
		/// Window.
		/// </summary>
		public new void Hide()
		{
			base.Hide();
			u_ToolStripDropDown.Hide();
			u_statusBarForm.SetSymbolFormHidden();
		}
		/// <summary>
		/// Create a new panel with rows of buttons, which contain the symbol
		/// characters.
		/// </summary>
		/// <param name="panelName">The name of the new panel</param>
		/// <param name="buttonNames">The array of symbol strings.</param>
		private void CreateButtonPanel(string panelName, string[] buttonNames)
		{
			int i = 0;
			double lines = Math.Ceiling(buttonNames.Length / 10.0);
			Panel p = new Panel();
			p.Name = panelName;
			p.MouseMove += new MouseEventHandler(BIForm_MouseMove);

			p.Size = new Size(250, (int)lines * 25 + 15);
			p.Location = new Point(0, u_symbolList.Height + 5);
			p.Visible = false;
			foreach (string name in buttonNames)
			{
				int row = i / 10;
				int col = i % 10;
				int y = row * 25;
				int x = col * 25; 
				Button b = new Button();
				b.Location = new Point(x, y);
				b.Size = new Size(25, 25);
				b.TabIndex = 0;
				b.Text = name;
				b.UseVisualStyleBackColor = false;
				b.Font = new Font(Win32FontHelper.DefaultFontFamily(), 10);
				b.Click += new EventHandler(SendString);
				p.Controls.Add(b);
				i++;
			}
			u_panelButtons.Controls.Add(p);
		}

		private void CreateSmileyPanel(string panelName, string[] symbolNames, bool editButtonVisible)
		{
			BISmileyPanel smileyPanel = new BISmileyPanel();
			smileyPanel.Name = panelName;
			smileyPanel.SetList(symbolNames);
			smileyPanel.EditButtonVisible = editButtonVisible;
			this.u_panelButtons.Controls.Add(smileyPanel);
		}

		private void CreateSmileyPanel(string panelName, List<KeyValuePair<string, string>> list, bool editButtonVisible)
		{
			BISmileyPanel smileyPanel = new BISmileyPanel();
			smileyPanel.Name = panelName;
			smileyPanel.SetList(list);
			smileyPanel.EditButtonVisible = editButtonVisible;
			this.u_panelButtons.Controls.Add(smileyPanel);
		}

		/// <summary>
		/// Send string to the client window by calling the sendString method.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SendString(object sender, EventArgs e)
		{            
			Button b = (Button)sender;
			string text = b.Text;
			BIServerConnector callback = BIServerConnector.SharedInstance;
			if (callback != null)
				callback.sendString(text);
		}
		/// <summary>
		/// Clicking on the drop-down menu to switch from a symbol panel to 
		/// another.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem currentItem = (ToolStripMenuItem)sender;
			int h = 0;
			int titleHeight = 16;

			string selected = currentItem.Tag.ToString();

			foreach (ToolStripMenuItem t in this.u_ToolStripDropDown.Items)
			{
				t.CheckState = CheckState.Unchecked;
			}
			currentItem.CheckState = CheckState.Checked;
			this.u_symbolList.Text = currentItem.Text;

			for (int i = 0; i < this.u_panelButtons.Controls.Count; i++)
			{
				Control c = this.u_panelButtons.Controls[i];
				c.Visible = false;
				if (c.Name.Equals(selected))
				{
					c.Visible = true;
					h = c.Height;
				}
			}

            this.SaveLastUsedPage(selected);

			this.Top = this.Top + (this.m_lastHeight - (h + this.u_symbolList.Height + titleHeight));
			this.Height = h + this.u_symbolList.Height + titleHeight;
			this.m_lastHeight = this.Height;
		}

		/// <summary>
		/// The symbol form should be hidden but not closed when user click 
		/// on the close  button on the window. However, it sould be closed 
		/// when other kind of close events happens, such as shutdown or 
		/// reboot.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BISymbolForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason.Equals(CloseReason.UserClosing))
			{
				e.Cancel = true;
				this.Hide();
			}
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