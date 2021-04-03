namespace DR.CeritaReliefAvadana.Droid.Views
{
    using System.Threading.Tasks;
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using MvvmCross.Forms.Platforms.Android.Views;

    [Activity(
        NoHistory = true,
        MainLauncher = true,
        Label = "@string/app_name",
        Theme = "@style/AppTheme.Splash",
        ScreenOrientation = ScreenOrientation.SensorLandscape)]
    public class SplashActivity : MvxFormsSplashScreenActivity<Setup, Core.App, UI.App>
    {
        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Essentials.Platform.Init(this, bundle);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
