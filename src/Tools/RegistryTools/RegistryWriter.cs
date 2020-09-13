using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace SpotifyAdRemover.Tools.RegistryTools
{
    /// <summary>
    /// Class to write to Registry.
    /// </summary>
    public class RegistryWriter
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="RegistryWriter"/>.
        /// </summary>
        /// <param name="key">One of the properties in <see cref="Registry"/> that represents a registry user.</param>
        /// <param name="subKey"></param>
        /// <param name="subSubKey"></param>
        public RegistryWriter(RegistryKey key, string subKey, string subSubKey = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(subKey))
            {
                throw new ArgumentNullException(nameof(subKey));
            }

            if (string.IsNullOrEmpty(subSubKey))
            {
                subSubKey = Application.ProductName;
            }

            RegistryKey = key.OpenSubKey(subKey, true);
            SubSubKey = subSubKey;
        }

        /// <summary>
        /// Default registry key is "\HKEY_CURRENT_USER\SOFTWARE\<see cref="Application.ProductName"/>\".
        /// </summary>
        public RegistryWriter()
        {
            RegistryKey = Registry.CurrentUser.OpenSubKey("Software", true);
            SubSubKey = Application.ProductName;
        }
        #endregion

        #region Properties
        public RegistryKey RegistryKey { get; }
        public string SubSubKey { get; }
        #endregion

        #region Methods
        public void SetValue(string keyName, object keyValue, RegistryValueKind valueKind = RegistryValueKind.Unknown)
        {
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException(nameof(keyName));
            }

            if (keyValue == null)
            {
                throw new ArgumentNullException(nameof(keyValue));
            }

            RegistryKey.CreateSubKey(SubSubKey, true).SetValue(keyName, keyValue, valueKind);
        }

        public void DeleteValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            RegistryKey.OpenSubKey(SubSubKey, true)?.DeleteValue(name, false);
        }
        #endregion
    }
}
