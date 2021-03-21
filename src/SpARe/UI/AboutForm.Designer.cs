
namespace Spare.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.CompanyNameLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ProductNameLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.VersionLabel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.CopyrightLabel, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.CompanyNameLabel, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.DescriptionLabel, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.CloseButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(487, 307);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(4, 3);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(152, 301);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductNameLabel.Location = new System.Drawing.Point(167, 0);
            this.ProductNameLabel.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.ProductNameLabel.MaximumSize = new System.Drawing.Size(0, 20);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(316, 20);
            this.ProductNameLabel.TabIndex = 19;
            this.ProductNameLabel.Text = "Product Name";
            this.ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionLabel
            // 
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionLabel.Location = new System.Drawing.Point(167, 30);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.VersionLabel.MaximumSize = new System.Drawing.Size(0, 20);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(316, 20);
            this.VersionLabel.TabIndex = 0;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CopyrightLabel.Location = new System.Drawing.Point(167, 60);
            this.CopyrightLabel.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.CopyrightLabel.MaximumSize = new System.Drawing.Size(0, 20);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(316, 20);
            this.CopyrightLabel.TabIndex = 21;
            this.CopyrightLabel.Text = "Copyright";
            this.CopyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompanyNameLabel
            // 
            this.CompanyNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyNameLabel.Location = new System.Drawing.Point(167, 90);
            this.CompanyNameLabel.Margin = new System.Windows.Forms.Padding(7, 0, 4, 0);
            this.CompanyNameLabel.MaximumSize = new System.Drawing.Size(0, 20);
            this.CompanyNameLabel.Name = "CompanyNameLabel";
            this.CompanyNameLabel.Size = new System.Drawing.Size(316, 20);
            this.CompanyNameLabel.TabIndex = 22;
            this.CompanyNameLabel.Text = "Company Name";
            this.CompanyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Location = new System.Drawing.Point(167, 123);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(7, 3, 4, 3);
            this.DescriptionLabel.Multiline = true;
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.ReadOnly = true;
            this.DescriptionLabel.Size = new System.Drawing.Size(316, 147);
            this.DescriptionLabel.TabIndex = 23;
            this.DescriptionLabel.TabStop = false;
            this.DescriptionLabel.Text = "Description";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseButton.Location = new System.Drawing.Point(409, 278);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 24;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(507, 327);
            this.Controls.Add(this.tableLayoutPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.Label CompanyNameLabel;
        private System.Windows.Forms.TextBox DescriptionLabel;
        private System.Windows.Forms.Button CloseButton;
    }
}
