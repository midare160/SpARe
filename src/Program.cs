using System;
using System.Windows.Forms;
using Spare.UI;

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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            var form = new SpareForm();

            Application.ThreadException += (s, e) => ExceptionBox.Show(form, e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ExceptionBox.Show(form, (Exception)e.ExceptionObject);

            Application.Run(form);
        }
    }
}
