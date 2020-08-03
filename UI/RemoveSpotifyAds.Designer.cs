namespace RemoveSpotifyAds.UI
{
    partial class RemoveSpotifyAdsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveSpotifyAdsForm));
            this.StartButton = new System.Windows.Forms.Button();
            this.FormTabControl = new System.Windows.Forms.TabControl();
            this.StartTabPage = new System.Windows.Forms.TabPage();
            this.InstallCheckBox = new System.Windows.Forms.CheckBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.OutputTabPage = new System.Windows.Forms.TabPage();
            this.OutputTextBox = new RemoveSpotifyAds.CustomControls.ReadOnlyRichTextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.HelpTabPage = new System.Windows.Forms.TabPage();
            this.CheckUpdatesButton = new System.Windows.Forms.Button();
            this.AboutGithubLabel = new System.Windows.Forms.LinkLabel();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.ControlToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FormTabControl.SuspendLayout();
            this.StartTabPage.SuspendLayout();
            this.OutputTabPage.SuspendLayout();
            this.HelpTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(125, 54);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "&Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FormTabControl
            // 
            this.FormTabControl.Controls.Add(this.StartTabPage);
            this.FormTabControl.Controls.Add(this.OutputTabPage);
            this.FormTabControl.Controls.Add(this.HelpTabPage);
            this.FormTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTabControl.Location = new System.Drawing.Point(0, 0);
            this.FormTabControl.Name = "FormTabControl";
            this.FormTabControl.SelectedIndex = 0;
            this.FormTabControl.Size = new System.Drawing.Size(332, 184);
            this.FormTabControl.TabIndex = 0;
            // 
            // StartTabPage
            // 
            this.StartTabPage.Controls.Add(this.InstallCheckBox);
            this.StartTabPage.Controls.Add(this.StartButton);
            this.StartTabPage.Controls.Add(this.WarningLabel);
            this.StartTabPage.Location = new System.Drawing.Point(4, 22);
            this.StartTabPage.Name = "StartTabPage";
            this.StartTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StartTabPage.Size = new System.Drawing.Size(324, 158);
            this.StartTabPage.TabIndex = 0;
            this.StartTabPage.Text = "Start";
            this.StartTabPage.UseVisualStyleBackColor = true;
            // 
            // InstallCheckBox
            // 
            this.InstallCheckBox.AutoSize = true;
            this.InstallCheckBox.Checked = true;
            this.InstallCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InstallCheckBox.Enabled = false;
            this.InstallCheckBox.Location = new System.Drawing.Point(68, 87);
            this.InstallCheckBox.Name = "InstallCheckBox";
            this.InstallCheckBox.Size = new System.Drawing.Size(189, 17);
            this.InstallCheckBox.TabIndex = 2;
            this.InstallCheckBox.Text = "(&Re)Install Spotify (Recommended)";
            this.ControlToolTip.SetToolTip(this.InstallCheckBox, "Installs Spotify (necessary), if its already installed it will override the previ" +
        "ous installation (recommended)");
            this.InstallCheckBox.UseVisualStyleBackColor = true;
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.ForeColor = System.Drawing.Color.Red;
            this.WarningLabel.Location = new System.Drawing.Point(75, 87);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(174, 13);
            this.WarningLabel.TabIndex = 0;
            this.WarningLabel.Text = "Spotify install-executable not found!";
            this.WarningLabel.Visible = false;
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
            this.OutputTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.OutputTextBox.DetectUrls = false;
            this.OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputTextBox.HideSelection = false;
            this.OutputTextBox.Location = new System.Drawing.Point(3, 3);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
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
            // HelpTabPage
            // 
            this.HelpTabPage.Controls.Add(this.CheckUpdatesButton);
            this.HelpTabPage.Controls.Add(this.AboutGithubLabel);
            this.HelpTabPage.Controls.Add(this.AboutLabel);
            this.HelpTabPage.Location = new System.Drawing.Point(4, 22);
            this.HelpTabPage.Name = "HelpTabPage";
            this.HelpTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HelpTabPage.Size = new System.Drawing.Size(324, 158);
            this.HelpTabPage.TabIndex = 2;
            this.HelpTabPage.Text = "Help";
            this.HelpTabPage.UseVisualStyleBackColor = true;
            // 
            // CheckUpdatesButton
            // 
            this.CheckUpdatesButton.Location = new System.Drawing.Point(204, 132);
            this.CheckUpdatesButton.Name = "CheckUpdatesButton";
            this.CheckUpdatesButton.Size = new System.Drawing.Size(117, 23);
            this.CheckUpdatesButton.TabIndex = 1;
            this.CheckUpdatesButton.Text = "&Check for updates";
            this.CheckUpdatesButton.UseVisualStyleBackColor = true;
            this.CheckUpdatesButton.Click += new System.EventHandler(this.CheckUpdatesButton_Click);
            // 
            // AboutGithubLabel
            // 
            this.AboutGithubLabel.AutoSize = true;
            this.AboutGithubLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.AboutGithubLabel.Location = new System.Drawing.Point(117, 84);
            this.AboutGithubLabel.Name = "AboutGithubLabel";
            this.AboutGithubLabel.Size = new System.Drawing.Size(91, 13);
            this.AboutGithubLabel.TabIndex = 0;
            this.AboutGithubLabel.TabStop = true;
            this.AboutGithubLabel.Text = "&Github Repository";
            this.AboutGithubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ControlToolTip.SetToolTip(this.AboutGithubLabel, "https://github.com/midare160/RemoveSpotifyAds");
            this.AboutGithubLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AboutGithubLabel_LinkClicked);
            this.AboutGithubLabel.Enter += new System.EventHandler(this.AboutGithubLabel_Enter);
            this.AboutGithubLabel.Leave += new System.EventHandler(this.AboutGithubLabel_Leave);
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(114, 61);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(97, 13);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = "©2020 MIDARE16";
            this.AboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlToolTip
            // 
            this.ControlToolTip.AutoPopDelay = 10000;
            this.ControlToolTip.InitialDelay = 500;
            this.ControlToolTip.ReshowDelay = 100;
            // 
            // RemoveSpotifyAdsForm
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
            this.Name = "RemoveSpotifyAdsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Spotify Ads";
            this.Load += new System.EventHandler(this.RemoveSpotifyAds_Load);
            this.FormTabControl.ResumeLayout(false);
            this.StartTabPage.ResumeLayout(false);
            this.StartTabPage.PerformLayout();
            this.OutputTabPage.ResumeLayout(false);
            this.HelpTabPage.ResumeLayout(false);
            this.HelpTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TabControl FormTabControl;
        private System.Windows.Forms.TabPage StartTabPage;
        private System.Windows.Forms.TabPage OutputTabPage;
        private CustomControls.ReadOnlyRichTextBox OutputTextBox;
        private System.Windows.Forms.TabPage HelpTabPage;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox InstallCheckBox;
        private System.Windows.Forms.ToolTip ControlToolTip;
        private System.Windows.Forms.LinkLabel AboutGithubLabel;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Button CheckUpdatesButton;
    }
}

