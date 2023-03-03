using Flurl;
using Microsoft.Extensions.Options;
using SpARe.Helpers;
using SpARe.Options;

namespace SpARe.UI
{
    public class ExceptionDialog : IExceptionDialog
    {
        private readonly GitHubOptions _gitHubOptions;

        public ExceptionDialog(IOptions<GitHubOptions> gitHubOptions)
        {
            _gitHubOptions = gitHubOptions.Value;
        }

        public TaskDialogButton? ShowNew(Exception exception)
        {
            var reportButton = new TaskDialogCommandLinkButton("Report", "Create an issue on Github (Stacktrace will be copied to clipboard).", allowCloseDialog: false);
            reportButton.Click += (_, _) => OnReportButtonClicked(exception);

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

        private void OnReportButtonClicked(Exception exception)
        {
            Clipboard.SetText(exception.ToString());

            var newIssueUrl = Url.Combine(_gitHubOptions.RepositoryUrl, "issues/new");
            using var _ = ProcessHelper.StartWithShell(newIssueUrl);
        }
    }
}
