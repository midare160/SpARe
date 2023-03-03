using Flurl;
using Microsoft.Extensions.Options;
using SpARe.Extensions;
using SpARe.Helpers;
using SpARe.Options;
using SpARe.Services.Http;
using System.Reflection;

namespace SpARe.UI;

public partial class AboutForm : Form
{
    private readonly GitHubOptions _gitHubOptions;
    private readonly IGitHubClient _gitHubClient;

    public AboutForm(IOptions<GitHubOptions> gitHubOptions, IGitHubClient gitHubClient)
    {
        _gitHubOptions = gitHubOptions.Value;
        _gitHubClient = gitHubClient;

        InitializeComponent();
    }

    private void AboutForm_Load(object sender, EventArgs e)
    {
        using var _ = this.StartWaitCursor();

        var assembly = typeof(IAssemblyMarker).Assembly;

        Text = $"About {Application.ProductName}";
        ProductNameLabel.Text = $"{Application.ProductName} ({assembly.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration})";
        CopyrightLabel.Text = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
        VersionLabel.Text = $"v. {Application.ProductVersion}";
    }

    private async void UpdateCheckButton_Click(object sender, EventArgs e)
    {
        using var _ = this.StartWaitCursor();

        var repository = await _gitHubClient.GetRepositoryAsync();
        var versionString = repository.TagName[1..];

        var newestVersion = Version.Parse(versionString);
        var currentVersion = Version.Parse(Application.ProductVersion);

        if (newestVersion <= currentVersion)
        {
            MessageBoxHelper.Info("Latest version already installed.");
            return;
        }

        var dialogResult = MessageBoxHelper.Question(
            $"Newer version {versionString} available! Do you want to visit the download page now?",
            "Update available");

        if (dialogResult == DialogResult.Yes)
        {
            using var __ = ProcessHelper.StartWithShell(Url.Combine(_gitHubOptions.RepositoryUrl, "releases/latest"));
        }
    }
}
