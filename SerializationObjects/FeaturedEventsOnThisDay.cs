using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Featured events on a given day
    /// </summary>
    public class FeaturedEventsOnThisDay
    {
        /// <summary>
        /// Featured article of the day
        /// </summary>
        [JsonPropertyName("tfa")]
        public PageMetadata? TodaysFeaturedArticle { get; set; }

        /// <summary>
        /// The most read articles on this day
        /// </summary>
        [JsonPropertyName("mostread")]
        public OnThisDayMostReadArticles? MostReadArticles { get; set; }

        /// <summary>
        /// Image of the day
        /// </summary>
        [JsonPropertyName("image")]
        public OnThisDayImage? ImageOfTheDay { get; set; }

        /// <summary>
        /// Articles on this day
        /// </summary>
        [JsonPropertyName("onthisday")]
        public List<OnThisDayItem>? OnThisDay { get; set; }
    }
}