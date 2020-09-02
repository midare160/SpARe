using SpotifyAdRemover.CustomControls;

namespace SpotifyAdRemover.UI
{
    partial class SpotifyAdRemoverForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
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
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotifyAdRemoverForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.FormTabControl = new System.Windows.Forms.TabControl();
            this.StartTabPage = new System.Windows.Forms.TabPage();
            this.RevertButton = new System.Windows.Forms.Button();
            this.InstallCheckBox = new System.Windows.Forms.CheckBox();
            this.CorrectVersionInstalledLabel = new System.Windows.Forms.Label();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.NewVersionAvailableLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OutputTabPage = new System.Windows.Forms.TabPage();
            this.OutputTextBox = new SpotifyAdRemover.CustomControls.ReadOnlyRichTextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AboutTabPage = new System.Windows.Forms.TabPage();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.CheckUpdatesButton = new System.Windows.Forms.Button();
            this.GithubLabel = new System.Windows.Forms.LinkLabel();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.InstallCheckboxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FormToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FormHelpProvider = new System.Windows.Forms.HelpProvider();
            this.FormTabControl.SuspendLayout();
            this.StartTabPage.SuspendLayout();
            this.OutputTabPage.SuspendLayout();
            this.AboutTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(125, 68);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "&Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FormTabControl
            // 
            this.FormTabControl.Controls.Add(this.StartTabPage);
            this.FormTabControl.Controls.Add(this.OutputTabPage);
            this.FormTabControl.Controls.Add(this.AboutTabPage);
            this.FormTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTabControl.Location = new System.Drawing.Point(0, 0);
            this.FormTabControl.Name = "FormTabControl";
            this.FormTabControl.SelectedIndex = 0;
            this.FormTabControl.Size = new System.Drawing.Size(332, 184);
            this.FormTabControl.TabIndex = 0;
            // 
            // StartTabPage
            // 
            this.StartTabPage.Controls.Add(this.StartButton);
            this.StartTabPage.Controls.Add(this.RevertButton);
            this.StartTabPage.Controls.Add(this.InstallCheckBox);
            this.StartTabPage.Controls.Add(this.CorrectVersionInstalledLabel);
            this.StartTabPage.Controls.Add(this.WarningLabel);
            this.StartTabPage.Controls.Add(this.NewVersionAvailableLinkLabel);
            this.StartTabPage.Location = new System.Drawing.Point(4, 22);
            this.StartTabPage.Name = "StartTabPage";
            this.StartTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StartTabPage.Size = new System.Drawing.Size(324, 158);
            this.StartTabPage.TabIndex = 0;
            this.StartTabPage.Text = "Start";
            this.StartTabPage.UseVisualStyleBackColor = true;
            // 
            // RevertButton
            // 
            this.RevertButton.Location = new System.Drawing.Point(125, 68);
            this.RevertButton.Name = "RevertButton";
            this.RevertButton.Size = new System.Drawing.Size(75, 23);
            this.RevertButton.TabIndex = 1;
            this.RevertButton.Text = "&Revert";
            this.RevertButton.UseVisualStyleBackColor = true;
            this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // InstallCheckBox
            // 
            this.InstallCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallCheckBox.AutoSize = true;
            this.InstallCheckBox.Checked = true;
            this.InstallCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InstallCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.InstallCheckBox.Location = new System.Drawing.Point(95, 101);
            this.InstallCheckBox.Name = "InstallCheckBox";
            this.InstallCheckBox.Size = new System.Drawing.Size(135, 17);
            this.InstallCheckBox.TabIndex = 2;
            this.InstallCheckBox.Text = "&Install Spotify (required)";
            this.InstallCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InstallCheckboxToolTip.SetToolTip(this.InstallCheckBox, "Spotify must be installed first before any ads can be removed!");
            this.InstallCheckBox.UseVisualStyleBackColor = true;
            this.InstallCheckBox.CheckedChanged += new System.EventHandler(this.InstallCheckBox_CheckedChanged);
            this.InstallCheckBox.SizeChanged += new System.EventHandler(this.InstallCheckBox_SizeChanged);
            this.InstallCheckBox.Click += new System.EventHandler(this.InstallCheckBox_Click);
            // 
            // CorrectVersionInstalledLabel
            // 
            this.CorrectVersionInstalledLabel.AutoSize = true;
            this.CorrectVersionInstalledLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.CorrectVersionInstalledLabel.Location = new System.Drawing.Point(65, 101);
            this.CorrectVersionInstalledLabel.Name = "CorrectVersionInstalledLabel";
            this.CorrectVersionInstalledLabel.Size = new System.Drawing.Size(194, 13);
            this.CorrectVersionInstalledLabel.TabIndex = 4;
            this.CorrectVersionInstalledLabel.Text = "Correct Spotify version already installed!";
            this.CorrectVersionInstalledLabel.Visible = false;
            // 
            // WarningLabel
            // 
            this.WarningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel.Location = new System.Drawing.Point(98, 101);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(128, 13);
            this.WarningLabel.TabIndex = 0;
            this.WarningLabel.Text = "Spotify installer not found!";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WarningLabel.Visible = false;
            this.WarningLabel.VisibleChanged += new System.EventHandler(this.WarningLabel_VisibleChanged);
            // 
            // NewVersionAvailableLinkLabel
            // 
            this.NewVersionAvailableLinkLabel.ActiveLinkColor = System.Drawing.Color.MediumSeaGreen;
            this.NewVersionAvailableLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewVersionAvailableLinkLabel.AutoSize = true;
            this.NewVersionAvailableLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewVersionAvailableLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.NewVersionAvailableLinkLabel.LinkColor = System.Drawing.Color.DarkGreen;
            this.NewVersionAvailableLinkLabel.Location = new System.Drawing.Point(202, 10);
            this.NewVersionAvailableLinkLabel.Name = "NewVersionAvailableLinkLabel";
            this.NewVersionAvailableLinkLabel.Size = new System.Drawing.Size(114, 13);
            this.NewVersionAvailableLinkLabel.TabIndex = 3;
            this.NewVersionAvailableLinkLabel.TabStop = true;
            this.NewVersionAvailableLinkLabel.Text = "New version available!";
            this.NewVersionAvailableLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FormToolTip.SetToolTip(this.NewVersionAvailableLinkLabel, "Click to install new version");
            this.NewVersionAvailableLinkLabel.Visible = false;
            this.NewVersionAvailableLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NewVersionAvailableLinkLabel_LinkClicked);
            this.NewVersionAvailableLinkLabel.Enter += new System.EventHandler(this.NewVersionAvailableLinkLabel_MouseEnter);
            this.NewVersionAvailableLinkLabel.MouseEnter += new System.EventHandler(this.NewVersionAvailableLinkLabel_MouseEnter);
            this.NewVersionAvailableLinkLabel.MouseLeave += new System.EventHandler(this.NewVersionAvailableLinkLabel_MouseLeave);
            // 
            // OutputTabPage
            // 
            this.OutputTabPage.Controls.Add(this.OutputTextBox);
            this.OutputTabPage.Controls.Add(this.ClearButton);
            this.OutputTabPage.Location = new System.Drawing.Point(4, 22);
            this.OutputTabPage.Name = "OutputTabPage";
            this.OutputTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.OutputTabPage.Size = new System.Drawing.Size(324, 158);
            this.OutputTabPage.TabIndex = 1;
            this.OutputTabPage.Text = "Output";
            this.OutputTabPage.UseVisualStyleBackColor = true;
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.CausesValidation = false;
            this.OutputTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.OutputTextBox.DetectUrls = false;
            this.OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.OutputTextBox.HideSelection = false;
            this.OutputTextBox.Location = new System.Drawing.Point(3, 3);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ShortcutsEnabled = false;
            this.OutputTextBox.Size = new System.Drawing.Size(318, 123);
            this.OutputTextBox.TabIndex = 0;
            this.OutputTextBox.TabStop = false;
            this.OutputTextBox.Text = "";
            this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(246, 132);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 0;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.Controls.Add(this.VersionLabel);
            this.AboutTabPage.Controls.Add(this.CheckUpdatesButton);
            this.AboutTabPage.Controls.Add(this.GithubLabel);
            this.AboutTabPage.Controls.Add(this.CopyrightLabel);
            this.AboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AboutTabPage.Size = new System.Drawing.Size(324, 158);
            this.AboutTabPage.TabIndex = 2;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(138, 49);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(49, 13);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v.1.0.0.0";
            // 
            // CheckUpdatesButton
            // 
            this.CheckUpdatesButton.Location = new System.Drawing.Point(204, 132);
            this.CheckUpdatesButton.Name = "CheckUpdatesButton";
            this.CheckUpdatesButton.Size = new System.Drawing.Size(117, 23);
            this.CheckUpdatesButton.TabIndex = 0;
            this.CheckUpdatesButton.Text = "&Check for updates";
            this.CheckUpdatesButton.UseVisualStyleBackColor = true;
            this.CheckUpdatesButton.Click += new System.EventHandler(this.CheckUpdatesButton_Click);
            // 
            // GithubLabel
            // 
            this.GithubLabel.AutoSize = true;
            this.GithubLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GithubLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.GithubLabel.Location = new System.Drawing.Point(117, 97);
            this.GithubLabel.Name = "GithubLabel";
            this.GithubLabel.Size = new System.Drawing.Size(91, 13);
            this.GithubLabel.TabIndex = 3;
            this.GithubLabel.TabStop = true;
            this.GithubLabel.Text = "Github Repository";
            this.GithubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FormToolTip.SetToolTip(this.GithubLabel, "https://github.com/midare160/SpotifyAdRemover");
            this.GithubLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutGithubLabel_LinkClicked);
            this.GithubLabel.Enter += new System.EventHandler(this.AboutGithubLabel_Enter);
            this.GithubLabel.Leave += new System.EventHandler(this.AboutGithubLabel_Leave);
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(114, 73);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(97, 13);
            this.CopyrightLabel.TabIndex = 2;
            this.CopyrightLabel.Text = "©2020 MIDARE16";
            this.CopyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstallCheckboxToolTip
            // 
            this.InstallCheckboxToolTip.AutoPopDelay = 10000;
            this.InstallCheckboxToolTip.InitialDelay = 500;
            this.InstallCheckboxToolTip.ReshowDelay = 100;
            this.InstallCheckboxToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.InstallCheckboxToolTip.ToolTipTitle = "Important";
            // 
            // FormHelpProvider
            // 
            this.FormHelpProvider.HelpNamespace = "https://github.com/midare160/SpotifyAdRemover/blob/master/README.md";
            // 
            // SpotifyAdRemoverForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 184);
            this.Controls.Add(this.FormTabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SpotifyAdRemoverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spotify Ad Remover";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RemoveSpotifyAdsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpotifyAdRemoverForm_KeyDown);
            this.FormTabControl.ResumeLayout(false);
            this.StartTabPage.ResumeLayout(false);
            this.StartTabPage.PerformLayout();
            this.OutputTabPage.ResumeLayout(false);
            this.AboutTabPage.ResumeLayout(false);
            this.AboutTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TabControl FormTabControl;
        private System.Windows.Forms.TabPage StartTabPage;
        private System.Windows.Forms.TabPage OutputTabPage;
        private System.Windows.Forms.TabPage AboutTabPage;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox InstallCheckBox;
        private System.Windows.Forms.LinkLabel GithubLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Button CheckUpdatesButton;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.LinkLabel NewVersionAvailableLinkLabel;
        internal CustomControls.ReadOnlyRichTextBox OutputTextBox;
        private System.Windows.Forms.ToolTip InstallCheckboxToolTip;
        private System.Windows.Forms.ToolTip FormToolTip;
        private System.Windows.Forms.HelpProvider FormHelpProvider;
        private System.Windows.Forms.Label CorrectVersionInstalledLabel;
        private System.Windows.Forms.Button RevertButton;
    }
}

