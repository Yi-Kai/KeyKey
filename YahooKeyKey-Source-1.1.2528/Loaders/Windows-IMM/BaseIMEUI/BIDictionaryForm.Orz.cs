using System;
using System.Collections.Generic;
using System.Text;

namespace BaseIMEUI
{
    partial class BIDictionaryForm
    {
        private void Orz()
        {
            string html = m_htmlHeader;
            html += 
"<h2>orz \u4e4b\u6b4c</h2>" +
"<p>\u4f5c\u8005\uff1a<a href=\"http://zonble.twbbs.org/\" onclick=\"openURL('http://zonble.twbbs.org/'); return false;\">zonble</a></p>" +
"<p><a href=\"http://zonble.twbbs.org/MIDI/orz.mp3\" onclick=\"openURL('http://zonble.twbbs.org/MIDI/orz.mp3'); return false;\">MP3</a></p>" +
"<p>\u5c0f\u59d0\u554a\u5c0f\u59d0\uff0c\u59b3\u771f\u662f\u7f8e\u9e97\u3002<br/>" +
"\u70cf\u6e9c\u6e9c\u7684\u79c0\u9aee\uff0c\u6c34\u6c6a\u6c6a\u7684\u773c\u775b\u3002<br/>" +
"\u53ea\u8981\u4e00\u60f3\u5230\u59b3\uff0c\u6211\u6eff\u5fc3\u90fdXD\u3002</p>" +
"<p>\u4eca\u5929\u554a\u4eca\u5929\uff0c\u6211\u9f13\u8d77\u52c7\u6c23\u3002<br/>" +
"\u5230\u5e95\u5fc3\u6b78\u4f55\u8655\uff0c\u6211\u60f3\u8981\u554f\u554f\u59b3\u3002<br/>" +
"\u4f46\u59b3\u7684\u7b54\u6848\uff0c\u771f\u8b93\u6211 &gt;_&lt; \u3002</p>" +
"<p>\u8aaa\u6211\u662f\u597d\u4eba\uff0c\u59b3\u8aaa\u771f\u662f\u5c0d\u4e0d\u8d77\u3002<br/>" +
"\u8aaa\u6211\u662f\u597d\u4eba\uff0c\u5c31\u5ba3\u5224\u6211\u7684\u547d\u904b\u3002<br/>" +
"\u8aaa\u6211\u662f\u597d\u4eba\uff0c\u6211\u632b\u6298\u4fef\u8dea\u4e0d\u8d77\u3002<br/>" +
"\u8aaa\u6211\u662f\u597d\u4eba\uff0c\u6211\u53ea\u80fdorz\u2026\u3002</p>";
            html += "</body></html>";
            this.u_output.DocumentText = html;
        }
    }
}
