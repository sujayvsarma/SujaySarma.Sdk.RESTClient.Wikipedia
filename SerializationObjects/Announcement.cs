
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Announcements from Wikipedia.org
    /// </summary>
    /// <remarks>
    /// This class was created using example schema from here: https://en.wikipedia.org/api/rest_v1/#/Feed/get_feed_announcements. 
    /// There were no announcements to actually retrieve at the time. Therefore the class may have errors.
    /// </remarks>
    public class Announcement
    {
        /// <summary>
        /// An Id for the announcement
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Type of announcement
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Start of period of the event/announced
        /// </summary>
        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End of period of the event/announced
        /// </summary>
        [JsonPropertyName("end_time")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// List of platforms this announcement affects
        /// </summary>
        [JsonPropertyName("platforms")]
        public List<string>? Platforms { get; set; }

        /// <summary>
        /// Announcement text
        /// </summary>
        [JsonPropertyName("text")]
        public string? Content { get; set; }

        /// <summary>
        /// Absolute URI to the image for the announcement (only if there is an image, else NULL)
        /// </summary>
        [JsonPropertyName("image")]
        public string? ImageUri { get; set; }

        /// <summary>
        /// Call to action - expect 2 keys: "title" (display caption) and "url" (url to take the action)
        /// </summary>
        [JsonPropertyName("action")]
        public Dictionary<string, string>? Action { get; set; }

        /// <summary>
        /// Html caption for the announcement
        /// </summary>
        [JsonPropertyName("caption_HTML")]
        public string? CaptionHtml { get; set; }

        /// <summary>
        /// Countries this announcement is applicable to. If empty, then it is applicable to all countries
        /// </summary>
        [JsonPropertyName("countries")]
        public List<string>? Countries { get; set; }
    }

    
}