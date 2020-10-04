using Spare.Properties;

namespace Spare.Extensions
{
    public static class SettingsExtensions
    {
        internal static void Save(this Settings settings, bool reload)
        {
            settings.Save();
            if (reload) settings.Reload();
        }
    }
}
