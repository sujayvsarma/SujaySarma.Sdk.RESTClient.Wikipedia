using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Events on a historical date
    /// </summary>
    public class EventsOnThisDay
    {
        /// <summary>
        /// List of selected events
        /// </summary>
        [JsonPropertyName("selected")]
        public List<OnThisDayItem>? SelectedEvents { get; set; }

        /// <summary>
        /// List of birthdays
        /// </summary>
        [JsonPropertyName("births")]
        public List<OnThisDayItem>? Births { get; set; }

        /// <summary>
        /// List of deaths
        /// </summary>
        [JsonPropertyName("deaths")]
        public List<OnThisDayItem>? Deaths { get; set; }

        /// <summary>
        /// List of fixed holidays
        /// </summary>
        [JsonPropertyName("holidays")]
        public List<OnThisDayItem>? Holidays { get; set; }

        /// <summary>
        /// List of other types of events
        /// </summary>
        [JsonPropertyName("events")]
        public List<OnThisDayItem>? OtherEvents { get; set; }

    }
}