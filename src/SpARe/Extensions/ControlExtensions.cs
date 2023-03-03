using SpARe.Utility;

namespace SpARe.Extensions
{
    public static class ControlExtensions
    {
        public static IDisposable StartWaitCursor(this Control control)
        {
            Cursor.Current = Cursors.WaitCursor;
            control.UseWaitCursor = true;

            return new Disposable<Control>(control, static c =>
			{
                c!.UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
			});
        }
    }
}
