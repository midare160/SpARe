using Spare.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.SpotifyTools
{
    public static class Manager
    {
        private static readonly Version CorrectVersion = new(1, 0, 80, 474);

        public static FileVersionInfo? GetExeInfo()
        {
            var exe = Paths.SpotifyExe;

            return File.Exists(exe) ? FileVersionInfo.GetVersionInfo(exe) : null;
        }

        public static void OutputInfo()
        {
            Output.Message("--- Info ---", HorizontalAlignment.Center);
            Output.NewLine();
            Output.Message($"Installed version");

            var version = GetExeInfo()?.ProductVersion;

            switch (version)
            {
                case null:
                    Output.FailedMessage("NONE");
                    break;
                case var correctVersion when CorrectVersion == new Version(correctVersion):
                    Output.SuccessMessage(correctVersion);
                    break;
                default:
                    Output.Message(version, HorizontalAlignment.Right);
                    break;
            }

            var removed = Settings.Instance.AdsRemoved;

            Output.Message("Ads removed");
            Output.EndMessage(removed, removed ? "YES" : "NO");
            Output.EndOfBlock();
        }

        public static async Task CleanAsync()
        {
            Output.Message("Uninstalling Spotify...");
            Output.EndMessage(await Uninstaller.Uninstall());

            Output.Message("Deleting directories...");
            Output.EndMessage(Uninstaller.DeleteDirectories().All(a => a.IsSuccessful));

            Output.Message("Deleting registry keys...");
            Uninstaller.DeleteRegistryKeys();
            Output.SuccessMessage();

            Output.EndOfBlock();
        }
    }
}
