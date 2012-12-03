// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace BaseIMEUI
{
    /// <remarks>
    /// The Yahoo! Dictionary search form.
    /// </remark>
    public partial class BIDictionaryForm : BIForm
    {
        private string m_enterImagePath;
        private string m_enterImageLink;
        private string m_loadingImagePath;
        private string m_loadingImageLink;
        private string m_originalTitle;
        /// <summary>
        /// The pre-defined HTML header.
        /// </summary>
        private string m_htmlHeader;

        private BIStatusBarForm u_statusBarForm;

        public BIDictionaryForm(BIStatusBarForm statusBarForm)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.u_statusBarForm = statusBarForm;
            this.FormClosing += new FormClosingEventHandler(BIDictionaryForm_FormClosing);
            this.InitLocation();
            this.InitHTML("");
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BIForm_MouseMove);
        }
        private void InitHTML(string keyword)
        {
            this.u_output.ObjectForScripting = this;
            this.u_output.IsWebBrowserContextMenuEnabled = false;
            this.m_originalTitle = this.Text;

            string currentPath = Application.StartupPath;

            this.m_enterImagePath = currentPath + Path.DirectorySeparatorChar + "WebUI" + Path.DirectorySeparatorChar + "enter.gif";
            this.m_enterImageLink = "<img src=\"" + m_enterImagePath + "\" alt=\"" + m_enterImagePath + "\">";

            this.m_loadingImagePath = currentPath + Path.DirectorySeparatorChar + "WebUI" + Path.DirectorySeparatorChar + "loading.gif";
            this.m_loadingImageLink = "<img src=\"" + m_loadingImagePath + "\" alt=\"" + m_loadingImagePath + "\">";

            // The header part of the generated HTML file
            this.m_htmlHeader = "<html>\n<head>" +
"<style type='text/css'>\nbody { font-size: 10pt; font-family: Arial, MingLiU, sans-serif; line-height: 1.2em; }\n a, a:visited {text-decoration: none; color: blue;}\n a:hover {text-decoration: underline;} b {font-weight: bold; color: darkred;}\n p {margin: 0.5em 0;}\n blockquote {border: 1px solid #CCC; margin: 0; padding: 5px; margin-bottom: 10px; margin-left: 20px;}\n blockquote p {margin: 0.2em 0;}\n h2 {font-family: Times New Roman, serif; font-weight: normal; font-size: 20pt; border-bottom: 1px solid #CCC; color: 000; line-height: 1.5em;}\n h2 a, h2 a:visited, h2 a:hover {color: #333; text-decoration: none;}\n h3 {font-size: 12pt; }\n div {display:none;}\n img {border: 0;} \n .credit {margin-top: 20px; color: #999; font-size: 8pt; line-height: 1.2em;}</style>\n" +
"<script type=\"text/javascript\">\n" +
"function changetitle(newtitle) { try {window.external.Search(newtitle);} catch(err){} return false;}\n" +
"function sendString(string) { try {window.external.SendString(string);} catch(err){} return false;}\n" +
"function openURL(string) { try {window.external.OpenURLInExternalBrowser(string);} catch(err){} return false;}\n" +
"function toggle(link, divName) { d = document.getElementById(divName); if (d.style.display == \"none\") { d.style.display = \"block\"; link.innerHTML = \"\u647a\u758a\"; } else { d.style.display = \"none\"; link.innerHTML = \"\u5c55\u958b\";}  return false;}" +
"</script>" +
"<script type=\"text/javascript\" src=\"http://del.icio.us/js/playtagger\"></script>" +
"<title>" + keyword + "</title></head>\n<body>";

            string html = m_htmlHeader;
            string locale = CultureInfo.CurrentUICulture.Name;
            if (locale.Equals("zh-TW"))
            {
                html += "<h2>Yahoo! \u5947\u6469\u5B57\u5178</h2>";
                html += "<p>\u6B61\u8FCE\u4F7F\u7528 Yahoo! \u5947\u6469\u82F1\u6F22\u6F22\u82F1\u7DDA\u4E0A\u5B57\u5178</p>";
            }
            else if (locale.Equals("zh-CN"))
            {
                html += "<h2>Yahoo! \u5947\u6469\u5B57\u5178</h2>";
                html += "<p>\u6B22\u8FCE\u4F7F\u7528 Yahoo! \u5947\u6469\u82F1\u6C49\u6C49\u82F1\u5728\u7DDA\u5B57\u5178</p>";
            }
            else
            {
                html += "<h2>Yahoo! Dictionary</h2>";
                html += "<p>Welcome to the Yahoo! English/Chinese Dictionary.</p>";
            }
            html += Config.YahooDictionaryCopyright;
            html += "</body></html>";
            this.u_output.DocumentText = html;
        }
        /// <summary>
        /// Set the default window location while initializing.
        /// </summary>
        private void InitLocation()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            int y = Screen.PrimaryScreen.WorkingArea.Y + 10;
            this.Location = new Point(x, y);
        }
        /// <summary>
        /// The shadowed Show()
        /// </summary>
        public new void Show()
        {
            #region Avoids the disctionary window to be out of the bound of current screen.
            Screen currentScreen = Screen.FromHandle(this.Handle);
            if (currentScreen == null)
                currentScreen = Screen.PrimaryScreen;
            if (this.Top > currentScreen.WorkingArea.Bottom)
                this.Top = currentScreen.WorkingArea.Bottom - this.Size.Height - 20;
            if (this.Bottom < currentScreen.WorkingArea.Top)
                this.Top = currentScreen.WorkingArea.Top + 20;
            if (this.Left > currentScreen.WorkingArea.Right)
                this.Left = currentScreen.WorkingArea.Right - this.Size.Width - 20;
            if (this.Right < currentScreen.WorkingArea.Left)
                this.Left = currentScreen.WorkingArea.Left + 20;
            #endregion
            base.Show();
        }
        /// <summary>
        /// Override the Hide method to store the status of the dictionary window.
        /// </summary>
        public new void Hide()
        {
            base.Hide();
            this.u_statusBarForm.SetDictionaryFormHide();
        }
        /// <summary>
        /// Oveeride the Close event to prevent the dictionary window is released when user clicks
        /// on the close button. The dictionary window should be hidden, but not really closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BIDictionaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing))
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        public void OpenURLInExternalBrowserInThread(object data)
        {
            string URL = (string)data;
            ProcessStartInfo startInfo = new ProcessStartInfo(URL);
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
        }
        public void OpenURLInExternalBrowser(string URL)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(this.OpenURLInExternalBrowserInThread));
            thread.Start(URL);
        }
        /// <summary>
        /// Perform search in the online dictionary.
        /// </summary>
        /// <param name="keyword">The keyword to search in the online dictionary</param>
        public void Search(string keyword)
        {
            if (this.Visible == false)
                this.Show();
            this.PerformSearch(keyword);
        }
        /// <summary>
        /// Send string from the dictionary to the current application which activates Yahoo! KeyKey input method.
        /// </summary>
        /// <param name="text">The content text to send</param>
        public void SendString(string text)
        {
            BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
                callback.sendString(text + " ");
        }

        private void AddContextMenuItem(string title)
        {
            foreach (ToolStripMenuItem anItem in this.u_historyMenuStrip.Items)
            {
                if (anItem.Text.Equals(title))
                    return;
            }
            ToolStripMenuItem newItem = new ToolStripMenuItem(title);
            newItem.Click += new EventHandler(historyContextMenuItem_Click);
            this.u_historyMenuStrip.Items.Add(newItem);
            if (this.u_historyMenuStrip.Items.Count > 8)
                this.u_historyMenuStrip.Items.RemoveAt(0);
        }

        void historyContextMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem anItem = (ToolStripMenuItem)sender;
            string keyword = anItem.Text;
            this.PerformSearch(keyword);
        }

        private delegate void UpdateHTMLCallBack(string html);
        private void UpdateContentHTML(string html)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateHTMLCallBack(UpdateContentHTML), new object[] { html });
                return;
            }
            this.u_output.DocumentText = html;
        }
        private void ErrorBeep()
        {
            if (this.Visible == true)
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
        private void ErrorMessage(Exception e)
        {
            string locale = CultureInfo.CurrentUICulture.Name;
            if (locale.Equals("zh-TW"))
                this.UpdateContentHTML(this.m_htmlHeader + "<h2>\u932f\u8aa4</h2><p>\u7121\u6cd5\u8207\u7dda\u4e0a\u5b57\u5178\u9023\u7dda\uff0c\u539f\u56e0\u662f\uff1a" + e.Message + "</p></body></html>");
            else if (locale.Equals("zh-CN"))
                this.UpdateContentHTML(this.u_output.DocumentText = this.m_htmlHeader + "<h2>\u9519\u8BEF</h2><p>\u65E0\u6CD5\u641C\u5BFB\u5728\u7EBF\u5B57\u5178\uFF0C\u539F\u56E0\u662F\uFF1A " + e.Message + "</p></body></html>");
            else
                this.UpdateContentHTML(this.u_output.DocumentText = this.m_htmlHeader + "<h2>Error</h2><p>Unable to search the online dicionary, the reason is: " + e.Message + "</p></body></html>");
            this.ErrorBeep();
        }
        private void PerformSearch(string keyword)
        {
            ParameterizedThreadStart s = new ParameterizedThreadStart(PerformSearchInThread);
            Thread t = new Thread(s);
            t.Start(keyword);
        }
        private void PerformSearchInThread(object data)
        {
            string keyword = (string)data;
            string locale = CultureInfo.CurrentUICulture.Name;
            string html = this.m_htmlHeader;

            this.Text = this.m_originalTitle + ": " + keyword;

            if (locale.Equals("zh-TW"))
                this.UpdateContentHTML(this.m_htmlHeader + "<h2>\u8f09\u5165\u4e2d..." + this.m_loadingImageLink + "</h2><p>\u6b63\u5728\u67e5\u8a62\u7dda\u4e0a\u5b57\u5178\u4e2d\uff0c\u8acb\u7a0d\u5019\u3002</p></body></html>");
            else if (locale.Equals("zh-CN"))
                this.UpdateContentHTML(this.m_htmlHeader + "<h2>\u52A0\u8F7D\u4E2D..." + this.m_loadingImageLink + "</h2><p>\u6b63\u5728\u67e5\u8be2\u5728\u7ebf\u5b57\u5178\u4e2d\uff0c\u8bf7\u7a0d\u5019\u3002</p></body></html>");
            else
                this.UpdateContentHTML(this.m_htmlHeader + "<h2>Loading..." + this.m_loadingImageLink + "</h2><p>Please wait.</p></body></html>");

            // Well..Golimar...
            if (keyword.IndexOf("\u5E79\u4F60\u5ABD") >= 0 || keyword.ToLower().Equals("golimar"))
            {
                Thread.Sleep(500);
                this.Golimar();
                this.ErrorBeep();
                return;
            }
            else if (keyword.ToLower().Equals("orz"))
            {
                Thread.Sleep(500);
                this.Orz();
                this.ErrorBeep();
                return;
            }

            string url = Config.YahooDictionaryAPIURL + Uri.EscapeUriString(keyword);

            XmlDocument dictionaryXMLDocument = new XmlDocument();

            try
            {
                dictionaryXMLDocument.Load(url);
            }
            catch (Exception e)
            {
                this.ErrorMessage(e);
                return;
            }
            // @zonble
            // Sometimes the Internet connection may be too fast, when
            // the thread of loading XML file online is done, the thread of
 			// user  interface and the web browser object is still not ready.
 			// We wait for 0.5 second for the web browser object. 0.5 second
 			// is a magic number, there should be better ways to do it.
            Thread.Sleep(500);

            #region The Yahoo! Dictionary XML parser.
            try
            {
                XmlNodeList entryNodes = dictionaryXMLDocument.SelectNodes("//DICTIONARY/ENTRIES/ENTRY");
                if (entryNodes.Count < 1)
                {
                    if (locale.Equals("zh-TW"))
                        html += "<h2>\u627e\u4e0d\u5230</h2><p>\u5728\u5b57\u5178\u4e2d\u627e\u4e0d\u5230\u7b26\u5408\u300c" + keyword + "\u300d\u7684\u9805\u76ee\u3002</p>";
                    else if (locale.Equals("zh-CN"))
                        html += "<h2>\u627E\u4E0D\u5230</h2><p>\u627E\u4E0D\u5230\u5339\u914D\u301D" + keyword + "\u301E\u7684\u9879\u76EE\u3002</p>";
                    else
                        html += "<h2>Not Found</h2><p>Unable to find results matching \"" + keyword + "\".</p>";
                    this.ErrorBeep();
                }
                else
                {
                    this.AddContextMenuItem(keyword);
                }

                int entryIndex = 0;

                foreach (XmlNode entryNode in entryNodes)
                {
                    entryIndex++;
                    bool isChineseEntry = false;
                    XmlDocument entryDocument = new XmlDocument();
                    entryDocument.LoadXml("<ENTRY>" + entryNode.InnerXml + "</ENTRY>");

                    string entryHTML = "";
                    try
                    {
                        XmlNode titleNode = entryDocument.SelectSingleNode("/ENTRY/HW");
                        if (titleNode != null)
                        {
                            string titleString;
                            string[] titleParts = titleNode.InnerText.Split('@');
                            if (titleParts.Length > 1)
                                titleString = titleParts[0] + "<sup>" + titleParts[1] + "</sup>";
                            else
                                titleString = titleParts[0];
                            string linkString = titleParts[0].Replace("'", "\\'"); // Escape String
                            string sendStringLink = " <a href=\"#\" onclick=\"sendString('" + linkString + "'); return false;\">" + m_enterImageLink + "</a>";
                            entryHTML += "<h2><a href=\"#\" onclick=\"changetitle('" + linkString + "'); return false;\">" + titleString + "</a>" + sendStringLink + "</h2>";
                        }

                        // To obtain the URL of the sound file and use flash player to play the file.
                        XmlNode soundNode = entryDocument.SelectSingleNode("/ENTRY/SOUND");
                        if (soundNode != null)
                        {
                            string mp3String = Config.YahooDictionaryURL + soundNode.InnerText;
                            string soundString = "<p><object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0\" width=\"152\" height=\"21\" id=\"audio_key\" align=\"middle\"><param name=\"wmode\" value=\"transparent\"><param name=\"allowScriptAccess\" value=\"sameDomain\" /><param name=\"movie\" value=\"http://tw.yimg.com/i/tw/dictionary/audio_key.swf\" /><param name=\"loop\" value=\"false\" /><param name=\"menu\" value=\"false\" /><param name=\"quality\" value=\"high\" /><param name=\"bgcolor\" value=\"#ffffff\" /><param name=\"FlashVars\" value=\"audio=" + mp3String + "\"><embed src=\"http://tw.yimg.com/i/tw/dictionary/audio_key.swf\" wmode=\"transparent\" loop=\"false\" menu=\"false\" quality=\"high\" bgcolor=\"#ffffff\" width=\"152\" height=\"21\" name=\"audio_key\" align=\"middle\" allowScriptAccess=\"sameDomain\" FlashVars=\"audio=" + mp3String + "\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" /></object></p>";
                            entryHTML += soundString;
                        }

                        #region Symbol
                        XmlNode symbolNode = entryDocument.SelectSingleNode("/ENTRY/SYMBOL");
                        if (symbolNode != null)
                        {
                            try
                            {
                                XmlNode kkNode = symbolNode.SelectSingleNode("./KK");
                                if (kkNode != null)
                                {
                                    if (kkNode.InnerText.Length > 0)
                                        entryHTML += "<p>KK: [" + kkNode.InnerText + "]</p>";
                                }
                                XmlNode djNode = symbolNode.SelectSingleNode("./DJ");
                                if (djNode != null)
                                {
                                    if (djNode.InnerText.Length > 0)
                                        entryHTML += "<p>DJ: [" + djNode.InnerText + "]</p>";
                                }
                                XmlNode pinyinNode = symbolNode.SelectSingleNode("./PINYIN");
                                if (pinyinNode != null)
                                {
                                    entryHTML += "<p>\u62fc\u97f3: " + pinyinNode.InnerText + "</p>";
                                }
                                XmlNode zhuyinNode = symbolNode.SelectSingleNode("./ZHUYIN");
                                if (zhuyinNode != null)
                                {
                                    entryHTML += "<p>\u6ce8\u97f3: " + zhuyinNode.InnerText + "</p>";
                                }

                                if (zhuyinNode != null || pinyinNode != null)
                                {
                                    if (zhuyinNode.InnerText.Length > 0 || pinyinNode.InnerText.Length > 0)
                                        isChineseEntry = true;
                                }
                            }
                            catch (Exception e)
                            {
                                this.ErrorMessage(e);
                                return;
                            }
                        }
                        #endregion
                        XmlNodeList posNodes = entryDocument.SelectNodes("/ENTRY/POS");
                        foreach (XmlNode posNode in posNodes)
                        {
                            int currentItem = 0;
                            bool hasOnlyOneItem = false;

                            XmlNodeList defs = posNode.SelectNodes("//DEF");
                            if (defs.Count < 2)
                                hasOnlyOneItem = true;

                            foreach (XmlNode xN in posNode)
                            {
                                if (xN.Name.Equals("DESC"))
                                {
                                    entryHTML += "<h3>" + xN.InnerText + "</h3>";
                                }
                                else if (xN.Name.Equals("DEF"))
                                {
                                    foreach (XmlNode xn in xN)
                                    {
                                        if (xn.Name.Equals("EXAMPLE"))
                                        {
                                            XmlNode sentenseNode = xn.SelectSingleNode("./SENTENCE");
                                            string sentense = "";
                                            if (sentenseNode != null)
                                                sentense = sentenseNode.InnerText;
                                            XmlNode transNode = xn.SelectSingleNode("./TRANS");
                                            string trans = "";
                                            if (transNode != null)
                                                trans = transNode.InnerText;
                                            entryHTML += "<blockquote><p>" + sentense + "<br/>" + trans + "</p></blockquote>";
                                        }
                                        else if (xn.Name.Equals("EXPL"))
                                        {
                                            if (xn.InnerText.Length > 0)
                                            {
                                                string explString = "";
                                                if (isChineseEntry)
                                                {
                                                    string[] explitemArray = xn.InnerText.Split(";".ToCharArray());
                                                    int i = 0;
                                                    foreach (string explItem in explitemArray)
                                                    {
                                                        string explItemString = explItem.Trim();
                                                        string trimed = explItemString.Replace("'", "\\'");
                                                        string link = " <a href=\"#\" onclick=\"sendString('" + trimed + "'); return false;\">" + m_enterImageLink + "</a> ";
                                                        explString += explItemString + link;
                                                        i++;
                                                        if (i < explitemArray.Length)
                                                            explString += "; ";
                                                    }
                                                }
                                                else
                                                {
                                                    explString = xn.InnerText;
                                                }


                                                if (hasOnlyOneItem)
                                                {
                                                    entryHTML += "<p>" + explString + "</p>";
                                                }
                                                else
                                                {
                                                    currentItem++;
                                                    entryHTML += "<p>" + currentItem + ". " + explString + "</p>";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        XmlNode rulNode = entryDocument.SelectSingleNode("/ENTRY/RUL");
                        if (rulNode != null)
                        {
                            entryHTML += "<h3>\u8b8a\u5316\u5f62</h3>";
                            XmlNodeList rulDescNodes = entryDocument.SelectNodes("/ENTRY/RUL/DESC");
                            string divName = "rul_" + entryIndex;
                            entryHTML += "<p><a href=\"#\" onclick=\"toggle(this, '" + divName + "'); return false;\">\u5c55\u958b</a></p>";
                            entryHTML += "<div id=\"" + divName + "\" style=\"display: none;\">";
                            entryHTML += "<ul>";
                            foreach (XmlNode rulDescNode in rulDescNodes)
                            {
                                entryHTML += "<li>" + rulDescNode.InnerText + "</li>";
                            }
                            entryHTML += "</ul>";
                            entryHTML += "</div>";
                        }

                        #region Syn
                        XmlNode syn = entryDocument.SelectSingleNode("/ENTRY/SYN");
                        if (syn != null)
                        {
                            entryHTML += "<h3>\u540c\u7fa9\u8a5e</h3>";
                            string divName = "syn_" + entryIndex;
                            entryHTML += "<p><a href=\"#\" onclick=\"toggle(this, '" + divName + "'); return false;\">\u5c55\u958b</a></p>";
                            entryHTML += "<div id=\"" + divName + "\" style=\"display: none;\">";

                            XmlNodeList defList = syn.SelectNodes("./DEF");
                            foreach (XmlNode defNode in defList)
                            {
                                XmlNode descNode = defNode.SelectSingleNode("./DESC");
                                if (descNode != null)
                                {
                                    entryHTML += "<p>" + descNode.InnerText + "</p>";
                                }
                                XmlNodeList synDefEntiyList = defNode.SelectNodes("./ENTRY");
                                entryHTML += "<ul>";
                                foreach (XmlNode synDefEntryNode in synDefEntiyList)
                                {
                                    string entryString = synDefEntryNode.InnerText;
                                    string trimed;
                                    string[] entryStringArray = entryString.Split("<".ToCharArray());
                                    trimed = entryStringArray[0];
                                    trimed = trimed.Replace("'", "\\'");
                                    string sendStringLink = " <a href=\"#\" onclick=\"sendString('" + trimed + "'); return false;\">" + m_enterImageLink + "</a> ";
                                    entryHTML += "<li><a href=\"#\" onclick=\"changetitle('" + trimed + "'); return false;\">" + entryString + "</a>" + sendStringLink + "</li>";
                                }
                                entryHTML += "</ul>";
                            }
                            entryHTML += "</div>";
                        }
                        #endregion
                        #region Syn2
                        XmlNode syn2 = entryDocument.SelectSingleNode("/ENTRY/SYN2");
                        if (syn2 != null)
                        {
                            entryHTML += "<h3>\u540c\u7fa9\u53c3\u898b</h3>";
                            string divName = "syn2_" + entryIndex;
                            entryHTML += "<p><a href=\"#\" onclick=\"toggle(this, '" + divName + "'); return false;\">\u5c55\u958b</a></p>";
                            entryHTML += "<div id=\"" + divName + "\" style=\"display: none;\">";

                            XmlNodeList defList = syn2.SelectNodes("./DEF");
                            foreach (XmlNode defNode in defList)
                            {
                                XmlNode descNode = defNode.SelectSingleNode("./DESC");
                                if (descNode != null)
                                {
                                    entryHTML += "<p>" + descNode.InnerText + "</p>";
                                }
                                XmlNodeList synDefEntiyList = defNode.SelectNodes("./ENTRY");
                                entryHTML += "<ul>";
                                foreach (XmlNode synDefEntryNode in synDefEntiyList)
                                {
                                    string entryString = synDefEntryNode.InnerText;
                                    string trimed;
                                    string[] entryStringArray = entryString.Split("<".ToCharArray());
                                    trimed = entryStringArray[0];
                                    trimed = trimed.Replace("'", "\\'");
                                    string sendStringLink = " <a href=\"#\" onclick=\"sendString('" + trimed + "'); return false;\">" + m_enterImageLink + "</a> ";
                                    entryHTML += "<li><a href=\"#\" onclick=\"changetitle('" + trimed + "'); return false;\">" + entryString + "</a>" + sendStringLink + "</li>";
                                }
                                entryHTML += "</ul>";
                            }
                            entryHTML += "</div>";
                        }
                        #endregion
                        XmlNode sourceNode = entryDocument.SelectSingleNode("/ENTRY/SOURCE");
                        if (sourceNode != null)
                        {
                            if (sourceNode.InnerText.Length > 0)
                                entryHTML += "<p class=\"credit\">\u8cc7\u6599\u4f86\u6e90: " + sourceNode.InnerText + "</p>";
                        }

                    }
                    catch (Exception e)
                    {
                        this.ErrorMessage(e);
                        return;
                    }
                    html += entryHTML;
                }
            #endregion

                html += Config.YahooDictionaryCopyright;
                // add random number in the back lest the IE component caches it
                html += Config.YahooDictionaryBeaconHTML;
                html += "</body></html>";
                this.UpdateContentHTML(html);
            }
            catch (Exception e)
            {
                this.ErrorMessage(e);
                return;
            }
        }

        private void CopyHTMLContent(object sender, EventArgs e)
        {
            this.u_output.Document.ExecCommand("Copy", false, null);
        }

        private void SelectAllHTMLContent(object sender, EventArgs e)
        {
            this.u_output.Document.ExecCommand("SelectAll", false, null);
        }

        private void u_closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
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