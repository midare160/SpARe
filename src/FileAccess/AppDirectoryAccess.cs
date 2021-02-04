using Spare.Extensions;
using Spare.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Spare.FileAccess
{
    public class AppDirectoryAccess
    {
        #region Static
        public static readonly string RoamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");
        private const string TargetVersion = "1.0.80.474";
        #endregion

        #region Constructors
        public AppDirectoryAccess(RichTextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;
        }
        #endregion

        #region Properties
        public RichTextBox OutputTextBox { get; }
        #endregion

        #region Methods
        public (bool alreadyInstalled, bool correctVersion) AlreadyInstalled()
        {
            var executablePath = Path.Combine(RoamingDirectory, "Spotify.exe");

            if (!File.Exists(executablePath))
            {
                return (false, false);
            }

            var executableVersion = new Version(FileVersionInfo
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

            var adspaPath = Path.Combine(RoamingDirectory, "Apps", "ad.spa");

            if (File.Exists(adspaPath))
            {
                File.Delete(adspaPath);
            }

            OutputTextBox.AppendText(SpareForm.TaskFinishedString, Color.Green);
        }
        #endregion
    }
}
