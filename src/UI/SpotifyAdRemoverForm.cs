using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daubert.Extensions;
using Daubert.Tools.RegistryTools;
using SpotifyAdRemover.FileAccess;

namespace SpotifyAdRemover.UI
{
    public partial class SpotifyAdRemoverForm : Form
    {
        #region Static
        public const string TaskFinishedString = " OK\r\n";
        private const string AdsRemovedKey = "AdsRemoved";
        private const string NewVersionAvailableKey = "NewVersionAvailable";
        private const string ProductVersionKey = "ProductVersion";
        private static string Separator;
        #endregion

        #region Fields
        private readonly Updater _updater;
        private readonly RegistryReader _registryReader;
        private readonly RegistryWriter _registryWriter;
        private readonly HostsFileAccess _hostsFileAccess;
        private readonly SpotifyUpdateDirectoryAccess _spotifyUpdateDirectoryAccess;
        private readonly SpotifyAppDirectoryAccess _spotifyAppDirectoryAccess;
        private readonly SpotifyInstaller _spotifyInstaller;
        private bool _alreadyInstalled;
        private FileStream _lockedFile;
        #endregion

        #region Constructors
        public SpotifyAdRemoverForm()
        {
            InitializeComponent();

            _updater = new Updater();
            _registryReader = new RegistryReader();
            _registryWriter = new RegistryWriter();
            _hostsFileAccess = new HostsFileAccess(OutputTextBox);
            _spotifyUpdateDirectoryAccess = new SpotifyUpdateDirectoryAccess(OutputTextBox);
            _spotifyAppDirectoryAccess = new SpotifyAppDirectoryAccess(OutputTextBox);
            _spotifyInstaller = new SpotifyInstaller(OutputTextBox);

            Separator = "\r\n";

            for (var i = 1; i < 50; i++)
            {
                Separator += "- ";
            }

            Separator += "\r\n";
        }
        #endregion

        #region Events
        #region Events-Form
        private void RemoveSpotifyAdsForm_Load(object sender, EventArgs e)
            => InitForm();

        private void SpotifyAdRemoverForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        #endregion

        #region Events-StartTabPage
        private void StartButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                FormTabControl.SelectTab(OutputTabPage);

                try
                {
                    if (InstallCheckBox.Checked)
                    {
                        WindowState = FormWindowState.Minimized;

                        if (!_spotifyInstaller.Install())
                        {
                            OutputTextBox.AppendText("\r\nNo changes have been made!");
                            SystemSounds.Hand.Play();

                            return;
                        }
                    }
                }
                finally
                {
                    WindowState = FormWindowState.Normal;
                }

                _spotifyUpdateDirectoryAccess.Deny();
                _hostsFileAccess.WriteUrls();
                _spotifyAppDirectoryAccess.DeleteAdSpaFile();

                SetUiAndRegistry(true);

