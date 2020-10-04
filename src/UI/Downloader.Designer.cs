namespace Spare.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
            this.CancelDownloadButton = new System.Windows.Forms.Button();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.TimeRemainingLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadPercentageLabel = new System.Windows.Forms.Label();
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
            this.CancelDownloadButton.Text = "&Cancel";
            this.CancelDownloadButton.UseVisualStyleBackColor = true;
            this.CancelDownloadButton.Click += new System.EventHandler(this.CancelDownloadButton_Click);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.SpeedLabel.Location = new System.Drawing.Point(12, 13);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(57, 13);
            this.SpeedLabel.TabIndex = 1;
            this.SpeedLabel.Text = "0.00 MB/s";
            this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SpeedLabel.Click += new System.EventHandler(this.SpeedLabel_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ProgressLabel.Location = new System.Drawing.Point(246, 13);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(207, 13);
            this.ProgressLabel.TabIndex = 3;
            this.ProgressLabel.Text = "0.00 MB / 0.00 MB";
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.TimeRemainingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProgressBar.Location = new System.Drawing.Point(12, 34);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(441, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 4;
            // 
            // DownloadPercentageLabel
            // 
            this.DownloadPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadPercentageLabel.BackColor = System.Drawing.Color.Transparent;
            this.DownloadPercentageLabel.Location = new System.Drawing.Point(210, 13);
            this.DownloadPercentageLabel.Name = "DownloadPercentageLabel";
            this.DownloadPercentageLabel.Size = new System.Drawing.Size(45, 13);
            this.DownloadPercentageLabel.TabIndex = 2;
            this.DownloadPercentageLabel.Text = "0 %";
            this.DownloadPercentageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDownloadButton;
            this.ClientSize = new System.Drawing.Size(465, 106);
            this.Controls.Add(this.DownloadPercentageLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.TimeRemainingLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.CancelDownloadButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Downloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Downloader_FormClosing);
            this.Load += new System.EventHandler(this.Downloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelDownloadButton;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label TimeRemainingLabel;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label DownloadPercentageLabel;
    }
}