using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.Extensions
{
    public static class ControlExtensions
    {
        public static async Task RunAsync(this Control control, Action action, params Control[] subControlsToDisable) =>
            await RunAsync(control, action, (IEnumerable<Control>)subControlsToDisable);

        public static async Task RunAsync(this Control control, Action action, IEnumerable<Control> subControlsToDisable)
        {
            control.ThrowIfNull(nameof(control));
            action.ThrowIfNull(nameof(control));
            subControlsToDisable.ThrowIfNull(nameof(subControlsToDisable));

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

        private static void SetControlsState(IEnumerable<Control> controls, bool enabled)
        {
            foreach (var control in controls)
            {
                control.Enabled = enabled;
            }
        }
    }
}
