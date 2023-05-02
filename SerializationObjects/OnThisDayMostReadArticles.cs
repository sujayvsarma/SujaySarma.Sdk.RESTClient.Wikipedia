using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Most read articles on a given day
    /// </summary>
    public class OnThisDayMostReadArticles
    {
        /// <summary>
        /// The same as the query date
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// List of articles
        /// </summary>
        [JsonPropertyName("articles")]
        public List<OnThisDayViewedArticle>? Articles { get; set; }
    }
}