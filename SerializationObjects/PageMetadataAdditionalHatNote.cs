using System.Text.Json.Serialization;


namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// A "hat note" is a note (typically with a link) that appear under a heading on a Wiki page. 
    /// An example is a "See also" (a link to a larger article when an "extract" is placed physically in a different page).
    /// </summary>
    public class PageMetadataAdditionalHatNote
    {
        /// <summary>
        /// Id of the section it appears in
        /// </summary>
        [JsonPropertyName("section")]
        public int SectionId { get; set; }

        /// <summary>
        /// Html of the hat note. Typically a blurb text + an A-HREF link.
        /// </summary>
        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }
}