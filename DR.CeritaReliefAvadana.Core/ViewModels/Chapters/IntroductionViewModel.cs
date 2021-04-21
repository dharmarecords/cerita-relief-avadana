namespace DR.CeritaReliefAvadana.Core.ViewModels.Chapters
{
    using System.Diagnostics.CodeAnalysis;
    using MvvmCross.ViewModels;

    public class IntroductionViewModel : MvxViewModel
    {
        public string ChapterId { get; set; }

        public string Background { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:Properties should not return arrays", Scope = "Property", MessageId = "0", Justification = "Legit suppression as it is part of DTO.")]
        public string[] Text { get; set; }
    }
}
