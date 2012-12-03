// [AUTO_HEADER]

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices; //< For [DllImport(...)]

namespace BaseIMEUI
{
    struct RECT
    {
        public int Left, Top, Right, Bottom;

        public RECT(int l, int t, int r, int b)
        {
            Left = l;
            Top = t;
            Right = r;
            Bottom = b;
        }
    }

    class Win32FunctionHelper
    {
        // this shuts the compiler's CS0649 warning down

        public struct ClassStyle
        {
            public const int CS_SAVEBITS = 0x0800;            
            public const int CS_DropSHADOW = 0x20000;
            public const int CS_IME = 0x00010000;
            public const int GCL_STYLE = (-26);
        }

        public struct WindowExStyle
        {
            public const int WS_EX_NOACTIVATE = 0x08000000; //< For CreateParams.
            public const int WS_EX_TOPMOST = 0x00000008;
        }

        public struct CmdShow
        {
            public const int SW_SHOWNORMAL = 1;
            public const int SW_SHOWNOACTIVATE = 4; //< For ShowWindow().
            public const int SW_HIDE = 0;

            public const int HWND_TOPMOST = 0xffff;
            public const int HWND_TOP = 0x0000;
            public const int SWP_NOSIZE = 0x0001;
            public const int SWP_NOMOVE = 0x0002;
            public const int SWP_NOACTIVATE = 0x0010;
            public const int SWP_SHOWWINDOW = 0x0040;
            public const int SWP_HIDEWINDOW = 0x0080;
            public const int SWP_NOOWNERZORDER = 0x0200;
        }

        [DllImport("user32")]
        public static extern int SetParent(
            IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32")]
        public static extern int ShowWindow(
            IntPtr hWnd, int nCmdShow);

        [DllImport("user32")]
        public static extern bool SetWindowPos( 
            IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, int uFlags);

        public static void ShowWindowTopMost(IntPtr handle)
        {
            SetParent(handle, IntPtr.Zero);
            SetWindowPos(
                handle, (IntPtr)CmdShow.HWND_TOP,
                0, 0, 0, 0,
                CmdShow.SWP_NOSIZE | CmdShow.SWP_NOMOVE |
                CmdShow.SWP_NOACTIVATE | CmdShow.SWP_SHOWWINDOW);
        }

        public struct MouseMove
        {
            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HT_CAPTION = 0x2;
            public const int WM_MOVING = 534;
            public const int WM_SIZING = 532;
            public const int WM_MOVE = 3;
        }

        public struct WorklingSetFlag
        {
            public const int QUOTA_LIMITS_HARDWS_MIN_ENABLE = 0x00000001;
            public const int QUOTA_LIMITS_HARDWS_MIN_DISABLE = 0x00000002;
            public const int QUOTA_LIMITS_HARDWS_MAX_ENABLE = 0x00000004;
            public const int QUOTA_LIMITS_HARDWS_MAX_DISABLE = 0x00000008;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        // This is Windows Vista only!
        //[DllImport("kernel32.dll")]
        //private static extern bool SetProcessWorkingSetSizeEx(IntPtr proc, int min, int max, int flags);

        [DllImport("psapi.dll")]
        private static extern bool EmptyWorkingSet(IntPtr proc);


        public static void EmptyWorkingSet()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                IntPtr handle = System.Diagnostics.Process.GetCurrentProcess().Handle;
                Win32FunctionHelper.EmptyWorkingSet(handle);
            }
        }

        public static void ReduceMemoryAtFirstTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                IntPtr handle = System.Diagnostics.Process.GetCurrentProcess().Handle;
                Win32FunctionHelper.SetProcessWorkingSetSize(handle, 6 * 1024 * 1024, 6 * 1024 * 1024);
			} 
		}

        public static void ReduceMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                IntPtr handle = System.Diagnostics.Process.GetCurrentProcess().Handle;
                Win32FunctionHelper.SetProcessWorkingSetSize(handle, 6 * 1024 * 1024, 30 * 1024 * 1024);
			}
		}
	} 
}
