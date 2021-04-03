namespace DR.CeritaReliefAvadana.iOS
{
    using DR.CeritaReliefAvadana.Core.Services;
    using DR.CeritaReliefAvadana.UI.Services;
    using MvvmCross;
    using MvvmCross.Forms.Platforms.Ios.Core;

    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterType<IAppSettingsService, AppSettingsService>();
        }
    }
}
