using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Category item for <see cref="PageAdditionalMetadata"/>
    /// </summary>
    public class PageMetadataCategory
    {
        /// <summary>
        /// Id of the namespace for this item
        /// </summary>
        [JsonPropertyName("ns")]
        public int NamespaceId { get; set; }

        /// <summary>
        /// If the category should be hidden from "display"
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool IsHidden { get; set; }

        /// <summary>
        /// Absolute Uri to the Summary REST endpoint for this category
        /// </summary>
        [JsonPropertyName("summary_url")]
        public string? SummaryEndpoint { get; set; }

        /// <summary>
        /// Titles for this category. Expect 3 keys: "canonical", "normalized" and "display".
        /// </summary>
        [JsonPropertyName("titles")]
        public Dictionary<string, string>? Titles { get; set; }
    }
}