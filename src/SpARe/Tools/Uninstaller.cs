using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;

namespace Spare.Tools
{
    public class Uninstaller
    {
        public static string[] GetDirectories()
        {
            var local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return new[]
            {
                Path.Combine(local, nameof(Spotify)),
                Path.Combine(roaming, nameof(Spotify))
            };
        }

        public static RegistryKey?[] GetRegistryKeys()
        {
            const string softwareClasses = @"SOFTWARE\Classes\spotify";

            return new[]
            {
                Registry.LocalMachine.OpenSubKey(softwareClasses, true),
                Registry.CurrentUser.OpenSubKey(softwareClasses, true),
                Registry.CurrentUser.OpenSubKey($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Spotify", true),
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Spotify", true),
                Registry.Users.OpenSubKey($@"{WindowsIdentity.GetCurrent().User}_Classes\spotify", true)
            };
        }
    }
}
