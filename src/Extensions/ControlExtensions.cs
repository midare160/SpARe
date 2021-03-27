using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.Extensions
{
    public static class ControlExtensions
    {
        public static async Task RunAsync(this Control control, Action action, params Control[] subControlsToDisable) =>
            await control.RunAsync(action, subControlsToDisable.AsEnumerable());

        public static async Task RunAsync(this Control control, Action action, IEnumerable<Control> subControlsToDisable) =>
            await control.Run(Task.Run(action), subControlsToDisable);

        public static async Task Run(this Control control, Task task, params Control[] subControlsToDisable) =>
            await control.Run(task, subControlsToDisable.AsEnumerable());

        public static async Task Run(this Control control, Task task, IEnumerable<Control> subControlsToDisable)
        {
            control.ThrowIfNull(nameof(control));
            task.ThrowIfNull(nameof(task));
            subControlsToDisable.ThrowIfNull(nameof(subControlsToDisable));

            var controlsWithInitialState = subControlsToDisable.ToDictionary(c => c, c => c.Enabled);

            try
            {
                control.UseWaitCursor = true;
                DisableControls(subControlsToDisable);
                await task;
            }
            finally
            {
                ResetControlsState(controlsWithInitialState);
                control.UseWaitCursor = false;
            }
        }

        private static void DisableControls(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = false;
            }
        }

        private static void ResetControlsState(IDictionary<Control, bool> controlsWithInitialState)
        {
            foreach (var control in controlsWithInitialState)
            {
                control.Key.Enabled = control.Value;
            }
        }
    }
}
