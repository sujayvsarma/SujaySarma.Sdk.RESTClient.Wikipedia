using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Information about audio or video sources listed in <see cref="MediaAttachment"/> structure
    /// </summary>
    public class MediaAVSourcesMetadata
    {
        /// <summary>
        /// Url to the image
        /// </summary>
        [JsonPropertyName("url")]
        public string? Uri { get; set; }

        /// <summary>
        /// Content type for item
        /// </summary>
        [JsonPropertyName("mime")]
        public string? ContentType { get; set; }

        /// <summary>
        /// List of codecs to use to decode the multimedia content
        /// </summary>
        [JsonPropertyName("codecs")]
        public List<string>? Codecs { get; set; }

        /// <summary>
        /// User-displayble name for the item
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Some sort of a short-name for the item, may not make sense to show this?
        /// </summary>
        [JsonPropertyName("short_name")]
        public string? ShortName { get; set; }

        /// <summary>
        /// Width in pixels (this is a STRING!)
        /// </summary>
        [JsonPropertyName("width")]
        public string? Width { get; set; }

        /// <summary>
        /// Height in pixels (this is a STRING!)
        /// </summary>
        [JsonPropertyName("height")]
        public string? Height { get; set; }
    }

}
