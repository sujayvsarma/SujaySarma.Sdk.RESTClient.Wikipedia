using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Information about a mobile-optimized Wikipedia page with both Lead and sectional content
    /// </summary>
    public class MobileFriendlyPage
    {
        /// <summary>
        /// Lead for the mobile page
        /// </summary>
        [JsonPropertyName("lead")]
        public MobileFriendlyPageLead? Lead { get; set; }

        /// <summary>
        /// Remaining sections
        /// </summary>
        [JsonPropertyName("remaining")]
        public MobileFriendlyPageContent? RemainingSections { get; set; }
    }
}
