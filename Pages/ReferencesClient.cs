using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Text;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Implements the "/page/references" endpoint. Methods provide means to query the 
    /// citations, references and notes listed on a Wikipedia.org page.
    /// </summary>
    public class ReferencesClient : PageClient
    {
        /// <summary>
        /// Get the references, citations and notes listed on a Wikipedia page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch</param>
        /// <returns>Metadata about the references</returns>
        public PageReferencesList? GetPageReferences(string pageName, decimal revisionNumber)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder uri = new ();
            uri.Append("page/references/").Append(pageName.Replace(" ", "_"));
            if (revisionNumber > 0)
            {
                uri.Append(revisionNumber.ToString("N0"));
            }

            string? responseJson = GET(uri.ToString()).Result;
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<PageReferencesList>(responseJson);
            }

            return null;
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public ReferencesClient() : base() { }
    }
}