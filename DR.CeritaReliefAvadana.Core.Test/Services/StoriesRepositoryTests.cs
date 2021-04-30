namespace DR.CeritaReliefAvadana.Core.Test.Services
{
    using System.Linq;
    using DR.CeritaReliefAvadana.Core.Services;
    using FluentAssertions;
    using Xunit;

    public class StoriesRepositoryTests
    {
        [Fact]
        public void TestGetStories()
        {
            var stories = new StoriesRepository().GetStories();

            stories.Should().HaveCount(1);
            stories.ElementAt(0).Chapters.Should().HaveCount(7);
            stories.ElementAt(0).Chapters.ElementAt(3).Introduction.Text.En.Should().HaveCount(5);
            stories.ElementAt(0).Chapters.ElementAt(3).Slides.Should().HaveCount(7);
            stories.ElementAt(0).Chapters.ElementAt(3).Slides.ElementAt(0).Caption.Id.Should().HaveCount(2);
        }

        [Theory]
        [InlineData("1", 138)]
        [InlineData("2", 96)]
        [InlineData("3", 76)]
        [InlineData("4", 72)]
        [InlineData("5", 63)]
        [InlineData("6", 35)]
        [InlineData("7", 16)]
        public void TestGetInitialSlideIndex(string chapterId, int initialSlideIndex)
        {
            var sr = new StoriesRepository();

            var isi = sr.GetInitialSlideIndex("avadana", chapterId);

            isi.Should().Be(initialSlideIndex);
        }
    }
}
