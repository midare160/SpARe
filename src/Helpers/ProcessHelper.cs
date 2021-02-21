using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spare.Helpers
{
    public static class ProcessHelper
    {
        public static async Task<Process?> StartAsNonAdmin(string processName)
        {
            await Process.Start("explorer", processName).WaitForExitAsync();

            return Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)).FirstOrDefault();
        }
    }
}
