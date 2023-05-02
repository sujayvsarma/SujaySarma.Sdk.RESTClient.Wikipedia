using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Information about an image on the page
    /// </summary>
    public class PageMobileImageInfo
    {
        /// <summary>
        /// Name of the file
        /// </summary>
        [JsonPropertyName("file")]
        public string? FileName { get; set; }

        /// <summary>
        /// Size-based URLs for the images. Typical keys are: "320", "640", "800" and "1024"
        /// </summary>
        [JsonPropertyName("urls")]
        public Dictionary<string, string>? SizeUrls { get; set; }
    }
}
