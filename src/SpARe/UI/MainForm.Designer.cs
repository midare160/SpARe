
namespace Spare.UI
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.ActionsTabControl = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.InfoButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.RevertTabPage = new System.Windows.Forms.TabPage();
            this.CleanupCheckBox = new System.Windows.Forms.CheckBox();
            this.RevertButton = new System.Windows.Forms.Button();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ActionsTabControl.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.RevertTabPage.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputTextBox.CausesValidation = false;
            this.OutputTextBox.DetectUrls = false;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputTextBox.HideSelection = false;
            this.OutputTextBox.Location = new System.Drawing.Point(3, 19);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.OutputTextBox.Size = new System.Drawing.Size(298, 186);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.Text = "";
            this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // ActionsTabControl
            // 
            this.ActionsTabControl.Controls.Add(this.MainTabPage);
            this.ActionsTabControl.Controls.Add(this.RevertTabPage);
            this.ActionsTabControl.Location = new System.Drawing.Point(12, 12);
            this.ActionsTabControl.Name = "ActionsTabControl";
            this.ActionsTabControl.SelectedIndex = 0;
            this.ActionsTabControl.Size = new System.Drawing.Size(301, 177);
            this.ActionsTabControl.TabIndex = 2;
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.InfoButton);
            this.MainTabPage.Controls.Add(this.StartButton);
            this.MainTabPage.Location = new System.Drawing.Point(4, 24);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabPage.Size = new System.Drawing.Size(293, 149);
            this.MainTabPage.TabIndex = 0;
            this.MainTabPage.Text = "Main";
            this.MainTabPage.UseVisualStyleBackColor = true;
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(109, 85);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(75, 23);
            this.InfoButton.TabIndex = 1;
            this.InfoButton.Text = "&Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(109, 40);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "&Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RevertTabPage
            // 
            this.RevertTabPage.Controls.Add(this.CleanupCheckBox);
            this.RevertTabPage.Controls.Add(this.RevertButton);
            this.RevertTabPage.Location = new System.Drawing.Point(4, 24);
            this.RevertTabPage.Name = "RevertTabPage";
            this.RevertTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RevertTabPage.Size = new System.Drawing.Size(293, 149);
            this.RevertTabPage.TabIndex = 1;
            this.RevertTabPage.Text = "Revert";
            this.RevertTabPage.UseVisualStyleBackColor = true;
            // 
            // CleanupCheckBox
            // 
            this.CleanupCheckBox.AutoSize = true;
            this.CleanupCheckBox.Location = new System.Drawing.Point(88, 79);
            this.CleanupCheckBox.Name = "CleanupCheckBox";
            this.CleanupCheckBox.Size = new System.Drawing.Size(117, 19);
            this.CleanupCheckBox.TabIndex = 1;
            this.CleanupCheckBox.Text = "&Perform clean up";
            this.CleanupCheckBox.UseVisualStyleBackColor = true;
            // 
            // RevertButton
            // 
            this.RevertButton.Location = new System.Drawing.Point(109, 50);
            this.RevertButton.Name = "RevertButton";
            this.RevertButton.Size = new System.Drawing.Size(75, 23);
            this.RevertButton.TabIndex = 0;
            this.RevertButton.Text = "&Revert";
            this.RevertButton.UseVisualStyleBackColor = true;
            this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.OutputTextBox);
            this.OutputGroupBox.Location = new System.Drawing.Point(12, 195);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(304, 208);
            this.OutputGroupBox.TabIndex = 3;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "&Output";
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(241, 415);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 450);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.ActionsTabControl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpARe";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ActionsTabControl.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.RevertTabPage.ResumeLayout(false);
            this.RevertTabPage.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl ActionsTabControl;
        private System.Windows.Forms.TabPage RevertTabPage;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button InfoButton;
        internal System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.CheckBox CleanupCheckBox;
        private System.Windows.Forms.Button RevertButton;
    }
}

