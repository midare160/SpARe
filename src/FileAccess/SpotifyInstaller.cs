using Daubert.Extensions;
using SpotifyAdRemover.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SpotifyAdRemover.FileAccess
{
    public class SpotifyInstaller
    {
        #region Properties
        public RichTextBox OutputTextBox { get; }
        public string Path => System.IO.Path.Combine(Application.StartupPath, "Data", "spotify_installer1.0.8.exe");

        public bool Exists
        {
            get
            {
                if (!File.Exists(Path))
                {
                    return false;
                }

                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(Path))
                    {
                        return string.Equals(
                            BitConverter
                                .ToString(md5.ComputeHash(stream))
                                .Replace("-", null),
                            InstallerHash,
                            StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
        }
        #endregion

        #region Static
        private const string InstallerHash = "a0f36ca24bf9df230afe59b6e4dd4f53";
        #endregion

        #region Fields
        private int _installExitCode;
        #endregion

        #region Constructors
        public SpotifyInstaller(RichTextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;
        }
        #endregion

        #region Events
        private void InstallProcessExited(object sender, EventArgs e)
            => _installExitCode = ((Process)sender).ExitCode;
        #endregion

        #region Methods
        /// <summary>
        /// Executes the Spotify installer and waits until it terminates.
        /// </summary>
        public bool Install()
        {
            OutputTextBox.AppendText("Installing Spotify...");

            // HACK Start the Spotify installer with non-admin rights, otherwise it wouldnt execute
            Process.Start("explorer.exe", Path)?.WaitForExit();

            try
            {
                using (var installProcess = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Path)).First())
                {
                    installProcess.EnableRaisingEvents = true;
                    installProcess.Exited += InstallProcessExited;

                    // ReSharper disable once EmptyEmbeddedStatement
                    while (!installProcess.HasExited) ;
                }
            }
            catch (InvalidOperationException)
            {
                _installExitCode = -1;
            }

            if (_installExitCode == 0)
            {
                OutputTextBox.AppendColoredText(SpotifyAdRemoverForm.TaskFinishedString, Color.Green);
                return true;
            }

            OutputTextBox.AppendColoredText(" Aborted!\r\n", Color.Red);
            return false;
        }
        #endregion
    }
}
