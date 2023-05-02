using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// The lead section of a mobile-optimized Wikipedia page content
    /// </summary>
    public class MobileFriendlyPageLead
    {
        /// <summary>
        /// Namespace Id
        /// </summary>
        [JsonPropertyName("ns")]
        public int NamespaceId { get; set; }

        /// <summary>
        /// Id of the page
        /// </summary>
        [JsonPropertyName("id")]
        public decimal PageId { get; set; }

        /// <summary>
        /// Revision Id (this is a STRING !!!)
        /// </summary>
        [JsonPropertyName("revision")]
        public string? RevisionId { get; set; }

        /// <summary>
        /// Timestamp the page was last modified
        /// </summary>
        [JsonPropertyName("lastmodified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// User that made the last modification. Expect keys: "user", "gender"
        /// </summary>
        [JsonPropertyName("lastmodifier")]
        public Dictionary<string, string>? LastModifiedBy { get; set; }

        /// <summary>
        /// User-friendly title
        /// </summary>
        [JsonPropertyName("displaytitle")]
        public string? DisplayTitle { get; set; }

        /// <summary>
        /// Normalized title
        /// </summary>
        [JsonPropertyName("normalizedtitle")]
        public string? NormalizedTitle { get; set; }

        /// <summary>
        /// Internal Id of the base item
        /// </summary>
        [JsonPropertyName("wikibase_item")]
        public string? BaseItemId { get; set; }

        /// <summary>
        /// Very brief one-line description
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// If the page is editable (some pages may be locked from editing)
        /// </summary>
        [JsonPropertyName("editable")]
        public bool IsEditable { get; set; }

        /// <summary>
        /// Number of languages this page is available in
        /// </summary>
        [JsonPropertyName("languagecount")]
        public int NumberOfTranslations { get; set; }

        /// <summary>
        /// Protection?
        /// </summary>
        [JsonPropertyName("protection")]
        public object? Protection { get; set; }

        /// <summary>
        /// Source of the description, usually "central"
        /// </summary>
        [JsonPropertyName("description_source")]
        public string? DescriptionSource { get; set; }

        /// <summary>
        /// Hero image of the lead
        /// </summary>
        [JsonPropertyName("image")]
        public PageMobileImageInfo? HeroImage { get; set; }

        /// <summary>
        /// List of Hat Notes in the lead section
        /// </summary>
        [JsonPropertyName("hatnotes")]
        public List<string>? HatNotes { get; set; }

        /// <summary>
        /// List of all sections in the page
        /// </summary>
        [JsonPropertyName("sections")]
        public List<PageMobileSection>? Sections { get; set; }
    }
}
