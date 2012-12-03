// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using TakaoPreference;

[assembly:SecurityPermission( SecurityAction.RequestMinimum, ControlThread = true )]
namespace QuickSetup
{
    /// <remarks>
	/// QuickSetup is the post-installation tool of the Yahoo! KeyKey project.
	/// This tool will be launched every time after a user install a copy of Yahoo!
	/// KeyKey. It helps users to choose their primary Chinese Input Method, and
	/// ask users to set their homepage and default search engine to Yahoo! Taiwan.
    /// </remarks>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
			string systemFolderPath = string.Empty;

            if (args.Length > 0)
            {
                if (args[0].Length > 0)
                    systemFolderPath = args[0];
            }

			// Unfortunately, we're working on an Internationalized/localized 
			// Application, so we have to handle the locale issue.
			//
			// Sometimes, the CurrentCulture and tne CurrentUICulture are
			// different, so we have to change the CurrentUICulture to what
			// it should be, since we have only some limited localized DLLs.
			
            string locale = CultureInfo.CurrentCulture.ToString();
            if (locale.Equals("zh-TW") || locale.Equals("zh-HK")|| 
                locale.Equals("zh-CHT") || locale.Equals("zh-SG") ||
                locale.Equals("zh-MO"))
            {
                CultureInfo cultureInfo = new CultureInfo("zh-TW", false);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }

            if (locale.Equals("zh-CN") || locale.Equals("zh-CHS"))
            {
                CultureInfo cultureInfo = new CultureInfo("zh-CN", false);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            QuickSetup.RegisterFileAssociation();
            //Application.Run(new QuickSetup(m_generalDictionary, m_generalXMLpath, systemFolderPath));
			Application.Run(new QuickSetup(systemFolderPath));

        }
    }
}