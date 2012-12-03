// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices; //< For [DllImport(...)]

namespace BaseIMEUI
{
     
    public class Win32FontHelper
    {
        private static string c_defaultFontFamilyName = "";
        public static bool isInFontFamilyArray(string Name)
        {
            FontFamily[] fArray = FontFamily.Families;
            foreach (FontFamily f in fArray)
            {
                if (f.GetName(0) == Name)
                    return true;
            }
            return false;
        }

        public static void setDefaultFontFamilyName(string name)
        {
            c_defaultFontFamilyName = name;
        }

        public static FontFamily DefaultFontFamily()
        {
            if (Win32FontHelper.c_defaultFontFamilyName.Length > 0)
            {
                return new FontFamily(Win32FontHelper.c_defaultFontFamilyName);
            }

            if (Win32FontHelper.isInFontFamilyArray("\u5fae\u8edf\u6b63\u9ed1\u9ad4"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "\u5fae\u8edf\u6b63\u9ed1\u9ad4";
                return new FontFamily("\u5fae\u8edf\u6b63\u9ed1\u9ad4");
            }
            if (Win32FontHelper.isInFontFamilyArray("Microsoft JhengHei"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "Microsoft JhengHei";
                return new FontFamily("Microsoft JhengHei");
            }
            if (Win32FontHelper.isInFontFamilyArray("\u5fae\u8edf\u96c5\u9ed1\u9ad4"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "\u5fae\u8edf\u96c5\u9ed1\u9ad4";
                return new FontFamily("\u5fae\u8edf\u96c5\u9ed1\u9ad4");
            }
            if (Win32FontHelper.isInFontFamilyArray("Microsoft YaHei"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "Microsoft YaHei";
                return new FontFamily("Microsoft YaHei");
            }
            if (Win32FontHelper.isInFontFamilyArray("\u7d30\u660e\u9ad4")) // MingLiU
            {
                Win32FontHelper.c_defaultFontFamilyName = "\u7d30\u660e\u9ad4";
                return new FontFamily("\u7d30\u660e\u9ad4");
            }
            if (Win32FontHelper.isInFontFamilyArray("\u65b0\u7d30\u660e\u9ad4")) // MingLiU
            {
                Win32FontHelper.c_defaultFontFamilyName = "\u65b0\u7d30\u660e\u9ad4";
                return new FontFamily("\u65b0\u7d30\u660e\u9ad4");
            }
            if (Win32FontHelper.isInFontFamilyArray("MingLiU"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "MingLiU";
                return new FontFamily("MingLiU");
            }
            if (Win32FontHelper.isInFontFamilyArray("SimHei"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "SimHei";
                return new FontFamily("SimHei");
            }
            if (Win32FontHelper.isInFontFamilyArray("SimSun"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "SimSun";
                return new FontFamily("SimSun");
            }
            if (Win32FontHelper.isInFontFamilyArray("Arial Unicode MS"))
            {
                Win32FontHelper.c_defaultFontFamilyName = "Arial Unicode MS";
                return new FontFamily("Arial Unicode MS");
            }
            Win32FontHelper.c_defaultFontFamilyName = "Arial";
            return new FontFamily("Arial");
        }
    }
}
