using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using RemoveSpotifyAds.UI;

namespace RemoveSpotifyAds
{
    public static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RemoveSpotifyAdsForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine((e.ExceptionObject as Exception)?.Message);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
        }
    }
}
