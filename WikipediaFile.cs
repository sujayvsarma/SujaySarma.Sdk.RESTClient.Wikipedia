namespace SujaySarma.Sdk.WikipediaApi
{
    /// <summary>
    /// Information about a downloadable artifact
    /// </summary>
    public class WikipediaFile
    {
        /// <summary>
        /// Content Type
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// Length of the available content
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Reference to the stream that can be used to download the content.
        /// </summary>
        public System.IO.Stream? Stream { get; set; }
    }
}
