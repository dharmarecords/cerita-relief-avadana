namespace DR.CeritaReliefAvadana.UI.Views
{
    using DR.CeritaReliefAvadana.Core.ViewModels.Chapters;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChapterContentView : MvxContentView<ChapterViewModel>
    {
        public ChapterContentView()
        {
            InitializeComponent();
        }
    }
}
