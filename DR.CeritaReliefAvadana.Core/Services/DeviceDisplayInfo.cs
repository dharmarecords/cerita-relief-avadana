namespace DR.CeritaReliefAvadana.UI.Services
{
    using DR.CeritaReliefAvadana.Core;
    using DR.CeritaReliefAvadana.Core.Services;

    public class DeviceDisplayInfo : IDeviceDisplayInfo
    {
        public double Width => App.MainScreenWidth;

        public double Height => App.MainScreenHeight;
    }
}
