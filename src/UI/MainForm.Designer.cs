
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
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.ActionsTabControl = new System.Windows.Forms.TabControl();
            this.StartTabPage = new System.Windows.Forms.TabPage();
            this.InfoButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.RevertTabPage = new System.Windows.Forms.TabPage();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ActionsTabControl.SuspendLayout();
            this.StartTabPage.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.Color.White;
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputTextBox.DetectUrls = false;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputTextBox.Location = new System.Drawing.Point(3, 19);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.OutputTextBox.Size = new System.Drawing.Size(298, 186);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.Text = "";
            this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // ActionsTabControl
            // 
            this.ActionsTabControl.Controls.Add(this.StartTabPage);
            this.ActionsTabControl.Controls.Add(this.RevertTabPage);
            this.ActionsTabControl.Location = new System.Drawing.Point(12, 12);
            this.ActionsTabControl.Name = "ActionsTabControl";
            this.ActionsTabControl.SelectedIndex = 0;
            this.ActionsTabControl.Size = new System.Drawing.Size(301, 177);
            this.ActionsTabControl.TabIndex = 2;
            // 
            // StartTabPage
            // 
            this.StartTabPage.Controls.Add(this.InfoButton);
            this.StartTabPage.Controls.Add(this.StartButton);
            this.StartTabPage.Location = new System.Drawing.Point(4, 24);
            this.StartTabPage.Name = "StartTabPage";
            this.StartTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StartTabPage.Size = new System.Drawing.Size(293, 149);
            this.StartTabPage.TabIndex = 0;
            this.StartTabPage.Text = "Start";
            this.StartTabPage.UseVisualStyleBackColor = true;
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(109, 85);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(75, 23);
            this.InfoButton.TabIndex = 1;
            this.InfoButton.Text = "&Info";
            this.InfoButton.UseVisualStyleBackColor = true;
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
            this.RevertTabPage.Location = new System.Drawing.Point(4, 24);
            this.RevertTabPage.Name = "RevertTabPage";
            this.RevertTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RevertTabPage.Size = new System.Drawing.Size(293, 149);
            this.RevertTabPage.TabIndex = 1;
            this.RevertTabPage.Text = "Revert";
            this.RevertTabPage.UseVisualStyleBackColor = true;
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.OutputTextBox);
            this.OutputGroupBox.Location = new System.Drawing.Point(12, 195);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(304, 208);
            this.OutputGroupBox.TabIndex = 3;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output";
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
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpARe";
            this.ActionsTabControl.ResumeLayout(false);
            this.StartTabPage.ResumeLayout(false);
            this.OutputGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl ActionsTabControl;
        private System.Windows.Forms.TabPage RevertTabPage;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TabPage StartTabPage;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button InfoButton;
        internal System.Windows.Forms.RichTextBox OutputTextBox;
    }
}

