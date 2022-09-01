using System.Diagnostics;

namespace SpARe.UI.Utility
{
    public static class ExceptionDialog
    {
        public static TaskDialogButton? Show(Exception exception)
        {
            var reportButton = new TaskDialogCommandLinkButton("Report", "Create an issue on Github (Stacktrace will be copied to clipboard).", allowCloseDialog: false);
            reportButton.Click += (s, e) => OnReportButtonClicked(exception);

            var page = new TaskDialogPage()
            {
                Heading = "Critical error occured!",
                Text = $"{exception.GetType()}: {exception.Message}",
                Expander = new TaskDialogExpander(exception.StackTrace),
                Icon = TaskDialogIcon.Error,
                AllowCancel = true,
                SizeToContent = true,
                Buttons =
                {
                    reportButton,
                    new TaskDialogCommandLinkButton("Ignore", "Proceed and ignore this error.")
                }
            };

            return TaskDialog.ShowDialog(page);
        }

        private static void OnReportButtonClicked(Exception exception)
        {
            Clipboard.SetText(exception.ToString());

            var startInfo = new ProcessStartInfo("https://github.com/midare160/SpotifyAdRemover/issues/new")
            {
                UseShellExecute = true
            };

            using var _ = Process.Start(startInfo);
        }
    }
}
