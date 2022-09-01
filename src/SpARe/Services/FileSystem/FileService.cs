using Microsoft.Extensions.Logging;

namespace SpARe.Services.FileSystem
{
    public class FileService : IFileService
    {
        private readonly ILogger _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public bool Delete(string? path)
        {
            _logger.LogTrace("Trying to delete file {path}...", path);

            if (!File.Exists(path))
            {
                _logger.LogInformation("File {path} did not exist or permission was denied.", path);
                return false;
            }

            File.Delete(path);

            _logger.LogInformation("File {path} successfully deleted.", path);
            return true;
        }
    }
}
