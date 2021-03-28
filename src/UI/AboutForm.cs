using Spare.Api;
using Spare.Extensions;
using Spare.Properties;
using Spare.SpotifyTools;
using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class AboutForm : Form
    {
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
            this.CopyrightLabel.Text = ProjectAssembly.Copyright;

            AboutToolTip.SetToolTip(GithubLabel, ProjectAssembly.RepositoryUrl);
        }
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
            Manager.OpenRepoWebsite();
        }
        #endregion

        #region Private Procedures
        private async Task CheckForUpdateAsync()
        {
            try
            {
                var result = await CheckIfRespositoryVersionNewerAsync();

                var dialogResult = MessageBox.Show(
                    result ? "New version available! Do you want to download it now?" : "Already up to date!",
                    "Update",
                    result ? MessageBoxButtons.YesNo : MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (dialogResult != DialogResult.Yes) return;

                Manager.OpenRepoWebsite("releases/latest");
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

        private async Task<bool> CheckIfRespositoryVersionNewerAsync()
        {
            _client ??= new GithubClient();

            var tagName = await _client.GetRepositoryTagNameAsync("https://api.github.com/repositories/283887091/releases/latest");

            if (string.IsNullOrEmpty(tagName))
            {
                throw new HttpRequestException("Tagname of repository could not be found!", null, HttpStatusCode.NotFound);
            }

            return new Version(Application.ProductVersion) < new Version(Regex.Replace(tagName, @"[^\d\.]+", ""));
        }
        #endregion
    }
}
