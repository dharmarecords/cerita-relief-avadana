namespace DR.CeritaReliefAvadana.Core.ViewModels.Slides
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using DR.CeritaReliefAvadana.Core.Services;
    using MvvmCross.ViewModels;

    public class SlideViewModel : MvxViewModel
    {
        private readonly IDeviceDisplayInfo _deviceDisplayInfo;

        public bool IsAChapterHeader => Path == null && (Caption == null || Caption.Length == 0);

        public bool IsAChapterIntro => Path == null && Caption != null && Caption.Length != 0;

        public bool IsASlide => Path != null;

        public string Path { get; set; }

        private readonly ObservableCollection<IntroSlideTextLine> _introSlideTextLines = new ObservableCollection<IntroSlideTextLine>();
        public ObservableCollection<IntroSlideTextLine> IntroSlideTextLines
        {
            get
            {
                FillIntroSlideTextLines();
                return _introSlideTextLines;
            }
        }

        public double HeightRequest => _deviceDisplayInfo.Width / 1000 * 305;

        public double WidthRequest => _deviceDisplayInfo.Width - 10; // NOTE: 10 = 2 x 5 margin.

        public string Name { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:Properties should not return arrays", Scope = "Property", MessageId = "0", Justification = "Legit suppression as it is part of DTO.")]
        public string[] Caption { get; set; }

        public SlideViewModel(IDeviceDisplayInfo deviceDisplayInfo)
        {
            _deviceDisplayInfo = deviceDisplayInfo;
        }

        public void FillIntroSlideTextLines()
        {
            if (!IsAChapterIntro || _introSlideTextLines.Any())
            {
                return;
            }

            _introSlideTextLines.Add(new IntroSlideTextLine { Text = Name, Emphasis = true, });
            _ = Caption
                .Select(c => new IntroSlideTextLine { Text = c, Emphasis = false, })
                .Aggregate(
                    _introSlideTextLines,
                    (acc, e) =>
                    {
                        acc.Add(e);
                        return acc;
                    });
        }
    }
}
