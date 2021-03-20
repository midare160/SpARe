using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Principal;

namespace Spare.SpotifyTools
{
    public class Uninstaller
    {
        public static string[] GetDirectories()
        {
            var local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return new[]
            {
                Path.Combine(local, "Spotify"),
                Path.Combine(roaming, "Spotify")
            };
        }

        public static void DeleteRegistryKeys()
        {
            const string softwareClasses = @"SOFTWARE\Classes\spotify";
            const bool throwOnMissing = false;

            Registry.LocalMachine.DeleteSubKeyTree(softwareClasses, throwOnMissing);
            Registry.Users.DeleteSubKeyTree($@"{WindowsIdentity.GetCurrent().User}_Classes\spotify", throwOnMissing);

            var currentUserKey = Registry.CurrentUser;
            currentUserKey.DeleteSubKeyTree(softwareClasses, throwOnMissing);
            currentUserKey.DeleteSubKeyTree($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Spotify", throwOnMissing);
            currentUserKey.DeleteSubKeyTree(@"SOFTWARE\Spotify", throwOnMissing);
        }
    }
}
