using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Text;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Implements the "/page/mobile-sections*" functions. Allows fetching mobile-optimized content from 
    /// the Wikipedia.org REST endpoints
    /// </summary>
    public class MobileClient : PageClient
    {

        /// <summary>
        /// Fetch mobile-optimized data for a page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch</param>
        /// <returns>Metadata for the mobile-optimized page</returns>
        public MobileFriendlyPage? GetSections(string pageName, decimal revisionNumber = -1)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder uri = new ();
            uri.Append("page/mobile-sections/").Append(pageName.Replace(" ", "_"));
            if (revisionNumber > 0)
            {
                uri.Append(revisionNumber.ToString("N0"));
            }

            string? responseJson = GET(uri.ToString()).Result;
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<MobileFriendlyPage>(responseJson);
            }

            return null;
        }

        /// <summary>
        /// Fetch mobile-optimized data for the lead for the page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch</param>
        /// <returns>Metadata for the mobile-optimized lead for the page</returns>
        public MobileFriendlyPageLead? GetLead(string pageName, decimal revisionNumber = -1)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder uri = new ();
            uri.Append("page/mobile-sections-lead/").Append(pageName.Replace(" ", "_"));
            if (revisionNumber > 0)
            {
                uri.Append(revisionNumber.ToString("N0"));
            }

            string? responseJson = GET(uri.ToString()).Result;
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<MobileFriendlyPageLead>(responseJson);
            }

            return null;
        }

        /// <summary>
        /// Fetch mobile-optimized data for all sections except the lead for the page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch</param>
        /// <returns>Metadata for any sections except the lead for the mobile-optimized page</returns>
        public MobileFriendlyPageContent? GetNonLeadSections(string pageName, decimal revisionNumber = -1)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder uri = new();
            uri.Append("page/mobile-sections-remaining/").Append(pageName.Replace(" ", "_"));
            if (revisionNumber > 0)
            {
                uri.Append(revisionNumber.ToString("N0"));
            }

            string? responseJson = GET(uri.ToString()).Result;
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<MobileFriendlyPageContent>(responseJson);
            }

            return null;
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public MobileClient() : base() { }
    }
}
