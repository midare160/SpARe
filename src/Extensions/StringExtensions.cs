using System;

namespace Spare.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a new string that centers the characters in this instance by padding
        /// them with spaces on the left and right, for a specified total length.
        /// </summary>
        public static string PadCenter(this string str, int totalWidth)
        {
            str.ThrowIfNullOrEmpty(nameof(str));

            var spaces = totalWidth - str.Length;
            var padLeft = spaces / 2 + str.Length;

            return str.PadLeft(padLeft).PadRight(totalWidth);
        }

        public static void ThrowIfNullOrEmpty(this string? str, string? argumentName = null, string? message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }
    }
}
