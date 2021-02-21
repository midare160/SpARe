using Spare.Extensions;
using Spare.Helpers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spare.UI
{
    public partial class MainForm : Form
    {
        #region Testing - DELETE AFTER
        private async Task TestMethod()
        {
            StartButton.Enabled = false;

            Program.WriteToOutput("Installing Spotify...", true);

            var process = await ProcessHelper.StartAsNonAdmin(@"C:\Users\Michael Daubert\source\repos\Spare\src\Data\spotify_installer1.0.8.exe");
            var exitCode = await process.WaitForExitCodeAsync();

            Program.WriteToOutput(exitCode == 0 ? "OK" : "Failed");

            StartButton.Enabled = true;
        }
        #endregion

        #region Static
        private const string GreetingString = "-- Spotify Ad Remover | by midare160 --\n";
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
            await TestMethod();

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
