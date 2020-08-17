using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace SpotifyAdRemover.FileAccess
{
    public class DirectoryAccessor
    {
        #region Properties
        public string Path { get; }
        public WellKnownSidType WellKnownSidType { get; }
        #endregion

        #region Fields
        private readonly FileSystemAccessRule _accessRule;
        #endregion

        #region Constructors
        public DirectoryAccessor(string path, WellKnownSidType wellKnownSidType)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = path;
            WellKnownSidType = wellKnownSidType;

            _accessRule = new FileSystemAccessRule(
                new SecurityIdentifier(WellKnownSidType, null),
                FileSystemRights.FullControl,
                AccessControlType.Deny);
        }
        #endregion

        #region Methods
        public void DenyAccess()
        {
            AllowOrDenyAccess(false);
        }

        /// <summary>
        /// Removes the <see cref="FileSystemAccessRule"/> from <see cref="Path"/>.
        /// </summary>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public void AllowAccess()
        {
            AllowOrDenyAccess(true);
        }
        #endregion

        #region Private Procedures
        private void AllowOrDenyAccess(bool allow)
        {
            Directory.CreateDirectory(Path);
            var directorySecurity = Directory.GetAccessControl(Path);

            if (allow)
            {
                directorySecurity.RemoveAccessRule(_accessRule);
            }
            else
            {
                directorySecurity.AddAccessRule(_accessRule);
            }

            Directory.SetAccessControl(Path, directorySecurity);
        }
        #endregion
    }
}
