using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Articles viewed on a particular date
    /// </summary>
    public class OnThisDayViewedArticle
    {
        /// <summary>
        /// Number of views of this page
        /// </summary>
        [JsonPropertyName("views")]
        public long NumberOfViews { get; set; }

        /// <summary>
        /// Rank of article
        /// </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Views by date
        /// </summary>
        [JsonPropertyName("view_history")]
        public List<ViewsByDate>? ViewsByDate { get; set; }

        /// <summary>
        /// Numeric ID of the page
        /// </summary>
        [JsonPropertyName("pageid")]
        public decimal Id { get; set; }

        /// <summary>
        /// Type of result
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// The page name (that can be used with functions like <see cref="WikipediaClient.GetPageMetadata(string, int?)"/>).
        /// </summary>
        [JsonPropertyName("title")]
        public string? PageName { get; set; }

        /// <summary>
        /// The user-friendly title for the page
        /// </summary>
        [JsonPropertyName("displaytitle")]
        public string? DisplayTitle { get; set; }

        /// <summary>
        /// Namespace key/value pairs (expect 2 keys: "id" with an int value, and "text" with a string value)
        /// </summary>
        [JsonPropertyName("namespace")]
        public Dictionary<string, object>? Namespace { get; set; }

        /// <summary>
        /// An internal ID of the type of base wiki item this belongs to
        /// </summary>
        [JsonPropertyName("wikibase_item")]
        public string? WikiBaseItemID { get; set; }

        /// <summary>
        /// Other forms of the <see cref="DisplayTitle"/>. Expect 3 keys: "canonical", "normalized" and "display".
        /// </summary>
        [JsonPropertyName("titles")]
        public Dictionary<string, string>? Titles { get; set; }

        /// <summary>
        /// Page thumbnail if any
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public ImageMetadata? Thumbnail { get; set; }

        /// <summary>
        /// The fullsized page image
        /// </summary>
        [JsonPropertyName("originalimage")]
        public ImageMetadata? FullsizePageImage { get; set; }

        /// <summary>
        /// 2-letter ISO language code
        /// </summary>
        [JsonPropertyName("lang")]
        public string? Language { get; set; }

        /// <summary>
        /// 3-letter direction code: ltr or rtr
        /// </summary>
        [JsonPropertyName("dir")]
        public string? Direction { get; set; }

        /// <summary>
        /// ID of the last revision performed on this page (strange, this is a string here!)
        /// </summary>
        [JsonPropertyName("revision")]
        public string? LastRevisionID { get; set; }

        /// <summary>
        /// Revision Time Id
        /// </summary>
        [JsonPropertyName("tid")]
        public string? RevisionTimeId { get; set; }

        /// <summary>
        /// Date/time when the page was last modified
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// A short description (that appears under the primary title) for the page
        /// </summary>
        [JsonPropertyName("description")]
        public string? Blurb { get; set; }

        /// <summary>
        /// Will contain one or more keys: "desktop", "mobile". Each key will give you a dictionary. Those will have links to 
        /// "page", "revisions", "edit" and talk" URI for this particular page.
        /// </summary>
        [JsonPropertyName("content_urls")]
        public Dictionary<string, Dictionary<string, string>>? ContentURI { get; set; }

        /// <summary>
        /// Fully qualified URI to other Wikipedia API endpoints for this page. Expected keys are: 
        /// "summary", "metadata", "references", "media", "edit_html" and "talk_page_html"
        /// </summary>
        [JsonPropertyName("api_urls")]
        public Dictionary<string, string>? APIRelatedURI { get; set; }

        /// <summary>
        /// Extract from the page, in plain-text
        /// </summary>
        [JsonPropertyName("extract")]
        public string? ExtractPlainText { get; set; }

        /// <summary>
        /// Extract from the page, in HTML
        /// </summary>
        [JsonPropertyName("extract_html")]
        public string? ExtractHtml { get; set; }

        /// <summary>
        /// Normalized page title
        /// </summary>
        [JsonPropertyName("normalizedtitle")]
        public string? NormalizedPageTitle { get; set; }

    }
}