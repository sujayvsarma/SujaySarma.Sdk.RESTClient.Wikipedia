using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// The table of contents on the Wiki page
    /// </summary>
    public class PageMetadataTableOfContents
    {
        /// <summary>
        /// The title text on the contents section (typically "Contents")
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The list of entries in this TOC
        /// </summary>
        [JsonPropertyName("entries")]
        public List<PageMetadataTableOfContentsEntry>? Entries { get; set; }
    }
}