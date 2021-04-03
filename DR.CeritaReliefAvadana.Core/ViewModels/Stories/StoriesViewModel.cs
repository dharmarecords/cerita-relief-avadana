namespace DR.CeritaReliefAvadana.Core.ViewModels.Stories
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using AutoMapper;
    using DR.CeritaReliefAvadana.Core.Services;
    using DR.CeritaReliefAvadana.Core.ViewModels.LocalePicker;
    using MvvmCross.Commands;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class StoriesViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMapper _mapper;
        private readonly IStoriesRepository _storiesRepository;

        public ObservableCollection<StoryViewModel> Stories { get; } = new ObservableCollection<StoryViewModel>();

        public ICommand ShowSettingsCommand => new MvxCommand(async () => await _navigationService.Navigate<LocalePickerViewModel>());

        public StoriesViewModel(IMvxNavigationService navigationService, IMapper mapper, IStoriesRepository storiesRepository)
        {
            _navigationService = navigationService;
            _mapper = mapper;
            _storiesRepository = storiesRepository;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            Stories.Clear();

            _ = _storiesRepository
                .GetStories()
                .Where(s => s.Enabled)
                .Select(_mapper.Map<StoryViewModel>)
                .Aggregate(Stories, (acc, e) => { acc.Add(e); return acc; });
        }
    }
}
