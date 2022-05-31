using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// List of Wiki pages service endpoints
    /// </summary>
    public class PagesListResult
    {
        [JsonPropertyName("items")]
        public List<string>? Items { get; set; }
    }
}
