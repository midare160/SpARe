using Microsoft.Extensions.Hosting;
using SpARe.Services.Exceptions;
using System.ComponentModel;

namespace SpARe.Services.Hosts
{
    public class ApplicationHostedService : IHostedService
    {
        private readonly IFormFactory _formFactory;
        private readonly IExceptionHandler _exceptionHandler;

        public ApplicationHostedService(IFormFactory formFactory, IExceptionHandler exceptionHandler)
        {
            _formFactory = formFactory;
            _exceptionHandler = exceptionHandler;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.UnhandledException += _exceptionHandler.OnAppDomainException;
            Application.ThreadException += _exceptionHandler.OnThreadException;

            Application.Run(_formFactory.GetForm<MainForm>());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Application.Exit(new CancelEventArgs(cancellationToken.IsCancellationRequested));
            return Task.CompletedTask;
        }
    }
}
