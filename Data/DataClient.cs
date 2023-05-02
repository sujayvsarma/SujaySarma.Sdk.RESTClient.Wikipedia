using SujaySarma.Sdk.RestApi;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SujaySarma.Sdk.WikipediaApi.Data
{
    /// <summary>
    /// Implements the "/data/*" endpoints
    /// </summary>
    public class DataClient : WikipediaClient
    {

        /// <summary>
        /// Gets common CSS that mobile apps need to properly display pages using Page Content Service
        /// </summary>
        /// <param name="type">Type of CSS bundle to fetch</param>
        /// <returns>DownloadableArtifact information. NULL on errors.</returns>
        public async Task<WikipediaFile?> GetCssAsync(CssType type = CssType.Base)
        {
            StringBuilder uri = new ();
            uri.Append(ENDPOINT_BASE_URI).Append("data/css/mobile/")
                    .Append(Enum.GetName(typeof(CssType), type)?.ToLower() ?? "Base");

            // Since we get a download, we cannot use the GET() method in the base.

            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri(uri.ToString()))
                .WithHeader("Accept", "text/css");

            HttpResponseMessage responseMessage = await client.Get();
            if (responseMessage.IsSuccessStatusCode)
            {
                return new WikipediaFile()
                {
                    ContentLength = responseMessage.Content.Headers.ContentLength ?? -1,
                    ContentType = responseMessage.Content.Headers.ContentType?.MediaType ?? "text/css",
                    Stream = await responseMessage.Content.ReadAsStreamAsync()
                };
            }

            return null;
        }

        /// <summary>
        /// Gets JavaScript that mobile apps need to properly display pages using Page Content Service
        /// </summary>
        /// <param name="type">Type of JavaScript bundle to fetch</param>
        /// <returns>DownloadableArtifact information. NULL on errors.</returns>
        public async Task<WikipediaFile?> GetJavaScriptAsync(JavaScriptType type = JavaScriptType.PageLib)
        {
            StringBuilder uri = new();
            uri.Append(ENDPOINT_BASE_URI).Append("data/javascript/mobile/")
                    .Append(Enum.GetName(typeof(JavaScriptType), type)?.ToLower() ?? "PageLib");

            // Since we get a download, we cannot use the GET() method in the base.
            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri(uri.ToString()))
                .WithHeader("Accept", "text/javascript");

            HttpResponseMessage responseMessage = await client.Get();
            if (responseMessage.IsSuccessStatusCode)
            {
                return new WikipediaFile()
                {
                    ContentLength = responseMessage.Content.Headers.ContentLength ?? -1,
                    ContentType = responseMessage.Content.Headers.ContentType?.MediaType ?? "text/javascript",
                    Stream = await responseMessage.Content.ReadAsStreamAsync()
                };
            }

            return null;
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public DataClient() : base() { }
    }


    /// <summary>
    /// Type of CSS to be returned by <see cref="DataClient.GetCss"/>
    /// </summary>
    public enum CssType
    {
        /// <summary>
        /// Common mobile CSS from ResourceLoader
        /// </summary>
        Base = 0,

        /// <summary>
        /// CSS from wikimedia-page-library
        /// </summary>
        PageLib,

        /// <summary>
        /// Site-specific, mobile CSS from ResourceLoader, as defined in MediaWiki:Mobile.css
        /// </summary>
        Site
    }

    /// <summary>
    /// Type of javascript to be returned
    /// </summary>
    public enum JavaScriptType
    {
        /// <summary>
        /// Wikimedia page library
        /// </summary>
        PageLib,

        /// <summary>
        /// Javascript that is intended to be run at the start of the body tag to apply settings with the wikimedia-page-library
        /// </summary>
        PageLib_Body_Start,

        /// <summary>
        /// Javascript that is intended to be run at the end of the body tag to apply settings with the wikimedia-page-library
        /// </summary>
        PageLib_Body_End
    }
}
