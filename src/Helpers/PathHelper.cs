using NLog;
using Spare.Entities;
using System.IO;

namespace Spare.Helpers
{
    public static class PathHelper
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static ActionResult DeleteFile(string filePath)
        {
            Logger.Trace($"Deleting file \"{filePath}\"...");
            var result = ActionHelper.Try(() => File.Delete(filePath));

            if (result.IsSuccessful)
            {
                Logger.Trace("Finished deleting file.");
            }
            else
            {
                Logger.Warn($"Couldn't delete file: {result.Exception?.Message}");
            }

            return result;
        }

        public static ActionResult DeleteDirectory(string directoryPath)
        {
            Logger.Trace($"Deleting directory \"{directoryPath}\"...");
            var result = ActionHelper.Try(() => Directory.Delete(directoryPath, true));

            if (result.IsSuccessful)
            {
                Logger.Trace("Finished deleting directory.");
            }
            else
            {
                Logger.Warn($"Couldn't delete directory: {result.Exception?.Message}");
            }

            return result;
        }
    }
}
