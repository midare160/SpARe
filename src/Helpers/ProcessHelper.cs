using System.Diagnostics;
using System.Linq;

namespace Spare.Helpers
{
    public static class ProcessHelper
    {
        private const int DefaultExitCode = -1;

        /// <summary>
        /// Finds the first process with the given <paramref name="processName"/>, waits for it to exit and then returns it's exit code.
        /// </summary>
        /// <returns><see cref="Process.ExitCode"/> or -1, if no process with given <paramref name="processName"/> was found.</returns>
        public static int WaitForExit(string? processName)
        {
            using var process = Process.GetProcessesByName(processName).FirstOrDefault();

            if (process == null)
            {
                return DefaultExitCode;
            }

            int? exitCode = null;

            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => exitCode = (s as Process)?.ExitCode;
            process.WaitForExit();

            return exitCode ?? DefaultExitCode;
        }
    }
}
