using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.Extensions
{
    public static class ControlExtensions
    {
        public static async Task RunAsync(this Control control, Action action, params Control[] subControlsToDisable)
        {
            control.ThrowIfArgumentNull(nameof(control));
            action.ThrowIfArgumentNull(nameof(control));
            subControlsToDisable.ThrowIfArgumentNull(nameof(subControlsToDisable));

            try
            {
                control.UseWaitCursor = true;
                SetControlsState(subControlsToDisable, false);
                await Task.Run(action);
            }
            finally
            {
                SetControlsState(subControlsToDisable, true);
                control.UseWaitCursor = false;
            }
        }

        private static void SetControlsState(Control[] controls, bool enabled)
        {
            foreach (var control in controls)
            {
                control.Enabled = enabled;
            }
        }
    }
}
