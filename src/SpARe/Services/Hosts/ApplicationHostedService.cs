using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace SpARe.Services.Hosts
{
    public class ApplicationHostedService : IHostedService
    {
        private readonly ILogger<ApplicationHostedService> _logger;
        private readonly IFormFactory _formFactory;

        public ApplicationHostedService(ILogger<ApplicationHostedService> logger, IFormFactory formFactory)
        {
            _logger = logger;
            _formFactory = formFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.UnhandledException += (s, e) => OnException((Exception)e.ExceptionObject);
            Application.ThreadException += (s, e) => OnException(e.Exception);

            Application.Run(_formFactory.GetForm<MainForm>());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Application.Exit(new CancelEventArgs(cancellationToken.IsCancellationRequested));
            return Task.CompletedTask;
        }

        private void OnException(Exception exception)
        {
            if (exception is OperationCanceledException)
            {
                return;
            }

            _logger.LogError(exception, "Unhandled exception occured.");
        }
    }
}
