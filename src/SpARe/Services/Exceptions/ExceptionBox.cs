using System.Diagnostics;

namespace SpARe.Services.Exceptions
{
    public static class ExceptionBox
    {
        public static TaskDialogButton? Show(Exception exception)
        {
            var reportButton = new TaskDialogButton("Create an issue on Github (Stacktrace will be copied to clipboard).", allowCloseDialog: false);
            reportButton.Click += (s, e) => OnReportButtonClicked(exception);

            var page = new TaskDialogPage()
            {
                Caption = "Critical error occured!",
                Heading = exception.Message,
                Icon = TaskDialogIcon.Error,
                AllowCancel = true,
                Expander = new TaskDialogExpander(exception.ToString()),
            };

            return TaskDialog.ShowDialog(page);
        }

        private static void OnReportButtonClicked(Exception exception)
        {
            Clipboard.SetText(exception.ToString());
            using var _ = Process.Start("https://github.com/midare160/SpotifyAdRemover/issues/new");
        }
    }
}
