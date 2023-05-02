using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Additional metadata about a Wiki page
    /// </summary>
    public class PageAdditionalMetadata
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
        /// List of hat notes that appear on the page. A "hat note" is a note (typically with a link) that appear under a heading on a Wiki page. 
        /// An example is a "See also" (a link to a larger article when an "extract" is placed physically in a different page).
        /// </summary>
        [JsonPropertyName("hatnotes")]
        public List<PageMetadataAdditionalHatNote>? HatNotes { get; set; }

        /// <summary>
        /// The TOC on the page
        /// </summary>
        [JsonPropertyName("toc")]
        public PageMetadataTableOfContents? TableOfContents { get; set; }

        /// <summary>
        /// Links for other languages (whatever was your original language, that is excluded). 
        /// Will contain fully qualified URI to the Summary REST endpoint for each language.
        /// </summary>
        [JsonPropertyName("language_links")]
        public List<PageMetadataLanguageLink>? OtherLanguages { get; set; }

        /// <summary>
        /// Categories linked to this page
        /// </summary>
        [JsonPropertyName("categories")]
        public List<PageMetadataCategory>? Categories { get; set; }

        /// <summary>
        /// Seems to be always empty object
        /// </summary>
        [JsonPropertyName("protection")]
        public object? Protection { get; set; }

        /// <summary>
        /// Source of description (some internal value)
        /// </summary>
        [JsonPropertyName("description_source")]
        public string? DescriptionSource { get; set; } = "central";
    }
}