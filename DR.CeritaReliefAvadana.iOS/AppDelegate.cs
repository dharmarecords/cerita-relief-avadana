namespace DR.CeritaReliefAvadana.iOS
{
    using Foundation;
    using MvvmCross.Forms.Platforms.Ios.Core;
    using UIKit;

    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override void FinishedLaunching(UIApplication application)
        {
            base.FinishedLaunching(application);

            Core.App.MainScreenHeight = UIScreen.MainScreen.Bounds.Height;
            Core.App.MainScreenWidth = UIScreen.MainScreen.Bounds.Width;
        }
    }
}
