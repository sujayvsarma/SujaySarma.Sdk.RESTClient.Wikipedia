using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// An entry in a <see cref="PageMetadataTableOfContents"/>
    /// </summary>
    public class PageMetadataTableOfContentsEntry
    {
        /// <summary>
        /// The level in the TOC list this pertains to (seems to be 1-based !!!)
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// The section Id of the section this item links to
        /// </summary>
        [JsonPropertyName("section")]
        public int Section { get; set; }

        /// <summary>
        /// The bullet name (the numering that appears in the bulletted contents list), eg "2.1"
        /// </summary>
        [JsonPropertyName("number")]
        public string? BulletText { get; set; }

        /// <summary>
        /// Name of the bookmark created on the page that this item links to
        /// </summary>
        [JsonPropertyName("anchor")]
        public string? BookmarkName { get; set; }

        /// <summary>
        /// The text to show as the content entry item
        /// </summary>
        [JsonPropertyName("html")]
        public string? Caption { get; set; }
    }
}