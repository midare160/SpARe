using Spare.API;
using Spare.API.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spare.UI;

namespace Spare.Tools
{
    public class Updater
    {
        #region Fields
        private Repository _repository;
        #endregion

        #region Properties
        public string BakPath => $"{Path.GetFileNameWithoutExtension(Application.ExecutablePath)}.bak";
        #endregion

        #region Methods
        public async Task<bool> Check()
        {
            var client = new GithubClient(Application.ProductName);
            _repository = await client.GetRepositoryAsync("https://api.github.com/repositories/283887091/releases/latest");

            return new Version(_repository.TagName.Substring(1)) // Remove 'v' from version string
                .CompareTo(new Version(Application.ProductVersion)) > 0;
        }

        public bool Install(IWin32Window owner)
        {
            if (_repository == null)
            {
                throw new NullReferenceException($"{nameof(Check)} has to be called first before {nameof(Install)} can be called!");
            }

            var downloadUrl = _repository.Assets[0].BrowserDownloadUrl;
            var updatePath = Path.Combine(Application.StartupPath, "Update");
            var zipPath = Path.Combine(updatePath, Path.GetFileName(downloadUrl));

            try
            {
                Directory.CreateDirectory(updatePath);

                var downloader = new Downloader(downloadUrl, zipPath)
                {
                    Headers = new List<(string name, string value)> { ("user-agent", Application.ProductName) },
                    AbortMessage = ShowAbortMessageBox
                };
                downloader.Start();

                if (downloader.ShowDialog(owner) == DialogResult.Cancel)
                {
                    return false;
                }

                UnzipFiles(zipPath);

                return true;
            }
            finally
            {
                while (true)
                {
                    try
                    {
                        Directory.Delete(updatePath, true);
                        break;
                    }
                    catch (Exception ex) when (ex is ObjectDisposedException | ex is UnauthorizedAccessException)
                    {
                        // HACK: Try to delete the directory multiple times, because sometimes it throws these Exceptions and I dont know why
                    }
                }
            }
        }
        #endregion

        #region Private Procedures
        private void UnzipFiles(string zipPath)
        {
            if (File.Exists(BakPath))
            {
                File.Delete(BakPath);
            }

            // Executable cant be replaced at runtime, but renamed
            File.Move(Application.ExecutablePath, BakPath);
            Directory.Delete(Path.Combine(Application.StartupPath, "Data"), true);

            ZipFile.ExtractToDirectory(zipPath, Application.StartupPath);
        }

        private static DialogResult ShowAbortMessageBox()
        {
            return MessageBox.Show(
                "Do you really want to cancel the download?",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }
        #endregion
    }
}
