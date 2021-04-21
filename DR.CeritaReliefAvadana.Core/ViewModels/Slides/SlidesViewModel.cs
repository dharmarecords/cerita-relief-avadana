namespace DR.CeritaReliefAvadana.Core.ViewModels.Slides
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DR.CeritaReliefAvadana.Core.Models;
    using DR.CeritaReliefAvadana.Core.Services;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class SlidesViewModel : MvxViewModel<(string StoryId, int InitialSlideIndex)>
    {
        private readonly IMapper _mapper;
        private readonly IMvxNavigationService _navigationService;
        private readonly IStoriesRepository _storiesRepository;
        private string _storyId;

        public int InitialSlideIndex { get; set; }

        public ObservableCollection<SlideViewModel> Slides { get; } = new ObservableCollection<SlideViewModel>();

        public SlidesViewModel(IMapper mapper, IMvxNavigationService navigationService, IStoriesRepository storiesRepository)
        {
            _mapper = mapper;
            _navigationService = navigationService;
            _storiesRepository = storiesRepository;
        }

        public override void Prepare((string StoryId, int InitialSlideIndex) parameter)
        {
            (_storyId, InitialSlideIndex) = parameter;

            Slides.Clear();

            _ = _storiesRepository
                .GetChapters(_storyId)
                .SelectMany(c => CreateSlidesForChapter(_storyId, c))
                .Reverse()
                .Select(_mapper.Map<SlideViewModel>)
                .Aggregate(
                    Slides,
                    (acc, e) =>
                    {
                        acc.Add(e);
                        return acc;
                    });
        }

        public async Task ClosePageAsync()
        {
            await _navigationService.Close(this);
        }

        private IEnumerable<Slide> CreateSlidesForChapter(string storyId, Chapter c)
        {
            var implicitSlides = new[] {
                new Slide { Name = c.Name },
                new Slide { Name = c.Introduction.Background, Caption = c.Introduction.Text },
            };
            var slides = _storiesRepository.GetSlides(storyId, c.Id);

            return implicitSlides.Concat(slides);
        }
    }
}
