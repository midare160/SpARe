using Spare.FileAccess;
using System.Diagnostics;
using System.IO;

namespace Spare.Tools
{
    public class Uninstaller
    {
        public void UninstallSpotify()
        {
            Process.Start(Path.Combine(AppDirectoryAccess.RoamingDirectory, "Spotify.exe"), "/uninstall /qn");
        }
    }
}
