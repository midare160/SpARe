using Spare.Extensions;
using Spare.UI;
using System;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace Spare.FileAccess
{
    public class SpotifyUpdateDirectoryAccess
    {
        #region Fields
        private readonly string _updateDirectory;
        private readonly DirectoryAccessor _directoryAccessor;
        #endregion

        #region Constructors
        public SpotifyUpdateDirectoryAccess(RichTextBox outputTextBox)
        {
            OutputTextBox = outputTextBox;

            _updateDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Spotify", "Update");
            _directoryAccessor = new DirectoryAccessor(_updateDirectory, WellKnownSidType.WorldSid);
        }
        #endregion

        #region Properties
        public RichTextBox OutputTextBox { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Denies access to the "Update"-directory to prevent Spotify from automatically updating itself
        /// </summary>
        public void Deny()
        {
            OutputTextBox.AppendText("Disabling auto-update...");

            var testPath = Path.Combine(_updateDirectory, "Test");

            try
            {
                Directory.CreateDirectory(testPath);
                Directory.Delete(testPath);
            }
            catch (UnauthorizedAccessException)
            {
                OutputTextBox.AppendText(SpareForm.TaskFinishedString, Color.Green);
                return;
            }

            _directoryAccessor.DenyAccess();

            OutputTextBox.AppendText(SpareForm.TaskFinishedString, Color.Green);
        }

        public void Allow()
        {
            OutputTextBox.AppendText("Enabling auto-update...");

            _directoryAccessor.AllowAccess();

            OutputTextBox.AppendText(SpareForm.TaskFinishedString, Color.Green);
        }
        #endregion
    }
}
