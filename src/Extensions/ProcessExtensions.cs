using System.Diagnostics;
using System.Threading.Tasks;

namespace Spare.Extensions
{
    public static class ProcessExtensions
    {
        private const int DefaultExitCode = -1;

        /// <summary>
        /// Waits for the <see cref="Process"/> to exit and then returns it's exit code.
        /// </summary>
        /// <returns><see cref="Process.ExitCode"/> or -1, if an error occured or the <see cref="Process"/> is <see langword="null"/>.</returns>
        public static async Task<int> WaitForExitCodeAsync(this Process? process)
        {
            if (process == null)
            {
                return DefaultExitCode;
            }

            int? exitCode = null;

            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => exitCode = (s as Process)?.ExitCode;
            await process.WaitForExitAsync();

            return exitCode ?? DefaultExitCode;
        }
    }
}
