namespace SpARe.Services.Exceptions
{
    public interface IExceptionHandler
    {
        void HandleException(Exception? exception);
    }
}
