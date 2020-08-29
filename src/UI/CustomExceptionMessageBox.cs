using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Windows;

namespace SpotifyAdRemover.UI
{
    public class CustomExceptionMessageBox
    {
        #region Static
        private static TaskDialog _taskDialog;
        private static Exception _exception;

        public static TaskDialogResult Show(Exception exception)
        {
            _exception = exception;

            _taskDialog = new TaskDialog
            {
                InstructionText = "Critical error occured!",
                Text = exception.Message,
                Icon = TaskDialogStandardIcon.Error,
                Cancelable = true,
                DetailsExpandedText = exception.ToString(),
                StartupLocation = TaskDialogStartupLocation.CenterScreen
            };

            var commandLinkSend = new TaskDialogCommandLink("buttonSendFeedback", "Report", "Create an issue on Github (Stacktrace will be copied to clipboard).");
            commandLinkSend.Click += CommandLinkSend_Click;

            var commandLinkIgnore = new TaskDialogCommandLink("buttonIgnore", "Ignore", "Proceed and ignore this error.");
            commandLinkIgnore.Click += CommandLinkIgnore_Click;

            _taskDialog.Controls.Add(commandLinkSend);
            _taskDialog.Controls.Add(commandLinkIgnore);

            return _taskDialog.Show();
        }

        private static void CommandLinkSend_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_exception.ToString());
            Process.Start("https://github.com/midare160/SpotifyAdRemover/issues/new");

            _taskDialog.Close();
        }

        private static void CommandLinkIgnore_Click(object sender, EventArgs e)
            => _taskDialog.Close();
        #endregion
    }
}
