/*
Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
Copyrights licensed under the New BSD License. See the accompanying LICENSE
file for terms.
*/
// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace TakaoPreference
{
    /// <remarks>
    /// The helper utilities.
    /// </remarks>
    public class TakaoHelper
    {
        public static string ProjectID = "Yahoo! KeyKey";
        public static string VenderIdentifer = "com.yahoo.KeyKey";
        public static string GeneralXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".plist");
        public static string TraditionalPhoneticXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".TraditionalMandarin.plist");
        public static string SmartPhoneticXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".SmartMandarin.plist");
        public static string CangjieXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".Generic-cj-cin.plist");
        public static string SimplexXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".Generic-simplex-cin.plist");
		public static string OneKeyXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".OneKey.plist");
		public static string LegacySearchXMLpath = TakaoHelper.GetXMLFullPath(VenderIdentifer + ".Search.plist");

        /// <summary>
        /// A tool to display debug messages.
        /// </summary>
        /// <param name="theMessage"></param>
        public static void msg(string theMessage)
        {
            System.Diagnostics.Debug.WriteLine(theMessage, "Debug");
        }

        public static string GetEnvTempDir()
        {
            return Environment.GetEnvironmentVariable("TEMP");
        }

        public static string GetTempFilePath(string filename)
        {
            return TakaoHelper.GetEnvTempDir() + Path.DirectorySeparatorChar + filename;
        }

        public static string GetTempFilePathFromURL(string URL)
        {
            string filename = URL.Remove(0, URL.LastIndexOf('/') + 1);
            return TakaoHelper.GetEnvTempDir() + Path.DirectorySeparatorChar +filename;
        }

        /// <summary>
        /// A helper to generator the full path of the perference file (which is in XML format) by passing the filename.
        /// </summary>
        /// <param name="filename">The filename of the perference file.</param>
        /// <returns></returns>
        /// 
        public static string GetXMLFullPath(string filename)
        {
            string confDir =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                Path.DirectorySeparatorChar +
                ProjectID +
                Path.DirectorySeparatorChar;

            if (!Directory.Exists(confDir))
            {
                Directory.CreateDirectory(confDir);
            }
            return confDir + filename;
        }
        #region XML related

        public static string SerializeListToString(List<string> list)
        {
            string returnString = "ARRAY:";
            int i = 0;
            foreach(string item in list)
            {
                if (i++ < list.Count)
                    returnString += item + ", ";
                else
                    returnString += item;
                //i++;
            }
            return returnString;
        }

        /// <summary>
        /// A helper to generate a dicitonary from a plist(xml) file.
        /// </summary>
        /// <param name="filename">The filename of the xml source.</param>
        /// <returns></returns>
        public static Dictionary<string, string> DictionaryFromFile(string filename)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if(System.IO.File.Exists(filename))
            {
                try
                {
                    XmlTextReader myReader = new XmlTextReader(filename);
                    myReader.XmlResolver = null;
                    string myKey = "";
                    string myValue = "";
                    List<string> items = new List<string>();

                    while (myReader.Read())
                    {
                        if (myReader.NodeType == XmlNodeType.Element)
                        {
                            if (myReader.Name == "key")
                            {
                                myReader.Read();
                                myKey = myReader.Value.Trim();

                            }
                            if (myReader.Name == "array")
                            {
                                if (myReader.IsEmptyElement)
                                {
                                    items.Clear();
                                }
                                else
                                {
                                    while (myReader.Read() && !(myReader.NodeType == XmlNodeType.EndElement && myReader.Name == "array"))
                                    {
                                        if (myReader.NodeType == XmlNodeType.Element
                                            && myReader.Name == "string")
                                        {
                                            myReader.Read();
                                            items.Add(myReader.Value.Trim());
                                        }
                                    }
                                }
                                myValue = TakaoHelper.SerializeListToString(items);
                                TakaoHelper.msg(myValue);
                                if (myKey.Length > 0)
                                    dictionary.Add(myKey, myValue);
                                items.Clear();

                                myKey = "";
                                myValue = "";
                            }

                            if (myReader.Name == "string")
                            {
                                myReader.Read();
                                myValue = myReader.Value.Trim();
                                if (myKey.Length > 0)
                                    dictionary.Add(myKey, myValue);
                                myKey = "";
                                myValue = "";
                            }
                        }
                    }
                    myReader.Close();
                }
                catch {
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Save a dictionary into an XML file by passing the dictionary object and filename
        /// </summary>
        /// <param name="dictionary">The Dictionary.</param>
        /// <param name="filename">The full path of the file to write.</param>
        public static void DictionaryToFile(Dictionary<string, string> dictionary, string filename)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.XmlResolver = null;
            
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            xmlDocument.AppendChild(xmlDeclaration);
            
            xmlDocument.AppendChild(xmlDocument.CreateDocumentType("plist", "-//Apple//DTD PLIST 1.0//EN", "http://www.apple.com/DTDs/PropertyList-1.0.dtd", null));
            // Somehow applying DTD to the XML parser of the .Net framework
			// makes parsing slow.
            XmlElement plst = xmlDocument.CreateElement("plist");
            xmlDocument.AppendChild(plst);
            XmlElement dict = xmlDocument.CreateElement("dict");
            plst.AppendChild(dict);

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                XmlElement theKey = xmlDocument.CreateElement("key");
                theKey.InnerText = kvp.Key.Trim();
                dict.AppendChild(theKey);

                if (kvp.Value.StartsWith("ARRAY:"))
                {
                    string stringToExplode = kvp.Value.Remove(0, 6);
                    string[] explodedStrings = stringToExplode.Split(", ".ToCharArray());
                    XmlElement theArray = xmlDocument.CreateElement("array");
                    foreach (string item in explodedStrings)
                    {
                        if (item.Length > 0)
                        {
                            XmlElement theString = xmlDocument.CreateElement("string");
                            theString.InnerText = item;
                            theArray.AppendChild(theString);
                        }
                    }
                    dict.AppendChild(theArray);
                }
                else
                {
                    XmlElement theString = xmlDocument.CreateElement("string");
                    theString.InnerText = kvp.Value.Trim();

                    if (theString.InnerText.Length == 0)
                    {
                        theString.IsEmpty = true;
                    }

                    dict.AppendChild(theString);
                }
            }
            XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            xmlDocument.WriteContentTo(writer);
            writer.Close();
        }
        /// <summary>
        /// To dump the content of a dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        public static void DumpDictionary(Dictionary<string, string> dictionary)
        {
            TakaoHelper.PrintDictionary(dictionary);
        }
        /// <summary>
        /// To dump the content of a dictionary.
        /// </summary>
        /// <param name="dictionary"></param>
        public static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                string msg = "key: " + kvp.Key + "=> value: " + kvp.Value;
                TakaoHelper.msg(msg);
            }
        }
        #endregion
    }
}
