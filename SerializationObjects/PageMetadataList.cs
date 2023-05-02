using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Metadata about Wiki pages
    /// </summary>
    public class PageMetadataList
    {
        /// <summary>
        /// List of page information data
        /// </summary>
        [JsonPropertyName("pages")]
        public List<PageMetadata>? Pages { get; set; }
    }
}
