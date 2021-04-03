namespace DR.CeritaReliefAvadana.Core.ViewModels.LocalePicker
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DR.CeritaReliefAvadana.Core.Services;
    using DR.CeritaReliefAvadana.Core.ViewModels.Stories;
    using MvvmCross.Commands;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class LocalePickerViewModel : MvxViewModel
    {
        private const string SelectedColor = "accent";
        private const string UnselectedColor = "default";
        private readonly IMvxNavigationService _navigationService;
        private readonly IAppSettingsService _appSettings;

        public string IdButtonBackgroundColor => _appSettings.Locale == "id" ? SelectedColor : UnselectedColor;

        public string EnButtonBackgroundColor => _appSettings.Locale == "en" ? SelectedColor : UnselectedColor;

        public ICommand IdButtonPressed => new MvxCommand(async () => await SaveLocaleAndProceedToStoriesPageAsync("id")());

        public ICommand EnButtonPressed => new MvxCommand(async () => await SaveLocaleAndProceedToStoriesPageAsync("en")());

        public LocalePickerViewModel(IMvxNavigationService navigationService, IAppSettingsService appSettings)
        {
            _navigationService = navigationService;
            _appSettings = appSettings;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            RaisePropertyChanged(() => IdButtonBackgroundColor);
            RaisePropertyChanged(() => EnButtonBackgroundColor);
        }

        private Func<Task> SaveLocaleAndProceedToStoriesPageAsync(string locale)
        {
            return async () =>
            {
                _appSettings.Locale = locale;
                await _navigationService.Navigate<StoriesViewModel>();
            };
        }
    }
}
