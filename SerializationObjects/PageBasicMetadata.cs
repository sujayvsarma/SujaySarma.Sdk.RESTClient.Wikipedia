using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Basic metadata for a Wiki page
    /// </summary>
    public class PageMetadataBasic
    {
        /// <summary>
        /// Page title
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Numeric page ID
        /// </summary>
        [JsonPropertyName("page_id")]
        public double PageId { get; set; }

        /// <summary>
        /// Page revision ID
        /// </summary>
        [JsonPropertyName("rev")]
        public double Revision { get; set; }

        /// <summary>
        /// Revision Time Id
        /// </summary>
        [JsonPropertyName("tid")]
        public string? RevisionTimeId { get; set; }

        /// <summary>
        /// Namespace ID
        /// </summary>
        [JsonPropertyName("namespace")]
        public double Namespace { get; set; }

        /// <summary>
        /// ID of the user that created or last edited this page
        /// </summary>
        [JsonPropertyName("user_id")]
        public double UserId { get; set; }

        /// <summary>
        /// Username of the user that created or last edited this page
        /// </summary>
        [JsonPropertyName("user_text")]
        public string? UserName { get; set; }

        /// <summary>
        /// Datetime this page was last modified
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Comment about the content
        /// </summary>
        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        /// <summary>
        /// Tags attached to this page
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        /// <summary>
        /// Restrictions placed on this page
        /// </summary>
        [JsonPropertyName("restrictions")]
        public List<string>? Restrictions { get; set; }

        /// <summary>
        /// Language of the page
        /// </summary>
        [JsonPropertyName("page_language")]
        public string? Language { get; set; }

        /// <summary>
        /// If this is a redirect
        /// </summary>
        [JsonPropertyName("redirect")]
        public string? Redirect { get; set; }
    }
}
