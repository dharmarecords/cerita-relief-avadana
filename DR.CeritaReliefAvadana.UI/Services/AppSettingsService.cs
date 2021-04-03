namespace DR.CeritaReliefAvadana.UI.Services
{
    using DR.CeritaReliefAvadana.Core.Services;
    using Xamarin.Essentials;

    public sealed class AppSettingsService : IAppSettingsService
    {
        private const string DefaultLocale = "id";
        private const string LocaleSettingsKey = "locale";
        private const bool DefaultFirstLaunch = true;
        private const string FirstLaunchSettingsKey = "firstLaunch2";

        public string Locale
        {
            get => Preferences.Get(LocaleSettingsKey, DefaultLocale);
            set => Preferences.Set(LocaleSettingsKey, value);
        }

        public bool FirstLaunch
        {
            get => Preferences.Get(FirstLaunchSettingsKey, DefaultFirstLaunch);
            set => Preferences.Set(FirstLaunchSettingsKey, value);
        }
    }
}
