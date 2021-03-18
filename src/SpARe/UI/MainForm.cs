using Spare.Extensions;
using Spare.Helpers;
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
            => await this.RunAsync(Spotify.OutputInfo, GetTabPageButtons());

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OutputTextBox.Text = GreetingString;
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e) =>
            ClearButton.Enabled = !string.Equals(OutputTextBox.Text, GreetingString);
        #endregion

        #region Private Procedures
        private IEnumerable<Button> GetTabPageButtons()
        {
            return ActionsTabControl.TabPages
                .Cast<TabPage>()
                .SelectMany(t => t.Controls.OfType<Button>());
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

        private async void RevertButton_Click(object sender, EventArgs e)
        {
            // TODO launch uninstaller exe first, see legacy project for implementation

            foreach (var directory in Uninstaller.GetDirectories())
            {
                //PathHelper.DeleteDirectory(directory);
            }

            foreach (var key in Uninstaller.GetRegistryKeys())
            {
                // TODO delete key
            }
        }
    }
}
