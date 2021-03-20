using Spare.UI;
using System;
using System.Windows.Forms;

namespace Spare.Root
{
    internal static class Program
    {
        public static readonly MainForm MainForm = new();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm);
        }
    }
}
