using Daubert.Extensions;
using SpotifyAdRemover.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SpotifyAdRemover.FileAccess
{
    public class SpotifyAppDirectoryAccess
    {
        #region Static
        private const string TargetVersion = "1.0.80.474";
        #endregion

        #region Fields
        private readonly string _roamingDirectory;
        #endregion

        #region Constructors
        public SpotifyAppDirectoryAccess(RichTextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;
            _roamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");
        }
        #endregion

        #region Properties
        public RichTextBox OutputTextBox { get; }
        #endregion

        #region Methods
        public (bool alreadyInstalled, bool correctVersion) AlreadyInstalled()
        {
            var executablePath = Path.Combine(_roamingDirectory, "Spotify.exe");

            if (!File.Exists(executablePath))
            {
                return (false, false);
            }

            var executableVersion = new Version(
                FileVersionInfo
                    .GetVersionInfo(executablePath)
                    .FileVersion);

            return (true, executableVersion.CompareTo(new Version(TargetVersion)) == 0);
        }

        /// <summary>
        /// Deletes the ad.spa file (could contain ad data)
        /// </summary>
        public void DeleteAdSpaFile()
        {
            OutputTextBox.AppendText("Deleting ad data...");

            var adspaPath = Path.Combine(_roamingDirectory, "Apps", "ad.spa");

            if (File.Exists(adspaPath))
            {
                File.Delete(adspaPath);
            }

            OutputTextBox.AppendColoredText(SpotifyAdRemoverForm.TaskFinishedString, Color.Green);
        }
        #endregion
    }
}
