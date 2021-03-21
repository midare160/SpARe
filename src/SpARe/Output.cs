using Spare.Extensions;
using Spare.UI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Spare
{
    public static class Output
    {
        private const int Width = 39;
        private const string SuccessMessageString = "OK";
        private const string FailedMessageString = "FAILED";

        private static void InvokeControlForMessage(string? message, HorizontalAlignment align, Color? fontColor = null) =>
            Program.MainForm.OutputTextBox.Invoke(new Action(() => AppendToOutput(message, align, fontColor)));

        private static void AppendToOutput(string? text, HorizontalAlignment align, Color? textColor)
        {
            if (align != HorizontalAlignment.Left)
            {
                if (align == HorizontalAlignment.Right)
                {
                    text = text?.PadLeft(Width - Program.MainForm.OutputTextBox.Lines[^1].Length);
                }
                else
                {
                    text = text?.PadCenter(Width);
                }

                text += Environment.NewLine;
            }

            Program.MainForm.OutputTextBox.AppendText(text, textColor ?? Program.MainForm.OutputTextBox.ForeColor);
        }

        /// <summary>
        /// Writes the given <paramref name="message"/> to the <see cref="MainForm.OutputTextBox"/> with the specified <paramref name="align"/> and <paramref name="textColor"/> applied.
        /// </summary>
        /// <param name="align">If not <see cref="HorizontalAlignment.Left"/>, an <see cref="Environment.NewLine"/> is added at the end of the <paramref name="message"/>.</param>
        /// <param name="textColor">If <see langword="null"/>, <see cref="RichTextBox.ForeColor"/> of <see cref="MainForm.OutputTextBox"/> will be used.</param>
        public static void Message(string? message, HorizontalAlignment align = default, Color? textColor = null) =>
            InvokeControlForMessage(message, align, textColor);

        /// <summary>
        /// Writes the given <paramref name="message"/> to the <see cref="MainForm.OutputTextBox"/> with <see cref="HorizontalAlignment.Right"/> and <see cref="Color.Green"/> applied
        /// and appends an <see cref="Environment.NewLine"/> afterwards.
        /// </summary>
        public static void SuccessMessage(string? message = SuccessMessageString) =>
            InvokeControlForMessage(message, HorizontalAlignment.Right, Color.Green);

        /// <summary>
        /// Writes the given <paramref name="message"/> to the <see cref="MainForm.OutputTextBox"/> with <see cref="HorizontalAlignment.Right"/> and <see cref="Color.Red"/> applied
        /// and appends an <see cref="Environment.NewLine"/> afterwards.
        /// </summary>
        public static void FailedMessage(string? message = FailedMessageString) =>
            InvokeControlForMessage(message, HorizontalAlignment.Right, Color.Red);

        /// <summary>
        /// Appends the <paramref name="message"/> to the <see cref="MainForm.OutputTextBox"/> with <see cref="HorizontalAlignment.Right"/> 
        /// and either <see cref="Color.Red"/> or <see cref="Color.Green"/> applied, depending on <paramref name="isSuccess"/>'s value.
        /// </summary>
        /// <remarks>Appends an <see cref="Environment.NewLine"/> afterwards.</remarks>
        public static void EndMessage(bool isSuccess, string? message = null)
        {
            if (isSuccess)
            {
                SuccessMessage(message ?? SuccessMessageString);
            }
            else
            {
                FailedMessage(message ?? FailedMessageString);
            }
        }

        public static void NewLine() =>
            InvokeControlForMessage(null, HorizontalAlignment.Center);

        /// <summary>
        /// Appends dashes ("-") <see cref="Width"/> times plus an <see cref="Environment.NewLine"/> to the <see cref="MainForm.OutputTextBox"/>.
        /// </summary>
        public static void EndOfBlock() =>
            InvokeControlForMessage(string.Concat(Enumerable.Repeat('-', Width)), HorizontalAlignment.Center);
    }
}
