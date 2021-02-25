using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Spare
{
    public class Spotify
    {
        #region Static
        // TODO get version directly from installer file
        public const string InstallerVersion = "1.0.80.474";

        public static readonly string RoamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");

        public static FileVersionInfo GetInfo() =>
            FileVersionInfo.GetVersionInfo(Path.Combine(RoamingDirectory, "Spotify.exe"));

        public static void OutputInfo()
        {
            var version = GetInfo().ProductVersion;

            Output.Message("--- Info ---", HorizontalAlignment.Center);
            Output.NewLine();
            Output.Message($"Installed version");

            switch (version)
            {
                case null:
                    Output.FailedMessage("NONE");
                    break;
                case InstallerVersion:
                    Output.SuccessMessage(version);
                    break;
                default:
                    Output.Message(version, HorizontalAlignment.Right);
                    break;
            }

            Output.Message(string.Concat(Enumerable.Repeat('-', Output.Width)));
            Output.NewLine();
        }
        #endregion
    }
}