                OutputTextBox.AppendColoredText("\r\nAds successfully removed!", Color.Green);
                SystemSounds.Asterisk.Play();
            }
            finally
            {
                OutputTextBox.AppendText(Separator);
            }
        }

        private void RevertButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var dialogResult = MessageBox.Show(
                    "Do you really want to revert all changes?",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            FormTabControl.SelectTab(OutputTabPage);

            _hostsFileAccess.RemoveUrls();
            _spotifyUpdateDirectoryAccess.Allow();

            SetUiAndRegistry(false);

            OutputTextBox.AppendColoredText("\r\nAll changes successfully reverted!", Color.Green);
            OutputTextBox.AppendText(Separator);
            SystemSounds.Asterisk.Play();
        }

        private void InstallCheckBox_Click(object sender, EventArgs e)
        {
            if (!_alreadyInstalled)
            {
                InstallCheckboxToolTip.Show(
                    InstallCheckboxToolTip.GetToolTip(InstallCheckBox),
                    InstallCheckBox,
                    InstallCheckboxToolTip.AutoPopDelay);
            }
        }

        private void InstallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_alreadyInstalled)
            {
                StartButton.Enabled = InstallCheckBox.Checked;
            }
        }

        private void InstallCheckBox_SizeChanged(object sender, EventArgs e)
            => InstallCheckBox.Left = (ClientSize.Width - InstallCheckBox.Width) / 2;

        private void NewVersionAvailableLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            FormTabControl.SelectTab(AboutTabPage);
            CheckUpdatesButton.PerformClick();
        }

        private void NewVersionAvailableLinkLabel_MouseEnter(object sender, EventArgs e)
            => NewVersionAvailableLinkLabel.LinkColor = Color.MediumSeaGreen;

        private void NewVersionAvailableLinkLabel_MouseLeave(object sender, EventArgs e)
            => NewVersionAvailableLinkLabel.LinkColor = Color.DarkGreen;

        private void WarningLabel_VisibleChanged(object sender, EventArgs e)
            => StartButton.Enabled = !WarningLabel.Visible;
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
            ClearButton.Enabled = true;
            Update();
        }
        #endregion

        #region Events-AboutTabPage
        private void AboutGithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            GithubLabel.LinkVisited = true;
            Process.Start("https://github.com/midare160/SpotifyAdRemover");
        }

        private void AboutGithubLabel_Enter(object sender, EventArgs e)
            => GithubLabel.LinkBehavior = LinkBehavior.AlwaysUnderline;

        private void AboutGithubLabel_Leave(object sender, EventArgs e)
            => GithubLabel.LinkBehavior = LinkBehavior.HoverUnderline;

        private void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var check = CheckForUpdates().Result; // TODO Task.Run cause it stops when synchronous

            try
            {
                this.UseWaitCursor = true;
                CheckUpdatesButton.Enabled = false;

                while (check.repeatCheck)
                {
                    check = CheckForUpdates().Result;
                }
            }
            finally
            {
                NewVersionAvailableLinkLabel.Visible = check.updateAvailable;
                _registryWriter.SetValue(NewVersionAvailableKey, Convert.ToInt32(check.updateAvailable));

                CheckUpdatesButton.Enabled = true;
                this.UseWaitCursor = false;
            }
        }
        #endregion
        #endregion

        #region Private Procedures
        private void InitForm()
        {
            FormHelpProvider.SetShowHelp(this, true);

            if (File.Exists(_updater.BakPath))
            {
                File.Delete(_updater.BakPath);
            }

            if (!string.Equals((string)_registryReader.GetValue(ProductVersionKey), Application.ProductVersion))
            {
                _registryWriter.DeleteValue(NewVersionAvailableKey);
                _registryWriter.SetValue(ProductVersionKey, Application.ProductVersion);
            }

            SetUiAndRegistry(Convert.ToBoolean(_registryReader.GetValue(AdsRemovedKey)));

            NewVersionAvailableLinkLabel.Visible = Convert.ToBoolean(_registryReader.GetValue(NewVersionAvailableKey));
            VersionLabel.Text = $"v.{Application.ProductVersion}";
        }

        private void SetUiAndRegistry(bool adsRemoved)
        {
            var installerExists = _spotifyInstaller.Exists();
            var (alreadyInstalled, correctVersionInstalled) = _spotifyAppDirectoryAccess.AlreadyInstalled();
            _alreadyInstalled = alreadyInstalled;

            InstallCheckBox.Visible = InstallCheckBox.Checked = installerExists && !correctVersionInstalled && !adsRemoved;
            InstallCheckBox.Text = alreadyInstalled ? "&Downgrade Spotify (recommended)" : "&Install Spotify (required)";
            InstallCheckboxToolTip.Active = !alreadyInstalled;

            CorrectVersionInstalledLabel.Visible = installerExists && !adsRemoved && correctVersionInstalled;
            WarningLabel.Visible = !installerExists && !adsRemoved;

            if (installerExists && _lockedFile == null)
            {
                // Lock installer directory
                _lockedFile = new FileStream(_spotifyInstaller.Path, FileMode.Open, System.IO.FileAccess.Read, FileShare.None);
            }

            RevertButton.Visible = adsRemoved;
            StartButton.Visible = !adsRemoved;
            AcceptButton = adsRemoved ? RevertButton : StartButton;

            _registryWriter.SetValue(AdsRemovedKey, Convert.ToInt32(adsRemoved));
        }
        #endregion

        private async Task<(bool repeatCheck, bool updateAvailable)> CheckForUpdates()
        {
            var updateAvailable = false;

            try
            {
                updateAvailable = await _updater.Check();

                if (updateAvailable)
                {
                    var dialogResult = MessageBox.Show(
                        "New version available! Do you want to download it now?",
                        "Update available!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult != DialogResult.Yes || !_updater.Install(this))
                    {
                        return (false, updateAvailable);
                    }

                    MessageBox.Show(
                        "Update successfully installed! Application will restart now.",
                        "Update installed!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Application.Restart();
                }

                MessageBox.Show(
                    "You already have the latest version!",
                    "Up to date!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is WebException | ex is HttpRequestException | ex is HttpListenerException)
            {
                var dialogResult = MessageBox.Show(
                    "Couldn't connect:\r\n\r\n" + ex.Message,
                    "Connection error!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Retry)
                {
                    return (true, updateAvailable);
                }
            }

            return (false, false);
        }
    }
}
