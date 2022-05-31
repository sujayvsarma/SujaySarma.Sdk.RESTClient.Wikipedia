using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Remaining sections on a mobile page
    /// </summary>
    public class MobileFriendlyPageContent
    {
        /// <summary>
        /// List of sections
        /// </summary>
        [JsonPropertyName("sections")]
        public List<PageMobileSection>? Sections { get; set; }
    }
}
