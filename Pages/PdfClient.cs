using SujaySarma.Sdk.RestApi;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SujaySarma.Sdk.WikipediaApi.Pages
{
    /// <summary>
    /// Implements the "/page/pdf" endpoint. Allows downloading of Wikipedia.org pages 
    /// as PDF files.
    /// </summary>
    public class PdfClient : PageClient
    {

        /// <summary>
        /// Gets the provided page as a PDF downloadable
        /// </summary>
        /// <param name="pageName">Exact title for the page. Function will convert spaces to underscores ('_').</param>
        /// <param name="pageSize">Size of page to use. Defaults to Letter size.</param>
        /// <param name="mobileOptimized">If set, gets mobile-optimized PDF (defaults to desktop)</param>
        /// <returns>DownloadableArtifact information. NULL on errors.</returns>
        public async Task<WikipediaFile?> GetPDF(string pageName, PageSize pageSize = PageSize.Letter, bool mobileOptimized = false)
        {
            if (string.IsNullOrWhiteSpace(pageName))
            {
                throw new ArgumentNullException(nameof(pageName));
            }

            if (!Enum.IsDefined(typeof(PageSize), pageSize))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            StringBuilder uri = new();
            uri.Append(ENDPOINT_BASE_URI).Append("/page/pdf/")
                .Append(pageName.Replace(" ", "_")).Append("/")
                    .Append(Enum.GetName(typeof(PageSize), pageSize)!.ToLower()).Append('/')
                        .Append((mobileOptimized ? "mobile" : "desktop"));

            // Since we get a download, we cannot use the GET() method in the base.
            RestApiClient client = RestApiClient.CreateBuilder()
                .WithRequestUri(new Uri(uri.ToString()))
                .WithHeader("Accept", "application/pdf");
            HttpResponseMessage responseMessage = await client.Get();
            if (responseMessage.IsSuccessStatusCode)
            {
                return new WikipediaFile()
                {
                    ContentLength = responseMessage.Content.Headers.ContentLength ?? -1,
                    ContentType = responseMessage.Content.Headers.ContentType?.MediaType ?? "application/pdf",
                    Stream = await responseMessage.Content.ReadAsStreamAsync()
                };
            }

            return null;
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public PdfClient() : base() { }
    }


    /// <summary>
    /// Page size to use to render the PDF
    /// </summary>
    public enum PageSize
    {
        /// <summary>
        /// A4 size
        /// </summary>
        A4,

        /// <summary>
        /// Letter size
        /// </summary>
        Letter,

        /// <summary>
        /// Legal size
        /// </summary>
        Legal
    }
}
