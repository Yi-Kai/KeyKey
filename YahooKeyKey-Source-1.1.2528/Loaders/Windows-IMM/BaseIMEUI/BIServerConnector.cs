// [AUTO_HEADER]

using System;
using System.Collections.Generic;

namespace BaseIMEUI {
    /// <remarks>
    /// The connector between the C# UI and the C++ CLI server.
    /// </remarks>
    public class BIServerConnector
    {
        /// <summary>
        /// The shared instance of the BIServerConnector class.
        /// </summary>
        public static BIServerConnector SharedInstance = null;
        
        /// <summary>
        /// If a configuration key is available in the OpenVanilla loader.
        /// </summary>
        /// <param name="key">The name of the configuration key.</param>
        /// <returns></returns>
        public virtual bool hasLoaderConfigKey(string key)
        {
            return false;
        }

        /// <summary>
        /// If the value of a configuration key in the OpenVanilla loader 
		/// is true.
        /// </summary>
        /// <param name="key">The name of the configuration key.</param>
        /// <returns></returns>
        public virtual bool isLoaderConfigKeyTrue(string key)
        {
            return false;
        }

        /// <summary>
        /// Set a configuration key in the OpenVanilla loader with a new
 		/// string value
        /// </summary>
        /// <param name="key">The name of the configuration key.</param>
        /// <param name="value">The new string value.</param>
        public virtual void setLoaderConfigKeyStringValue(string key, string value)
        {
        }

        /// <summary>
        /// Retreive the string value of a configuration key in the
 		/// OpenVanilla loader.
        /// </summary>
        /// <param name="key">The name of the configuration key</param>
        /// <returns>The string value.</returns>
        public virtual string stringValueForLoaderConfigKey(string key)
        {
            return "";
        }
        
        public virtual List<string> arrayValueForLoaderConfigKey(string key)
        {
            List<string> array = new List<string>();
            return array;
        }

        public virtual string stringValueForConfigKeyOfModule(string key, string moduleID)
        {
            return "";
        }

        public virtual void forceSyncModuleConfig(string moduleID)
        {
        }
        
        public virtual void deleteAllKeysAndValuesInModuleConfig(string moduleID)
        {
        }

        public virtual void syncLoaderConfig()
        {
        }

        /// <summary>
        /// Jump to the previous page of the candidate list.
        /// </summary>
        public virtual void gotoPrevPage()
        {
        }

        /// <summary>
        /// Jump to the next page of the candidate list.
        /// </summary>
        public virtual void gotoNextPage()
        {
        }

        public virtual void sendOneKeyChar()
        {
        }

        /// <summary>
        /// Send a character as a keycode 
        /// </summary>
        /// <param name="c">The chaacter to send</param>
        public virtual void sendChar(char c)
        {
        }

        /// <summary>
        /// Ask the input method software to send a string to the current application.
        /// </summary>
        /// <param name="text">The string to send.</param>
		public virtual void sendString(string text)
		{
		}

        /// <summary>
        /// Retrieve the identifer of the current primary input method.
        /// </summary>
        /// <returns>The identifer of the current primary input method.</returns>
        public virtual string primaryInputMethod()
        {
            return "";
        }

        /// <summary>
        /// Set the current primary input method with specified identifer.
        /// </summary>
        /// <param name="moduleIdentifier">The identifer of the input method.</param>
        public virtual void setPrimaryInputMethod(string moduleIdentifier, bool sendFakeKeyToCleanUpState)
        {
        }

        /// <summary>
        /// The Alphanumeric mode is on or not.
        /// </summary>
        /// <returns></returns>
        public virtual bool isAlphanumericMode()
        {
            return false;
        }

        /// <summary>
        /// To enable or disable the Alphanumeric mode.
        /// </summary>
        /// <param name="mode"></param>
        public virtual void setAlphanumericMode(bool mode)
        {
        }

        /// <summary>
        /// The Full-Width Character mode is on or not.
        /// </summary>
        /// <returns></returns>
        public virtual bool isFullWidthCharacterMode()
        {
            return false;
        }

        /// <summary>
        /// To enable or disable the Full-Width Character mode.
        /// </summary>
        /// <param name="mode"></param>
        public virtual void setFullWidthCharacterMode(bool mode)
        {            
        }

        /// <summary>
        /// An Output Filter module is enabled or not. 
        /// </summary>
        /// <param name="moduleIdentifier">The identifer of the specified Output Filter.</param>
        /// <returns></returns>
        public virtual bool isOutputFilterEnabled(string moduleIdentifier)
        {
			return false;
        }

        public virtual void toggleOutputFilter(string moduleIdentifier)
        {
        }

        /// <summary>
        /// An Around Filter module is enabled or not.
        /// </summary>
        /// <param name="moduleIdentifier">The identifer of the specified Around Filter.</param>
        /// <returns></returns>
        public virtual bool isAroundFilterEnabled(string moduleIdentifier)
        {
            return false;
        }

        public virtual void toggleAroundFilter(string moduleIdentifier)
        {
        }
        
        public virtual bool moduleWithWildcardNameExists(string wildcardName)
        {
            return false;
        }

        /// <summary>
        /// Retreive the dictionary of the identifers of all Input Method modules.
        /// </summary>
        /// <returns>The identifers of all Input Method modules.</returns>
        public virtual Dictionary<string, string> allInputMethodIdentifiersAndNames()
        {
            Dictionary<string, string> dictionary = new Dictionary<string,string>();
            return dictionary;
        }

        /// <summary>
        /// Retreive the dictionary of the identifers of all Output Filter modules.
        /// </summary>
        /// <returns>The identifers of all Output Filter modules.</returns>

        public virtual Dictionary<string, string> allOutputFilterIdentifiersAndNames()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            return dictionary;
        }

        /// <summary>
        /// Retreive the dictionary of the identifers of all Around Filter modules.
        /// </summary>
        /// <returns>The identifers of all Around Filter modules.</returns>
        public virtual Dictionary<string, string> allAroundFilterIdentifiersAndNames()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            return dictionary;
        }        
        
        public virtual string databaseVersion()
        {
            return "";
        }
        
        public virtual bool isRunningUnderWow64()
        {
            return false;
        }
        
        // this tells BaseIMEServer to cancel the waiting state of the punctuation keyboard, called by the keyboard form
        public virtual void cancelPunctuationKeyboardWaitingState()
        {
        }
        
        public virtual List<string> cannedMessageCategories()
        {
            List<string> result = new List<string>();
            result.Add("Default Greetings");
            return result;
        }
        
        public virtual List<KeyValuePair<string, string> > cannedMessagesOfCategory(int index)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            if (index == 0)
            {
                result.Add(new KeyValuePair<string, string>("Hello, world!", "Hello, world!"));
                result.Add(new KeyValuePair<string, string>("Season's greetings!", "Season's greetings!"));
            }
            
            return result;
        }

        public virtual List<string> symbolButtonCategories()
        {
            List<string> result = new List<string>();
            result.Add("Default Category");
            return result;
        }
        
        public virtual List<string> symbolButtonsOfCategory(int index)
        {
            List<string> result = new List<string>();
            if (index == 0)
            {
                result.Add(",");
                result.Add(".");
            }
            
            return result;
        }
        
        public virtual void startUpdateServerDataThread()
        {
        }
    };    
};
