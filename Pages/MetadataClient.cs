using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Text;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Gets metadata about a page
    /// </summary>
    public class MetadataClient : PageClient
    {

        /// <summary>
        /// Fetch additional metadata the provided page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch</param>
        /// <returns>Additional metadata about the page (more than what is provided by <see cref="PageTitleClient.GetPageMetadata(string, int?)"/>). Can be NULL.</returns>
        public PageAdditionalMetadata? GetAdditionalMetadata(string pageName, decimal revisionNumber = -1)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder uri = new ();
            uri.Append("page/metadata/").Append(pageName.Replace(" ", "_"));
            if (revisionNumber > 0)
            {
                uri.Append(revisionNumber.ToString("N0"));
            }

            string? responseJson = GET(uri.ToString()).Result;
            if (! string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<PageAdditionalMetadata>(responseJson);
            }

            return null;
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public MetadataClient() : base() { }
    }
}