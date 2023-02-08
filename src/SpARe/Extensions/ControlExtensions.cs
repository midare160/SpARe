using SpARe.Utility;

namespace SpARe.Extensions
{
    public static class ControlExtensions
    {
        public static IDisposable StartWaitCursor(this Control control)
        {
            control.UseWaitCursor = true;

            return new Disposable(() => control.UseWaitCursor = false);
        }
    }
}
