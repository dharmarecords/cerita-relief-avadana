namespace DR.CeritaReliefAvadana.Core.ViewModels.Slides
{
    using System.Diagnostics.CodeAnalysis;
    using DR.CeritaReliefAvadana.Core.Services;
    using MvvmCross.ViewModels;

    public class SlideViewModel : MvxViewModel
    {
        private readonly IDeviceDisplayInfo _deviceDisplayInfo;

        public bool IsAChapterHeader => Path == null && (Caption == null || Caption.Length == 0);

        public bool IsAChapterIntro => Path == null && Caption != null && Caption.Length != 0;

        public bool IsASlide => Path != null;

        public string Path { get; set; }

        public double HeightRequest => _deviceDisplayInfo.Width / 1000 * 321;

        public string Name { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:Properties should not return arrays", Scope = "Property", MessageId = "0", Justification = "Legit suppression as it is part of DTO.")]
        public string[] Caption { get; set; }

        public SlideViewModel(IDeviceDisplayInfo deviceDisplayInfo)
        {
            _deviceDisplayInfo = deviceDisplayInfo;
        }
    }
}
