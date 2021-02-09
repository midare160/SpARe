using Spare.Extensions;
using Spare.FileAccess;
using Spare.UI;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Spare.Tools
{
    public class Uninstaller
    {
        public Uninstaller(RichTextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;
        }

        public RichTextBox OutputTextBox { get; }

        public void UninstallSpotify()
        {
            OutputTextBox.AppendText("Uninstalling Spotify...");
            Process.Start(Path.Combine(AppDirectoryAccess.RoamingDirectory, "Spotify.exe"), "/uninstall /qn").WaitForExit();

            // TODO check status of uninstaller like in installer => find process and wait for it to exit

            OutputTextBox.AppendText(SpareForm.TaskFinishedString, Color.Green);

            // TODO clear/delete all remaining folders and registry entries
        }
    }
}
