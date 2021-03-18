using Spare.Models;
using System;
using System.IO;

namespace Spare.Helpers
{
    public static class PathHelper
    {
        /// <summary>
        /// Deletes the file at the specified <paramref name="filePath"/>.
        /// </summary>
        /// <returns>An <see cref="ActionResult"/> with <see cref="ActionResult.IsSuccessful"/> as <see langword="true"/>, if the file exists and was successfully deleted, 
        /// otherwise <see langword="false"/> and with <see cref="ActionResult.Exception"/> as the catched <see cref="Exception"/>.</returns>
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
