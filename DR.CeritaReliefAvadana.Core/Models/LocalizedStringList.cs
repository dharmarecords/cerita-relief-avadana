namespace DR.CeritaReliefAvadana.Core.Models
{
    using System.Diagnostics.CodeAnalysis;

    public class LocalizedStringList
    {
        [SuppressMessage("Microsoft.Performance", "CA1819:Properties should not return arrays", Scope = "Property", MessageId = "0", Justification = "Legit suppression as it is part of DTO.")]
        public string[] Id { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:Properties should not return arrays", Scope = "Property", MessageId = "0", Justification = "Legit suppression as it is part of DTO.")]
        public string[] En { get; set; }
    }
}
