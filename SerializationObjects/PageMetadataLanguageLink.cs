using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Language links in <see cref="PageAdditionalMetadata"/>
    /// </summary>
    public class PageMetadataLanguageLink
    {
        /// <summary>
        /// 2-letter language code ("en")
        /// </summary>
        [JsonPropertyName("lang")]
        public string? LanguageCode { get; set; }

        /// <summary>
        /// Fully qualified REST endpoint for fetching the summary data for the page in this language
        /// </summary>
        [JsonPropertyName("summary_url")]
        public string? SummaryEndpoint { get; set; }

        /// <summary>
        /// Titles. Expect two keys: "canonical" and "normalized"
        /// </summary>
        [JsonPropertyName("titles")]
        public Dictionary<string, string>? Titles { get; set; }

    }
}