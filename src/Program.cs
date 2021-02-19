using Spare.Helpers;
using Spare.UI;
using System;
using System.Diagnostics;
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
                text += Environment.NewLine;
            }
            else if (MainForm.OutputTextBox.Lines.Length > 0)
            {
                // TODO measure text length to replace magic number 41
                var maxLength = MainForm.OutputTextBox.Width / TextRenderer.MeasureText("a", MainForm.OutputTextBox.Font, MainForm.OutputTextBox.Size).Width;
                text = text.PadLeft(41 - MainForm.OutputTextBox.Lines[^1].Length);
            }

            MainForm.OutputTextBox.AppendText(text);
            Debug.Write(text);
        }
    }
}
