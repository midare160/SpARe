using Spare.Helpers;
using Spare.UI;
using System;
using System.Windows.Forms;

namespace Spare
{
    internal static class Program
    {
        private static readonly MainForm MainForm = new MainForm();

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

        internal static void WriteToOutput(string text, bool newLine = false) =>
            ThreadHelper.InvokeControl(MainForm.OutputTextBox, () => AppendToOutput(text, newLine));

        private static void AppendToOutput(string text, bool newLine)
        {
            if (newLine)
            {
                text = Environment.NewLine + text;
            }
            else
            {
                text = text.PadLeft(39 - MainForm.OutputTextBox.Lines[^1].Length);
            }

            MainForm.OutputTextBox.AppendText(text);
        }
    }
}
