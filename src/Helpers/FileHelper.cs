using System.IO;

namespace Spare.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Deletes the file at the specified <paramref name="filePath"/>.
        /// </summary>
        /// <returns><see langword="true"/>, if the file exists and was successfuly deleted, otherwise <see langword="false"/>.</returns>
        public static bool Delete(string? filePath)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            try
            {
                File.Delete(filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
