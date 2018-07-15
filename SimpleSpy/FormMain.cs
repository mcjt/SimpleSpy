using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace SimpleSpy {
   public partial class FormMain : Form {
      public FormMain() {
         InitializeComponent();
      }

      private void DrawPicturBoxCursor(Graphics g, Cursor csr) {
         g.FillRectangle(Brushes.White, this.pbxCap.DisplayRectangle);
         if (csr != null) {
            Rectangle rect = new Rectangle((this.pbxCap.Width - csr.Size.Width)/2, (this.pbxCap.Height - csr.Size.Height)/2, csr.Size.Width, csr.Size.Height);
            csr.Draw(g, rect);
         }
      }

      IntPtr oldHwnd = IntPtr.Zero;

      private void SpyScreen() {
         Point ptSpy = Control.MousePosition;
         var hwnd = Win32Api.WindowFromPoint(ptSpy);
         string clsName = Win32Api.GetClassName(hwnd);
         string caption = Win32Api.GetWindowText(hwnd);
         Rectangle rect = Win32Api.GetWindowRect(hwnd);

         string message = 
$@"handle : {hwnd.ToInt32():X8}
class : {clsName}
caption : {((hwnd == this.tbxSpy.Handle) ? string.Empty : caption)}
rect : {rect}";
         this.tbxSpy.Text = message;
         
         if (oldHwnd != IntPtr.Zero && oldHwnd != hwnd) {
            Win32Api.RedrawWindow(oldHwnd);
         }

         var g = Graphics.FromHdc(Win32Api.GetWindowDC(IntPtr.Zero));
         g.DrawRectangle(Pens.Red, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
         g.Dispose();

         oldHwnd = hwnd;
      }

      private void pbxCap_MouseMove(object sender, MouseEventArgs e) {
         if (Control.MouseButtons != MouseButtons.Left)
            return;
         this.SpyScreen();
         this.pbxCap.Refresh();
      }

      private void FormMain_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {
         e.Cancel = true;

         var caption = "Simple Spy";
         var link = "https://github.com/sim511777/SimpleSpy";
         var message = link + "\r\nWould yo visit?";

         var dr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
         if (dr == DialogResult.Yes) {
            System.Diagnostics.Process.Start(link);
         }
      }

      private void pbxSpy_MouseDown(object sender, MouseEventArgs e) {
         this.Cursor = Cursors.Cross;
         this.pbxCap.Refresh();
      }

      private void pbxSpy_MouseUp(object sender, MouseEventArgs e) {
         this.Cursor = Cursors.Default;
         this.pbxCap.Refresh();
      }

      private void pbxCap_Paint(object sender, PaintEventArgs e) {
         Cursor pbxCursor = this.Cursor == Cursors.Cross ? null : Cursors.Cross;
         this.DrawPicturBoxCursor(e.Graphics, pbxCursor);
      }
   }
}
