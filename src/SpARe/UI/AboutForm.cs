using Spare.Api;
using Spare.Api.Json;
using Spare.Extensions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class AboutForm : Form
    {
        #region Static
        private static readonly Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

        private static T? GetAttribute<T>() where T : Attribute =>
            ExecutingAssembly.GetCustomAttributes<T>().FirstOrDefault();
        #endregion

        #region Declarations
        private GithubClient? _client;
        #endregion

        #region Constructors
        public AboutForm()
        {
            InitializeComponent();

            this.Text = $"About {Application.ProductName}";
            this.ProductNameLabel.Text = Application.ProductName;
            this.VersionLabel.Text = $"v. {Application.ProductVersion}";
            this.CopyrightLabel.Text = AssemblyCopyright;

            AboutToolTip.SetToolTip(GithubLabel, RepositoryUrl);
        }
        #endregion

        #region Properties
        public static string? AssemblyCopyright => GetAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        public static string? RepositoryUrl => GetAttribute<AssemblyMetadataAttribute>()?.Value;
        #endregion

        #region Events
        private async void UpdateButton_Click(object sender, EventArgs e) =>
            await this.Run(CheckForUpdateAsync(), UpdateButton);

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Close();
        }

        private void GithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Button != MouseButtons.Left) return;

            GithubLabel.LinkVisited = true;
            OpenRepoWebsite();
        }
        #endregion

        #region Private Procedures
        private async Task CheckForUpdateAsync()
        {
            try
            {
                var result = await CompareVersionsAsync();

                var dialogResult = MessageBox.Show(
                    result ? "New version available! Do you want to download it now?" : "Already up to date!",
                    "Update",
                    result ? MessageBoxButtons.YesNo : MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (dialogResult != DialogResult.Yes) return;

                OpenRepoWebsite();
            }
            catch (HttpRequestException ex)
            {
                var dialogResult = MessageBox.Show(
                    ex.Message,
                    ex.StatusCode.ToString(),
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (dialogResult != DialogResult.Retry) return;

                await CheckForUpdateAsync();
            }
        }

        private async Task<bool> CompareVersionsAsync()
        {
            if (_client == null)
            {
                _client = new GithubClient(Application.ProductName);
            }

            var repository = await _client.GetRepositoryAsync("https://api.github.com/repositories/283887091/releases/latest");

            if (string.IsNullOrEmpty(repository?.TagName))
            {
                return false;
            }

            return new Version(Application.ProductVersion) < new Version(Regex.Replace(repository.TagName, @"[^\d\.]+", ""));
        }

        private void OpenRepoWebsite()
        {
            var info = new ProcessStartInfo
            {
                FileName = RepositoryUrl ?? throw new NullReferenceException($"{nameof(RepositoryUrl)} is not defined!"),
                UseShellExecute = true
            };

            Process.Start(info)?.Dispose();
        }
        #endregion
    }
}
