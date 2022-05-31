using System;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Article traffic by date
    /// </summary>
    public class ViewsByDate
    {
        /// <summary>
        /// Date of traffic (ignore the timepart)
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Number of views on the date
        /// </summary>
        [JsonPropertyName("views")]
        public long NumberOfViews { get; set; }
    }
}