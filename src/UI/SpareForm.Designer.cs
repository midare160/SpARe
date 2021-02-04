using Spare.CustomControls;

namespace Spare.UI
{
    partial class SpareForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpareForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.RevertButton = new System.Windows.Forms.Button();
            this.InstallCheckBox = new System.Windows.Forms.CheckBox();
            this.CorrectVersionInstalledLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InstallCheckboxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.StartGroupbox = new System.Windows.Forms.GroupBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.OutputGroupbox = new System.Windows.Forms.GroupBox();
            this.OutputTextBox = new Spare.CustomControls.ReadOnlyRichTextBox();
            this.InstallerWatcher = new System.IO.FileSystemWatcher();
            this.CleanSpotifyButton = new System.Windows.Forms.Button();
            this.StartGroupbox.SuspendLayout();
            this.OutputGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstallerWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(117, 53);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "&Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RevertButton
            // 
            this.RevertButton.Location = new System.Drawing.Point(117, 53);
            this.RevertButton.Name = "RevertButton";
            this.RevertButton.Size = new System.Drawing.Size(75, 23);
            this.RevertButton.TabIndex = 1;
            this.RevertButton.Text = "&Revert";
            this.RevertButton.UseVisualStyleBackColor = true;
            this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // InstallCheckBox
            // 
            this.InstallCheckBox.AutoSize = true;
            this.InstallCheckBox.Checked = true;
            this.InstallCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InstallCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.InstallCheckBox.Location = new System.Drawing.Point(87, 86);
            this.InstallCheckBox.Name = "InstallCheckBox";
            this.InstallCheckBox.Size = new System.Drawing.Size(135, 17);
            this.InstallCheckBox.TabIndex = 1;
            this.InstallCheckBox.Text = "&Install Spotify (required)";
            this.InstallCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InstallCheckboxToolTip.SetToolTip(this.InstallCheckBox, "Spotify must be installed first before any ads can be removed!");
            this.InstallCheckBox.UseVisualStyleBackColor = true;
            this.InstallCheckBox.CheckedChanged += new System.EventHandler(this.InstallCheckBox_CheckedChanged);
            this.InstallCheckBox.SizeChanged += new System.EventHandler(this.InstallCheckBox_SizeChanged);
            // 
            // CorrectVersionInstalledLabel
            // 
            this.CorrectVersionInstalledLabel.AutoSize = true;
            this.CorrectVersionInstalledLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.CorrectVersionInstalledLabel.Location = new System.Drawing.Point(57, 86);
            this.CorrectVersionInstalledLabel.Name = "CorrectVersionInstalledLabel";
            this.CorrectVersionInstalledLabel.Size = new System.Drawing.Size(194, 13);
            this.CorrectVersionInstalledLabel.TabIndex = 2;
            this.CorrectVersionInstalledLabel.Text = "Correct Spotify version already installed!";
            this.CorrectVersionInstalledLabel.Visible = false;
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(227, 164);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // InstallCheckboxToolTip
            // 
            this.InstallCheckboxToolTip.AutoPopDelay = 10000;
            this.InstallCheckboxToolTip.InitialDelay = 500;
            this.InstallCheckboxToolTip.ReshowDelay = 100;
            this.InstallCheckboxToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.InstallCheckboxToolTip.ToolTipTitle = "Important";
            // 
            // StartGroupbox
            // 
            this.StartGroupbox.Controls.Add(this.CleanSpotifyButton);
            this.StartGroupbox.Controls.Add(this.StartButton);
            this.StartGroupbox.Controls.Add(this.RevertButton);
            this.StartGroupbox.Controls.Add(this.InstallCheckBox);
            this.StartGroupbox.Controls.Add(this.CorrectVersionInstalledLabel);
            this.StartGroupbox.Controls.Add(this.WarningLabel);
            this.StartGroupbox.Location = new System.Drawing.Point(12, 12);
            this.StartGroupbox.Name = "StartGroupbox";
            this.StartGroupbox.Size = new System.Drawing.Size(308, 125);
            this.StartGroupbox.TabIndex = 0;
            this.StartGroupbox.TabStop = false;
            this.StartGroupbox.Text = "Start";
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel.Location = new System.Drawing.Point(90, 86);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(128, 13);
            this.WarningLabel.TabIndex = 3;
            this.WarningLabel.Text = "Spotify installer not found!";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WarningLabel.Visible = false;
            // 
            // OutputGroupbox
            // 
            this.OutputGroupbox.Controls.Add(this.OutputTextBox);
            this.OutputGroupbox.Controls.Add(this.ClearButton);
            this.OutputGroupbox.Location = new System.Drawing.Point(12, 143);
            this.OutputGroupbox.Name = "OutputGroupbox";
            this.OutputGroupbox.Size = new System.Drawing.Size(308, 193);
            this.OutputGroupbox.TabIndex = 1;
            this.OutputGroupbox.TabStop = false;
            this.OutputGroupbox.Text = "Output";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.OutputTextBox.HideSelection = false;
            this.OutputTextBox.Location = new System.Drawing.Point(6, 19);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(296, 139);
            this.OutputTextBox.TabIndex = 0;
            this.OutputTextBox.TabStop = false;
            this.OutputTextBox.Text = "";
            this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // InstallerWatcher
            // 
            this.InstallerWatcher.EnableRaisingEvents = true;
            this.InstallerWatcher.Filter = "*.exe";
            this.InstallerWatcher.SynchronizingObject = this;
            this.InstallerWatcher.Changed += new System.IO.FileSystemEventHandler(this.InstallerWatcher_Modified);
            this.InstallerWatcher.Created += new System.IO.FileSystemEventHandler(this.InstallerWatcher_Modified);
            this.InstallerWatcher.Deleted += new System.IO.FileSystemEventHandler(this.InstallerWatcher_Modified);
            this.InstallerWatcher.Renamed += new System.IO.RenamedEventHandler(this.InstallerWatcher_Modified);
            // 
            // CleanSpotifyButton
            // 
            this.CleanSpotifyButton.Location = new System.Drawing.Point(104, 19);
            this.CleanSpotifyButton.Name = "CleanSpotifyButton";
            this.CleanSpotifyButton.Size = new System.Drawing.Size(101, 23);
            this.CleanSpotifyButton.TabIndex = 4;
            this.CleanSpotifyButton.Text = "Clean Spotify";
            this.CleanSpotifyButton.UseVisualStyleBackColor = true;
            this.CleanSpotifyButton.Click += new System.EventHandler(this.CleanSpotifyButton_Click);
            // 
            // SpareForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 348);
            this.Controls.Add(this.OutputGroupbox);
            this.Controls.Add(this.StartGroupbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpareForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpARre";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SpareForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.RemoveSpotifyAdsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpareForm_KeyDown);
            this.StartGroupbox.ResumeLayout(false);
            this.StartGroupbox.PerformLayout();
            this.OutputGroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InstallerWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox InstallCheckBox;
        private System.Windows.Forms.ToolTip InstallCheckboxToolTip;
        private System.Windows.Forms.Label CorrectVersionInstalledLabel;
        private System.Windows.Forms.Button RevertButton;
        private System.Windows.Forms.GroupBox StartGroupbox;
        private System.Windows.Forms.GroupBox OutputGroupbox;
        private ReadOnlyRichTextBox OutputTextBox;
        private System.Windows.Forms.Label WarningLabel;
        private System.IO.FileSystemWatcher InstallerWatcher;
        private System.Windows.Forms.Button CleanSpotifyButton;
    }
}

