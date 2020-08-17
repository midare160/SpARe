using System;
using System.Windows.Forms;
using SpotifyAdRemover.UI;

namespace SpotifyAdRemover
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpotifyAdRemoverForm());
        }
    }
}
