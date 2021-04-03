namespace DR.CeritaReliefAvadana.Core
{
    using MvvmCross.ViewModels;
    using MvvmCross;
    using MvvmCross.Plugin;
    using System.Diagnostics.CodeAnalysis;

    public class App : MvxApplication
    {
        public static double MainScreenHeight { get; set; }

        public static double MainScreenWidth { get; set; }

        public override void Initialize()
        {
            base.Initialize();

            Mvx.IoCProvider.RegisterSingleton(AutoMapperFactory.CreateMapper(Mvx.IoCProvider.Resolve));

            Mvx.IoCProvider.RegisterType<Services.IStoriesRepository, Services.StoriesRepository>();
            Mvx.IoCProvider.RegisterType<Services.IDeviceDisplayInfo, UI.Services.DeviceDisplayInfo>();
            Mvx.IoCProvider.RegisterType<ViewModels.Stories.StoryViewModel, ViewModels.Stories.StoryViewModel>();
            Mvx.IoCProvider.RegisterType<ViewModels.Chapters.ChapterViewModel, ViewModels.Chapters.ChapterViewModel>();
            Mvx.IoCProvider.RegisterType<ViewModels.Slides.SlideViewModel, ViewModels.Slides.SlideViewModel>();

            RegisterCustomAppStart<AppStart>();
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Scope = "Method", MessageId = "0", Justification = "API called by framework.")]
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.MethodBinding.Plugin>();
        }
    }
}
