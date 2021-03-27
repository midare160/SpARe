using System.Diagnostics;
using System.Threading.Tasks;

namespace Spare.Extensions
{
    public static class ProcessExtensions
    {
        private const int DefaultExitCode = -1;

        /// <summary>
        /// Waits for the <see cref="Process"/> to exit and then returns its <see cref="Process.ExitCode"/>.
        /// </summary>
        /// <returns><see cref="Process.ExitCode"/> or <see cref="DefaultExitCode"/> if an error occured.</returns>
        public static async Task<int> WaitForExitCodeAsync(this Process process)
        {
            process.ThrowIfNull(nameof(process));

            try
            {
                int? exitCode = null;

                process.EnableRaisingEvents = true;
                process.Exited += (s, e) => exitCode = (s as Process)?.ExitCode;
                await process.WaitForExitAsync();

                return exitCode ?? DefaultExitCode;
            }
            catch
            {
                return DefaultExitCode;
            }
        }
    }
}
