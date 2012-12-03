// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TakaoPreference;
using System.Diagnostics;
using System.Threading;

namespace BaseIMEUI
{
    /// <remarks>
    /// The Japanese-style Smiley panel.
    /// </remarks>
    public partial class BISmileyPanel : UserControl
    {
        public BISmileyPanel()
        {
            InitializeComponent();  
        }

        public List<KeyValuePair<string, string>> m_symbolsList = new List<KeyValuePair<string, string>>();

        public void SetList(List<KeyValuePair<string, string>> symbolsList)
        {
            this.m_symbolsList.Clear();
            this.u_listBox.Items.Clear();
            this.m_symbolsList.AddRange(symbolsList);
            foreach (KeyValuePair<string, string> item in m_symbolsList)
            {
                string name = item.Key;
                this.u_listBox.Items.Add(name);
            }
            this.u_listBox.SelectedIndex = 0;
        }

        public void SetList(List<string> symbolsList)
        {
            this.m_symbolsList.Clear();
            this.u_listBox.Items.Clear();
            foreach (string item in symbolsList)
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(item, item);
                this.m_symbolsList.Add(kvp);
                this.u_listBox.Items.Add(item);
            }
            this.u_listBox.SelectedIndex = 0;
        }


        public void SetList(string[] symbols)
        {
            this.m_symbolsList.Clear();
            this.u_listBox.Items.Clear();
            foreach (string item in symbols)
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(item, item);
                this.m_symbolsList.Add(kvp);
                this.u_listBox.Items.Add(item);
            }
            this.u_listBox.SelectedIndex = 0;
        }

        public void AddItem(KeyValuePair<string, string> symbol)
        {
            this.m_symbolsList.Add(symbol);
            this.u_listBox.Items.Add(symbol.Key);
        }

        public void AddItem(string symbol)
        {
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(symbol, symbol);
            this.m_symbolsList.Add(kvp);
            this.u_listBox.Items.Add(symbol);
        }

        private void u_listBox_DoubleClick(object sender, EventArgs e)
        {
            if (u_listBox.SelectedIndex < 0 || u_listBox.SelectedIndex >= this.m_symbolsList.Count)
                return;

            KeyValuePair<string, string>kvp = this.m_symbolsList[u_listBox.SelectedIndex];
            string text = kvp.Value;
            
            if (text == null || text.Length == 0)
                return;

            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
                callback.sendString(text);
            }
        }

        private void u_sendBtn_Click(object sender, EventArgs e)
        {
            this.u_listBox_DoubleClick(sender, e);
        }

		public bool EditButtonVisible
		{
			get
			{
				return this.u_editButton.Visible;
			}
			set
			{
				this.u_editButton.Visible = value;
			}
		}

		private void EditSymbolsInThread()
		{			
			PreferenceConnector callback = PreferenceConnector.SharedInstance;
			if (callback != null)
			{
				string filename = callback.userFreeCannedMessagePath();
				Process process = new Process();
				process.StartInfo.FileName = "Notepad.exe";
				process.StartInfo.Arguments = filename;
				process.Start();
			}
		}

		private void u_editButton_Click(object sender, EventArgs e)
		{
			try
			{
				ThreadStart threadStart = new ThreadStart(EditSymbolsInThread);
				Thread thread = new Thread(threadStart);
				thread.Start();
			}
			catch { }
		}
    }
}
