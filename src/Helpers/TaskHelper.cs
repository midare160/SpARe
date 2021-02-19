using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.Helpers
{
    public static class TaskHelper
    {
        public static async Task RunAsync(Action action, params Control[] controlsToDisable)
        {
            try
            {
                SetControlState(controlsToDisable, false);
                await Task.Run(action);
            }
            finally
            {
                SetControlState(controlsToDisable, true);
            }
        }

        public static async Task<TResult> RunAsync<TResult>(Func<TResult> function, params Control[] controlsToDisable)
        {
            try
            {
                SetControlState(controlsToDisable, false);
                return await Task.Run(function);
            }
            finally
            {
                SetControlState(controlsToDisable, true);
            }
        }

        private static void SetControlState(Control[] controls, bool enabled)
        {
            foreach (var control in controls)
            {
                control.Enabled = enabled;
            }
        }
    }
}
