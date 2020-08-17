using Daubert.Extensions;
using Daubert.Tools.RegistryTools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using SpotifyAdRemover.FileAccess;

namespace SpotifyAdRemover.UI
{
    public partial class SpotifyAdRemoverForm : Form
    {
        #region Static Properties
        public const string AlreadyDoneString = " Already done!\r\n";
        public const string TaskFinishedString = "\r\n";
        #endregion

        #region Static Fields
        private const string AdsRemovedKey = "AdsRemoved";
        private const string NewVersionAvailableKey = "NewVersionAvailable";
        private const string ProductVersionKey = "ProductVersion";
        private const string Separator = "\r\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\r\n";
        #endregion

        #region Fields
        private readonly Updater _updater;
        private readonly RegistryReader _registryReader;
        private readonly RegistryWriter _registryWriter;
        private readonly HostsFileAccess _hostsFileAccess;
        private readonly SpotifyUpdateDirectoryAccess _spotifyUpdateDirectoryAccess;
        private readonly SpotifyAppDirectoryAccess _spotifyAppDirectoryAccess;
        private readonly SpotifyInstaller _spotifyInstaller;
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
        }
        #endregion

        #region Events
        #region Events-Form
        private void RemoveSpotifyAdsForm_Load(object sender, EventArgs e)
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
        #endregion

        #region Events-StartTabPage
        private void StartButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                FormTabControl.SelectTab(OutputTabPage);

                if (InstallCheckBox.Checked && !_spotifyInstaller.Install())
                {
                    OutputTextBox.AppendText("\r\nNo changes have been made!");
                    SystemSounds.Hand.Play();
                    return;
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
            try
            {
                this.UseWaitCursor = true;

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

                FormTabControl.SelectTab(OutputTabPage);

                _hostsFileAccess.RemoveUrls();
                _spotifyUpdateDirectoryAccess.Allow();

                SetUiAndRegistry(false);
                OutputTextBox.AppendColoredText("\r\nAll changes successfully reverted!", Color.Green);
                SystemSounds.Asterisk.Play();
            }
            finally
            {
                OutputTextBox.AppendText(Separator);
                this.UseWaitCursor = false;
            }
        }

        private void InstallCheckBox_SizeChanged(object sender, EventArgs e)
            => InstallCheckBox.Left = (this.ClientSize.Width - InstallCheckBox.Width) / 2;

        private void InstallCheckBox_Click(object sender, EventArgs e)
        {
            if (!InstallCheckBox.AutoCheck)
            {
                InstallCheckboxToolTip.Show(InstallCheckboxToolTip.GetToolTip(InstallCheckBox), InstallCheckBox, 10000);
            }
        }

        private void NewVersionAvailableLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            FormTabControl.SelectTab(AboutTabPage);
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
            ClearButton.Enabled = true;
            this.Update();
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

        private async void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            var updateAvailable = false;

            try
            {
                // Cant use Cursors.WaitCursor because 'await' would disable it
                this.UseWaitCursor = true;

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
                        return;
                    }

                    updateAvailable = false;

                    MessageBox.Show(
                        "Update successfully installed! Application will restart now.",
                        "Update installed!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Application.Restart();
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
                var dialogResult = MessageBox.Show(
                    "Couldn't connect:\r\n\r\n" + ex.Message,
                    "Connection error!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Retry)
                {
                    CheckUpdatesButton.PerformClick();
                }
            }
            finally
            {
                NewVersionAvailableLinkLabel.Visible = updateAvailable;
                _registryWriter.SetValue(NewVersionAvailableKey, Convert.ToInt32(updateAvailable));

                this.UseWaitCursor = false;
            }
        }
        #endregion
        #endregion

        #region Private Procedures
        private void SetUiAndRegistry(bool adsRemoved)
        {
            var installerAvailable = _spotifyInstaller.InstallerExists();
            var alreadyInstalled = _spotifyAppDirectoryAccess.AlreadyInstalled;

            InstallCheckBox.Visible = installerAvailable && !adsRemoved;
            InstallCheckBox.Checked = installerAvailable;
            InstallCheckBox.AutoCheck = alreadyInstalled;
            InstallCheckBox.Text = alreadyInstalled ? "&Downgrade Spotify (recommended)" : "&Install Spotify (required)";
            InstallCheckboxToolTip.Active = !alreadyInstalled;

            WarningLabel.Visible = !installerAvailable;

            RevertButton.Enabled = adsRemoved;
            StartButton.Enabled = !adsRemoved;

            _registryWriter.SetValue(AdsRemovedKey, Convert.ToInt32(adsRemoved));
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
    }
}
