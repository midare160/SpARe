using Spare.Extensions;
using Spare.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spare
{
    public static class Output
    {
        public const int Width = 39;

        public static void Message(string message, HorizontalAlignment align = default, Color? textColor = null) =>
            InvokeControlForMessage(message, align, textColor ?? Program.MainForm.OutputTextBox.ForeColor);

        public static void SuccessMessage(string message = "OK") =>
            InvokeControlForMessage(message, HorizontalAlignment.Right, Color.Green);

        public static void FailedMessage(string message = "FAILED") =>
            InvokeControlForMessage(message, HorizontalAlignment.Right, Color.Red);

        public static void NewLine() =>
            InvokeControlForMessage(null, HorizontalAlignment.Center, Program.MainForm.OutputTextBox.ForeColor);

        private static void InvokeControlForMessage(string? message, HorizontalAlignment align, Color fontColor) =>
            ThreadHelper.InvokeControl(Program.MainForm.OutputTextBox, () => AppendToOutput(message, align, fontColor));

        private static void AppendToOutput(string? text, HorizontalAlignment align, Color textColor)
        {
            switch (align)
            {
                case HorizontalAlignment.Right:
                    text = text?.PadLeft(Width - Program.MainForm.OutputTextBox.Lines[^1].Length);
                    break;
                case HorizontalAlignment.Center:
                    text = text?.PadCenter(Width);
                    break;
                default:
                    break;
            }

            if (align != HorizontalAlignment.Left)
            {
                text += Environment.NewLine;
            }

            Program.MainForm.OutputTextBox.AppendText(text, textColor);
        }
    }
}
