
using System;
using System.Runtime.InteropServices;

namespace ReportTool.Core
{
    class Mouse
    {
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        public enum MouseEventFlags : UInt32
        {
            LEFTDOWN = 0x0201,
            LEFTUP = 0x0202,
            MOVE = 0x0200,
        }

        public enum KeyEventFlags : UInt32
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYUP = 0x0101,
        }

        public enum MouseParam : Int32
        {
            MK_LBUTTON = 0x1,
        }

        public static void MouseLeftClick(IntPtr hWnd, POINT location)
        {
            PostMessage(hWnd, (UInt32)MouseEventFlags.LEFTDOWN, (Int32)MouseParam.MK_LBUTTON, location.ToPostParam());
            PostMessage(hWnd, (UInt32)MouseEventFlags.LEFTUP, 0, location.ToPostParam());
        }

        public static void MouseDragUp(IntPtr hWnd)
        {
            PostMessage(hWnd, (UInt32)KeyEventFlags.WM_KEYDOWN, (Int32)0x79, 0);
            PostMessage(hWnd, (UInt32)KeyEventFlags.WM_KEYUP, (Int32)0x79, 0);
        }

        public static void MouseDragDown(IntPtr hWnd)
        {
            PostMessage(hWnd, (UInt32)KeyEventFlags.WM_KEYDOWN, (Int32)0x78, 0);
            PostMessage(hWnd, (UInt32)KeyEventFlags.WM_KEYUP, (Int32)0x78, 0);
        }

        public static POINT GetMousePosition(IntPtr hWnd)
        {
            Core.Rect rc;
            WindowAPI.GetWindowRect(hWnd, out rc);

            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new POINT(w32Mouse.X - rc.X, w32Mouse.Y - rc.Y);
        }
    }
}
