using Microsoft.WindowsAPICodePack.Taskbar;
using RemoveSpotifyAds.Tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace RemoveSpotifyAds.UI
{
    public partial class Downloader : Form
    {
        #region Properties
        public string Address { get; }

        public string FileName { get; }

        public ICollection<(string name, string value)> Headers { get; set; }

        public ICredentials Credentials { get; set; } = CredentialCache.DefaultCredentials;

        public IWebProxy Proxy { get; set; }

        public SecurityProtocolType SecurityProtocol { get; set; } = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        #endregion

        #region Declarations
        private WebClient _webClient;
        private readonly DateTime _startedAt;
        private bool _isMegaBit;
        #endregion

        #region Constructors
        public Downloader(string adress, string filename)
        {
            InitializeComponent();

            ServicePointManager.SecurityProtocol = SecurityProtocol;
            WebRequest.DefaultWebProxy = Proxy;

            Address = adress;
            FileName = filename;

            _startedAt = DateTime.Now;
        }
        #endregion

        #region Methods
        public void Start()
        {
            using (_webClient = new WebClient())
            {
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
            this.Icon = IconExtractor.Extract("imageres.dll", 175, true); // 175 = index of "Download"-icon in dll

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(this.Handle, new ThumbnailToolBarButton(IconExtractor.Extract("imageres.dll", 175, false), "abort")); // TODO add abort button
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            const string numberFormat = "0.00";
            const double quotient = 1000000;

            double bytesPerSecond = 0;
            var timeSpan = DateTime.Now - _startedAt;

            if (timeSpan.TotalSeconds > 0)
            {
                bytesPerSecond = e.BytesReceived / timeSpan.TotalSeconds;
            }

            var megaBytesPerSecond = (bytesPerSecond / quotient).ToString(numberFormat);
            var megaBitPerSecond = (bytesPerSecond / quotient * 8).ToString(numberFormat);
            var megaBytesReceived = (e.BytesReceived / quotient).ToString(numberFormat);
            var totalMegaBytesToReceive = (e.TotalBytesToReceive / quotient).ToString(numberFormat);
            var timeRemaining = TimeSpan.FromSeconds((e.TotalBytesToReceive - e.BytesReceived) / bytesPerSecond);

            var timeRemainingString = "";

            if (timeRemaining.Days > 0) timeRemainingString += $"{timeRemaining.Days}d, ";
            if (timeRemaining.Hours > 0) timeRemainingString += $"{timeRemaining.Hours}h, ";
            if (timeRemaining.Minutes > 0) timeRemainingString += $"{timeRemaining.Minutes}min, ";

            TimeRemainingLabel.Text = $"{timeRemainingString}{timeRemaining.Seconds}s left";
            ProgressLabel.Text = $"{megaBytesReceived} MB / {totalMegaBytesToReceive} MB";
            SpeedLabel.Text = _isMegaBit ? $"{megaBitPerSecond} MBit/s" : $"{megaBytesPerSecond} MB/s";
            ProgressBar.Value = e.ProgressPercentage;
            DownloadPercentageLabel.Text = $"{e.ProgressPercentage} %";

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

        private void SpeedLabel_Click(object sender, EventArgs e)
        {
            _isMegaBit = !_isMegaBit;
        }

        private void Downloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused, this.Handle);

            var dialogResult = MessageBox.Show(
                "Do you really want to cancel the download?",
                "Are you sure?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (this.DialogResult == DialogResult.OK) return;

            if (dialogResult == DialogResult.OK)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error, this.Handle);
                _webClient.CancelAsync();
                _webClient.Dispose();
            }
            else
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);
                e.Cancel = true;
            }
        }
        #endregion
    }
}
