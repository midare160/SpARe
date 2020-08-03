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
            /*PercentageProgressLabel.Parent = DownloadProgressBar;*/ // TODO transparent not working

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
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(this.Handle, new ThumbnailToolBarButton(IconExtractor.Extract("imageres.dll", 175, false), "abort")); // TODO add abort button

            this.Icon = IconExtractor.Extract("imageres.dll", 175, true); // 175 = index of "Download"-icon in dll
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            const string numberFormat = "0.00";
            const double basis = 10, exponent = 6;

            long bytesPerSecond = 0;
            var timeSpan = DateTime.Now - _startedAt;

            if ((long)timeSpan.TotalSeconds > 0)
            {
                bytesPerSecond = e.BytesReceived / (long)timeSpan.TotalSeconds;
            }

            var megaBytesPerSecond = (bytesPerSecond / Math.Pow(basis, exponent)).ToString(numberFormat);
            var megaBitsPerSecond = (bytesPerSecond / Math.Pow(basis, exponent) * 8).ToString(numberFormat);
            var megaBytesReceived = (e.BytesReceived / Math.Pow(basis, exponent)).ToString(numberFormat);
            var totalMegaBytesToReceive = (e.TotalBytesToReceive / Math.Pow(10, 6)).ToString(numberFormat);
            var timeRemaining = TimeSpan.FromSeconds((e.TotalBytesToReceive - e.BytesReceived) / bytesPerSecond);

            DownloadProgressBar.Value = e.ProgressPercentage;
            PercentageProgressLabel.Text = $"{e.ProgressPercentage} %";
            DownloadProgressLabel.Text = $"{megaBytesReceived} MB / {totalMegaBytesToReceive} MB";

            if (_isMegaBit)
            {
                DownloadSpeedLabel.Text = $"{megaBitsPerSecond} MBit/s";
                DownloadToolTip.SetToolTip(DownloadSpeedLabel, "Change to MB/s (MegaBytes per second)");
            }
            else
            {
                DownloadSpeedLabel.Text = $"{megaBytesPerSecond} MB/s";
                DownloadToolTip.SetToolTip(DownloadSpeedLabel, "Change to MBit/s (MegaBit per second)");
            }

            var timeRemainingString = "";

            if (timeRemaining.Days > 0) timeRemainingString += $"{timeRemaining.Days:0}d, ";
            if (timeRemaining.Hours > 0) timeRemainingString += $"{timeRemaining.Hours:0}h, ";
            if (timeRemaining.Minutes > 0) timeRemainingString += $"{timeRemaining.Minutes:0}min, ";

            TimeRemainingLabel.Text = $"{timeRemainingString}{timeRemaining.Seconds:0}s left";

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

        private void DownloadSpeedLabel_Click(object sender, EventArgs e)
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
                MessageBoxIcon.Question);

            if (this.DialogResult != DialogResult.OK)
            {
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
        }
        #endregion
    }
}
