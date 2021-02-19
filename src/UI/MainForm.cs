using Spare.Helpers;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class MainForm : Form
    {
        #region Static
        private void TestMethod()
        {
            var processExitCode = ProcessHelper.WaitForExit("mstsc");
            Program.WriteToOutput("fucking");
        }
        #endregion

        #region Constructors
        public MainForm() => InitializeComponent();
        #endregion

        #region Events
        private async void StartButton_Click(object sender, EventArgs e) =>
            await TaskHelper.RunAsync(TestMethod, StartButton);

        private void OutputTextBox_TextChanged(object sender, EventArgs e) =>
            ClearButton.Enabled = !string.IsNullOrEmpty(OutputGroupBox.Text);

        private void ClearButton_Click(object sender, EventArgs e) =>
            OutputTextBox.Text = "";
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
