using NLog;
using NLog.Config;
using NLog.Targets;
using Spare.SpotifyTools;
using Spare.UI;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Spare
{
    internal static class Program
    {
        public static MainForm MainForm { get; } = new();

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ConfigureLogging();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += OnUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm);
        }

        private static void ConfigureLogging()
        {
            var errorLogFile = new FileTarget
            {
                Layout = "${longdate}|${level:uppercase=true}|${message}${exception:format=ToString}",
                FileName = Path.Combine(Paths.Logs, "error.log"),
                KeepFileOpen = true,
            };

            var traceLogFile = new FileTarget
            {
                FileName = Path.Combine(Paths.Logs, "trace.log"),
                KeepFileOpen = true,
            };

            LogManager.Configuration = new LoggingConfiguration
            {
                LoggingRules =
                {
                    new LoggingRule("*", LogLevel.Trace, LogLevel.Warn, traceLogFile),
                    new LoggingRule("*", LogLevel.Error, LogLevel.Fatal, errorLogFile),
                    new LoggingRule("*", LogLevel.Trace, LogLevel.Fatal, new ConsoleTarget())
                }
            };
        }

        private static void OnUnhandledException(object sender, EventArgs e)
        {
            var exception = (e as ThreadExceptionEventArgs)?.Exception ?? (e as UnhandledExceptionEventArgs)?.ExceptionObject as Exception;

            Logger.Error(exception);

            var reportButton = new TaskDialogCommandLinkButton("Report", "Create an issue on Github (Stacktrace will be copied to clipboard).");

            var page = new TaskDialogPage
            {
                Heading = "Critical error occured!",
                Text = exception?.Message,
                Icon = TaskDialogIcon.Error,
                AllowCancel = true,
                Expander = new TaskDialogExpander(exception?.ToString()),
                Buttons =
                {
                    reportButton,
                    new TaskDialogCommandLinkButton("Ignore", "Proceed and ignore this error.")
                }
            };

            if (TaskDialog.ShowDialog(MainForm, page) == reportButton)
            {
                Clipboard.SetText($"```\n{exception}\n```");
                Manager.OpenRepoWebsite("issues/new");
            }
        }
    }
}
