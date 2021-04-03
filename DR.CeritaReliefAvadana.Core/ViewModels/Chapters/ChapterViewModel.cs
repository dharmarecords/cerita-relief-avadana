namespace DR.CeritaReliefAvadana.Core.ViewModels.Chapters
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DR.CeritaReliefAvadana.Core.Services;
    using DR.CeritaReliefAvadana.Core.ViewModels.Slides;
    using MvvmCross.Commands;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class ChapterViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IStoriesRepository _storiesRepository;

        public string Id { get; set; }

        public string StoryId { get; set; }

        public string Name { get; set; }

        public ICommand SelectChapterCommand => new MvxCommand(async () => await SelectChapterAsync());

        public ChapterViewModel(IMvxNavigationService navigationService, IStoriesRepository storiesRepository)
        {
            _navigationService = navigationService;
            _storiesRepository = storiesRepository;
        }

        public async Task ClosePageAsync()
        {
            await _navigationService.Close(this);
        }

        private async Task SelectChapterAsync()
        {
            var initialSlideIndex = _storiesRepository.GetInitialSlideIndex(StoryId, Id);
            await _navigationService.Navigate<SlidesViewModel, (string StoryId, int InitialSlideIndex)>((StoryId, initialSlideIndex));
        }
    }
}
