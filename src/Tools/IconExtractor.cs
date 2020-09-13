using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SpotifyAdRemover.Tools
{
    /// <summary>
    /// Provides methods to extract an <see cref="Icon"/> from a dll.
    /// </summary>
    public class IconExtractor
    {
        /// <summary>
        /// Extracts the <see cref="Icon"/> from the given <paramref name="dllFile"/>.
        /// </summary>
        /// <param name="dllFile">DLL file where the <see cref="Icon"/> is located.</param>
        /// <param name="iconIndex">Index of <see cref="Icon"/>.</param>
        /// <param name="largeIcon">Indicates whether the large or the small <see cref="Icon"/> will be returned.</param>
        /// <returns></returns>
        public static Icon Extract(string dllFile, int iconIndex, bool largeIcon)
        {
            ExtractIconEx(dllFile, iconIndex, out var large, out var small, 1);

            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }

        [DllImport("shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iconIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
    }
}
