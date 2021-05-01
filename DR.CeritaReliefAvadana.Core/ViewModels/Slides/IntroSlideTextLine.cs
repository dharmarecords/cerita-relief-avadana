namespace DR.CeritaReliefAvadana.Core.ViewModels.Slides
{
    public class IntroSlideTextLine
    {
        public string Text { get; set; }

        public bool IsNotEmpty => !string.IsNullOrEmpty(Text);

        public bool Emphasis { get; set; }
    }
}
