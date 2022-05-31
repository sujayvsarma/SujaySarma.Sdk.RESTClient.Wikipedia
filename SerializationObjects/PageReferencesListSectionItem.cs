using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// An element in <see cref="PageReferencesList.Lists"/>
    /// </summary>
    public class PageReferencesListSectionItem
    {
        /// <summary>
        /// An ID for the section
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Heading for the section. Expect 2 keys: "id" (is the bookmark 'name' for the section) and "html" (text to show)
        /// </summary>
        [JsonPropertyName("section_heading")]
        public Dictionary<string, string>? Heading { get; set; }

        /// <summary>
        /// The order in which the items in the section should appear.
        /// </summary>
        [JsonPropertyName("order")]
        public List<string>? Order { get; set; }

    }
}
