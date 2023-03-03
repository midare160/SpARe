namespace SpARe.Helpers
{
    public static class MessageBoxHelper
    {
        public static DialogResult Question(
            string text,
            string? caption = null,
            MessageBoxButtons buttons = MessageBoxButtons.YesNo,
            MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Info(
            string text,
            string? caption = "Info",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Warning(
            string text,
            string? caption = "Warning!",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Warning)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
    }
}
