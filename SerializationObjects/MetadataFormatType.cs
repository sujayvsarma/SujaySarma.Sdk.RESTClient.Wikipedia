namespace SujaySarma.Sdk.WikipediaApi.SerializationObjects
{
    /// <summary>
    /// Type of metadata
    /// </summary>
    public enum MetadataFormatType
    {
        /// <summary>
        /// Basic metadata
        /// </summary>
        Title, 

        /// <summary>
        /// Html content for the page
        /// </summary>
        Html, 

        /// <summary>
        /// Detailed page metadata
        /// </summary>
        Summary, 

        /// <summary>
        /// Related pages for the topic
        /// </summary>
        Related,

        /// <summary>
        /// All the sections for the mobile page
        /// </summary>
        Mobile_Sections, 

        /// <summary>
        /// Only the lead section for the mobile page
        /// </summary>
        Mobile_Sections_Lead
    }
}
