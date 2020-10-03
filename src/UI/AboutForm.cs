using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Windows.Forms;
using Spare.FileAccess;

namespace Spare.UI
{
    public sealed partial class AboutForm : Form
    {
        // TODO add info icon
        #region Constructors
        public AboutForm(Updater updater)
        {
            InitializeComponent();
            Updater = updater;

            this.Text = $"About {AssemblyTitle}";
            this.ProductNameLabel.Text = AssemblyProduct;
            this.VersionLabel.Text = $"Version {AssemblyVersion}";
            this.CopyrightLabel.Text = AssemblyCopyright;
        }
        #endregion

        #region Properties
        public Updater Updater { get; }

        public string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") return titleAttribute.Title;
                }

                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyDescription
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0) return "";
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        #region Events
        private void GithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            GithubLabel.LinkVisited = true;
            Process.Start("https://github.com/midare160/SpotifyAdRemover");
        }

        private async void CheckUpdatesButton_Click(object sender, EventArgs e)
        {
            var dialogResult = DialogResult.None;

            try
            {
                this.UseWaitCursor = true;
                CheckUpdatesButton.Enabled = false;

                if (await Updater.Check())
                {
                    var diagResult = MessageBox.Show(
                        "New version available! Do you want to download it now?",
                        "Update available!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (diagResult != DialogResult.Yes || !Updater.Install(this))
                    {
                        return;
                    }

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
                dialogResult = MessageBox.Show(
                    "Couldn't connect:\r\n\r\n" + ex.Message,
                    "Connection error!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (dialogResult == DialogResult.Retry)
                {
                    CheckUpdatesButton.PerformClick();
                }
                else
                {
                    this.UseWaitCursor = false;
                    CheckUpdatesButton.Enabled = true;
                }
            }
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion
    }
}
