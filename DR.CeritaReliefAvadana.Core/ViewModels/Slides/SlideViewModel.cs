namespace DR.CeritaReliefAvadana.Core.ViewModels.Slides
{
    using DR.CeritaReliefAvadana.Core.Services;
    using MvvmCross.ViewModels;

    public class SlideViewModel : MvxViewModel
    {
        private readonly IDeviceDisplayInfo _deviceDisplayInfo;

        public bool IsAChapterHeader => Path == null;

        public bool IsASlide => !IsAChapterHeader;

        public string Path { get; set; }

        public double HeightRequest => _deviceDisplayInfo.Width / 1000 * 312;

        public string Name { get; set; }

        public string Caption { get; set; }

        public SlideViewModel(IDeviceDisplayInfo deviceDisplayInfo)
        {
            _deviceDisplayInfo = deviceDisplayInfo;
        }
    }
}
