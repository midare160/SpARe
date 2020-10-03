using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Spare.Tools;

namespace Spare.UI
{
    public partial class Downloader : Form
    {
        #region Properties
        public string Address { get; }
        public string FileName { get; }
        public Icon FormIcon { get; set; }
        public Func<DialogResult> AbortMessage { get; set; }
        public IEnumerable<(string name, string value)> Headers { get; set; }
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
        public Downloader(string address, string filename)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            InitializeComponent();

            ServicePointManager.SecurityProtocol = SecurityProtocol;
            WebRequest.DefaultWebProxy = Proxy;

            Address = address;
            FileName = filename;

            _startedAt = DateTime.Now;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts downloading the file.
        /// </summary>
        public void Start()
        {
            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            _webClient.Credentials = Credentials;
            _webClient.Headers.Clear();

            foreach (var (name, value) in Headers)
            {
                _webClient.Headers.Add(name, value);
            }

            _webClient.DownloadFileTaskAsync(new Uri(Address), FileName);
        }
        #endregion

        #region Events
        private void Downloader_Load(object sender, EventArgs e)
        {
            this.Text = $"Downloading \"{Path.GetFileName(FileName)}\"";

            // TODO add icon to images folder
            this.Icon = FormIcon ?? IconExtractor.Extract("imageres.dll", 175, true); // 175 = index of "Download"-icon in dll

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            const string numberFormat = "0.00";
            const double quotient = 1000000;

            var timeSpan = DateTime.Now - _startedAt;
            var bytesPerSecond = timeSpan.TotalSeconds > 0 ? e.BytesReceived / timeSpan.TotalSeconds : 0;

            var megaBytesPerSecond = (bytesPerSecond / quotient).ToString(numberFormat);
            var megaBitPerSecond = (bytesPerSecond / quotient * 8).ToString(numberFormat);
            var megaBytesReceived = (e.BytesReceived / quotient).ToString(numberFormat);
            var totalMegaBytesToReceive = (e.TotalBytesToReceive / quotient).ToString(numberFormat);
            var timeRemaining = TimeSpan.FromSeconds((e.TotalBytesToReceive - e.BytesReceived) / bytesPerSecond);

            var timeRemainingString = timeRemaining.Days > 0 ? $"{timeRemaining.Days}d, " : null;
            timeRemainingString += timeRemaining.Hours > 0 ? $"{timeRemaining.Hours}h, " : null;
            timeRemainingString += timeRemaining.Minutes > 0 ? $"{timeRemaining.Minutes}min, " : null;

            ProgressBar.Value = e.ProgressPercentage;
            DownloadPercentageLabel.Text = $"{e.ProgressPercentage} %";
            TimeRemainingLabel.Text = $"{timeRemainingString}{timeRemaining.Seconds}s left";
            ProgressLabel.Text = $"{megaBytesReceived} MB / {totalMegaBytesToReceive} MB";
            SpeedLabel.Text = _isMegaBit ? $"{megaBitPerSecond} MBit/s" : $"{megaBytesPerSecond} MB/s";

            TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100, this.Handle);
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            => this.DialogResult = DialogResult.OK;

        private void CancelDownloadButton_Click(object sender, EventArgs e)
            => this.DialogResult = DialogResult.Cancel;

        private void SpeedLabel_Click(object sender, EventArgs e)
            => _isMegaBit = !_isMegaBit;

        private void Downloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused, this.Handle);

            var dialogResult = AbortMessage();

            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }

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
