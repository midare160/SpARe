using System;
using System.Windows.Forms;

namespace Spare.Helpers
{
    public class ThreadHelper
    {
        /// <summary>
        /// Helper method to determine if invoking is required. If so, it will rerun the method on the correct thread.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> that might require invoking.</param>
        /// <param name="action"><see cref="Action"/> to perform on the <paramref name="control"/> thread if invoking is required.</param>
        public static void InvokeControl(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
                return;
            }

            action();
        }
    }
}
