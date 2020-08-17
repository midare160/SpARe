using Daubert.Extensions;
using Daubert.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SpotifyAdRemover.UI;

namespace SpotifyAdRemover.FileAccess
{
    public class HostsFileAccess
    {
        #region Properties
        public RichTextBox OutputTextBox { get; }
        #endregion

        #region Static
        private const string Header = "# Block Spotify ads";
        private const string Mapping = "0.0.0.0";
        #endregion

        #region Fields
        private readonly string _hostsPath;
        #endregion

        #region Constructors
        public HostsFileAccess(RichTextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;
            _hostsPath = Path.Combine(Environment.SystemDirectory, "drivers", "etc", "hosts");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Blocks all Spotify ad-servers through writing to the hosts-file
        /// </summary>
        public void WriteUrls()
        {
            OutputTextBox.AppendText("Blocking ad servers...");

            var filteredUrls = CheckIfHostsFileAlreadyContains();

            if (filteredUrls.Count == 0)
            {
                OutputTextBox.AppendColoredText(SpotifyAdRemoverForm.AlreadyDoneString, Color.Green);
                return;
            }

            // Create backup of hosts file just in case
            File.Copy(_hostsPath, $"{_hostsPath}{DateTime.Now:yyMMdd}.backup", true);

            using (var sw = File.AppendText(_hostsPath))
            {
                sw.WriteLine(Header);

                foreach (var url in filteredUrls)
                {
                    sw.WriteLine($"{Mapping} {url}");
                }
            }

            OutputTextBox.AppendText(SpotifyAdRemoverForm.TaskFinishedString);
        }

        public void RemoveUrls()
        {
            OutputTextBox.AppendText("Unblocking ad servers...");

            var newFile = File.ReadAllLines(_hostsPath)
                .Where(line => !AdServerUrls().Any(s => string.Equals(line, $"{Mapping} {s}", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            LanguageUtils.IgnoreErrors<ArgumentOutOfRangeException>(() => newFile.RemoveAt(newFile.IndexOf(Header)));

            File.WriteAllLines(_hostsPath, newFile);

            OutputTextBox.AppendText(SpotifyAdRemoverForm.TaskFinishedString);
        }
        #endregion

        #region Private Procedures
        /// <summary>
        /// Removes the URLs from the list that the hosts-file is already containing
        /// </summary>
        /// <returns>A <see cref="List{T}"/> that contains all URLs that are not already written to the hosts-file.
        /// The <see cref="List{T}"/> is empty if the hosts-file already contains all of them.</returns>
        private List<string> CheckIfHostsFileAlreadyContains()
        {
            var urls = AdServerUrls();

            foreach (var url in urls.ToList().Where(File.ReadAllText(_hostsPath).Contains))
            {
                urls.Remove(url);
            }

            return urls;
        }

        /// <summary>
        /// Contains all Spotify Ad-URLs 
        /// </summary>
        private static List<string> AdServerUrls()
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
