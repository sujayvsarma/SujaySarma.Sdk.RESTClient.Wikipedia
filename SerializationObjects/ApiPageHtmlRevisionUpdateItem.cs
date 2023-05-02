using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Internal data structure used in <see cref="Pages.HtmlClient.AddPageRevisionHtmlAsync(string, string, string, bool)"/>
    /// </summary>
    internal class ApiPageHtmlRevisionUpdateItem
    {
        /// <summary>
        /// Cross site request anti-forgery token
        /// </summary>
        [JsonPropertyName("csrf_token")]
        public string? CrossSiteAntiForgeryToken { get; set; }

        /// <summary>
        /// Base e-tag, only used to update an older revision (not supported). We always set this to empty string.
        /// </summary>
        [JsonPropertyName("base_etag")]
        public string? BaseEtag { get; set; }

        /// <summary>
        /// The content Html
        /// </summary>
        [JsonPropertyName("html")]
        public string? ContentHtml { get; set; }

        /// <summary>
        /// Comments to use to commit changes
        /// </summary>
        [JsonPropertyName("comment")]
        public string? CommitComments { get; set; }

        /// <summary>
        /// Flag indicating if it is a minor or major edit
        /// </summary>
        [JsonPropertyName("is_minor")]
        public bool IsMinorEdit { get; set; }

        /// <summary>
        /// Flag indicating if the user is authenticated (we always set this to true)
        /// </summary>
        [JsonPropertyName("is_bot")]
        public bool IsBotUser { get; set; }
    }
}
