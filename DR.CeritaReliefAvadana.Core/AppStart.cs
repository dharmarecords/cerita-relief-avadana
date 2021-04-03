namespace DR.CeritaReliefAvadana.Core
{
    using System.Threading.Tasks;
    using DR.CeritaReliefAvadana.Core.Services;
    using MvvmCross.Exceptions;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class AppStart : MvxAppStart
    {
        private readonly IAppSettingsService _appSettings;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, IAppSettingsService appSettings)
            : base(application, navigationService)
        {
            _appSettings = appSettings;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {
                if (_appSettings.FirstLaunch)
                {
                    _appSettings.FirstLaunch = false;

                    // NOTE: This is as per the docs: https://www.mvvmcross.com/documentation/advanced/customizing-appstart#now-create-an-appstartcs-file-and-add-the-following-code
                    // You need to Navigate sync so the screen is added to the root before continuing.
                    return NavigationService.Navigate<ViewModels.LocalePicker.LocalePickerViewModel>();
                }
                else
                {
                    return NavigationService.Navigate<ViewModels.Stories.StoriesViewModel>();
                }
            }
            catch (System.Exception exception)
            {
                throw exception.MvxWrap("Problem navigating at startup. First launch? {0}.", _appSettings.FirstLaunch);
            }
        }
    }
}
