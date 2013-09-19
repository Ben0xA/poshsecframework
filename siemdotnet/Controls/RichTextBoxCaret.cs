using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace poshsecframework.Controls
{
    class RichTextBoxCaret : RichTextBox
    {
        [DllImport("user32.dll")]
        static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);
        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);
        public event EventHandler TabPressed;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.DrawCaret();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.DrawCaret();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.DrawCaret();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            this.DrawCaret();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.DrawCaret();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.DrawCaret();
        }

        public void DrawCaret()
        {
            Bitmap bmp = Properties.Resources.caret_underline;
            Size sz = new Size(0, 0);
            //This size matches the Lucidia Console 9.75pt font.
            //Adjust as necessary.
            sz.Width = 8;
            sz.Height = 13;
            CreateCaret(this.Handle, bmp.GetHbitmap(Color.White), sz.Width, sz.Height);
            ShowCaret(this.Handle);
        }

        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Tab:
                        this.OnTabpressed();
                        return true;
                    default:
                        return base.ProcessCmdKey(ref m, keyData);    
                }
            }
            else
            {
                return base.ProcessCmdKey(ref m, keyData);          
            }            
        }

        public virtual void OnTabpressed()
        {
            if (TabPressed != null)
            {
                this.TabPressed(this, EventArgs.Empty);
            }
        }
    }
}
