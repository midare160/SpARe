using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace RemoveSpotifyAds.UI
{
    public partial class Downloader : Form
    {
        #region Properties
        public string Address { get; set; }

        public string FileName { get; set; }

        public ICollection<(string name, string value)> Headers { get; set; }

        public ICredentials Credentials { get; set; } = CredentialCache.DefaultCredentials;

        public SecurityProtocolType SecurityProtocol { get; set; } = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        #endregion

        #region Static
        private const string _numberFormat = "0.00";
        #endregion

        #region Declarations
        private WebClient _webClient;
        private DateTime _startedAt;
        #endregion

        #region Constructors
        public Downloader()
        {
            InitializeComponent();

            /*PercentageProgressLabel.Parent = DownloadProgressBar;*/ // TODO transparent not working
        }
        #endregion

        #region Methods
        public void Start()
        {
            using (_webClient = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocol;

                _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                _webClient.Credentials = Credentials;
                _webClient.Headers.Clear();

                foreach (var (name, value) in Headers)
                {
                    _webClient.Headers.Add(name, value);
                }

                _webClient.DownloadFileAsync(new Uri(Address), FileName);
            }
        }
        #endregion

        #region Events
        private void Downloader_Load(object sender, EventArgs e)
        {
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            long bytesPerSecond = 0;

            if (_startedAt == default)
            {
                _startedAt = DateTime.Now;
            }
            else
            {
                var timeSpan = DateTime.Now - _startedAt;

                if (timeSpan.TotalSeconds > 0)
                {
                    /*bytesPerSecond = e.BytesReceived / (long)timeSpan.TotalSeconds;*/ // TODO devided by 0
                }
            }

            var megaBytesPerSecond = (bytesPerSecond / Math.Pow(10, 6)).ToString(_numberFormat);
            var megaBytesReceived = (e.BytesReceived / Math.Pow(10, 6)).ToString(_numberFormat);
            var totalMegaBytesToReceive = (e.TotalBytesToReceive / Math.Pow(10, 6)).ToString(_numberFormat);

            DownloadProgressBar.Value = e.ProgressPercentage;
            PercentageProgressLabel.Text = $"{e.ProgressPercentage} %";
            DownloadSpeedLabel.Text = $"{megaBytesPerSecond} MBit/s";
            DownloadProgressLabel.Text = $"{megaBytesReceived} MB / {totalMegaBytesToReceive} MB";

            TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100, this.Handle);
        }

        private void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelDownloadButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Downloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }

            var dialogResult = MessageBox.Show(
                "Do you really want to cancel the download?",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                _webClient.CancelAsync();
                _webClient.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
