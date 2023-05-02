using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Fetches media-related information for a Wikipedia page
    /// </summary>
    public class MediaClient : PageClient
    {

        /// <summary>
        /// Fetch metadata about all the media items (images, video, audio) embedded in the provided page
        /// </summary>
        /// <param name="pageName">Exact title for the page (spaces will be converted to underscores '_' by the function)</param>
        /// <param name="revisionNumber">The revision Id of the version to fetch</param>
        /// <returns>List of media metadata. Will never be NULL, but can be Empty.</returns>
        public List<MediaAttachment> GetMediaAttachments(string pageName, decimal revisionNumber = -1)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            StringBuilder uri = new ();
            uri.Append("page/media/").Append(pageName.Replace(" ", "_"));
            if (revisionNumber > 0)
            {
                uri.Append(revisionNumber.ToString("N0"));
            }

            string? responseJson = GET(uri.ToString(), new Dictionary<string, string>() { { "redirect", "true" } }).Result;
            List<MediaAttachment>? results = null;
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                results = JsonSerializer.Deserialize<ApiGetMediaItemsResult>(responseJson)?.Items;
            }

            return results ?? new List<MediaAttachment>();
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public MediaClient() : base() { }
    }
}
