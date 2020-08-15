using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace RemoveSpotifyAds
{
    public class DirectoryAccess
    {
        #region Properties
        public string Path { get; }
        public WellKnownSidType WellKnownSidType { get; }
        #endregion

        #region Fields
        private readonly FileSystemAccessRule _accessRule;
        #endregion

        #region Constructors
        public DirectoryAccess(string path, WellKnownSidType wellKnownSidType)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = path;
            WellKnownSidType = wellKnownSidType;

            var user = new SecurityIdentifier(WellKnownSidType, null);
            _accessRule = new FileSystemAccessRule(user, FileSystemRights.FullControl, AccessControlType.Deny);
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
