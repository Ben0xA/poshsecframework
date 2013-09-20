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

        public RichTextBoxCaret()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.KeyDown += this_KeyDown;
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            this.DrawCaret();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.DrawCaret();
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                AutoComplete();
            }
        }

        private void AutoComplete()
        {
            int cmdstart = this.Text.LastIndexOf(' ', this.SelectionStart - 1) + 1;
            int cmdstop = this.SelectionStart;
            String cmdtxt = this.Text.Substring(cmdstart, cmdstop - cmdstart);
            this.Text += cmdtxt;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            { 
                case Keys.Tab:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
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
    }
}
