namespace SpARe.UI
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            tableLayoutPanel = new TableLayoutPanel();
            ProductNameLabel = new Label();
            VersionLabel = new Label();
            CopyrightLabel = new Label();
            UpdateCheckButton = new Button();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(ProductNameLabel, 0, 0);
            tableLayoutPanel.Controls.Add(VersionLabel, 0, 1);
            tableLayoutPanel.Controls.Add(CopyrightLabel, 0, 2);
            tableLayoutPanel.Controls.Add(UpdateCheckButton, 1, 3);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(10, 10);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Size = new Size(343, 151);
            tableLayoutPanel.TabIndex = 0;
            // 
            // ProductNameLabel
            // 
            ProductNameLabel.Anchor = AnchorStyles.None;
            ProductNameLabel.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(ProductNameLabel, 2);
            ProductNameLabel.Location = new Point(131, 11);
            ProductNameLabel.Margin = new Padding(7, 0, 4, 0);
            ProductNameLabel.MaximumSize = new Size(0, 20);
            ProductNameLabel.Name = "ProductNameLabel";
            ProductNameLabel.Size = new Size(84, 15);
            ProductNameLabel.TabIndex = 0;
            ProductNameLabel.Text = "Product Name";
            ProductNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = AnchorStyles.None;
            VersionLabel.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(VersionLabel, 2);
            VersionLabel.Location = new Point(150, 48);
            VersionLabel.Margin = new Padding(7, 0, 4, 0);
            VersionLabel.MaximumSize = new Size(0, 20);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(45, 15);
            VersionLabel.TabIndex = 1;
            VersionLabel.Text = "Version";
            VersionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CopyrightLabel
            // 
            CopyrightLabel.Anchor = AnchorStyles.None;
            CopyrightLabel.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(CopyrightLabel, 2);
            CopyrightLabel.Location = new Point(143, 85);
            CopyrightLabel.Margin = new Padding(7, 0, 4, 0);
            CopyrightLabel.MaximumSize = new Size(0, 20);
            CopyrightLabel.Name = "CopyrightLabel";
            CopyrightLabel.Size = new Size(60, 15);
            CopyrightLabel.TabIndex = 2;
            CopyrightLabel.Text = "Copyright";
            CopyrightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UpdateCheckButton
            // 
            UpdateCheckButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            UpdateCheckButton.Location = new Point(204, 125);
            UpdateCheckButton.Name = "UpdateCheckButton";
            UpdateCheckButton.Size = new Size(136, 23);
            UpdateCheckButton.TabIndex = 3;
            UpdateCheckButton.Text = "Check for updates";
            UpdateCheckButton.UseVisualStyleBackColor = true;
            UpdateCheckButton.Click += UpdateCheckButton_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 171);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = Properties.Resources.about;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            Load += AboutForm_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private Button UpdateCheckButton;
    }
}
