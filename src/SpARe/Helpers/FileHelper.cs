using System.IO;

namespace Spare.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Deletes the file at the specified <paramref name="filePath"/>.
        /// </summary>
        /// <returns><see langword="true"/>, if the file exists and was successfully deleted, otherwise <see langword="false"/>.</returns>
        public static bool Delete(string? filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            try
            {
#nullable disable
                File.Delete(filePath);
#nullable enable

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
