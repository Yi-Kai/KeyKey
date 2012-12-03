/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Windows.Forms;

namespace TakaoPreference
{
    public class UpdateHelper
    {
        public static string CustomerCareURL = "http://tw.help.cc.yahoo.com/feedback.html?id=3430";

        public static string GetStringFromStream(Stream s)
        {
            StreamReader reader = new StreamReader(s);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        public static void SaveStringToFile(string file, string content)
        {
            StreamWriter writer = new StreamWriter(file);
            writer.Write(content);
            writer.Close();
        }

        public static string ReadStringFormRequest(WebRequest request)
        {
            WebResponse response = null;
            response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            return UpdateHelper.GetStringFromStream(resStream);
        }

        public static void SaveResponceToFile(string file, WebRequest request)
        {
            string content = UpdateHelper.ReadStringFormRequest(request);
            UpdateHelper.SaveStringToFile(file, content);
        }

        public static string GetVersionInfo()
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if(callback == null)
                return "";

            string filename = callback.temporaryFilename("VersionInfo.xml");
            string userInfoForPOST = "&userinfo=" + callback.userInfoForPOST();

            WebRequest request = null;
           
            try
            {
                Encoding encode = Encoding.GetEncoding("utf-8");
                byte[] arrB = encode.GetBytes(userInfoForPOST);

                request = WebRequest.Create(callback.versionInfoURL());
                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                request.Timeout = 1000 * 5;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(arrB, 0, arrB.Length);
                reqStream.Close();
                UpdateHelper.SaveResponceToFile(filename, request);
            }
            catch
            {
                return "";
            }
            return filename;
        }

        public static string GetVersionInfoSignature()
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
                return "";
            string filename = callback.temporaryFilename("VersionInfo.sig");

            try
            {
                WebClient client = new WebClient();
                client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                client.DownloadFile(new Uri(callback.versionInfoSignatureURL()), filename);
            }
            catch
            {
                return "";
            }
            return filename;
        }

        public static bool ValidateFile(string packageFile, string signatureFile)
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
                return false;
            bool result = callback.validateFile(packageFile, signatureFile);
            return result;
        }

        public static bool ShouldUpdate(string XMLfilename)
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
                return false;
            bool result = callback.shouldUpdate(XMLfilename);
            return result;
        }

        public static string ActionURL()
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
                return "";
            return callback.actionURL();
        }

        public static string SignatureURL()
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
                return "";
            return callback.signatureURL();
        }
        
        public static string LocaleTaggedChangeLogURL()
        {
            PreferenceConnector callback = PreferenceConnector.SharedInstance;
            if (callback == null)
                return "";
            return callback.localeTaggedChangeLogURL();            
        }

        public static void DownloadUpdate(string actionURL, string actionFilename, string signatureURL, string signatureFilename, string changeLogURL, bool CheckOptionVisible)
        {
            FormDownload formDownload = new FormDownload(actionURL, actionFilename, signatureURL, signatureFilename, changeLogURL, CheckOptionVisible);
            Application.Run(formDownload);
        }

        public static void DownloadUpdate(string actionURL, string actionFilename, string signatureURL, string signatureFilename, string changeLogURL)
        {
            DownloadUpdate(actionURL, actionFilename, signatureURL, signatureFilename, changeLogURL, true);
        }
    }
}
