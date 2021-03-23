using Spare.Api;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

        #region Constructors
        public AboutForm()
        {
            InitializeComponent();

            this.Text = $"About {AssemblyTitle}";
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = $"v. {AssemblyVersion}";
            this.CopyrightLabel.Text = AssemblyCopyright;

            AboutToolTip.SetToolTip(GithubLabel, RepositoryUrl);
        }
        #endregion

        #region Properties
        public static string? AssemblyTitle
        {
            get
            {
                var attribute = GetAttribute<AssemblyTitleAttribute>()?.Title;

                if (string.IsNullOrEmpty(attribute))
                {
                    return Path.GetFileNameWithoutExtension(ExecutingAssembly.Location);
                }

                return attribute;
            }
        }

        public static string? AssemblyVersion => ExecutingAssembly.GetName().Version?.ToString(3);

        public static string? AssemblyProduct => GetAttribute<AssemblyProductAttribute>()?.Product;

        public static string? AssemblyCopyright => GetAttribute<AssemblyCopyrightAttribute>()?.Copyright;

        public static string? RepositoryUrl => GetAttribute<AssemblyMetadataAttribute>()?.Value;
        #endregion

        #region Events
        private void OkButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Close();
        }

        private void GithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Button != MouseButtons.Left) return;

            GithubLabel.LinkVisited = true;

            var info = new ProcessStartInfo
            {
                FileName = RepositoryUrl ?? throw new NullReferenceException($"{nameof(RepositoryUrl)} is not defined!"),
                UseShellExecute = true
            };

            Process.Start(info)?.Dispose();
        }
        #endregion

        #region Private Procedures
        public async Task<bool> CheckForLaterVersion()
        {
            var client = new GithubClient(Application.ProductName);
            var repository = await client.GetRepositoryAsync("https://api.github.com/repositories/283887091/releases/latest");

            // TODO resolve possible null reference, eventually replace Properties with "Application.*"

            return new Version(repository.TagName?[1..]) // Remove 'v' from version string
                .CompareTo(new Version(Application.ProductVersion)) > 0;
        }
        #endregion
    }
}
