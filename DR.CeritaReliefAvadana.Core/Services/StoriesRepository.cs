namespace DR.CeritaReliefAvadana.Core.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using DR.CeritaReliefAvadana.Core.Models;

    public class StoriesRepository : IStoriesRepository
    {
        private IEnumerable<Story> _stories = Enumerable.Empty<Story>();

        public IEnumerable<Story> GetStories()
        {
            LoadStories();

            return _stories;
        }

        public IEnumerable<Chapter> GetChapters(string storyId)
        {
            return GetStories()
                .Where(s => s.Id == storyId)
                .SelectMany(s => s.Chapters);
        }

        public IEnumerable<Slide> GetSlides(string storyId, string chapterId)
        {
            return GetChapters(storyId)
                .Where(c => c.Id == chapterId)
                .SelectMany(s => s.Slides);
        }

        public int GetInitialSlideIndex(string storyId, string chapterId)
        {
            var chapters = GetChapters(storyId).Reverse().TakeWhile(c => c.Id != chapterId);
            return chapters.SelectMany(c => c.Slides).Count()
                + chapters.Count()
                + GetSlides(storyId, chapterId).Count()
                - 2;
        }

        private void LoadStories()
        {
            if (_stories.Any())
            {
                return;
            }

            var opt = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var stream = typeof(StoriesRepository).Assembly.GetManifestResourceStream($"{typeof(StoriesRepository).Namespace}.StoriesRepository.json");
            using var reader = new StreamReader(stream);

            _stories = JsonSerializer.Deserialize<Story[]>(reader.ReadToEnd(), opt);
        }
    }
}
