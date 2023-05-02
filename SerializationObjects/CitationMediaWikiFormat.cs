using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// MediaWiki-format result for a citation request
    /// </summary>
    public class CitationMediaWikiFormat
    {
        /// <summary>
        /// Type of item. Eg: "book"
        /// </summary>
        [JsonPropertyName("itemType")]
        public string? Type { get; set; }

        /// <summary>
        /// The date of publication. Will be in weird formats, do NOT trust that it is a proper date!
        /// </summary>
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        /// <summary>
        /// Name of publisher
        /// </summary>
        [JsonPropertyName("publisher")]
        public string? PublisherName { get; set; }

        /// <summary>
        /// Title of item
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// OCLC Id
        /// </summary>
        [JsonPropertyName("oclc")]
        public string? OCLC { get; set; }

        /// <summary>
        /// URL to the artifact
        /// </summary>
        [JsonPropertyName("url")]
        public string? Uri { get; set; }

        /// <summary>
        /// All applicable ISBN numbers for this item
        /// </summary>
        [JsonPropertyName("ISBN")]
        public List<string>? Isbn { get; set; }

        /// <summary>
        /// Name of matching edition
        /// </summary>
        [JsonPropertyName("edition")]
        public string? EditionName { get; set; }

        /// <summary>
        /// Place of publication
        /// </summary>
        [JsonPropertyName("place")]
        public string? PlaceOfPublication { get; set; }

        /// <summary>
        /// Total number of pages in the publication. This is NOT a pure number! Sometimes you also get 
        /// non-PAGE stuff like "6 audio discs (7 1/2 hr.)". Be careful.
        /// </summary>
        [JsonPropertyName("numPages")]
        public string? NumberOfPages { get; set; }

        /// <summary>
        /// List of authors of the book. This is a weird format: The inner list's [0]-element is always "". 
        /// The authors names are in the inner list's [1] and in the "last, first, birth_year-death_year" format.
        /// </summary>
        [JsonPropertyName("author")]
        public List<List<string>>? Authors { get; set; }

        /// <summary>
        /// List of contributors to the book. Empty or NULL if there are no contributors other than the author(s). 
        /// This is a weird format: The inner list's [0]-element is always "". 
        /// The authors names are in the inner list's [1] and in the "last, first, birth_year-death_year" format.
        /// </summary>
        [JsonPropertyName("contributor")]
        public List<List<string>>? Contributor { get; set; }

        /// <summary>
        /// Item's abstract (plain-text)
        /// </summary>
        [JsonPropertyName("abstractNote")]
        public string? AbstractNote { get; set; }

        /// <summary>
        /// Date of last access. May be in a strange format, use carefully. When it is a date, it could be "yyyy-MM-dd"
        /// </summary>
        [JsonPropertyName("accessDate")]
        public string? LastAccessed { get; set; }

        /// <summary>
        /// Sources of data
        /// </summary>
        [JsonPropertyName("source")]
        public List<string>? Sources { get; set; }
    }

}
