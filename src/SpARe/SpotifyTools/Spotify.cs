using Spare.Helpers;
using Spare.Root;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Spare.SpotifyTools
{
    public static class Spotify
    {
        private static readonly Version CorrectVersion = new(1, 0, 80, 474);
        private static readonly string RoamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");

        public static FileVersionInfo? GetInfo()
        {
            var path = Path.Combine(RoamingDirectory, "Spotify.exe");

            if (File.Exists(path))
            {
                return FileVersionInfo.GetVersionInfo(path);
            }

            return null;
        }

        public static void OutputInfo()
        {
            Output.Message("--- Info ---", HorizontalAlignment.Center);
            Output.NewLine();
            Output.Message($"Installed version");

            var version = GetInfo()?.ProductVersion;

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

            Output.Message("Ads removed");

            if (Settings.Instance.AdsRemoved)
            {
                Output.SuccessMessage("YES");
            }
            else
            {
                Output.FailedMessage("NO");
            }

            Output.EndOfBlock();
        }

        public static void Uninstall(bool cleanUp)
        {
            // TODO launch uninstaller exe first, see legacy project for implementation

            if (!cleanUp) return;

            foreach (var directory in Uninstaller.GetDirectories())
            {
                PathHelper.DeleteDirectory(directory);
            }

            Uninstaller.DeleteRegistryKeys();
        }
    }
}
