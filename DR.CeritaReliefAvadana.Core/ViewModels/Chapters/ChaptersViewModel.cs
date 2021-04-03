namespace DR.CeritaReliefAvadana.Core.ViewModels.Chapters
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DR.CeritaReliefAvadana.Core.Services;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class ChaptersViewModel : MvxViewModel<string>
    {
        private readonly IMapper _mapper;
        private readonly IMvxNavigationService _navigationService;
        private readonly IStoriesRepository _storiesRepository;

        public ObservableCollection<ChapterViewModel> Chapters { get; } = new ObservableCollection<ChapterViewModel>();

        public ChaptersViewModel(IMapper mapper, IMvxNavigationService navigationService, IStoriesRepository storiesRepository)
        {
            _mapper = mapper;
            _navigationService = navigationService;
            _storiesRepository = storiesRepository;
        }

        public override void Prepare(string parameter)
        {
            Chapters.Clear();

            _ = _storiesRepository
                .GetChapters(parameter)
                .Select(_mapper.Map<ChapterViewModel>)
                .Aggregate(
                    Chapters,
                    (acc, e) =>
                    {
                        e.StoryId = parameter;
                        acc.Add(e);
                        return acc;
                    });
        }

        public async Task ClosePageAsync()
        {
            await _navigationService.Close(this);
        }
    }
}
