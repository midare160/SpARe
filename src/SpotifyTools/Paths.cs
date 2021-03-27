using System;
using System.IO;

namespace Spare.SpotifyTools
{
    public static class Paths
    {
        public static string Local { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify");

        public static string Roaming { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spotify");

        public static string SpotifyExe { get; } = Path.Combine(Roaming, "Spotify.exe");
    }
}
