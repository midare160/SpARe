using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace SpARe.Services.IO;

public class FileService : IFileService
{
    private const int NumberOfRetries = 5;
    private const string PathKey = "path";

    private static readonly TimeSpan SleepDuration = TimeSpan.FromMilliseconds(500);

    private readonly ILogger _logger;
    private readonly ISyncPolicy _retryPolicy;

    public FileService(ILogger<FileService> logger)
    {
        _logger = logger;
        _retryPolicy = GetRetryPolicy();
    }

    public bool Delete(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        _logger.LogTrace("Trying to delete file {path}...", path);

        var result = _retryPolicy.ExecuteAndCapture(c => File.Delete((string)c[PathKey]), GetRetryContext(path));

        if (result.Outcome == OutcomeType.Failure)
        {
            _logger.LogWarning(
                result.ExceptionType == ExceptionType.Unhandled ? result.FinalException : null,
                "File {path} couldn't be deleted! Cancelling...",
                path);

            return false;
        }

        _logger.LogInformation("File {path} successfully deleted.", path);
        return true;
    }

    private RetryPolicy GetRetryPolicy()
    {
        return Policy.Handle<UnauthorizedAccessException>()
            .Or<IOException>()
            .WaitAndRetry(NumberOfRetries, i => i * SleepDuration, OnRetry);
    }

    private void OnRetry(Exception exception, TimeSpan sleepDuration, int retryCount, Context context)
    {
        _logger.LogInformation(
            exception,
            "File {0} couldn't be deleted! Retry {1}/{2}. Next retry in {3} sec...",
            context[PathKey],
            retryCount,
            NumberOfRetries,
            sleepDuration.TotalSeconds);
    }

    private static Context GetRetryContext(string path)
    {
        return new Context()
        {
            { PathKey, path }
        };
    }
}
