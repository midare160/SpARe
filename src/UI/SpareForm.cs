using Spare.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Spare.Extensions;
using Spare.FileAccess;
using Spare.Tools;

namespace Spare.UI
{
    public partial class SpareForm : Form
    {
        #region Static
        public const string TaskFinishedString = " OK\r\n";
        #endregion

        #region Fields
        private bool _alreadyInstalled;
        private readonly Updater _updater;
        private readonly HostsFileAccess _hostsFileAccess;
        private readonly UpdateDirectoryAccess _spotifyUpdateDirectoryAccess;
        private readonly AppDirectoryAccess _spotifyAppDirectoryAccess;
        private readonly Installer _spotifyInstaller;
        private readonly string _textBoxSeparator;
        #endregion

        #region Constructors
        public SpareForm()
        {
            InitializeComponent();

            _updater = new Updater();
            _hostsFileAccess = new HostsFileAccess(OutputTextBox);
            _spotifyUpdateDirectoryAccess = new UpdateDirectoryAccess(OutputTextBox);
            _spotifyAppDirectoryAccess = new AppDirectoryAccess(OutputTextBox);
            _spotifyInstaller = new Installer(OutputTextBox);
            _textBoxSeparator = "\r\n" + string.Concat(Enumerable.Repeat("- ", 46)) + "\r\n";
        }
        #endregion

        #region Events
        #region Events-Form
        private void RemoveSpotifyAdsForm_Load(object sender, EventArgs e)
            => InitForm();

        private void SpareForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenAboutForm();
            e.Cancel = true;
        }

        private void InstallerWatcher_Modified(object sender, EventArgs e)
            => SetUiAndRegistry(Settings.Default.AdsRemoved);

        private void SpareForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                Cursor.Current = Cursors.WaitCursor;
                OpenAboutForm();
            }
        }
        #endregion

        #region Events-StartGroupbox
        private void StartButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (InstallCheckBox.Checked)
                {
                    this.Visible = false;

                    if (!_spotifyInstaller.Install())
                    {
                        this.Visible = true;
                        OutputTextBox.AppendText("\r\nNo changes have been made!");
                        SystemSounds.Hand.Play();

                        return;
                    }
                }

                this.Visible = true;

                _spotifyUpdateDirectoryAccess.Deny();
                _hostsFileAccess.WriteUrls();
                _spotifyAppDirectoryAccess.DeleteAdSpaFile();

                SetUiAndRegistry(true);

                OutputTextBox.AppendText("\r\nAds successfully removed!", Color.Green);
                SystemSounds.Asterisk.Play();
            }
            finally
            {
                this.Visible = true;
                OutputTextBox.AppendText(_textBoxSeparator);
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

            if (dialogResult != DialogResult.Yes) return;

            Cursor.Current = Cursors.WaitCursor;

            _hostsFileAccess.RemoveUrls();
            _spotifyUpdateDirectoryAccess.Allow();

            SetUiAndRegistry(false);

            OutputTextBox.AppendText("\r\nAll changes successfully reverted!", Color.Green);
            OutputTextBox.AppendText(_textBoxSeparator);

            SystemSounds.Asterisk.Play();
        }

        private void InstallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_alreadyInstalled) return;

            StartButton.Enabled = InstallCheckBox.Checked;

            InstallCheckboxToolTip.Show(
                InstallCheckboxToolTip.GetToolTip(InstallCheckBox),
                InstallCheckBox,
                InstallCheckboxToolTip.AutoPopDelay);
        }

        private void InstallCheckBox_SizeChanged(object sender, EventArgs e)
            => InstallCheckBox.Left = (this.ClientSize.Width - InstallCheckBox.Width) / 2;
        #endregion

        #region Events-OutputGroupbox
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
        #endregion

        #region Private Procedures
        private void InitForm()
        {
            if (File.Exists(_updater.BakPath))
            {
                File.Delete(_updater.BakPath);
            }

            this.Text = Application.ProductName;
            InstallerWatcher.Path = Path.GetDirectoryName(_spotifyInstaller.InstallerPath);

            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save(true);
            }

            SetUiAndRegistry(Settings.Default.AdsRemoved);
        }

        private void OpenAboutForm()
            => new AboutForm(_updater).ShowDialog(this);

        private void SetUiAndRegistry(bool adsRemoved)
        {
            var (alreadyInstalled, correctVersionInstalled) = _spotifyAppDirectoryAccess.AlreadyInstalled();
            _alreadyInstalled = alreadyInstalled;
            var installerExists = _spotifyInstaller.Exists();

            InstallCheckBox.Visible = InstallCheckBox.Checked = installerExists && !correctVersionInstalled && !adsRemoved;
            InstallCheckBox.Text = alreadyInstalled ? "&Downgrade Spotify (recommended)" : "&Install Spotify (required)";
            InstallCheckboxToolTip.Active = !alreadyInstalled;

            CorrectVersionInstalledLabel.Visible = installerExists && !adsRemoved && correctVersionInstalled;
            WarningLabel.Visible = !installerExists && !adsRemoved;

            RevertButton.Visible = adsRemoved;
            StartButton.Visible = !adsRemoved;
            AcceptButton = adsRemoved ? RevertButton : StartButton;

            Settings.Default.AdsRemoved = adsRemoved;
            Settings.Default.Save(true);
        }
        #endregion

        private void CleanSpotifyButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // TODO check if alreadyv installed(=>Exception), add Checkbox to Revert instead of extra button
            var uninstaller = new Uninstaller();
            uninstaller.UninstallSpotify();
        }
    }
}
