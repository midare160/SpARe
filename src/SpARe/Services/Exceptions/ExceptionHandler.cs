using Microsoft.Extensions.Logging;

namespace SpARe.Services.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void OnAppDomainException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                _logger.LogCritical("Application can't recover from error and is terminating...");
            }

            OnException(e.ExceptionObject as Exception);
        }

        public void OnThreadException(object sender, ThreadExceptionEventArgs e) =>
            OnException(e.Exception);

        private void OnException(Exception? exception)
        {
            if (exception is OperationCanceledException)
            {
                return;
            }

            _logger.LogError(exception, "Unhandled exception occured.");
        }
    }
}
