using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.Extensions
{
    public static class ControlExtensions
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static async Task RunAsync(this Control control, Action action, string actionName, params Control[] subControlsToDisable) =>
            await control.RunAsync(action, actionName, subControlsToDisable.AsEnumerable());

        public static async Task RunAsync(this Control control, Action action, string actionName, IEnumerable<Control> subControlsToDisable) =>
            await control.RunAsync(Task.Run(action), actionName, subControlsToDisable);

        public static async Task RunAsync(this Control control, Task task, string taskName, params Control[] subControlsToDisable) =>
            await control.RunAsync(task, taskName, subControlsToDisable.AsEnumerable());

        public static async Task RunAsync(this Control control, Task task, string taskName, IEnumerable<Control> subControlsToDisable)
        {
            control.ThrowIfNull(nameof(control));
            task.ThrowIfNull(nameof(task));
            subControlsToDisable.ThrowIfNull(nameof(subControlsToDisable));

            var controlsWithInitialState = subControlsToDisable.ToDictionary(c => c, c => c.Enabled);

            try
            {
                control.UseWaitCursor = true;
                DisableControls(subControlsToDisable);

                Logger.Trace($"Performing {taskName}...");
                await task;
                Logger.Trace("Task successfully completed.");
            }
            finally
            {
                ResetControlsState(controlsWithInitialState);
                control.UseWaitCursor = false;
            }
        }

        private static void DisableControls(IEnumerable<Control> controls)
        {
            Logger.Trace($"Disabling controls: {string.Join(", ", controls.Select(c => c.Name))}...");

            foreach (var control in controls)
            {
                control.Enabled = false;
            }

            Logger.Trace("Finished disabling controls.");
        }

        private static void ResetControlsState(IDictionary<Control, bool> controlsWithInitialState)
        {
            Logger.Trace($"Resetting controls to their initial enabled state: {string.Join(", ", controlsWithInitialState.Select(k => $"{k.Key.Name} => {k.Value}"))}...");

            foreach (var control in controlsWithInitialState)
            {
                control.Key.Enabled = control.Value;
            }

            Logger.Trace("Finished resetting controls.");
        }
    }
}
