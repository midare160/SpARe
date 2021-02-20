using Spare.Helpers;
using System;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class MainForm : Form
    {
        #region Static
        private const string GreetingString = "-- Spotify Ad Remover | by midare160 --\n";

        private void TestMethod()
        {
            _ = ProcessHelper.WaitForExit("mstsc");
            Program.WriteToOutput("Fucking your mother...", true);
            Program.WriteToOutput("OK");
        }
        #endregion

        #region Constructors
        public MainForm() => InitializeComponent();
        #endregion

        #region Events Form
        private void MainForm_Load(object sender, EventArgs e) =>
            OutputTextBox.Text = GreetingString;
        #endregion

        #region Events
        private async void StartButton_Click(object sender, EventArgs e) =>
            await TaskHelper.RunAsync(TestMethod, StartButton);

        private void OutputTextBox_TextChanged(object sender, EventArgs e) =>
            ClearButton.Enabled = !string.Equals(OutputTextBox.Text, GreetingString);

        private void ClearButton_Click(object sender, EventArgs e) =>
            OutputTextBox.Text = GreetingString;
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
