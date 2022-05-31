using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// A featured image of the day
    /// </summary>
    public class OnThisDayImage
    {
        /// <summary>
        /// Image title
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Image thumbnail
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public ImageMetadata? Thumbnail { get; set; }

        /// <summary>
        /// The image
        /// </summary>
        [JsonPropertyName("image")]
        public ImageMetadata? Image { get; set; }

        /// <summary>
        /// Absolute URI to the file-page for this image
        /// </summary>
        [JsonPropertyName("file_page")]
        public string? FilePage { get; set; }

        /// <summary>
        /// Name(s) of the artist. Expect 2 keys: "html" (containing Html content) and "text" (containing the plain-text caption)
        /// </summary>
        [JsonPropertyName("artist")]
        public Dictionary<string, string>? Artist { get; set; }

        /// <summary>
        /// Credits/copyright info. Expect 2 keys: "html" (containing Html content) and "text" (containing the plain-text caption)
        /// </summary>
        [JsonPropertyName("credit")]
        public Dictionary<string, string>? Credits { get; set; }

        /// <summary>
        /// License information. Expect 3 keys: "type" (type of license), "code" (license code name) and "url" (absolute URI to license name - no "http(s)://" prefix!)
        /// </summary>
        [JsonPropertyName("license")]
        public Dictionary<string, string>? License { get; set; }

        /// <summary>
        /// Description. Expect 3 keys: "html" (containing Html content), "text" (containing the plain-text caption) and "lang" (2 letter language code)
        /// </summary>
        [JsonPropertyName("description")]
        public Dictionary<string, string>? Description { get; set; }

        /// <summary>
        /// WB Entity ID (???) - usually populated only for video
        /// </summary>
        [JsonPropertyName("wb_entity_id")]
        public string? WbEntityId { get; set; }

        /// <summary>
        /// Structured information - mostly empty?
        /// </summary>
        [JsonPropertyName("structured")]
        public Dictionary<string, object>? Structured { get; set; }
    }
}