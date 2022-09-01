using System.Diagnostics;

namespace SpARe.Helpers
{
    public static class ProcessHelper
    {
        public static Process? StartWithShell(string fileName)
        {
            var startInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true
            };

            return Process.Start(startInfo);
        }
    }
}
