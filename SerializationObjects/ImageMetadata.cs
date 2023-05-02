using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Information about a picture used on a wiki page
    /// </summary>
    public class ImageMetadata
    {
        /// <summary>
        /// URI to the image
        /// </summary>
        [JsonPropertyName("source")]
        public string? ImageURI { get; set; }

        /// <summary>
        /// Actual width of the image in pixels
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        /// Actual height of the image in pixels
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        /// Content type (mime)
        /// </summary>
        [JsonPropertyName("mime")]
        public string? ContentType { get; set; }
    }
}
