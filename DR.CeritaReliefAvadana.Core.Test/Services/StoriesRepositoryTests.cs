namespace DR.CeritaReliefAvadana.Core.Test.Services
{
    using System.Linq;
    using DR.CeritaReliefAvadana.Core.Models;
    using DR.CeritaReliefAvadana.Core.Services;
    using FluentAssertions;
    using Xunit;

    public class StoriesRepositoryTests
    {
        [Fact]
        public void TestGetStories()
        {
            var stories = new StoriesRepository().GetStories();

            stories.Should().HaveCount(2);
            stories.ElementAt(1).Should().BeEquivalentTo(new Story
            {
                Id = "series2",
                Name = new LocalizedString
                {
                    En = "s2 - english",
                    Id = "s2 - bhasa",
                },
                Description = new LocalizedString
                {
                    En = "s2 - desc - english",
                    Id = "s2 - desc - bhasa",
                },
                Chapters = new[] {
                    new Chapter
                    {
                        Id = "1",
                        Name = new LocalizedString
                        {
                            En = "c1 - en",
                            Id = "c1 - id",
                        },
                        Slides = new[] {
                            new Slide
                            {
                                Name = new LocalizedString
                                {
                                    En = "p1 - en",
                                    Id = "p1 - id",
                                },
                                Path = "/pic1.jpg",
                                Caption = new LocalizedString
                                {
                                    En = "p1 - cap - en",
                                    Id = "p1 - cap - id",
                                },
                            }
                        },
                    },
                },
            });
        }

        [Theory]
        [InlineData("1", 123)]
        [InlineData("2", 95)]
        [InlineData("4", 51)]
        [InlineData("5", 24)]
        public void TestGetInitialSlideIndex(string chapterId, int initialSlideIndex)
        {
            var sr = new StoriesRepository();

            var isi = sr.GetInitialSlideIndex("lvista", chapterId);

            isi.Should().Be(initialSlideIndex);
        }
    }
}
