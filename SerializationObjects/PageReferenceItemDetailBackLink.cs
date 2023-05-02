using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// An item in the <see cref="PageReferenceItemDetail.BackLinks"/>
    /// </summary>
    public class PageReferenceItemDetailBackLink
    {
        /// <summary>
        /// Relative URI to the item in the HTML page. Only meant to be used in an A-HREF link!
        /// </summary>
        [JsonPropertyName("href")]
        public string? Uri { get; set; }

        /// <summary>
        /// The text to display
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
