using Spare.Extensions;
using Spare.Helpers;
using System;
using System.Drawing;

namespace Spare.src
{
    public static class Output
    {
        public static void Message(string message, bool newLine = true) =>
            InvokeControlForMessage(message, newLine, Program.MainForm.OutputTextBox.ForeColor);

        public static void SuccessMessage() =>
            InvokeControlForMessage("OK", false, Color.Green);

        public static void FailedMessage() =>
            InvokeControlForMessage("FAILED", false, Color.Red);

        private static void InvokeControlForMessage(string message, bool newLine, Color fontColor) =>
            ThreadHelper.InvokeControl(Program.MainForm.OutputTextBox, () => AppendToOutput(message, newLine, fontColor));

        private static void AppendToOutput(string text, bool newLine, Color fontColor)
        {
            if (newLine)
            {
                text = Environment.NewLine + text;
            }
            else
            {
                var padding = Math.Max(0, 39 - Program.MainForm.OutputTextBox.Lines[^1].Length);
                text = text.PadLeft(padding);
            }

            Program.MainForm.OutputTextBox.AppendText(text, fontColor);
        }
    }
}
