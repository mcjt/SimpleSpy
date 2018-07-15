using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace SimpleSpy {
   class Win32Api {
      [DllImport("User32.dll")] 
      public static extern IntPtr WindowFromPoint(Point p); 
 
      [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)] 
      private static extern int GetWindowTextLength(IntPtr hWnd); 
      [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)] 
      private static extern long GetWindowText(IntPtr hwnd, StringBuilder lpString, long nMaxCount);
      public static string GetWindowText(IntPtr hwnd) {
         int textLen = Win32Api.GetWindowTextLength(hwnd)+1;
         var sb = new StringBuilder(textLen);
         Win32Api.GetWindowText(hwnd, sb, textLen);
         return sb.ToString();
      }
 
      [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)] 
      private static extern long GetClassName(IntPtr hwnd, StringBuilder lpClassName, long nMaxCount); 
      public static string GetClassName(IntPtr hwnd) {
         var sb = new StringBuilder(256);
         Win32Api.GetClassName(hwnd, sb, 256);
         return sb.ToString();
      }

      [DllImport("User32.dll")] 
      public static extern IntPtr GetParent(IntPtr hwnd); 
 
      [DllImport("User32.dll")] 
      public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point p); 

      [DllImport("User32.dll")] 
      private static extern bool GetWindowRect(IntPtr hwnd, ref RECT rect);
      public static Rectangle GetWindowRect(IntPtr hwnd) {
         var rect = default(RECT);
         GetWindowRect(hwnd, ref rect);
         return new Rectangle(rect.left, rect.top, rect.right-rect.left, rect.bottom-rect.top);
      }

      [DllImport("User32.dll")] 
      private static extern bool GetClientRect(IntPtr hwnd, ref RECT rect); 
      public static Rectangle GetClientRect(IntPtr hwnd) {
         var rect = default(RECT);
         GetClientRect(hwnd, ref rect);
         return new Rectangle(rect.left, rect.top, rect.right-rect.left, rect.bottom-rect.top);
      }

      [DllImport("User32.dll")] 
      public static extern IntPtr GetWindowDC(IntPtr hwnd);

      const int RDW_INVALIDATE          = 0x0001;
      const int RDW_INTERNALPAINT       = 0x0002;
      const int RDW_ERASE               = 0x0004;

      const int RDW_VALIDATE            = 0x0008;
      const int RDW_NOINTERNALPAINT     = 0x0010;
      const int RDW_NOERASE             = 0x0020;

      const int RDW_NOCHILDREN          = 0x0040;
      const int RDW_ALLCHILDREN         = 0x0080;

      const int RDW_UPDATENOW           = 0x0100;
      const int RDW_ERASENOW            = 0x0200;

      const int RDW_FRAME               = 0x0400;
      const int RDW_NOFRAME             = 0x0800;

      [DllImport("User32.dll")] 
      private static extern bool RedrawWindow(IntPtr hwnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
      public static bool RedrawWindow(IntPtr hwnd) {
         return RedrawWindow(hwnd, IntPtr.Zero, IntPtr.Zero, RDW_FRAME | RDW_UPDATENOW | RDW_NOCHILDREN);
      }
   }

   struct RECT {
      public int left;
      public int top;
      public int right;
      public int bottom;
   }
}
