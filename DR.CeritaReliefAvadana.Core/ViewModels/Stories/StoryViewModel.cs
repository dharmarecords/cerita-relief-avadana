namespace DR.CeritaReliefAvadana.Core.ViewModels.Stories
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DR.CeritaReliefAvadana.Core.ViewModels.Chapters;
    using MvvmCross.Commands;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;

    public class StoryViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public string Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public ICommand SelectStoryCommand => new MvxCommand(async () => await SelectStoryAsync());

        public StoryViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private async Task SelectStoryAsync()
        {
            await _navigationService.Navigate<ChaptersViewModel, string>(Id);
        }
    }
}
