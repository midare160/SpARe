using Daubert.Extensions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SpotifyAdRemover.UI;

namespace SpotifyAdRemover.FileAccess
{
    public class SpotifyAppDirectoryAccess
    {
        #region Properties
        public bool AlreadyInstalled => File.Exists(Path.Combine(_roamingDirectory, "Spotify.exe"));
        public RichTextBox OutputTextBox { get; }
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

        #region Methods
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
                OutputTextBox.AppendText(SpotifyAdRemoverForm.TaskFinishedString);
            }
            else
            {
                OutputTextBox.AppendColoredText("Doesn't exist!\r\n", Color.Green);
            }
        }
        #endregion
    }
}
