namespace DR.CeritaReliefAvadana.UI.Views
{
    using DR.CeritaReliefAvadana.Core.ViewModels.Slides;
    using MvvmCross.Forms.Views;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SlideContentView : MvxContentView<SlideViewModel>
    {
        public SlideContentView()
        {
            InitializeComponent();
        }
    }
}
