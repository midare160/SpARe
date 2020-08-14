using Daubert.Forms;
using Daubert.Tools;
using Daubert.Tools.RegistryTools;
using RemoveSpotifyAds.API;
using RemoveSpotifyAds.Registry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace RemoveSpotifyAds.UI
{
    public partial class RemoveSpotifyAdsForm : Form
    {
        #region Static Fields
        private const string HostsHeader = "# Block Spotify ads";
        private const string Mapping = "0.0.0.0";
        private const string TaskFinishedString = "\r\n";
        private const string OutputTextBoxSeparator = "\r\n- - - - - - - - - - - - - - - - - - - - - - - -\r\n\r\n";
        #endregion

        #region Fields
        private readonly string _roamingDirectory;
        private readonly string _localDirectory;
        private readonly string _hostsPath;
        private readonly string _bakPath;
        private int _installExitCode;

        private readonly RegistryReader _registryReader;
        private readonly RegistryWriter _registryWriter;
        #endregion

        #region Constructors
        public RemoveSpotifyAdsForm()
        {
            InitializeComponent();

            _roamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");
            _localDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify");
            _hostsPath = Path.Combine(Environment.SystemDirectory, "drivers", "etc", "hosts");
            _bakPath = $"{Path.GetFileNameWithoutExtension(Application.ExecutablePath)}.bak";

            _registryReader = new RegistryReader();
            _registryWriter = new RegistryWriter();
        }
        #endregion

        #region Events
        #region Events-Form
        private void RemoveSpotifyAdsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(_bakPath))
            {
                File.Delete(_bakPath);
            }

            if (!string.Equals((string)_registryReader.GetValue(RegistryKeys.ProductVersion), Application.ProductVersion))
            {
                _registryWriter.DeleteValue(RegistryKeys.NewVersionAvailable);
                _registryWriter.SetValue(RegistryKeys.ProductVersion, Application.ProductVersion);
            }

            SetUiAndRegistry(Convert.ToBoolean(_registryReader.GetValue(RegistryKeys.AdsRemoved)));

            NewVersionAvailableLinkLabel.Visible = Convert.ToBoolean(_registryReader.GetValue(RegistryKeys.NewVersionAvailable));
            VersionLabel.Text = $"v.{Application.ProductVersion}";
        }

        private void InstallProcessExited(object sender, EventArgs e)
            => _installExitCode = ((Process)sender).ExitCode;
        #endregion

        #region Events-StartTabPage
        private void StartButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            FormTabControl.SelectTab(OutputTabPage);

            if (!string.IsNullOrEmpty(OutputTextBox.Text))
            {
                OutputTextBox.AppendText(OutputTextBoxSeparator);
            }

            if (InstallCheckBox.Checked && !InstallSpotify())
            {
                OutputTextBox.AppendText("\r\nNo changes have been made!");
                SystemSounds.Hand.Play();
                return;
            }

            DenyAccessToUpdateDirectory();
            WriteToHostsFile();
            DeleteAdSpaFile();

            SetUiAndRegistry(true);
            OutputTextBox.AppendText("\r\nAds removed successfully!");
            SystemSounds.Asterisk.Play();
        }

        private void RevertButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            FormTabControl.SelectTab(OutputTabPage);

            if (!string.IsNullOrEmpty(OutputTextBox.Text))
            {
                OutputTextBox.AppendText(OutputTextBoxSeparator);
            }

            RemoveUrlsFromHostsFile();
            // TODO revert code here

            SetUiAndRegistry(false);
            OutputTextBox.AppendText("\r\nAll changes successfully reverted!");
            SystemSounds.Asterisk.Play();
        }

        private void InstallCheckBox_SizeChanged(object sender, EventArgs e)
            => InstallCheckBox.Left = (this.ClientSize.Width - InstallCheckBox.Width) / 2;

        private void InstallCheckBox_Click(object sender, EventArgs e)
        {
            if (!InstallCheckBox.AutoCheck)
            {
                MessageBox.Show(
                    "Spotify is not installed, therefore it must be installed first before any ads can be removed!",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void NewVersionAvailableLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormTabControl.SelectTab(HelpTabPage);
            CheckUpdatesButton.PerformClick();
        }
        #endregion

        #region Events-OutputTabPage
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            OutputTextBox.Clear();
            ClearButton.Enabled = false;
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Update();
            ClearButton.Enabled = true;
        }
        #endregion

        #region Events-AboutTabPage
        private void AboutGithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                GithubLabel.LinkVisited = true;
                Process.Start("https://github.com/midare160/RemoveSpotifyAds");
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

        private void AboutGithubLabel_Enter(object sender, EventArgs e)
            => GithubLabel.LinkBehavior = LinkBehavior.AlwaysUnderline;

        private void AboutGithubLabel_Leave(object sender, EventArgs e)
            => GithubLabel.LinkBehavior = LinkBehavior.HoverUnderline;

        private async void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            // Cant use Cursors.WaitCursor because the async method would disable it
            this.UseWaitCursor = true;

            try
            {
                var client = new GithubClient(Application.ProductName);
                var repository = await client.GetRepositoryAsync("https://api.github.com/repositories/283887091/releases/latest");

                var releaseVersion = new Version(repository.TagName.Substring(1));

                if (releaseVersion.CompareTo(new Version(Application.ProductVersion)) > 0) // TODO Change to bigger ('>')
                {
                    NewVersionAvailableLinkLabel.Visible = true;
                    _registryWriter.SetValue(RegistryKeys.NewVersionAvailable, 1);

                    var dialogResult = MessageBox.Show(
                        "New version available! Do you want to download it now?",
                        "Update available!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        InstallNewVersion(repository.Assets.First().BrowserDownloadUrl);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "You already have the latest version!",
                        "Up to date!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) when (ex is WebException | ex is HttpRequestException | ex is HttpListenerException)
            {
                MessageBox.Show(
                    "Couldn't connect to the servers:\r\n\r\n" + ex.Message,
                    "Connection error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }
        #endregion
        #endregion

        #region Private Procedures
        private void SetUiAndRegistry(bool adsRemoved)
        {
            var installerAvailable = File.Exists(Path.Combine(Application.StartupPath, "Data", "spotify_installer1.0.8.exe"));
            var alreadyInstalled = File.Exists(Path.Combine(_roamingDirectory, "Spotify.exe"));

            InstallCheckBox.Visible = installerAvailable && !adsRemoved;
            InstallCheckBox.Checked = installerAvailable;
            InstallCheckBox.AutoCheck = alreadyInstalled;
            InstallCheckBox.Text = alreadyInstalled ? "&Downgrade Spotify (recommended)" : "&Install Spotify (required)";

            WarningLabel.Visible = !installerAvailable;

            RevertButton.Enabled = adsRemoved;
            StartButton.Enabled = !adsRemoved;

            _registryWriter.SetValue(RegistryKeys.AdsRemoved, Convert.ToInt32(adsRemoved));
        }

        /// <summary>
        /// Executes the Spotify installer and waits until it terminates.
        /// </summary>
        private bool InstallSpotify()
        {
            OutputTextBox.AppendText("Installing Spotify...");

            // HACK Start the Spotify installer with non-admin rights, otherwise it wouldnt execute
            Process.Start("explorer.exe", Path.Combine(Application.StartupPath, "Data", "spotify_installer1.0.8.exe"))?.WaitForExit();

            try
            {
                using (var installProcess = Process.GetProcessesByName("spotify_installer1.0.8").First())
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
                OutputTextBox.AppendText(TaskFinishedString);
                return true;
            }

            OutputTextBox.AppendText(" Aborted!\r\n");
            return false;
        }

        /// <summary>
        /// Denies access for all users to the "Update"-directory to prevent Spotify from updating itself
        /// </summary>
        private void DenyAccessToUpdateDirectory()
        {
            OutputTextBox.AppendText("Denying access to \"Update\" directory...");

            var updatePath = Path.Combine(_localDirectory, "Update");
            var testPath = Path.Combine(updatePath, "Test");

            try
            {
                Directory.CreateDirectory(testPath);
            }
            catch (UnauthorizedAccessException)
            {
                OutputTextBox.AppendText(" Already done!\r\n");
                return;
            }

            Directory.Delete(testPath);

            var directoryInfo = new DirectoryInfo(updatePath);
            var directorySecurity = directoryInfo.GetAccessControl(AccessControlSections.All);
            var user = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var accessRule = new FileSystemAccessRule(user, FileSystemRights.FullControl, AccessControlType.Deny);

            directorySecurity.AddAccessRule(accessRule);
            directoryInfo.SetAccessControl(directorySecurity);

            OutputTextBox.AppendText(TaskFinishedString);
        }

        /// <summary>
        /// Block all Spotify ad-servers through writing to the hosts-file
        /// </summary>
        private void WriteToHostsFile()
        {
            OutputTextBox.AppendText("Editing hosts file...");

            var filteredUrls = CheckIfHostsFileAlreadyContains();

            if (filteredUrls.Count == 0)
            {
                OutputTextBox.AppendText(" Already done!\r\n");
                return;
            }

            // Create backup of hosts file just in case
            File.Copy(_hostsPath, $"{_hostsPath}{DateTime.Now:yyMMdd}.backup", true);

            using (var sw = File.AppendText(_hostsPath))
            {
                sw.WriteLine();
                sw.WriteLine(HostsHeader);

                foreach (var url in filteredUrls)
                {
                    sw.WriteLine($"{Mapping} {url}");
                }
            }

            OutputTextBox.AppendText(TaskFinishedString);
        }

        /// <summary>
        /// Removes the URLs from the list that the hosts-file is already containing
        /// </summary>
        /// <returns>A <see cref="List{T}"/> that contains all URLs that are not already written to the hosts-file.
        /// The <see cref="List{T}"/> is empty if the hosts-file already contains all of them.</returns>
        private List<string> CheckIfHostsFileAlreadyContains()
        {
            var urls = UrlsToBlock();

            foreach (var url in urls.ToList().Where(File.ReadAllText(_hostsPath).Contains))
            {
                urls.Remove(url);
            }

            return urls;
        }

        private void RemoveUrlsFromHostsFile()
        {
            OutputTextBox.AppendText("Removing URLs from hosts file...");

            var newFile = File.ReadAllLines(_hostsPath)
                .Where(line => !UrlsToBlock().Any(s => string.Equals(line, $"{Mapping} {s}", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            LanguageUtils.IgnoreErrors<ArgumentOutOfRangeException>(() => newFile.RemoveAt(newFile.IndexOf(HostsHeader)));

            File.WriteAllLines(_hostsPath, newFile);

            OutputTextBox.AppendText(TaskFinishedString);
        }

        /// <summary>
        /// Deletes the ad.spa file (could contain ad data)
        /// </summary>
        private void DeleteAdSpaFile()
        {
            OutputTextBox.AppendText("Deleting ad.spa...");

            var adspaPath = Path.Combine(_roamingDirectory, "Apps", "ad.spa");

            if (File.Exists(adspaPath))
            {
                File.Delete(adspaPath);
                OutputTextBox.AppendText(TaskFinishedString);
            }
            else
            {
                OutputTextBox.AppendText(" Does not exist!\r\n");
            }
        }

        private void InstallNewVersion(string url)
        {
            var updatePath = Path.Combine(Application.StartupPath, "Update");
            var zipPath = Path.Combine(updatePath, Path.GetFileName(url));

            Directory.CreateDirectory(updatePath);

            try
            {
                var downloader = new Downloader(url, zipPath)
                {
                    Headers = new List<(string name, string value)> { ("user-agent", Application.ProductName) },
                    AbortMessage = ShowAbortMessageBox
                };

                downloader.Start();
                if (downloader.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }

                if (File.Exists(_bakPath))
                {
                    File.Delete(_bakPath);
                }

                // Executable cant be replaced at runtime => rename it
                File.Move(Application.ExecutablePath, _bakPath);
                Directory.Delete(Path.Combine(Application.StartupPath, "Data"), true);

                ZipFile.ExtractToDirectory(zipPath, Application.StartupPath);

                _registryWriter.SetValue(RegistryKeys.NewVersionAvailable, 0);

                MessageBox.Show(
                    "Update successfully installed! The application will restart now.",
                    "Finished!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Restart();
            }
            finally
            {
                Directory.Delete(updatePath, true);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            // ReSharper disable once InvertIf
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region Static Procedures
        private static DialogResult ShowAbortMessageBox()
        {
            return MessageBox.Show(
                "Do you really want to cancel the download?",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }

        /// <summary>
        /// Contains all Spotify Ad-URLs 
        /// </summary>
        private static List<string> UrlsToBlock()
        {
            return new List<string>
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
        }
        #endregion
    }
}
