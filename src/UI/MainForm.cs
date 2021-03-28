using NLog;
using Spare.Extensions;
using Spare.Properties;
using Spare.SpotifyTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class MainForm : Form
    {
        #region Static
        private const string GreetingString = "-- Spotify Ad Remover | by midare160 --\n\n";

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Declarations
        private AboutForm? _aboutForm;
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
            StartButton.Enabled = !string.IsNullOrEmpty(Manager.GetExeInfo()?.FileVersion);
        }

        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            e.Cancel = true;

            if (_aboutForm?.IsDisposed == false)
            {
                return;
            }

            _aboutForm = new AboutForm();
            _aboutForm.Show(this);
        }
        #endregion

        #region Events
        private async void StartButton_Click(object sender, EventArgs e)
        {
            // TODO remove ads here
            throw new NotImplementedException();
        }

        private async void InfoButton_Click(object sender, EventArgs e) =>
            await this.RunAsync(Manager.OutputInfo, nameof(Manager.OutputInfo), GetTabPageButtons());

        private async void RevertButton_Click(object sender, EventArgs e)
        {
            // TODO revert changes here
            throw new NotImplementedException();
        }

        private async void CleanButton_Click(object sender, EventArgs e) =>
            await this.RunAsync(Manager.CleanAsync(), nameof(Manager.CleanAsync), GetTabPageButtons());

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OutputTextBox.Text = GreetingString;
        }

        private void ActionsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AcceptButton = (sender as TabControl)?
                .SelectedTab
                .Controls
                .OfType<Button>()
                .Select(button => (button.TabIndex, button))
                .Min()
                .button;
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
    }
}
