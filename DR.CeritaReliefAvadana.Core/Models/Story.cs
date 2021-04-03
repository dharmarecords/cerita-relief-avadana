namespace DR.CeritaReliefAvadana.Core.Models
{
    using System.Collections.Generic;

    public class Story
    {
        public string Id { get; set; }

        public LocalizedString Name { get; set; }

        public LocalizedString Description { get; set; }

        public string Author { get; set; }

        public bool Enabled { get; set; }

        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
