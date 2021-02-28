using Spare.Extensions;
using Spare.Root;
using Spare.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class MainForm : Form
    {
        #region Static
        private const string GreetingString = "-- Spotify Ad Remover | by midare160 --\n\n";
        #endregion

        #region Constructors
        public MainForm()
        {
            Settings.Instance.Upgrade();

            InitializeComponent();
        }
        #endregion

        #region Events Form
        private void MainForm_Load(object sender, EventArgs e)
        {
            OutputTextBox.Text = GreetingString;
            StartButton.Enabled = Spotify.GetInfo().FileVersion != null;
        }
        #endregion

        #region Events
        private async void StartButton_Click(object sender, EventArgs e)
        {
            // TODO begin removing ads here
        }

        private async void InfoButton_Click(object sender, EventArgs e)
            => await this.RunAsync(Spotify.OutputInfo, GetActionButtons());

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OutputTextBox.Text = GreetingString;
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e) =>
            ClearButton.Enabled = !string.Equals(OutputTextBox.Text, GreetingString);
        #endregion

        #region Private Procedures
        private List<Button> GetActionButtons()
        {
            var buttons = new List<Button>();

            foreach (TabPage tab in ActionsTabControl.TabPages)
            {
                buttons.AddRange(tab.Controls.OfType<Button>());
            }

            return buttons;
        }
        #endregion

        #region Overrides
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion
    }
}
