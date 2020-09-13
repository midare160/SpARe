using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpotifyAdRemover.Extensions
{
    /// <summary>
    /// Provides Extensions for <see cref="TextBoxBase"/> controls
    /// </summary>
    public static class TextBoxExtensions
    {
        /// <summary>
        /// Appends the given <paramref name="text"/> colored with <paramref name="color"/> to a <see cref="RichTextBox"/>.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="text">The text that should be appended.</param>
        /// <param name="color">Represents the color of the appended text.</param>
        public static void AppendText(this RichTextBox textBox, string text, Color color)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException(nameof(textBox));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            textBox.SelectionColor = color;
            textBox.AppendText(text);
            textBox.SelectionColor = textBox.ForeColor;
        }
    }
}
