using System;
using System.IO;

namespace Spare.src
{
    public class Spotify
    {
        public static readonly string RoamingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");

        public static bool IsInstalled => File.Exists(Path.Combine(RoamingDirectory, "Spotify.exe"));
    }
}
