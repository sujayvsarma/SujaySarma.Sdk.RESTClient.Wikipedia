using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// The internal API result
    /// </summary>
    internal class ApiGetMediaItemsResult
    {
        [JsonPropertyName("revision")]
        public string? RevisionId { get; set; }

        /// <summary>
        /// Revision Time Id
        /// </summary>
        [JsonPropertyName("tid")]
        public string? RevisionTimeId { get; set; }

        /// <summary>
        /// The resultant items
        /// </summary>
        [JsonPropertyName("items")]
        public List<MediaAttachment>? Items { get; set; }
    }
}
