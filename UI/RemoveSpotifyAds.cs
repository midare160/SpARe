using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace RemoveSpotifyAds.UI
{
    public partial class RemoveSpotifyAdsForm : Form
    {
        #region Static
        private const string Mapping = "0.0.0.0";
        private const string FinishedKeyWord = " Finished.\r\n";
        #endregion

        #region Declarations
        private readonly string _roamingDirectory;
        private readonly string _localDirectory;
        private int _installExitCode;
        #endregion

        #region Constructor
        public RemoveSpotifyAdsForm()
        {
            InitializeComponent();

            _roamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");
            _localDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify");
        }
        #endregion

        #region Events
        private void RemoveSpotifyAds_Load(object sender, EventArgs e)
        {
            SetCheckboxState(File.Exists(Path.Combine(Application.StartupPath, @"Data\spotify_installer1.0.8.exe")));

            InstallCheckBox.Enabled = File.Exists(Path.Combine(_roamingDirectory, "Spotify.exe"));
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            PerformUITasks();

            if (InstallCheckBox.Checked && !InstallSpotify())
            {
                OutputTextBox.AppendText("\r\nNo changes have been made!");
                SystemSounds.Hand.Play();
                return;
            }

            DenyAccessToUpdateDirectory();
            WriteToHostFile();
            DeleteAdSpaFile();
            InstallCheckBox.Enabled = true;

            OutputTextBox.AppendText("\r\nAds removed successfully!");
            SystemSounds.Asterisk.Play();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            OutputTextBox.Clear();
            ClearButton.Enabled = false;
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e) 
            => this.Update();

        private void AboutGithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                AboutGithubLabel.LinkVisited = true;
                Process.Start("www.google.de"); //TODO Github repo link
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to open the link!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Thread.Sleep(new Random().Next(500, 3000)); // TODO remove

            MessageBox.Show(
                "No updates available!",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            //TODO check for updates
        }

        private void RemoveSpotifyAds_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion

        #region Private Procedures
        private void SetCheckboxState(bool visible)
        {
            InstallCheckBox.Checked = visible;
            InstallCheckBox.Visible = visible;
            WarningLabel.Visible = !visible;
        }

        /// <summary>
        /// Does some tasks before starting to remove the ads.
        /// </summary>
        private void PerformUITasks()
        {
            FormTabControl.SelectTab(OutputTabPage);
            ClearButton.Enabled = true;

            if (!string.IsNullOrEmpty(OutputTextBox.Text))
            {
                OutputTextBox.AppendText("\r\n- - - - - - - - - - - - - - - - - - - - - - - -\r\n\r\n");
            }

            this.Update();
        }

        /// <summary>
        /// Executes the Spotify installer and waits until it terminates
        /// </summary>
        private bool InstallSpotify()
        {
            OutputTextBox.AppendText("Installing Spotify...");

            // §HACK: Start the Spotify installer with non-admin rights, otherwise it won't execute
            Process.Start("explorer.exe", Path.Combine(Application.StartupPath, @"Data\spotify_installer1.0.8.exe")).WaitForExit();

            using (var installProcess = Process.GetProcessesByName("spotify_installer1.0.8")[0])
            {
                installProcess.EnableRaisingEvents = true;
                installProcess.Exited += InstallProcessExited;

                while (!installProcess.HasExited) ;
            }

            if (_installExitCode == 0)
            {
                OutputTextBox.AppendText(FinishedKeyWord);
                return true;
            }
            else
            {
                OutputTextBox.AppendText(" Aborted!\r\n");
                return false;
            }
        }

        private void InstallProcessExited(object sender, EventArgs e)
            => _installExitCode = (sender as Process).ExitCode;

        /// <summary>
        /// Denies access for all users to the "Update"-directory to prevent Spotify from updating itself
        /// </summary>
        private void DenyAccessToUpdateDirectory() //TODO check if access is already denied
        {
            OutputTextBox.AppendText("Denying access to \"Update\" directory...");

            var updatePath = Path.Combine(_localDirectory, "Update");
            Directory.CreateDirectory(updatePath);

            var allUsers = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var directoryInfo = new DirectoryInfo(updatePath);
            var fsar = new FileSystemAccessRule(allUsers, FileSystemRights.FullControl, AccessControlType.Deny);

            var directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(fsar);
            directoryInfo.SetAccessControl(directorySecurity);

            OutputTextBox.AppendText(FinishedKeyWord);
        }

        /// <summary>
        /// Contains all Spotify Ad-URLs 
        /// </summary>
        private List<string> UrlsToBlock()
            => new List<string>()
            {
                "adclick.g.doublecklick.net",
                "googleads.g.doubleclick.net",
                "googleadservices.com",
                "pubads.g.doubleclick.net",
                "securepubads.g.doubleclick.net",
                "pagead2.googlesyndication.com",
                "spclient.wg.spotify.com",
                "audio2.spotify.com"
            };

        /// <summary>
        /// Block all Spotify ad-servers through writing to the hosts-file
        /// </summary>
        private void WriteToHostFile()
        {
            OutputTextBox.AppendText("Editing hosts file...");

            var hostsPath = Path.Combine(Environment.SystemDirectory, @"drivers\etc\hosts");

            var filteredUrls = FilterBlockedUrlsIfHostsFileAlreadyContains(hostsPath);

            if (filteredUrls.Count == 0)
            {
                OutputTextBox.AppendText(" Already done!\r\n");
                return;
            }

            // Create backup of hosts file just in case
            File.Copy(hostsPath, $"{hostsPath}{DateTime.Now:yyMMdd}.backup", true);

            using (var sw = File.AppendText(hostsPath))
            {
                sw.WriteLine();
                sw.WriteLine("# Block Spotify ads");

                foreach (var url in filteredUrls)
                {
                    sw.WriteLine($"{Mapping} {url}");
                }
            }

            OutputTextBox.AppendText(FinishedKeyWord);
        }

        /// <summary>
        /// Removes the URLS that the hosts-file is already containing
        /// </summary>
        /// <param name="hostsPath">The path to the hosts-file</param>
        /// <returns>A <see cref="List{T}"/> that contains all URLs that are not already written to the hosts-file.
        /// The <see cref="List{T}"/> is empty if the hosts-file already contains all of them.</returns>
        private List<string> FilterBlockedUrlsIfHostsFileAlreadyContains(string hostsPath)
        {
            var fileContent = File.ReadAllText(hostsPath);
            var urls = UrlsToBlock();

            foreach (var a in urls.ToList().Where(u => fileContent.Contains(u)))
            {
                urls.Remove(a);
            }

            return urls;
        }

        /// <summary>
        /// Deletes the ad.spa file (could contain ad data)
        /// </summary>
        private void DeleteAdSpaFile()
        {
            OutputTextBox.AppendText("Deleting ad.spa...");

            var adspaPath = Path.Combine(_roamingDirectory, @"Apps\ad.spa");

            if (File.Exists(adspaPath))
            {
                File.Delete(adspaPath);
                OutputTextBox.AppendText(FinishedKeyWord);
            }
            else
            {
                OutputTextBox.AppendText(" Does not exist!\r\n");
            }
        }
        #endregion
    }
}
