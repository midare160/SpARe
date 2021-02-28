using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spare.Extensions
{
    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// Appends the given <paramref name="text"/> colored with <paramref name="color"/> to a <see cref="RichTextBox"/>.
        /// </summary>
        public static void AppendText(this RichTextBox textBox, string? text, Color color)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException(nameof(textBox));
            }

            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = default;

            textBox.SelectionColor = color;
            textBox.AppendText(text);
            textBox.SelectionColor = textBox.ForeColor;
        }
    }
}
