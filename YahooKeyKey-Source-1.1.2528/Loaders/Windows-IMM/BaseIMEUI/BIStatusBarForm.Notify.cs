// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace BaseIMEUI
{
    public partial class BIStatusBarForm
    {
        #region Handle Notify
        private delegate void NotifyCallBack(string Message, string Title);
        private void InvokedNotify(string Messsage, string Title)
        {
            BINotifyForm notify = new BINotifyForm();
            notify.SetMesssage(Messsage);
            notify.SetText(Title);
            notify.Show();
        }

        /// <summary>
        /// Show the Notify Window with a message and the default title.
        /// </summary>
        /// <param name="Message">The content of the message.</param>
        public void Notify(string Message)
        {
	        BIServerConnector callback = BIServerConnector.SharedInstance;
            if (callback != null)
            {
				if (!callback.isLoaderConfigKeyTrue("ShouldUseNotifyWindow"))
					return;
            }

            if (this.InvokeRequired) 
			{
	            List<string> list = new List<string>();
	            list.Add(Message);
	            string currentLocale = CultureInfo.CurrentUICulture.Name;
	            if (currentLocale.Equals("zh-TW"))
	                list.Add("Yahoo! \u5947\u6469\u8f38\u5165\u6cd5");
	            else if (currentLocale.Equals("zh-CN"))
	                list.Add("Yahoo! \u5947\u6469\u8f93\u5165\u6cd5");
	            else
	                list.Add("Yahoo! KeyKey");

	            this.Invoke(new NotifyCallBack(InvokedNotify),
	 				list.ToArray());	
				return;
			}
			else {
				string currentLocale = CultureInfo.CurrentUICulture.Name;
				string Title = "";
	            if (currentLocale.Equals("zh-TW"))
	                Title = "Yahoo! \u5947\u6469\u8f38\u5165\u6cd5";
	            else if (currentLocale.Equals("zh-CN"))
	                Title = "Yahoo! \u5947\u6469\u8f93\u5165\u6cd5";
	            else
	                Title = "Yahoo! KeyKey";
				this.InvokedNotify(Message, Title);
			}

        }
        /// <summary>
        /// Show the Notify window with a message and the customized title.
        /// </summary>
        /// <param name="Message">The content of the message.</param>
        /// <param name="Title">The customized title.</param>
        public void Notify(string Message, string Title)
        {
	        BIServerConnector callback = BIServerConnector.SharedInstance;	
            if (callback != null)
            {
				if (!callback.isLoaderConfigKeyTrue("ShouldUseNotifyWindow"))
					return;
            }	
            if (this.InvokeRequired) 
            	this.Invoke(new NotifyCallBack(InvokedNotify),
 					new object[] { Message, Title });
			else
				this.InvokedNotify(Message, Title);

        }
        #endregion

        #region Handle Beep
        /// <summary>
        /// Alert user with the system default alert sound or customzied
 		/// sound clip.
        /// </summary>
        /// <param name="filename">The full path of the sound clip.</param>
        public void Beep(string filename)
        {

            if (filename.Equals("Default") || filename.Length == 0)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else if (File.Exists(filename))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(filename);
                try
                {
                    player.Play();
                }
                catch { }
                player.Dispose();
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
        #endregion
    }
}
