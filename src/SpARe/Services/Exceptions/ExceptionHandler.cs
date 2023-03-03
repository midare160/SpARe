using Microsoft.Extensions.Logging;
using SpARe.UI;
using WindowsFormsLifetime;

namespace SpARe.Services.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;
        private readonly IExceptionDialog _exceptionDialog;
        private readonly IGuiContext _guiContext;

        public ExceptionHandler(ILogger<ExceptionHandler> logger, IExceptionDialog exceptionDialog, IGuiContext guiContext)
        {
            _logger = logger;
            _exceptionDialog = exceptionDialog;
            _guiContext = guiContext;
        }

        public void HandleException(Exception? exception)
        {
            if (exception is null or OperationCanceledException)
            {
                return;
            }

            _logger.LogError(exception, "Unhandled exception occured.");
            _guiContext.Invoke(() => _exceptionDialog.ShowNew(exception));
        }
    }
}
