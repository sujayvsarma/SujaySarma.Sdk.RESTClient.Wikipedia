using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// List of references used on a Wiki page
    /// </summary>
    public class PageReferencesList
    {

        /// <summary>
        /// Revision number (of the original page)
        /// </summary>
        [JsonPropertyName("revision")]
        public string? RevisionId { get; set; }

        /// <summary>
        /// Time Id
        /// </summary>
        [JsonPropertyName("tid")]
        public string? RevisionTimeId { get; set; }

        /// <summary>
        /// The types of reference sections available for the page
        /// </summary>
        [JsonPropertyName("reference_lists")]
        public List<PageReferencesListSectionItem>? Lists { get; set; }

        /// <summary>
        /// The actual reference items. The Key is the <see cref="PageReferencesListSectionItem.Id"/> value.
        /// </summary>
        [JsonPropertyName("references_by_id")]
        public Dictionary<string, PageReferenceItemDetail>? Items { get; set; }
    }
}
