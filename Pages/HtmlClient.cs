using SujaySarma.Sdk.RestApi;
using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Implements the "/page/html/{title}" endpoint. All methods require the page title (eg: "Hello_world") as their 
    /// first parameter. This class allows you to search, query and modify pages.
    /// </summary>
    public class HtmlClient : WikipediaClient
    {
        /// <summary>
        /// Gets the Html content for a specific page for a specific revision/version
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch the Html for (set zero or negative numbers to fetch latest version)</param>
        /// <param name="mobileOptimized">If set, gets the mobile-optimized Html</param>
        /// <param name="willEditAfterRead">If set, prepares Wikipedia to allow you to save a revision of the page.</param>
        /// <returns>The current Html content for the page -- this is the FULL Html and (if user-displayed) for display on a page on its own, or in an iframe. CALLER MUST CHECK FOR NULL!</returns>
        /// <remarks>
        ///     if <paramref name="willEditAfterRead"/> is TRUE, requests will be rate-limited to 5 requests/client (details unknown)
        /// </remarks>
        public string? GetHtml(string pageName, decimal revisionNumber = -1, bool mobileOptimized = false, bool willEditAfterRead = false)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                // the actual endpoint actually returns stuff, but that behavior does not "mean" anything
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder urlBuilder = new ();
            urlBuilder.Append(ENDPOINT_BASE_URI)
                            .Append("/page/")
                                .Append((mobileOptimized ? "mobile-html/" : "html/"))
                                    .Append(pageName.Replace(" ", "_"));

            if (revisionNumber > 0)
            {
                urlBuilder.Append('/').Append(revisionNumber.ToString("N0"));
            }

            Dictionary<string, string> parameters = new ()
            {
                { "redirect", "true" }
            };

            if (willEditAfterRead)
            {
                parameters.Add("stash", "true");
            }

            return GET(urlBuilder.ToString(), parameters).Result;
        }

        /// <summary>
        /// Adds a page revision using Html-format content
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="contentHtml">New content (full content) for the page in Html format</param>
        /// <param name="editComments">Comments to be used to commit the edits</param>
        /// <param name="isMinorRevision">If true, adds a minor version to the page, otherwise increments the major version (major versions may require approvals before being public)</param>
        /// <returns>Must return "Content Unmodified" or "Accepted". Anything else is an error.</returns>
        public async Task<string> AddPageRevisionHtmlAsync(string pageName, string contentHtml, string editComments, bool isMinorRevision = true)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            if (string.IsNullOrWhiteSpace(contentHtml))
            {
                throw new ArgumentNullException(nameof(contentHtml));
            }

            if (string.IsNullOrWhiteSpace(editComments))
            {
                throw new ArgumentNullException(nameof(editComments));
            }

            StringBuilder uri = new ();
            uri.Append(ENDPOINT_BASE_URI).Append("/page/html/").Append(pageName.Replace(" ", "_"));

            ApiPageHtmlRevisionUpdateItem updateItem = new ()
            {
                CrossSiteAntiForgeryToken = Guid.NewGuid().ToString("d"),
                BaseEtag = string.Empty,
                CommitComments = editComments,
                ContentHtml = contentHtml,
                IsBotUser = true,
                IsMinorEdit = isMinorRevision
            };

            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri(uri.ToString()))
                .WithHeader("Accept", "application/json")
                .WithBody(JsonSerializer.Serialize(updateItem), "multipart/form-data");

            HttpResponseMessage? responseMessage = await client.Post();
            switch (responseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return "Content Unmodified";

                case System.Net.HttpStatusCode.Created:
                    return "Accepted";

            }

            Dictionary<string, string>? messages = JsonSerializer.Deserialize<Dictionary<string, string>>(responseMessage.Content.ReadAsStringAsync().Result);
            return (((messages != null) && (messages.ContainsKey("detail"))) ? messages["detail"] : "Unknown Error");
        }

        /// <summary>
        /// Adds a page revision using WikiText-format content
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="contentWikiText">New content (full content) for the page in WikiText format</param>
        /// <param name="editComments">Comments to be used to commit the edits</param>
        /// <param name="isMinorRevision">If true, adds a minor version to the page, otherwise increments the major version (major versions may require approvals before being public)</param>
        /// <returns>Must return "Content Unmodified" or "Accepted". Anything else is an error.</returns>
        public async Task<string> AddPageRevisionWikiTextAsync(string pageName, string contentWikiText, string editComments, bool isMinorRevision = true)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            if (string.IsNullOrWhiteSpace(contentWikiText))
            {
                throw new ArgumentNullException(nameof(contentWikiText));
            }

            if (string.IsNullOrWhiteSpace(editComments))
            {
                throw new ArgumentNullException(nameof(editComments));
            }

            StringBuilder uri = new ();
            uri.Append(ENDPOINT_BASE_URI).Append("/page/wikitext/").Append(pageName.Replace(" ", "_"));

            ApiPageHtmlRevisionUpdateItem updateItem = new ()
            {
                CrossSiteAntiForgeryToken = Guid.NewGuid().ToString("d"),
                BaseEtag = string.Empty,
                CommitComments = editComments,
                ContentHtml = contentWikiText,
                IsBotUser = true,
                IsMinorEdit = isMinorRevision
            };

            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri(uri.ToString()))
                .WithHeader("Accept", "application/json")
                .WithBody(JsonSerializer.Serialize(updateItem), "multipart/form-data");

            HttpResponseMessage responseMessage = await client.Post();
            switch (responseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return "Content Unmodified";

                case System.Net.HttpStatusCode.Created:
                    return "Accepted";

            }

            Dictionary<string, string>? messages = JsonSerializer.Deserialize<Dictionary<string, string>>(responseMessage.Content.ReadAsStringAsync().Result);
            return (((messages != null) && (messages.ContainsKey("detail"))) ? messages["detail"] : "Unknown Error");
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public HtmlClient() : base() { }
    }
}
