using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Zotero-format result for a citation request
    /// </summary>
    public class CitationZoteroFormat
    {
        /// <summary>
        /// Type of item. Eg: "book"
        /// </summary>
        [JsonPropertyName("itemType")]
        public string? Type { get; set; }

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
        /// All applicable ISBN numbers for this item (comma-seperated)
        /// </summary>
        [JsonPropertyName("ISBN")]
        public string? Isbn { get; set; }

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
        /// List of creators (authors and contributors) to this work. Expect 3 keys: 
        /// "creatorType" (contributor/author), "firstName" (usually blank) and "lastName" ("last, first, birthyear-deathyear" format)
        /// </summary>
        [JsonPropertyName("creators")]
        public Dictionary<string, string>? Creators { get; set; }
    }



}
