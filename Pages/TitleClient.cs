using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Implements the "/page/{title}" endpoint. All methods require the page title (eg: "Hello_world") as their 
    /// first parameter. This class allows you to search and query pages. Use the methods in PageHtmlClient to 
    /// modify the page.
    /// </summary>
    public class TitleClient : PageClient
    {

        /// <summary>
        /// Gets the metadata for a specific page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionId">If a specific revision of the page is required, the revision ID. Set to zero or negative to bring latest revision.</param>
        /// <returns>The metadata for the page as returned by the service. No modifications are done. CALLER MUST CHECK FOR NULL!</returns>
        public PageMetadataBasic? GetPageMetadata(string pageName, decimal revisionId = -1)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                // the actual endpoint actually returns stuff, but that behavior does not "mean" anything
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder urlBuilder = new ();
            urlBuilder.Append(ENDPOINT_BASE_URI)
                            .Append("/page/")
                                .Append(pageName.Replace(" ", "_"));

            if (revisionId > 0)
            {
                urlBuilder.Append('/').Append(revisionId.ToString("N0"));
            }

            string? resultData = GET(urlBuilder.ToString()).Result;
            if (!string.IsNullOrWhiteSpace(resultData))
            {
                PageMetadataBasic? result = JsonSerializer.Deserialize<PageMetadataBasic>(

                        // the results are returned as a wasteful single-element array enclosed in an "{ items [ ] }" container. 
                        // get rid of this string and only parse what it contains.
                        resultData.Replace("{\"items\":[", "").Replace("]}", "")

                    );

                return result;
            }

            return null;
        }

        /// <summary>
        /// Gets the page summary for a single page related to the provided page name (title)
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <returns>Page metadata. Will be NULL if nothing was found.</returns>
        public PageMetadata? GetPageSummary(string pageName)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                // the actual endpoint actually returns stuff, but that behavior does not "mean" anything
                throw new ArgumentNullException(nameof(pageName));
            }

            string? resultData = GET($"page/summary/{pageName.Replace(" ", "_")}", new Dictionary<string, string>() { { "redirect", "true" } })
                                    .Result;
            if (!string.IsNullOrWhiteSpace(resultData))
            {
                return JsonSerializer.Deserialize<PageMetadata>(resultData);
            }

            return null;
        }

        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public TitleClient() : base() { }
    }
}
