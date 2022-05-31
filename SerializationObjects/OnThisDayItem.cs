using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// An item in the list of events for events on a historical date
    /// </summary>
    public class OnThisDayItem
    {
        /// <summary>
        /// Type of event (we populate this before returning)
        /// </summary>
        public Feed.FeedEventType Type { get; set; }

        /// <summary>
        /// Headline or statement about what/who/where the event was about.
        /// </summary>
        [JsonPropertyName("text")]
        public string? Headline { get; set; }

        /// <summary>
        /// The year the event happened in. NULL for holidays because holidays occur every year on that day.
        /// </summary>
        [JsonPropertyName("year")]
        public int? Year { get; set; }

        /// <summary>
        /// List of pages (metadata) that reference or provide more detail or forms "next reading" material 
        /// for this event
        /// </summary>
        [JsonPropertyName("pages")]
        public List<PageMetadata>? Pages { get; set; }
    }
}