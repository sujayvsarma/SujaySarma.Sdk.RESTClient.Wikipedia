using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// A section of a mobile-optimized Wikipedia page content
    /// </summary>
    public class PageMobileSection
    {
        /// <summary>
        /// Id of the section, 1-based
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Html content of the section
        /// </summary>
        [JsonPropertyName("text")]
        public string? Html { get; set; }

        /// <summary>
        /// Table of contents item this section maps to
        /// </summary>
        [JsonPropertyName("toclevel")]
        public int TocLevel { get; set; }

        /// <summary>
        /// Caption text for the section link or title
        /// </summary>
        [JsonPropertyName("line")]
        public string? Caption { get; set; }

        /// <summary>
        /// Name of the anchor-name for this section
        /// </summary>
        [JsonPropertyName("anchor")]
        public string? AnchorName { get; set; }
    }
}
