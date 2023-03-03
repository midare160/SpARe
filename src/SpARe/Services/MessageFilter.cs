using Microsoft.Extensions.Options;
using SpARe.Helpers;
using SpARe.Options;
using System.Diagnostics;

namespace SpARe.Services;

public class MessageFilter : IMessageFilter
{
    private const int WM_KEYDOWN = 0x100;
    private readonly GitHubOptions _gitHubOptions;

    public MessageFilter(IOptions<GitHubOptions> gitHubOptions)
    {
        _gitHubOptions = gitHubOptions.Value;
    }

    [DebuggerStepThrough]
    public bool PreFilterMessage(ref Message m)
    {
        if (m.Msg != WM_KEYDOWN)
        {
            return false;
        }

        switch ((Keys)m.WParam)
        {
            case Keys.F1:
                using (ProcessHelper.StartWithShell(_gitHubOptions.RepositoryUrl)) { }
                break;
            case Keys.F2:
                GC.Collect();
                break;
            case Keys.Escape:
                Form.ActiveForm?.Close();
                break;
        }

        return false;
    }
}
