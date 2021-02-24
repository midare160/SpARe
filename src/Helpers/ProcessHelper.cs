using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spare.Helpers
{
    public static class ProcessHelper
    {
        public static async Task<Process?> StartAsStandardUserAsync(string processName)
        {
            using var process = Process.Start("explorer", processName);
            await process.WaitForExitAsync();

            return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)).LastOrDefault();
        }
    }
}
