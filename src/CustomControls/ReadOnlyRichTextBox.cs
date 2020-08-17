using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpotifyAdRemover.CustomControls
{
    public class ReadOnlyRichTextBox : RichTextBox
    {
        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);

        public ReadOnlyRichTextBox()
        {
            this.MouseDown += new MouseEventHandler(this.ReadOnlyRichTextBox_Mouse);
            this.MouseUp += new MouseEventHandler(this.ReadOnlyRichTextBox_Mouse);
            base.ReadOnly = true;
            base.TabStop = false;
            HideCaret(this.Handle);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        protected override void OnEnter(EventArgs e)
        {
            HideCaret(this.Handle);
        }

        private void ReadOnlyRichTextBox_Mouse(object sender, MouseEventArgs e)
        {
            HideCaret(this.Handle);
        }
    }
}
