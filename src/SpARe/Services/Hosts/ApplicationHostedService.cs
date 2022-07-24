using Microsoft.Extensions.Hosting;
using System.ComponentModel;

namespace SpARe.Services.Hosts
{
    public class ApplicationHostedService : IHostedService
    {
        private readonly IFormFactory _formFactory;

        public ApplicationHostedService(IFormFactory formFactory)
        {
            _formFactory = formFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.UnhandledException += (s, e) => OnException(e.ExceptionObject);
            Application.ThreadException += (s, e) => OnException(e.Exception);
            Application.Run(_formFactory.GetForm<MainForm>());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Application.Exit(new CancelEventArgs(cancellationToken.IsCancellationRequested));
            return Task.CompletedTask;
        }

        private static void OnException(object exceptionObject)
        {
            if (exceptionObject is not Exception or OperationCanceledException)
            {
                return;
            }

            // TODO handle ex
        }
    }
}
