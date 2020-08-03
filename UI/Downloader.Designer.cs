namespace RemoveSpotifyAds.UI
{
    partial class Downloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CancelDownloadButton = new System.Windows.Forms.Button();
            this.PercentageProgressLabel = new System.Windows.Forms.Label();
            this.DownloadSpeedLabel = new System.Windows.Forms.Label();
            this.DownloadProgressLabel = new System.Windows.Forms.Label();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TimeRemainingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelDownloadButton
            // 
            this.CancelDownloadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelDownloadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDownloadButton.Location = new System.Drawing.Point(378, 71);
            this.CancelDownloadButton.Name = "CancelDownloadButton";
            this.CancelDownloadButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDownloadButton.TabIndex = 0;
            this.CancelDownloadButton.Text = "Cancel";
            this.CancelDownloadButton.UseVisualStyleBackColor = true;
            this.CancelDownloadButton.Click += new System.EventHandler(this.CancelDownloadButton_Click);
            // 
            // PercentageProgressLabel
            // 
            this.PercentageProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PercentageProgressLabel.BackColor = System.Drawing.Color.Transparent;
            this.PercentageProgressLabel.Location = new System.Drawing.Point(207, 39);
            this.PercentageProgressLabel.Name = "PercentageProgressLabel";
            this.PercentageProgressLabel.Size = new System.Drawing.Size(50, 13);
            this.PercentageProgressLabel.TabIndex = 2;
            this.PercentageProgressLabel.Text = "0 %";
            this.PercentageProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DownloadSpeedLabel
            // 
            this.DownloadSpeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DownloadSpeedLabel.AutoSize = true;
            this.DownloadSpeedLabel.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.DownloadSpeedLabel.Location = new System.Drawing.Point(12, 13);
            this.DownloadSpeedLabel.Name = "DownloadSpeedLabel";
            this.DownloadSpeedLabel.Size = new System.Drawing.Size(57, 13);
            this.DownloadSpeedLabel.TabIndex = 3;
            this.DownloadSpeedLabel.Text = "0.00 MB/s";
            this.DownloadSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadToolTip.SetToolTip(this.DownloadSpeedLabel, "Change to MBit/s (MegaBits per second)");
            this.DownloadSpeedLabel.Click += new System.EventHandler(this.DownloadSpeedLabel_Click);
            // 
            // DownloadProgressLabel
            // 
            this.DownloadProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DownloadProgressLabel.Location = new System.Drawing.Point(228, 8);
            this.DownloadProgressLabel.Name = "DownloadProgressLabel";
            this.DownloadProgressLabel.Size = new System.Drawing.Size(225, 23);
            this.DownloadProgressLabel.TabIndex = 4;
            this.DownloadProgressLabel.Text = "0.00 MB / 0.00 MB";
            this.DownloadProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadProgressBar.Location = new System.Drawing.Point(12, 34);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(441, 23);
            this.DownloadProgressBar.TabIndex = 1;
            // 
            // TimeRemainingLabel
            // 
            this.TimeRemainingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TimeRemainingLabel.AutoSize = true;
            this.TimeRemainingLabel.Location = new System.Drawing.Point(12, 65);
            this.TimeRemainingLabel.Name = "TimeRemainingLabel";
            this.TimeRemainingLabel.Size = new System.Drawing.Size(35, 13);
            this.TimeRemainingLabel.TabIndex = 5;
            this.TimeRemainingLabel.Text = "0s left";
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDownloadButton;
            this.ClientSize = new System.Drawing.Size(465, 106);
            this.Controls.Add(this.TimeRemainingLabel);
            this.Controls.Add(this.DownloadProgressLabel);
            this.Controls.Add(this.DownloadSpeedLabel);
            this.Controls.Add(this.PercentageProgressLabel);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.CancelDownloadButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Downloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Downloader_FormClosing);
            this.Load += new System.EventHandler(this.Downloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelDownloadButton;
        private System.Windows.Forms.Label PercentageProgressLabel;
        private System.Windows.Forms.Label DownloadSpeedLabel;
        private System.Windows.Forms.Label DownloadProgressLabel;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.ToolTip DownloadToolTip;
        private System.Windows.Forms.Label TimeRemainingLabel;
    }
}