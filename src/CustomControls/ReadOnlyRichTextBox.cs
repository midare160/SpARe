using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Spare.CustomControls
{
    public class ReadOnlyRichTextBox : RichTextBox
    {
        #region Fields
        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hwnd);
        #endregion

        #region Constructors
        public ReadOnlyRichTextBox()
        {
            this.MouseDown += ReadOnlyRichTextBox_Mouse;
            this.MouseUp += ReadOnlyRichTextBox_Mouse;
            this.MouseWheel += ReadOnlyRichTextBox_Mouse;
            base.ReadOnly = true;
            base.TabStop = false;
            base.Cursor = Cursors.Default;
            HideCaret(this.Handle);
        }
        #endregion

        #region Procedures
        protected override void OnGotFocus(EventArgs e) 
            => HideCaret(this.Handle);

        protected override void OnEnter(EventArgs e) 
            => HideCaret(this.Handle);

        private void ReadOnlyRichTextBox_Mouse(object sender, MouseEventArgs e) 
            => HideCaret(this.Handle);

        #endregion
    }
}
