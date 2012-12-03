/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;

namespace TakaoPreference {
	public class PreferenceConnector
	{
        static public PreferenceConnector SharedInstance = null;

        public virtual void syncLoaderAndCurrentModuleConfig()
        {
        }

        public virtual string versionInfoURL()
        {
            return "";
        }

        public virtual string versionInfoSignatureURL()
        {
            return "";
        }

        public virtual string selfVersion(string component)
        {
            return "";
        }

        public virtual string lastCheckedDateString(string component)
        {
            return "";
        }
        
        public virtual string userInfoForPOST()
        {
            return "";
        }
        
        public virtual string temporaryFilename(string filename)
        {
            return "";
        }
        
        public virtual bool validateFile(string packageFile, string signatureFile)
        {
            return false;
        }
        
        public virtual bool shouldUpdate(string XMLfilename)
        {
            return false;
        }
        
        // returns reinstall, upgradeProgram, upgradeDatabase
        public virtual string updateAction()
        {
            return "";
        }
        
        public virtual string actionURL()
        {
            return "";
        }
        
        public virtual string signatureURL()
        {
            return "";
        }
        
        public virtual string localeTaggedChangeLogURL()
        {
            return "";
        }

        public virtual string versionInfo()
        {
            return "";
        }

        public virtual void unlinkFile(string filename)
        {
        }
        
        public virtual bool performAction(string action, string filename)
        {
            if (action == "reinstall") {
                // opens the downloaded file (.msi)
            }
            
            return false;
        }

        public virtual string primaryInputMethod()
        {
            return "";
        }
        
        public virtual bool isRunningUnderWow64()
        {
            return false;
        }
        
        public virtual void closePreferencesPanel()
        {            
        }
        
        public virtual bool importPhraseDB(string filename)
        {
            return false;
        }
        
        public virtual bool exportPhraseDB(string filename)
        {
            return false;
        }
        
        public virtual int numberOfUnloadableSignedModules()
        {
            return 0;
        }
        
        public virtual string localizedNameOfUnloadableSignedModulesAtIndex(int index)
        {
            return "";
        }
        
        public virtual bool unloadSignedModuleAtIndex(int index)
        {
            return false;
        }        
        
        public virtual string userFreeCannedMessagePath()
        {
            return "";
        }
	}
};
