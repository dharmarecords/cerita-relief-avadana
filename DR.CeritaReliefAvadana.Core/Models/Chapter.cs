namespace DR.CeritaReliefAvadana.Core.Models
{
    using System.Collections.Generic;

    public class Chapter
    {
        public string Id { get; set; }

        public LocalizedString Name { get; set; }

        public IEnumerable<Slide> Slides { get; set; }
    }
}
