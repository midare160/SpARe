namespace SpARe
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AboutButton = new Button();
            StartButton = new Button();
            RevertButton = new Button();
            InstallButton = new Button();
            SuspendLayout();
            // 
            // AboutButton
            // 
            AboutButton.Location = new Point(147, 150);
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(108, 23);
            AboutButton.TabIndex = 0;
            AboutButton.Text = "About";
            AboutButton.UseVisualStyleBackColor = true;
            AboutButton.Click += AboutButton_Click;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(147, 92);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(108, 23);
            StartButton.TabIndex = 1;
            StartButton.Text = "Remove ads";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // RevertButton
            // 
            RevertButton.Location = new Point(147, 121);
            RevertButton.Name = "RevertButton";
            RevertButton.Size = new Size(108, 23);
            RevertButton.TabIndex = 2;
            RevertButton.Text = "Revert changes";
            RevertButton.UseVisualStyleBackColor = true;
            RevertButton.Click += RevertButton_Click;
            // 
            // InstallButton
            // 
            InstallButton.Location = new Point(147, 63);
            InstallButton.Name = "InstallButton";
            InstallButton.Size = new Size(108, 23);
            InstallButton.TabIndex = 3;
            InstallButton.Text = "Install Spotify";
            InstallButton.UseVisualStyleBackColor = true;
            InstallButton.Click += InstallButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 237);
            Controls.Add(InstallButton);
            Controls.Add(RevertButton);
            Controls.Add(StartButton);
            Controls.Add(AboutButton);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SpARe";
            ResumeLayout(false);
        }

        #endregion

        private Button AboutButton;
        private Button StartButton;
        private Button RevertButton;
        private Button InstallButton;
    }
}