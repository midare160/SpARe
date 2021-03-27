using System.Configuration;

namespace Spare.Properties
{
    public sealed class Settings : ApplicationSettingsBase
    {
        #region Static
        private const string FalseString = "False";
        private const string TrueString = "True";

        public static Settings Instance { get; } = (Settings)Synchronized(new Settings());
        #endregion

        #region Constructors
        private Settings() { }
        #endregion

        #region Properties
        [UserScopedSetting]
        [DefaultSettingValue(FalseString)]
        public bool AdsRemoved
        {
            get => (bool)this[nameof(AdsRemoved)];
            set => this[nameof(AdsRemoved)] = value;
        }

        [UserScopedSetting]
        [DefaultSettingValue(TrueString)]
        public bool UpgradeRequired
        {
            get => (bool)this[nameof(UpgradeRequired)];
            set => this[nameof(UpgradeRequired)] = value;
        }
        #endregion

        #region Overrides
        public override void Save()
        {
            base.Save();
            this.Reload();
        }

        public override void Upgrade()
        {
            if (!UpgradeRequired) return;

            base.Upgrade();
            this.UpgradeRequired = false;
            this.Save();
        }
        #endregion
    }
}
