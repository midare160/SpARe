using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace SpotifyAdRemover.Tools.RegistryTools
{
    public class RegistryReader
    {
        #region Constructors
        public RegistryReader(RegistryKey key, string subKey, string folderName = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(subKey))
            {
                throw new ArgumentNullException(nameof(subKey));
            }

            if (string.IsNullOrEmpty(folderName))
            {
                folderName = Application.ProductName;
            }

            RegistryKey = key.OpenSubKey(subKey)?.OpenSubKey(folderName);
        }

        public RegistryReader()
        {
            RegistryKey = Registry.CurrentUser
                .OpenSubKey("Software")?
                .OpenSubKey(Application.ProductName);
        }
        #endregion

        #region Properties
        public RegistryKey RegistryKey { get; }
        #endregion

        #region Methods
        public object GetValue(string keyName)
        {
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            return RegistryKey?.GetValue(keyName);
        }
        #endregion
    }
}
