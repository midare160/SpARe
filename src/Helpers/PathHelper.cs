using Spare.Entities;
using System.IO;

namespace Spare.Helpers
{
    public static class PathHelper
    {
        public static ActionResult DeleteFile(string filePath)
        {
            return ActionHelper.Try(() => File.Delete(filePath));
        }

        public static ActionResult DeleteDirectory(string directoryPath)
        {
            return ActionHelper.Try(() => Directory.Delete(directoryPath, true));
        }
    }
}
