namespace SpARe.Services.General
{
    public class MessageFilter : IMessageFilter
    {
        private const int WM_KEYDOWN = 0x100;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != WM_KEYDOWN)
            {
                return false;
            }

            switch ((Keys)m.WParam)
            {
                case Keys.F1:
                    // TODO open readme in repo
                    break;
                case Keys.Escape:
                    Form.ActiveForm?.Close();
                    break;
            }

            return false;
        }
    }
}
