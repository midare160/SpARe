using Spare.Models;
using System;
using System.IO;

namespace Spare.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Deletes the file at the specified <paramref name="filePath"/>.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> with <see langword="true"/>, if the file exists and was successfully deleted, 
        /// otherwise <see langword="false"/> and the catched <see cref="Exception"/>.</returns>
        public static ActionResult Delete(string filePath)
        {
            try
            {
                File.Delete(filePath);

                return new ActionResult(true);
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex);
            }
        }
    }
}
